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
using Windows.System;
using WpfApp2.Sessions;
using WebApplication1.Users;

namespace WpfApp2.Users
{
    /// <summary>
    /// Логика взаимодействия для ChangePage.xaml
    /// </summary>
    public partial class ChangePage : Page
    {
        private UserDTO user;
        public ChangePage()
        {
            InitializeComponent();
            SetProfile();
        }

        private void SetProfile()
        {

            Task.Run(async () =>
            {
                try
                {
                    var service = NetworkManager.Instance.AuthService;
                    var response = await service.Profile();
                    await Dispatcher.BeginInvoke(() =>
                    {
                        if (response == null)
                        {

                        }
                        else
                        {
                            user = response.User;
                            familyTb.Text = user.Family;
                            nameTb.Text = user.Name;
                            patronymicTb.Text = user.Patronymic;
                            emailTb.Text = user.Email;
                        }
                    });
                }
                catch (Exception ex)
                {
                    await Dispatcher.BeginInvoke(() =>
                    {

                    });
                }
                finally
                {
                    await Dispatcher.BeginInvoke(() =>
                    {

                    });
                }
            });
        }

        private void Change()
        {
            string email = emailTb.Text;
            string pass = passTb.Password;
            string name = nameTb.Text;
            string family = familyTb.Text;
            string patronymic = patronymicTb.Text;
            string repeat = repeatTb.Text;
            Task.Run(async () =>
            {
                try
                {
                    var result = await AuthManager.Instance.Register(email, pass, name, family, patronymic);

                    await Dispatcher.BeginInvoke(() =>
                    {
                        if (result)
                        {
                            NavigationService?.GoBack();
                        }
                        else
                        {
                            MessageBox.Show("Не удалось зарегистрироваться. Проверьте корректность введенных данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            });
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
