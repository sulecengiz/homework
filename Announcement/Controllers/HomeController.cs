using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AnnouncementApp.Models; // Announcement.Models isim alanını kullandığınızdan emin olun.
using System.Collections.Generic;

namespace AnnouncementApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    // Duyuru listesini tutmak için bir statik liste
    private static List<AnnouncementModel> announcements = new List<AnnouncementModel>
    {
        new AnnouncementModel { Id = 1, Title = "Duyuru 1", Text = "Bu bir duyurudur.", ResponsiblePerson = "Ali", AnnouncementDate = DateTime.Now },
        new AnnouncementModel { Id = 2, Title = "Duyuru 2", Text = "Bu başka bir duyurudur.", ResponsiblePerson = "Ayşe", AnnouncementDate = DateTime.Now }
    };

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    // Anasayfa: duyuruları listele
    public IActionResult Index()
    {
        ViewBag.TotalAnnouncements = announcements.Count;
        ViewBag.CurrentDateTime = DateTime.Now;
        return View(announcements);
    }

    // Yeni duyuru oluşturma sayfası
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    // Yeni duyuruyu kaydetme
    [HttpPost]
    public IActionResult Create(AnnouncementModel announcement)
    {
        announcement.Id = announcements.Count + 1; // Basit bir Id ataması
        announcement.AnnouncementDate = DateTime.Now; // Eklenme tarihini ayarla
        announcements.Add(announcement);
        return RedirectToAction("Index");
    }

    // Duyuru detay sayfası
    public IActionResult Details(int id)
    {
        var announcement = announcements.Find(a => a.Id == id);
        return View(announcement);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
