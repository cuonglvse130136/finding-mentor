using Data.StaticData;
using Data.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SafeAndClean.Extensions;
using Services.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWP391_FindMentorApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MentorController : ControllerBase
    {
        private readonly IMentorService _MentorService;

        public MentorController(IMentorService MentorService)
        {
            _MentorService = MentorService;
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public IActionResult Get(Guid? id)
        {
            var result = _MentorService.Get(id);

            if (result.Success) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }

        [HttpGet("RecommendMentorByMajor")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public IActionResult RecommendMentorByMajor()
        {
            var result = _MentorService.RecommendMentorByMajor(User.GetId());

            if (result.Success) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }
        [HttpGet("RecommendMentor")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public IActionResult RecommendMentor()
        {
            var result = _MentorService.RecommendMentor();

            if (result.Success) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }

        [HttpGet("Information/{id}")]
        //[Authorize(AuthenticationSchemes = "Bearer")]
        public IActionResult Information(string id)
        {
            var result = _MentorService.GetMentorInformation(id);

            if (result.Success) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }

        [HttpGet("Search/{name}")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public IActionResult Search(string name)
        {
            var result = _MentorService.Search(name);

            if (result.Success) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public IActionResult Create([FromBody] MentorAddModel model)
        {
            var result = _MentorService.Create(model);

            if (result.Success) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }

        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public IActionResult Update(Guid id, [FromBody] MentorUpdateModel model)
        {
            var result = _MentorService.Update(id, model);

            if (result.Success) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }

        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public IActionResult Delete(Guid id)
        {
            var result = _MentorService.Delete(id);

            if (result.Success) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }
    }
}
