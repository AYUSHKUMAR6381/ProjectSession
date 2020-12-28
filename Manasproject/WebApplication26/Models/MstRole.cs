using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication26.Models
{
    public partial class MstRole
    {
        public int PkRoleId { get; set; }
        public string RoleName { get; set; }
        public bool? IsActive { get; set; }
    }
}
