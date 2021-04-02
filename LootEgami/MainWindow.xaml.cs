using Microsoft.Win32;
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

namespace LootEgami
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_ImageLoad(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            {
                openFileDialog.Filter = "Image Files | *.jpg; *.png; *.gif; *.bmp";
                openFileDialog.Multiselect = true;

                if (openFileDialog.ShowDialog().GetValueOrDefault())
                {
                    foreach (var i in openFileDialog.FileNames)
                    {
                        FilePathList.Items.Add(i);
                    }
                }                
            }
        }

        private void Button_Click_ImageDelete(object sender, RoutedEventArgs e)
        {
            var selectedIndex = FilePathList.SelectedIndex;
            if (selectedIndex != -1) { FilePathList.Items.RemoveAt(FilePathList.SelectedIndex); }
        }

        private void Button_Click_ImageClear(object sender, RoutedEventArgs e)
        {
            FilePathList.Items.Clear();
        }

        private void FilePathList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var image = new Image();
            image.Source = new BitmapImage(new Uri(FilePathList.SelectedItem.ToString()));

            var imageWindow = new LootEgami.Dialog.ImageWindow();
            imageWindow.Show();
            imageWindow.ImageBox.Source = image.Source;
        }
    }
}
