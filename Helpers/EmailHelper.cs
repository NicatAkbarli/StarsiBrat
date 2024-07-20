using System;
using System.Net;
using System.Net.Mail;

public class EmailHelper
{
    public static void SendEmail(string toEmail, string subject, string body)
    {
        string fromEmail = "hesidi22@gmail.com";  // Kendi email adresinizi yazın
        string fromPassword = "Nicat2005";       // Kendi email şifrenizi yazın

       MailMessage mail = new MailMessage();
        mail.From = new MailAddress(fromEmail);
        mail.To.Add(toEmail);
        mail.Subject = subject;
        mail.Body = body;

        SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587); // Gmail SMTP server adresi ve portu
        smtpClient.Credentials = new NetworkCredential(fromEmail, fromPassword);
        smtpClient.EnableSsl = true;

        try
        {
            smtpClient.Send(mail);
            Console.WriteLine("Email sent successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error sending email: " + ex.Message);
        }
    }
}
