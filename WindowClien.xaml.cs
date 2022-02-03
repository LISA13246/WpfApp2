using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
            SaveImage();
            context.SaveChanges();
            this.Close();
        }
        
        private void SaveImage()
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Image files: *.jpg, *.png| *.jpg;*.png";
            openFile.ShowDialog();
            if (openFile.FileName.Length != 0)
            {
                string namefile = openFile.FileName;
                byte[] image = File.ReadAllBytes(namefile);
                var client = (Client)this.DataContext;
                //client.PhotoPath = image;
                Img.Source = new BitmapImage(new Uri(namefile));
            }
        }


    }
}
