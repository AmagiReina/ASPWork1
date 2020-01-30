using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Entities
{
    public class Order
    {   
        [Key]
        public int Id { get; set; }

        [ForeignKey("Users")]
        public int UserId { get; set; }

        [ForeignKey("Books")]
        public int BookId { get; set; }

        public User Users { get; set; }

        public Book Books { get; set; }
    }
}