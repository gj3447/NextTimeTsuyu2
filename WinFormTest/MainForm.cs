using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static WinFormTest.MainForm;

namespace WinFormTest
{
    public partial class MainForm : Form
    {
        public enum TAB_STATE
        {
            COPY,
            FILE_SYNC,
            FOLDER_BACKUP
        }
        private TAB_STATE _tab_state;
        public void h_switch_tab(TAB_STATE tab_state)
        {
            this._tab_state = tab_state;
            switch (tab_state)
            {
                case TAB_STATE.COPY:
                    pnlCopy.Visible = true;
                    pnlFileSync.Visible = false;
                    pnlFolderBackup.Visible = false;
                    break;

                case TAB_STATE.FILE_SYNC:
                    pnlCopy.Visible = false;
                    pnlFileSync.Visible = true;
                    pnlFolderBackup.Visible = false;
                    break;

                case TAB_STATE.FOLDER_BACKUP:
                    pnlCopy.Visible = false;
                    pnlFileSync.Visible = false;
                    pnlFolderBackup.Visible = true;
                    break;
            }
        }
        public MainForm()
        {
            InitializeComponent();
        }

        private void settingToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void btnPanelChangeCopy_Click(object sender, EventArgs e)
        {
            h_switch_tab(TAB_STATE.COPY);
        }

        private void btnPanelChangeFileSync_Click(object sender, EventArgs e)
        {
            h_switch_tab(TAB_STATE.FILE_SYNC);
        }

        private void btnPanelChangeFolderBackup_Click(object sender, EventArgs e)
        {
            h_switch_tab(TAB_STATE.FOLDER_BACKUP);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
