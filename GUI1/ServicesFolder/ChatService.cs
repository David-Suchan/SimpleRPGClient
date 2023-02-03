using GUI1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace GUI1.ServicesFolder
{
    internal class ChatService
    {
        private static WebClient webClient = new WebClient();
        const string url = "http://merlin-app.net:5001";


        public static void PostFieldMessage(string msg)
        {           
            string messageContent = webClient.UploadString(url + "/api/gamedata/chat/fieldmessage", JsonSerializer.Serialize(new { message = msg }));
        }
        public static void PostShoutMessage(string msg)
        {
            string messageContent = webClient.UploadString(url + "/api/gamedata/chat/shoutmessage", JsonSerializer.Serialize(new { message = msg }));
        }
        public static void PostClanMessage(string msg)
        {
            string messageContent = webClient.UploadString(url + "/api/gamedata/chat/clanmessage", JsonSerializer.Serialize(new { message = msg }));
        }
        
        static ChatService()
        {
            webClient.Headers["x-api-token"] = $"{Services.httpServices.Session.Token}";
            webClient.Headers["content-type"] = "application/json";
        }
    }
}
