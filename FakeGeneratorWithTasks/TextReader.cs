using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FakeGeneratorWithTasks
{
    public class TextReader
    {
        public async Task ReadText(int fileNumber)
        {
            string line;
            var users = new List<User>();
            using (StreamReader sr = File.OpenText(@"C:\File" + fileNumber + ".txt"))
            {
                while ((line = await sr.ReadLineAsync()) != null)
                {
                    string[] item = line.Split(',');
                    var user = new User()
                    {
                        Id = int.Parse(item[0].Split(':').Last()),
                        FirstName = item[1].Split(':').Last(),
                        LastName = item[2].Split(':').Last(),
                        BirthDate = DateTime.Parse(item[3].Split('/').Last()),
                        Salary = decimal.Parse(item[4].Split(':').Last() + "," + item[5].Split(':').Last())
                    };

                    users.Add(user);
                    Console.WriteLine("File №" + fileNumber + " Id:" + user.Id + ",FirstName:" + user.FirstName + ",LastName:" + user.LastName + ",BirthDate:" + user.BirthDate + ",Salary:" + user.Salary);
                }
            }
        }
    }
}