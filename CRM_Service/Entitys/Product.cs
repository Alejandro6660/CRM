using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using CRM_Service.Enums;

namespace CRM_Service.Entitys
{
    /// <summary>
    /// Clase que representa a un usuario del sistema.
    /// </summary>
    [Table("Product")]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        [MaxLength(20)]
        public string Code { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Required]
        public int ProductType { get; set; }

        [Required]
        public DateTime Created { get; set; } = DateTime.Now;

        public DateTime? DateModify { get; set; }

        [Required]
        public StatusProduct Status { get; set; }

        [MaxLength]
        public string ComentStatus { get; set; }

        [Required]
        public long Stock { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? Weight { get; set; }

        public string Dimencion { get; set; }

        [MaxLength(100)]
        public string Brand { get; set; }

        [Required]
        public int UnitOfMeasure { get; set; }


        [ForeignKey("ImageId")]
        public Int64? ImageId { get; set; }
        public virtual Document Document { get; set; }
    }
}
