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
    /// Логика взаимодействия для Req.xaml
    /// </summary>
    public partial class Req : Page
    {
        public Req()
        {
            InitializeComponent();
            AllUsers();
        }
        private DataClasses1DataContext BD = new DataClasses1DataContext();
        public void AllUsers()
        {
            tbl_Users[] arrUser = (from b in BD.tbl_Users select b).ToArray();
            string userText = "";
            string userReq = "";
            foreach (var user in arrUser)
            {
                if(user.BalanseReq != 0 || user.BalanseReq != null || user.BalanseReq != -1)
                {
                    userText = user.UserID + ". " + user.FullName + "\n";
                    userReq = user.BalanseReq + "\n";
                   
                }
                
            }
            userName.Content = userText;
            req.Content = userReq;
        }
        public void Accept()
        {
            int userId;
            tbl_Users[] arrUser = (from b in BD.tbl_Users select b).ToArray();
            if (int.TryParse(nameTextBox.Text, out userId))
            {
                var userToUpdate = BD.tbl_Users.FirstOrDefault(u => u.UserID == userId);
                userToUpdate.Balanse += (int) arrUser[userId-1].BalanseReq;
                userToUpdate.BalanseReq = 0;
                BD.SubmitChanges();
                MessageBox.Show("Баланс пользователя пополнен");
                AllUsers();
            }
            else { MessageBox.Show("Введите правильное id пользователя"); }
           
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Accept();
        }
        public void Rejected()
        {
            int userId;
            tbl_Users[] arrUser = (from b in BD.tbl_Users select b).ToArray();
            if (int.TryParse(nameTextBox.Text, out userId))
            {
                var userToUpdate = BD.tbl_Users.FirstOrDefault(u => u.UserID == userId);
                userToUpdate.BalanseReq = -1;
                MessageBox.Show("Запрос на пополнение отклонён");
                AllUsers();
            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Rejected();
        }
    }
}
