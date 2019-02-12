using System;

namespace FakeGeneratorWithTasks
{
    public class User
    {
        public User(int userId)
        {
            this.Id = userId;
        }

        public User()
        {
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public decimal Salary { get; set; }
    }
}