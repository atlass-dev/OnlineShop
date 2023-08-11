using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.WebEncoders.Testing;
using OnlineShop.Infrastructure.Common.Exceptions;
using System.Text;

namespace OnlineShop.Infrastructure.Middlewares;

/// <summary>
/// Global exception handler.
/// </summary>
public class ApiExceptionMiddleware
{
    private const string ProblemJsonMimeType = @"application/problem+json";

    private readonly RequestDelegate next;
    private readonly IJsonHelper jsonHelper;
    private readonly HtmlTestEncoder encoder = new();

    private static readonly IDictionary<Type, int> ExceptionStatusCodes = new Dictionary<Type, int>
    {
        [typeof(NotFoundException)] = StatusCodes.Status404NotFound,
        [typeof(NotImplementedException)] = StatusCodes.Status501NotImplemented,
        [typeof(DomainException)] = StatusCodes.Status400BadRequest
    };

    /// <summary>
    /// Constructor.
    /// </summary>
    public ApiExceptionMiddleware(RequestDelegate next, IJsonHelper jsonHelper)
    {
        this.next = next;
        this.jsonHelper = jsonHelper;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            var problemDetails = GetObjectByException(ex);
            problemDetails.Instance = context.Request.Path;
            context.Response.Clear();
            context.Response.StatusCode = problemDetails.Status ?? StatusCodes.Status500InternalServerError;
            context.Response.ContentType = ProblemJsonMimeType;

            await using var stringWriter = new StringWriter(new StringBuilder(200));
            jsonHelper.Serialize(problemDetails).WriteTo(stringWriter, encoder);
            await context.Response.WriteAsync(stringWriter.ToString());
        }
    }

    private ProblemDetails GetObjectByException(Exception exception)
    {
        // Prepare model.
        var problem = new ProblemDetails();
        var statusCode = StatusCodes.Status400BadRequest;

        var errors = new List<ProblemFieldDto>();

        switch (exception)
        {
            case ValidationException validationException:
                problem.Type = "ModelValidation";
                problem.Title = "Validation failed";

                errors.AddRange(ParseToProblemFields(validationException.Errors));

                break;

            case DomainException domainException:
                AddExceptionInfoToProblemDetails(problem, domainException);
                statusCode = GetStatusCodeByExceptionType(domainException.GetType());
                errors.Add(new ProblemFieldDto(string.Empty, new string[] { exception.Message }));
                break;
        }

        problem.Status = statusCode;
        problem.Extensions["errors"] = errors;

        return problem;
    }

    private static void AddExceptionInfoToProblemDetails(ProblemDetails problemDetails, DomainException exception)
    {
        problemDetails.Title = exception.Message;
        problemDetails.Type = exception.GetType().Name;
        AddCodeToProblemDetails(problemDetails, exception.Code);
    }

    private static void AddCodeToProblemDetails(ProblemDetails problemDetails, string code)
    {
        if (!string.IsNullOrEmpty(code))
        {
            problemDetails.Extensions["code"] = code;
        }
    }

    private static int GetStatusCodeByExceptionType(Type exceptionType)
    {
        // Most probable case.
        if (exceptionType == typeof(DomainException))
        {
            return StatusCodes.Status400BadRequest;
        }
        foreach ((Type exceptionTypeKey, int statusCode) in ExceptionStatusCodes)
        {
            if (exceptionTypeKey.IsAssignableFrom(exceptionType))
            {
                return statusCode;
            }
        }
        return StatusCodes.Status500InternalServerError;
    }

    private static IEnumerable<ProblemFieldDto> ParseToProblemFields(IEnumerable<ValidationFailure> validationFailures)
    {
        var validationFailuresByPropertyName = validationFailures
            .GroupBy(_ => _.PropertyName);

        foreach (var validationFailureByPropertyName in validationFailuresByPropertyName)
        {
            string field = validationFailureByPropertyName.Key;

            var messages = validationFailureByPropertyName
                .Select(_ => _.ErrorMessage);

            yield return new ProblemFieldDto(field, messages);
        }
    }
}
