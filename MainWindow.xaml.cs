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

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        wwwEntities context;
        public MainWindow()
        {
            InitializeComponent();
            context = new wwwEntities();
            ShowTable();
        }
        private void ShowTable()
        {
            DataGridClient.ItemsSource = context.Client.ToList();
        }
       

        private void BtnAdeteData_Click(object sender, RoutedEventArgs e)
        {
            var NEWClient = new Client();
            context.Client.Add(NEWClient);
            var EditWindow = new WindowClien(context, NEWClient);                       
            EditWindow.ShowDialog();
            MessageBox.Show("Данные добавлены");
            ShowTable();
        }

        private void BtnDeleteData_Click(object sender, RoutedEventArgs e)
        {
            var currentClient = DataGridClient.SelectedItem as Client;
            if (currentClient == null)
            {
                MessageBox.Show("Выберите строку!");
                return;
            }
            MessageBoxResult messageBoxResult = MessageBox.Show("Вы хотите удалить?", "Удаление", 
                MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                context.Client.Remove(currentClient);
                context.SaveChanges();
                MessageBox.Show("Данные удалены");
                ShowTable();
            }
        }

        private void BtnEditData_Click(object sender, RoutedEventArgs e)
        {
            Button BtnEdit = sender as Button;
            var currentClient = BtnEdit.DataContext as Client;
            var EditWindow = new WindowClien(context, currentClient);          
             EditWindow.ShowDialog();
             MessageBox.Show("Данные изменены");

        }

        private void DataGridClient_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtnClientServis_Click(object sender, RoutedEventArgs e)
        {
            WindowClientServis windowClientServis = new WindowClientServis();
            windowClientServis.Show();
            this.Hide();
        }
    }
}
