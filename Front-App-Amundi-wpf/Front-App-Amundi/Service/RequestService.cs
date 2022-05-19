using Front_App_Amundi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

                        foreach (RequestSettings request in listRequests)
                        {
                            request.initRequestStarted();
                        }

                        return listRequests;
                    }
                }
            }
        }
    
        public async void StartedRequest(RequestSettings request, DataGrid dataGrid, Ellipse elipse, List<RequestSettings> listRequestsStarted, ListBox LbxRequestStarted, ListBox LbxRequest,List<RequestSettings> listRequestsShow)
        {
            this.client = new HttpClient();
            this.clearDataGread(dataGrid);
            request = (RequestSettings)request.Clone();

            using (client)
            {
                using (HttpResponseMessage response = await client.GetAsync($"{requestAPIUrl}/startRequest/ {request.id}"))
                {
                    using (HttpContent content = response.Content)
                    {
                        JArray jsonArray = JArray.Parse(await content.ReadAsStringAsync());
                        JObject responseRequest = JObject.Parse(jsonArray[0].ToString());


                        Dictionary<string, string> dictObj = responseRequest.ToObject<Dictionary<string, string>>();

                        if (request.columns == null) {
                            request.columns = new List<Column>();
                            dictObj.Keys.ToList().ForEach(p =>
                            {

                                var newColumn = new DataGridTextColumn();
                                newColumn.Header = p;
                                newColumn.Binding = new Binding(p);
                                dataGrid.Columns.Add(newColumn);

                                request.columns.Add(new Column(p, p));
                            });

                        }else
                        {
                            int i = 0;
                            dictObj.Keys.ToList().ForEach(p =>
                            {

                                var newColumn = new DataGridTextColumn();
                                newColumn.Binding = new Binding(p);
                                newColumn.Header = request.columns[i].modifyColumn; i++;
                                dataGrid.Columns.Add(newColumn);

                            });
                            }


                        foreach (var row in jsonArray)
                        {
                            dataGrid.Items.Add(row);
                        }




                        request.row = jsonArray;
                        var src = DateTime.Now;
                        request.hourOfStart = new DateTime(src.Year, src.Month, src.Day, src.Hour, src.Minute, src.Second);
                        listRequestsStarted.Insert(0, request);

                        dataGrid.Items.Add(request);
                        LbxRequestStarted.ItemsSource = listRequestsStarted.ToArray();

                        LbxRequestStarted.Focus();
                        LbxRequestStarted.SelectedIndex = 0;


                        var listBoxItem =
               (ListBoxItem)LbxRequestStarted
                 .ItemContainerGenerator
                   .ContainerFromItem(LbxRequestStarted.SelectedItem);

                        listBoxItem.Focus();


                        LbxRequest.ItemsSource = null;
                        LbxRequest.ItemsSource = listRequestsShow;
                        request.addRequestStarted(request);


                    }
                }
            }
            elipse.Visibility = Visibility.Hidden;


            dataGrid.Columns[0].Header = "Task";
        }


        public async void setColumnRequest(RequestSettings request, ListBox LbxColumnsRequest)
        {
            this.client = new HttpClient();

            if (request.columns == null) {
                request.columns = new List<Column>();

                request = (RequestSettings)request.Clone();

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
                                columns.Add(p);
                            });


                            for (int i = 0; i < columns.Count; i++)
                            {
                                request.columns.Add(new Column(columns[i], columns[i]));
                            }
                        
                    


                        }
                    }
                } 
            }

            LbxColumnsRequest.ItemsSource = request.columns;
        }

        public void reloadDataGrid(DataGrid dataGrid, RequestSettings requete)
        {
            this.clearDataGread(dataGrid);
            for (int i = 0; i < requete.columns.Count; i++)
            {
                var newColumn = new DataGridTextColumn();
                newColumn.Binding = new Binding(requete.columns[i].initialColumn);
                newColumn.Header = requete.columns[i].modifyColumn; 
                dataGrid.Columns.Add(newColumn);
            }

    
                        foreach (var row in requete.row)
                        {
                            dataGrid.Items.Add(row);
                        }
}

        public async void reloadRequest(RequestSettings request, Ellipse elipse, DataGrid dataGrid)
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


                        request.row = jsonArray;
                        var src = DateTime.Now;
                        request.hourOfStart = DateTime.Now;

                    }
                }
            }
            elipse.Visibility = Visibility.Hidden;

            this.reloadDataGrid(dataGrid, request);
        }

        public void showRequest(RequestSettings request, DataGrid dataGrid, Ellipse elipse)
        {
            this.clearDataGread(dataGrid);

            request.columns.ToList().ForEach(p =>
            {

                var newColumn = new DataGridTextColumn();
                newColumn.Header = p.modifyColumn;
                newColumn.Binding = new Binding(p.initialColumn);
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

