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

namespace BozziPannelliApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Insieme elencoMisure;

        public MainWindow()
        {
            InitializeComponent();
            elencoMisure = new Insieme();
            DgElenco.ItemsSource = elencoMisure.ElencoMisure;
        }

        private void BtnLeggiDaFile_Click(object sender, RoutedEventArgs e)
        {
            string giorno = TxtGiorno.Text;
            string mese = TxtMese.Text;
            string anno = TxtAnno.Text;
            string nomeFile = giorno + "_" + mese + "_" + anno + ".txt";
            elencoMisure.LeggiDaFile(nomeFile);
            DgElenco.Items.Refresh();
        }

        private void BtnCercaMassimo_Click(object sender, RoutedEventArgs e)
        {
            string orario = elencoMisure.CercaPotenzaMassima();
            MessageBox.Show(orario);
        }
    }
}
