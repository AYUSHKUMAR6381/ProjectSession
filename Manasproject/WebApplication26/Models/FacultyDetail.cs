using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication26.Models
{
    public partial class FacultyDetail
    {
        public int PkFacultyId { get; set; }
        public string FacultyId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public string Pswd { get; set; }
        public int? FkDeptId { get; set; }
        public string FatherName { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual MstDepartment FkDept { get; set; }
    }
}
