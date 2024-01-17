using Refit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using WebApplication1.Comments;
using WebApplication1.News;
using WpfApp2.News;

namespace WpfApp2.Comments
{
    /// <summary>
    /// Логика взаимодействия для CommentsPage.xaml
    /// </summary>
    public partial class CommentsPage : Page
    {
        private ICommentsService service;
        readonly ObservableCollection<CommentsDTO> items = new();

        private int _newsId;
        public CommentsPage(int newsId)
        {
            InitializeComponent();
            service = RestService.For<ICommentsService>("http://localhost:5221");
            commentsList.ItemsSource = items;
            _newsId = newsId;
        }
        private void CommentsChanged(object sender, EventArgs e)
        {
            var item = (CommentsDTO)sender;
            var existing = items.FirstOrDefault(n => n.Id == item.Id);
            if (existing == null)
            {
                items.Insert(0, item);

            }
            else
            {
                var index = items.IndexOf(existing);
                items.RemoveAt(index);
                items.Insert(index, item);
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.GoBack();
        }

        private void CreateBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new NewsEditPage(CommentsChanged));
        }
    }
}
