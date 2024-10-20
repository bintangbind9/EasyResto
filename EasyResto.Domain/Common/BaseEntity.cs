using System.ComponentModel.DataAnnotations;

namespace EasyResto.Domain.Common
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<DateTime> CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<DateTime> UpdatedAt { get; set; }
        public string DeletedBy { get; set; }
        public Nullable<DateTime> DeletedAt { get; set; }
    }
}
