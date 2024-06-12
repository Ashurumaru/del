using laba9.model;
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
    /// Логика взаимодействия для AddSuppliersTable.xaml
    /// </summary>
    public partial class AddSuppliersTable : Window
    {
        public AddSuppliersTable()
        {
            InitializeComponent();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var context = new dddEntities())
                {
                    var item = new Поставщики
                    {
                        КодПоставщика = int.Parse(one.Text),
                        Адрес = two.Text,
                        Примечание = thee.Text
                    };

                    context.Поставщики.Add(item);

                    context.SaveChanges();

                    this.Close();
                    MessageBox.Show("Данные успешно сохранены!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
