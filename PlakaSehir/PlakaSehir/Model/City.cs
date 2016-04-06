using System.Collections.Generic;
using Xamarin.Forms;

namespace PlakaSehir
{
    public class City
    {
        public string Plate { get; set; }
        public string Name { get; set; }
        public string PictureAddress { get; set; }
        public List<Trivia> TriviaList { get; set; }
    }
}
