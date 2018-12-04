using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaloITChallenge.Model
{
    public class FullName
    {
        public int id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int SumOfAsciiValue { get; set; }
        public int NumOfConsecutive0s { get; set; }
    }
}
