using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace DeckofCardsAPILab.Models
{
    public class DeckDAL
    {
        public string Shuffle()
        {
            string url = @$"https://deckofcardsapi.com/api/deck/new/shuffle/?deck_count=1";

            HttpWebRequest request = WebRequest.CreateHttp(url);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader reader = new StreamReader(response.GetResponseStream());
            string JSON = reader.ReadToEnd();

            return JSON;
        }
        public string DrawCards(string deckId,int cardAmount)
        {
            
            string url = @$"https://deckofcardsapi.com/api/deck/{deckId}/draw/?count={cardAmount}";

            HttpWebRequest request = WebRequest.CreateHttp(url);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader reader = new StreamReader(response.GetResponseStream());
            string JSON = reader.ReadToEnd();

            return JSON;
        }
        //public string NewDeck()
        //{
        //    string url = @$"https://deckofcardsapi.com/api/deck/new";

        //    HttpWebRequest request = WebRequest.CreateHttp(url);

        //    HttpWebResponse response = (HttpWebResponse)request.GetResponse();

        //    StreamReader reader = new StreamReader(response.GetResponseStream());
        //    string JSON = reader.ReadToEnd();

        //    return JSON;
        //}

        public CardModel GetCards(string deckId, int cardAmount)
        {
            string draw = DrawCards(deckId,cardAmount);
            CardModel deckCard = JsonConvert.DeserializeObject<CardModel>(draw);

            return deckCard;

        }

        public DeckModel ShuffleCards()
        {
            string shuf = Shuffle();
            DeckModel drawn = JsonConvert.DeserializeObject<DeckModel>(shuf);

            return drawn;
        }
    }
       
      
        
    }




