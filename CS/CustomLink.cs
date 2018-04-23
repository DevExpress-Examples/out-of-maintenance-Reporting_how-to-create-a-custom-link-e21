using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraPrinting;
// ...

namespace CustomLink_ListView {

    public class ListLink : Link {
        private ListView listView = null;


        public ListView ListViewControl {
            get { return listView; }
            set { listView = value; }
        }

        public ListLink(System.ComponentModel.IContainer container)
            : base(container) {
        }

        public ListLink()
            : base() {
        }

        public ListLink(PrintingSystem ps)
            : base(ps) {
        }

        public override void CreateDocument(PrintingSystem ps) {
            if (listView == null) return;
            if (listView.Items.Count == 0) return;
            BrickGraphics gr = ps.Graph;
            base.CreateDocument(ps);
        }


        protected override void CreateMarginalHeader(BrickGraphics gr) {
            gr.Modifier = BrickModifier.MarginalHeader;
            string format = "Printed on {0:MMMM, dd}";
            PageInfoBrick brick = gr.DrawPageInfo(PageInfo.DateTime, format, Color.Black,
            new RectangleF(0, 0, 0, 20), BorderSide.None);
            brick.Alignment = BrickAlignment.Far;
            brick.AutoWidth = true;
        }


        protected override void CreateReportHeader(BrickGraphics gr) {
            gr.Modifier = BrickModifier.ReportHeader;
            TextBrick textBrick;
            gr.BackColor = Color.White;
            gr.StringFormat = 
                new BrickStringFormat(StringFormatFlags.NoWrap | StringFormatFlags.LineLimit);
            gr.StringFormat = gr.StringFormat.ChangeAlignment(StringAlignment.Center);
            Rectangle r = new Rectangle(0, 0, 200, 30);
            gr.Font = new Font("Arial", 16);
            textBrick = gr.DrawString("ListView Report", Color.Red, r, BorderSide.None);
            textBrick.StringFormat.ChangeAlignment(StringAlignment.Center);
        }


        protected override void CreateDetailHeader(BrickGraphics gr) {
            if (listView.View != View.Details)
                return;
            gr.Modifier = BrickModifier.DetailHeader;
            gr.Font = listView.Font;
            gr.BackColor = SystemColors.Control;
            gr.ForeColor = SystemColors.ControlText;
            gr.StringFormat = new BrickStringFormat(StringFormatFlags.NoWrap);
            gr.StringFormat = gr.StringFormat.ChangeAlignment(StringAlignment.Near);
            gr.DrawString("Name", gr.ForeColor, listView.Items[0].Bounds, BorderSide.All);
        }

        protected override void CreateDetail(BrickGraphics gr) {
            gr.StringFormat = 
                new BrickStringFormat(StringFormatFlags.NoWrap | StringFormatFlags.LineLimit);
            gr.StringFormat = gr.StringFormat.ChangeLineAlignment(StringAlignment.Near);
            for (int i = 0; i < listView.Items.Count; i++) {
                gr.Font = listView.Items[i].Font;
                gr.BackColor = listView.Items[i].BackColor;
                gr.ForeColor = listView.Items[i].ForeColor;
                gr.DrawString(listView.Items[i].Text, gr.ForeColor, listView.Items[i].Bounds, 
                    BorderSide.None);
            }
        }

        protected override void CreateDetailFooter(BrickGraphics gr) {
            gr.Modifier = BrickModifier.DetailFooter;
            gr.Font = listView.Font;
            gr.BackColor = SystemColors.Control;
            gr.ForeColor = SystemColors.ControlText;
            gr.StringFormat = new BrickStringFormat(StringFormatFlags.NoWrap);
            gr.StringFormat = gr.StringFormat.ChangeAlignment(StringAlignment.Far);
            gr.DrawString("Total Items: " + Convert.ToString(listView.Items.Count), gr.ForeColor,
                new Rectangle(0, 0, 60 + listView.Items[0].Bounds.Width, listView.Items[0].Bounds.Height),
                BorderSide.All);
        }

        protected override void CreateMarginalFooter(BrickGraphics gr) {
            gr.Modifier = BrickModifier.MarginalFooter;
            string format = "Page {0} of {1}";
            PageInfoBrick brick = gr.DrawPageInfo(PageInfo.NumberOfTotal, format, Color.Black,
                new RectangleF(0, 0, 0, 20), BorderSide.None);
            brick.Alignment = BrickAlignment.Far;
            brick.AutoWidth = true;
        }

        protected override void CreateReportFooter(BrickGraphics gr) {
            gr.Modifier = BrickModifier.ReportFooter;
            gr.StringFormat = 
                new BrickStringFormat(StringFormatFlags.NoWrap | StringFormatFlags.LineLimit);
            gr.StringFormat = gr.StringFormat.ChangeLineAlignment(StringAlignment.Far);
            gr.Font = listView.Font;
            gr.DrawString("Created by John Smith", gr.ForeColor, 
                new Rectangle(0, 0, 200, 30), BorderSide.None);
        }
    }
}
