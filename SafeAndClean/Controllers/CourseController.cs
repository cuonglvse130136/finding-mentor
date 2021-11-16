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
using System.Net;
using System.Threading.Tasks;

namespace SWP391_FindMentorApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var rs = _courseService.Get(id);

            if (rs.Success) return Ok(rs.Data);
            return BadRequest(rs.ErrorMessage);
        }

        [HttpGet("courseOfMentor/{id}")]
        public IActionResult GetCourseOfMentor(string id)
        {
            var rs = _courseService.getCourseofMentor(id);

            if (rs.Success) return Ok(rs.Data);
            return BadRequest(rs.ErrorMessage);
        }
        [HttpGet("courseOfStudent/{id}")]
        public IActionResult GetCourseOfStudent(string id)
        {
            var rs = _courseService.GetCourseOfStudent(id);

            if (rs.Success) return Ok(rs.Data);
            return BadRequest(rs.ErrorMessage);
        }
        [HttpGet("Name/{name}")]
        public IActionResult Filter(string name)
        {
            var rs = _courseService.Search(name);
            if (rs.Success) return Ok(rs.Data);
            return BadRequest(rs.ErrorMessage);
        }
        [HttpGet("RecommendCourse")]
        [Authorize(AuthenticationSchemes = "Bearer" )]
        public IActionResult RecommendMentor()
        {
            var result = _courseService.RecommendCourse(User.GetId());

            if (result.Success) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }

        [HttpPost]
        public IActionResult Add([FromBody] CourseAddModels model)
        {
            var rs = _courseService.Add(model, User.GetId());

            if (rs.Success) return Ok(rs.Data);
            return BadRequest(rs.ErrorMessage);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] CourseUpdateModels model)
        {
            var rs = _courseService.Update(id, model);

            if (rs.Success) return Ok(rs.Data);
            return BadRequest(rs.ErrorMessage);
        }
        [HttpPut("ImageUrl/{id}")]
        public IActionResult Update(Guid id, [FromBody] UpdateImageUrlModel model)
        {
            var rs = _courseService.UpdateImageUrl(id, model);

            if (rs.Success) return Ok(rs.Data);
            return BadRequest(rs.ErrorMessage);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var rs = _courseService.Delete(id);

            if (rs.Success) return Ok(rs.Data);
            return BadRequest(rs.ErrorMessage);
        }
    }
}

