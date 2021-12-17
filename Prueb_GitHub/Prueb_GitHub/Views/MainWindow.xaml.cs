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
        ListView dragSource = null;

        public MainWindow()
        {
            InitializeComponent();
            
            //Conexio a la BBDD
            DbContext.ObtenerConexion();

            //Fem un enllaç de cada listView
            //Depen del estat si es To Do, Doing o Done, mostrará l'informació en un list view diferent. 
           
            prioritats = UserService.SelectP();
            responsables = UserService.SelectR();

            SelecionarTodo();
        }

        public void SelecionarTodo()
        {
            //Agafa el items que te cada llista
            lvTascaToDo.ItemsSource = todo = UserService.Select(1); 
            lvTascaDoing.ItemsSource = doing = UserService.Select(2); 
            lvTascaDone.ItemsSource = done = UserService.Select(3); ;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            at = new afegirTasca(this);
            at.btn_modificar.Visibility = Visibility.Hidden;
            at.Show();
        }

        private void lvTascaToDo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Selecciona una tasca del listview corresponent
            //Es posa null els altres view, perque no hi hagi cap conflicte a l'hora de seleccionar.
            if (lvTascaToDo.SelectedItem != null)
            {
                lvTascaDoing.SelectedItem = null;
                lvTascaDone.SelectedItem = null;
                temp = null;
                temp = (Tasca)lvTascaToDo.SelectedItem;
            }
        }

        private void lvTascaDoing_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Selecciona una tasca del listview corresponent
            if (lvTascaDoing.SelectedItem != null)
            {
                lvTascaToDo.SelectedItem = null;
                lvTascaDone.SelectedItem = null;
                temp = null;
                temp = (Tasca)lvTascaDoing.SelectedItem;
            }
        }

        private void lvTascaDone_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Selecciona una tasca del listview corresponent
            //Es posa null els altres view, perque no hi hagi cap conflicte a l'hora de seleccionar.
            if (lvTascaDone.SelectedItem != null)
            {
                lvTascaDoing.SelectedItem = null;
                lvTascaToDo.SelectedItem = null;
                temp = null;
                temp = (Tasca)lvTascaDone.SelectedItem;
            }
        }

        //Funcio per poder eliminar una tasca seleccionada.
        private void MenuItem_Eliminar(object sender, RoutedEventArgs e)
        {
            if(temp == null)
            {
                MessageBox.Show("Has de seleccionar una tasca, per poder eliminar-la. ", "Informacio", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                UserService.eliminarTasca(temp._Id);
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
        }

        //Funcio per seleccionar un item i poder modificar les dades la tasca. 
        private void MenuItem_Modificar(object sender, RoutedEventArgs e)
        {
            if (temp == null)
            {
                MessageBox.Show("Has de seleccionar una tasca, per poder modificar-la. ", "Informacio", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                obrirModificar();
                mt.btn_agregar.Visibility = Visibility.Hidden;
                emplenarCampsFinestra();
                mt.Focus();
            }
        }

        public void obrirModificar()
        {
            at = new afegirTasca(this);
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
            if(mt.IsActive && temp != null)
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
        private void ListView_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //Obtenim la llista des d'on s'ha polsat 
            ListView parent = (ListView)sender;
            dragSource = parent;
            //Obtenim l'element seleccionat
            object data = GetDataFromListView(dragSource, e.GetPosition(parent));

            if (data != null)
            {
                DragDrop.DoDragDrop(parent, data, DragDropEffects.Move);
            }
        }

        private static object GetDataFromListView(ListView source, Point point)
        {
            UIElement element = source.InputHitTest(point) as UIElement;
            if (element != null)
            {
                object data = DependencyProperty.UnsetValue;
                while (data == DependencyProperty.UnsetValue)
                {
                    data = source.ItemContainerGenerator.ItemFromContainer(element);

                    if (data == DependencyProperty.UnsetValue)
                    {
                        element = VisualTreeHelper.GetParent(element) as UIElement;
                    }
                    if (element == source)
                    {
                        return null;
                    }
                }
                if (data != DependencyProperty.UnsetValue)
                {
                    return data;
                }
            }
            return null;
        }

        //Eliminem l'element de la llista origen i l'afegim a la llista desti
        private void ListView_Drop(object sender, DragEventArgs e)
        {
            Tasca task = (Tasca)e.Data.GetData(typeof(Tasca)); //obte les dades del item seleccionat previament
            ListView parent = (ListView)sender; //obte el llistview destí

            //Depenennt del nom del listview destí, actualitzará el seu estat en un numero o altre
            switch (parent.Name)
            {
                case "lvTascaToDo":
                    UserService.updateEstat(task._Id, 1); // 1 - estat todo
                    break;
                case "lvTascaDoing":
                    UserService.updateEstat(task._Id, 2); // 2 - estat doing
                    break;
                case "lvTascaDone":
                    UserService.updateEstat(task._Id, 3); // 3 - estat done
                    break;
            }
            //Actualitza els listviews
            SelecionarTodo();
        }
    }
}
