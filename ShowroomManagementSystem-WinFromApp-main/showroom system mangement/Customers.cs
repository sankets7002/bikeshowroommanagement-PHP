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
    public partial class Customers : Form
    {

        SqlDataAdapter adap;
        DataTable tab = new DataTable();
        int pos = 0;


        SqlCommand cmd;
        string conn = "Data Source=DANIYAL;Initial Catalog=Showroom_Management_System;User ID=sa;Password=daniyal";
        SqlConnection con;
        public Customers()
        {
            InitializeComponent();
        }

        private void Customers_Load(object sender, EventArgs e)
        {
            textBox1.Select();
            //xuiObjectAnimator1.FormAnimate(this, XanderUI.XUIObjectAnimator.FormAnimation.FadeIn, 3);
            adap = new SqlDataAdapter("SELECT * FROM customer_showroom", conn);
            adap.Fill(tab);
            showdata(pos);
            textBox1.Text = "";
            textBox2.Text = "";
            richTextBox1.Text = "";
            comboBox1.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            comboBox4.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
         }

        public void showdata(int index)
        {
            if (tab.Rows.Count>0)
            {
                textBox1.Text = tab.Rows[index][0].ToString();
                textBox2.Text = tab.Rows[index][1].ToString();
                richTextBox1.Text = tab.Rows[index][2].ToString();
                comboBox1.Text = tab.Rows[index][3].ToString();
                textBox4.Text = tab.Rows[index][4].ToString();
                textBox5.Text = tab.Rows[index][5].ToString();
                comboBox2.Text = tab.Rows[index][6].ToString();
                comboBox3.Text = tab.Rows[index][7].ToString();
                comboBox4.Text = tab.Rows[index][8].ToString();
                textBox6.Text = tab.Rows[index][9].ToString();
                textBox7.Text = tab.Rows[index][10].ToString();
            }
        }

        private void xuiButton1_Click(object sender, EventArgs e)
        {
            //xuiObjectAnimator1.FormAnimate(this, XanderUI.XUIObjectAnimator.FormAnimation.FadeOut, 3);
            Application.Exit();
        }

        private void dASHBOARDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard2 obj1 = new Dashboard2();
            obj1.Show();
        }

        private void eXOTICCARSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Exotic_cars obj2 = new Exotic_cars();
            obj2.Show();
        }
        private void COSTUMERSToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Classical_Cars obj3 = new Classical_Cars();
            obj3.Show();
        }

        private void XuiButton3_Click(object sender, EventArgs e)
        {
            try
            {

                SqlConnection con = new SqlConnection(conn);
                con.Open();

                int id = Convert.ToInt16(textBox1.Text);
                string name = textBox2.Text;
                string address =richTextBox1.Text;
                string gender= comboBox1.Text;
                string phone_no = textBox4.Text;
                string car_name = textBox5.Text;
                string manufact_year = comboBox2.Text;
                string car_catagorie = comboBox3.Text;
                string car_type = comboBox4.Text;
                string chassis_no = textBox6.Text;
                string cost = textBox7.Text;

                string sqlcmd = "INSERT INTO customer_showroom(cust_id,cust_name,address,gender,phone_no,car_name,manufact_year,car_catagorie,car_type,chassis_no,cost) values (" + id + ",'" + name + "','" + address + "','" + gender + "','" + phone_no + "','" + car_name + "','" + manufact_year + "','" + car_catagorie + "','" + car_type + "','" + chassis_no + "','" + cost + "')";
                cmd = new SqlCommand(sqlcmd, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Inserted!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();

            }
            catch (SqlException ex)
            {
                MessageBox.Show("conection error" + ex);
            }
        }

        private void XuiButton6_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="")
            {
                MessageBox.Show("Please Enter id to delete data!!");
            }
            else
            {
            try
            {
                SqlConnection con = new SqlConnection(conn);
                con.Open();
                cmd = new SqlCommand("delete customer_showroom where cust_id='" + textBox1.Text + "'", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("DELETED!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();

                textBox1.Text = "";
                textBox2.Text = "";
                richTextBox1.Text = "";
                comboBox1.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                comboBox2.Text = "";
                comboBox3.Text = "";
                comboBox4.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";

            }
            catch(SqlException ex)
            {
                MessageBox.Show("Connection" + ex);
            }
            }
        }

        private void XuiButton4_Click(object sender, EventArgs e)
        {
            
            con = new SqlConnection(conn);
            con.Open();
            string sqlcmd = "SELECT * FROM customer_showroom";
            cmd = new SqlCommand(sqlcmd, con);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            textBox1.Text = (dr["cust_id"].ToString());
            textBox2.Text = (dr["cust_name"].ToString()); 
            richTextBox1.Text = (dr["address"].ToString()); 
            comboBox1.Text = (dr["gender"].ToString()); 
            textBox4.Text = (dr["phone_no"].ToString()); 
            textBox5.Text = (dr["car_name"].ToString()); 
            comboBox2.Text = (dr["manufact_year"].ToString());
            comboBox3.Text = (dr["car_catagorie"].ToString());
            comboBox4.Text = (dr["car_type"].ToString());
            textBox6.Text = (dr["chassis_no"].ToString()); 
            textBox7.Text = (dr["cost"].ToString()); 

            con.Close();
        }

        private void XuiButton5_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Enter customer id to UPDATE!!!");
                }
                else
                {

                    int id = Convert.ToInt16(textBox1.Text);
                    string name = textBox2.Text;
                    string address = richTextBox1.Text;
                    string gender = comboBox1.Text;
                    string phone_no = textBox4.Text;
                    string car_name = textBox5.Text;
                    string manufact_year = comboBox2.Text;
                    string car_catagorie = comboBox3.Text;
                    string car_type = comboBox4.Text;
                    string chassis_no = textBox6.Text;
                    string cost = textBox7.Text;

                    SqlConnection con = new SqlConnection(conn);

                    cmd = new SqlCommand("UPDATE customer_showroom SET cust_name='" + name + "',address='" + address + "',gender='" + gender + "',phone_no='" + phone_no + "',car_name='" + car_name + "',manufact_year='" + manufact_year + "',car_catagorie='" + car_catagorie + "',car_type='" + car_type + "',chassis_no='" + chassis_no + "',cost='" + cost + "' where cust_id =" + id + "", con);
                    con.Open();
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Updated");
                    con.Close();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("connection error" + ex);
            }
        }

        private void XuiButton8_Click(object sender, EventArgs e)
        {
            pos++;
            if (pos < tab.Rows.Count)
            {
                showdata(pos);
            }
            else
            {
                MessageBox.Show("END OF RECORD!");
                pos = tab.Rows.Count - 1;
            }
        }

        private void XuiButton2_Click(object sender, EventArgs e)
        {
            pos--;
            if (pos >= 0)
            {
                showdata(pos);
            }
            else
            {
                MessageBox.Show("FIRST RECORD!");
            }
        }

        private void XuiButton7_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            richTextBox1.Text = "";
            comboBox1.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            comboBox4.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
        }
    }
}
