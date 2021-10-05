using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCP.Models
{
    public class FootBallPlayer
    {

        private int _id;
        private string _name;
        private int _price;
        private int _shirtNumber;

        public int ID
        {
            get => _id;
            set => _id = value;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public int Price
        {
            get => _price;
            set => _price = value;
        }

        public int ShirtNumber
        {
            get => _shirtNumber;
            set => _shirtNumber = value;
        }
    }
}
