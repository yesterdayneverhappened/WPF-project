using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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
using CheclBox = System.Windows.Controls.CheckBox;

namespace Курсач
{
    /// <summary>
    /// Логика взаимодействия для Filter.xaml
    /// </summary>
    public class MyCheckbox
    {
        public string Content { get; set; } 
        public Thickness Margin { get; set; } 
        public string Name { get; set; }

        public CheckBox Create(string content, double margin, string name)
        {
            CheckBox checkBox = new CheckBox();
            checkBox.Content = content;
            checkBox.Margin = new Thickness(0, margin, 0, 0);
            checkBox.Name = name;
            return checkBox;
        }

        public MyCheckbox()
        {
        }
    }
    public partial class Filter : Page
    {
        OpenShop op;
        public Filter(int id)
        {
            InitializeComponent();
            this.id = id;
            op = new OpenShop(id);
            AllGenre();
            AllAuthor();
        }
        int id;
        private DataClasses1DataContext BD = new DataClasses1DataContext();
        public void AllGenre()
        {
            Grid grid = new Grid();
            ScrollViewer scroll = (ScrollViewer)FindName("Genre");
            tbl_Genre[] arrGenre = (from b in BD.tbl_Genre select b).ToArray();
            string name = "";
            double marginTop = 30.0;
            for(int i = 0; i < arrGenre.Length; i++)
            {
                name = "g" + i;
                MyCheckbox myCheckbox = new MyCheckbox();
                CheckBox chk = new CheckBox();
                chk = myCheckbox.Create(arrGenre[i].GenreName.ToString(), marginTop, name);
                grid.Children.Add(chk);
                marginTop += 30;
            }
            
            scroll.Content = grid;
        }
        public void AllAuthor()
        {
            Grid grid = new Grid();
            ScrollViewer scroll = (ScrollViewer)FindName("Author");
            tbl_Author[] arrAuth = (from b in BD.tbl_Author select b).ToArray();
            string name = "";
            double marginTop = 30.0;
            for (int i = 0; i < arrAuth.Length; i++)
            {
                name = "g" + i;
                MyCheckbox myCheckbox = new MyCheckbox();
                CheckBox chk = new CheckBox();
                chk = myCheckbox.Create(arrAuth[i].AuthorName.ToString(), marginTop, name);
                grid.Children.Add(chk);
                marginTop += 30;
            }

            scroll.Content = grid;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }
        int[] checkedGenres = new int[1000];
        int[] checkedAuthors = new int[1000];
        string nameScroll1 = "Genre";
        string nameScroll2 = "Author";
        public int[] CheckAndConvert(string nameScroll1, int[] checkedNames)
        {
            ScrollViewer scrollView = FindName(nameScroll1) as ScrollViewer;
            int i = 0;

            foreach (var child in (scrollView.Content as Panel)?.Children)
            {
                if (child is CheckBox checkBox && checkBox.IsChecked == true)
                {
                    string nameWithoutFirstLetter = checkBox.Name.Substring(1); // Имя без первой буквы
                    if (int.TryParse(nameWithoutFirstLetter, out int convertedName))
                    {
                        checkedNames[i] = convertedName;
                        i++;
                    }
                }
            }

            Array.Resize(ref checkedNames, i); // Изменяем размер массива до реального количества элементов

            return checkedNames;
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            CheckAndConvert(nameScroll1, checkedGenres);
            CheckAndConvert(nameScroll2, checkedAuthors);
            MainWindow main = new MainWindow(id);
            op.SortNumb(checkedGenres, checkedAuthors);
            main.LOL.Content = op;
            main.Show();


        }
    }
}
