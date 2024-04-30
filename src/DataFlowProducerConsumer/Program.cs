// https://learn.microsoft.com/ja-jp/dotnet/standard/parallel-programming/how-to-implement-a-producer-consumer-dataflow-pattern
using System;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace DataFlowProducerConsumer
{
    internal class DataFlowProducerConsumer
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        static void Produce(ITargetBlock<byte[]> target)
        {
            var rand = new Random();

            for (int i = 0; i < 100; ++i)
            {
                var buffer = new byte[1024];
                rand.NextBytes(buffer);

                // Write the data to target block synchronously
                target.Post(buffer);
            }

            // Block from adding new available data
            target.Complete();
        }


        /// <summary>
        /// Calculate gross byte numbers of received data asynchronously
        /// (Using only one consumer)
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        static async Task<int> ConsumeAsyncWithSingleConsumer(ISourceBlock<byte[]> source)
        {
            int bytesProcessed = 0;

            while (await source.OutputAvailableAsync())
            {
                byte[] data = await source.ReceiveAsync();
                bytesProcessed += data.Length;
            }

            return bytesProcessed;
        }


        /// <summary>
        /// Calculate gross byte numbers of received data asynchronously
        /// (Using multiple consumer)
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        static async Task<int> ConsumeAsyncWithMultiConsumer(IReceivableSourceBlock<byte[]> source)
        {
            int bytesProcessed = 0;
            while (await source.OutputAvailableAsync())
            {
                // Returns false if data is not available
                while(source.TryReceive(out byte[] data))
                {
                    bytesProcessed += data.Length;
                }
            }
            return bytesProcessed;
        }


        /// <summary>
        /// Main Process
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        static async Task Main(string[] args)
        {
            var buffer = new BufferBlock<byte[]>();

            var consumerTask = ConsumeAsyncWithMultiConsumer(buffer);
            Produce(buffer);

            var bytesProcessed = await consumerTask;

            Console.WriteLine($"Processed {bytesProcessed:#,#} bytes");

            Console.WriteLine("Press any key to exit ...");
            Console.ReadKey();
        }
    }
}
