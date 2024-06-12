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

namespace laba9
{
    /// <summary>
    /// Логика взаимодействия для AddPhysicalPersonsTable.xaml
    /// </summary>
    public partial class AddPhysicalPersonsTable : Window
    {
        public AddPhysicalPersonsTable()
        {
            InitializeComponent();
        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var context = new dddEntities())
                {
                    var item = new ФизическиеЛица
                    {
                        КодПоставщика = int.Parse(one.Text),
                        Фамилия = two.Text,
                        Имя = thee.Text,
                        Отчество = four.Text,
                        НомерСвидетельства = five.Text
                    };

                    context.ФизическиеЛица.Add(item);

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
