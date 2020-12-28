using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication26.Models
{
    public partial class MarksDetail
    {
        public int PkMarksId { get; set; }
        public int? FkSemId { get; set; }
        public int? FkStudId { get; set; }
        public int? FkSubId { get; set; }
        public double? SessionalMarks { get; set; }
        public double? MainExamMarks { get; set; }
        public double? TotalMarks { get; set; }

        public virtual MstSemester FkSem { get; set; }
        public virtual StudentDetail FkStud { get; set; }
        public virtual MstSubject FkSub { get; set; }
    }
}
