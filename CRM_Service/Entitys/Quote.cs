using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM_Service.Enums;
using DocumentFormat.OpenXml.Wordprocessing;

namespace CRM_Service.Entitys
{
    /// <summary>
    /// Clase que representa una cotización del sistema.
    /// </summary>
    [Table("Quote")]
    public class Quote
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Code { get; set; }

        public string Description { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Total { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Subtotal { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Discount { get; set; }

        [Required]
        public DateTime Created { get; set; } = DateTime.Now;

        [Required]
        [MaxLength]
        public string ShippingAddress { get; set; }

        [Required]
        [MaxLength]
        public string BuillingAddress { get; set; }

        public DateTime? DeliveryDate { get; set; }

        public DateTime? DateModify { get; set; }

        [Required]
        public StatusGeneral Status { get; set; }

        [MaxLength]
        public string? ComentStatus { get; set; }

        [ForeignKey("User")]
        public long? UserId { get; set; }
        public virtual User? User { get; set; }

        [ForeignKey("Customer")]
        public long? CustomerId { get; set; }
        public virtual Customer? Customer { get; set; }

        [ForeignKey("DetailsSale")]
        public long? DetailsSaleId { get; set; }
        public virtual DetailsQuote? DetailsSale { get; set; }

        [ForeignKey("Document")]
        public long? DocumentId { get; set; }
        public virtual Document? Document { get; set; }

        [ForeignKey("Incoterm")]
        public long? IncotermId { get; set; }
        public virtual Incoterm? Incoterm { get; set; }
    }
}
