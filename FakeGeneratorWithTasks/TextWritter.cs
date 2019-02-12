using System;
using System.IO;
using System.Threading.Tasks;

namespace FakeGeneratorWithTasks
{
    public class TextWritter
    {
        public async Task WriteText(int usersCount, int fileNumber)
        {
            var result = new FakeListUsers().GetUsers(usersCount);

            using (StreamWriter sw = File.AppendText(@"C:\File" + fileNumber + ".txt"))
            {
                foreach (var s in result)
                {
                    Console.WriteLine("File №" + fileNumber + " Id:" + s.Id + ",FirstName:" + s.FirstName + ",LastName:" + s.LastName + ",BirthDate:" + s.BirthDate + ",Salary:" + s.Salary);
                    await sw.WriteLineAsync("Id:" + s.Id + ",FirstName:" + s.FirstName + ",LastName:" + s.LastName + ",BirthDate/" + s.BirthDate + ",Salary:" + s.Salary);
                }
            }
        }
    }
}