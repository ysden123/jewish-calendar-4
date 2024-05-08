using StulSoft.JewishCalendar4.Service;
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
        private void CandleLightButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CandleLightDate.Text = CandleService.GetCandleLightDate();
            }
            catch (Exception ex)
            {
                CandleLightDate.Text = $"ERROR: {ex.Message}";
            }

        }

        private void HebDateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                HebrewDate.Text = HebrewDateConverterService.GetHebrewDate(DateTime.Parse(GregDate.Text));
            }
            catch (Exception ex)
            {
                HebrewDate.Text = $"ERROR: {ex.Message}";
            }
        }
    }
}