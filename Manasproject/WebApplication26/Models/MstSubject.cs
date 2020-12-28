using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication26.Models
{
    public partial class MstSubject
    {
        public MstSubject()
        {
            MarksDetails = new HashSet<MarksDetail>();
        }

        public int PkSubjectId { get; set; }
        public int? FkSemId { get; set; }
        public string SubjectName { get; set; }
        public bool? IsActive { get; set; }

        public virtual MstSemester FkSem { get; set; }
        public virtual ICollection<MarksDetail> MarksDetails { get; set; }
    }
}
