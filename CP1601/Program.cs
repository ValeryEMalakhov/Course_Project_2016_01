using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CP1601.WForm_Admin;
using CP1601.WForm_Staff;
using CP1601.WForm_Start;

namespace CP1601
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // по умолчанию
            //Application.Run(new WFLogin());

            // для быстрого тестирования
            //Application.Run(new WFAdmin());
            Application.Run(new WfStaff());
            //Application.Run(new WFUser());
        }
    }
}
