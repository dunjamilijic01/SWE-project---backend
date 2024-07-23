using System.Threading.Tasks;
using Connections;
using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Models;

namespace Hubs
{
    public class StoloviHub:Hub
    {
        public readonly IDictionary<string, UserConnection> _connections;
        public StoloviHub(IDictionary<string,UserConnection> connections)
        {
            _connections = connections;
        }
        public async Task SendMessage(string message)
        {
            {

                await Clients.All.SendAsync("Rezervacije",message);

            }
        }
        public async Task SendStolove(List<Sto> stolovi)
        {
        if(_connections.TryGetValue(Context.ConnectionId, out UserConnection userConnection))
            {
                await Clients.Groups(userConnection.kafic)
                    .SendAsync("RecieveStoMessage", userConnection.userId, stolovi);
            }
        }
        public async Task JoinApp(UserConnection userConnection)
        {
             _connections[Context.ConnectionId] = userConnection;
            await Groups.AddToGroupAsync(Context.ConnectionId, userConnection.kafic);
            await Clients.Group(userConnection.kafic).SendAsync("RecieveMessage", 1 ,"caooo");
            //ako bude nekih problema mozda je ove
            
        }
    }
}