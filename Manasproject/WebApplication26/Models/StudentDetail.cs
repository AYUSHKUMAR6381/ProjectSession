using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace WebApplication26.Models
{
    public partial class StudentDetail
    {
        public StudentDetail()
        {
            AttendanceDetails = new HashSet<AttendanceDetail>();
            MarksDetails = new HashSet<MarksDetail>();
        }

        public int PkStudentId { get; set; }
        public string EnrollId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Contact { get; set; }
        public string Address { get; set; }
        public string Pswd { get; set; }
        public string Course { get; set; }
        public string FatherName { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public string studentPic { get; set; }
        [NotMapped]

        public IFormFile PProfilepic { get; set; }
        public virtual ICollection<AttendanceDetail> AttendanceDetails { get; set; }
        public virtual ICollection<MarksDetail> MarksDetails { get; set; }
    }
}
