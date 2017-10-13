﻿using System;
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
        private readonly IUnitofWork unitofWork;
        private readonly IMapper mapper;

        public LettersController(IUnitofWork unitofWork, IMapper mapper)
        {
            this.unitofWork = unitofWork;
            this.mapper = mapper;
        }

        [HttpGet("{skip:int}/{pageSize:int}")]
        public async Task<IActionResult> GetLetters(int skip,int pageSize)
        {       
            var letters = await unitofWork.Letter.GetAll();
            return  Ok(mapper.Map<IEnumerable<Letter>,IEnumerable<LetterDto>>(letters));   
        }


        [HttpGet("")]
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
                        letters = await unitofWork.Letter.GetAll();
                    }
                    else
                    {
                        letters = await unitofWork.Letter.GetAll();
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
        
    }
}