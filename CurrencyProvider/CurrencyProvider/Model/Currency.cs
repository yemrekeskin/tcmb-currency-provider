using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyProvider.Model
{
   public class Currency
   {
        public string Code { get; }
        public string Name { get; }        
        
        public double ForexBuying { get; }
        public double ForexSelling { get; }

        public double BanknoteBuying { get; }
        public double BanknoteSelling { get; }
        
        public double CrossRateUsd { get; set; }
        public double CrossRateOther { get; set; }
    }
}
