using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
namespace PayloadApi
{
    public class RobotProvidercs
    {
        //Getting data from svt api
        public string GetRobots()
        {
            var web = new WebClient();
            string url = "https://60c8ed887dafc90017ffbd56.mockapi.io/robots";
            var response = web.DownloadString(url);
            return response;
        }
    }
}
