using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace RapidKL
{
    public partial class Form1 : Form
    {
        double[,] price = { { 0.80, 1.30, 1.90, 2.10, 2.80, 3.10, 2.90, 3.10, 3.30, 3.50, 3.80, 3.50, 3.70, 3.90, 4.20, 4.40, 4.40, 4.00, 4.10, 3.60, 3.70, 3.80, 4.00, 4.10, 4.30, 4.50, 4.70, 4.90, 5.00, 5.10, 5.30, 5.40, 5.60, 5.70, 5.90, 6.10, 6.10 },
            {1.30,0.80,1.50,1.80,2.40,2.70,2.80,3.00,3.00,3.20,3.40,3.60,3.90,3.60,3.90,4.10,4.10,3.70,3.90,4.20,4.30,3.70,3.80,3.90,4.30,4.40,4.50,4.70,4.80,4.90,5.20,5.30,5.40,5.50,5.70,5.90,5.90 },
            { 1.90,1.50,0.80,1.70,2.00,2.10,2.30,2.50,2.80,3.00,3.00,3.20,3.50,3.70,3.50,3.70,3.70,4.10,4.20,3.90,4.00,4.30,3.60,3.70,4.00,4.10,4.30,4.50,4.60,4.70,4.90,5.00,5.20,5.30,5.50,5.70,5.70 },
            {2.10,1.80,1.70,0.80,1.70,1.90,2.00,2.20,2.50,2.70,3.00,2.90,3.20,3.50,3.80,3.50,3.70,3.90,4.00,3.70,3.90,4.10,4.30,3.60,3.70,3.80,4.00,4.20,4.30,4.40,4.60,4.70,4.90,5.00,5.20,5.40,5.50 },
            {2.80,2.40,2.00,1.70,0.80,1.10,1.30,1.60,1.90,2.00,2.30,2.60,2.90,3.20,3.20,3.40,3.70,3.90,3.50,4.00,4.10,3.70,3.90,4.10,4.30,4.40,3.70,3.90,4.00,4.10,4.30,4.40,4.60,4.70,4.90,5.10,5.30 },
            {3.10,2.70,2.10,1.90,1.10,0.80,1.00,1.30,1.60,1.90,2.00,2.30,2.70,3.00,3.00,3.20,3.50,3.70,3.80,3.80,3.90,4.20,3.80,3.90,4.10,4.30,3.60,3.80,3.90,4.00,4.20,4.30,4.50,4.60,4.80,5.00,5.20 },
            {2.90,2.80,2.30,2.00,1.30,1.00,0.80,1.10,1.40,1.70,2.00,2.20,2.50,2.80,3.20,3.10,3.40,3.50,3.70,3.70,3.80,4.10,3.70,3.80,4.10,4.20,4.40,3.70,3.90,4.00,4.20,4.30,4.40,4.50,4.80,4.90,5.10 },
            {3.10,3.00,2.50,2.20,1.60,1.30,1.10,0.80,1.20,1.40,1.80,1.90,2.30,2.60,3.00,2.90,3.20,3.40,3.50,3.50,3.70,4.00,4.20,3.70,3.90,4.10,4.30,3.60,3.80,3.90,4.10,4.20,4.30,4.50,4.70,4.80,5.00 },
        {3.30,3.00,2.80,2.50,1.90,1.60,1.40,1.20,0.80,1.10,1.50,1.80,2.00,2.30,2.70,3.00,3.00,3.10,3.30,3.80,3.50,3.80,4.00,4.20,3.80,3.90,4.10,4.40,3.60,3.80,4.00,4.10,4.20,4.30,4.50,4.70,4.90 },
        {3.50,3.20,3.00,2.70,2.00,1.90,1.70,1.40,1.10,0.80,1.20,1.50,1.90,2.10,2.40,2.70,3.10,2.90,3.10,3.60,3.80,3.60,3.90,4.00,4.30,3.80,4.00,4.20,3.60,3.70,3.90,4.00,4.10,4.20,4.40,4.60,4.80 },
        {3.80,3.40,3.00,3.00,2.30,2.00,2.00,1.80,1.50,1.20,0.80,1.20,1.50,1.90,2.10,2.40,2.80,3.00,3.20,3.40,3.60,3.90,3.70,3.80,4.10,4.30,3.80,4.10,4.30,4.40,3.80,3.80,4.00,4.10,4.30,4.50,4.70 },
        {3.50,3.60,3.20,2.90,2.60,2.30,2.20,1.90,1.80,1.50,1.20,0.80,1.20,1.60,2.00,2.20,2.50,2.70,2.90,3.20,3.30,3.70,3.50,3.70,3.90,4.10,4.40,3.90,4.10,4.20,3.60,3.70,3.90,4.00,4.20,4.40,4.60 },
        {3.70,3.90,3.50,3.20,2.90,2.70,2.50,2.30,2.00,1.90,1.50,1.20,0.80,1.20,1.60,2.00,2.20,2.40,2.60,3.20,3.10,3.40,3.70,3.90,3.70,3.90,4.10,3.70,3.90,4.10,4.40,3.60,3.80,3.90,4.10,4.20,4.40 },
        {3.90,3.60,3.70,3.50,3.20,3.00,2.80,2.60,2.30,2.10,1.90,1.60,1.20,0.80,1.30,1.60,2.00,2.10,2.30,2.90,3.10,3.20,3.50,3.70,3.50,3.70,3.90,4.20,3.80,3.90,4.20,4.30,3.60,3.70,4.00,4.10,4.30 },
        {4.20,3.90,3.50,3.80,3.20,3.00,3.20,3.00,2.70,2.40,2.10,2.00,1.60,1.30,0.80,1.20,1.60,1.80,2.00,2.50,2.80,3.20,3.20,3.40,3.70,3.90,3.70,3.90,4.20,4.40,4.00,4.10,4.30,3.60,3.80,4.00,4.10 },
        {4.40,4.10,3.70,3.50,3.40,3.20,3.10,2.90,3.00,2.70,2.40,2.20,2.00,1.60,1.20,0.80,1.20,1.40,1.70,2.20,2.40,2.90,3.20,3.10,3.50,3.60,4.00,3.70,4.00,4.20,3.80,3.90,4.20,4.30,3.70,3.80,4.00 },
        {4.40,4.10,3.70,3.70,3.70,3.50,3.40,3.20,3.00,3.10,2.80,2.50,2.20,2.00,1.60,1.20,0.80,1.10,1.30,2.00,2.10,2.50,2.90,3.20,3.20,3.40,3.70,3.50,3.80,4.00,4.30,3.80,4.00,4.10,3.50,3.70,3.90 },
        {4.00,3.70,4.10,3.90,3.90,3.70,3.50,3.40,3.10,2.90,3.00,2.70,2.40,2.10,1.80,1.40,1.10,0.80,1.10,1.80,1.90,2.30,2.70,3.00,3.00,3.20,3.50,3.90,3.60,3.80,4.20,4.30,3.90,4.00,4.30,3.60,3.80 },
        {4.10,3.90,4.20,4.00,3.50,3.80,3.70,3.50,3.30,3.10,3.20,2.90,2.60,2.30,2.00,1.70,1.30,1.10,0.80,1.60,1.80,2.10,2.50,2.80,3.20,3.00,3.40,3.70,3.50,3.70,4.00,4.20,3.80,3.90,4.20,4.40,3.70 },
        {3.60,4.20,3.90,3.70,4.00,3.80,3.70,3.50,3.80,3.60,3.40,3.20,3.20,2.90,2.50,2.20,2.00,1.80,1.60,0.80,1.10,1.60,2.00,2.10,2.50,2.80,3.20,3.20,3.50,3.70,3.60,3.80,4.00,4.20,3.80,4.10,4.30 },
        {3.70,4.30,4.00,3.90,4.10,3.90,3.80,3.70,3.50,3.80,3.60,3.30,3.10,3.10,2.80,2.40,2.10,1.90,1.80,1.10,0.80,1.30,1.70,1.90,2.30,2.50,2.90,3.00,3.30,3.50,4.00,3.60,3.90,4.10,3.70,3.90,4.20 },
        {3.80,3.70,4.30,4.10,3.70,4.20,4.10,4.00,3.80,3.60,3.90,3.70,3.40,3.20,3.20,2.90,2.50,2.30,2.10,1.60,1.30,0.80,1.30,1.60,2.00,2.10,2.50,2.90,3.00,3.20,3.60,3.80,3.60,3.80,4.10,3.70,3.90 },
        {4.00,3.80,3.60,4.30,3.90,3.80,3.70,4.20,4.00,3.90,3.70,3.50,3.70,3.50,3.20,3.20,2.90,2.70,2.50,2.00,1.70,1.30,0.80,1.20,1.60,1.90,2.10,2.60,2.90,3.20,3.30,3.50,3.80,3.50,3.90,4.10,3.70 },
        {4.10,3.90,3.70,3.60,4.10,3.90,3.80,3.70,4.20,4.00,3.80,3.70,3.90,3.70,3.40,3.10,3.20,3.00,2.80,2.10,1.90,1.60,1.20,0.80,1.30,1.60,2.00,2.30,2.70,2.90,3.10,3.30,3.60,3.80,3.70,4.00,4.30 },
        {4.30,4.30,4.00,3.70,4.30,4.10,4.10,3.90,3.80,4.30,4.10,3.90,3.70,3.50,3.70,3.50,3.20,3.00,3.20,2.50,2.30,2.00,1.60,1.30,0.80,1.10,1.50,2.00,2.30,2.50,3.10,2.90,3.30,3.50,3.90,3.70,4.00 },
        {4.50,4.40,4.10,3.80,4.40,4.30,4.20,4.10,3.90,3.80,4.30,4.10,3.90,3.70,3.90,3.60,3.40,3.20,3.00,2.80,2.50,2.10,1.90,1.60,1.10,0.80,1.30,1.80,2.00,2.30,2.80,3.10,3.10,3.30,3.70,3.50,3.80 },
        {4.70,4.50,4.30,4.00,3.70,3.60,4.40,4.30,4.10,4.00,3.80,4.40,4.10,3.90,3.70,4.00,3.70,3.50,3.40,3.20,2.90,2.50,2.10,2.00,1.50,1.30,0.80,1.30,1.70,2.00,2.40,2.70,3.00,3.00,3.40,3.70,3.60 },
        {4.90,4.70,4.50,4.20,3.90,3.80,3.70,3.60,4.40,4.20,4.10,3.90,3.70,4.20,3.90,3.70,3.50,3.90,3.70,3.20,3.00,2.90,2.60,2.30,2.00,1.80,1.30,0.80,1.30,1.50,2.00,2.20,2.60,2.90,3.00,3.40,3.70 },
        {5.00,4.80,4.60,4.30,4.00,3.90,3.90,3.80,3.60,3.60,4.30,4.10,3.90,3.80,4.20,4.00,3.80,3.60,3.50,3.50,3.30,3.00,2.90,2.70,2.30,2.00,1.70,1.30,0.80,1.10,1.80,2.00,2.30,2.50,3.00,3.10,3.40 },
        {5.10,4.90,4.70,4.40,4.10,4.00,4.00,3.90,3.80,3.70,4.40,4.20,4.10,3.90,4.40,4.20,4.00,3.80,3.70,3.70,3.50,3.20,3.20,2.90,2.50,2.30,2.00,1.50,1.10,0.80,1.50,1.70,2.00,2.30,2.80,3.20,3.20 },
        {5.30,5.20,4.90,4.60,4.30,4.20,4.20,4.10,4.00,3.90,3.80,3.60,4.40,4.20,4.00,3.80,4.30,4.20,4.00,3.60,4.00,3.60,3.30,3.10,3.10,2.80,2.40,2.00,1.80,1.50,0.80,1.10,1.50,1.90,2.20,2.60,3.10 },
        {5.40,5.30,5.00,4.70,4.40,4.30,4.30,4.20,4.10,4.00,3.80,3.70,3.60,4.30,4.10,3.90,3.80,4.30,4.20,3.80,3.60,3.80,3.50,3.30,2.90,3.10,2.70,2.20,2.00,1.70,1.10,0.80,1.30,1.60,2.00,2.40,2.90 },
        {5.60,5.40,5.20,4.90,4.60,4.50,4.40,4.30,4.20,4.10,4.00,3.90,3.80,3.60,4.30,4.20,4.00,3.90,3.80,4.00,3.90,3.60,3.80,3.60,3.30,3.10,3.00,2.60,2.30,2.00,1.50,1.30,0.80,1.20,1.70,2.00,2.50 },
        {5.70,5.50,5.30,5.00,4.70,4.60,4.50,4.50,4.30,4.20,4.10,4.00,3.90,3.70,3.60,4.30,4.10,4.00,3.90,4.20,4.10,3.80,3.50,3.80,3.50,3.30,3.00,2.90,2.50,2.30,1.90,1.60,1.20,0.80,1.40,1.90,2.20 },
        {5.90,5.70,5.50,5.20,4.90,4.80,4.80,4.70,4.50,4.40,4.30,4.20,4.10,4.00,3.80,3.70,3.50,4.30,4.20,3.80,3.70,4.10,3.90,3.70,3.90,3.70,3.40,3.00,3.00,2.80,2.20,2.00,1.70,1.40,0.80,1.30,1.80 },
        {6.10,5.90,5.70,5.40,5.10,5.00,4.90,4.80,4.70,4.60,4.50,4.40,4.20,4.10,4.00,3.80,3.70,3.60,4.40,4.10,3.90,3.70,4.10,4.00,3.70,3.50,3.70,3.40,3.10,3.20,2.60,2.40,2.00,1.90,1.30,0.80,1.40 },
        {6.10,5.90,5.70,5.50,5.30,5.20,5.10,5.00,4.90,4.80,4.70,4.60,4.40,4.30,4.10,4.00,3.90,3.80,3.70,4.30,4.20,3.90,3.70,4.30,4.00,3.80,3.60,3.70,3.40,3.20,3.10,2.90,2.50,2.20,1.80,1.40,0.80 } };

        double initialNum = 1;

        

        double amount, total;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            listBoxFrom.Items.Add("Gombak");
            listBoxFrom.Items.Add("Taman Melati");
            listBoxFrom.Items.Add("Wangsa Maju");
            listBoxFrom.Items.Add("Sri Rampai");
            listBoxFrom.Items.Add("SetiaWangsa");
            listBoxFrom.Items.Add("Jelatek");
            listBoxFrom.Items.Add("Dato' Keramat");
            listBoxFrom.Items.Add("Damai");
            listBoxFrom.Items.Add("Ampang Park");
            listBoxFrom.Items.Add("KLCC");
            listBoxFrom.Items.Add("Kampung Baru");
            listBoxFrom.Items.Add("Dang Wangi");
            listBoxFrom.Items.Add("Masjid Jamek");
            listBoxFrom.Items.Add("Pasar Seni");
            listBoxFrom.Items.Add("KL Sentral");
            listBoxFrom.Items.Add("Bangsar");
            listBoxFrom.Items.Add("Abdullah hukum");
            listBoxFrom.Items.Add("Kerinchi");
            listBoxFrom.Items.Add("Universiti");
            listBoxFrom.Items.Add("Taman Jaya");
            listBoxFrom.Items.Add("Asia Jaya");
            listBoxFrom.Items.Add("Taman Paramount");
            listBoxFrom.Items.Add("Taman Bahagia");
            listBoxFrom.Items.Add("Kelana Jaya");
            listBoxFrom.Items.Add("Lembah Subang");
            listBoxFrom.Items.Add("Ara Damansara");
            listBoxFrom.Items.Add("Glenmarie");
            listBoxFrom.Items.Add("Subang Jaya");
            listBoxFrom.Items.Add("SS 15");
            listBoxFrom.Items.Add("SS 18");
            listBoxFrom.Items.Add("USJ 7");
            listBoxFrom.Items.Add("Taipan");
            listBoxFrom.Items.Add("Wawasan");
            listBoxFrom.Items.Add("USJ 21");
            listBoxFrom.Items.Add("Alam Megah");
            listBoxFrom.Items.Add("Subang Alam");
            listBoxFrom.Items.Add("Putra Heights");

            listBoxTo.Items.Add("Gombak");
            listBoxTo.Items.Add("Taman Melati");
            listBoxTo.Items.Add("Wangsa Maju");
            listBoxTo.Items.Add("Sri Rampai");
            listBoxTo.Items.Add("SetiaWangsa");
            listBoxTo.Items.Add("Jelatek");
            listBoxTo.Items.Add("Dato' Keramat");
            listBoxTo.Items.Add("Damai");
            listBoxTo.Items.Add("Ampang Park");
            listBoxTo.Items.Add("KLCC");
            listBoxTo.Items.Add("Kampung Baru");
            listBoxTo.Items.Add("Dang Wangi");
            listBoxTo.Items.Add("Masjid Jamek");
            listBoxTo.Items.Add("Pasar Seni");
            listBoxTo.Items.Add("KL Sentral");
            listBoxTo.Items.Add("Bangsar");
            listBoxTo.Items.Add("Abdullah hukum");
            listBoxTo.Items.Add("Kerinchi");
            listBoxTo.Items.Add("Universiti");
            listBoxTo.Items.Add("Taman Jaya");
            listBoxTo.Items.Add("Asia Jaya");
            listBoxTo.Items.Add("Taman Paramount");
            listBoxTo.Items.Add("Taman Bahagia");
            listBoxTo.Items.Add("Kelana Jaya");
            listBoxTo.Items.Add("Lembah Subang");
            listBoxTo.Items.Add("Ara Damansara");
            listBoxTo.Items.Add("Glenmarie");
            listBoxTo.Items.Add("Subang Jaya");
            listBoxTo.Items.Add("SS 15");
            listBoxTo.Items.Add("SS 18");
            listBoxTo.Items.Add("USJ 7");
            listBoxTo.Items.Add("Taipan");
            listBoxTo.Items.Add("Wawasan");
            listBoxTo.Items.Add("USJ 21");
            listBoxTo.Items.Add("Alam Megah");
            listBoxTo.Items.Add("Subang Alam");
            listBoxTo.Items.Add("Putra Heights");


            lblQuantity.Text = initialNum.ToString();

            lblTotal.Text = total.ToString("0.00");

        }

        private void listBoxTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            int intFrom, intTo;
            intFrom = listBoxFrom.SelectedIndex;
            intTo = listBoxTo.SelectedIndex;
            if (intFrom != -1 && intTo != -1)
            {
                amount = price[intFrom, intTo];
                lblAmount.Text = amount.ToString("0.00");
            }
            else
            {
                MessageBox.Show("Select your Origin.", "Information Missing",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            total = amount * initialNum;

            lblTotal.Text = total.ToString("0.00");

        }

        

        private void btnAdd_Click(object sender, EventArgs e)
        {

          
            initialNum = initialNum + 1;

            lblQuantity.Text = initialNum.ToString();

            total = amount * initialNum;
            lblTotal.Text = total.ToString("0.00");

        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            if (initialNum > 1)
            {
                initialNum = initialNum - 1;
                lblQuantity.Text = initialNum.ToString();
            }

            total = amount * initialNum;
            lblTotal.Text = total.ToString("0.00");

        }

        private void btnAmount_Click(object sender, EventArgs e)
        {
            
            double overall, balance;
            double total10sen = 0.10*  (comboBox1.SelectedIndex +1);
            double total20sen = 0.20*  (comboBox2.SelectedIndex+1);
            double total50sen = 0.50 * (comboBox3.SelectedIndex + 1);
            double totalRM1 = 1 * (comboBox4.SelectedIndex + 1);
            double totalRM5 = 5 * (comboBox5.SelectedIndex + 1);
            double totalRM10 = 10 * (comboBox6.SelectedIndex + 1);
            double totalRM20 = 20 * (comboBox7.SelectedIndex + 1);
            overall = total10sen+total20sen+ total50sen+ totalRM1+ totalRM5+ totalRM10+ totalRM20;
            lblTotalPrice.Text = overall.ToString("0.00");
            total = double.Parse(lblTotal.Text);
            if (overall >= total)
            {
                balance = overall - total;
                lblBalance.Text = balance.ToString("0.00");
                MessageBox.Show("Thank You! Please Collect Your Token", "RapidKL",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;
                    AttachDBFilename=|DataDirectory|\RapidKL.mdf;
                    Integrated Security=True");

                
                // Create command
                SqlCommand cmd = new SqlCommand("spPurchaseToken", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@origin", SqlDbType.VarChar).Value = listBoxFrom.SelectedItem;
                cmd.Parameters.Add("@destination", SqlDbType.VarChar).Value = listBoxTo.SelectedItem;
                cmd.Parameters.Add("@amount", SqlDbType.Float).Value = amount;
                cmd.Parameters.Add("@numberOfToken", SqlDbType.Int).Value = initialNum;
                cmd.Parameters.Add("@totalAmount", SqlDbType.Float).Value = total;
                cmd.Parameters.Add("@totalPrice", SqlDbType.Float).Value = overall;
                cmd.Parameters.Add("@balance", SqlDbType.Float).Value = double.Parse(lblBalance.Text);
                try
                {

                    // Open connection
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }

                finally
                {
                    conn.Close();
                }
            }
            else
            {
                balance = overall - total;
                lblBalance.Text = balance.ToString("0.00");
                MessageBox.Show("Not Enough Balance.", "RapidKL",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            lblAmount.Text = "";
            lblBalance.Text = "";
            lblTotal.Text = "";
            lblTotalPrice.Text = "";
            lblQuantity.Text = "1";
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
            comboBox4.SelectedIndex = -1;
            comboBox5.SelectedIndex = -1;
            comboBox6.SelectedIndex = -1;
            comboBox7.SelectedIndex = -1;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                string origin, destination;
                int numberOfToken;
                double amount, totalamount, totalprice, balance;
                origin = listBoxFrom.SelectedItem.ToString();
                destination = listBoxTo.SelectedItem.ToString();
                numberOfToken = int.Parse(lblQuantity.Text);
                amount = double.Parse(lblAmount.Text);
                totalamount = double.Parse(lblTotal.Text);
                totalprice = double.Parse(lblTotalPrice.Text);
                balance = double.Parse(lblBalance.Text);
                Form2 rec = new Form2(origin, destination, numberOfToken, amount, totalamount, totalprice, balance);
                rec.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

       

       
    }

        

        
    }

