using CefSharp;
using CefSharp.Wpf;
using System;
using System.IO;

namespace  RC_CEF_Integration
{
    public static class Program
    {
        /// <summary>
        /// Application Entry Point.
        /// </summary>
        [STAThread]
        public static int Main(string[] args)
        {
            Cef.EnableHighDPISupport();
            var subProcessExe = new CefSharp.BrowserSubprocess.BrowserSubprocessExecutable(); //handle chromium browser processes
            int result = (int)subProcessExe.Main(args);
            if (result > 0)
            {
                return (int)result;
            }
            var exePath = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
            var settings = new CefSettings()
            {
                CachePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CefSharp\\Cache"),
                BrowserSubprocessPath = exePath
            };
            settings.CefCommandLineArgs.Add("enable-media-stream");
            settings.CefCommandLineArgs.Add("enable-p2papi", "1");
            settings.CefCommandLineArgs.Add("allow-running-insecure-content", "1");
            settings.CefCommandLineArgs.Add("enable-usermedia-screen-capturing", "1");
            settings.CefCommandLineArgs.Add("enable-speech-input", "1");
            settings.CefCommandLineArgs.Add("enable-experimental-web-platform-features", "1");
            settings.CefCommandLineArgs.Add("allow-file-access-from-files", "1");
            settings.CefCommandLineArgs.Add("allow-http-screen-capture", "1");
            settings.CefCommandLineArgs.Add("unsafely-treat-insecure-origin-as-secure", "http://localhost:8080/");
            //Perform dependency check to make sure all relevant resources are in our output directory.
            Cef.Initialize(settings, performDependencyCheck: true, browserProcessHandler: null);

            var app = new App();
            app.InitializeComponent();
            return app.Run();
        }
    }
}