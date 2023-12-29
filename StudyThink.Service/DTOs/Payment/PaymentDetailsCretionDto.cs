using StudyThink.Domain.Enums;

namespace StudyThink.Service.DTOs.Payment;

public class PaymentDetailsCretionDto
{
    public string CardHolderName { get; set; } = string.Empty;

    public string CardNumber { get; set; } = string.Empty;

    public string ExpirationDate { get; set; }

    public string CardCodeCVV { get; set; } = string.Empty;

    public string CardPhoneNumber { get; set; } = string.Empty;

    public long StudentId { get; set; }

    public PaymentStatus IsPaid { get; set; }

    public long CourseId { get; set; }
}
