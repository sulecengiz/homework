using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AnnouncementApp.Models; // Announcement.Models isim alanını kullandığınızdan emin olun.
using System.Collections.Generic;

namespace AnnouncementApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    // Anasayfa: duyuruları listele
    public IActionResult Index()
    {
        ViewData["Title"] = "Duyuru Listesi";
        var announcements = Repository.Announcements; // Repository'den duyuruları al
        ViewBag.TotalAnnouncements = announcements.Count;
        ViewBag.CurrentDateTime = DateTime.Now;
        return View(announcements); // Duyuruları view'a gönder
    }

    // Yeni duyuru oluşturma sayfası
    [HttpGet]
    public IActionResult Create()
    {
        ViewData["Title"] = "Yeni Duyuru Ekle";
        //ViewData["CssFile"] = "create"; // Doğru CSS dosyası adı
        return View();
    }

    // Yeni duyuruyu kaydetme
    [HttpPost]
    public IActionResult Create(AnnouncementModel announcement)
    {
        announcement.Id = Repository.Announcements.Count + 1; // Basit bir Id ataması
        announcement.AnnouncementDate = DateTime.Now; // Eklenme tarihini ayarla
        Repository.Announcements.Add(announcement);
        return RedirectToAction("Index");
    }

    // Duyuru detay sayfası
    public IActionResult Details(int id)
    {
        var announcement = Repository.Announcements.Find(a => a.Id == id);
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
