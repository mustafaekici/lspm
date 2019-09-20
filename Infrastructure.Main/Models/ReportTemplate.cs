using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Main.Models
{
    public class ReportTemplate
    {

        public int ReportTemplateID { get; set; }
        public int TemplateTypeID { get; set; }
        [MaxLength(50)]
        public string Description { get; set; }
        public string FileName { get; set; }
        public bool IsSystemTemplate { get; set; }

        public byte[] Template { get; set; }
        public DateTime ModifiedDate { get; set; }

        public TemplateType TemplateType { get; set; }

 
    }
}
