using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace FakeGeneratorWithTasks
{
    public class TextWritter
    {
        public async Task WriteText(int usersCount, int fileNumber)
        {
            var result = new FakeListUsers().GetUsers(usersCount);

            Console.WriteLine("Thred Id {0}, index: {1}", System.Threading.Thread.CurrentThread.ManagedThreadId, fileNumber);
            using (StreamWriter sw = new StreamWriter(@"C:\File" + fileNumber + ".txt"))
            {
                foreach (var s in result)
                {
                    //Console.WriteLine("File №" + fileNumber + " Id:" + s.Id + ",FirstName:" + s.FirstName + ",LastName:" + s.LastName + ",BirthDate:" + s.BirthDate + ",Salary:" + s.Salary);
                    await sw.WriteLineAsync("Id:" + s.Id + ",FirstName:" + s.FirstName + ",LastName:" + s.LastName + ",BirthDate/" + s.BirthDate + ",Salary:" + s.Salary);
                }
            }
        }

        public void WriteText(List<User> users)
        {
            Console.WriteLine("Writter: Thread Id {0}", System.Threading.Thread.CurrentThread.ManagedThreadId);
            int ids = 1;
            using (StreamWriter sw = new StreamWriter(@"C:\FileAll.txt"))
            {
                foreach (var s in users)
                {
                    //Console.WriteLine("FileAll Id:" + ids + ",FirstName:" + s.FirstName + ",LastName:" + s.LastName + ",BirthDate:" + s.BirthDate + ",Salary:" + s.Salary);
                    sw.WriteLine("Id:" + ids++ + ",FirstName:" + s.FirstName + ",LastName:" + s.LastName + ",BirthDate/" + s.BirthDate + ",Salary:" + s.Salary);
                }
            }
        }
    }
}