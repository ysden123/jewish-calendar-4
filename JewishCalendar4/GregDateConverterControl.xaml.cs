using StulSoft.JewishCalendar4.Service;
using System.Windows;
using System.Windows.Controls;

namespace StulSoft.JewishCalendar4
{
    /// <summary>
    /// Interaction logic for GregDateConverterControl.xaml
    /// </summary>
    public partial class GregDateConverterControl : UserControl
    {
        public GregDateConverterControl()
        {
            InitializeComponent();
        }

        private void ConvertDateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                HebDate.Text = HebrewDateConverterService.GetHebrewDate(DateTime.Parse(GregDate.Text));
            }
            catch (Exception ex)
            {
                HebDate.Text = $"ERROR: {ex.Message}";
            }
        }
    }
}
