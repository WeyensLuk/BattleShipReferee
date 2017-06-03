using BattleShipReferee.API.Domain;
using RestSharp;

namespace BattleShipReferee.API.Controllers
{
    public class ResultNotifier
    {
        private readonly IRestClient _RestClient;

        public ResultNotifier(IRestClient client)
        {
            _RestClient = client;
        }

        public ResultNotifier() : this(new RestClient())
        {
        }

        public void Notify(Player player, string result)
        {
            var request = new RestRequest(player.Url, Method.POST);
            request.AddBody(result);
            _RestClient.Execute(request);
        }
    }
}