using System;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
using System.Windows;

namespace TRX_Launcher
{
    public static class LauncherHelper
    {
        private static string appFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "TRX_Launcher");
        private static string configFile = Path.Combine(appFolder, "paths.json");

        static LauncherHelper()
        {
            Directory.CreateDirectory(appFolder);
            EnsureConfigExists();
        }

        private static void EnsureConfigExists()
        {
            if (!File.Exists(configFile))
            {
                var defaultPaths = new
                {
                    TR1X = "%USERPROFILE%\\Documents\\TR1X\\TRX.exe",
                    TR2X = "%USERPROFILE%\\Documents\\TR2X\\TRX.exe",
                    TR3X = "%USERPROFILE%\\Documents\\TR3X\\TRX.exe"
                };

                string jsonDefault = JsonSerializer.Serialize(defaultPaths, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(configFile, jsonDefault);
            }
        }

        public static string GetExePath(string game)
        {
            try
            {
                string json = File.ReadAllText(configFile);
                using JsonDocument doc = JsonDocument.Parse(json);

                if (!doc.RootElement.TryGetProperty(game, out JsonElement element))
                    throw new Exception($"Game {game} non trovato nel paths.json");

                string pathRaw = element.GetString() ?? "";
                return Environment.ExpandEnvironmentVariables(pathRaw);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errore lettura paths.json: {ex.Message}", "Errore", MessageBoxButton.OK, MessageBoxImage.Error);
                return "";
            }
        }

        public static void StartGame(string exePath, string args)
        {
            if (string.IsNullOrWhiteSpace(exePath) || !File.Exists(exePath))
            {
                MessageBox.Show($"Exe non trovato:\n{exePath}", "Errore", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = exePath,
                    Arguments = args,
                    WorkingDirectory = Path.GetDirectoryName(exePath) ?? ""
                };

                Process.Start(startInfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errore avvio: {ex.Message}", "Errore", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
