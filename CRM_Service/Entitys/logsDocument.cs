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

        [ForeignKey("UserId")]
        public Int64 UserId { get; set; }
        public virtual User User { get; set; }

        [ForeignKey("DocumentId")]
        public Int64 DocumentId { get; set; }
        public virtual Document Document { get; set; }

        public string? Coment {  get; set; }

        public DateTime? CreatedDate { get; set; }

        [Required]
        public StatusDocument StatusChange { get; set; }
    }
}
