using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public class LabelCreator
    {
        public Label CreateLabel(string content, string name, int margin, int left, int top, int right)
        {

            Label label = new Label();
            label.Content = content;
            label.Name = name;
            label.Margin = new Thickness(left, margin, 0, 0);
            return label;

        }
    }

    public partial class Page1 : Page
    {
        public Page1(int name1)
        {
            InitializeComponent();
            this.name1 = name1;
            OplFalse();
            OplTrue();
            LastBook();
            Counter();
            ImgForLast();
        }
        private int name1;
        private DataClasses1DataContext BD = new DataClasses1DataContext();
        int IDBook = 0;
        public void OplFalse()
        {
            Grid grid = (Grid)FindName("TrueOpl");
            string nameB = "b";
            string nameA = "a";
            string nameG = "g";
            tbl_OrderTY[] arr = (from b in BD.tbl_OrderTY select b).ToArray();
            tbl_Books[] arrBook = (from b in BD.tbl_Books select b).ToArray();
            int row = 40;
            int row2 = 25;
            int j = 0;
            int newI = 1;
            int allPrise = 0;
            int stertPrise = 0;
            int bookPrise = 0;
            
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].Oplacheno == false)
                {
                    if (name1 == (int)arr[i].UserID)
                    {
                        
                        LabelCreator label = new LabelCreator();
                        nameB = nameB + i;
                        nameA = nameA + i;
                        nameG = nameG + i;

                        j = (int)arr[i].BookID - 1;
                        Label lbl = new Label();
                        lbl = label.CreateLabel(newI + ". " + arrBook[j].Title.ToString(), nameB, row, 0, 0, 0);
                        grid.Children.Add(lbl);
                        Label lbl4 = new Label();
                        lbl4 = label.CreateLabel(arrBook[j].Prise.ToString() + "+" + arrBook[j].PriseStart.ToString(), nameG, row, 180, 0, 0);
                        grid.Children.Add(lbl4);

                        allPrise += arrBook[j].Prise + arrBook[j].PriseStart;
                        stertPrise += arrBook[j].PriseStart;
                        bookPrise += arrBook[j].Prise;

                        lbl.FontWeight = FontWeights.Bold;
                        

                        row += 40;
                        row2 += 25;
                        newI++;
                    }

                }
                
            }
        }
        public void OplTrue()
        {
            Grid grid = (Grid)FindName("FalseOpl");
            string nameB = "b";
            string nameA = "a";
            string nameG = "g";
            tbl_OrderTY[] arr = (from b in BD.tbl_OrderTY select b).ToArray();
            tbl_Books[] arrBook = (from b in BD.tbl_Books select b).ToArray();
            int row = 40;
            int row2 = 25;
            int j = 0;
            int newI = 1;
            int allPrise = 0;
            int stertPrise = 0;
            int bookPrise = 0;
            DateTime dat = new DateTime();
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].Oplacheno == true)
                {
                    if (name1 == (int)arr[i].UserID)
                    {
                        dat = arr[i].DataOrder;
                        LabelCreator label = new LabelCreator();
                        nameB = nameB + i;
                        nameA = nameA + i;
                        nameG = nameG + i;

                        j = (int)arr[i].BookID - 1;
                        Label lbl = new Label();
                        lbl = label.CreateLabel(newI + ". " + arrBook[j].Title.ToString(), nameB, row, 0, 0, 0);
                        grid.Children.Add(lbl);
                        Label lbl4 = new Label();
                        lbl4 = label.CreateLabel(arrBook[j].Prise.ToString() + "+" + arrBook[j].PriseStart.ToString(), nameG, row, 180, 0, 0);
                        grid.Children.Add(lbl4);

                        allPrise += arrBook[j].Prise + arrBook[j].PriseStart;
                        stertPrise += arrBook[j].PriseStart;
                        bookPrise += arrBook[j].Prise;

                        lbl.FontWeight = FontWeights.Bold;


                        row += 40;
                        row2 += 25;
                        newI++;
                    }
                }

            }
            dat = dat.AddDays(30);
            LabelCreator label6 = new LabelCreator();
            Label lbl666 = new Label();
            lbl666 = label6.CreateLabel("Крайний срок сдачи\nвсех книг: " + dat.ToLongDateString(), nameG, row + 20, 10, 0, 0);
            DateTime newData = new DateTime();
            newData = dat;
            newData = newData.AddDays(-10);
            if (DateTime.Today >= newData)
            {
                lbl666.Foreground = Brushes.Red;
                lbl666.FontWeight = FontWeights.Bold;
            }
            grid.Children.Add(lbl666);
        }
        public void LastBook()
        {
            Grid grid = (Grid)FindName("Pagers");
            tbl_OrderTY[] arr = (from b in BD.tbl_OrderTY select b).ToArray();
            tbl_Books[] arrBook = (from b in BD.tbl_Books select b).ToArray();
            Label[] label = new Label[1000];
            int g = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].UserID == name1)
                {
                    foreach (FrameworkElement txt in grid.Children)
                    {

                        if (txt is Label)
                        {
                            if (txt.Name.StartsWith("q", StringComparison.OrdinalIgnoreCase))
                            {
                                if (arr[i].Oplacheno == true)
                                {
                                    label[i] = (Label)txt;
                                    g = (int)arr[i].BookID;
                                    label[i].Content = arrBook[g - 1].Title.ToString();
                                }

                            }
                            if (txt.Name.StartsWith("w", StringComparison.OrdinalIgnoreCase))
                            {
                                if (arr[i].Oplacheno == true)
                                {
                                    label[i] = (Label)txt;
                                    g = (int)arr[i].BookID;
                                    label[i].Content = arrBook[g-1].tbl_Author.AuthorName.ToString();
                                }

                            }
                            if (txt.Name.StartsWith("e", StringComparison.OrdinalIgnoreCase))
                            {
                                if (arr[i].Oplacheno == true)
                                {
                                    label[i] = (Label)txt;
                                    g = (int)arr[i].BookID;
                                    label[i].Content = arrBook[g-1].tbl_Genre.GenreName.ToString();
                                }

                            }
                            IDBook = (int)arr[i].BookID;
                        }
                    }
                }
            }

        }
        public void Counter()
        {
            tbl_OrderTY[] arr = (from b in BD.tbl_OrderTY select b).ToArray();
            int count = 0;
            foreach (var a in arr)
            {
                if(a.Oplacheno == true && name1 == a.UserID)
                {
                    count++;
                }
            }
            counter.Content += count.ToString();
        }
        
        public void ImgForLast()
        {
           
            try
            {
                tbl_Books[] arrBook = (from b in BD.tbl_Books select b).ToArray();
                Grid grid = (Grid)FindName("Pagers");
                int imageIndex = 0;
                var book = arrBook[IDBook+1];
                
                string imagePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "img", book.tbl_Img.ImageName + ".jpg"); // Assuming 'ImageFileName' is the column in your database containing image file names

                if (File.Exists(imagePath))
                {
                    BitmapImage bitmapImage = new BitmapImage(new Uri(imagePath));
                    Image image = grid.Children.OfType<Image>().ElementAtOrDefault(imageIndex);

                    if (image != null)
                    {
                        image.Source = bitmapImage;
                    }
                    else
                    {
                        MessageBox.Show($"Not enough Image elements on the page for the book: {book.Title}");
                    }

                    imageIndex++;
                }
                else
                {
                    MessageBox.Show($"Image file not found for the book: {book.Title}");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading images: {ex.Message}");
            }
        }
        
    }
}
