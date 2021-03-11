using NBA.WPFApp.BL;
using NBA.WPFApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBA.WPFApp.UI
{
    class EditorServiceViaWindow : IEditorService
    {
        public bool EditPlayer(PlayerUI p)
        {
            EditorWindow win = new EditorWindow(p);
            return win.ShowDialog() ?? false;
        }
    }
}
