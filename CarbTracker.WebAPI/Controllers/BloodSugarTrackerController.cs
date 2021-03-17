using CarbTracker.Data;
using CarbTracker.Models;
using CarbTracker.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarbTracker.WebAPI.Controllers
{
    //[Authorize]
    public class BloodSugarTrackerController : ApiController
    {
        public IHttpActionResult Get()
        {
            BloodSugarTrackerService bloodSugarTrackerService = CreateBloodSugarTrackerService();
            var bloodSugarTracker = bloodSugarTrackerService.GetBloodSugarTracker();
            return Ok(bloodSugarTracker);
        }

        public IHttpActionResult Post(BloodSugarTrackerCreate bloodSugarTracker)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateBloodSugarTrackerService();

            if (!service.CreateBloodSugarTracker(bloodSugarTracker))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int bsLevelID)
        {
            var service = CreateBloodSugarTrackerService();

            if (!service.DeleteBloodSugarTrackerId(bsLevelID))
                return InternalServerError();
            return Ok();
        }

        public IHttpActionResult Put(BloodSugarTrackerEdit bloodSugarTracker)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateBloodSugarTrackerService();

            if (!service.UpdateBloodSugarTracker(bloodSugarTracker))
                return InternalServerError();

            return Ok();
        }

        private BloodSugarTrackerService CreateBloodSugarTrackerService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var bloodSugarTrackerService = new BloodSugarTrackerService(userId.ToString());
            return bloodSugarTrackerService;
        }
    }
}
