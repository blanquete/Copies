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
using Prueb_GitHub.Service;

namespace Prueb_GitHub
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public afegirTasca w2 = new afegirTasca();
        Tasca temp;
        public List<Tasca> todo = new List<Tasca>();
        public List<Tasca> doing = new List<Tasca>();
        public List<Tasca> done = new List<Tasca>();
        public List<Prioritat> prioritats = new List<Prioritat>();
        public List<Responsable> responsables = new List<Responsable>();

        public MainWindow()
        {
            InitializeComponent();

            DbContext.ObtenerConexion();

            todo = UserService.Select(1);
            doing = UserService.Select(2);
            done = UserService.Select(3);
            prioritats = UserService.SelectP();
            responsables = UserService.SelectR();

            SelecionarTodo();
        }

        public void SelecionarTodo()
        {
            lvTascaToDo.ItemsSource = todo;
            lvTascaDoing.ItemsSource = doing;
            lvTascaDone.ItemsSource = done;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

            this.w2.btn_modificar.IsEnabled = false;
            this.w2.btn_modificar.Visibility = (Visibility)2;

            this.w2.btn_agregar.IsEnabled = true;
            this.w2.btn_agregar.Visibility = (Visibility)0;

            w2.w1 = this;
            w2.Show();
            
        }

        private void lvTascaToDo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            temp = null;
            temp = (Tasca)lvTascaToDo.SelectedItem;
            lvTascaDoing.SelectedItem = null;
            lvTascaDone.SelectedItem = null;

            if (this.w2.IsActive)
            {
                this.w2.txt_nomTasca.Text = temp.Nom;
                this.w2.txt_descripcio.Text = temp.Descripcio;
                this.w2.datepicker_data_final.SelectedDate = temp.DFinal;
                this.w2.cmb_prioritat.SelectedItem = temp.Prioritat_id;
                this.w2.cmb_responsable.SelectedItem = temp.Responsable_id;
            }
        }

        private void lvTascaDoing_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            temp = null;
            lvTascaToDo.SelectedItem = null;
            temp = (Tasca)lvTascaDoing.SelectedItem;
            lvTascaDone.SelectedItem = null;

            if (this.w2.IsActive)
            {
                this.w2.txt_nomTasca.Text = temp.Nom;
                this.w2.txt_descripcio.Text = temp.Descripcio;
                this.w2.datepicker_data_final.SelectedDate = temp.DFinal;
                this.w2.cmb_prioritat.SelectedItem = temp.Prioritat_id;
                this.w2.cmb_responsable.SelectedItem = temp.Responsable_id;
            }
        }

        private void lvTascaDone_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            temp = null;
            lvTascaToDo.SelectedItem = null;
            lvTascaDoing.SelectedItem = null;
            temp = (Tasca)lvTascaDone.SelectedItem;

            if (this.w2.IsActive)
            {
                this.w2.txt_nomTasca.Text = temp.Nom;
                this.w2.txt_descripcio.Text = temp.Descripcio;
                this.w2.datepicker_data_final.SelectedDate = temp.DFinal;
                this.w2.cmb_prioritat.SelectedItem = temp.Prioritat_id;
                this.w2.cmb_responsable.SelectedItem = temp.Responsable_id;
            }


        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            this.w2.btn_agregar.IsEnabled = false;
            this.w2.btn_agregar.Visibility = (Visibility)2;

            this.w2.btn_modificar.IsEnabled = true;
            this.w2.btn_modificar.Visibility = (Visibility)0;

            UserService.eliminarTasca(temp.Id);
            if (lvTascaToDo.SelectedItem != null)
            {
                todo.RemoveAt(lvTascaToDo.SelectedIndex);
                lvTascaToDo.ItemsSource = null;
                lvTascaToDo.ItemsSource = todo;
            }
            else if (lvTascaDoing.SelectedItem != null)
            {
                doing.RemoveAt(lvTascaDoing.SelectedIndex);
                lvTascaDoing.ItemsSource = null;
                lvTascaDoing.ItemsSource = doing;
            }
            else if (lvTascaDone.SelectedItem != null)
            {
                done.RemoveAt(lvTascaDone.SelectedIndex);
                lvTascaDone.ItemsSource = null;
                lvTascaDone.ItemsSource = done;
            }

        }
    }


}
