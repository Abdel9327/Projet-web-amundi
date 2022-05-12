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
        private string[] errorMessageAdd;
        private string[] errorMessageMod;
        private Label labelRequestSelectedToMod;
        private static bool testConditionEffectue=false;
        public MainWindow()
        {

            InitializeComponent();

            spinnerLoad.Visibility = Visibility.Hidden;

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
            spinnerLoad.Visibility = Visibility.Visible;

            _service.StartedRequest(request, dataGrid, spinnerLoad, listRequestsStarted, LbxRequestStarted);
        

        }

        private void showRequest(object sender, MouseButtonEventArgs e)
        {
            RequestSettings request = ((sender as Label).Tag as RequestSettings);
            spinnerLoad.Visibility = Visibility.Visible;

           _service.showRequest(request, dataGrid, spinnerLoad);

       
        }

     

        private void createRequest(object sender, RoutedEventArgs e)
        {
            _service.addRequest(CreateAddingrequestSettings()).ContinueWith(t => {
                this.errorMessageAdd = t.Result;
                this.Dispatcher.Invoke(() =>
                {
                    messageErrorAdd.Content = this.errorMessageAdd[0];
                    LbxRequest.ItemsSource = listRequests;
                });
            });
        }

        private RequestSettings CreateAddingrequestSettings()
        {
            return new RequestSettings(LbxbDescriptionAdd.Text, LbxbRequeteAdd.Text, LbxbTypeBddAdd.Text, LbxbServeurBddAdd.Text, LbxbCompteAdd.Text, LbxbMdpAdd.Text, LbxbTypeRequeteAdd.Text, LbxbConditionAdd.Text);
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

     

        private RequestSettings CreateModifrequestSettings()
        {
            
            RequestSettings requesttoModify = labelRequestSelectedToMod.Tag as RequestSettings ;
            RequestSettings newRequestWithMod= new RequestSettings(txtbDesciptionMod.Text, txtbRequestMod.Text, txtbTypeBddMod.Text, txtbServeurMod.Text, txtbCompteMod.Text, txtbMdpMod.Text, txtbTypeRequestMod.Text, txtbConditionMod.Text);
            newRequestWithMod.id = requesttoModify.id;
            return newRequestWithMod;

        }

        private void closePopUpModify(object sender, RoutedEventArgs e)
        {
            ModifPopup.IsOpen = false;
        }

        private void showRequestToModify(object sender, MouseButtonEventArgs e)
        {
            this.labelRequestSelectedToMod = sender as Label;
            RequestSettings request = this.labelRequestSelectedToMod.Tag as RequestSettings;
            setTxtForm(request);
           

        }

        private void setTxtForm(RequestSettings request)
        {
            txtbDesciptionMod.Text = request.description;
            txtbTypeRequestMod.Text = request.typeRequete;
            txtbRequestMod.Text = request.requete;
            txtbTypeBddMod.Text = request.typeBDD;
            txtbServeurMod.Text=request.serveur;
            txtbCompteMod.Text = request.compte;
            txtbMdpMod.Text = request.password;
            txtbConditionMod.Text = request.condition;
        }

        private void deleteRequestStarted(object sender, RoutedEventArgs e)
        {
            RequestSettings request = ((sender as Button).Tag as RequestSettings);
            listRequestsStarted.Remove(request);

            LbxRequestStarted.ItemsSource = listRequestsStarted.ToArray();
            //Si il n'y a plus de requete lancé
            if (this.listRequestsStarted.Count == 0)
            {
                this.clearDataGread();
                return;
            }
        }

        private void reloadRequestStarted(object sender, RoutedEventArgs e)
        {
            spinnerLoad.Visibility = Visibility.Visible;
            RequestSettings request = ((sender as Button).Tag as RequestSettings);
            _service.reloadRequest(request, spinnerLoad);
            LbxRequestStarted.ItemsSource = listRequestsStarted.ToArray();

        }

        private void clearDataGread()
        {
            dataGrid.Items.Clear();
            dataGrid.Columns.Clear();
        }

        private void ModifyRequest(object sender, RoutedEventArgs e)
        {
            _service.modifyRequest(this.CreateModifrequestSettings()).ContinueWith(t => {
                this.errorMessageMod = t.Result;
                this.Dispatcher.Invoke(() =>
                {
                    messageErrorMod.Content = this.errorMessageMod[0];
                    LbxRequest.ItemsSource = listRequests;
                });
            });
        }

        private void testRequestCondition(object sender, RoutedEventArgs e)
        {
            _service.testRequestCondition().ContinueWith(t => {
                listRequests = t.Result;
                this.Dispatcher.Invoke(() =>
                {
                    testConditionEffectue = true;
                    LbxRequest.ItemsSource = listRequests;
                });
            });
        }
        public static bool GetTestConditionEffectue()
        {
            return testConditionEffectue;
        }
    }

  
}


// test amundi dont work
// si requete ajouter alors vider le cases !!
// reparer le reload

// a reparer pour la suppression
/*


        if ( LbxRequestStarted.SelectedIndex != listRequestsStarted.IndexOf(request) || this.listRequestsStarted.Count == 1)
        {
            Console.WriteLine(LbxRequestStarted.SelectedIndex + "and " + listRequestsStarted.IndexOf(request));
            //Changement de la requete afficher  
            if (this.listRequestsStarted.Count == 1)
            {
                _service.showRequest(this.listRequestsStarted[0], dataGrid, spinnerLoad);
                LbxRequestStarted.Focus();
                LbxRequestStarted.SelectedIndex =0;
            }
            else
            {
                _service.showRequest(this.listRequestsStarted[0], dataGrid, spinnerLoad);
                LbxRequestStarted.Focus();
                LbxRequestStarted.SelectedIndex = LbxRequestStarted.SelectedIndex + 1;
*/


//https://3ds.zoom.us/j/83203458068?pwd=VndJZHBjNmhGRHRhWFZQYVdoZXp3dz09