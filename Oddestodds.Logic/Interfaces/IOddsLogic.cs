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
        void DeleteOdds(int Id);
        IEnumerable<OddsData> GetOdds();
    }
}
