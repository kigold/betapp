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
            await TestUserConnected();
;        }
        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await base.OnDisconnectedAsync(exception);
        }

        public async Task TestUserConnected()
        {
            await Clients.All.SendAsync("Test", "New User Connected");
        }
    }
}
