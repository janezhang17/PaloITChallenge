using Microsoft.EntityFrameworkCore;
using PaloITChallenge.Model;
using PaloITChallenge.Services;
using PaloITChallenge.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaloITChallenge.Data
{
    public class FullNameRepository : IFullNameRepository
    {
        private readonly ApplicationDBContext _context;
        private INameConvertService _nameConvertService;

        public FullNameRepository(ApplicationDBContext context, INameConvertService nameConvertService)
        {
            _context = context;
            _nameConvertService = nameConvertService;
        }

        //Search Database to check if the Name already existed in DB
        public FullName GetExistingRecordsByName(string firstName, string lastName)
        {
            var existingFullName = _context.FullNames.Where(
                                name => (name.FirstName==firstName) && (name.LastName==lastName)).FirstOrDefault();

            return existingFullName;
        }

        //Insert a new name in database
        public string InsertNewFullNameAsync(FullName newFullName) 
        {
            string result = null;
            int sumOfAsciiValue = _nameConvertService.GetSumOfAsciiValuesOfName(newFullName.FirstName, newFullName.LastName);
            int numOfConsecutive0s = BinaryArrayService.GetLargestNumOfConsecutive0s(sumOfAsciiValue);

            newFullName.SumOfAsciiValue = sumOfAsciiValue;
            newFullName.NumOfConsecutive0s = numOfConsecutive0s;
            
            _context.FullNames.AddAsync(newFullName);

            try
            {
                _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                //handle exception
                result = e.Message;

            }

            return result;
        }
    }
}
