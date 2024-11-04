using System.ComponentModel.DataAnnotations;
namespace AnnouncementApp.Models{
    public class AnnouncementModel{
        public int Id{get; set;}
        [Required(ErrorMessage = "Başlık gereklidir.")]
        public string? Title{get; set;}
        [Required(ErrorMessage = "İçerik gereklidir.")]
        public string? Text{get; set;}
        [Required(ErrorMessage = "Sorumlu kişi gereklidir.")]
        public string? ResponsiblePerson{get; set;}
        public DateTime AnnouncementDate {get; set;} //Eklenen tarih
    }
}