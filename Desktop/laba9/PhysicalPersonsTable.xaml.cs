using laba9.model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для PhysicalPersonsTable.xaml
    /// </summary>
    public partial class PhysicalPersonsTable : Page
    {
        ObservableCollection<PhysicalPerson> PhysicalPersonsList;

        public PhysicalPersonsTable()
        {
            InitializeComponent();
            UpdateDataGrid();
        }
        private void UpdateDataGrid()
        {
            using (var context = new dddEntities())
            {
                PhysicalPersonsList = new ObservableCollection<PhysicalPerson>(context.ФизическиеЛица.Select(r => new PhysicalPerson
                {
                    КодПоставщика = r.КодПоставщика,
                    Имя = r.Имя,
                    Фамилия = r.Фамилия,
                    Отчество = r.Отчество,
                    НомерСвидетельства = r.НомерСвидетельства
                }).ToList());

                DataGridPhysicalPersons.ItemsSource = PhysicalPersonsList;
            }
        }
        //доделать!!!!!!!!!!!!!!!!!!!
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = DataGridPhysicalPersons.SelectedItem as PhysicalPerson;

            if (selectedItem != null)
            {
                EditPhysicalPersonsTable view = new EditPhysicalPersonsTable(selectedItem);
                view.Closed += EditWindow_Closed;
                view.ShowDialog();
            }
            else
            {
                MessageBox.Show("Выберите элемент для редактирования.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddPhysicalPersonsTable view = new AddPhysicalPersonsTable();
            view.Closed += EditWindow_Closed;
            view.ShowDialog();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            PhysicalPerson selectedItem = (PhysicalPerson)DataGridPhysicalPersons.SelectedItem;

            if (selectedItem != null)
            {
                MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите удалить этот элемент?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    using (var context = new dddEntities())
                    {
                        var itemToRemove = context.ФизическиеЛица.FirstOrDefault(s => s.КодПоставщика == selectedItem.КодПоставщика);

                        if (itemToRemove != null)
                        {
                            context.ФизическиеЛица.Remove(itemToRemove);
                            context.SaveChanges();
                            UpdateDataGrid();
                        }
                        else
                        {
                            MessageBox.Show("Элемент не найден.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите элемент для удаления.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void EditWindow_Closed(object sender, EventArgs e)
        {
            UpdateDataGrid();
        }
    }
}
