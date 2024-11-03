namespace AnnouncementApp.Models{
    public class AnnouncementModel{
        public int Id{get; set;}
        public string? Title{get; set;}
        public string? Text{get; set;}
        public string? ResponsiblePerson{get; set;}
        public DateTime AnnouncementDate {get; set;} //Eklenen tarih
    }
}