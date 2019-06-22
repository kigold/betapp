using Oddestodds.Data;
using Oddestodds.Logic.DataObjects;
using Oddestodds.Logic.Interfaces;
using System;
using System.Linq;
using System.Collections.Generic;
using Oddestodds.Data.Entities;

namespace Oddestodds.Logic
{
    public class OddsLogic : IOddsLogic
    {
        private readonly ApplicationDbContext _context;
        public OddsLogic(ApplicationDbContext context)
        {
            _context = context;
        }
        public int CreateOdds(OddsData data)
        {
            if (data == null)
                throw new ArgumentNullException();
            try
            {
                var odd = new Odd
                {
                    Name = data.Name,
                    Home = data.Home,
                    Away = data.Away,
                    Draw = data.Draw
                };
                _context.Odds.Add(odd);
                _context.SaveChanges();
                return odd.Id;
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        public void DeleteOdds(int id)
        {
            try
            {
                var odd = _context.Odds.Find(id);
                if (odd == null)
                    throw new NullReferenceException("Odd not found");
                _context.Odds.Remove(odd);
                _context.SaveChanges();
            }
            catch(Exception e)
            {

            }
        }

        public void EditOdds(OddsData data)
        {
            var odd = _context.Odds.Find(data.Id);
            if (odd == null)
                throw new NullReferenceException("Odd not found");
            odd.Name = data.Name;
            odd.Home = data.Home;
            odd.Away = data.Away;
            odd.Draw = data.Draw;
            _context.SaveChanges();
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
            try
            {
                var result = _context.Odds.Where(x => ids.Contains(x.Id))
                    .ToList().Select(x => new OddsData
                {
                    Id = x.Id,
                    Name = x.Name,
                    Away = x.Away,
                    Home = x.Home,
                    Draw = x.Draw
                });
                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
