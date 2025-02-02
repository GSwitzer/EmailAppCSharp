﻿//thsi is a new comment im adding

// this comment was added before i tried to push from visual studio


//this should only be in the newFeature branch

using MailKit.Net.Smtp;
using MimeKit;

namespace IntroEmailApplication
{
    internal class Program
    {
        private const int SmtpPort = 465;
        private const bool IsSslConnection = true;

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the command line email client!");

            var user_wants_to_send_message = true;

            while (user_wants_to_send_message)
            {
                Console.WriteLine();
                Console.WriteLine("New Message");

                var mail = new MimeMessage();

                mail.From.Add(new MailboxAddress("Jared Hoyt", "jaredhoyt@gmail.com")); // TODO: update to your own name and email address

                Console.Write("To: ");
                mail.To.Add(new MailboxAddress("", Console.ReadLine()));

                Console.Write("Subject: ");
                mail.Subject = Console.ReadLine();

                Console.Write("Body: ");
                mail.Body = new TextPart("plain") { Text = Console.ReadLine() };

                using (var client = new SmtpClient())
                {
                    client.Connect("smtp.gmail.com", SmtpPort, IsSslConnection);
                    client.Authenticate("jaredhoyt", "abcd efgh ijkl mnop"); // TODO: update to your own username and APP PASSWORD (this is different from your normal password)
                    client.Send(mail);
                    client.Disconnect(true);

                    Console.WriteLine("Message sent successfully!");
                }

                Console.WriteLine();
                Console.Write("Would you like to send another email? (Y/N): ");

                if (Console.ReadKey().Key != ConsoleKey.Y)
                {
                    user_wants_to_send_message = false;
                }
            }
        }
    }
}