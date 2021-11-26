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
        public afegirTasca w2;
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

            //w2 = new afegirTasca(this);
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

        private void MenuItem_Afegir(object sender, RoutedEventArgs e)
        {
            w2 = new afegirTasca(this);
            w2.w1 = this;
            w2.Show();
        }

        private void lvTascaToDo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            temp = null;
            temp = (Tasca)lvTascaToDo.SelectedItem;
            lvTascaDoing.SelectedItem = null;
            lvTascaDone.SelectedItem = null;

            emplenarCampsFinestra();
        }

        private void lvTascaDoing_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            temp = null;
            lvTascaToDo.SelectedItem = null;
            temp = (Tasca)lvTascaDoing.SelectedItem;
            lvTascaDone.SelectedItem = null;

            emplenarCampsFinestra();
        }

        private void lvTascaDone_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            temp = null;
            lvTascaToDo.SelectedItem = null;
            lvTascaDoing.SelectedItem = null;
            temp = (Tasca)lvTascaDone.SelectedItem;

            emplenarCampsFinestra();


        }

        private void MenuItem_Eliminar(object sender, RoutedEventArgs e)
        {

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
        private void MenuItem_Modificar(object sender, RoutedEventArgs e)
        {
            w2 = new afegirTasca(this);
            if(temp != null)
            {
                if (w2.IsActive)
                {
                    w2.txt_nomTasca.Text = temp.Nom;
                    w2.txt_descripcio.Text = temp.Descripcio;
                    w2.datepicker_data_final.SelectedDate = temp.DFinal;
                    w2.cmb_prioritat.SelectedIndex = temp.Prioritat_id + 1;
                    w2.cmb_responsable.SelectedIndex = temp.Responsable_id + 1;

                    w2.Focus();
                }
                else
                {
                    w2.Show();

                    w2.txt_nomTasca.Text = temp.Nom;
                    w2.txt_descripcio.Text = temp.Descripcio;
                    w2.datepicker_data_final.SelectedDate = temp.DFinal;
                    w2.cmb_prioritat.SelectedIndex = temp.Prioritat_id + 1;
                    w2.cmb_responsable.SelectedIndex = temp.Responsable_id + 1;

                    w2.Focus();
                }
            }
        }
        public void emplenarCampsFinestra()
        {
            w2 = new afegirTasca(this);
            if (w2.IsActive)
            {
                w2.txt_nomTasca.Text = temp.Nom;
                w2.txt_descripcio.Text = temp.Descripcio;
                w2.datepicker_data_final.SelectedDate = temp.DFinal;
                w2.cmb_prioritat.SelectedItem = temp.Prioritat_id;
                w2.cmb_responsable.SelectedItem = temp.Responsable_id;
            }
        }
    }
}
