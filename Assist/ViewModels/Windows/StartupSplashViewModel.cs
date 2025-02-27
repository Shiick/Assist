﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Assist.Settings;
using ReactiveUI;
using Serilog;
using Serilog.Core;

namespace Assist.ViewModels.Windows
{
    internal class StartupSplashViewModel : ViewModelBase
    {
        private string _statusMessage = "Loading";
        public string StatusMessage
        {
            get => _statusMessage;
            set => this.RaiseAndSetIfChanged(ref _statusMessage, value);
        }
        
        public async Task Startup()
        {
            Log.Information("Splash Startup Started");
            StatusMessage = "Loading..";
            // Look for Settings
            Log.Information("Reading the settings file");
            try
            {
                var settingsContent = File.ReadAllText(AssistSettings.SettingsFilePath);
                AssistSettings.Current = JsonSerializer.Deserialize<AssistSettings>(settingsContent);
                App.ChangeLanguage();
                Log.Information("Successfully read the settings file");
            }
            catch
            {
                Log.Error("Settings File was not found or tampered with.");
                AssistSettings.Current = new AssistSettings();
            }

            await Task.Delay(1000);

            //Open Main Window
            AssistApplication.Current.OpenMainWindow();
        }
    }
}
