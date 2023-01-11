using MailKit.Security;
using MimeKit.Text;
using MimeKit;
using MailKit.Net.Smtp;

namespace SendEmail.Services.EmailService
{
    public class EmailService : IEmailService
    {
        public void SendEmail(EmailDto request)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("jack.wintheiser43@ethereal.email"));
            email.To.Add(MailboxAddress.Parse(request.To));
            email.Subject = request.Subject;
            email.Body = new TextPart(TextFormat.Html) { Text = request.Body };

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.ethereal.email", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("jack.wintheiser43@ethereal.email", "DsE1FvDUW89cGKFZZR");
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}
