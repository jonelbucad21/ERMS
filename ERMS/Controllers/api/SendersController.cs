using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ERMS.Persistence;
using AutoMapper;
using ERMS.Models;
using ERMS.Controllers.api.DTOs;

namespace ERMS.Controllers.api
{
    [Produces("application/json")]
    [Route("api/Senders")]
    public class SendersController : Controller
    {
        private readonly IUnitofWork unitOfWork;
        private readonly IMapper mapper;

        public SendersController(IUnitofWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public IUnitofWork UnitOfWork { get; }

        [HttpGet]
        public async Task<IActionResult> GetSenders()
        {
            var senders = await unitOfWork.Senders.GetAll();
            return Ok(mapper.Map<IEnumerable<Sender>, IEnumerable<SenderDto>>(senders));
        }
    }
}