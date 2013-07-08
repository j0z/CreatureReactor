using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatureReactor
{
    public class Core
    {
        public static MainWindow mainWindow = null;

        public void SetWindow(MainWindow wnd)
        {
            mainWindow = wnd;
        }

        public MainWindow GetWindow()
        {
            return mainWindow;
        }
    }
}
