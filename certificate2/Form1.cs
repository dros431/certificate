using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;



namespace certificate2
{
    public partial class Form1 : Form
    {
        
        SqlConnection con;
        konek k = new konek();
        SqlCommand cmd;
        SqlDataReader dr;
        



        TextInfo text = new CultureInfo("en-US", false).TextInfo;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void cbname_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
            
        {
            string a = "";
            if (comboBox2.Text == "Most Valuable Player")
            {
                tbdis.Text = @"""Agent with the most overall points this month""";
            }
            if (comboBox2.Text == "Customer Wow Champion")
            {
                tbdis.Text = @"""Agent with the maximum Customer satisfaction points this month""";
            }
            if (comboBox2.Text == "Sharpshooter")
            {
                tbdis.Text = @"""Agent with the highest First Call Resolution points this month"" ";
            }
            if (comboBox2.Text == "Speed Racer")
            {
                tbdis.Text = @"""Agent with the maximum points for fast resolution this month"" ";
            }
            if (comboBox2.Text == "Best in Attendance")
            {
                comboBox1.SelectedItem = null;
                tbdis.Clear();
            }
            if (comboBox2.Text == "Employee of the Month")
            {
               
                comboBox1.SelectedItem = null;
                tbdis.Clear();
            }
            if (comboBox2.Text == @"Most number of ""Awesome"" KUDOS" || comboBox2.Text == "Employee of the Month" || comboBox2.Text == "Best in Attendance")
            {
                comboBox1.Enabled = false;
                comboBox1.SelectedItem = null;
                tbdis.Clear();
            }
            else if (comboBox2.Text != @"Most number of ""Awesome"" KUDOS")
            {
                tbdis.Enabled = true;
                comboBox1.Enabled = true;
            }
        }
        private void selectName()
        {
            cbname.Items.Clear();
            cbname.Text = "Cesar Oagdan";
            comboBox2.Text = "Most Valuable Player";
            comboBox1.Text = "- Expert";
            cmd = new SqlCommand("select Names from names", con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cbname.Items.Add(dr[0].ToString());
            }
            dr.Close();
            cmd.Dispose();
        }
       
        private void Form1_Load(object sender, EventArgs e)
        {
            con = k.getcon();
            selectName();
           
            
        }

