using CRM_Service.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CRM_Service.Entitys
{
    /// <summary>
    /// Clase que representa a un usuario del sistema.
    /// </summary>
    [Table("Customer")]
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(20)]
        public string Initials { get; set; }

        [Required]
        [MaxLength]
        public string Email { get; set; }

        [Required]
        [MaxLength]
        public string Phone { get; set; }

        [Required]
        [StringLength(100)]
        public string Country { get; set; }

        [Required]
        [MaxLength]
        public string Address { get; set; }

        [Required]
        [StringLength(100)]
        public string City { get; set; }

        [Required]
        [StringLength(100)]
        public string State { get; set; }

        [Required]
        [MaxLength]
        public string ZIP { get; set; }


        [Required]
        [StringLength(100)]
        public string Name_Dealer { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName_Dealer { get; set; }

        [Required]
        [MaxLength]
        public string Email_Dealer { get; set; }

        [Required]
        [MaxLength]
        public string Phone_Dealer { get; set; }

        [StringLength(100)]
        public string? BillingCountry { get; set; }

        [StringLength(100)]
        public string? BillingAddress { get; set; }

        [StringLength(100)]
        public string? BillingCity { get; set; }

        [StringLength(100)]
        public string? BillingState { get; set; }

        [StringLength(100)]
        public string? BillingZIP { get; set; }

        public DateTime Created { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

        public StatusCustomer Status { get; set; }

        [MaxLength]
        public string? CommentStatus { get; set; }

        [ForeignKey("Documents")]
        public long ImageId { get; set; } 
        public virtual Document Image { get; set; }
    }
}
