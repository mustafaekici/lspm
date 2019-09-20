using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Main.Models
{
    public class NoteType
    {
        public int NoteTypeID { get; set; }
        
        public string NoteTypeName { get; set; }
        public DateTime ModifiedDate { get; set; }

        public ICollection<ProjectNote> ProjectNotes { get; set; }
    }
}
