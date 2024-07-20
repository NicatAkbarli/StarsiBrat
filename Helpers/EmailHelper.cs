using System;
using MailKit.Net.Smtp;
using MimeKit;

public class EmailHelper
{
    public static void SendEmail(string toEmail, string subject, string body)
    {
        // E-posta mesajını oluştur
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress("Nicat", "nicatakbarli571@gmail.com")); // Gönderen e-posta adresi
        message.To.Add(new MailboxAddress("", toEmail)); // Alıcı e-posta adresi
        message.Subject = subject; // E-posta konusu

        // E-posta içeriğini ayarla
        message.Body = new TextPart("plain")
        {
            Text = body
        };

        // SMTP istemcisi ile e-posta gönderimi
        using (var client = new SmtpClient())
        {
            try
            {
                // SMTP sunucusuna bağlan
                client.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                
                // Kimlik doğrulama
                // Uygulama şifresi kullanılmalı
                client.Authenticate("nicatakbarli571@gmail.com", "uuiz mfrj uvnp qhex");
                
                // E-postayı gönder
                client.Send(message);
                Console.WriteLine("Email sent successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error sending email: " + ex.Message);
            }
            finally
            {
                // Bağlantıyı kes
                client.Disconnect(true);
            }
        }
    }
}
