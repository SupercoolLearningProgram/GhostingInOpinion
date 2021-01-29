using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
namespace GhostingInOpinion
{
    public partial class Dashboard : Form
    { 
        // Dragging Menustrips variable and library.
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd,
                 int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        private static extern bool ReleaseCapture();
        // Dragging Menustrips variable and library.

        public Dashboard()
        {
            LoginForm g = new LoginForm();
            g.Show;
            InitializeComponent(); 
        }

        // Window Form shadow dropping (Decoration)
        private const int CS_DropShadow = 0x00020000;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DropShadow;
                return cp;
            }
        }
        // Window Form shadow dropping (Decoration)


        // Dragging Menustrips Event capture
        private void menuStrip1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void menuStrip1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!Focused)
            {
                Focus();
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void Dashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }

        }
        // Dragging Menustrips Event capture
    }
}
