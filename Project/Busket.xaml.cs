using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Label = System.Windows.Controls.Label;

namespace Курсач
{
    /// <summary>
    /// Логика взаимодействия для Busket.xaml
    /// </summary>
    public class LabalCreator
    {
        public Label CreateLabel(string content, string name, int margin, int left, int top, int right)
        {

            Label label = new Label();
            label.Content = content;
            label.Name = name;
            label.Margin = new Thickness(left, margin,0,0);
            return label;
            
        }
    }
    
    public partial class Busket : Page
    {
        
        public Busket(int name1)
        {
            InitializeComponent();
            this.name1 = name1;
            ListU();
           

        }
        int name1;
        private DataClasses1DataContext BD = new DataClasses1DataContext();
        int i7 = 0;
        private void clear_Click(object sender, RoutedEventArgs e)
        {
            i7++;
            if (i7 == 1)
            {
                tbl_OrderTY[] arrOpl = (from b in BD.tbl_OrderTY select b).ToArray();
                for (int i = 0; i < arrOpl.Length; i++)
                {
                    if (arrOpl[i].UserID == name1)
                    {
                        if (arrOpl[i].Oplacheno == false)
                        {
                            var rowToDelete = BD.tbl_OrderTY.FirstOrDefault(row => row.UserID == name1);
                            if (rowToDelete != null)
                            {
                                BD.tbl_OrderTY.DeleteOnSubmit(rowToDelete);
                                try
                                {
                                    BD.SubmitChanges();
                                    MessageBox.Show("Корзина очищена");
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                            }
                        }
                    }
                
                }
            }
        }
        public void ClearBusket()
        {

        }
        int i4 = 0;
        private void oplata_Click(object sender, RoutedEventArgs e)
        {
            i4++;
            if (i4 == 1)
            {
                
                oplata();
                return;
            }
            else
            {
                return;
            }
        }
        public void ListU()
        {
            ScrollViewer scrollViewer = new ScrollViewer();
            
            Grid grid = new Grid();
            
            Content = scrollViewer;
            string nameB = "b";
            string nameA = "a";
            string nameG = "g";
            tbl_OrderTY[] arr = (from b in BD.tbl_OrderTY select b).ToArray();
            tbl_Books[] arrBook = (from b in BD.tbl_Books select b).ToArray();
            int row = 40;
            int row2 = 25;
            int j = 0;
            int newI = 1;
            int allPrise =0;
            int stertPrise =0;
            int bookPrise = 0;
            
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].Oplacheno == false)
                {
                    if (name1 == (int)arr[i].UserID)
                    {
                        LabalCreator label = new LabalCreator();
                        nameB = nameB + i;
                        nameA = nameA + i;
                        nameG = nameG + i;

                        j = (int)arr[i].BookID - 1;
                        Label lbl = new Label();
                        lbl = label.CreateLabel(newI + ". " + arrBook[j].Title.ToString(), nameB, row, 200, 0, 0);
                        grid.Children.Add(lbl);
                        Label lbl2 = new Label();
                        lbl2 = label.CreateLabel(arrBook[j].tbl_Author.AuthorName.ToString(), nameA, row, 450, 0, 0);
                        grid.Children.Add(lbl2);
                        Label lbl3 = new Label();
                        lbl3 = label.CreateLabel(arrBook[j].tbl_Genre.GenreName.ToString(), nameG, row, 600, 0, 0);
                        grid.Children.Add(lbl3);
                        Label lbl4 = new Label();
                        lbl4 = label.CreateLabel(arrBook[j].Prise.ToString() + "+" + arrBook[j].PriseStart.ToString(), nameG, row, 750, 0, 0);
                        grid.Children.Add(lbl4);
                        
                        allPrise += arrBook[j].Prise + arrBook[j].PriseStart;
                        stertPrise += arrBook[j].PriseStart;
                        bookPrise += arrBook[j].Prise;

                        lbl.FontWeight = FontWeights.Bold;
                        lbl2.Foreground = Brushes.Gray;
                        lbl3.Foreground = Brushes.Gray;
                        AutoSize();
                        row += 40;
                        row2 += 25;
                        newI++;
                    }

                }
            }
            Content = scrollViewer;
            scrollViewer.Content = grid;

