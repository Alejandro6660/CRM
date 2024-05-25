using CRM_Service.Enums;
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
    [Table("Document")]
    public class Documents
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 Id { get; set; }

        [Required]
        public string Title { get; set; }
        
        [Required]
        public string FileName { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public TypesDocuments DocumentType { get; set; }
        
        [Required]
        [MaxLength(20)]
        public string FileExtension { get; set; }
        
        [Required]
        public string FilePath { get; set; }
        
        [Required]
        public string FileSize { get; set; }
        
        [Required]
        public int Version { get; set; }
        
        [Required]
        public DateTime CreatedDate { get; set; }
        
        [Required]
        public DateTime DateModified { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

        [Required]
        public StatusDocument Status { get; set; } 

        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        [ForeignKey("DocumentGrouper")]
        public int GroupId { get; set; }
        public virtual DocumentGrouper DocumentGrouper { get; set; }
    }
}
