using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using StackOverBros2.Objects;

namespace StackOverBros2.Challenge_Classes
{
    class ApiClass
    {
        public IRestResponse<GetChallenge> ApiGet(int id)
        {
            var client = new RestClient("htf2018.azurewebsites.net");

            var request = new RestRequest(String.Format("challenges/{0}", id), Method.GET);
            request.AddHeader("htf-identification", "ZGJkOWZjOGUtODE4NS00YjEzLWI0OWQtMjUxZmU3MTIwODVk");

            GetChallenge challenge = new GetChallenge();

            IRestResponse<GetChallenge> response = client.Execute<GetChallenge>(request);
            string titel = response.Data.title;

            return response;
        }

        public void ApiPost()
        {
            
        }
    }
}
