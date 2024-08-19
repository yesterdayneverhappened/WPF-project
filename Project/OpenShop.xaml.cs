using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Data.SqlTypes;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Курсач
{
    /// <summary>
    /// Логика взаимодействия для OpenShop.xaml
    /// </summary>
    
    public class Book
    {
        
        public IComparable comparable;
        public int Id { get;set; }
        public string Title { get;set; } 
        public string Author { get;set; }
        public string Genre { get;set; }
        public int Prise { get;set; }
        public int PriseStart { get; set; }
        public string Image { get; set; }

        public Book(int id, string title, string author, string genre, int prise, int priseStart, string image)
        {
            Id = id;
            Title = title;
            Author = author;
            Genre = genre;
            Prise = prise;
            PriseStart = priseStart;
            Image = image;
        }
        public Book() { }
    }
    
    public partial class OpenShop : Page
    {
        List<Book> books = new List<Book>();
        public void AddToList()
        {
            tbl_Books[] arr = (from b in BD.tbl_Books select b).ToArray();
            for (int i = 0; i < arr.Length; i++)
            {
                Book a = new Book(arr[i].BookID, arr[i].Title.ToString(), arr[i].AuthorID.ToString(), arr[i].GenreID.ToString(), arr[i].Prise, arr[i].PriseStart, arr[i].ImageID.ToString());
                books.Add(a);
            }
        }
        public OpenShop(int UsId)
        { 
            this.UsId = UsId; 
            InitializeComponent();
            AddToList();
            Book(iQ1, books);
            Author(iQ, books);
            Genre(iQ2, books);
            Prise(iQ3, books);

            LoadImagesFromFolder(imageIndex, books);
        }
        
        int UsId;
        private DataClasses1DataContext BD = new DataClasses1DataContext();

        Label[] label = new Label[1000];

        int countInBusket;
        private int AddBookId;
        int iQ1 = 0;
       
       
        public void Book(int iQ1, List<Book> books)
        {
            tbl_Books[] arr = (from b in BD.tbl_Books select b).ToArray();
            Label[] author = new Label[1000];
            
            foreach (FrameworkElement txt in (scroll.Content as Panel)?.Children)
            {

                if (txt is Label)
                {
                    if (txt.Name.StartsWith("b", StringComparison.OrdinalIgnoreCase))
                    {
                        if (iQ1 < arr.Length)
                        {
                            label[iQ1] = (Label)txt;
                            
                            label[iQ1].Content = books[iQ1].Title.ToString();
                            iQ1++;
                        }

                    }
                }
            }
            iQ1 = 0;

        }
        int iQ = 0;
        public void Author(int iQ, List<Book> books)
        {
            tbl_Books[] arr = (from b in BD.tbl_Books select b).ToArray();

            Label[] label = new Label[1000];

            
            foreach (FrameworkElement txt in (scroll.Content as Panel)?.Children)
            {

                if (txt is Label)
                {
                    if (txt.Name.StartsWith("a", StringComparison.OrdinalIgnoreCase))
                    {
                        if (iQ < arr.Length)
                        {
                            label[iQ] = (Label)txt;
                            if (books[iQ].Author == arr[iQ].AuthorID.ToString())
                            {
                                label[iQ].Content = "Автор: " + arr[iQ].tbl_Author.AuthorName.ToString();
                                iQ++;
                            }
                            
                        }
                    }

                }
            }
            iQ = 0;
        }
        int iQ2 = 0;
        public void Genre(int iQ2, List<Book> books)
        {
            tbl_Books[] arr = (from b in BD.tbl_Books select b).ToArray();

            Label[] label = new Label[1000];
            
            foreach (FrameworkElement txt in (scroll.Content as Panel)?.Children)
            {

                if (txt is Label)
                {
                    if (txt.Name.StartsWith("g", StringComparison.OrdinalIgnoreCase))
                    {
                        if (iQ2 < arr.Length)
                        {
                            label[iQ2] = (Label)txt;
                            if (books[iQ2].Genre == arr[iQ2].GenreID.ToString())
                            {
                                label[iQ2].Content = "Жанр: " + arr[iQ2].tbl_Genre.GenreName.ToString();
                                iQ2++;
                            }
                        }
                    }

                }
            }
            iQ2 = 0;
        }
        int iQ3 = 0;
        public void Prise(int iQ3, List<Book> books)
        {
            tbl_Books[] arr = (from b in BD.tbl_Books select b).ToArray();

            Label[] label = new Label[1000];

            foreach (FrameworkElement txt in (scroll.Content as Panel)?.Children)
            {

                if (txt is Label)
                {
                    if (txt.Name.StartsWith("p", StringComparison.OrdinalIgnoreCase))
                    {
                        if (iQ3 < arr.Length)
                        {
                            label[iQ3] = (Label)txt;
                            if (books[iQ3].Id == arr[iQ3].BookID)
                            {
                                label[iQ3].Content = "Цена: " + arr[iQ3].Prise.ToString();
                                iQ3++;
                            }
                           
                        }
                    }

                }
            }
            iQ3 = 0;
        }
        int imageIndex = 0;
        private void LoadImagesFromFolder(int imageIndex, List<Book> books)
        {
            try
            {
                tbl_Books[] arrBook = (from b in BD.tbl_Books select b).ToArray();
                Grid grid = (Grid)FindName("GRIIIDE");
                int newIndex = 0;

                for (int book = imageIndex; book < arrBook.Length; book++)
                {
                    for (int book2 = 0; book2 < books.Count; book2++)
                    {
                        if (arrBook[book].BookID == books[book2].Id)
                        {
                            string imagePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "img", arrBook[book].tbl_Img.ImageName + ".jpg");
                            string[] path = new string[1000];
                            path[book] = imagePath;

                            if (File.Exists(imagePath))
                            {
                                BitmapImage bitmapImage = new BitmapImage(new Uri(imagePath));
                                Image image = grid.Children.OfType<Image>().ElementAtOrDefault(newIndex);

                                if (image != null)
                                {
                                    image.Source = bitmapImage;
                                }
                                else
                                {
                                    MessageBox.Show($"Not enough Image elements on the page for the book: {arrBook[book].Title}");
                                    // Сбросить индексы и начать заново

                                    book = -1; // -1, чтобы следующая итерация установила book на 0
                                }
                                newIndex++;
                                imageIndex++;
                            }
                            else
                            {
                                MessageBox.Show($"Image file not found for the book: {arrBook[book].Title}");
                            }
                        }
                    }

                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading images: {ex.Message}");
            }
        }

        public void SortNumb(int[] genre, int[] author)
        {
            List<Book> books2 = new List<Book>(books);
            //books = (List<Book>)(from p in books orderby p.Prise select p);
            //books2.Sort((book1, book2) => book1.Prise.CompareTo(book2.Prise));
            BySort(iQ1, books2, genre, author);
            LoadImagesFromFolder(imageIndex, books2);
        }
        public void BySort(int iQ1, List<Book> books, int[] genre, int[] author2)
        {
            tbl_Books[] arr = (from b in BD.tbl_Books select b).ToArray();
            tbl_Genre[] arrGenre = (from b in BD.tbl_Genre select b).ToArray();
            tbl_Author[] arrAuth = (from b in BD.tbl_Author select b).ToArray();
            Label[] author = new Label[1000];
            int j = 0;
            int k = 0;
            int l = 0;
            int g = 0;
            int a = 0;

            foreach (FrameworkElement txt in (scroll.Content as Panel)?.Children)
            {
                if (txt is Label)
                {
                    if (g < arrGenre.Length && a < arrAuth.Length)
                    {
                        if (genre[iQ1] == arr[g].tbl_Genre.GenreID && author2[iQ1] == arrAuth[a].AuthorID)
                        {
                            

                                if (txt.Name.StartsWith("b", StringComparison.OrdinalIgnoreCase))
                                {
                                    if (iQ1 < arr.Length)
                                    {
                                        label[iQ1] = (Label)txt;
                                        label[iQ1].Content = books[iQ1].Title.ToString();
                                        iQ1++;
                                    }
                                }
                                else if (txt.Name.StartsWith("a", StringComparison.OrdinalIgnoreCase))
                                {
                                    if (iQ < arr.Length)
                                    {
                                        label[iQ] = (Label)txt;
                                        if (books[iQ].Author == arr[iQ].AuthorID.ToString())
                                        {
                                            label[iQ].Content = "Автор: " + arr[j].tbl_Author.AuthorName.ToString();
                                            j++;
                                        }
                                    }
                                }
                                else if (txt.Name.StartsWith("g", StringComparison.OrdinalIgnoreCase))
                                {
                                    if (iQ2 < arr.Length)
                                    {
                                        label[iQ2] = (Label)txt;
                                        if (books[iQ2].Genre == arr[iQ2].GenreID.ToString())
                                        {
                                            label[iQ2].Content = "Жанр: " + arr[k].tbl_Genre.GenreName.ToString();
                                            k++;
                                        }
                                    }
                                }
                                else if (txt.Name.StartsWith("p", StringComparison.OrdinalIgnoreCase))
                                {
                                    if (iQ3 < arr.Length)
                                    {
                                        label[iQ3] = (Label)txt;
                                        if (books[iQ3].Id == arr[iQ3].BookID)
                                        {
                                            label[iQ3].Content = "Цена: " + arr[l].Prise.ToString();
                                            l++;
                                        }
                                    }
                                }
                                
                            }
                           
                        }
                        g++;
                        a++;
                    }
                    else if (a >= arrAuth.Length)
                    {
                        a = 0;
                    }
                    else if (g >= arrGenre.Length)
                    {
                        g = 0;
                    }

                    
                
            }

            iQ1 = 0;
        }
        public void BookIsBook()
        {
            tbl_Books[] arr = (from b in BD.tbl_Books select b).ToArray();
            List<Book> books = new List<Book>();
            for(int i = 0; i < arr.Length; i++)
            {
                Book book = new Book();
                book.Id = arr[i].BookID;
                book.Author = arr[i].AuthorID.ToString();
                book.Genre = arr[i].GenreID.ToString();
                book.Prise = arr[i].Prise;
                book.PriseStart = arr[i].PriseStart;
                books.Add(book);
            }
        }

        public void AddToBusket()
        {
            tbl_Books[] arr = (from b in BD.tbl_Books select b).ToArray();
            tbl_OrderTY tbl_OrderTY = new tbl_OrderTY();
            tbl_OrderTY.BookID = AddBookId-1;
            tbl_OrderTY.UserID = UsId;
            tbl_OrderTY.PriseAll = arr[AddBookId-1].Prise + arr[AddBookId-1].PriseStart;
            tbl_OrderTY.Oplacheno = false;
            tbl_OrderTY.DataOrder = DateTime.Now;
            BD.tbl_OrderTY.InsertOnSubmit(tbl_OrderTY);
            BD.SubmitChanges();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            countInBusket++;
            AddBookId = 2 + str * 12;
            AddToBusket();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            countInBusket++;

            AddBookId = 3 + str * 12;
            AddToBusket();
            
               
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            countInBusket++;
            AddBookId = 4 + str * 12;
            AddToBusket();
            
                
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            countInBusket++;

            AddBookId = 5 + str * 12;
            AddToBusket();
            
                
        }
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            countInBusket++;
            AddBookId = 6 + str * 12;
            AddToBusket();
            
                
        }
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            countInBusket++;
            AddBookId = 7 + str * 12;
            AddToBusket();
            
        }
                
        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            countInBusket++;
            AddBookId = 8 + str * 12;
            AddToBusket();
        }
        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            countInBusket++;
            AddBookId = 9 + str * 12;
            AddToBusket();
                
        }
        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            countInBusket++;
            AddBookId = 10 + str * 12;
            AddToBusket();
        }
        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            countInBusket++;
            AddBookId = 11 + str * 12;
            AddToBusket();
                
        }
        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
            countInBusket++;
            AddBookId = 12 + str * 12;

        }
        private void Button_Click_12(object sender, RoutedEventArgs e)
        {
            countInBusket++;
            AddBookId = 13 + str * 12;
            AddToBusket();
        }
        
        int str = 0;
        int newI = 0;
        
       

        private void Button_Click_R(object sender, RoutedEventArgs e)
        {
            tbl_Books[] arrBook = (from b in BD.tbl_Books select b).ToArray();
            str++;
            if(newI <= arrBook.Length)
            {
                newI += 9;
                Book(newI, books);
                Author(newI, books);
                Genre(newI, books);
                Prise(newI, books);
                LoadImagesFromFolder(newI, books);
            }

            
        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            countInBusket++;
            AddBookId = 11 + str * 12;
            AddToBusket();
        }

        private void Button_Click_13(object sender, RoutedEventArgs e)
        {
            countInBusket++;
            AddBookId = 14 + str * 12;
            AddToBusket();
        }

        private void Button_Click_14(object sender, RoutedEventArgs e)
        {
            countInBusket++;
            AddBookId = 15 + str * 12;
            AddToBusket();
        }

        private void Button_Click_15(object sender, RoutedEventArgs e)
        {
            countInBusket++;
            AddBookId = 16 + str * 12;
            AddToBusket();
        }
    }
}
