using System.Collections.Generic;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System.Linq;

namespace WebApplication1
{
    [HubName("ChatHub")]
    public class ChatHub : Hub
    {
        [HubMethodName("Send")]
        public void Send(string name, string message)
        {
            Clients.All.broadcastMessage(name, message);
        }
        [HubMethodName("Send")]
        public void Send(string name, string toname, string message)
        {
            var fromId = UserHandler.ConnectedIds.Where(p => p.Value == name).FirstOrDefault().Key;

            var toId = UserHandler.ConnectedIds.Where(p => p.Value == toname).FirstOrDefault().Key;
            //var toId=UserHandler.ConnectedIds.Where(p.Key==Context.)
            
            Clients.Client(toId).addContosoChatMessageToPage(name, toname, message);
            
        }

        [HubMethodName("UserConnected")]
        public void UserConnected(string name)
        {
            UserHandler.ConnectedIds.Add(Context.ConnectionId, name);
        }


        /// <summary>
        /// 使用者
        /// </summary>
        public static class UserHandler
        {
            public static Dictionary<string, string> ConnectedIds = new Dictionary<string, string>();
        }
    }
}