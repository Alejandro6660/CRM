using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_Service.Entitys
{
    /// <summary>
    /// Clase que representa a un usuario del sistema.
    /// </summary>
    [Table("RelUserPage")]
    public class RelUserPage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        ///  Relacion con Pages
        /// </summary>

        [ForeignKey("Page")]
        public Int64 PageId { get; set; }
        public virtual Page? Page { get; set; }

        /// <summary>
        ///  Relacion con User
        /// </summary>

        [ForeignKey("User")]
        public Int64 UserId { get; set; }
        public virtual User? User { get; set; }
    }
}
