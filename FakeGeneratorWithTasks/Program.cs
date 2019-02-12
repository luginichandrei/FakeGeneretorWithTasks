using System;

namespace FakeGeneratorWithTasks
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //for (int i = 1; i <= 5; i++)
            //{
            //    Console.WriteLine("{0} File from loop", i);
            //    var result = new TextWritter().WriteText(50, i);

            //}
            //Console.ReadKey();

            //var tasks = new Task[3];
            //for (int i = 0; i < tasks.Length; i++)
            //{
            //    tasks[i] = Task.Run(() => new TextWritter().WriteText(50, i));
            //}
            //Task.WaitAll(tasks);
            //Console.ReadKey();
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine("{0} File from loop", i);
                var result = new TextReader().ReadText(i);
            }
            Console.ReadKey();
        }
    }
}