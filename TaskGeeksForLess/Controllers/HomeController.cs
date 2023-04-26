using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using TaskGeeksForLess.Data;
using TaskGeeksForLess.IServices;
using TaskGeeksForLess.Models;

namespace TaskGeeksForLess.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TaskGeeksForLessContext _context;
        private readonly ICatalogService _service;

        public HomeController(ILogger<HomeController> logger, TaskGeeksForLessContext context, ICatalogService service)
        {
            _logger = logger;
            _context = context;
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Catalog(string? path, string? name)
        {
            if (string.IsNullOrEmpty(name))
            {
                var thisFolder = _context.Folders.FirstOrDefault(x => x.Path == "");
                ViewBag.Name = thisFolder.Name;

                var attachedFolder = _context.Folders.Where(x => x.FolderId == thisFolder.Id).ToList();

                return View(attachedFolder);
            }
            else
            {

                var thisFolder = _context.Folders.FirstOrDefault(x => x.Path == path && x.Name == name);
                ViewBag.Name = thisFolder.Name;

                var attachedFolder = _context.Folders.Where(x => x.FolderId == thisFolder.Id).ToList();

                return View(attachedFolder);
            }

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}