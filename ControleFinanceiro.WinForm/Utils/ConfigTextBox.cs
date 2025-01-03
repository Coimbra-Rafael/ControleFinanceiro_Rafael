using System.Windows.Forms;

namespace ControleFinanceiro.WinForm.Utils
{
    public static class ConfigTextBox
    {
        public static void SetPlaceholder(TextBox textBox, string placeholder)
        {
            textBox.ForeColor = System.Drawing.Color.Gray;
            textBox.Text = placeholder;

            textBox.GotFocus += (sender, e) =>
            {
                if (textBox.Text == placeholder)
                {
                    textBox.Text = "";
                    textBox.ForeColor = System.Drawing.Color.Black;
                }
            };

            textBox.LostFocus += (sender, e) =>
            {
                if (string.IsNullOrEmpty(textBox.Text))
                {
                    textBox.Text = placeholder;
                    textBox.ForeColor = System.Drawing.Color.Gray;
                }
            };
        }

        public static void ClearingReservedSpace(TextBox textBox, string placeholder) 
        {
            if (textBox.Text.Equals(placeholder)) 
            {
                textBox.Text = string.Empty;
            }
        }
    }
}
