using System;
using System.Windows.Forms;
// ...

namespace CustomLink_ListView {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            ListLink myLink = new ListLink(printingSystem1);

            myLink.ListViewControl = listView1;
            myLink.ShowPreviewDialog();
            
            myLink.Dispose();
        }
    }
}