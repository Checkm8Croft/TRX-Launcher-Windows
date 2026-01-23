using System.Windows;
using System.Windows.Controls;

namespace TRX_Launcher
{
    public partial class TR1X : Page
    {
        private const string GameName = "TR1X"; // Nome del gioco nel JSON

        public TR1X()
        {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            // Prende il percorso dell'exe dal JSON tramite LauncherHelper
            string exePath = LauncherHelper.GetExePath(GameName);

            if (string.IsNullOrEmpty(exePath))
                return; // GetExePath già mostra messaggio di errore

            // Costruisci argomenti in base al RadioButton selezionato
            string args = GoldRadio.IsChecked == true ? "-gold" : "";

            // Avvia il gioco usando LauncherHelper
            LauncherHelper.StartGame(exePath, args);
        }
    }
}
