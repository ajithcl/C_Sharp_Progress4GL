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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        guestProxxy objGuest = null;
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

            objGuest.guest(guestNumber, out string guestName);
            System.Windows.Forms.MessageBox.Show(guestNumber);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private bool StartAppserverConnection()
        {
            try 
            { 
                Connection objCon = new Connection("appserver://NLBAVWSLDEV01:5162/asbroker1", "", "", "");
                objGuest = new guestProxxy(objCon);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }

}
