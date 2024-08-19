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
    /// Логика взаимодействия для BlockedUser.xaml
    /// </summary>
    public partial class BlockedUser : Page
    {
        public BlockedUser()
        {
            InitializeComponent();
            UserList();
        }
        private DataClasses1DataContext BD = new DataClasses1DataContext();

        public void UserList()
        {
            tbl_Users[] arrUser = (from b in BD.tbl_Users select b).ToArray();
            string userText = "";
            foreach(var user in arrUser)
            {
                userText = user.UserID + ". " + user.FullName;
                userText += (user.Blocked == false) ? ".   Доступ не ограничен\n" : ".   Заблокирован\n";
                userList.Content += userText;
            }
        }

        public void UserChangeState()
        {
            int userIdToChange;
            if (int.TryParse(userId.Text, out userIdToChange))
            {
                // Найти пользователя по userIdToChange
                tbl_Users user = BD.tbl_Users.FirstOrDefault(u => u.UserID == userIdToChange);
                if (user != null)
                {
                    // Изменить состояние блокировки пользователя
                    user.Blocked = !user.Blocked;

                    // Сохранить изменения в базе данных
                    BD.SubmitChanges();

                    userList.Content = "";

                    UserList();
                }
                else
                {
                    // Обработка ситуации, когда пользователь не найден
                    MessageBox.Show($"Пользователь с ID {userIdToChange} не найден.");
                }
            }
            else
            {
                // Обработка ситуации, когда userIdToChange не удалось преобразовать в число
                MessageBox.Show("Некорректный ID пользователя.");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UserChangeState();
        }
    }
}
