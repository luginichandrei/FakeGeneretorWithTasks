using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FakeGeneratorWithTasks
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var fileNumber = 10;
            var userCount = 50;

            //Init Write into textFile
            Console.WriteLine("Init I Task");
            var tasks = new Task[fileNumber];
            for (int i = 0; i < tasks.Length; i++)
            {
                var index = i;
                tasks[i] = Task.Run(() => new TextWritter().WriteText(userCount, index));
            }
            Task.WaitAll(tasks);
            Console.ReadKey();

            ////Init read from file
            Console.WriteLine("Init II Task");
            Task[] task = new Task[fileNumber];
            var users = new List<User>();
            object locker = new object();
            for (int i = 0; i < tasks.Length; i++)
            {
                var index = i;
                tasks[i] = Task.Run(() =>
                {
                    var res = new TextReader().ReadText(index);

                    foreach (var u in res)
                    {
                        lock (locker)
                        {
                            users.Add(u);
                        }
                    }
                });
            }
            Task.WaitAll(tasks);
            if (users.Count() == 0) Console.WriteLine("users is empty");
            else Console.WriteLine("Users count = " + users.Count);
            Console.ReadKey();

            //Init read from file with BlockingCollection
            Console.WriteLine("Init III Task");
            var people = new BlockingCollection<User>();
            var reader = new TextReader();
            var writer = new TextWritter();

            for (int i = 0; i < fileNumber; i++)
            {
                int file = i;
                Task task1 = Task.Run(() => reader.ReadText(file, people));
                task1.ContinueWith(nextTask => writer.WriteText(people.ToList())).Wait();
            }

            //new TextWritter().WriteText(people.ToList());
            if (people.Count() == 0) Console.WriteLine("people is empty");
            else Console.WriteLine("Users count = " + people.Count);

            Console.ReadKey();
        }
    }
}