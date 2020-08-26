using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
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
        string loggedinuser;
        public MainUserUI(string t_username_loggedinuser)
        {
            InitializeComponent();

            loggedinuser = t_username_loggedinuser;

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

        private void dtagrdBooks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnReserve.IsEnabled = true;
        }

        private void btnReserve_Click(object sender, RoutedEventArgs e)
        {
            ModelObjBook selectedRow = (ModelObjBook)dtagrdBooks.SelectedItem;

            int selectedPKey = selectedRow.pkey;

            ControllerBook C_ControllerBook = new ControllerBook();
            
            bool bookAvaiable = C_ControllerBook.bookAvaiable(selectedPKey);

            if (bookAvaiable == true)
            {
                
            } else
            {
                MessageBox.Show("Book already reserved", "Book reservation", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }

        }
    }
}
