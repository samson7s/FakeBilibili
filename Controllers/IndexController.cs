using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FakeBilibili.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndexController : ControllerBase
    {
        private readonly string _resourcesLocation = Path.Combine(Directory.GetCurrentDirectory(), "IndexResources");
        private readonly string _picFormat = "image/jpeg";

        [Route(nameof(GetNavbarPic))]
        public IActionResult GetNavbarPic()
        {
            string navbarPicLocation = Path.Combine(_resourcesLocation, "cnblogs.jpg");
            if (System.IO.File.Exists(navbarPicLocation))
            {
                return File(navbarPicLocation, _picFormat);
            }

            return null;
        }
    }
}