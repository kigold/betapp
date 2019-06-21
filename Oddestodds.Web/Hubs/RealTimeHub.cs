using Microsoft.AspNetCore.SignalR;
using Oddestodds.Logic.DataObjects;
using Oddestodds.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oddestodds.Web.Hubs
{
    public class RealTimeHub : Hub
    {
        private readonly IOddsLogic _oddsLogic;
        const string UpdateOdds = "UpdateOdds";
        public RealTimeHub(IOddsLogic oddslogic)
        {
            _oddsLogic = oddslogic;
        }
        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
            await FetchOdds();
            
        }
        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await base.OnDisconnectedAsync(exception);
        }

        public async Task SendUpdatedOdds(List<OddsData> data)
        {
            _oddsLogic.EditOdds(data);
            var result = _oddsLogic.GetOdds(data.Select(x => x.Id).ToArray());
            await Clients.All.SendAsync(UpdateOdds, result);
        }
        public async Task FetchOdds()
        {
            var result = _oddsLogic.GetOdds().ToArray();
            await Clients.All.SendAsync(UpdateOdds, result);
        }
        public async Task TestUserConnected()
        {
            await Clients.All.SendAsync("Test", "New User Connected");
            var res = _oddsLogic.GetOdds(new[] { 1, 2, 3 });
            await Clients.All.SendAsync("Test", res);

        }
    }
}
