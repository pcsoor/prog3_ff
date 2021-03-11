using NBA.WPFApp.Data;
using NBA.WPFApp.VM;
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
using System.Windows.Shapes;

namespace NBA.WPFApp.UI
{
    /// <summary>
    /// Interaction logic for EditorWindow.xaml
    /// </summary>
    public partial class EditorWindow : Window
    {
        EditorViewModel VM;

        public PlayerUI PlayerUI { get => VM.PlayerUi; }

        public EditorWindow()
        {
            InitializeComponent();

            VM = FindResource("VM") as EditorViewModel;
        }

        public EditorWindow(PlayerUI oldPlayer) : this()
        {
            VM.PlayerUi = oldPlayer;
        }

        private void OkClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
