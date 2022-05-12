using Front_App_Amundi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Shapes;

namespace Front_App_Amundi.Service
{
    public class RequestService
    {

        public readonly string requestAPIUrl = "https://localhost:7185/api/Request";
        public HttpClient client;

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

                        return listRequests;
                    }
                }
            }
        }

        public async void StartedRequest(RequestSettings request, DataGrid dataGrid, Ellipse elipse, List<RequestSettings> listRequestsStarted, ListBox LbxRequestStarted)
        {
            this.client = new HttpClient();
            this.clearDataGread(dataGrid);

            using (client)
            {
                using (HttpResponseMessage response = await client.GetAsync($"{requestAPIUrl}/startRequest/ {request.id}"))
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

                        foreach (var row in jsonArray)
                        {
                            dataGrid.Items.Add(row);
                        }


                        request.columns = columns.ToArray();
                        request.row = jsonArray;
                        var src = DateTime.Now;
                        request.hourOfStart = new DateTime(src.Year, src.Month, src.Day, src.Hour, src.Minute, src.Second);
                        listRequestsStarted.Insert(0, request);

                        dataGrid.Items.Add(request);
                        LbxRequestStarted.ItemsSource = listRequestsStarted.ToArray();

                    }
                }
            }
            elipse.Visibility = Visibility.Hidden;
        }
        public async void reloadRequest(RequestSettings request, Ellipse elipse)
        {
            this.client = new HttpClient();

            using (client)
            {
                using (HttpResponseMessage response = await client.GetAsync($"{requestAPIUrl}/startRequest/{request.id}"))
                {
                    using (HttpContent content = response.Content)
                    {

                        JArray jsonArray = JArray.Parse(await content.ReadAsStringAsync());
                        JObject responseRequest = JObject.Parse(jsonArray[0].ToString());


                        Dictionary<string, string> dictObj = responseRequest.ToObject<Dictionary<string, string>>();

                        List<String> columns = new List<string>();

                        dictObj.Keys.ToList().ForEach(p =>
                        {
                            columns.Add(p);
                        });

                        request.columns = columns.ToArray();
                        request.row = jsonArray;
                        var src = DateTime.Now;
                        request.hourOfStart = DateTime.Now;

                    }
                }
            }
            elipse.Visibility = Visibility.Hidden;

        }

        public void showRequest(RequestSettings request, DataGrid dataGrid, Ellipse elipse)
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

            elipse.Visibility = Visibility.Hidden;


        }

        public async Task<string[]> addRequest(RequestSettings request)
        {

            this.client = new HttpClient();
            String requestJson = JsonConvert.SerializeObject(request);
            using (client)
            {
                using (HttpResponseMessage response = await client.PostAsJsonAsync($"{requestAPIUrl}/createRequest", requestJson))
                {

                    using (HttpContent content = response.Content)
                    {
                        string[] addErrorMessage = JsonConvert.DeserializeObject<string[]>(await content.ReadAsStringAsync());
                        Console.WriteLine(addErrorMessage[0]);
                        return addErrorMessage;


                    }
                }
            }
        }

        public async Task<string[]> modifyRequest(RequestSettings request)
        {

            this.client = new HttpClient();
            String requestJson = JsonConvert.SerializeObject(request);
            using (client)
            {

                using (HttpResponseMessage response = await client.PostAsJsonAsync($"{requestAPIUrl}/modifyRequest/{request.id}", requestJson))
                {

                    using (HttpContent content = response.Content)
                    {
                        string[] modErrorMessage = JsonConvert.DeserializeObject<string[]>(await content.ReadAsStringAsync());
                        Console.WriteLine(modErrorMessage[0]);

                        return modErrorMessage;


                    }
                }
            }
        }

        public async Task<RequestSettings[]> testRequestCondition()
        {
            this.client = new HttpClient();

            using (client)
            {
                using (HttpResponseMessage response = await client.GetAsync($"{requestAPIUrl}/testConditions/ADMIN"))
                {
                    using (HttpContent content = response.Content)
                    {

                        RequestSettings[] listRequests = JsonConvert.DeserializeObject<RequestSettings[]>(await content.ReadAsStringAsync());

                        return listRequests;
                    }
                }
            }
        }

        private void clearDataGread(DataGrid dataGrid)
        {
            dataGrid.Items.Clear();
            dataGrid.Columns.Clear();
        }
    }
}

