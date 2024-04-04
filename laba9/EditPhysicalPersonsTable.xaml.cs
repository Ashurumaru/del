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
    /// Логика взаимодействия для EditPhysicalPersonsTable.xaml
    /// </summary>
    public partial class EditPhysicalPersonsTable : Window
    {
        public EditPhysicalPersonsTable(PhysicalPerson item)
        {
            InitializeComponent();
            one.Text = item.КодПоставщика.ToString();
            two.Text = item.Фамилия;
            thee.Text = item.Имя;
            four.Text = item.Отчество;
            five.Text = item.НомерСвидетельства;
        }
        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new dddEntities())
            {
                int кодПоставщика = int.Parse(one.Text);

                var item = context.ФизическиеЛица.FirstOrDefault(s => s.КодПоставщика == кодПоставщика);

                if (item != null)
                {

                    item.Фамилия = two.Text;
                    item.Имя = thee.Text;
                    item.Отчество = four.Text;
                    item.НомерСвидетельства = five.Text;

                    context.SaveChanges();

                    MessageBox.Show("Данные успешно обновлены!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Элемент с указанным кодом не найден!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

        }
    }
}
