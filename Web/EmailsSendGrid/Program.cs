using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;

namespace EmailsWithSendGrid
{
    
    class Program
    {
        private const string SG_API_KEY = "Enter your API Key from Send Grid";
        static async Task Main(string[] args)
        {
            try
            {
                var apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
                var client = new SendGridClient(SG_API_KEY);
                var from = new EmailAddress("EmailAddressOfTheSender", "Name of the sender");
                var subject = "Sending with SendGrid is Fun... and it Works :) ";
                var to = new EmailAddress("RecipientEmailAddressHere");
                var plainTextContent = "and easy to do anywhere, even with C#";
                var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
                var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
                var response = await client.SendEmailAsync(msg);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error {ex.Message}");
            }
        }
    }
}
