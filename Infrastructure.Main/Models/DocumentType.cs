using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Main.Models
{
    public class DocumentType
    {
        public int DocumentTypeID { get; set; }

        public int ParentID { get; set; }
        [MaxLength(50)]
        public string Executable { get; set; }
        [MaxLength(50)]
        public string Extensions { get; set; }
        [MaxLength(80)]
        public string Description { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
