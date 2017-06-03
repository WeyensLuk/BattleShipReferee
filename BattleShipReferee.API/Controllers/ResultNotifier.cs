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

        public void Notify(Player player, ShotResult result)
        {
            var request = new RestRequest(player.Url, Method.POST);
            request.AddBody(result.ToString());
            _RestClient.Execute(request);
        }
    }
}