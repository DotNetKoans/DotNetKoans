using Xunit;
using System.Threading;
using DotNetKoans.Engine;

namespace DotNetKoans.Koans
{
    public class AboutThreads : Koan
    {
        // Prerequisites Concepts
        //
        // Concurrency: In software, Concurrency refers to the ability of a program to
        // execute multiple tasks simultaneously (which should not be
        // confused with the Task Class).
        //
        // Multithreading: The general mechanism by which a program can
        // simultaneously execute code is called multithreading.
        //
        // Thread: A thread is an execution path that can proceed independently of
        // others. Each thread runs within an operating system process,
        // which provides an isolated environment in which a program runs.
        //
        // Definitions taken from "C# in a Nutshell" by Joseph Albahari and Ben Albahari.


        [Step(1)]
        public void CreatingThreads()
        {
            Thread.CurrentThread.Name = "MainThread";

            var result = string.Empty;

            //Create a new thread object with anonymous function
            Thread otherThread = new Thread(() =>
            {
                Thread.CurrentThread.Name = "OtherThread";
                //Block execution path of the current thread
                //Remove this statement after you are done with this koan because
                //it can cause other koans to take longer to run.
                Thread.Sleep(1000);
                result += Thread.CurrentThread.Name;
            });
            //Run the thread   
            otherThread.Start();

            result += Thread.CurrentThread.Name;
            Assert.Equal(FILL_ME_IN, result);
        }

        [Step(2)]
        public void SynchronizingThreads()
        {
            Thread.CurrentThread.Name = "MainThread";

            var result = string.Empty;

            //Create a new thread object with anonymous function
            Thread otherThread = new Thread(() =>
            {
                Thread.CurrentThread.Name = "OtherThread";
                //Block execution path of the current thread
                Thread.Sleep(1000);
                result += Thread.CurrentThread.Name;
            });
            //Run the thread   
            otherThread.Start();
            otherThread.Join();

            result += Thread.CurrentThread.Name;
            Assert.Equal(FILL_ME_IN, result);
        }

        [Step(3)]
        public void OrderingThreadsPractice()
        {
            string result = string.Empty;
            const string HELLO = nameof(HELLO);
            const string WORLD = nameof(WORLD);

            Thread thread1 = new Thread(() => { result += HELLO; });
            Thread thread2 = new Thread(() => { result += WORLD; });

            //start threads so that pass this exercise 
            thread1.Start();
            thread1.Join();
            thread2.Start();
            thread2.Join();

            Assert.Equal(FILL_ME_IN, result);
        }

        [Step(4)]
        public void PassArgumentsToThreads()
        {
            int result = default(int);

            Thread thread = new Thread((factor) => { result = (int)factor * 5; });
            thread.Start(100);
            thread.Join();

            Assert.Equal(FILL_ME_IN, result);
        }


        [Step(5)]
        public void LockStatement()
        {
            //When two or more thread access shared data or resources
            //in a way that can lead to unexpected or incorrect behavior
            //it can cause Race Condition 
            //
            //Locking is one way to prevent race conditions by allowing only
            //one thread to access a shared resource at a time

            object lockObject = new object();

            //Its shared resource that the Sum method access it 
            //from two different threads
            int SumResult = 0;

            //We have to do this several times because
            //the result is not predictable and sometimes might seem correct
            //although it is not reliable
            for (int i = 0; i < 5; i++)
            {
                // Create two threads that call Sum simultaneously
                Thread thread1 = new Thread(() => Sum(30));
                Thread thread2 = new Thread(() => Sum(30));
                SumResult = 0;
                thread1.Start();
                thread2.Start();

                // Wait for the threads to finish
                thread1.Join();
                thread2.Join();

                Assert.Equal(60, SumResult);
            }

            void Sum(int length)
            {
                for (int i = 0; i < length; i++)
                {
                    //Remove this statement after you are done with this koan because
                    //it can cause other koans to take longer to run.
                    Thread.Sleep(100);

                    //Just uncomment this code
                    //lock (lockObject)
                    {
                        SumResult++;
                    }
                }
            }
        }

    }
}
