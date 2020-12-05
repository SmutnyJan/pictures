using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using myPictures.Models;

namespace myPictures.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private UserManager<BetterUser> _userManager;
        public List<BetterUser> Users { get; set; }


        public IndexModel(ILogger<IndexModel> logger, UserManager<BetterUser> userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }

        public void OnGet()
        {
            Users = _userManager.Users.ToList();
        }
    }
}
