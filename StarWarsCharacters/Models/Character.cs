using System;
using System.Collections.Generic;
using System.Text;

namespace StarWarsCharacters.Models
{
    public class Character
    {
        public string name { get; set; }
        public int height { get; set; }
        public int mass { get; set; }
        public string hair_color { get; set; }
        public string skin_color { get; set; }
        public string eye_color { get; set; }
        public string birth_year { get; set; }
        public string gender { get; set; }
    }
}
