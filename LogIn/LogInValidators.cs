using System.Text.RegularExpressions;
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

        public bool ValidAddUser(TextBox pass, TextBox textBoxUserId, TextBox textBoxFirstName, TextBox textBoxSecondName,
            ComboBox comboBoxGender, DateTimePicker dtpBirth, MaskedTextBox textBoxPhone)
        {
            try
            {
                if (pass.Text == string.Empty)
                {
                    ErrorString += "-- Пароль не может быть пустым\n";
                    ValidKey = false;
                }
                if (textBoxUserId.Text == string.Empty)
                {
                    ErrorString += "-- Код паспорта не может быть пустым\n";
                    ValidKey = false;
                }
                if (textBoxFirstName.Text == string.Empty)
                {
                    ErrorString += "-- Поле имени не может быть пустым\n";
                    ValidKey = false;
                }
                if (textBoxSecondName.Text == string.Empty)
                {
                    ErrorString += "-- Поле фамилии не может быть пустым\n";
                    ValidKey = false;
                }
                if (comboBoxGender.Text == string.Empty)
                {
                    ErrorString += "-- Пол человека не может быть пустым\n";
                    ValidKey = false;
                }
                else
                {
                    if (comboBoxGender.Text != "муж" && comboBoxGender.Text != "жен")
                    {
                        ErrorString += "-- Пол человека не может быть таким\n";
                        ValidKey = false;
                    }
                }
                if (Regex.Replace(textBoxPhone.Text, "[ ]+", "") != "()-")
                {
                    if (textBoxPhone.Text.IndexOf(' ') != 5 && textBoxPhone.Text.IndexOf(' ') != -1)
                    {
                        ErrorString += "-- Номер должен быть без пробелов\n";
                        ValidKey = false;
                    }
                }
                else
                {
                    textBoxPhone.Text = "0000000000";
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
