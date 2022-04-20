
namespace WebProject.Sevices;

public class EmailSender : IEmailSender
{
    public void SendEmail(string toEmail, string subject, string message, bool isMessageHtml = false)
    {
        using (var client = new System.Net.Mail.SmtpClient())
        {
            var cred = new System.Net.NetworkCredential
            {
                UserName = "nikravesh.works",
                Password = "12as34df@",

            };
            client.Port = 587;
            client.EnableSsl = true;
            client.Credentials = cred;
            client.Host = "smtp.gmail.com";
            using var email = new System.Net.Mail.MailMessage()
            {

                Body = message,
                Subject = subject,
                IsBodyHtml = isMessageHtml,
                To = { new System.Net.Mail.MailAddress(toEmail) },
                From = new System.Net.Mail.MailAddress("nikravesh.Works@gmail.com"),
            };
            client.Send(email);
        }
    }
}
