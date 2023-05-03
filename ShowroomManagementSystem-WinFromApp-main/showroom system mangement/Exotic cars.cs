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
    public partial class Exotic_cars : Form
    {

        SqlDataAdapter adap;
        DataTable tab = new DataTable();
        int pos = 0;


        SqlCommand cmd;
        string conn = "Data Source=DANIYAL;Initial Catalog=Showroom_Management_System;User ID=sa;Password=daniyal";
        SqlConnection con;
        public Exotic_cars()
        {
            InitializeComponent();
        }
        private void Exotic_cars_Load(object sender, EventArgs e)
        {
            textBox1.Select();
            //xuiObjectAnimator1.FormAnimate(this, XanderUI.XUIObjectAnimator.FormAnimation.FadeIn, 3);
            adap = new SqlDataAdapter("SELECT * FROM exoticcar_showroom", conn);
            adap.Fill(tab);
            showdata(pos);
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
        }
        public void showdata(int index)
        {
            if (tab.Rows.Count>0)
            {
                textBox1.Text = tab.Rows[index][0].ToString();
                textBox2.Text = tab.Rows[index][1].ToString();
                comboBox1.Text = tab.Rows[index][2].ToString();
                comboBox2.Text = tab.Rows[index][3].ToString();
                textBox4.Text = tab.Rows[index][4].ToString();
                textBox3.Text = tab.Rows[index][5].ToString();
                textBox5.Text = tab.Rows[index][6].ToString();
                comboBox3.Text = tab.Rows[index][7].ToString();
                textBox6.Text = tab.Rows[index][8].ToString();
                textBox7.Text = tab.Rows[index][9].ToString();
                textBox8.Text = tab.Rows[index][10].ToString();
            }
        }
        private void xuiFlatMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

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
            Classical_Cars obj2 = new Classical_Cars();
            obj2.Show();
        }

        private void cOSTUMERSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Customers obj3 = new Customers();
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
                string brand = comboBox1.Text;
                string manufact_year = comboBox2.Text;
                string reg_no = textBox4.Text;
                string chassis_no = textBox3.Text;
                string eng_no = textBox5.Text;
                string trasmission = comboBox3.Text;
                string power = textBox6.Text;
                string fuel = textBox7.Text;
                string cost = textBox8.Text;

                string sqlcmd = "INSERT INTO exoticcar_showroom(car_id,car_name,car_brand,Manufacturing_year,reg_no,chassis_no,eng_no,trasmission,horse_power,fuel_type,cost) values (" + id + ",'" + name + "','" + brand + "','" + manufact_year + "','" + reg_no + "','" + chassis_no + "','" + eng_no + "','" + trasmission + "','" + power + "','" + fuel + "','" + cost + "')";
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

        private void XuiButton7_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
        }

        private void XuiButton4_Click(object sender, EventArgs e)
        {

            
            con = new SqlConnection(conn);
            con.Open();
            string sqlcmd = "SELECT * FROM exoticcar_showroom";
            cmd = new SqlCommand(sqlcmd, con);
            SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                textBox1.Text = (dr["car_id"].ToString());
                textBox2.Text = (dr["car_name"].ToString()); ;
                comboBox1.Text = (dr["car_brand"].ToString()); ;
                comboBox2.Text = (dr["Manufacturing_year"].ToString()); ;
                textBox4.Text = (dr["reg_no"].ToString()); ;
                textBox3.Text = (dr["chassis_no"].ToString()); ;
                textBox5.Text = (dr["eng_no"].ToString()); ;
                comboBox3.Text = (dr["trasmission"].ToString()); ;
                textBox6.Text = (dr["horse_power"].ToString()); ;
                textBox7.Text = (dr["fuel_type"].ToString()); ;
                textBox8.Text = (dr["cost"].ToString()); ;
            
            

            con.Close();

        }

        private void XuiButton5_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Enter car id to UPDATE!!!");
                }
                else
                {

                    int id = Convert.ToInt16(textBox1.Text);
                    string name = textBox2.Text;
                    string brand = comboBox1.Text;
                    string manufact_year = comboBox2.Text;
                    string reg_no = textBox4.Text;
                    string chassis_no = textBox3.Text;
                    string eng_no = textBox5.Text;
                    string trasmission = comboBox3.Text;
                    string power = textBox6.Text;
                    string fuel = textBox7.Text;
                    string cost = textBox8.Text;

                    SqlConnection con = new SqlConnection(conn);

                    cmd = new SqlCommand("UPDATE exoticcar_showroom SET car_name='" + name + "',car_brand='" + brand + "',Manufacturing_year='" + manufact_year + "',reg_no='" + reg_no + "',chassis_no='" + chassis_no + "',eng_no='" + eng_no + "',trasmission='" + trasmission + "',horse_power='" + power + "',fuel_type='" + fuel + "',cost='" + cost + "' where car_id =" + id + "", con);
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
                cmd = new SqlCommand("delete exoticcar_showroom where car_id='" + textBox1.Text + "'", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("DELETED!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();
            }

            catch(SqlException ex)
            {
                MessageBox.Show("connection error!!!" + ex);
            }
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
    }
}
