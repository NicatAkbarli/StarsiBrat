using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter your email: ");
        string userEmail = Console.ReadLine();

        // Doğrulama kodunu gönder
        VerificationCodeHelper.SendVerificationCode(userEmail);

        // Kullanıcıdan doğrulama kodunu al
        Console.Write("Enter the verification code: ");
        string userInputCode = Console.ReadLine();

        // Doğru kodu kontrol et
        if (VerificationCodeHelper.ValidateCode(userInputCode))
        {
            Console.WriteLine("Email verified successfully. You are now logged in.");
        }
        else
        {
            Console.WriteLine("Invalid verification code. Please try again.");
        }
    }
}
