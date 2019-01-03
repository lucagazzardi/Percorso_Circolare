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
    [RoutePrefix("api/module")]
    public class ModuleController : ApiController
    {

        private readonly IModuleAppService _moduleAppService;

        public ModuleController
        (
            IModuleAppService moduleAppService
        )
        {
            _moduleAppService = moduleAppService;
        }

        //GET

        [Route("get/{moduleId:int}")]
        [HttpGet]
        public IHttpActionResult GetModule(int moduleId)
        {
            var data = _moduleAppService.GetModuleById(moduleId);

            if (data != null)
                return Ok(data);
            else
                return NotFound();
        }

        [Route("get/all")]
        [HttpGet]
        public IHttpActionResult GetModules()
        {
            var data = _moduleAppService.GetModules();

            if (data != null)
                return Ok(data);
            else
                return NotFound();
        }

        //POST

        [Route("insert")]
        [HttpPost]
        public void InsertNewModule(ModuleDto module)
        {
            _moduleAppService.Insert(module);
        }        
    }
}
