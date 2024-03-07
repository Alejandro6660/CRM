using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_Service.Entitys
{
    [Table("User")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string? Password { get; set; }

        public string? Phone { get; set; }
        [Required]
        public string? Addres { get; set; }
        [ForeignKey("Id")]
        [Required]
        public int RolUserId { get; set; }
        public virtual RolUser RolUser { get; set; }
        public string? Image { get; set; }

    }
}
