using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
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
using laba9.model;
using System.Collections.ObjectModel;


namespace laba9
{
    /// <summary>
    /// Логика взаимодействия для SuppliersTable.xaml
    /// </summary>
    public partial class SuppliersTable : Page
    {
        ObservableCollection<Supplier> SuppliersList;

        public SuppliersTable()
        {
            InitializeComponent();
            UpdateDataGrid();
        }

        private void UpdateDataGrid()
        {
            using (var context = new dddEntities())
            {
                SuppliersList = new ObservableCollection<Supplier>(context.Поставщики.Select(r => new Supplier
                {
                    КодПоставщика = r.КодПоставщика,
                    Адрес = r.Адрес,
                    Примечание = r.Примечание
                }).ToList()); 

                DataGridSuppliers.ItemsSource = SuppliersList;
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var selectedSupplier = DataGridSuppliers.SelectedItem as Supplier;

            if (selectedSupplier != null)
            {
                EditSuppliersTable view = new EditSuppliersTable(selectedSupplier); 
                view.Closed += EditWindow_Closed;
                view.ShowDialog();
            }
            else
            {
                MessageBox.Show("Выберите поставщика для редактирования.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddSuppliersTable view = new AddSuppliersTable();
            view.Closed += EditWindow_Closed;
            view.ShowDialog();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            Supplier selectedSupplier = (Supplier)DataGridSuppliers.SelectedItem;

            if (selectedSupplier != null)
            {
                MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите удалить этого поставщика?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    using (var context = new dddEntities())
                    {
                        var supplierToRemove = context.Поставщики.FirstOrDefault(s => s.КодПоставщика == selectedSupplier.КодПоставщика);

                        if (supplierToRemove != null)
                        {
                            context.Поставщики.Remove(supplierToRemove);
                            context.SaveChanges();
                            UpdateDataGrid();
                        }
                        else
                        {
                            MessageBox.Show("Поставщик не найден.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите поставщика для удаления.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void EditWindow_Closed(object sender, EventArgs e)
        {
            UpdateDataGrid();
        }
    }
}
