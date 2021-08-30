using System;
using System.Collections.Generic;
using System.Text;

namespace WorldFrequency.Interfaces
{
  public  interface IWordFrequency
    {
        string Word { get; }
        int Frequency { get; }
    }
}
