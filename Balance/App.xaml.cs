using System.Diagnostics;

using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation; 
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls; 
using Windows.UI.Xaml.Navigation;
using Windows.Storage;
using Windows.UI.ViewManagement;

using Microsoft.EntityFrameworkCore;

using Balance.Models;
using System;

namespace Balance
{ 
    sealed partial class App : Application
    { 
        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;


            Debug.WriteLine(ApplicationData.Current.LocalFolder.Path);

            using (var db = new SQLiteContext())
            {
                db.Database.Migrate();
            }
        }
         
        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;

            if (rootFrame == null)
            {
                
                rootFrame = new Frame();

                rootFrame.NavigationFailed += OnNavigationFailed;

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    //TODO: Загрузить состояние из ранее приостановленного приложения
                }

             
                Window.Current.Content = rootFrame; 
            }

            if (e.PrelaunchActivated == false)
            {
                if (rootFrame.Content == null)
                {
                   
                    rootFrame.Navigate(typeof(Views.StartPage), e.Arguments);
                }
               
                Window.Current.Activate();
            }

            ApplicationView appView = ApplicationView.GetForCurrentView();
            appView.SetPreferredMinSize(new Size(600, 400));
            
        }

        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            
            deferral.Complete();
        }
    }
}
