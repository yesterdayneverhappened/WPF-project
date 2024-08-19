using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
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
using Excel = Microsoft.Office.Interop.Excel;

namespace Курсач
{
    /// <summary>
    /// Логика взаимодействия для admin.xaml
    /// </summary>
    public partial class admin : Window
    {
        public admin()
        {
            InitializeComponent();
            ADMIN.Content = new Page2();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ADMIN.Content = new newBook();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ADMIN.Content = new BlockedUser();
        }
        private DataClasses1DataContext BD = new DataClasses1DataContext();

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var query = from c in BD.tbl_OrderTY
                        join book in BD.tbl_Books on c.BookID equals book.BookID
                        join user in BD.tbl_Users on c.UserID equals user.UserID
                        select new
                        {
                            Номер_заказа = c.OrderID,
                            Книга = c.tbl_Books.Title,
                            Пользователь = c.tbl_Users.FullName,
                            Сумма = c.PriseAll,
                            Оплачен = c.Oplacheno,
                            Дата = c.DataOrder.ToLongDateString()
                        };

            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "Excel files (*.xlsx)|*.xlsx",
                    FileName = "orders.xlsx"
                };

                if (saveFileDialog.ShowDialog() == true)
                {
                    Excel.Application excelApp = new Excel.Application();
                    Excel.Workbook workbook = excelApp.Workbooks.Add();
                    Excel.Worksheet worksheet = workbook.ActiveSheet;

                    // Записываем заголовки столбцов
                    worksheet.Cells[1, 1] = "Номер_заказа";
                    worksheet.Cells[1, 2] = "Книга";
                    worksheet.Cells[1, 3] = "Пользователь";
                    worksheet.Cells[1, 4] = "Сумма";
                    worksheet.Cells[1, 5] = "Оплачен";
                    worksheet.Cells[1, 6] = "Дата";

                    // Записываем данные
                    int row = 2;
                    foreach (var item in query)
                    {
                        worksheet.Cells[row, 1] = item.Номер_заказа;
                        worksheet.Cells[row, 2] = item.Книга;
                        worksheet.Cells[row, 3] = item.Пользователь;
                        worksheet.Cells[row, 4] = item.Сумма;
                        worksheet.Cells[row, 5] = item.Оплачен;
                        worksheet.Cells[row, 6] = item.Дата;
                        row++;
                    }

                    workbook.SaveAs(saveFileDialog.FileName);
                    workbook.Close();
                    excelApp.Quit();

                    MessageBox.Show("Данные успешно экспортированы в файл Excel.", "Экспорт данных", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при экспорте данных: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var query = from c in BD.tbl_Users
                        select new
                        {
                            Id = c.UserID,
                            Полное_имя = c.FullName,
                            Улица = c.Street,
                            Номер_телефона = c.PhoneNumber,
                            Баланс = c.Balanse,
                            Запросы_баланса = c.BalanseReq,
                            Доступ = c.BalanseReq
                        };

            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "Excel files (*.xlsx)|*.xlsx",
                    FileName = "orders.xlsx"
                };

                if (saveFileDialog.ShowDialog() == true)
                {
                    Excel.Application excelApp = new Excel.Application();
                    Excel.Workbook workbook = excelApp.Workbooks.Add();
                    Excel.Worksheet worksheet = workbook.ActiveSheet;

                    // Записываем заголовки столбцов
                    worksheet.Cells[1, 1] = "Id";
                    worksheet.Cells[1, 2] = "Полное имя";
                    worksheet.Cells[1, 3] = "Улица";
                    worksheet.Cells[1, 4] = "Номер телефона";
                    worksheet.Cells[1, 5] = "Баланс";
                    worksheet.Cells[1, 6] = "Запросы баланса";
                    worksheet.Cells[1, 7] = "Доступ";

                    // Записываем данные
                    int row = 2;
                    foreach (var item in query)
                    {
                        worksheet.Cells[row, 1] = item.Id;
                        worksheet.Cells[row, 2] = item.Полное_имя;
                        worksheet.Cells[row, 3] = item.Улица;
                        worksheet.Cells[row, 4] = item.Номер_телефона;
                        worksheet.Cells[row, 5] = item.Баланс;
                        worksheet.Cells[row, 6] = item.Запросы_баланса;
                        worksheet.Cells[row, 7] = item.Доступ;
                        row++;
                    }

                    workbook.SaveAs(saveFileDialog.FileName);
                    workbook.Close();
                    excelApp.Quit();

                    MessageBox.Show("Данные успешно экспортированы в файл Excel.", "Экспорт данных", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при экспорте данных: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            var query = from c in BD.tbl_OrderTY
                        join book in BD.tbl_Books on c.BookID equals book.BookID
                        join user in BD.tbl_Users on c.UserID equals user.UserID
                        select new
                        {
                            Номер_заказа = c.OrderID,
                            Книга = c.tbl_Books.Title,
                            Пользователь = c.tbl_Users.FullName,
                            Сумма = c.PriseAll,
                            Оплачен = c.Oplacheno,
                            Дата = c.DataOrder.ToLongDateString()
                        };

            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "Excel files (*.xlsx)|*.xlsx",
                    FileName = "orders.xlsx"
                };

                if (saveFileDialog.ShowDialog() == true)
                {
                    Excel.Application excelApp = new Excel.Application();
                    Excel.Workbook workbook = excelApp.Workbooks.Add();
                    Excel.Worksheet worksheet = workbook.ActiveSheet;

                    // Записываем заголовки столбцов
                    worksheet.Cells[1, 1] = "Номер_заказа";
                    worksheet.Cells[1, 2] = "Книга";
                    worksheet.Cells[1, 3] = "Пользователь";
                    worksheet.Cells[1, 4] = "Сумма";
                    worksheet.Cells[1, 5] = "Оплачен";
                    worksheet.Cells[1, 6] = "Дата";

                    // Записываем данные
                    int row = 2;
                    foreach (var item in query)
                    {
                        worksheet.Cells[row, 1] = item.Номер_заказа;
                        worksheet.Cells[row, 2] = item.Книга;
                        worksheet.Cells[row, 3] = item.Пользователь;
                        worksheet.Cells[row, 4] = item.Сумма;
                        worksheet.Cells[row, 5] = item.Оплачен;
                        worksheet.Cells[row, 6] = item.Дата;
                        row++;
                    }

                    workbook.SaveAs(saveFileDialog.FileName);
                    workbook.Close();
                    excelApp.Quit();

                    MessageBox.Show("Данные успешно экспортированы в файл Excel.", "Экспорт данных", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при экспорте данных: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            ADMIN.Content = new Req();
        }
    }
}
