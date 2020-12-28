using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication26.Models
{
    public partial class MstSemester
    {
        public MstSemester()
        {
            MarksDetails = new HashSet<MarksDetail>();
            MstSubjects = new HashSet<MstSubject>();
        }

        public int PkSemId { get; set; }
        public int? Semester { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<MarksDetail> MarksDetails { get; set; }
        public virtual ICollection<MstSubject> MstSubjects { get; set; }
    }
}
