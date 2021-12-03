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
        public afegirTasca at;
        public afegirTasca mt;
        Tasca temp;
        public List<Tasca> todo = new List<Tasca>();
        public List<Tasca> doing = new List<Tasca>();
        public List<Tasca> done = new List<Tasca>();
        public List<Prioritat> prioritats = new List<Prioritat>();
        public List<Responsable> responsables = new List<Responsable>();

        public MainWindow()
        {
            InitializeComponent();

            //Conexio a la BBDD
            DbContext.ObtenerConexion();

            //Fem un enllaç de cada listView
            //Depen del estat si es To Do, Doing o Done, mostrará l'informació en un list view diferent. 
            todo = UserService.Select(1);
            doing = UserService.Select(2);
            done = UserService.Select(3);

            prioritats = UserService.SelectP();
            responsables = UserService.SelectR();

            SelecionarTodo();
            
            //w2 = new afegirTasca(this);
        }

        public void SelecionarTodo()
        {
            //Agafa el items que te cada llista
            lvTascaToDo.ItemsSource = todo;
            lvTascaDoing.ItemsSource = doing;
            lvTascaDone.ItemsSource = done;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            at = new afegirTasca(this);
            at.Show();
        }

        private void lvTascaToDo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Selecciona una tasca del listview corresponent
            //Es posa null els altres view, perque no hi hagi cap conflicte a l'hora de seleccionar.
            temp = null;
            temp = (Tasca)lvTascaToDo.SelectedItem;
            lvTascaDoing.SelectedItem = null;
            lvTascaDone.SelectedItem = null;

            //obrir_i_emplenar();

            //emplenarCampsFinestra();
        }

        private void lvTascaDoing_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Selecciona una tasca del listview corresponent
            //Es posa null els altres view, perque no hi hagi cap conflicte a l'hora de seleccionar.
            temp = null;
            lvTascaToDo.SelectedItem = null;
            temp = (Tasca)lvTascaDoing.SelectedItem;
            lvTascaDone.SelectedItem = null;

            //obrir_i_emplenar();

            //emplenarCampsFinestra();
        }

        private void lvTascaDone_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Selecciona una tasca del listview corresponent
            //Es posa null els altres view, perque no hi hagi cap conflicte a l'hora de seleccionar.
            temp = null;
            lvTascaToDo.SelectedItem = null;
            lvTascaDoing.SelectedItem = null;
            temp = (Tasca)lvTascaDone.SelectedItem;

            
            //obrir_i_emplenar();
             

            //emplenarCampsFinestra();
        }

        //Funcio per poder eliminar una tasca seleccionada.
        private void MenuItem_Eliminar(object sender, RoutedEventArgs e)
        {
            UserService.eliminarTasca(temp.Id);
            if (lvTascaToDo.SelectedItem != null)
            {
                todo.RemoveAt(lvTascaToDo.SelectedIndex);
                lvTascaToDo.ItemsSource = null; //Es posa null per fer com una "actualizacio del ListView"
                lvTascaToDo.ItemsSource = todo; //I després es torna a omplir.
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

        //Funcio per seleccionar un item i poder modificar les dades la tasca. 
        private void MenuItem_Modificar(object sender, RoutedEventArgs e)
        {
            obrirModificar();

            emplenarCampsFinestra();

            mt.Focus();
        }

        public void obrirModificar()
        {

            if (at.IsEnabled)
            {
                at.Close();

                mt = new afegirTasca(this);
                mt.Show();
            }
            else if(mt.IsEnabled)
            {
                mt.Close();

                mt = new afegirTasca(this);
                mt.Show();
            }
            else
            {
                mt = new afegirTasca(this);
                mt.Show();
            }

        }

        //Funcio per seleccionar un item i poder modificar les dades la tasca. 
        public void emplenarCampsFinestra()
        {
            if (mt.IsActive)
            {
                mt.txt_id.Text = temp.Id.ToString();
                mt.txt_estat.Text = ((int)temp.Estat).ToString();
                mt.datepicker_data_inici.SelectedDate = temp.DInici;

                mt.txt_nomTasca.Text = temp.Nom;
                mt.txt_descripcio.Text = temp.Descripcio;
                mt.datepicker_data_final.SelectedDate = temp.DFinal;
                mt.cmb_prioritat.SelectedIndex = temp.Prioritat_id;
                mt.cmb_responsable.SelectedIndex = temp.Responsable_id;
            }
        }

        private void btn_AfegirResponsalbe_Click(object sender, RoutedEventArgs e)
        {
            AfegirResponsable afegirResponsable = new AfegirResponsable();
            afegirResponsable.Show();

        }
    }
}
