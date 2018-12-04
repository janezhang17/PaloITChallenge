using System.Linq;
using PaloITChallenge.Model;

namespace PaloITChallenge.Data
{
    public interface IFullNameRepository
    {
        FullName GetExistingRecordsByName(string firstName, string lastName);
        string InsertNewFullNameAsync(FullName newFullName);
    }
}