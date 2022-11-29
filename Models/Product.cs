using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Akhil_API.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string Description { get; set; } = string.Empty;
        public bool IsAvailable { get; set; }
        [Required]
        public int CategoyId { get; set; }
        [JsonIgnore]
        public virtual Category? Category { get; set; }

    }
}
