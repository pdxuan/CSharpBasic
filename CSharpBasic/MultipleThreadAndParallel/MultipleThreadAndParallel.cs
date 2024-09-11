using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CSharpBasic
{
    public static class MultipleThreadAndParallel
    {
        public static void CreateNewThread()
        {

            var cancellationTokenSource = new CancellationTokenSource();


            // Foreground thread example
            Thread foregroundThread = new Thread((cts) =>
            {
                if (cancellationTokenSource.IsCancellationRequested)
                {
                    Console.WriteLine("Foreground thread started...");
                    Thread.Sleep(11000); // Simulate some work (5 seconds)
                    Console.WriteLine("Foreground thread finished.");
                }
            });

            // Background thread example
            Thread backgroundThread = new Thread((cts) =>
            {

                Console.WriteLine("Background thread started...");
                Thread.Sleep(10000); // Simulate some work (10 seconds)
                Console.WriteLine("Background thread finished.");

            });


            // Set the second thread as a background thread
            backgroundThread.IsBackground = true;

            // Start both threads
            foregroundThread.Start(cancellationTokenSource.Token);
            backgroundThread.Start(cancellationTokenSource.Token);


            // When cancellation is trigger -> ForeGround Thread will stop -> Main thread will stop -> Background Thread will forced stop 
            cancellationTokenSource.Cancel();


            Console.WriteLine("Main thread ends here.");
        }


        private static readonly EventWaitHandle ewh = new EventWaitHandle(false, EventResetMode.AutoReset);

        public static void EventWaitHandleDemo()
        {
            // Starting two worker threads
            Thread worker1 = new Thread(WorkerMethod);
            worker1.Start(1);

            Thread worker2 = new Thread(WorkerMethod);
            worker2.Start(2);

            // Main thread is waiting until both workers are done
            Console.WriteLine("Main thread: Waiting for workers to signal completion.");
            ewh.WaitOne(); // Block here until the event is signaled

            Console.WriteLine("Main thread: All workers are done, continuing.");
        }


        static void WorkerMethod(object id)
        {
            Console.WriteLine($"Worker {id}: Starting task...");
            Thread.Sleep(2000); // Simulate work by sleeping for 2 seconds
            Console.WriteLine($"Worker {id}: Task completed.");

            // After both workers are done, signal the event
            if ((int)id == 2) // Assume last worker signals
            {
                Console.WriteLine($"Worker {id}: Signaling event.");
                ewh.Set(); // Signal the event, allowing the main thread to continue
            }
        }




        /// <summary>
        /// Asynchronous programming with async and await in C# allows you to write 
        /// responsive and efficient code by executing non-blocking operations.It is 
        /// particularly useful for tasks that involve I/O operations, such as file I/O, network requests, or database queries.
        /// </summary>
        public static async Task AsyncAwaitDemo()
        {
            // Task.Run -> require a Thread from ThreadPool
            Task res3 = Task.Run(Fn3);

            Console.WriteLine($"AsyncDemoFn before call Fn1- ThreadID = {Environment.CurrentManagedThreadId}");

            var res1 = await AsyncFn1();

            Console.WriteLine($"AsyncDeoFn before call Fn2 - Thread = {Environment.CurrentManagedThreadId}");

            var res2 = await AsyncFn2();

            Console.WriteLine($"AsyncDemoFn before call Fn3 - Thread = {Environment.CurrentManagedThreadId}");

            res3.Wait();
        }

       


        /// <summary>
        /// Declare async method
        /// </summary>
        /// <returns></returns>
        public static async Task<int> AsyncFn1()
        {
            Console.WriteLine($"AsyncFn1 - ThreadID = {Environment.CurrentManagedThreadId}");

            // IO task demo 
            var temp =  await File.ReadAllTextAsync(Path.Combine(Environment.CurrentDirectory, "FileIO\\FileContent.txt"));
            return 1;
        }


        public static async Task<int> AsyncFn2()
        {
            Console.WriteLine($"AsyncFn2 - ThreadID = {Environment.CurrentManagedThreadId}");

            // IO task demo 
            var temp = await File.ReadAllTextAsync(Path.Combine(Environment.CurrentDirectory, "FileIO\\FileContent.txt"));

            return 2;
        }

        private static int Fn3()
        {
            Console.WriteLine($"Fn3 - ThreadID = {Environment.CurrentManagedThreadId}");
            return 3;
        }






    }
}
