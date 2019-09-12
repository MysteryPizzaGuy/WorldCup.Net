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
using WorldCup.Net;

namespace WorldCup.Net_WPF
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        public SettingsWindow()
        {
            InitializeComponent();
            if (Configuration.AppLanguage == Configuration.Language.Croatian)
            {
                TranslationSource.Instance.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("hr");
            }else{
                TranslationSource.Instance.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("");
            }
            this.Closed += SettingsWindow_Closed;
        }
        public WindowState WinState { get; set; } = WindowState.Normal;
        public WindowStyle WinStyle { get; set; } = WindowStyle.SingleBorderWindow;
        protected void SettingsWindow_Closed(object sender, EventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.WindowStyle = WinStyle;
            mainWindow.WindowState = WinState;
            Application.Current.MainWindow = mainWindow;
            mainWindow.Show();
        }

        private void BtnSubmitOptions_Click(object sender, RoutedEventArgs e)
        {
            if ((cboLanguage.SelectedItem as ComboBoxItem).Content as String== Properties.Resources.ResourceManager.GetString("Croatian"))
            {
                Configuration.AppLanguage = Configuration.Language.Croatian;
                TranslationSource.Instance.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("hr");
            }
            else
            {
                Configuration.AppLanguage = Configuration.Language.English;
                TranslationSource.Instance.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("");

            }
            if ((cboScreenMode.SelectedItem as ComboBoxItem).Content as String == "Fullscreen")
            {
                WinState = WindowState.Maximized;
                WinStyle = WindowStyle.None;
            }
            


            this.Close();
        }

        private void CboLanguage_Loaded(object sender, RoutedEventArgs e)
        {
            if (Configuration.AppLanguage==Configuration.Language.Croatian)
            {
                cboLanguage.SelectedIndex = 1;
            }
            else
            {
                cboLanguage.SelectedIndex = 0;
            }
        }

        private void CboScreenMode_Loaded(object sender, RoutedEventArgs e)
        {
            if (Configuration.Fullscreen)
            {
                cboScreenMode.SelectedIndex = 0;
            }
            else
            {
                cboScreenMode.SelectedIndex = 1;
            }
        }
    }
}
