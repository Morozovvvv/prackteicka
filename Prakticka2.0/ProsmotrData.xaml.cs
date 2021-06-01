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

namespace Prakticka2._0
{
    /// <summary>
    /// Логика взаимодействия для ProsmotrData.xaml
    /// </summary>
    public partial class ProsmotrData : Window
    {
        public ProsmotrData()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window1 win = new Window1();
            win.Show();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            Prakticka2._0.loginDataSet1 loginDataSet1 = ((Prakticka2._0.loginDataSet1)(this.FindResource("loginDataSet1")));
            // Загрузить данные в таблицу FIO. Можно изменить этот код как требуется.
            Prakticka2._0.loginDataSet1TableAdapters.FIOTableAdapter loginDataSet1FIOTableAdapter = new Prakticka2._0.loginDataSet1TableAdapters.FIOTableAdapter();
            loginDataSet1FIOTableAdapter.Fill(loginDataSet1.FIO);
            System.Windows.Data.CollectionViewSource fIOViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("fIOViewSource")));
            fIOViewSource.View.MoveCurrentToFirst();
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
