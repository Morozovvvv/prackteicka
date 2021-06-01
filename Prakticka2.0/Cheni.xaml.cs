using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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


namespace Prakticka2._0
{
    /// <summary>
    /// Логика взаимодействия для Cheni.xaml
    /// </summary>
    public partial class Cheni : Window
    {


        public DataTable Select(string selectSQL) // функция подключения к базе данных и обработка запросов
        {
            DataTable dataTable = new DataTable("dataBase");                // создаём таблицу в приложении
                                                                            // подключаемся к базе данных
            SqlConnection sqlConnection = new SqlConnection("server=DESKTOP-BHACMI8;Trusted_Connection=Yes;DataBase=Chena;");
            sqlConnection.Open();                                           // открываем базу данных
            SqlCommand sqlCommand = sqlConnection.CreateCommand();          // создаём команду
            sqlCommand.CommandText = selectSQL;                             // присваиваем команде текст
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand); // создаём обработчик
            sqlDataAdapter.Fill(dataTable);                                 // возращаем таблицу с результатом
            return dataTable;
        }

        public Cheni()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window1 win = new Window1();
            win.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {

            Prakticka2._0.loginDataSet loginDataSet = ((Prakticka2._0.loginDataSet)(this.FindResource("loginDataSet")));
            // Загрузить данные в таблицу Chena. Можно изменить этот код как требуется.
            Prakticka2._0.loginDataSetTableAdapters.ChenaTableAdapter loginDataSetChenaTableAdapter = new Prakticka2._0.loginDataSetTableAdapters.ChenaTableAdapter();
            loginDataSetChenaTableAdapter.Fill(loginDataSet.Chena);
            System.Windows.Data.CollectionViewSource chenaViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("chenaViewSource")));
            chenaViewSource.View.MoveCurrentToFirst();
        }

        private void Button_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
