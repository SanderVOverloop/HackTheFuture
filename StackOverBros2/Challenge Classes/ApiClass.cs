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
        public IRestResponse<GetChallenge> ApiGet(string id)
        {
            var baseurl = "http://htf2018.azurewebsites.net/";

            var client = new RestClient();
            client.BaseUrl = new System.Uri(baseurl);

            var request = new RestRequest(String.Format("challenges/{0}", id), Method.GET);
            request.AddHeader("htf-identification", "ZGJkOWZjOGUtODE4NS00YjEzLWI0OWQtMjUxZmU3MTIwODVk");

            GetChallenge challenge = new GetChallenge();

            IRestResponse<GetChallenge> response = client.Execute<GetChallenge>(request);

            return response;
        }

        public IRestResponse<PostChallenge> ApiPost(string challengeId, string id, List<InputValue> values)
        {
            var baseurl = "http://htf2018.azurewebsites.net/";

            var client = new RestClient();
            client.BaseUrl = new System.Uri(baseurl);

            var request = new RestRequest(String.Format("challenges/{0}", id), Method.POST);
            request.AddHeader("Content-type", "application/json");
            request.AddHeader("htf-identification", "ZGJkOWZjOGUtODE4NS00YjEzLWI0OWQtMjUxZmU3MTIwODVk");

            PostObject obj = new PostObject();
            obj.challengeId = challengeId;
            obj.values = values;

            //request.AddJsonBody(obj);

            var json = request.JsonSerializer.Serialize(obj);

            request.AddParameter("application/json; charset=utf-8", json, ParameterType.RequestBody);

            //request.JsonSerializer.Serialize(obj);

            //request.AddObject(obj);

            PostChallenge challenge = new PostChallenge();

            IRestResponse<PostChallenge> response = client.Execute<PostChallenge>(request);

            return response;
        }
    }
}
