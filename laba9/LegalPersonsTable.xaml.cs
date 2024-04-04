using laba9.model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
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
    /// Логика взаимодействия для LegalPersonsTable.xaml
    /// </summary>
    /// 
    public class SupplierCode
    {
        public int Code { get; set; }
    }
    public partial class LegalPersonsTable : Page
    {
        ObservableCollection<LegalPerson> LegalPersonsList;
        public ObservableCollection<SupplierCode> SupplierCodes { get; set; }

        public LegalPersonsTable()
        {
            InitializeComponent();
            UpdateDataGrid();
            LoadSupplierCodes();
        }
        private void LoadSupplierCodes()
        {
            using (var context = new dddEntities())
            {
                SupplierCodes = new ObservableCollection<SupplierCode>(
                    context.Поставщики.Select(s => new SupplierCode { Code = s.КодПоставщика }).ToList()
                );
            }
        }

        private void DataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var column in DataGridLegalPersons.Columns)
            {
                if (column is DataGridTemplateColumn templateColumn)
                {
                    var cellTemplate = templateColumn.CellTemplate;
                    if (cellTemplate != null)
                    {
                        var comboBox = cellTemplate.LoadContent() as ComboBox;
                        if (comboBox != null)
                        {
                            comboBox.ItemsSource = SupplierCodes;
                        }
                    }
                }
            }
        }


        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataGridLegalPersons.SelectedItem is Поставщики selectedSupplier)
            {
                using (var content = new dddEntities())
                {
                    var comboBox = sender as ComboBox;
                    selectedSupplier.КодПоставщика = (int)comboBox.SelectedValue;

                    content.Entry(selectedSupplier).State = EntityState.Modified;
                    content.SaveChanges();
                }
                
            }
        }

        private void UpdateDataGrid()
        {
            using (var context = new dddEntities())
            {
                LegalPersonsList = new ObservableCollection<LegalPerson>(context.ЮридическиеЛица.Select(r => new LegalPerson
                {
                    КодПоставщика = r.КодПоставщика,
                    Название = r.Название,
                    НалоговыйНомер = r.НалоговыйНомер,
                    НомерСвидетельстваНДС = r.НомерСвидетельстваНДС
                }).ToList());

                DataGridLegalPersons.ItemsSource = LegalPersonsList;
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = DataGridLegalPersons.SelectedItem as LegalPerson;

            if (selectedItem != null)
            {
                EditLegalPersonsTable view = new EditLegalPersonsTable(selectedItem);
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
            AddLegalPersonsTable view = new AddLegalPersonsTable();
            view.Closed += EditWindow_Closed;
            view.ShowDialog();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            LegalPerson selectedItem = (LegalPerson)DataGridLegalPersons.SelectedItem;

            if (selectedItem != null)
            {
                MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите удалить этот элемент?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    using (var context = new dddEntities())
                    {
                        var itemToRemove = context.ЮридическиеЛица.FirstOrDefault(s => s.КодПоставщика == selectedItem.КодПоставщика);

                        if (itemToRemove != null)
                        {
                            context.ЮридическиеЛица.Remove(itemToRemove);
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
