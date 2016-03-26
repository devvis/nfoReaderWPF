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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace nfoReader_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string version = "1.0";
        private string nfoPath = "test.nfo";

        private nfoReader nfo = new nfoReader();

        public MainWindow()
        {
            InitializeComponent();

            #region Shortcut keystrokes
            // A really ugly(?) way of attaching gestures to existing commands in XAML
            AboutCmd.InputGestures.Add(new KeyGesture(Key.F1));
            ExitApplication.InputGestures.Add(new KeyGesture(Key.Escape));
            OpenNFOFile.InputGestures.Add(new KeyGesture(Key.O, ModifierKeys.Control));
            #endregion

            this.mainWindow.Title = "dNR v" + this.version;

            //nfoReader nfo = new nfoReader(this.version);
            try
            {
                this.nfoBox.Text = nfo.readNfoFromPath(this.nfoPath);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, this.Title);
            }
        }

        /*
         *  This is really not the correct way of doing things in WPF.
         *  But apparently this is all that I could manage, in reality this should probably be in its own class and stuff.
         */
        #region Shortcut-definitions
        public static RoutedCommand AboutCmd = new RoutedCommand();
        public static RoutedCommand ExitApplication = new RoutedCommand();
        public static RoutedCommand OpenNFOFile = new RoutedCommand();
        private void AboutCmdExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("asdf.", this.Title);
        }
        private void ExitApplicationExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void OpenNFOFileExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog nfoOpen = new OpenFileDialog();
            nfoOpen.Filter = "nfo files (*.nfo)|*.nfo";
            if (nfoOpen.ShowDialog() == true)
            {
                this.nfoBox.Text = nfo.readNfoFromPath(nfoOpen.FileName);
            }
        }
        #endregion
    }
}
