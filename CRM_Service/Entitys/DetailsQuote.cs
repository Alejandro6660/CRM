using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM_Service.Enums;

namespace CRM_Service.Entitys
{
    /// <summary>
    /// Clase que representa los detalles de una cotización.
    /// </summary>
    [Table("DetailsQuote")]
    public class DetailsQuote
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Code { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Required]
        public DateTime Created { get; set; } = DateTime.Now;

        public DateTime? DateModify { get; set; }

        [Required]
        public StatusGeneral Status { get; set; }

        [MaxLength]
        public string? ComentStatus { get; set; }

        [ForeignKey("Product")]
        public long? ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
