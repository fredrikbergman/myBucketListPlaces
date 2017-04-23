using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using myBucketListPlaces.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace myBucketListPlaces.Controllers
{
    public class PlacesController : Controller
    {
        blpContext context;
        public PlacesController(blpContext context)
        {
            this.context = context;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(context.GetAllPlaces());
        }

        public IActionResult Details(int Id)
        {
            return View(context.GetPlace(Id));
        }
    }
}
