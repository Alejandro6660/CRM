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
    public class Document
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

        [Required]
        public Int64 UploadedByUserId { get; set; }

        [ForeignKey("UploadedByUserId")]
        public virtual User UploadedByUser { get; set; }

        [ForeignKey("DocumentGrouperId")]
        public Int64 DocumentGrouperId { get; set; }
        public virtual DocumentGrouper? DocumentGrouper { get; set; }
    }
}
