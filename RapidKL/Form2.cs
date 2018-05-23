using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RapidKL
{
    public partial class Form2 : Form
    {
        public Form2(string origin, string destination, int numberOfToken, double amount, double totalamount, double totalprice, double balance)
        {
            InitializeComponent();
            lblFrom.Text = origin;
            lblTo.Text = destination;
            lblQuantity.Text = numberOfToken.ToString();
            lblPrice.Text = amount.ToString("RM 0.00");
            lblTotalPrice.Text = totalamount.ToString("RM 0.00");
            lblAmount.Text = totalprice.ToString("RM 0.00");
            lblBalance.Text = balance.ToString("RM 0.00");
        }

        private void Print_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(memoryImage, 0, 0);
        }

        
        Bitmap memoryImage;

        private void CaptureScreen()
        {
            Graphics myGraphics = this.CreateGraphics();
            Size s = this.Size;
            memoryImage = new Bitmap(s.Width, s.Height, myGraphics);
            Graphics memoryGraphics = Graphics.FromImage(memoryImage);
            memoryGraphics.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, s);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            CaptureScreen();
            Print.Print();
            Print.PrintPage += new PrintPageEventHandler(Print_PrintPage);
        }
    }
}
