using CurrencyProvider.Cache;
using CurrencyProvider.Entity;
using CurrencyProvider.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyProvider.Service
{
    public class CurrencyService
    {
        private readonly IServiceExecuter serviceExecuter = null;
        private readonly ICacher cacher = null;

        public CurrencyService()
        {
            serviceExecuter = new ServiceExecuter();
            serviceExecuter.ResponseType = ResponseType.XML;
            serviceExecuter.Endpoint = "https://www.tcmb.gov.tr";

            cacher = new Cacher();
        }

        public List<Currency> GetCurrencyRates(DateTime date)
        {
            string year = String.Format("{0:0000}", date.Year);
            string month = String.Format("{0:00}", date.Month);
            string day = String.Format("{0:00}", date.Day);
            string bultenNo = year + month + "/" + day + month + year;
            string path = "/kurlar/" + bultenNo + ".xml";

            var result = ServiceCall(path);
            return result;
        }

        public List<Currency> GetCurrencyRates(int Year, int Month, int Day)
        {
            string year = String.Format("{0:0000}", Year);
            string month = String.Format("{0:00}", Month);
            string day = String.Format("{0:00}", Day);
            string bultenNo = year + month + "/" + day + month + year;
            string path = "/kurlar/" + bultenNo + ".xml";

            var result = ServiceCall(path);
            return result;
        }

        private List<Currency> ServiceCall(string path)
        {
            var data = serviceExecuter.InvokeGet<CurrencyEntityList>(path);

            List<Currency> currencyRates = new List<Currency>();
            if (data.Success)
            {
                var cacheData = cacher.Get<List<Currency>>(path);
                if (cacheData == null)
                {
                    currencyRates = FullMap(data.Result.Currencies);

                    // ADD CACHE
                    // Create a dateoffset until next 3.30pm
                    // Tcmb updates the rates every day at 3.30pm 
                    var now = DateTime.Now;
                    var today = now.Date;
                    var nextPublishTime = today.AddHours(15).AddMinutes(31).AddDays(now.Hour >= 15 && now.Minute >= 31 ? 1 : 0);
                    TimeSpan ts = TimeSpan.FromTicks(nextPublishTime.ToUniversalTime().Ticks);

                    cacher.Add<List<Currency>>(path, currencyRates, ts);
                }
                else
                {
                    currencyRates = cacheData;
                }
            }
            return currencyRates;
        }

        private Currency Map(CurrencyEntity entity)
        {
            Currency currency = new Currency();
            currency.Code = entity.CurrencyCode;
            currency.Name = entity.CurrencyName;

            currency.ForexBuying = String.IsNullOrEmpty(entity.ForexBuying) ? 0 : Convert.ToDouble(entity.ForexBuying.Trim().Replace(".", ","));
            currency.ForexSelling = String.IsNullOrEmpty(entity.ForexSelling) ? 0 : Convert.ToDouble(entity.ForexSelling.Trim().Replace(".", ","));

            currency.BanknoteBuying = String.IsNullOrEmpty(entity.BanknoteBuying) ? 0 : Convert.ToDouble(entity.BanknoteBuying.Trim().Replace(".", ","));
            currency.BanknoteSelling = String.IsNullOrEmpty(entity.BanknoteSelling) ? 0 : Convert.ToDouble(entity.BanknoteSelling.Trim().Replace(".", ","));

            currency.CrossRateUsd = String.IsNullOrEmpty(entity.CrossRateUsd) ? 0 : Convert.ToDouble(entity.CrossRateUsd.Trim().Replace(".", ","));
            currency.CrossRateOther = String.IsNullOrEmpty(entity.CrossRateOther) ? 0 : Convert.ToDouble(entity.CrossRateOther.Trim().Replace(".", ","));

            return currency;
        }

        private List<Currency> FullMap(List<CurrencyEntity> entityList)
        {
            List<Currency> currencies = new List<Currency>();
            foreach (var entity in entityList)
            {
                currencies.Add(Map(entity));
            }
            return currencies;
        }
    }
}
