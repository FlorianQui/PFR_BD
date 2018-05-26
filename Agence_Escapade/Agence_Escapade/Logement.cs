using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Agence_Escapade
{
    public class Logement
    {

        private int host, room_id, borough, reviews, overall_satisfaction, accomodates, bedrooms, price, minstay;
        private string room_type, neighborhood;
        private float latitude, longitude;

        public Logement()
        {

        }

        public int host_id { get => host; set => host = value; }
        public int Room_id { get => room_id; set => room_id = value; }
        public int Borough { get => borough; set => borough = value; }
        public int Reviews { get => reviews; set => reviews = value; }
        public int Overall_satisfaction { get => overall_satisfaction; set => overall_satisfaction = value; }
        public int Accomodates { get => accomodates; set => accomodates = value; }
        public int Bedrooms { get => bedrooms; set => bedrooms = value; }
        public int Price { get => price; set => price = value; }
        public int Minstay { get => minstay; set => minstay = value; }
        public string Room_type { get => room_type; set => room_type = value; }
        public string Neighborhood { get => neighborhood; set => neighborhood = value; }
        public float Latitude { get => latitude; set => latitude = value; }
        public float Longitude { get => longitude; set => longitude = value; }

        public override string ToString()
        {
            return "[LOCATION] \n" + JsonConvert.SerializeObject(this, Formatting.Indented) + "\n\n";
        }
    }
}