        private void cboption_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboption.Text == "Technical Support Manager - Phils.")
            {
                tbHTS.Text = "Michael Belle Dupio";
            }
            if (cboption.Text == "Technical Support Manager - USA")
            {
               tb1.Text = "Tom Duffy";
            }
            if (cboption.Text == "Head of Technical Support")
            {
                tb2.Text = "Jourdain Bonfante";
            }
            if (cboption.Text == "Operations Manager")
            {
               tb3.Text = "Isiel Zanya Undag";
            }
            if (cboption.Text == "Project Manager")
            {
                tb4.Text = "Joel Zapanta";
            }
            if (cboption.Text == "Managing Director")
            {
                tb5.Text = "Joshua Oliver";
            }
        }
        
        TextObject t1,t2,a,t4,t5,name1,name2,name3,name4,name5,name6;

        private void tbadd_Leave(object sender, EventArgs e)
        {
            tbadd.Text = text.ToTitleCase(tbadd.Text);
        }

        private void btnrev_Click(object sender, EventArgs e)
        {
            
        }

        

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbname.Text))
            {
                MessageBox.Show("You must select the Name first!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DialogResult d = MessageBox.Show("Do you want to Remove", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (d == DialogResult.Yes)
                {
                    cmd = new SqlCommand("delete from names where Names='" + cbname.Text + "'", con);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    selectName();
                }
                else
                {
                  
                }
            }

            
        }

        int z = 0;
        string sql;
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbadd.Text))
            {
                MessageBox.Show("You must input Data!","", MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                
                sql = "select Names from names where Names = '"+tbadd.Text+"'";
                cmd = new SqlCommand(sql, con);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    z++;
                }
                dr.Close();
                cmd.Dispose();
                if (z == 0)
                {
                    MessageBox.Show(" Successfull!","",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    cmd = new SqlCommand("insert into names ( Names ) values ('" + tbadd.Text + "')", con);
                    cmd.ExecuteNonQuery();
                    tbadd.Clear();
                    cbname.Text = tbadd.Text;
                    selectName();
                }
                else
                {
                    MessageBox.Show("Name already exist!","",MessageBoxButtons.OK,MessageBoxIcon.Hand);
                    tbadd.Clear();
                }
            }
        }

        

        private void tbdis_Leave(object sender, EventArgs e)
        {
            tbdis.Text = text.ToTitleCase(tbdis.Text);
        }

        private void tb1_Leave(object sender, EventArgs e)
        {
            tb1.Text = text.ToTitleCase(tb1.Text);
            tb2.Text = text.ToTitleCase(tb2.Text);
            tb3.Text = text.ToTitleCase(tb3.Text);
            tb4.Text = text.ToTitleCase(tb4.Text);
            tb5.Text = text.ToTitleCase(tb5.Text);
            tbdis.Text = text.ToTitleCase(tbdis.Text);
        }

        private void tbHTS_Leave(object sender, EventArgs e)
        {
            tbHTS.Text = text.ToTitleCase(tbHTS.Text);
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Form2 f2 = new certificate2.Form2();
            CrystalReport1 c = new certificate2.CrystalReport1();
            t1 = (TextObject)c.ReportDefinition.Sections["Section3"].ReportObjects["centername"];
            t2 = (TextObject)c.ReportDefinition.Sections["Section3"].ReportObjects["category"];
            a = (TextObject)c.ReportDefinition.Sections["Section3"].ReportObjects["text3"];
            t4 = (TextObject)c.ReportDefinition.Sections["Section3"].ReportObjects["time"];
            t5 = (TextObject)c.ReportDefinition.Sections["Section3"].ReportObjects["text17"];
            name1 = (TextObject)c.ReportDefinition.Sections["Section3"].ReportObjects["t1"];
            name2 = (TextObject)c.ReportDefinition.Sections["Section3"].ReportObjects["t2"];
            name3 = (TextObject)c.ReportDefinition.Sections["Section3"].ReportObjects["t3"];
            name4 = (TextObject)c.ReportDefinition.Sections["Section3"].ReportObjects["t4"];
            name5 = (TextObject)c.ReportDefinition.Sections["Section3"].ReportObjects["t5"];
            name6 = (TextObject)c.ReportDefinition.Sections["Section3"].ReportObjects["t6"];
            t1.Text = cbname.Text;
            a.Text = tbdis.Text;
            t5.Text = dateTimePicker1.Text;
 
            if (comboBox2.Text == "Employee of the Month")
            {
                t2.Text =  comboBox2.Text;
            }
            else if(comboBox2.Text == "Best in Attendance")
            {
                t2.Text = comboBox2.Text + " " + comboBox1.Text;
            }
            else if (comboBox2.Text == @"Most number of ""Awesome"" KUDOS")
            {
                t2.Text = comboBox2.Text + " " + comboBox1.Text;
            }
            else
            {
                t2.Text =  comboBox2.Text + " " + comboBox1.Text;
            }

            //date
            if (dateTimePicker2.Value.Day == 1)
            {
                t4.Text = "Given this "+ dateTimePicker2.Value.Day.ToString() + "st " + dateTimePicker2.Value.ToString("MMMM yyyy");
            }else if (dateTimePicker2.Value.Day ==2)
            {
                t4.Text = "Given this " + dateTimePicker2.Value.Day.ToString() + "nd " + dateTimePicker2.Value.ToString("MMMM yyyy");
            }
            else if (dateTimePicker2.Value.Day == 3)
            {
                t4.Text = "Given this " + dateTimePicker2.Value.Day.ToString() + "rd " + dateTimePicker2.Value.ToString("MMMM yyyy");
            }
            else
            {
                t4.Text = "Given this " + dateTimePicker2.Value.Day.ToString() + "th " + dateTimePicker2.Value.ToString("MMMM yyyy");
            }
            
            name1.Text = tbHTS.Text;
            name2.Text = tb1.Text;
            name3.Text = tb2.Text;
            name4.Text = tb3.Text;
            name5.Text = tb4.Text;
            name6.Text = tb5.Text;
            f2.crt.ReportSource = c;
            f2.ShowDialog();

            tbHTS.Clear();
            tb1.Clear();
            tb2.Clear();
            tb3.Clear();
            tb4.Clear();
            tb5.Clear();
        }
    }
}


