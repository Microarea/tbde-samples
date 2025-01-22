using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace TbApiTester
{
    internal class LogCredential
    {
        public class LoginDetails
        {
            public string Username { get; set; }
            public string Password { get; set; }
            public string Subscription { get; set; }
            public string Producer { get; set; }
            public string App { get; set; }
        }

        private readonly string _fileName = "loginDetails.json";

        // Metodo per salvare i dettagli di login per un ambiente specifico
        public void SaveLoginDetails(string environment, string username, string password, string subscription, string producer, string app)
        {
            var loginDetails = new LoginDetails
            {
                Username = username,
                Password = password,
                Subscription = subscription,
                Producer = producer,
                App = app
            };

            var allDetails = LoadAllLoginDetails() ?? new Dictionary<string, LoginDetails>();
            allDetails[environment] = loginDetails;

            string json = JsonConvert.SerializeObject(allDetails, Formatting.Indented);
            File.WriteAllText(_fileName, json);
        }

       
        public LoginDetails LoadLoginDetails(string environment)
        {
            var allDetails = LoadAllLoginDetails();
            if (allDetails != null && allDetails.ContainsKey(environment))
            {
                return allDetails[environment];
            }
            return null;
        }

       
        public void SaveCredentialsFromForm(string environment, string username, string password, string subscription, string producer, string app)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("Username and password cannot be empty.");
            }

            SaveLoginDetails(environment, username, password, subscription, producer, app);
        }

       
        private Dictionary<string, LoginDetails> LoadAllLoginDetails()
        {
            if (File.Exists(_fileName))
            {
                string json = File.ReadAllText(_fileName);
                return JsonConvert.DeserializeObject<Dictionary<string, LoginDetails>>(json);
            }
            return null;
        }
    }
}