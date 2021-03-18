using CarbTracker.Data;
using CarbTracker.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbTracker.Services
{
    public class SettingsService
    {
        private readonly string _userId;
        public SettingsService(string userId)
        {
            _userId = userId;
        }
        public SettingsListItem GetSettings()
        {

            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                var query = context.Users


                                 .FirstOrDefault(e => e.Id == _userId);
                var settings = new SettingsListItem()
                {
                    FirstName = query.FirstName,
                    LastName = query.LastName,
                    InsulinToCarbRatio = query.InsulinToCarbRatio.GetValueOrDefault(),
                    CorrectionFactor = query.CorrectionFactor.GetValueOrDefault()
                };

                return settings; 
            }
        }

        public bool UpdateSettings(SettingsEdit model)
        {
            using (var context = new ApplicationDbContext())
            {
                var entity = context.Users
                    .Single(e => e.Id == _userId);

                entity.InsulinToCarbRatio = model.InsulinToCarbRatio;
                entity.CorrectionFactor = model.CorrectionFactor;

                return context.SaveChanges() == 1;
            }
        }
    }
}
