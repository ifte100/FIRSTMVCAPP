using System.ComponentModel.DataAnnotations;
namespace WebApplication1.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Range(1,10,ErrorMessage="Quantity should be less than 10!")]
        public int Quantity { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
