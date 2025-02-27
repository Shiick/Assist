﻿using System.Collections.Generic;
using Assist.Services;
using Assist.Views.Dashboard;
using Assist.Views.Progression;
using Assist.Views.Settings;
using Assist.Views.Store;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;

namespace Assist.Controls.Global.Navigation
{
    public partial class NavigationBar : UserControl
    {
        public static NavigationBar Instance;
        public List<NavigationButton> NavigationButtons = new List<NavigationButton>();

        public NavigationBar()
        {
            Instance = this;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
            NavigationButtons.Add(this.FindControl<NavigationButton>("DashboardBtn"));
            NavigationButtons.Add(this.FindControl<NavigationButton>("ProgressionBtn"));
            NavigationButtons.Add(this.FindControl<NavigationButton>("StoreBtn"));
            NavigationButtons.Add(this.FindControl<NavigationButton>("SettingsBtn"));

            NavigationButtons[0].IsSelected = true;
        }


        private void DashboardBtn_OnPointerPressed(object? sender, PointerPressedEventArgs e)
        {
            ClearSelected();

            if (MainViewNavigationController.CurrentPage != Page.DASHBOARD)
                MainViewNavigationController.Change(new DashboardView());

            NavigationButtons[0].IsSelected = true;
        }

        private void ProgressionBtn_OnPointerPressed(object? sender, PointerPressedEventArgs e)
        {
            ClearSelected();

            if (MainViewNavigationController.CurrentPage != Page.PROGRESS)
                MainViewNavigationController.Change(new ProgressionView());
            NavigationButtons[1].IsSelected = true;
        }

        private void StoreBtn_OnPointerPressed(object? sender, PointerPressedEventArgs e)
        {
            ClearSelected();

            if (MainViewNavigationController.CurrentPage != Page.STORE)
                MainViewNavigationController.Change(new StoreView());

            NavigationButtons[2].IsSelected = true;
        }

        private void ClearSelected()
        {
            NavigationButtons.ForEach(btn => btn.IsSelected = false);
        }

        public void SetSelected(int indexOfBtn)
        {
            
        }
        private void SettingsBtn_OnPointerPressedBtn_OnPointerPressed(object? sender, PointerPressedEventArgs e)
        {
            ClearSelected();

            if (MainViewNavigationController.CurrentPage != Page.SETTINGS)
                MainViewNavigationController.Change(new SettingsView());
            NavigationButtons[3].IsSelected = true;
        }
    }
}