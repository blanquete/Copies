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
using Prueb_GitHub.BBDD;

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
            BBDD.BaseDatos.ObtenerConexion();
            InitializeComponent();
            
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            w2 = new Views.afegirTasca();
            w2.w1 = this;
            w2.Show();
            
        }

        private void lvTascaToDo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            temp = (Tasca)lvTascaToDo.SelectedItem;
            lvTascaDoing.SelectedItem = null;
            lvTascaDone.SelectedItem = null;

            w2.txt_id.Text = temp.Id.ToString();
            w2.txt_nomTasca.Text = temp.Nom;
            w2.txt_descripcio.Text = temp.Descripcio;
            w2.datepicker_data_inici.SelectedDate = new DateTime(int.Parse(temp.DInici.Split("/")[2]), int.Parse(temp.DInici.Split("/")[1]), int.Parse(temp.DInici.Split("/")[0]));
            w2.datepicker_data_final.SelectedDate = new DateTime(int.Parse(temp.DFinal.Split("/")[2]), int.Parse(temp.DFinal.Split("/")[1]), int.Parse(temp.DFinal.Split("/")[0]));
            w2.cmb_prioritat.Text = temp.Prioritat_id;
            w2.cmb_responsable.Text = temp.Responsable_id;
            w2.cmb_estat.Text = temp.Estat_id;
        }

        private void lvTascaDoing_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lvTascaToDo.SelectedItem = null;
            temp = (Tasca)lvTascaDoing.SelectedItem;
            lvTascaDone.SelectedItem = null;

            w2.txt_id.Text = temp.Id.ToString();
            w2.txt_nomTasca.Text = temp.Nom;
            w2.txt_descripcio.Text = temp.Descripcio;
            w2.datepicker_data_inici.SelectedDate = new DateTime(int.Parse(temp.DInici.Split("/")[2]), int.Parse(temp.DInici.Split("/")[1]), int.Parse(temp.DInici.Split("/")[0]));
            w2.datepicker_data_final.SelectedDate = new DateTime(int.Parse(temp.DFinal.Split("/")[2]), int.Parse(temp.DFinal.Split("/")[1]), int.Parse(temp.DFinal.Split("/")[0]));
            w2.cmb_prioritat.Text = temp.Prioritat_id;
            w2.cmb_responsable.Text = temp.Responsable_id;
            w2.cmb_estat.Text = temp.Estat_id;
        }
        private void lvTascaDone_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lvTascaToDo.SelectedItem = null;
            lvTascaDoing.SelectedItem = null;
            temp = (Tasca)lvTascaDone.SelectedItem;

            w2.txt_id.Text = temp.Id.ToString();
            w2.txt_nomTasca.Text = temp.Nom;
            w2.txt_descripcio.Text = temp.Descripcio;
            w2.datepicker_data_inici.SelectedDate = new DateTime(int.Parse(temp.DInici.Split("/")[2]), int.Parse(temp.DInici.Split("/")[1]), int.Parse(temp.DInici.Split("/")[0]));
            w2.datepicker_data_final.SelectedDate = new DateTime(int.Parse(temp.DFinal.Split("/")[2]), int.Parse(temp.DFinal.Split("/")[1]), int.Parse(temp.DFinal.Split("/")[0]));
            w2.cmb_prioritat.Text = temp.Prioritat_id;
            w2.cmb_responsable.Text = temp.Responsable_id;
            w2.cmb_estat.Text = temp.Estat_id;
        }
    }


}
