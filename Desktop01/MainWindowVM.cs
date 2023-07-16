using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Desktop01.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Desktop01
{
    public  partial class MainWindowVM : ObservableObject
    {
        [ObservableProperty]
        public  ObservableCollection<User> users;

        [ObservableProperty]
        public User selectedUser=null;

        public void CloseMainWindow()
        {
            Application.Current.MainWindow.Close();
        }

        [RelayCommand]
        public void messeag()
        {
            MessageBox.Show($"{selectedUser.FirstName}'s GPA value is not valid. It must be between 0 and 4.", "Error!");
        }

        [RelayCommand]
        public void AddStudent()
        {
            var vm = new AddUserVM();
            vm.title = "ADD USER";
            AddUserWindow window = new AddUserWindow(vm);
            window.ShowDialog();
            if (vm.Student.FirstName != null)
            {
                users.Add(vm.Student);
            }
        }

        [RelayCommand]
        public void Delete()
        {
            if (selectedUser != null)
            {
                string name = selectedUser.FirstName;
                users.Remove(selectedUser);
                MessageBox.Show($"{name}'s data are successfuly deleted!", "Deleting Student Data");               
            }
            else
            {
                MessageBox.Show("Before you delete student data, please select the student.", "Warning!");
            }
        }

        [RelayCommand]
        public void ExecuteEditStudentCommand()
        {
            if (selectedUser != null)
            {
                var vm = new AddUserVM(selectedUser);
                vm.title = "EDIT USER";
                var window = new AddUserWindow(vm);
                window.ShowDialog();
                int index = users.IndexOf(selectedUser);
                users.RemoveAt(index);
                users.Insert(index, vm.Student);
            }
            else
            {
                MessageBox.Show("Before you edit student data, please select the relevant student.", "Warning!");
            }
        }

        public  MainWindowVM()
        {
            users = new ObservableCollection<User>();
            BitmapImage image1 = new BitmapImage(new Uri("/Model/Images/1.png", UriKind.Relative));
            users.Add(new User(23, "Malith", "Aberuwan", "07/10/2000",image1,3.8));
            BitmapImage image2 = new BitmapImage(new Uri("/Model/Images/2.png", UriKind.Relative));
            users.Add(new User(22, "Shanilka", "Manchanayaka", "09/02/2001",image2,3.2));
            BitmapImage image3 = new BitmapImage(new Uri("/Model/Images/4.png", UriKind.Relative));
            users.Add(new User(25, "Madhushani", "Rajapaksha", "20/06/1998",image3,2.2));
            BitmapImage image4= new BitmapImage(new Uri("/Model/Images/3.png", UriKind.Relative));
            users.Add(new User(24, "Kushan", "Jayarathna", "11/11/1999", image4,2.8));
            BitmapImage image5 = new BitmapImage(new Uri("/Model/Images/5.png", UriKind.Relative));
            users.Add(new User(23, "Sithum", "Nimesh", "29/03/2000", image5,3.2));
        }
    }
}
