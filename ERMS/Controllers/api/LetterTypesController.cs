using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ERMS.Persistence;
using AutoMapper;
using ERMS.Controllers.api.DTOs;
using ERMS.Models;

namespace ERMS.Controllers.api
{
    [Produces("application/json")]
    [Route("api/LetterTypes")]
    public class LetterTypesController : Controller
    {
        private readonly IUnitofWork unitOfWork;
        private readonly IMapper mapper;

        public LetterTypesController(IUnitofWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

            [HttpGet]
            public async Task<IActionResult> GetLetterTypes()
            {
                var letterTypes = await unitOfWork.LetterTypes.GetAll();
                return Ok(mapper.Map<IEnumerable<LetterType>, IEnumerable<LetterTypeDto>>(letterTypes));
            }
        
    }
}