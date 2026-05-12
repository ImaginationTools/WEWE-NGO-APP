using SQLite;
using System;

namespace WEWE.Maui.Models
{
    public class CaseLog
    {
        [PrimaryKey, AutoIncrement]
        public long LogID { get; set; }

        [Indexed, NotNull]
        public Guid CaseID { get; set; }
        public string StaffRemark { get; set; } = string.Empty;
        [NotNull]
        public Guid AccessedBy { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
}
