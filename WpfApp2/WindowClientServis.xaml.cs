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
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для WindowClientServis.xaml
    /// </summary>
    public partial class WindowClientServis : Window
    {
        wwwEntities context1;
        public WindowClientServis()
        {
            InitializeComponent();
            context1 = new  wwwEntities();
            ShowTable1();

        }
        private void ShowTable1()
        {
            DataGridClientServis.ItemsSource = context1.ClientService.ToList();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Hide();
        }

        private void DataGridClientServis_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
