using StudyThink.Domain.Entities;

namespace StudyThink.Service.DTOs.Payment
{
    public class PaymentUpdateDto : BaseEntity
    {
        public string Type { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public int CourseId { get; set; }
    }
}
