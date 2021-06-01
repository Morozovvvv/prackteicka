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
    /// Логика взаимодействия для ProverkaMashin.xaml
    /// </summary>
    public partial class ProverkaMashin : Window
    {
        public ProverkaMashin()
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

            Prakticka2._0.loginDataSet2 loginDataSet2 = ((Prakticka2._0.loginDataSet2)(this.FindResource("loginDataSet2")));
            // Загрузить данные в таблицу Mashina. Можно изменить этот код как требуется.
            Prakticka2._0.loginDataSet2TableAdapters.MashinaTableAdapter loginDataSet2MashinaTableAdapter = new Prakticka2._0.loginDataSet2TableAdapters.MashinaTableAdapter();
            loginDataSet2MashinaTableAdapter.Fill(loginDataSet2.Mashina);
            System.Windows.Data.CollectionViewSource mashinaViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("mashinaViewSource")));
            mashinaViewSource.View.MoveCurrentToFirst();
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
