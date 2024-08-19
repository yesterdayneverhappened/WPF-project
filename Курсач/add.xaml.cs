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

namespace Курсач
{
    /// <summary>
    /// Логика взаимодействия для add.xaml
    /// </summary>
    public partial class add : Window
    {
        public add(int name)
        {
            InitializeComponent();
            this.name = name;
            Time();
        }
        public int name;

        private DataClasses1DataContext BD = new DataClasses1DataContext();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int balanse;
            var userToUpdate = BD.tbl_Users.FirstOrDefault(u => u.UserID == name);
            if (int.TryParse(balanseReq.Text, out balanse)) {
                userToUpdate.BalanseReq = balanse;
                BD.SubmitChanges();
            }
            else
            {
                MessageBox.Show("Введите правильный запрос на баланс");
            }
            MessageBox.Show("Запрос на сумму " + balanse + " передан на рассмотрение");
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        public void Time()
        {
            var userToUpdate = BD.tbl_Users.FirstOrDefault(u => u.UserID == name);
            if (userToUpdate.BalanseReq > 0 || userToUpdate.BalanseReq != null)
            {
                timeTextBox.Content = "Ваш запрос ещё рассматривается,\nвы моежете обновить его\nили же отклонить";
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            
            var userToUpdate = BD.tbl_Users.FirstOrDefault(u => u.UserID == name);
            userToUpdate.BalanseReq = null;
            BD.SubmitChanges();
            MessageBox.Show("Запрос был отклонён");
            Time();
        }
    }
}
