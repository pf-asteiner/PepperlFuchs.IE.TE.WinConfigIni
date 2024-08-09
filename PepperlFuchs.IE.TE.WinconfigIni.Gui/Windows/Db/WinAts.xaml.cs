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
using PepperlFuchs.IE.TE.WinConfigIni.Db;

namespace PepperlFuchs.IE.TE.WinconfigIni.Gui.Windows.Db
{
    /// <summary>
    /// Interaction logic for WinAts.xaml
    /// </summary>
    public partial class WinAts : Window
    {
        List<string> sectionNamesList = [];
        List<string> parameterNamesList = [];

        public WinAts()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            sectionNamesList = WinAtsData.SectionNameList.ToList();
            parameterNamesList= WinAtsData.ParameterList.ToList();

            SectionNamesList.ItemsSource = sectionNamesList;
            ParameterNamesList.ItemsSource = parameterNamesList;
        }
    }
}
