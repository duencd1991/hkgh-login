using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YulgangLogin
{
    public partial class FormEncryptChangePassword : Form
    {
        public bool ChangePassword = false;
        private bool _passwordChanged = false;
        public FormEncryptChangePassword()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if( textBoxPassword.Text.Equals(textBoxPassword2.Text) && textBoxPassword.Text != "" )
            {
                if( Database.SetPassword(textBoxPassword.Text, ChangePassword) )
                {
                    Database.PasswordDatabase = textBoxPassword.Text;
                    _passwordChanged = true;
                    MessageBox.Show("Một mật khẩu đã được thiết lập để sử dụng. Vui lòng mở lại chương trình.!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập cùng một mật khẩu vào cả hai trường.!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void FormEncryptFirst_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!ChangePassword && !_passwordChanged || !ChangePassword && _passwordChanged )
            {
                Process.GetCurrentProcess().Kill();
            }
        }

    }
}
