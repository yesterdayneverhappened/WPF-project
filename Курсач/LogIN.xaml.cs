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
    /// Логика взаимодействия для LogIN.xaml
    /// </summary>
    public partial class LogIN : Page
    {
        public LogIN()
        {
            InitializeComponent();
        }

        private void Reg5_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new Reg());
        }
        private DataClasses1DataContext BD = new DataClasses1DataContext();
        private string logIN;
        private string password;
        private int ID;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            tbl_Users[] arr = (from b in BD.tbl_Users select b).ToArray();
            logIN = login5.Text;
            password = pass5.Text.GetHashCode().ToString();
            int i = 0;
            foreach (var a in arr)
            {
                if (a.Password_User == password && "admin" == logIN)
                {
                    admin admin = new admin();
                    admin.Show();
                    Registration registration = new Registration();
                    registration.Close();
                    break;
                }
                else if (a.Password_User == password && a.FullName == logIN)
                {
                    if(a.Blocked == false)
                    {
                        ID = arr[i].UserID;
                        MainWindow w = new MainWindow(ID);
                        w.Show();
                        Registration registration = new Registration();
                        registration.Close();
                    }
                    else
                    {
                        MessageBox.Show("Ваша учётная запись была заюлокировала");
                    }
                }

                i++;
            }
        }
    }
}