            LabalCreator label2 = new LabalCreator();
            Label lbl6 = new Label();
            lbl6 = label2.CreateLabel("Сумма залога: " + stertPrise.ToString(), nameG, row, 470, 0, 70);
            grid.Children.Add(lbl6);
            Label lbl5 = new Label();
            lbl5 = label2.CreateLabel("Сумма всех книг: " + bookPrise.ToString(), nameG, row, 620, 0, 70);
            grid.Children.Add(lbl5);
            Label lbl7 = new Label();
            lbl7 = label2.CreateLabel("Итого: " + allPrise.ToString(), nameG, row, 750, 0, 70);
            grid.Children.Add(lbl7);

            lbl7.FontWeight = FontWeights.Bold;
            lbl5.Foreground = Brushes.Gray;
            lbl6.Foreground = Brushes.Gray;

            Button btn = new Button();
            btn.Content = "Оплатить";
            btn.Name = "oplata68";
            btn.Height = 50;
            btn.Width = 70;
            btn.Background = new SolidColorBrush(Colors.Green);
            btn.VerticalAlignment = VerticalAlignment.Bottom;
            grid.Children.Add(btn);

            btn.Click += new RoutedEventHandler(oplata_Click);
            grid.AddHandler(ButtonBase.ClickEvent, new RoutedEventHandler(oplata_Click));

            Button btn2 = new Button();
            btn2.Content = "Очистить карзину";
            btn2.Name = "oplata68";
            btn2.Height = 50;
            btn2.Width = 150;
            btn2.VerticalAlignment = VerticalAlignment.Bottom;
            btn2.Margin = new Thickness(220, 0, 0, 0);
            grid.Children.Add(btn2);

            btn2.Click += new RoutedEventHandler(clear_Click);
            grid.AddHandler(ButtonBase.ClickEvent, new RoutedEventHandler(clear_Click));
        }
                
        public void AutoSize()
        {
            foreach (FrameworkElement txt in InGrid.Children)
            {

                if (txt is Label)
                {
                    txt.HorizontalAlignment = HorizontalAlignment.Stretch;
                    txt.VerticalAlignment = VerticalAlignment.Stretch;
                }
            }
        }
        
        public void oplata()
        {
            int fg = 0;
            tbl_OrderTY[] arr = (from b in BD.tbl_OrderTY select b).ToArray();
            tbl_Users[] arrUse = (from b in BD.tbl_Users select b).ToArray();
            tbl_OrderTY[] arrOpl = (from b in BD.tbl_OrderTY select b).ToArray();
            int priseAll = 0;
            int newBalanse = 0;
            for (int k = 0; k < arr.Length; k++)
            {
                if (arr[k].BookID == name1)
                {
                    priseAll += arr[k].Amount;
                }
            }
            newBalanse = arr[name1 - 1].tbl_Users.Balanse;
            if (arrUse[name1 - 1].Balanse < priseAll)
            {
                MessageBox.Show("У вас недостаточно денег");
            }
            else
            {
                for (int j = 0; j < arr.Length; j++)
                {
                    if (arr[j].UserID == name1)
                    {
                        if (arr[j].Oplacheno == false)
                        {
                            if (newBalanse > arr[j].PriseAll)
                        {
                           
                                newBalanse -= arr[j].PriseAll;
                                var userToUpdate = BD.tbl_Users.FirstOrDefault(u => u.UserID == name1);
                                userToUpdate.Balanse = newBalanse;
                                arrOpl[j].Oplacheno = true;
                                BD.SubmitChanges();
                            }
                            
                        }
                        
                        
                    }
                }
                
            }

        }
       
    }
}

    