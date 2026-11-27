namespace SmartCampusPortal.Models
{
    public class Complaint
    {
        public int ComplaintId { get; set; }

        public int StudentId { get; set; }

        public string Title { get; set; } = "";

        public string Description { get; set; } = "";

        public string Status { get; set; } = "Pending";
    }
}
