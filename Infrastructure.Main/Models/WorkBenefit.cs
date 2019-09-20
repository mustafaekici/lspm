using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Main.Models
{
   public class WorkBenefit
    {
        public int WorkBenefitID { get; set; }
        public int WorkCodeID { get; set; }
        public int BenefitTypeID { get; set; }
        public DateTime ModifiedDate { get; set; }

        public WorkCode WorkCode { get; set; }
        public BenefitType BenefitType { get; set; }
    }
}
