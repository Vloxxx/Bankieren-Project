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
using System.Windows.Shapes;
using Bank;

namespace Bankieren
{
    /// <summary>
    /// Interaction logic for HoofdMenu.xaml
    /// </summary>
    public partial class HoofdMenu : Window
    {
        #region Fields
        // -- FIELDS --
        Betaalrekening betaalrekening;
        Spaarrekening spaarrekening;
        Inloggen inloggen;
        Bankrekeninghouder bankrekeninghouder;
        #endregion

        #region Constructor
        // -- CONSTRUCTOR --

        // Een hoofdmenu aanmaken met class Bankrekeninghouder en Inloggen als parameters
        public HoofdMenu(Bankrekeninghouder bankrekeninghouder,Inloggen inloggen)
        {
            InitializeComponent();
            this.bankrekeninghouder = bankrekeninghouder;
            this.inloggen = inloggen;
        }
        #endregion

        #region EventArgs Methods
        // -- EVENTARGS METHODS --

        #region Grid_Loaded Events
        // -- GRID_LOADED EVENTARGS --
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {        
            lblVoornaam.Content = bankrekeninghouder.Persoon.Voornaam;
            lblAchternaam.Content = bankrekeninghouder.Persoon.Achternaam;
            lblBSN.Content = bankrekeninghouder.Persoon.Bsn;
            betaalrekening = new Betaalrekening(bankrekeninghouder);
            spaarrekening = new Spaarrekening(bankrekeninghouder);           
        }
        #endregion

        #region btnLogUit ClickEvents
        // -- BTNLOGUIT CLICK-EVENTARGS --
        private void btnLogUit_Click(object sender, RoutedEventArgs e)
        {
            inloggen.Show();
            this.Hide();
            betaalrekening.Hide();
            spaarrekening.Hide();
        }
        #endregion

        #region btnOpenBetaalrekening ClickEvents
        // -- BTNOPENBETAALREKENING CLICK-EVENTARGS --
        private void btnOpenBetaalrekening_Click(object sender, RoutedEventArgs e)
        {
            betaalrekening.HuidigeSaldoEnKredietBijwerken();
            betaalrekening.ShowDialog();
        }
        #endregion

        #region btnOpenSpaarrekening ClickEvents
        // -- BTNOPENSPAARREKENING CLICK-EVENTARGS --
        private void btnOpenSpaarrekening_Click(object sender, RoutedEventArgs e)
        {
            spaarrekening.HuidigeSaldoEnRenteBijwerken();
            spaarrekening.ShowDialog();
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
    }
}
