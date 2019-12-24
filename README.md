# Tcmb-Currency-Provider

## Project Features
- Service Executer for web service call
- Caching by endpoint path (daily)
- XML Response Deseriliazer
- Service Endpoints
  - https://www.tcmb.gov.tr/kurlar/today.xml
  - https://www.tcmb.gov.tr/kurlar/201512/25122015.xml

## Usage

```CSharp
var executer = new ServiceExecuter();
executer.ResponseType = ResponseType.XML;
executer.Endpoint = "https://www.tcmb.gov.tr";
var data = executer.InvokeGet<CurrencyEntityList>("/kurlar/today.xml");

var service = new CurrencyService();
var response = service.GetCurrencyRates(2015, 12, 10);
var cacheResponse = service.GetCurrencyRates(2015, 12, 10);
```


## Contribution
Pull requests are welcome, but make sure you sign the Contributor License Agreement.

## License

Tcmb-Currency-Provider is licensed under the MIT license. Check the [LICENSE](LICENSE) file for details.
