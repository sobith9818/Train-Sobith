using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sobith_forma
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

       
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            comboBox2.Items.AddRange(new object[]
{
        "Select Net Banking",
        "SBI",
        "BHIMUPI",
        "PHONEPE",
        "AUTOPAY_UPI",
        "HDFCUPI",
        "RAZORPAYUPI",
        "iPay-QR",
        "PayTM-QR",
        "PHONEPE-QR",
        "IRCTC_WALLET",
        "AIRTELMONEY",
        "PAYTM"
});

            comboBox2.SelectedIndex = 0;
        }
    }
}
