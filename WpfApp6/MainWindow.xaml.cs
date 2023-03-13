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
using System.IO;
using Microsoft.Win32;

namespace WpfApp6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {

            var check = sender as CheckBox;
            if (check?.IsChecked == true)
            {
                int s = 1;
                while (true)
                {
                    if (File.Exists($"text{s}.txt")) s++;
                    else
                    {
                        File.WriteAllText($"text{s}.txt", txtbx2.Text);
                        MessageBox.Show("Text saved","Information",MessageBoxButton.OK,MessageBoxImage.Information);
                        break;
                    }
                }
            }
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists(txtbx1.Text))
            {
                txtbx2.Text=File.ReadAllText(txtbx1.Text);
            }
            else
            {
                var dialog = new OpenFileDialog();
                dialog.Filter = dialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                dialog.ShowDialog();
                if(dialog.FileName.Length>0)txtbx2.Text = File.ReadAllText(dialog.FileName);
            }
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            save.ShowDialog();
            if (save.FileName.Length>0) File.WriteAllText(save.FileName, txtbx2.Text);
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            if (txtbx2.SelectionLength != 0)
            {
                txtbx2.Copy();
                MessageBox.Show("Text Copied", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btn6_Click(object sender, RoutedEventArgs e)
        {   
            txtbx2.SelectAll();
            txtbx2.Focus();
        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            if (txtbx2.SelectionLength > 0) txtbx2.AppendText(txtbx2.SelectedText);
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            txtbx2.Cut();
        }
    }
}
