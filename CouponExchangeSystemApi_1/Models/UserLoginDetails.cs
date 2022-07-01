using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CouponExchangeSystemApi_1.Models
{
    public class UserLoginDetails
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public UserDetails UserDetails { get; set; }
        
        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string Password { get; set; }
        
        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(100)]
        public string UserName { get; set; }
        
        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(20)]
        public string UserRole { get; set; }
    }
}
