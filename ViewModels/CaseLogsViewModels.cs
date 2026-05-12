using SQLite;
using System;

namespace WEWE.Maui.Models
{
    public class CaseLogs
    {
        [PrimaryKey, Unique]
        public Guid CaseLogID { get; set; } = Guid.NewGuid();

        [Indexed, NotNull]
        public Guid CaseID { get; set; } // Links to Case

        [MaxLength(100)]
        public string ActionType { get; set; } = string.Empty;
        // e.g. "Created", "Updated", "Visit", "Comment", "StatusChanged"

        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;

        public DateTime ActionDate { get; set; } = DateTime.UtcNow;

        [NotNull]
        public Guid OfficerID { get; set; }

        [MaxLength(100)]
        public string LGA { get; set; } = string.Empty;
    }
}