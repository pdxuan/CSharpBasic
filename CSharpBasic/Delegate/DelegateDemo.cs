using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpBasic.Delegate
{
    public static class DelegateDemo
    {
        public static async Task CompareDelegateAndFuncDemo()
        {
            RecruitmentService service = new RecruitmentService();

            // Define the callback method
            RecruitmentService.ProcessCompletionCallback callback = async (success, message) =>
            {
                if (success)
                {
                    Console.WriteLine($"Success: {message}");
                    // Handle successful processing
                }
                else
                {
                    Console.WriteLine($"Failure: {message}");
                    // Handle failure
                }
            };

            // Call the async method with the callback
            await service.ProcessApplicationAsync("Jane Doe", callback);

            // Continue with other work while waiting for async processing
            Console.WriteLine("Processing application asynchronously...");


        }

    }



    public class RecruitmentService
    {
        // Define the delegate
        public delegate Task ProcessCompletionCallback(bool success, string message);

        // Define an async method that takes a delegate as a parameter
        public async Task ProcessApplicationAsync(string applicantName, ProcessCompletionCallback callback)
        {
            // Simulate processing with a delay
            await Task.Delay(2000); // Simulate processing delay

            bool isValid = ValidateApplication(applicantName);
            if (isValid)
            {
                // Simulate additional async processing
                await Task.WhenAll(
                    PerformBackgroundChecksAsync(applicantName),
                    SendNotificationEmailAsync(applicantName)
                );

                // Call the callback with success
                await callback(true, $"Application for {applicantName} processed successfully.");
            }
            else
            {
                // Call the callback with failure
                await callback(false, $"Application for {applicantName} failed validation.");
            }
        }

        public bool ValidateApplication(string applicantName)
        {
            // Simulate validation logic
            return !string.IsNullOrEmpty(applicantName);
        }

        public async Task PerformBackgroundChecksAsync(string applicantName)
        {
            // Simulate async background checks
            Console.WriteLine($"Performing background checks for {applicantName}...");
            await Task.Delay(3000); // Simulate delay
        }

        public async Task SendNotificationEmailAsync(string applicantName)
        {
            // Simulate async email sending
            Console.WriteLine($"Sending notification email to {applicantName}...");
            await Task.Delay(1000); // Simulate delay
        }
    }
}
