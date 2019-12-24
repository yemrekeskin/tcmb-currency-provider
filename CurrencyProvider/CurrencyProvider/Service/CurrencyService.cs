using CurrencyProvider.Entity;
using CurrencyProvider.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyProvider.Service
{
    public class CurrencyService
    {
        public Dictionary<string, Currency> GetCurrencyRates()
        {
            Dictionary<string, Currency> currencyRates = new Dictionary<string, Currency>();

            return currencyRates;
        }

        private Currency Map(CurrencyEntity entity)
        {
            Currency currency = new Currency();

            return currency;
        }

        private List<Currency> FullMap(List<CurrencyEntity> entity)
        {
            List<Currency> currencies = new List<Currency>();

            return currencies;
        }
    }
}
