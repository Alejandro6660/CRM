using CRM_Service.Enums;
using DocumentFormat.OpenXml.Office2010.Word;
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
    [Table("logDocument")]
    public class logsDocument
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        [ForeignKey("Documents")]
        public int DocumentId { get; set; }
        public virtual Document Document { get; set; }

        public string? Coment {  get; set; }

        public DateTime? CreatedDate { get; set; }

        [Required]
        public StatusDocument StatusChange { get; set; }
    }
}
