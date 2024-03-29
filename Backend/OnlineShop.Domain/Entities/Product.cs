﻿using OnlineShop.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Domain.Entities;

/// <summary>
/// Represents an entity of product.
/// </summary>
public class Product
{
    /// <summary>
    /// Product's id.
    /// </summary>
    public int Id { get; private set; }

    /// <summary>
    /// Product's name.
    /// </summary>
    [MaxLength(150)]
    [Required]
    required public string Name { get; set; }

    /// <summary>
    /// Product's descrtiption.
    /// </summary>
    [MaxLength(1000)]
    [Required]
    required public string Description { get; set; }

    /// <summary>
    /// Product's price.
    /// </summary>
    [Required]
    required public decimal Price { get; set; }

    /// <summary>
    /// Product's rating.
    /// </summary>
    public double Rating => Reviews.Count() > 0 ? Reviews.Average(r => r.Rating) : 0.0;

    /// <summary>
    /// Product's category.
    /// </summary>
    [Required]
    required public Category Category { get; set; }

    /// <summary>
    /// Seller's id.
    /// </summary>
    required public int SellerId { get; set; }

    /// <summary>
    /// Seller.
    /// </summary>
    public User? Seller { get; set; }

    /// <summary>
    /// Product's creation date.
    /// </summary>
    [Required]
    required public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Product's removal date.
    /// </summary>
    public DateTime? RemovedAt { get; set; }

    /// <summary>
    /// Product's reviews.
    /// </summary>
    public IEnumerable<Review> Reviews { get; set; } = new List<Review>();

    /// <summary>
    /// Product's sales.
    /// </summary>
    public IEnumerable<Purchase> Purchases { get; set; } = new List<Purchase>();
}
