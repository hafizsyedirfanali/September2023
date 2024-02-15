using Microsoft.AspNetCore.Identity.UI.Services;
using MimeKit;
using MailKit;
using MailKit.Net.Smtp;

namespace MVCProject.Models
{
    public class MailService : IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            try
            {
                var senderEmail = "mohammadasuboor@gmail.com";
                using (MimeMessage emailMessage = new MimeMessage())
                {
                    MailboxAddress emailFrom = new MailboxAddress(senderEmail, senderEmail);
                    emailMessage.From.Add(emailFrom);
                    MailboxAddress emailTo = new MailboxAddress(email, email);
                    emailMessage.To.Add(emailTo);

                    // you can add the CCs and BCCs here.
                    //emailMessage.Cc.Add(new MailboxAddress("Cc Receiver", "cc@example.com"));
                    //emailMessage.Bcc.Add(new MailboxAddress("Bcc Receiver", "bcc@example.com"));

                    emailMessage.Subject = subject;

                    BodyBuilder emailBodyBuilder = new BodyBuilder();
                    emailBodyBuilder.TextBody = htmlMessage;

                    emailMessage.Body = emailBodyBuilder.ToMessageBody();
                    //this is the SmtpClient from the Mailkit.Net.Smtp namespace, not the System.Net.Mail one
                    using (SmtpClient mailClient = new SmtpClient())
                    {
                        await mailClient.ConnectAsync("smtp-relay.brevo.com", 587, MailKit.Security.SecureSocketOptions.None);
                        await mailClient.AuthenticateAsync("mohammadasuboor@gmail.com", "kmCKLXWaxVFUEhD4");
                        await mailClient.SendAsync(emailMessage);
                        await mailClient.DisconnectAsync(true);
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
    }
}
