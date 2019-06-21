using Oddestodds.Data;
using Oddestodds.Logic.DataObjects;
using Oddestodds.Logic.Interfaces;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Oddestodds.Logic
{
    public class OddsLogic : IOddsLogic
    {
        private readonly ApplicationDbContext _context;
        public OddsLogic(ApplicationDbContext context)
        {
            _context = context;
        }
        public void CreateOdds(OddsData data)
        {
            throw new NotImplementedException();
        }

        public void DeleteOdds(int Id)
        {
            throw new NotImplementedException();
        }

        public void EditOdds(OddsData data)
        {
            throw new NotImplementedException();
        }

        public void EditOdds(List<OddsData> data)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OddsData> GetOdds()
        {
            try
            {
                var result = _context.Odds.ToList().Select(x => new OddsData
                {
                    Id = x.Id,
                    Name = x.Name,
                    Away = x.Away,
                    Home = x.Home,
                    Draw = x.Draw
                });
                return result;
            }
            catch(Exception e)
            {
                throw;
            }
        }

        public IEnumerable<OddsData> GetOdds(int[] ids)
        {
            throw new NotImplementedException();
        }
    }
}
