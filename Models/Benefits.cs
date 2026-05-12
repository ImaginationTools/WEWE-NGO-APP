using SQLite;
using System;

namespace WEWE.Maui.Models
{
    public class Benefit
    {
        [PrimaryKey, Unique]
        public Guid BenefitID { get; set; } = Guid.NewGuid();

        [MaxLength(10)]
        public string RecipientType { get; set; } = string.Empty; // Widow or Orphan 

        [Indexed, NotNull]
        public Guid RecipientID { get; set; }

        [MaxLength(50)]
        public string BenefitCategory { get; set; } = string.Empty; // Food, Cash, Education, Health 

        public decimal AmountValue { get; set; }
        public DateTime DateDelivered { get; set; } = DateTime.UtcNow;

        [NotNull]
        public Guid FieldOfficerID { get; set; }

        [MaxLength(100)]
        public string LGAOfDistribution { get; set; } = string.Empty;
    }
}