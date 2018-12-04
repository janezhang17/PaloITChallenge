using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaloITChallenge.Data;
using PaloITChallenge.Model;
using PaloITChallenge.Services;
using PaloITChallenge.ViewModel;

namespace PaloITChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NameFormController : ControllerBase
    {
        private IFullNameRepository _fullNameRepository;

        public NameFormController(IFullNameRepository fullNameRepository)
        {

            _fullNameRepository = fullNameRepository;

        }

        // POST: api/PaloITChallenge
        [HttpPost]
        public NameFormViewModel Post([FromBody] FullName fullName)
        {
            FullName existingFullName = _fullNameRepository.GetExistingRecordsByName(fullName.FirstName, fullName.LastName);
            if (existingFullName != null)
                return new NameFormViewModel(existingFullName.NumOfConsecutive0s.ToString(), null);           

            var result = _fullNameRepository.InsertNewFullNameAsync(fullName);

            return new NameFormViewModel(fullName.NumOfConsecutive0s.ToString(),result);

        }

        
    }

    
}
