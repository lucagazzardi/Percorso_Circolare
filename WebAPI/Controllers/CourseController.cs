using BL.AppServices.Interfaces;
using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebAPICircolare.Controllers
{
    [EnableCors(origins: "http://localhost:15684", headers: "*", methods: "*")]
    [RoutePrefix("api/course")]
    public class CourseController : ApiController
    {

        private readonly ICourseAppService _courseAppService;

        public CourseController
        (
            ICourseAppService courseAppService
        )
        {
            _courseAppService = courseAppService;
        }

        //GET

        [Route("get/{courseId:int}")]
        [HttpGet]
        public IHttpActionResult GetCourse(int courseId)
        {
            var data = _courseAppService.GetCourseById(courseId);


            if (data != null)
                return Ok(data);
            else
                return NotFound();
        }

        [Route("get/all")]
        [HttpGet]
        public IHttpActionResult GetCourses()
        {
            var data = _courseAppService.GetCourses();

            if (data != null)
                return Ok(data);
            else
                return NotFound();
        }

        //POST

        [Route("insert")]
        [HttpPost]
        public void InsertNewCourse(CourseDto course)
        {
            _courseAppService.Insert(course);
        }
    }
}
