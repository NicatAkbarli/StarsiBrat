using System;

public class VerificationCodeHelper
{
    private static string generatedCode;

    public static string GenerateVerificationCode()
    {
        Random random = new Random();
        generatedCode = random.Next(100000, 999999).ToString(); // 6 haneli kod
        return generatedCode;
    }

    public static void SendVerificationCode(string toEmail)
    {
        string code = GenerateVerificationCode();
        string subject = "Email Verification Code";
        string body = $"Your verification code is: {code}";

        EmailHelper.SendEmail(toEmail, subject, body);
        Console.WriteLine("Verification code sent to " + toEmail);
    }

    public static bool ValidateCode(string inputCode)
    {
        return inputCode == generatedCode;
    }
}
