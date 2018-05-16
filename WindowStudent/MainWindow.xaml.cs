using MahApps.Metro.Controls;
using StudentBlank;
using StudentBlank.Controller;
using StudentBlank.Entity;
using StudentBlank.View;
using System;
using System.Collections.Generic;
using System.Drawing;
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

namespace WindowStudent
{
    //Для роботи програми(генерації документа), потрібно щоб був встановлений Microsoft Word
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public Student student = new Student();
        IList<EStudent> eStudent;
        Photo photo = new Photo();
        public MainWindow()
        {
            InitializeComponent();
            eStudent = student.GetAll(); 
            StudentGrid.ItemsSource = eStudent;
        }

        private void StudentGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (StudentGrid.SelectedItem != null && StudentGrid.SelectedIndex <= StudentGrid.Items.Count)
            {
                VStudent temp = new VStudent(StudentGrid.SelectedItem as EStudent);
                StackData.DataContext = temp;
                StackPassport.DataContext = temp.Pasport;
                Subjects.ItemsSource = temp.Ratings;
                StakREsidence.DataContext = temp.Residence;
                BitmapImage bit = new BitmapImage();
            
                if (temp.Image != null)
                {
                    bit.BeginInit();
                    bit.StreamSource = photo.MemoryStream(temp.Image);
                    bit.EndInit();
                    ImageS.Stretch = Stretch.Fill;
                    ImageS.Source = bit;
                }
                else
                {
                    bit.UriSource = new Uri(@"C:\Users\Arikatamo\source\repos\StudentBlank\WindowStudent\no-image.png");
                }
   
                //Добавлення фото в базу
                //(StudentGrid.SelectedItem as EStudent).Image = photo.ImageToByte(photo.BitmapImage2Bitmap(bit));
                //student.Save();

            }


        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            StudentAdd window = new StudentAdd();
            window.DataContext = student;
            window.Owner = this;
            window.ShowDialog();
            if (window.DialogResult == true)
            {
                StudentGrid.ItemsSource = student.GetAll();
                StudentGrid.Items.Refresh();
            }
        }

        private void btnGenerateDoc_Click(object sender, RoutedEventArgs e)
        {
            //Генерування ДОкументу, поки один(неповний) C:\Users\Arikatamo\source\repos\StudentBlank\WindowStudent\bin\Debug + папка студента
            EStudent temp = StudentGrid.SelectedItem as EStudent;
            DirectoryInfo dir = new DirectoryInfo(Directory.GetCurrentDirectory());
            if (Directory.Exists(dir.FullName + @"\" + temp.Id + "_Student") != true)
            {
                Directory.CreateDirectory(dir.FullName + @"\"+ temp.Id + "_" + temp.Name + "_" + temp.SName);
                DocumentFirst.CreateDocument(dir.FullName + @"\" + temp.Id + "_" + temp.Name + "_" + temp.SName, StudentGrid.SelectedItem as EStudent);
            }
        }
    }
}
