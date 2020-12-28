using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication26.Models
{
    public partial class AttendanceDetail
    {
        public int PkAttndId { get; set; }
        public int? FkStudId { get; set; }
        public string Attendance { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual StudentDetail FkStud { get; set; }
    }
}
