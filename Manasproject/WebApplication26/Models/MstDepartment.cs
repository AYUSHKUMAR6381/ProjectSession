using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication26.Models
{
    public partial class MstDepartment
    {
        public MstDepartment()
        {
            FacultyDetails = new HashSet<FacultyDetail>();
        }

        public int PkDeptId { get; set; }
        public string DepartmentName { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<FacultyDetail> FacultyDetails { get; set; }
    }
}
