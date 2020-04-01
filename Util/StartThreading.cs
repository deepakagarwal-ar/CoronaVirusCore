using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CoronaVirusCore.Util
{
    public class StartThreading
    {
        const int max = int.MaxValue / 1000;
        const int min = max + 10000;
        //private long m_totalIterations = 0;
        readonly object m_totalItersLock = new object();

        // The method that will be called when the thread is started.
        public void GenerateData()
        {
            Console.WriteLine(
                "ServerClass.InstanceMethod is running on another thread.");

            LoopThroughNumber();

        }

        private void LoopThroughNumber()
        {
            var rand = new Random();
            var iters = rand.Next(max, min);
            
            lock (m_totalItersLock)
            {
                // we're just spinning here
                // and using Random to frustrate compiler optimizations
                for (var i = 0; i < iters; i++)
                {
                    rand.Next();
                }
            }
        }
    }

    public class Simple
    {
        public Simple()
        {
            while(true)
            {
                CreateThreads();
            }
        }
        public static void CreateThreads()
        {
            var serverObject = new StartThreading();

            Thread threadInstance = new Thread(new ThreadStart(serverObject.GenerateData));
            // Start the thread.
            threadInstance.Start();

            Console.WriteLine("The Main() thread calls this after "
                + "starting the new InstanceCaller thread.");

        }
    }
}
