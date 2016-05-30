using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogIn
{
    public class LogInValidators
    {
        #region Global Values

        private bool ValidKey;
        private string ErrorString;

        #endregion

        public LogInValidators()
        {
            ValidKey = true;
            ErrorString = "--- Введите корректные значения ---\n" +
                          "-----------------------------------------\n";
        }

        public bool ValidFormNamePass(string name, string pass)
        {
            try
            {
                if (name == string.Empty)
                {
                    ErrorString += "-- Логин не может быть пуcтым\n";
                    ValidKey = false;
                }
                if (pass == string.Empty)
                {
                    ErrorString += "-- Пароль не может быть пуcтым\n";
                    ValidKey = false;
                }

                if (ValidKey)
                {
                    return ValidKey;
                }
                else
                {
                    MessageBox.Show(ErrorString);
                    return ValidKey;
                }
            }
            finally
            {
                ValidKey = true;
                ErrorString = "--- Введите корректные значения ---\n" +
                              "-----------------------------------------\n";
            }
        }

    }
}
