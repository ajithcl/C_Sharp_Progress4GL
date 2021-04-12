using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Progress.Open4GL.Proxy;

/*
 * Ref: http://www.oehive.org/node/903.html
 */

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        GuestProxy objGuest = null;
        protected string guestNumber;

        public Form1()
        {
            InitializeComponent();
            bool result= this.StartAppserverConnection();
            if (result == false){
                System.Windows.Forms.MessageBox.Show("Unable to establish connection.");
            }
        }

        private void txtNumber_TextChanged(object sender, EventArgs e)
        {
            guestNumber = txtNumber.Text;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            objGuest.guest(Convert.ToInt32(guestNumber), 
                           out string guestName,
                           out string guestAddress,
                           out string guestCountry);
            txtGuestName.Text = guestName;
            txtCountry.Text = guestCountry;
            txtAddress.Text = guestAddress;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private bool StartAppserverConnection()
        {
            try 
            { 
                Connection objCon = new Connection("appserver://NLBAVWSLDEV01:5162/asbroker1", "", "", "");
                objGuest = new GuestProxy(objCon);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }

}
