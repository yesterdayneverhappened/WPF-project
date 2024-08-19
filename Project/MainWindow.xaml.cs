using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
using System.Data.Linq;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics;

namespace Курсач
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        OpenShop op;
        public MainWindow(int name)
        {
            InitializeComponent();
            this.name = name;
            User();
            
            back.Visibility = Visibility.Collapsed;
            op = new OpenShop(name);
            Scroll();
            ReqBalanse();
        }
        int name;
        int newId;
        private DataClasses1DataContext BD = new DataClasses1DataContext();

        public void User()
        {
            string nameU = "";
            tbl_Users[] arr = (from b in BD.tbl_Users select b).ToArray();
            
            int i = 0;
            foreach (var use in arr)
            {
                if (name == arr[i].UserID)
                {
                    newId = arr[i].UserID;
                    _balanse.Content += arr[i].Balanse.ToString();
                    nameU = arr[i].FullName.ToString();
                }
                i++;
            }
            user.Content = nameU;
        }

        public void Scroll()
        {

            LOL.Content = op;
        }
        public void ReqBalanse()
        {
            tbl_Users[] arr = (from b in BD.tbl_Users select b).ToArray();
            if (arr[name-1].BalanseReq != null)
            {
                if (arr[name-1].BalanseReq == 0)
                {
                    MessageBox.Show("Ваш запрос на поплнение счёта был одобрен");
                    var userToUpdate = BD.tbl_Users.FirstOrDefault(u => u.UserID == name);
                    userToUpdate.BalanseReq = null;
                    BD.SubmitChanges();
                }
                else if (arr[name - 1].BalanseReq == -1)
                {
                    MessageBox.Show("Ваш запрос на пополлнение счёта был откланён");
                    var userToUpdate = BD.tbl_Users.FirstOrDefault(u => u.UserID == name);
                    userToUpdate.BalanseReq = null;
                    BD.SubmitChanges();
                }
            }
            
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LOL.Content = new Busket(newId);
            back.Visibility = Visibility.Visible;
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            LOL.Content = new OpenShop(newId);
            back.Visibility = Visibility.Collapsed;
            tbl_Users[] arr = (from b in BD.tbl_Users select b).ToArray();
            _balanse.Content = "Кошелёк: " + arr[name-1].Balanse;

        }

        private void user_Click(object sender, RoutedEventArgs e)
        {
            LOL.Content = new Page1(newId);
            back.Visibility = Visibility.Visible;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //op.SortAZ();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            LOL.Content = new Filter(newId);
            back.Visibility = Visibility.Visible;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            add add = new add(name);
            add.ShowDialog();
        }
    }
}
