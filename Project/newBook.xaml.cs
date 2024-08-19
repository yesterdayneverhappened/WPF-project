using Microsoft.Win32;
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
using Path = System.IO.Path;

namespace Курсач
{
    /// <summary>
    /// Логика взаимодействия для newBook.xaml
    /// </summary>
    public partial class newBook : Page
    {
        public newBook()
        {
            InitializeComponent();
            allAuth();
            allGenre();
        }
        private DataClasses1DataContext BD = new DataClasses1DataContext();
        int selectedAuthorId;
        int selectedGenreId;
        public void allAuth()
        {
            tbl_Author[] arr = (from b in BD.tbl_Author select b).ToArray();

            foreach (var a in arr)
            {
                author.Items.Add(a.AuthorName);
            }
        }
        private void author_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Получаем выбранный автор
            string selectedAuthorName = author.SelectedItem.ToString();

            // Находим автора в базе данных по имени
            tbl_Author selectedAuthor = BD.tbl_Author.FirstOrDefault(a => a.AuthorName == selectedAuthorName);

            if (selectedAuthor != null)
            {
                // Если автор найден, сохраняем его ID в глобальной переменной
                selectedAuthorId = selectedAuthor.AuthorID;
            }
            else
            {
                // Если автор не найден, сбрасываем значение ID
                selectedAuthorId = -1;
            }
        }
        public void allGenre()
        {
            tbl_Genre[] arr = (from b in BD.tbl_Genre select b).ToArray();

            foreach (var a in arr)
            {
                genre.Items.Add(a.GenreName);
            }
        }
        private void genre_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Получаем выбранный жанр
            string selectedGenreName = genre.SelectedItem.ToString();

            // Находим жанр в базе данных по имени
            tbl_Genre selectedGenre = BD.tbl_Genre.FirstOrDefault(g => g.GenreName == selectedGenreName);

            if (selectedGenre != null)
            {
                // Если жанр найден, сохраняем его ID в глобальной переменной
                selectedGenreId = selectedGenre.GenreID;
            }
            else
            {
                // Если жанр не найден, сбрасываем значение ID
                selectedGenreId = -1;
            }
        }
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            UpdateAuthState();
        }
        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            UpdateAuthState();
        }
       

        private void UpdateAuthState()
        {
            if (AuthCheck.IsChecked == true)
            {
                AuthTextBox.IsEnabled = true;
                author.IsEnabled = false;
            }
            else
            {
                AuthTextBox.IsEnabled = false;
                author.IsEnabled = true;
            }
        }
        private void UpadateGenreState()
        {
            if (GenreCheck.IsChecked == false)
            {
                genreTextBox.IsEnabled = false;
                genre.IsEnabled = true;
            }
            else { genreTextBox.IsEnabled = true; genre.IsEnabled = false; }
        }
        private void CheckBox_Checked_1(object sender, RoutedEventArgs e)
        {
            UpadateGenreState();
        }
        string fileName;
        private void GenreCheck_Unchecked(object sender, RoutedEventArgs e)
        {
            UpadateGenreState();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg; *.png; *.bmp)|*.jpg; *.png; *.bmp";

            if (openFileDialog.ShowDialog() == true)
            {
                string selectedImagePath = openFileDialog.FileName;

                string targetDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "img");

                try
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.UriSource = new Uri(selectedImagePath);
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImage.EndInit();

                    // Устанавливаем изображение в элемент управления Image
                    image.Source = bitmapImage;

                    Directory.CreateDirectory(targetDirectory);

                    // Генерируем новое имя файла
                    string newFileName = $"{DateTime.Now:yyyyMMddHHmmss}_{Path.GetFileName(selectedImagePath)}";
                    string newFilePath = Path.Combine(targetDirectory, newFileName);

                    // Считываем содержимое файла в байтовый массив
                    byte[] imageData = File.ReadAllBytes(selectedImagePath);

                    // Создаем новый файл и записываем в него содержимое
                    File.WriteAllBytes(newFilePath, imageData);

                    // Присваиваем значение переменной fileName
                    fileName = Path.GetFileNameWithoutExtension(selectedImagePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при перемещении изображения: {ex.Message}");
                }
            }
        
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int price;
            int priseStart;

            tbl_Books tbl_Books = new tbl_Books();
            tbl_Img tbl_Img = new tbl_Img();
            tbl_Author tbl_Author = new tbl_Author();
            tbl_Genre tbl_Genre = new tbl_Genre();

            tbl_Img[] arr = (from b in BD.tbl_Img select b).ToArray();

            tbl_Books.Title = nameOfBook.Text;
            /// УСЛОВИЯ
            if (selectedAuthorId != -1) // УСЛОВИЯ НА АВТОРА
                tbl_Books.AuthorID = selectedAuthorId+1;
            else if (author.Text!="" || author.Text!=null)
            {
                tbl_Author.AuthorName = author.Text;
                BD.tbl_Author.InsertOnSubmit(tbl_Author);
                BD.SubmitChanges();
            }
            tbl_Author[] arrAuth = (from b in BD.tbl_Author select b).ToArray();
            tbl_Books.AuthorID = arrAuth.Last().AuthorID;

            if (selectedGenreId != -1) // УСЛОВИЯ НА ЖАРНЫ
                tbl_Books.GenreID = selectedGenreId+1;
            else if(genre.Text!="" || genre.Text!=null)
            {
                tbl_Genre.GenreName = genre.Text;
                BD.tbl_Genre.InsertOnSubmit(tbl_Genre);
                BD.SubmitChanges();
            }
            tbl_Genre[] arrGenre = (from b in BD.tbl_Genre select b).ToArray();
            tbl_Books.GenreID = arrGenre.Last().GenreID;

            if (int.TryParse(priseOfBook.Text, out price))
            {
                tbl_Books.Prise = price; // Сохраняем целочисленное значение в переменную tbl_Books.Prise
            }
            else {
                //////
            }
            tbl_Img.ImageName = fileName;
            BD.tbl_Img.InsertOnSubmit(tbl_Img);
            BD.SubmitChanges();
            if (int.TryParse(zalogPrise.Text, out priseStart))
            {
                tbl_Books.PriseStart = priseStart; // Сохраняем целочисленное значение в переменную tbl_Books.Prise
            }
            tbl_Img[] arr2 = (from b in BD.tbl_Img select b).ToArray();
            tbl_Books.ImageID = arr2.Last().ImageID;
            BD.tbl_Books.InsertOnSubmit(tbl_Books);
            try
            {
                BD.SubmitChanges();
                MessageBox.Show("Книга добавлена");
            }
            catch (Exception exx)
            {
                MessageBox.Show("Ошибочка" + exx);
            }
            
        }

        
    }
}
