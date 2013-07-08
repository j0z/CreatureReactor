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

namespace CreatureReactor
{
    /// <summary>
    /// Interaction logic for NameEditWindow.xaml
    /// </summary>
    public partial class NameEditWindow : Window
    {
        public NameEditWindow()
        {
            InitializeComponent();
        }

        private void confirmName(object sender, RoutedEventArgs e)
        {
            MainWindow.scriptData.creatureName = TxtBox_Name.Text;
            this.Close();
        }

        private void Btn_NameCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
