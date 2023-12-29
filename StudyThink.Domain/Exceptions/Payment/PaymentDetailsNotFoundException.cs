namespace StudyThink.Domain.Exceptions.Payment;
public class PaymentDetailsNotFoundException:NotFoundException
{
    public PaymentDetailsNotFoundException()
    {
        TitleMessage = "Payment details not found";
    }
}
