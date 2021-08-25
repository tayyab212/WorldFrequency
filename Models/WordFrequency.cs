using System;
using System.Collections.Generic;
using System.Text;
using WorldFrequency.Interfaces;

namespace WorldFrequency.Models
{
   public class WordFrequency : IWordFrequency
    {
        public string Word { get; set; }
        public int Frequency { get; set; }

    }
}
