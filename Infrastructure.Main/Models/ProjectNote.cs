using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Main.Models
{
    public class ProjectNote
    {
        public int ProjectNoteID { get; set; }

        public int ProjectID { get; set; }
        public int NoteTypeID { get; set; }
        public string NoteText { get; set; }
        public DateTime ModifiedDate { get; set; }

        public NoteType NoteType { get; set; }

        public Project Project { get; set; }
    }
}
