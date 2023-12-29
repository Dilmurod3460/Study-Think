using StudyThink.Domain.Enums;

namespace StudyThink.Domain.Entities.Payments;

public class Payment : BaseEntity
{

    public PaymentType Type { get; set; }
    public PaymentStatus Status { get; set; }
    public string Description { get; set; } = string.Empty;
    public long CourseId { get; set; }
}
