using GUI1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;
using System.Text.Json;
using System.Windows;

namespace GUI1.ServicesFolder
{
    internal class HttpServices
    {
        
        public Session Session;
        private WebClient webClient;
        const string url = "http://merlin-app.net:5001";
        public static Player PlayerInfo {get; set;}

        
        public void Login(string username,string password)
        {
            
            string jsonContent = JsonSerializer.Serialize(new UserInfo() { Email = username, Password = password });
            string sessionInfo = webClient.UploadString(url + "/api/auth/login", jsonContent);
            this.Session = JsonSerializer.Deserialize<Session>(sessionInfo);
            this.webClient.Headers["x-api-token"] = $"{this.Session.Token}";
            string playerInfo = webClient.DownloadString("http://merlin-app.net:5001/api/gamedata/player/me");
            Player player = JsonSerializer.Deserialize<Player>(playerInfo);
            PlayerInfo = player;
            WindowManager.OpenMainWindow();
            WindowManager.CloseLoginWindow();   
            

        }

        public void Register(string email,  string username,  string password)
        {
            try
            {
                string jsonContent = JsonSerializer.Serialize(new UserInfo() { Email = email, Username = username, Password = password });
                string sessionInfo = webClient.UploadString("http://merlin-app.net:5001/api/registration/new", jsonContent);
            }
            catch (Exception)
            {

                return;
            }
            

        }

        public HttpServices()
        {
            webClient = new WebClient();
            this.webClient.Headers["content-type"] = "application/json";
            
        }
    }
}
