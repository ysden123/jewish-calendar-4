using StulSoft.JewishCalendar4.Service;
using System.Windows.Controls;

namespace StulSoft.JewishCalendar4
{
    /// <summary>
    /// Interaction logic for CandlesLightControl.xaml
    /// </summary>
    public partial class CandlesLightControl : UserControl
    {
        public CandlesLightControl()
        {
            InitializeComponent();
            try
            {
                Text.Text = $"Ближайшее время зажигания свечей: {CandleService.GetCandleLightDate()}";
            }
            catch (Exception ex)
            {
                Text.Text = ex.Message;
            }
        }
    }
}
