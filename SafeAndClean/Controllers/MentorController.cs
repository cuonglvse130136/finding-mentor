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

        [HttpGet("Search")]
        public IActionResult Filter(string name, string majorId, [FromQuery] string[] subjectIds)
        {
            var result = _MentorService.Search(name, majorId, subjectIds);

            if (result.Success) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> Create([FromBody] MentorAddModel model)
        {
            var result = await _MentorService.Create(model);

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

        [HttpPut("Profile/{id}")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public IActionResult UpdateProflie(string id, [FromBody] MentorUpdateModel1 model)
        {
            var result = _MentorService.UpdateMentorProfile(id, model);

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

        [HttpGet("Major/{mentorId}")]
        public IActionResult GetAvalableMajor(string mentorId)
        {
            var rs = _MentorService.GetAvailableMajors(mentorId);

            if (rs.Success) return Ok(rs.Data);
            return BadRequest(rs.ErrorMessage);
        }
    }
}
