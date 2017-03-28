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
using Bank;
using System.Text.RegularExpressions;

namespace Bankieren
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Inloggen : Window
    {

        #region Constructor
        // -- CONSTRUCTOR --
        public Inloggen()
        {
            InitializeComponent();
        }
        #endregion

        #region EventArgs Methods
        // -- EVENTARGS METHODS --

        #region btnLogIn ClickEvents
        // -- BTNLOGIN CLICK-EVENTARGS --
        private void btnLogIn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                HoofdMenu hoofdmenu = new HoofdMenu(DataProvider.Inloggen(tbxGebruikersnaam.Text, pasxwachtwoord.Password),this);
                tbxGebruikersnaam.Text = "";
                pasxwachtwoord.Password = "";
                hoofdmenu.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        #endregion

        #region Window_Closing Events
        // -- WINDOW_CLOSING EVENTARGS --
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Environment.Exit(1);
            e.Cancel = true;
        }
        #endregion        
        #endregion

        #region PreviewTextInputs
        // -- PREVIEW TEXT INPUTS --
        private void StringIntPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^a-zA-Z0-9]+$"); //Accepteert alleen de toetsen 0 t/m 9 en de letters A/a t/m Z/z
            e.Handled = regex.IsMatch(e.Text);
        }
        #endregion
    }
}
