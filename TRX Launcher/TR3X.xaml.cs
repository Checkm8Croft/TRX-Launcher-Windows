using System.Windows;
using System.Windows.Controls;

namespace TRX_Launcher
{
    public partial class TR3X : Page
    {
        private const string GameName = "TR3X";

        public TR3X()
        {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            string exePath = LauncherHelper.GetExePath(GameName);
            if (string.IsNullOrEmpty(exePath))
                return;

            // Gold o normale
            string args = GoldRadio.IsChecked == true ? "-gold" : "";

            LauncherHelper.StartGame(exePath, args);
        }
    }
}
