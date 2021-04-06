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
using System.Windows.Shapes;
using System.Drawing;

namespace LootEgami.Dialog
{
    /// <summary>
    /// ImageWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ImageWindow : Window
    {
        public ImageWindow()
        {
            InitializeComponent();
            this.Title = "이미지 창";
        }
        
        public void LoadImage(string path)
        {
            this.Show();
            this.ImageBox.Source = new BitmapImage(new Uri(path));
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        public void SaveImage()
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "다른 이름으로 저장";
            saveFileDialog.DefaultExt = "jpg";
            saveFileDialog.Filter = "Image Files | *.jpg; *.png; *.gif; *.bmp";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName != "")
            {
                var image = new Image();
                image = this.ImageBox;
            }
        }           
    }
}
