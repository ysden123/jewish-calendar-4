using System.Windows;

namespace StulSoft.JewishCalendar4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            System.Diagnostics.FileVersionInfo fvi = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);
            if (fvi != null && fvi.FileVersion != null)
            {
                string version = fvi.FileVersion;
                Title = $"{Title} {version}";
            }
        }

        private void CloseMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ConvertHebDateMunuItem_Click(object sender, RoutedEventArgs e)
        {
            CC.Content = new GregDateConverterControl();
        }

        private void CandleLightDateMenuItem_Click(object sender, RoutedEventArgs e)
        {
            CC.Content = new CandlesLightControl();
        }
    }
}