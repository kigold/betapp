using Oddestodds.Logic.DataObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oddestodds.Logic.Interfaces
{
    public interface IOddsLogic
    {
        void CreateOdds(OddsData data);
        void EditOdds(OddsData data);
        void EditOdds(List<OddsData> data);
        void DeleteOdds(int id);
        IEnumerable<OddsData> GetOdds();
        IEnumerable<OddsData> GetOdds(int[] ids);
    }
}
