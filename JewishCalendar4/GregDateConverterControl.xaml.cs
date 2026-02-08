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

        private async void ConvertDateButton_Click(object sender, RoutedEventArgs e)
        {
            ConvertDateButton.IsEnabled = false;
            var currentCursor = HebDate.Cursor;
            HebDate.Cursor = System.Windows.Input.Cursors.Wait;

            try
            {
                var date = DateTime.Parse(GregDate.Text);
                HebDate.Text = await Task.Run(() => HebrewDateConverterService.GetHebrewDateAsync(date));
            }
            catch (Exception ex)
            {
                HebDate.Text = $"ERROR: {ex.Message}";
            }

            ConvertDateButton.IsEnabled = true;
            HebDate.Cursor = currentCursor;
        }
    }
}
