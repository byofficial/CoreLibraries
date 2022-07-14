using System;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Swagger.API.Models
{
    /// <summary>
    /// Ürün nesnesi
    /// </summary>
    public partial class Product
    {
        /// <summary>
        /// Ürün id'si
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Ürün ismi
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Ürün Fiyatı
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Ürün Tarihi
        /// </summary>
        public DateTime? Date { get; set; }

        /// <summary>
        /// Ürün Kategorisi
        /// </summary>
        public string Category { get; set; }
    }
}