using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaloITChallenge.ViewModel
{
    public class NameFormViewModel
    {
        public string NumOfConsecutive0s { get; set; }
        public string ErrorMesg { get; set; }

        public NameFormViewModel(string numOfConsecutive0s, string error)
        {
            NumOfConsecutive0s = numOfConsecutive0s;
            ErrorMesg = error;
        }

    }
}
