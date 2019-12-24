# Tcmb-Currency-Provider
📈 💰 Provider Daily Exchange Rates Announced by the Central Bank of Turkey. 

## Project Features
- Service Executer for web service call
- **Object Caching** Mechanism with endpoint path key (daily)
  - Tcmb updates the rates every day at 3.30pm 
- **XML** Response Deseriliazer
- Service Endpoints
  - https://www.tcmb.gov.tr/kurlar/today.xml
  - https://www.tcmb.gov.tr/kurlar/201512/25122015.xml
    - BültenNo Format
    - Year{0:0000} Month{0:00} Day{0:00}
    - BültenNo = year + month + "/" + day + month + year 

## Class Diagram

<img src="https://raw.githubusercontent.com/yemrekeskin/tcmb-currency-provider/master/CurrencyProvider/ClassDiagram.png"> 


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
