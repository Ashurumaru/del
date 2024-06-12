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

namespace laba9
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SuppliersTable_Click(object sender, RoutedEventArgs e)
        {
            MainFrane.Content = new SuppliersTable();
        }
        private void PhysicalPersonsTable_Click(object sender, RoutedEventArgs e)
        {
            MainFrane.Content = new PhysicalPersonsTable();
        }
        private void LegalPersonsTable_Click(object sender, RoutedEventArgs e)
        {
            MainFrane.Content = new LegalPersonsTable();
        }
    }
}
