using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaloITChallenge.Services
{
    public class BinaryArrayService
    {
        public static int GetLargestNumOfConsecutive0s(int number) {

            var largestNum =0;
            var count = 0;

            while (number > 1) {
                if (number % 2 == 1)
                    count = 0;
                else
                    count++;
                largestNum = largestNum > count ? largestNum : count;

                number = number / 2;
            }

            return largestNum;
        }

        public static int GetLargestNumOfConsecutive0s(string binaryArrayString)
        {
            if (String.IsNullOrWhiteSpace(binaryArrayString))
                return 0;

            int result = 0;
            string[] tempList = binaryArrayString.Split('1');
            for (int i = 0; i < tempList.Length; i++)
            {
                if (!String.IsNullOrWhiteSpace(tempList[i]))
                    result = Math.Max(result,tempList[i].Length);
            }

            return result;
        }
    }
}
