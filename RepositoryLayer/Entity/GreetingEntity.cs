using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepositoryLayer.Entity
{
   
    public class GreetingEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Message { get; set; }
    }
}
