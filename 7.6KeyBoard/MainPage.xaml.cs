using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace _7._6KeyBoard
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        private bool isCtrlKeyPressed = false;
        public MainPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // Set the input focus to ensure that keyboard events are raised.
            this.Loaded += delegate { this.Focus(FocusState.Programmatic); };
        }

        private void Grid_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.Control) isCtrlKeyPressed = false;
        }

        private void Grid_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.Control) isCtrlKeyPressed = true;
            else if (isCtrlKeyPressed)
            {
                switch (e.Key)
                {
                    case VirtualKey.P: DemoMovie.Play(); break;
                    case VirtualKey.A: DemoMovie.Pause(); break;
                    case VirtualKey.S: DemoMovie.Stop(); break;
                }
            }
        }

        private void MediaButton_Click(object sender, RoutedEventArgs e)
        {
            switch ((sender as Button).Name)
            {
                case "PlayButton": DemoMovie.Play(); break;
                case "PauseButton": DemoMovie.Pause(); break;
                case "StopButton": DemoMovie.Stop(); break;
            }
        }

    }
}
