using SQLite;
using System;

namespace WEWE.Maui.Models
{
    public class Case
    {
        [PrimaryKey, Unique]
        public Guid CaseID { get; set; } = Guid.NewGuid();

        [Indexed, NotNull]
        public Guid WidowID { get; set; }

        [MaxLength(150)]
        public string Subject { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        [MaxLength(20)]
        public string Status { get; set; } = "Open"; // Open, In-Progress, Resolved 

        [MaxLength(10)]
        public string Priority { get; set; } = string.Empty; // Low, Medium, High 
    }
}