
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using myPictures.Data;
using myPictures.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.Processing;
using Microsoft.AspNetCore.Identity;

namespace myPictures.Areas.Identity.Pages.Account
{
    [Authorize]
    public class AvatarModel : PageModel
    {
        private IWebHostEnvironment _environment;
        public UserManager<BetterUser> _userManager;
        private ApplicationDbContext _context;
        private int _size = 200;

        [TempData]
        public string SuccessMessage { get; set; }
        [TempData]
        public string ErrorMessage { get; set; }

        public IFormFile Upload { get; set; }

        public AvatarModel(ApplicationDbContext context, IWebHostEnvironment environment, UserManager<BetterUser> userManager)
        {
            _environment = environment;
            _userManager = userManager;
            _context = context;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var userId = User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value;
            var user = _userManager.Users.Where(c => c.Id == userId).FirstOrDefault();
            if (Upload.ContentType.StartsWith("image"))
            {
                MemoryStream ims = new MemoryStream();
                MemoryStream oms = new MemoryStream();
                Upload.CopyTo(ims);
                user.IconImageType = Upload.ContentType;
                user.IconImage = ims.ToArray();
                _context.SaveChanges();
            }
            return RedirectToPage("/Index");
        }
    }
}
