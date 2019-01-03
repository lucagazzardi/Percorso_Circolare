using BL.AppServices.Interfaces;
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
    [RoutePrefix("api/classroom")]
    public class ClassroomController : ApiController
    {

        private readonly IClassroomAppService _classroomAppService;

        public ClassroomController
        (
            IClassroomAppService classroomAppService
        )
        {
            _classroomAppService = classroomAppService;
        }

        //GET

        [Route("get/{classroomId:int}")]
        [HttpGet]
        public IHttpActionResult GetClassroom(int classroomId)
        {
            var data = _classroomAppService.GetClassroomById(classroomId);

            if (data != null)
                return Ok(data);
            else
                return NotFound();
        }

        [Route("get/all")]
        [HttpGet]
        public IHttpActionResult GetClassrooms()
        {
            var data = _classroomAppService.GetClassrooms();

            if (data != null)
                return Ok(data);
            else
                return NotFound();
        }
    }
}
