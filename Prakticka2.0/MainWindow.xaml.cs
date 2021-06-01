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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Prakticka2._0
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Window1 win1 = new Window1();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(TextBoxLogin.Text.Length > 0) // проверяем введён ли логин
            {
                if (PasswordBoxPassword.Password.Length > 0) // проверяем введён ли пароль
                {             // ищем в базе данных пользователя с такими данными
                    DataTable dt_user = mainWindow.Select("SELECT * FROM [dbo].[Login] WHERE [Login] = '" + TextBoxLogin.Text + "' AND [Password] = '" + PasswordBoxPassword.Password + "'");
                    if (dt_user.Rows.Count > 0) // если такая запись существует
                    {
                        mainWindow.Hide();
                        Window1 menuWindow1 = new Window1();
                        menuWindow1.Show();

                    }
                    else MessageBox.Show("Пользователя не найден"); // выводим ошибку
                }
                else MessageBox.Show("Введите пароль"); // выводим ошибку
            }
            else MessageBox.Show("Введите логин"); // выводим ошибку
        }
        public DataTable Select(string selectSQL) // функция подключения к базе данных и обработка запросов
        {
            DataTable dataTable = new DataTable("dataBase");                // создаём таблицу в приложении
                                                                            // подключаемся к базе данных
            SqlConnection sqlConnection = new SqlConnection("server=DESKTOP-BHACMI8;Trusted_Connection=Yes;DataBase=Login;");
            sqlConnection.Open();                                           // открываем базу данных
            SqlCommand sqlCommand = sqlConnection.CreateCommand();          // создаём команду
            sqlCommand.CommandText = selectSQL;                             // присваиваем команде текст
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand); // создаём обработчик
            sqlDataAdapter.Fill(dataTable);                                 // возращаем таблицу с результатом
            return dataTable;
        }

        private void Label_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Registraciya reg = new Registraciya();
            reg.Show();
            this.Close();
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
