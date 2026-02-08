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
            FillData();
        }
        
        public async void FillData()
        {
            try
            {
                var data = await Task.Run(CandleService.GetCandleLightDateAsync);
                Text.Text = $"Ближайшее время зажигания свечей: {data}";
            }
            catch (Exception ex)
            {
                Text.Text = ex.Message;
            }
        }
    }
}
