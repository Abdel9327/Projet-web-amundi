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
          
            _service.StartedRequest(request, dataGrid);

            listRequestsStarted.Insert(0,request);
            LbxRequestStarted.ItemsSource = listRequestsStarted.ToArray();

            LbxRequestStarted.Focus();
            LbxRequestStarted.SelectedIndex = 0;

        }

        private void showRequest(object sender, MouseButtonEventArgs e)
        {
            RequestSettings request = ((sender as Label).Tag as RequestSettings);
            _service.showRequest(request, dataGrid);

       
        }

     

        private void createRequest(object sender, RoutedEventArgs e)
        {
            //creation de la requete 
        }

        private void closePopUpAdd(object sender, RoutedEventArgs e)
        {
            PopupAdd.IsOpen = false;

        }

        private void addRequestPopUp(object sender, RoutedEventArgs e)
        {
            PopupAdd.IsOpen =true;
        }

        private void modifyRequestPopUp(object sender, RoutedEventArgs e)
        {
            ModifPopup.IsOpen = true;
            LbxRequestModify.ItemsSource = listRequests;

        }

        private void ModifyRequest(object sender, RoutedEventArgs e)
        {
            //modification de la requete
        }

        private void closePopUpModify(object sender, RoutedEventArgs e)
        {
            ModifPopup.IsOpen = false;
        }
    }
}


//regler affichage modify
// faire ajout et modification
// test amundi dont work
//premiere requetelance beug date
//message derreur o upas ajout 
