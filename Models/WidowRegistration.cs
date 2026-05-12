using SQLite;
using System;

namespace WEWE.Maui.Models
{
    public class WidowRegistration
    {
        [PrimaryKey, Unique]
        public Guid WidowID { get; set; } = Guid.NewGuid();

        [MaxLength(150), NotNull]
        public string FullName { get; set; } = string.Empty;

        [MaxLength(50), Unique, NotNull]
        public string NationalID { get; set; } = string.Empty;

        [MaxLength(20), Unique, NotNull]
        public string PhoneNumber { get; set; } = string.Empty;

        [NotNull]
        public DateTime DOB { get; set; }

        public int DependentsCount { get; set; } = 0;
        public decimal MonthlyIncome { get; set; } = 0.00M;
        public bool HasDisability { get; set; }
        public string HousingStatus { get; set; } = string.Empty;

        public string VulnerabilityTier
        {
            get
            {
                if (MonthlyIncome < 5000 && DependentsCount > 4) return "Critical";
                if (MonthlyIncome < 15000) return "High";
                return "Moderate";
            }
        }

        [MaxLength(100), NotNull]
        public string LGA { get; set; } = string.Empty;

        [MaxLength(100), NotNull]
        public string State { get; set; } = String.Empty;

        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

        public bool IsQuarantined { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }
}
