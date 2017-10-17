using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ERMS.Models;
using ERMS.Persistence;
using ERMS.Controllers.api.DTOs;
using AutoMapper;
using System.Reflection;

namespace ERMS.Controllers.api
{
    [Produces("application/json")]
    [Route("api/Letters")]
    public class LettersController : Controller
    {
        private readonly IUnitofWork unitOfWork;
        private readonly IMapper mapper;

        public LettersController(IUnitofWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        
        [HttpGet("{skip:int}/{pageSize:int}")]
        public async Task<IActionResult> GetLetters(int skip,int pageSize)
        {
            var letters = await unitOfWork.Letters.GetAll(skip, pageSize, null);
            var totalRecords = await unitOfWork.Letters.GetCount();
            var responsedate = new
            {
                
                sEcho = 3,
                TotalRecords = totalRecords,
                TotalDisplayRecords = letters.Count(),
                page = 1,
                pages = 20,
                length = 5,
                serverSide = true,
                aadata = mapper.Map<IEnumerable<Letter>, IEnumerable<LetterDto>>(letters)
            };
            
            return  Ok(responsedate);   
        }

        [HttpGet("Data")]
        public async Task<IActionResult> GetLetters()
        {
            IEnumerable<Letter> letters = new List<Letter>();
          
            var requestFormData = HttpContext.Request;
            var skip = Convert.ToInt32(requestFormData.Query["start"].ToString());  
            var pageSize = Convert.ToInt32(requestFormData.Query["length"].ToString());
            Microsoft.Extensions.Primitives.StringValues tempOrder = new[] { "" };
            
            if (Request.Query.TryGetValue("order[0][column]", out tempOrder))
            {
                var columnIndex = requestFormData.Query["order[0][column]"].ToString();
                var sortDirection = requestFormData.Query["order[0][dir]"].ToString();
                tempOrder = new[] { "" };
                if (requestFormData.Query.TryGetValue($"columns[{columnIndex}][data]", out tempOrder))
                {
                    var columName = requestFormData.Query[$"columns[{columnIndex}][data]"].ToString();



                    var prop = getProperty(columName);
                    if (sortDirection == "asc")
                    {
                        letters = await unitOfWork.Letters.GetAll();
                    }
                    else
                    {
                        letters = await unitOfWork.Letters.GetAll();
                    }
                }
            }

            var results = mapper.Map<IEnumerable<Letter>, IEnumerable<LetterDto>>(letters);

            dynamic response = new
                {
                data = results,
                draw = requestFormData.Query["draw"],
                recordsFiltered = results.Count(),
                recordsTotal = results.Count()
                
                };

           return Ok(response);
        }

        private PropertyInfo getProperty(string name)
        {
            var properties = typeof(Models.Letter).GetProperties();
            PropertyInfo prop = null;
            foreach (var item in properties)
            {
                if (item.Name.ToLower().Equals(name.ToLower()))
                {
                    prop = item;
                    break;
                }
            }
            return prop;
        }
        
        [HttpGet]
        public IActionResult GetLetter(int id)
        {
            var letter = unitOfWork.Letters.SingleOrDefault(c => c.Id == id);
            if (letter == null)
                return NotFound();

            return Ok(mapper.Map<Task<Letter>,Task<LetterDto>>(letter));
        }
        
        [HttpPost]
        public  IActionResult CreateLetter(Letter letter)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            unitOfWork.Letters.Add(letter);
            unitOfWork.Commit();

            return Created(new Uri("api/letters/" + letter.Id), letter);
        }   
        
        [HttpPut]
        public IActionResult UpdateLetter(int id, Letter letter)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var letterinDb = unitOfWork.Letters.SingleOrDefault(p => p.Id == id);

            if (letterinDb == null)
                return NotFound();

            mapper.Map(letter, letterinDb);

            unitOfWork.Commit();

            return Ok();

        }
        
        [HttpDelete]
        public IActionResult DeleteLetter(int id)
        {
            var letterinDb = unitOfWork.Letters.Single(p => p.Id == id);

            if (letterinDb == null)
                return NotFound();

            unitOfWork.Letters.Remove(letterinDb);
            unitOfWork.Commit();

           return Ok();

        }
        
    }
}