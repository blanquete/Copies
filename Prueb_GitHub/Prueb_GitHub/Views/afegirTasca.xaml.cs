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

        public List<Prioritat> prioritats;
        public List<Responsable> responsables;
        

        public afegirTasca(MainWindow main)
        {
            //Conexio a la BBDD
            DbContext.ObtenerConexion();
            InitializeComponent();

            w1 = main;
            txt_nomTasca.Focus();

            prioritats = UserService.SelectP();
            responsables = UserService.SelectR();

            

            foreach (Prioritat prio in prioritats)
            {
                cmb_prioritat.Items.Add(prio.Nom);
            }
            foreach (Responsable resp in responsables)
            {
                cmb_responsable.Items.Add(resp.Nom);
            }
        }
        //Funcio, per poder afegir una tasca
        private void btn_agregar_Click(object sender, RoutedEventArgs e)
        {
            try
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
                         Estat_name = "To do", //Fixem el valor de l'index, una tasca sempre inicia al ToDo
                     };
                
                //Des de la pantalla Afegir passem l'objecte al listview de la pagina principal
                w1.todo.Add(temp);

                //Mostrem la tasca nova en el list view
                w1.lvTascaToDo.ItemsSource = null;
                w1.lvTascaToDo.ItemsSource = w1.todo;

                UserService.Agregar(temp);

                netejaCamps();
            }
            catch (Exception)
            {
                MessageBox.Show("Has d'omplir tots els camps", "Information",MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }

        private void btn_modificar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //creem un nou item al listview
                temp = new Tasca()
                {
                    Id = int.Parse(txt_id.Text),
                    DInici = (DateTime)datepicker_data_inici.SelectedDate,
                    Estat = (Estat)int.Parse(txt_estat.Text),

                    Nom = txt_nomTasca.Text,
                    Descripcio = txt_descripcio.Text,
                    DFinal = (DateTime)datepicker_data_final.SelectedDate,
                    Prioritat_name = cmb_prioritat.SelectedItem.ToString(), //transforma el valor del item seleccionat
                    Responsable_name = cmb_responsable.SelectedItem.ToString(), //transforma el valor del item seleccionat
                };
                //intercanvia l'item seleccionat per el que acabem de crear


                if(w1.lvTascaToDo.SelectedItem != null)
                {
                    w1.todo.RemoveAt(w1.lvTascaToDo.SelectedIndex);
                    w1.todo.Insert(w1.lvTascaToDo.SelectedIndex, temp);
                    w1.lvTascaToDo.ItemsSource = null;
                    w1.lvTascaToDo.ItemsSource = w1.todo;
                }
                else if (w1.lvTascaDoing.SelectedItem != null)
                {
                    w1.todo.RemoveAt(w1.lvTascaDoing.SelectedIndex);
                    w1.doing.Insert(w1.lvTascaDoing.SelectedIndex, temp);
                    w1.lvTascaDoing.ItemsSource = null;
                    w1.lvTascaDoing.ItemsSource = w1.doing;
                }
                else if (w1.lvTascaDone.SelectedItem != null)
                {
                    w1.todo.RemoveAt(w1.lvTascaDone.SelectedIndex);
                    w1.done.Insert(w1.lvTascaDone.SelectedIndex, temp);
                    w1.lvTascaDone.ItemsSource = null;
                    w1.lvTascaDone.ItemsSource = w1.done;
                }
                

                //UserService.updateTasca(temp);

                netejaCamps();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Has de seleccionar una tasca i omplir tots els camps. " + ex.Message, "Informacio", MessageBoxButton.OK, MessageBoxImage.Information);
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

            txt_id.Text = "";
            txt_estat.Text = "";
            datepicker_data_inici.SelectedDate = null;


            txt_nomTasca.Focus();
        }

        
    }
}
