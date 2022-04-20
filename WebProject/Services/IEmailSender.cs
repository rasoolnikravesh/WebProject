namespace WebProject.Sevices;

public interface IEmailSender
{
    void SendEmail(string toEmail, string subject, string message, bool isMessageHtml = false);
}

