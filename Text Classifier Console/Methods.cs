using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Text_Classifier_Console
{
    
     class Methods
    {
        private string requestTxt;
        private string endpoint;
        static readonly HttpClient client = new HttpClient();

        public Methods(string txt)
        {
            this.requestTxt = txt;
            this.endpoint = "https://text-classification-bart.ai-sandbox.4th-ir.io/api/v1/classify";
            
        }

        public async Task classify()
        {
            var requestObj = new { text = requestTxt };

            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync(endpoint, requestObj);
                response.EnsureSuccessStatusCode();
                Console.WriteLine("Success");
                var responseString = await response.Content.ReadFromJsonAsync<SuccessResponse>();
                var result = responseString.label;
                //return result
                Console.WriteLine(result);
            }catch(Exception e) {
                Console.WriteLine("\nException Caught!");
               Console.WriteLine(e.Message);
                //return e.Message;
            }
            
        }
    }

    public class SuccessResponse
    {
        public string label { get; set; }
        //public string conversion_text { get; set; }
    }
}
