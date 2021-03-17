using CarbTracker.Data;
using CarbTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbTracker.Services
{
    public class BloodSugarTrackerService
    {
        private readonly string _userId;
        public BloodSugarTrackerService (string userId)
        {
            _userId = userId;
        }
        public IEnumerable<BloodSugarTrackerListItem> GetBloodSugarTracker()
        {

            using (var context = new ApplicationDbContext())
            {

                var query = context.BloodSugarTrackers
                                .Select(e => new BloodSugarTrackerListItem

                                {
                                    BSLevelId = e.BSLevelId,
                                    BSLevel = e.BSLevel,
                                    CarbsConsumed = e.CarbsConsumed,
                                    Id = _userId
                                }
                            ) ;

                return query.ToArray();
            }
        }
        public bool CreateBloodSugarTracker(BloodSugarTrackerCreate model)
        {
            var entity =
                new BloodSugarTracker()
                {

                    BSLevel = model.BSLevel,
                    CarbsConsumed = model.CarbsConsumed,
                    Id = _userId
                };

            using (var context = new ApplicationDbContext())
            {
                context.BloodSugarTrackers.Add(entity);
                return context.SaveChanges() == 1;
            }
        }

        public bool DeleteBloodSugarTrackerId (int bsLevelId)
        {
            using (var context = new ApplicationDbContext())
            {
                BloodSugarTracker entity =
                    context
                        .BloodSugarTrackers
                        .Single(e => e.BSLevelId == bsLevelId);

                context.BloodSugarTrackers.Remove(entity);

                return context.SaveChanges() == 1;
            }
        }
        public bool UpdateBloodSugarTracker(BloodSugarTrackerEdit model)
        {
            using (var context = new ApplicationDbContext())
            {
                var entity = context.BloodSugarTrackers.Single(e => e.BSLevelId == model.BSLevelId) ;

                entity.BSLevel = model.BSLevel;
                entity.CarbsConsumed = model.CarbsConsumed;

                return context.SaveChanges() == 1;
            }

        }
    }

}