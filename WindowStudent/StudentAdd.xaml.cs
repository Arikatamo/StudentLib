using Microsoft.Win32;
using StudentBlank;
using StudentBlank.Concrette;
using StudentBlank.Controller;
using StudentBlank.Entity;
using StudentBlank.View;
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

namespace WindowStudent
{
    /// <summary>
    /// Interaction logic for StudentAdd.xaml
    /// </summary>
    public partial class StudentAdd : Window
    {
        ControllClass control;
        Epassport passport;
        EResidenc residenc;
        EStudent student;
        VRatings rating;
        Photo photo;
        public StudentAdd()
        {
            InitializeComponent();
            control = new ControllClass();
            photo = new Photo();
            Facultet.ItemsSource = control.fac.GetAll();
            Facultet.DisplayMemberPath = "Name";
            CatZarah.ItemsSource = control.cat.GetAll();
            CatZarah.DisplayMemberPath = "Name";
            FormEdu.ItemsSource = control.form.GetAll();
            FormEdu.DisplayMemberPath = "Name";
            comboSex.ItemsSource = control.sex.GetAll();
            comboSex.DisplayMemberPath = "Sex";
            Subject.ItemsSource = control.subject.GetAll();
            Subject.DisplayMemberPath = "Name";
            Rating.ItemsSource = control.rating.GetAll();
            Rating.DisplayMemberPath = "Rating";
            Finance.ItemsSource = control.finance.GetAll();
            Finance.DisplayMemberPath = "Name";
            Cvalification.ItemsSource = control.cval.GetAll();
            Finance.DisplayMemberPath = "Name";
            control.cat.Dispose();
            control.fac.Dispose();
            control.form.Dispose();
            control.rating.Dispose();
            control.sex.Dispose();
            control.subject.Dispose();
            control.finance.Dispose();
            control.cval.Dispose();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            passport = new Epassport
            {
                Number = int.Parse(txtNumber.Text),
                Serial = txtSerial.Text,
                WhenGave = txtWhenGave.Text,
                WhoGave = txtWhoGave.Text
            };
            control.passport.Add(passport);
            control.passport.Dispose();
         



            residenc = new EResidenc
            {
                Index = int.Parse(txtIndex.Text),
                NumberBuild = int.Parse(txtNumberHouse.Text),
                NumberKW = int.Parse(txtNumberKW.Text),
                Oblast = txtOblast.Text,
                Rajon = txtRajon.Text,
                Street = txtStreet.Text,
                Town = txtTown.Text

            };
            control.residence.Add(residenc);
            control.residence.Dispose();
            student = new EStudent
            {
                Age = int.Parse(txtAge.Text),
                CatZarahId = (CatZarah.SelectedItem as ECatZarah).Id,
                FacultetId = (Facultet.SelectedItem as EFacultet).Id,
                FName = txtFName.Text,
                FormEduId = (FormEdu.SelectedItem as EFormEdu).Id,
                FinImportId = (Finance.SelectedItem as EFinInport).Id,
                CvalLvlId = (Cvalification.SelectedItem as ECvalLvL).Id,
                ResidenceId = residenc.Id,
                Name = txtName.Text,
                PasportId = passport.Id,
                Pasport = passport,
                Residence = residenc,
                SexId = (comboSex.SelectedItem as ESex).Id,
                SName = txtSname.Text,
                StudY = (bool)checkStydu.IsChecked,
                Image = null,
                MobilePhone = txtMobile.Text,
                Phone = txtPhone.Text,
                Ratings = null,
                Blanks = null,
                Email = txtEmail.Text,
            };
            control.stud.Add(student);
            btnAddPhoto.IsEnabled = true;
            AddRatings.IsEnabled = true;
            RemoveRating.IsEnabled = true;
            Add.IsEnabled = false;
            
            
        }

        private void btnAddPhoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Image|*.jpg|*.jpeg|";
            openFileDialog1.Title = "Виберете фото";
            if (openFileDialog1.ShowDialog() == true)
            {
                BitmapImage bi3 = new BitmapImage();
                bi3.BeginInit();
                bi3.UriSource = new Uri(openFileDialog1.FileName);
                bi3.EndInit();
                ImageS.Source = bi3;
                student.Image = photo.ImageToByte(photo.BitmapImage2Bitmap(bi3));
                control.stud.Save();
            }
        }

        private void AddRatings_Click(object sender, RoutedEventArgs e)
        {

            if (Subject.SelectedItem != null && Rating.SelectedItem != null)
            {
                rating = new ERatings
                {
                    Rating = Rating.SelectedItem as ERating,
                    RatingId =(Rating.SelectedItem as ERating).Id,
                    SubjectId = (Subject.SelectedItem as ESubject).Id,
                    Subject = Subject.SelectedItem as ESubject
                };
                Subjects.Items.Add(rating);
                control.Ratings.Add(new ERatings
                {
                    RatingId = rating.RatingId,
                    SubjectId = rating.SubjectId,
                    StudentId = student.Id
                }
                );
            }
        }

        private void RemoveRating_Click(object sender, RoutedEventArgs e)
        {
            if (Subjects.SelectedIndex >= 0)
            {
                int ind = Subjects.SelectedIndex;
                Subjects.Items.RemoveAt(ind);
                control.Ratings.Delete(control.Ratings.GetAll().FirstOrDefault(x => x.Id == (Subjects.SelectedItem as ERatings).Id));

            }
        }
    }
}
