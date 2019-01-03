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
    [RoutePrefix("api/lesson")]
    public class LessonController : ApiController
    {

        private readonly ILessonAppService _lessonAppService;

        public LessonController
        (
            ILessonAppService lessonAppService
        )
        {
            _lessonAppService = lessonAppService;
        }

        //GET

        [Route("get/{lessonId:int}")]
        [HttpGet]
        public IHttpActionResult GetLesson(int lessonId)
        {
            var data = _lessonAppService.GetLessonById(lessonId);

            if (data != null)
                return Ok(data);
            else
                return NotFound();
        }

        [Route("get/all")]
        [HttpGet]
        public IHttpActionResult GetLessons()
        {
            var data = _lessonAppService.GetLessons();

            if (data != null)
                return Ok(data);
            else
                return NotFound();
        }

        //POST

        [Route("insert")]
        [HttpPost]
        public void InsertNewLesson(LessonDto lesson)
        {
            _lessonAppService.Insert(lesson);
        }

        //DELETE

        [Route("delete/{lessonId:int}")]
        [HttpDelete]
        public void DeleteLesson(int lessonId)
        {
            _lessonAppService.DeleteLesson(lessonId);
        }
    }
}
