using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp37
{
    internal class Person
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }

        public override string ToString()
        {
            return $"Id: {Id} - UserName: {UserName} - Password: {Password} - UserType: {UserType} ";
        }
    }
}
