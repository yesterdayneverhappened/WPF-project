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

namespace Курсач
{
    /// <summary>
    /// Логика взаимодействия для Reg.xaml
    /// </summary>
    public partial class Reg : Page
    {
        public Reg()
        {
            InitializeComponent();
        }
        private string filePath = "info.txt";

        private string loginU { get; set; }
        private string password { get; set; }
        private string passwordUpply;
        private string tel;
        private int UsId { get; set; }

        private void CheckIsEmpty()
        {
            if (login.Text == null || login.Text == "")
            {
                MessageBox.Show("Вы не ввели логин");
            }
            if (pass.Text == null || pass.Text == "")
            {
                MessageBox.Show("Вы не ввели пароль");
            }
            else
            {
                loginU = login.Text;
                password = pass.Text;
                passwordUpply = pass2.Text;
            }
        }
        private void CheckPass()
        {
            if (password == passwordUpply)
            {
                return;
            }
            else
            {
                Err.Content = "Ваш пароль не совпадает";
            }
        }
        private void CheckLogin()
        {
            char[] logInChar = loginU.ToCharArray();
            char first = logInChar[0];
            if (char.IsDigit(first))
            {
                ErrLogin.Content = "Логин не может начинатся с цифры";
            }
            else
            {
                return;
            }
        }
        private void CheckPhone()
        {

        }
        //////////////////////////////////////////////////
        private DataClasses1DataContext BD = new DataClasses1DataContext();
        private void Rega()
        {
            Random rnd = new Random();
            int balanse = rnd.Next(10, 100);
            tel = number.Text;
            string adr = adres.Text;
            string hashPass = pass.Text.GetHashCode().ToString();

            tbl_Users tbl_Users1 = new tbl_Users();
            tbl_Users1.Street = adr;
            tbl_Users1.FullName = loginU;
            tbl_Users1.PhoneNumber = tel;
            tbl_Users1.Password_User = hashPass;
            tbl_Users1.Balanse = balanse;
            tbl_Users1.Blocked = false;
            
            BD.tbl_Users.InsertOnSubmit(tbl_Users1);
            BD.SubmitChanges();
            UsId = tbl_Users1.UserID;
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CheckIsEmpty();
                CheckPass();
                CheckLogin();
                Rega();
                MainWindow wind = new MainWindow(UsId);
                wind.Show();
                OpenShop openShop = new OpenShop(UsId);
                Registration re = new Registration();
                re.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка" + ex.Message, "Попробуйте сново ", MessageBoxButton.OK, MessageBoxImage.Warning);
            }


        }
        private void Singln_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new LogIN());
        }

        private void Reg4_MouseDown(object sender, MouseButtonEventArgs e)
        {
            

        }
    }
}
