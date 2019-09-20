using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Main.Models
{
    public class TemplateType
    {
        public int TemplateTypeID { get; set; }
        [MaxLength(50)]
        public string TemplateTypeInfo { get; set; }
        public DateTime ModifiedDate { get; set; }
        public ICollection<ReportTemplate> ReportTemplates { get; set; }
    }
}
