namespace StudyThink.Domain.Exceptions.Payment;

public class PaymentTypeException : NotFoundException
{
    public PaymentTypeException()
    {
        TitleMessage = "Payment type not found";
    }
}
