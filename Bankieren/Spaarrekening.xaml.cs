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
using System.Text.RegularExpressions;

namespace Bankieren
{
    /// <summary>
    /// Interaction logic for Spaarrekening.xaml
    /// </summary>
    public partial class Spaarrekening : Window
    {
        #region Fields
        // -- FIELDS --
        Bankrekeninghouder bankrekeninghouder;
        #endregion

        #region Constructor
        // -- CONSTRUCTOR --
        public Spaarrekening(Bankrekeninghouder bankrekeninghouder)
        {
            InitializeComponent();
            this.bankrekeninghouder = bankrekeninghouder;
        }
        #endregion

        #region Methods
        // -- METHODS --

        public void HuidigeSaldoEnRenteBijwerken()
        {
            foreach (Bankrekeninghouder bankrekeninghouder in Bankrekeninghouder.Bankrekeninghouderslijst)
            {
                if (bankrekeninghouder.Spaarrekening.RekeningNr == this.bankrekeninghouder.Spaarrekening.RekeningNr)
                {
                    string s = string.Format("{0:0.00}", bankrekeninghouder.Spaarrekening.BankSaldo);
                    s.Replace(".", ",");
                    lblHuidigSaldo.Content = s;
                    lblOpgebouwdeRente.Content = bankrekeninghouder.Spaarrekening.HuidigOpgebouwdeRente();
                }
            }
        }
        #endregion

        #region EventArgs Methods
        // -- EVENTARGS METHODS --

        #region Grid_Loaded Events
        // -- GRID_LOADED EVENTARGS --
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            HuidigeSaldoEnRenteBijwerken();
        }
        #endregion

        #region btnVerzenden ClickEvents
        // -- BTNVERZENDEN CLICK-EVENTARGS --
        private void btnVerzenden_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (tbxBedrag.Text != string.Empty)
                {
                    if (MessageBox.Show("Weet u zeker of u het bedrag wilt overmaken?", "Overmaken", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        foreach (Bankrekeninghouder bankrekeninghouder in Bankrekeninghouder.Bankrekeninghouderslijst)
                        {
                            if (bankrekeninghouder.Spaarrekening.RekeningNr == this.bankrekeninghouder.Spaarrekening.RekeningNr)
                            {
                                bankrekeninghouder.OverboekenBetaalrekening(Convert.ToDecimal(tbxBedrag.Text));
                                HuidigeSaldoEnRenteBijwerken();
                                tbxBedrag.Text = "";
                            }
                        }
                        MessageBox.Show("Het bedrag is overgemaakt.", "Overmaken", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region Window_Closing Events
        // -- WINDOW_CLOSING EVENTARGS --
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }
        #endregion

        #region btnClose Events
        // -- BTNCLOSE EVENTARGS --
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
        #endregion
        #endregion

        #region PreviewTextInputs
        // -- PREVIEW TEXT INPUTS --
        private void DoublePreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex1 = new Regex("[^0-9,-]+$"); //Accepteert alleen de toetsen 0 t/m 9, - en ,
            e.Handled = regex1.IsMatch(e.Text);
            if (Regex.IsMatch(tbxBedrag.Text, @"\,\d\d")) //Mag maximaal 2 decimalen achter de komma hebben
            {
                e.Handled = true;
            }
        }
        #endregion
    }
}
