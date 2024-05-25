using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_Service.Entitys
{
    /// <summary>
    /// Clase que representa a un usuario del sistema.
    /// </summary>
    [Table("DocumentGroup")]
    public class DocumentGrouper
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 Id { get; set; }

        [Required]
        [MaxLength(100)]
        public Int64 Consecutive { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }
    }
}
