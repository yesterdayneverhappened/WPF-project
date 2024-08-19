using System;
using System.Collections.Generic;
using System.Data.Linq;
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

namespace Курсач
{
    /// <summary>
    /// Логика взаимодействия для Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        public Page2()
        {
            InitializeComponent();
            TableZkaz();
        }
        private DataClasses1DataContext BD = new DataClasses1DataContext();
        public void TableZkaz()
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
                            Дата = c.DataOrder.ToLongDateString(),
                        };

            // Устанавливаем источник данных для DataGrid
            Tabl.ItemsSource = query.ToList();

        }
    }
}
