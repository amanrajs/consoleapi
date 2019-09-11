using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FinancialAPI
{
    class dataProcessor
    {

        public static async void loadData(string symbol)
        {
            Console.WriteLine(symbol);
            string url = "https://financialmodelingprep.com/api/v3/financials/income-statement/";
            url += symbol;
            url +="?datatype = json";
            using (HttpResponseMessage res = await Apihelper.apiClient.GetAsync(url))
            {
                if (res.IsSuccessStatusCode)
                {
                    string responseContent = await res.Content.ReadAsStringAsync();
                    var obj = JsonConvert.DeserializeObject<DataModel>(responseContent);
                    Console.WriteLine(obj.financials[0].Revenue);
                    Console.Read();
                }
                else
                {
                    throw new Exception(res.ReasonPhrase);
                }
            }
    }

        public static async void storeKey(string key)
        {
            string url = "https://financialmodelingprep.com/api/v3/company/stock/list?datatype=json";
            using (HttpResponseMessage res = await Apihelper.apiClient.GetAsync(url))
            {
                if (res.IsSuccessStatusCode)
                {
                    string responseContent = await res.Content.ReadAsStringAsync();
                    var obj = JsonConvert.DeserializeObject<KeyModel>(responseContent);
                    for(int item = 0; item < obj.symbolsList.Count; item++)
                    {
                        if (string.Equals(obj.symbolsList[item].name, key) )
                        {
                            Console.WriteLine(obj.symbolsList[item].symbol);
                            Console.Read();


                            loadData(obj.symbolsList[item].symbol);

                        }

                    }
                }
                else
                {
                    throw new Exception(res.ReasonPhrase);
                }
            }
        }
    }
}
