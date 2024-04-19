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
using MySql.Data.MySqlClient;


namespace WpfAppBicajkolcsonzo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string connectionString = "server=localhost;user=root;database=biziglikolcsonzorendszer;port=3306;";
        private DatabaseHelper dbHelper;
        public MainWindow()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
            LoadData();

    }

        private void LoadData()
        {
            bicajJarganyDataGrid.ItemsSource = dbHelper.GetBicajJarganyList();
            berloEmberDataGrid.ItemsSource = dbHelper.GetBerloEmberList();
            kolcsonzesCuccDataGrid.ItemsSource = dbHelper.GetKolcsonzesCuccList();
        }

    }
}
