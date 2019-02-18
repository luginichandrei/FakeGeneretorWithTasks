using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;

namespace FakeGeneratorWithTasks
{
    public class TextReader
    {
        private readonly object locker = new object();

        public IEnumerable<User> ReadText(int fileNumber)
        {
            string line;
            using (StreamReader sr = File.OpenText(@"C:\File" + fileNumber + ".txt"))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    //var user = line.GetUserFromFileExt();
                    //Console.WriteLine("File №" + fileNumber + " Id:" + user.Id + ",FirstName:" + user.FirstName + ",LastName:" + user.LastName + ",BirthDate:" + user.BirthDate + ",Salary:" + user.Salary);
                    yield return line.GetUserFromFileExt();
                }
            }
        }

        public void ReadText(int fileNumber, BlockingCollection<User> users)
        {
            Console.WriteLine("Reader: Thread Id {0}, index: {1}", System.Threading.Thread.CurrentThread.ManagedThreadId, fileNumber);
            string line;
            using (StreamReader sr = File.OpenText(@"C:\File" + fileNumber + ".txt"))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    users.Add(line.GetUserFromFileExt());
                }
            }
        }
    }
}