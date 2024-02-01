using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace A11y
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<MyItem> MyItemCollection { get; set; }
        private CollectionView _myView;
        public MainWindow()
        {
            InitializeComponent();

            // Initialize and populate YourCollection with MyItem instances
            MyItemCollection = new ObservableCollection<MyItem>
        {
            new MyItem { Name = "Item1" , Type = "A"  },
            new MyItem { Name = "Item2" , Type = "B" },
            new MyItem { Name = "Item3" , Type = "A" , IsVisible = false },
            new MyItem { Name = "Item4" , Type = "A" },
            new MyItem { Name = "Item5" , Type = "B" },

        };

            // Set the DataContext to enable data binding
            DataContext = this;
        }

        //CASE 4
        private void AddGrouping(object sender, RoutedEventArgs e)
        {
            _myView = (CollectionView)CollectionViewSource.GetDefaultView(myItemsControl.ItemsSource);
            if (_myView.CanGroup)
            {
                var groupDescription
                    = new PropertyGroupDescription("Type");
                _myView.GroupDescriptions.Add(groupDescription);
            }
        }

        //CASE 4
        private void RemoveGrouping(object sender, RoutedEventArgs e)
        {
            _myView = (CollectionView)CollectionViewSource.GetDefaultView(myItemsControl.ItemsSource);
            _myView.GroupDescriptions.Clear();
        }
    }
    public class MyItem
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public bool IsVisible { get; set; } = true;
    }
}