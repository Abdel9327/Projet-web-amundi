using Front_App_Amundi.Models;
using Front_App_Amundi.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Front_App_Amundi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private RequestService _service;
        private RequestSettings[] listRequests;
        private List<RequestSettings> listRequestsStarted;

       public  MainWindow()
        {

            InitializeComponent();

            listRequestsStarted = new List<RequestSettings>();
            _service = new RequestService();
            _service.getAllRequest().ContinueWith(t => {
                listRequests = t.Result;
                this.Dispatcher.Invoke(() =>
                {
                    LbxRequest.ItemsSource = listRequests;
                });
            });


        }

        

        private void StartRequest(object sender, MouseButtonEventArgs e)
        {
            RequestSettings request = ((sender as Label).Tag as RequestSettings);
            listRequestsStarted.Add(request);
            LbxRequestStarted.ItemsSource = listRequestsStarted.ToArray();

            _service.StartedRequest(request, dataGrid);
                
        }

        private void showRequest(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
