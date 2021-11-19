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
using Prueb_GitHub.Entity;
using Prueb_GitHub.Views;
using Prueb_GitHub.Persistence;


namespace Prueb_GitHub
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public afegirTasca w2;
        Tasca temp;

        public MainWindow()
        {
            InitializeComponent();
            DbContext.ObtenerConexion();
            
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            w2 = new Views.afegirTasca();
            w2.w1 = this;
            w2.Show();
            
        }

        private void lvTascaToDo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            temp = null;
            temp = (Tasca)lvTascaToDo.SelectedItem;
            lvTascaDoing.SelectedItem = null;
            lvTascaDone.SelectedItem = null;

            w2.txt_nomTasca.Text = temp.Nom;
            w2.txt_descripcio.Text = temp.Descripcio;
            w2.datepicker_data_final.SelectedDate = temp.DFinal;
            w2.cmb_prioritat.SelectedItem = temp.Prioritat_id;
            w2.cmb_responsable.SelectedItem = temp.Responsable_id;
        }

        private void lvTascaDoing_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            temp = null;
            lvTascaToDo.SelectedItem = null;
            temp = (Tasca)lvTascaDoing.SelectedItem;
            lvTascaDone.SelectedItem = null;

            w2.txt_nomTasca.Text = temp.Nom;
            w2.txt_descripcio.Text = temp.Descripcio;
            w2.datepicker_data_final.SelectedDate = temp.DFinal;
            w2.cmb_prioritat.SelectedItem = temp.Prioritat_id;
            w2.cmb_responsable.SelectedItem = temp.Responsable_id;
        }
        private void lvTascaDone_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            temp = null;
            lvTascaToDo.SelectedItem = null;
            lvTascaDoing.SelectedItem = null;
            temp = (Tasca)lvTascaDone.SelectedItem;

            w2.txt_nomTasca.Text = temp.Nom;
            w2.txt_descripcio.Text = temp.Descripcio;
            w2.datepicker_data_final.SelectedDate = temp.DFinal;

            w2.cmb_prioritat.SelectedItem = temp.Prioritat_id;
            w2.cmb_responsable.SelectedItem = temp.Responsable_id;

        }
    }


}
