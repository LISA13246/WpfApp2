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
    /// Логика взаимодействия для WindowClien.xaml
    /// </summary>
    public partial class WindowClien : Window
    {
        wwwEntities context;
        public WindowClien(wwwEntities context, Client client)
        {
            InitializeComponent();
            this.context = context;
            CmbGender.ItemsSource = context.Gender.ToList();
            this.DataContext = client;
        }

        private void SaveData_Click(object sender, RoutedEventArgs e)
        {
            context.SaveChanges();           
            this.Close();
        }
    }
}
