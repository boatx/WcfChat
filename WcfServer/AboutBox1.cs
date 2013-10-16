using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace WcfServer
{
    partial class InfoBox : Form
    {
        public InfoBox()
        {
            InitializeComponent();
          //  this.Text = String.Format("About {0} {0}", AssemblyTitle);
          //  this.labelProductName.Text = AssemblyProduct;
          //  this.labelVersion.Text = String.Format("Version {0} {0}", AssemblyVersion);
          //  this.labelCopyright.Text = AssemblyCopyright;
            
           // this.textBoxDescription.Text = AssemblyDescription;
        }



        private void okButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
