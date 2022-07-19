using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RzNovel.Models
{
    public class UserRegister
    {
        public int id { get; set; }
        public string one { get; set; }
        public string two { get; set; }

        public override string ToString()
        {
            return id.ToString() + ": " + one + " " + two;
        }
    }
}
