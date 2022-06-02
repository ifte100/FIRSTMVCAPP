using System.ComponentModel.DataAnnotations;
namespace WebApplication1.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
