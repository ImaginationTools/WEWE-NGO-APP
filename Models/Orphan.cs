using System;
using SQLite;
using System;

namespace WEWE.Maui.Models
{
    public class Orphan
    {
        [PrimaryKey, Unique]
        public Guid OrphanID { get; set; } = Guid.NewGuid();

        [Indexed, NotNull]
        public Guid WidowID { get; set; }

        [MaxLength(150), NotNull]
        public string FullName { get; set; } = string.Empty;

        [MaxLength(10)]
        public string Gender { get; set; } = string.Empty;  // Male, Female, Other  

        public int Age { get; set; }

        [MaxLength(20)]
        public string SchoolStatus { get; set; } = string.Empty; // In-School, Out-of-School, Vocational 

        [MaxLength(512)]
        public string PhotoURL { get; set; } = string.Empty;
    }
}