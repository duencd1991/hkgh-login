using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YulgangLogin
{
    public partial class FormEncrypt : Form
    {
        private bool _hasPassword = false;
        public FormEncrypt()
        {
            InitializeComponent();
        }

        private void checkPassword()
        {
            if( Database.CheckConnection(textBoxPassword.Text) )
            {
                Database.PasswordDatabase = textBoxPassword.Text;
                _hasPassword = true;
                Close();
            }
            else
            {
                MessageBox.Show("Mật khẩu sai!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxPassword.Text = null;
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Console.WriteLine(Database.PathDatabaseFile());
            checkPassword();
        }

        private void FormEncrypt_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_hasPassword == false)
            {
                System.Environment.Exit(0);
            }
        }

        private void textBoxPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if( e.KeyChar == Convert.ToChar(Keys.Return) )
            {
                checkPassword();
            }
        }

        private void ToolStripMenuItemClean_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn sắp xóa sạch dữ liệu cũ một cách không thể cứu vãn được. Có thể là do bạn không nhớ mật khẩu hoặc gặp sự cố khi truy cập dữ liệu của mình. Bạn có chắc chắn muốn xóa tất cả dữ liệu không??","Chắc chắn?",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if( dialogResult == DialogResult.Yes )
            {
                if (Database.Clean())
                {
                    MessageBox.Show("Dữ liệu đã được xoá", "Chắc chắn?", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Process.GetCurrentProcess().Kill();
                }
                else
                {
                    MessageBox.Show("Đã xảy ra lỗi; không thể xóa dữ liệu.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FormEncrypt_Load(object sender, EventArgs e)
        {
            //Set title
            this.Text = "Yulgang Login " + Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }
    }
}
