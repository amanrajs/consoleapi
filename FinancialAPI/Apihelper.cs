using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace FinancialAPI
{
    static class Apihelper
    {
        public static HttpClient apiClient { get; set; }

        public static void initialize()
        {
            apiClient = new HttpClient();

            //apiClient.BaseAddress = new Uri("https://financialmodelingprep.com/api/v3/financials/income-statement/AAPL?datatype=json");

            apiClient.DefaultRequestHeaders.Accept.Clear();
            apiClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

        }
    }
}
