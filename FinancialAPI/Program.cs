using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace FinancialAPI
{
    class Program
    {
        public static void Main(string[] args)
        {
            Apihelper.initialize();

            try
            {

                //string revenue_of = "Microsoft Corporation";
                //dataProcessor.storeKey(revenue_of);
                dataProcessor.loadData("MSFT");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"There was an exception: {ex.ToString()}");
            }

            Console.Read();
            

            //GetFINANCE();
            //Console.Read();
            //Program p = new Program();
            //p.data();
            //Console.Read();
            //Console.WriteLine("MAIN");
        }
        //private async void onload()
        //{

        //}
        //public static async Task load()
        //{

        //}


        public async void data()
        {
            using (var httpClient = new HttpClient())

            {
                using (var request = new HttpRequestMessage(new HttpMethod("GET"), "https://financialmodelingprep.com/api/company/profile/AAPL?datatype=json"))

                {
                    request.Headers.TryAddWithoutValidation("Upgrade-Insecure-Requests", "1");
                    Console.WriteLine("hello");
                    Console.ReadKey();

                    var response = await httpClient.SendAsync(request);
                    Console.WriteLine("Asas");
                    Console.WriteLine(response);
                    Console.ReadLine();
                }
            }
        }
        //Now define your asynchronous method which will retrieve all your pokemon.
        public static async void GetFINANCE()
        {
            //Define your baseUrl
            string baseUrl = "https://financialmodelingprep.com/api/company/profile/AAPL?datatype=json";
            //Have your using statements within a try/catch block
            try
            {
                //We will now define your HttpClient with your first using statement which will implements a IDisposable interface.
                using (HttpClient client = new HttpClient())
                {

                    //In the next using statement you will initiate the Get Request, use the await keyword so it will execute the using statement in order.
                    using (HttpResponseMessage res = await client.GetAsync(baseUrl))
                    {
                        res.Headers.TryAddWithoutValidation("Upgrade-Insecure-Requests", "1");

                        //Then get the content from the response in the next using statement, then within it you will get the data, and convert it to a c# object.
                        using (HttpContent content = res.Content)
                        {
                            //Now assign your content to your data variable, by converting into a string using the await keyword.
                            var data = await content.ReadAsStringAsync();
                            //If the data isn't null return log convert the data using newtonsoft JObject Parse class method on the data.
                            if (content != null)
                            {
                                //Now log your data object in the console
                                Console.WriteLine("data------------{0}", JObject.Parse(data)["results"]);

                            }
                            else
                            {
                                Console.WriteLine("NO Data----------");
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("Exception Hit------------");
                Console.WriteLine(exception);
            }
        }
    }
}
