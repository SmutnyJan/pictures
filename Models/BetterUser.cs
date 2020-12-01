using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myPictures.Models
{
    public class BetterUser : IdentityUser
    {
        public byte[] IconImage { get; set; }
        public string IconImageType { get; set; }
    }
}
