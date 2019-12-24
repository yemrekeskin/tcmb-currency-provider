using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyProvider.Model
{
   public class Currency
   {
        public string Code { get; set; }
        public string Name { get; set; }        
        
        public double ForexBuying { get; set; }
        public double ForexSelling { get; set; }

        public double BanknoteBuying { get; set; }
        public double BanknoteSelling { get; set; }
        
        public double CrossRateUsd { get; set; }
        public double CrossRateOther { get; set; }
    }
}
