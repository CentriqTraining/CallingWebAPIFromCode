using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;

namespace CallingWebApiFromCode
{
    class Program
    {
        static   void Main(string[] args)
        {
            //  Need to have Newtonsoft.JSON library installed
            //  Either find it from "Manage nuget packages" from right-clicking the project
            //  Or pull up package manager console and type "Install-package newtonsoft.json"
            string url = "http://centriqdata.azurewebsites.net/data/chuck";

            //  Using web client
            WebClient client = new WebClient();
            var results = client.DownloadString(new Uri(url));
            var Toons = JsonConvert.DeserializeObject<List<Toon>>(results);
        }


    }
    public class Datatarget
    {
        public Toon[] items;
    }
}