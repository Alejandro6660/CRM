
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM_Service.Entitys
{
    /// <summary>
    /// Clase que representa a un usuario del sistema.
    /// </summary>
    [Table("User")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(100)]
        public string NameUser { get; set; }
        
        [Required]
        [MaxLength(20)]
        public string Initials { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Phone { get; set; }
        
        [Required]
        public string PhoneEmergency { get; set; }

        [Required]
        public string Address { get; set; }
        
        [Required]
        public string ZIP { get; set; }


        [MaxLength(100)]
        public string? RFC { get; set; }

        public bool? IsPayroll { get; set; }

        public DateTime? CreatedDate { get; set; }

        [ForeignKey("Documents")]
        public long ImageId { get; set; }
        public virtual Document? Image { get; set; }
        
        [ForeignKey("Documents")]
        public long DocumentId { get; set; }
        public virtual Document? Signature { get; set; }

        [ForeignKey("RolUser")]
        public int RolUserId { get; set; }
        public virtual RolUser? RolUser { get; set; }
    }
}
