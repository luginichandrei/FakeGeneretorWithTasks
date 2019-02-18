using System.Collections.Concurrent;
using System.IO;
using System.Threading.Tasks;

namespace FakeGeneratorWithTasks
{
    internal class TextReaderAsync
    {
        private readonly object locker = new object();

        public async Task ReadTextAsync(int fileNumber, BlockingCollection<User> users)
        {
            string line;
            using (StreamReader sr = new StreamReader(@"C:\File" + fileNumber + ".txt", true))
            {
                while ((line = await sr.ReadLineAsync()) != null)
                {
                    //var user = line.GetUserFromFileExt();
                    var user = new User().GetFromFile(line);
                    //Console.WriteLine("File №" + fileNumber + " Id:" + user.Id + ",FirstName:" + user.FirstName + ",LastName:" + user.LastName + ",BirthDate:" + user.BirthDate + ",Salary:" + user.Salary);
                    //lock (locker)
                    //{
                    users.Add(user);
                    //}
                }
            }
        }
    }
}