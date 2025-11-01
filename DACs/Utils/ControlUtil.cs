using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DACs.Utils
{
    public static class ControlUtil
    {
        public static void LoadContentControl(UserControl userControl, Panel panel)
        {
            panel.Controls.Clear();
            userControl.Dock = DockStyle.Fill;
            panel.Controls.Add(userControl);
            userControl.BringToFront();
        }
        public static void LoadForm(Form currentForm, Form newForm)
        {
            newForm.StartPosition = FormStartPosition.CenterScreen;
            newForm.Show();
            currentForm.Hide();

            newForm.FormClosed += (s, e) => currentForm.Close();
        }
    }
}
