using CurrencyProvider.Entity;
using CurrencyProvider.Service;
using System;

namespace ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.Write("Hello World");

            var executer = new ServiceExecuter();
            executer.ResponseType = ResponseType.XML;
            executer.Endpoint = "https://www.tcmb.gov.tr";
            var data = executer.InvokeGet<CurrencyEntityList>("/kurlar/today.xml");

            var service = new CurrencyService();
            var response = service.GetCurrencyRates(2015, 12, 10);
            var response1 = service.GetCurrencyRates(2015, 12, 10);

            Console.ReadLine();
        }
    }
}