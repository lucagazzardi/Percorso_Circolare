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
    [RoutePrefix("api/resource")]
    public class ResourceController : ApiController
    {

        private readonly IResourceAppService _resourceAppService;

        public ResourceController
        (
            IResourceAppService resourceAppService
        )
        {
            _resourceAppService = resourceAppService;
        }

        //GET

        [Route("get/{resourceId:int}")]
        [HttpGet]
        public IHttpActionResult GetResource(int resourceId)
        {
            var data = _resourceAppService.GetResourceById(resourceId);

            if (data != null)
                return Ok(data);
            else
                return NotFound();
        }

        [Route("get/all")]
        [HttpGet]
        public IHttpActionResult GetResources()
        {
            var data = _resourceAppService.GetResources();

            if (data != null)
                return Ok(data);
            else
                return NotFound();
        }

        //POST

        [Route("insert")]
        [HttpPost]
        public void InsertNewResource(ResourceDto resource)
        {
            _resourceAppService.Insert(resource);
        }
    }
}
