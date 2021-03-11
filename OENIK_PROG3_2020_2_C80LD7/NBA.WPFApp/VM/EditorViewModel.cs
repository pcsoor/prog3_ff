namespace NBA.WPFApp.VM
{
    using GalaSoft.MvvmLight;
    using NBA.WPFApp.Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class EditorViewModel : ViewModelBase
    {
        PlayerUI playerui;
        public PlayerUI Playerui
        {
            get { return playerui; }
            set { Set(ref playerui, value); }
        }

        public EditorViewModel()
        {
            playerui = new PlayerUI();
            if (IsInDesignMode)
            {
                playerui.Name = "Unknown Bill";
                playerui.Height = 200;
            }
        }
    }
}
