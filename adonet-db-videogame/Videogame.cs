using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adonet_db_videogame
{
    public class Videogioco
    {
        public int ID { get; set; }
        public string _name { get; set; }
        public string _overview { get; set; }
        public DateTime _release_date { get; set; }
        public DateTime _created_at { get; set; }
        public DateTime _updated_at { get; set; }
        public int _sofware_house_id { get; set; }

        public Videogioco(int id, string name, string overview, DateTime release_date, DateTime created_at, DateTime update_at, int sofware_house)
        {
            ID = id;
            _name = name;
            _overview = overview;
            _release_date = release_date;
            _created_at = created_at;
            _updated_at = update_at;
            _sofware_house_id = sofware_house;
        }
    }

}