using System.Windows;
using System.Windows.Controls;

namespace TRX_Launcher
{
    public partial class TR2X : Page
    {
        private const string GameName = "TR2X";

        public TR2X()
        {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            string exePath = LauncherHelper.GetExePath(GameName);
            if (string.IsNullOrEmpty(exePath))
                return;

            // Gold o normale, come TR1X
            string args = GoldRadio.IsChecked == true ? "-gold" : "";

            LauncherHelper.StartGame(exePath, args);
        }
    }
}
