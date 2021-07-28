using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace work_01.Data
{
    public class ApplicationUser:IdentityUser
    {
        public string Name { get; set; }
        public string CellPhone { get; set; }
        public string Country { get; set; }

    }
}
