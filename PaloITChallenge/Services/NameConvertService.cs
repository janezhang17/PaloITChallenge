using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaloITChallenge.Services
{
    public class NameConvertService : INameConvertService
    {
        public int GetSumOfAsciiValuesOfName(string firstName, string lastName)
        {
            if (String.IsNullOrWhiteSpace(firstName) && String.IsNullOrWhiteSpace(lastName))
                return 0;
            string fullName = firstName + " " + lastName;
            byte[] nameAsciiBytes = Encoding.ASCII.GetBytes(fullName);
            int sum = 0;

            foreach (var chaByte in nameAsciiBytes)
                sum += chaByte;

            return sum;
        }
    }
}
