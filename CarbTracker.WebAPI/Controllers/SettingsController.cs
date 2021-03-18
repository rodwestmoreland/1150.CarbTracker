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
    [Authorize]
    public class SettingsController : ApiController
    {
        public IHttpActionResult Get()
        {
            SettingsService settingsService = CreateSettingsService();
            var settings = settingsService.GetSettings();
            return Ok(settings);
        }

        public IHttpActionResult Put(SettingsEdit settings)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateSettingsService();

            if (!service.UpdateSettings(settings))
                return InternalServerError();

            return Ok();
        }

        private SettingsService CreateSettingsService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var settingsService = new SettingsService(userId.ToString());
            return settingsService;
        }
    }
}
