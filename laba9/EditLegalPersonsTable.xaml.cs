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
using laba9.model;

namespace laba9
{
    /// <summary>
    /// Логика взаимодействия для EditLegalPersonsTable.xaml
    /// </summary>
    public partial class EditLegalPersonsTable : Window
    {
        public EditLegalPersonsTable(LegalPerson item)
        {
            InitializeComponent();
            if (item != null)
            {
                one.Text = item.КодПоставщика.ToString();
                two.Text = item.Название;
                thee.Text = item.НалоговыйНомер;
                four.Text = item.НомерСвидетельстваНДС;
            }
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new dddEntities())
            {
                int кодПоставщика = int.Parse(one.Text);

                var item = context.ЮридическиеЛица.FirstOrDefault(s => s.КодПоставщика == кодПоставщика);

                if (item != null)
                {

                    item.Название = two.Text;
                    item.НалоговыйНомер = thee.Text;
                    item.НомерСвидетельстваНДС = four.Text;

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
