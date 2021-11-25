using Prueb_GitHub.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Prueb_GitHub.Persistence;
using Prueb_GitHub.Service;

namespace Prueb_GitHub.Views
{
    /// <summary>
    /// Lógica de interacción para afegirTasca.xaml
    /// </summary>
    public partial class afegirTasca : Window
    {
        public Tasca temp;
        public MainWindow w1;
        
        public afegirTasca()
        {
            DbContext.ObtenerConexion();
            InitializeComponent();
            txt_nomTasca.Focus();

            List<Prioritat> prioritats = UserService.SelectP();
            List<Responsable> responsables = UserService.SelectR();

            foreach (Prioritat prio in prioritats)
            {
                cmb_prioritat.Items.Add(prio.Nom);
            }
            foreach (Responsable resp in responsables)
            {
                cmb_responsable.Items.Add(resp.Nom);
            }
        }
        //quan l'usuari clica sobre el button afegir
        private void btn_agregar_Click(object sender, RoutedEventArgs e)
        {
            //try
            {
                    //afageix un nou item al listview
                     temp = new Tasca()
                     {
                         Id = UserService.maxId()+1,
                         Nom = txt_nomTasca.Text,
                         Descripcio = txt_descripcio.Text,
                         DInici = DateTime.Now,
                         DFinal = (DateTime)datepicker_data_final.SelectedDate,
                         Prioritat_name = cmb_prioritat.SelectedItem.ToString(), //Agafa el valor de l'index
                         Responsable_name = cmb_responsable.SelectedItem.ToString(), //Agafa el valor de l'index
                         Estat_name = "ToDo", //Fixem el valor de l'index, una tasca sempre inicia al ToDo
                     };
                //Añadir al listView De Afegir Tasca
                //Des de la pantalla Afegir passem l'objecte al listview de la pagina principal
                netejaCamps();

                w1.todo.Add(temp);
                w1.lvTascaToDo.ItemsSource = null;
                w1.lvTascaToDo.ItemsSource = w1.todo;

            }
            /*catch (Exception)
            {
                MessageBox.Show("Has d'omplir tots els camps");
            }*/
            
            UserService.Agregar(temp);
            //w1.lvTascaToDo.ItemsSource = UserService.Select((int)Estat.ToDo);

        }

        private void btn_modificar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //creem un nou item al listview
                temp = new Tasca()
                {
                    //Id = int.Parse(txt_id.Text),
                    Nom = txt_nomTasca.Text,
                    Descripcio = txt_descripcio.Text,
                    DFinal = (DateTime)datepicker_data_final.SelectedDate,

                    Prioritat_name = cmb_prioritat.SelectedItem.ToString(), //transforma el valor del item seleccionat
                    Responsable_name = cmb_responsable.SelectedItem.ToString(), //transforma el valor del item seleccionat
                };
                //intercanvia l'item seleccionat per el que acabem de crear

                if(w1.lvTascaToDo.SelectedItem != null)
                {
                    w1.lvTascaToDo.Items.Insert(w1.lvTascaToDo.SelectedIndex, temp);
                }
                else if (w1.lvTascaDoing.SelectedItem != null)
                {
                    w1.lvTascaDoing.Items.Insert(w1.lvTascaDoing.SelectedIndex, temp);
                }
                else if (w1.lvTascaDone.SelectedItem != null)
                {
                    w1.lvTascaDone.Items.Insert(w1.lvTascaDone.SelectedIndex, temp);
                }


                netejaCamps();
            }
            catch (Exception)
            {
                MessageBox.Show("Has de seleccionar una tasca i omplir tots els camps", "Informacio", MessageBoxButton.OK, MessageBoxImage.Information);
                
            }
        }

        // quan l'usuari clica sobre el button eliminar
        private void btn_eliminar_Click(object sender, RoutedEventArgs e)
        {
            try //faig un trycatch per asegurarme que l'usuari ha seleccionat un item previament
            {
                //elimina el item seleccionat

                if (w1.lvTascaToDo.SelectedItem != null)
                {
                    w1.lvTascaToDo.Items.RemoveAt(w1.lvTascaToDo.SelectedIndex);
                }
                else if (w1.lvTascaDoing.SelectedItem != null)
                {
                    w1.lvTascaDoing.Items.RemoveAt(w1.lvTascaDoing.SelectedIndex);
                }
                else if (w1.lvTascaDone.SelectedItem != null)
                {
                    w1.lvTascaDone.Items.RemoveAt(w1.lvTascaDone.SelectedIndex);
                }
                netejaCamps();

            }
            catch (Exception)
            {
                MessageBox.Show("Has de seleccionar una tasca", "Informacio", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        //metode per netejar els camps
        public void netejaCamps()
        {
            txt_nomTasca.Text = "";
            txt_descripcio.Text = "";
            datepicker_data_final.SelectedDate = null;
            cmb_prioritat.SelectedItem = null;
            cmb_responsable.SelectedItem = null;
            
            txt_nomTasca.Focus();
        }

        //Aques event s'aplica sobre el textbox id  
        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            //si la tecla es un nuemero
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9 || e.Key == Key.Tab)
                //permet introduir valors
                e.Handled = false;
            else
                //si no no permet introduir valors
                e.Handled = true;
        }

        private void btn_netejar_Click(object sender, RoutedEventArgs e)
        {
            netejaCamps();
        }
    }
}
