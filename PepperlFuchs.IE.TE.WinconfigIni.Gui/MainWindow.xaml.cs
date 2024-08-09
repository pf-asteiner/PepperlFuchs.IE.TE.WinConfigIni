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
using mySetting = PepperlFuchs.IE.TE.WinconfigIni.Gui.Properties.Settings;

using PepperlFuchs.IE.TE.WinconfigIni;

namespace PepperlFuchs.IE.TE.WinconfigIni.Gui;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    WinConfigIniFacility WinConfigIniFacility;
     public MainWindow()
    {
        InitializeComponent();

        if (string.IsNullOrEmpty(mySetting.Default.PathToConfigFiles))
        {
            SeachePathToConfigFiles(@"p:\ppl\ConfigFiles");
        }
        else
        {
            PathToConfigFilesTextBox.Text = mySetting.Default.PathToConfigFiles;
        }
        WinConfigIniFacility = new WinConfigIniFacility(mySetting.Default.PathToConfigFiles);

        DataContext = this;

 
        SettingsListBox.ItemsSource=WinConfigIniFacility.ListSettingNames;
     }

    private void SelectPathToConfigFiles_Click(object sender, RoutedEventArgs e)
    {
        SeachePathToConfigFiles(@"p:\ppl\ConfigFiles");
    }



    private void SeachePathToConfigFiles(string path)
    {
        FolderBrowserDialog dialog = new FolderBrowserDialog();
        dialog.SelectedPath = path;
        if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        {

            mySetting.Default.PathToConfigFiles = dialog.SelectedPath.ToString();
            mySetting.Default.Save();
            PathToConfigFilesTextBox.Text = mySetting.Default.PathToConfigFiles;
        }
    }

    private void SelectPathToTestSystem_Click(object sender, RoutedEventArgs e)
    {

    }

    private void OpenDb_Click(object sender, RoutedEventArgs e)
    {
        var dbWindow = new Windows.Db.WinAts();
        dbWindow.Show();
    }
}