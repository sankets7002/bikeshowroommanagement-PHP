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
    public partial class Dashboard2 : Form
    {
        public Dashboard2()
        {
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            //xuiObjectAnimator1.FormAnimate(this, XanderUI.XUIObjectAnimator.FormAnimation.FadeIn, 1);
        }

        private void XuiButton1_Click(object sender, EventArgs e)
        {
            xuiObjectAnimator1.FormAnimate(this, XanderUI.XUIObjectAnimator.FormAnimation.FadeOut, 3);
            Application.Exit();
        }



        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Exotic_cars obj2 = new Exotic_cars();
            obj2.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Customers obj4 = new Customers();
            obj4.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Classical_Cars obj3 = new Classical_Cars();
            obj3.Show();
        }

       
        private void Label1_MouseEnter(object sender, EventArgs e)
        {
            label1.ForeColor = Color.Red;
        }

        private void Label1_MouseLeave(object sender, EventArgs e)
        {
            label1.ForeColor = Color.WhiteSmoke;
        }
        private void Label2_MouseEnter(object sender, EventArgs e)
        {
            label2.ForeColor = Color.Red;
        }
        private void Label3_MouseEnter(object sender, EventArgs e)
        {
            label3.ForeColor = Color.Red;
        }
       
        private void Label2_MouseLeave_1(object sender, EventArgs e)
        {
            label2.ForeColor = Color.WhiteSmoke;
        }

        private void Label3_MouseLeave_1(object sender, EventArgs e)
        {
            label3.ForeColor = Color.WhiteSmoke;
        }

        private void Label4_MouseEnter(object sender, EventArgs e)
        {
            label4.ForeColor = Color.WhiteSmoke;
        }

        private void Label4_MouseLeave(object sender, EventArgs e)
        {
            label4.ForeColor = Color.Black;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login obj5 = new Login();
            obj5.Show();
        }
    }
}
