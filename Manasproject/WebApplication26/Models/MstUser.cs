using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication26.Models
{
    public partial class MstUser
    {
        public int PkUserId { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public string Pswd { get; set; }
        public DateTime Dob { get; set; }
        public DateTime CreatedDate { get; set; }
        public int FkRoleId { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
