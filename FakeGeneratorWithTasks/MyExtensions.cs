using System;
using System.Collections.Generic;
using System.Linq;

namespace FakeGeneratorWithTasks
{
    public static class MyExtensions
    {
        public static User GetUserFromFileExt(this String usersInfo)
        {
            string[] item = usersInfo.Split(',');
            var user = new User()
            {
                Id = int.Parse(item[0].Split(':').Last()),
                FirstName = item[1].Split(':').Last(),
                LastName = item[2].Split(':').Last(),
                BirthDate = DateTime.Parse(item[3].Split('/').Last()),
                Salary = decimal.Parse(item[4].Split(':').Last() + "," + item[5].Split(':').Last())
            };
            return user;
        }

        public static User GetFromFile(this User user, string lineFromFile)
        {
            string[] item = lineFromFile.Split(',');

            user.Id = int.Parse(item[0].Split(':').Last());
            user.FirstName = item[1].Split(':').Last();
            user.LastName = item[2].Split(':').Last();
            user.BirthDate = DateTime.Parse(item[3].Split('/').Last());
            user.Salary = decimal.Parse(item[4].Split(':').Last() + "," + item[5].Split(':').Last());

            return user;
        }

        public static IEnumerable<User> ByName(this IEnumerable<User> users, string name)
        {
            return users.Where(x => x.FirstName == name);
        }
    }
}