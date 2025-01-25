using MyFinancialCrm.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyFinancialCrm
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        FinancialCrmDbEntities db = new FinancialCrmDbEntities();
        private void button1_Click(object sender, EventArgs e)
        {
            var user = db.Users.FirstOrDefault(u => u.Username == txtUsername.Text && u.Password == mskPassword.Text);

            int userId = db.Users.Where(x => x.Username == txtUsername.Text).Select(y => y.UserId).FirstOrDefault();
            
            if (user != null)
            {
                FrmDashboard frm = new FrmDashboard();
              

                MessageBox.Show("Giriş Başarılı", "Hoşgeldiniz", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Geçersiz kullanıcı adı veya şifre.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
             txtUsername.Text =string.Empty;
             mskPassword.Text = string.Empty;

                txtUsername.Focus();
            }
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
