using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace showroom_system_mangement
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //animator1.FormAnimate(this, XanderUI.XUIObjectAnimator.FormAnimation.FadeIn, 3);
        }
        private void XuiButton1_Click(object sender, EventArgs e)
        {
            animator1.FormAnimate(this, XanderUI.XUIObjectAnimator.FormAnimation.FadeOut, 3);
            Application.Exit();
           
        }
        private void Button1_Click(object sender, EventArgs e)
        {
          
            string conn = "Data Source=DANIYAL;Initial Catalog=Showroom_Management_System;User ID=sa;Password=daniyal";
            SqlConnection cnn;
            SqlCommand cmd;
            cnn = new SqlConnection(conn);
            //select upper(User_id),upper(Password) from login_showroom where User_id = 'ali'and Password = 'aLi';
            try
            {
                cnn.Open();
                cmd = new SqlCommand("select * from login_showroom where User_id='"+textBox1.Text+"'and Password='"+textBox2.Text+"'", cnn);
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                ad.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Login Successful!");
                    cnn.Close();
                    this.Hide();
                    Dashboard2 da = new Dashboard2();
                    da.Show();
                    

                }
                else
                {
                    MessageBox.Show("Invalid Login Credentials");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Connection Error" + ex);
            }
        }
    }
}
