using laba7.data;
using laba7.ui;
using laba7.ui.console;
using laba7.ui.win_forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laba7
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var repo = new ZheckListRepository();
            var formController = new Presenter(new WinFormUi(),repo);
            formController.RunView();
            var consoleController = new Presenter(new ConsoleUi(), repo);
           // consoleController.RunView();
        }
    }
}
