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

namespace fre_librarysystem
{
    /// <summary>
    /// Interaktionslogik für MainUserUI.xaml
    /// </summary>
    public partial class MainUserUI : Window
    {
        public MainUserUI()
        {
            InitializeComponent();

            ControllerBook C_ControllerBook = new ControllerBook();

            var books = C_ControllerBook.getBooks("All");

            dtagrdBooks.ItemsSource = books;
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string searchString = txtSearch.Text;

            ControllerBook C_ControllerBook = new ControllerBook();

            var filteredBooks = C_ControllerBook.getBooks(searchString);

            dtagrdBooks.ItemsSource = filteredBooks;
        }
    }
}
