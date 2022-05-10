using Front_App_Amundi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace Front_App_Amundi.Service
{
    public class RequestService
    {

        public readonly string requestAPIUrl= "https://localhost:7185/api/Request";
        public  HttpClient client;

        public RequestService()
        {
        }

        public async Task<RequestSettings[]> getAllRequest()
        {
            this.client = new HttpClient();

            using (client)
            {
                using (HttpResponseMessage response = await client.GetAsync($"{requestAPIUrl}/GetAllRequests/ADMIN"))
                {
                    using (HttpContent content = response.Content)
                    {

                        RequestSettings[] listRequests = JsonConvert.DeserializeObject<RequestSettings[]>(await content.ReadAsStringAsync());
           
                        return  listRequests;
                    }
                }
            }
        }

        public async void StartedRequest(RequestSettings request, DataGrid dataGrid)
        {
            this.client = new HttpClient();
            this.clearDataGread(dataGrid);

            using (client)
            {
                using (HttpResponseMessage response = await client.GetAsync($"{requestAPIUrl}/startRequest/" + request.id))
                {
                    using (HttpContent content = response.Content)
                    {
                        JArray jsonArray = JArray.Parse(await content.ReadAsStringAsync());
                        JObject responseRequest = JObject.Parse(jsonArray[0].ToString());

                       
                        Dictionary<string, string> dictObj = responseRequest.ToObject<Dictionary<string, string>>();

                        List<String> columns = new List<string>();

                        dictObj.Keys.ToList().ForEach(p =>
                        {

                            var newColumn = new DataGridTextColumn();
                            newColumn.Header = p;
                            newColumn.Binding = new Binding(p);
                            dataGrid.Columns.Add(newColumn);

                            columns.Add(p);
                        });

                       foreach(var row in jsonArray)
                        {
                            dataGrid.Items.Add(row);
                        }


                        request.columns = columns.ToArray();
                        request.row = jsonArray;
                        var src = DateTime.Now;
                        request.hourOfStart = new DateTime(src.Year, src.Month, src.Day, src.Hour, src.Minute, src.Second);

                        dataGrid.Items.Add(request);
                    }
                }
            }
        }

        public void showRequest(RequestSettings request, DataGrid dataGrid)
        {
            this.clearDataGread(dataGrid);

            request.columns.ToList().ForEach(p =>
            {

                var newColumn = new DataGridTextColumn();
                newColumn.Header = p;
                newColumn.Binding = new Binding(p);
                dataGrid.Columns.Add(newColumn);

            });

            foreach (var row in request.row)
            {
                dataGrid.Items.Add(row);
            }



        }

        private void clearDataGread(DataGrid dataGrid)
        {
            dataGrid.Items.Clear();
            dataGrid.Columns.Clear();
        }
    }
}

