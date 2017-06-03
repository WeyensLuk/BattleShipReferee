using System;
using BattleShipReferee.API.Domain;
using RestSharp;

namespace BattleShipReferee.API.Business
{
    public class TurnNotifier
    {
        private readonly IRestClient _RestClient;

        public TurnNotifier(IRestClient client)
        {
            _RestClient = client;
        }

        public TurnNotifier() : this(new RestClient())
        {

        }

        public void Notify(Player player)
        {
            player.IsMyTurn = true;
            _RestClient.Execute(new RestRequest(new Uri(player.Url), Method.POST));
        }
    }
}