using NTTSystem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static WinFormTest.MainForm;

namespace WinFormTest
{
    public partial class MainForm : Form
    {
        private CancellationTokenSource _cts;
        public enum TAB_STATE
        {
            COPY,
            FILE_SYNC,
            FOLDER_BACKUP
        }
        private TAB_STATE _tab_state;

        public NTTSystem.SystemSettingFile _system_setting_file;

        public bool is_sync_on { get; set; }
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
            h_switch_tab(TAB_STATE.COPY);
            _system_setting_file = new NTTSystem.SystemSettingFile();
            lstvFileSync.Columns.Add("from_path", 275);
            lstvFileSync.Columns.Add("to_path", 275);
            lstvFolderBackupBackup.Columns.Add("write_path", 351);
            lstvFolderBackupTarget.Columns.Add("target_path", 275);
            lstvFolderBackupTarget.Columns.Add("backup_path", 275);

            is_sync_on = false;
        }
        private async void StartBackgroundUpdate(CancellationToken token)
        {
            try
            {
                while (!token.IsCancellationRequested)
                {
                    Invoke(new Action(() =>
                    {
                        NextTimeTsuyu2.Backup backup = _system_setting_file._copy._backup;
                        if (backup != null)
                        {
                            if (backup.get_state == NextTimeTsuyu2.Backup.STATE.END)
                            {
                                lblCopyStatus.Text = $"total:{backup.get_memory_cluster.get_total_byte_size}|" +
                                $"time:{backup.get_end_time - backup.get_start_time}";
                            }
                            else
                            {
                                lblCopyStatus.Text = $"total:{backup.get_memory_cluster.get_total_byte_size}|" +
                                $"use:{backup.get_memory_cluster.get_use_byte_size}|" +
                                $"worked:{backup.get_memory_cluster.get_worked_byte_size}";
                                pgbCopy.Value = (int)((double)pgbCopy.Maximum * ((double)backup.get_memory_cluster.get_worked_byte_size
                                / (double)(backup.get_memory_cluster.get_total_byte_size == 0 ? 1 : backup.get_memory_cluster.get_total_byte_size)));
                            }
                        }

                        _system_setting_file.h_day_from_update();
                        _system_setting_file.h_sync_update();
                        if(_system_setting_file._day_from_selected !=null)
                        {
                            lstvBackupBackupUpdate(_system_setting_file._day_from_selected);
                        }
                    }));
                    await Task.Delay(100, token); // 1초마다 실행 (취소 가능)
                }
            }
            catch
            {

            }
        }

        private void settingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingForm settingform = new SettingForm(_system_setting_file._setting);
            settingform.ShowDialog();
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
            _cts = new CancellationTokenSource();
            StartBackgroundUpdate(_cts.Token);
        }

        private void btnFileSyncTargetLoadFileSystem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "파일 선택";
                openFileDialog.Filter = "모든 파일 (*.*)|*.*"; // 파일 필터 설정
                openFileDialog.Multiselect = false; // 여러 개 선택 비활성화

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txbFileSyncTargetPath
                    .Text = openFileDialog.FileName; // 선택한 파일 경로 출력
                }
            }
        }

        private void btnFileSyncSyncLoadFileSystem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "파일 선택";
                openFileDialog.Filter = "모든 파일 (*.*)|*.*"; // 파일 필터 설정
                openFileDialog.Multiselect = false; // 여러 개 선택 비활성화

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txbFileSyncSyncPath
                    .Text = openFileDialog.FileName; // 선택한 파일 경로 출력
                }
            }
        }


        private void btnCopyFromLoadFileSystem_Click(object sender, EventArgs e)
        {

            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog
            {
                Description = "폴더 선택"
            };

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                txbCopyFromPath.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void btnCopyToLoadFileSystem_Click(object sender, EventArgs e)
        {

            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog
            {
                Description = "폴더 선택"
            };

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                txbCopyToPath.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void btnCopyCopy_Click(object sender, EventArgs e)
        {
            NextTimeTsuyu2.Backup bu = _system_setting_file.h_copy();
            if (bu == null)
                MessageBox.Show("디렉토리 복사 실패");
            MessageBox.Show("디렉토리 복사 완료");
        }

        private void ckbFolderBackupMon_CheckedChanged(object sender, EventArgs e)
        {
            if (_system_setting_file._day_from_selected != null)
                _system_setting_file._day_from_selected._mon =
                ckbFolderBackupMon.Checked;
            else
                ckbFolderBackupMon.Checked = false;
        }

        private void txbFileSyncTargetPath_TextChanged(object sender, EventArgs e)
        {

        }

        private void txbFileSyncSyncPath_TextChanged(object sender, EventArgs e)
        {

        }

        private void txbFolderBackupTargetPath_TextChanged(object sender, EventArgs e)
        {
            NTTSystem.DayFrom df = _system_setting_file.h_day_from_search(txbFolderBackupTargetPath.Text);
            if (df == null)
            {
                lstvFolderBackupBackup.Items.Clear();
                _system_setting_file._day_from_selected = null;
                ckbClear();
            }
            else
            {
                _system_setting_file._day_from_selected = df;
                ckbUpdate(df);
            }
        }
        private void ckbClear()
        {
            ckbFolderBackupMon.Checked = false;
            ckbFolderBackupTue.Checked = false;
            ckbFolderBackupWed.Checked = false;
            ckbFolderBackupThu.Checked = false;
            ckbFolderBackupFri.Checked = false;
            ckbFolderBackupSat.Checked = false;
            ckbFolderBackupSun.Checked = false;

            ckbFolderBackupRun.Checked = false;
        }
        private void lstvBackupBackupUpdate(DayFrom dayfrom)
        {
            lstvFolderBackupBackup.Items.Clear();
            if (dayfrom._day_to_list == null)
                return;
            foreach (DayTo dayto in dayfrom._day_to_list)
            {
                if (dayto != null)
                {
                    lstvFolderBackupBackup.Items.Add(dayto._write_path);
                    lstvFolderBackupBackup.Columns[0].Width = 351;
                }
            }
        }
        private void ckbUpdate(DayFrom dayfrom)
        {
            ckbFolderBackupMon.Checked = dayfrom._mon;
            ckbFolderBackupTue.Checked = dayfrom._tue;
            ckbFolderBackupWed.Checked = dayfrom._wed;
            ckbFolderBackupThu.Checked = dayfrom._thu;
            ckbFolderBackupFri.Checked = dayfrom._fri;
            ckbFolderBackupSat.Checked = dayfrom._sat;
            ckbFolderBackupSun.Checked = dayfrom._sun;

            ckbFolderBackupRun.Checked = dayfrom._run;
        }
        private void txbFolderBackupBackupPath_TextChanged(object sender, EventArgs e)
        {
            if (_system_setting_file._day_from_selected == null)
                return;
            DayTo dt = _system_setting_file._day_from_selected.h_day_to_search(
                txbCopyFromPath.Text
                );
            if (dt == null)
                return;
            _system_setting_file._day_from_selected._day_to_selected = dt;
        }

        private void ckbFolderBackupTue_CheckedChanged(object sender, EventArgs e)
        {

            if (_system_setting_file._day_from_selected != null)
                _system_setting_file._day_from_selected._tue =
                ckbFolderBackupTue.Checked;
            else
                ckbFolderBackupTue.Checked = false;
        }

        private void ckbFolderBackupWed_CheckedChanged(object sender, EventArgs e)
        {

            if (_system_setting_file._day_from_selected != null)
                _system_setting_file._day_from_selected._wed =
                ckbFolderBackupWed.Checked;
            else
                ckbFolderBackupWed.Checked = false;
        }

        private void ckbFolderBackupThu_CheckedChanged(object sender, EventArgs e)
        {

            if (_system_setting_file._day_from_selected != null)
                _system_setting_file._day_from_selected._thu =
                ckbFolderBackupThu.Checked;
            else
                ckbFolderBackupThu.Checked = false;
        }

        private void ckbFolderBackupFri_CheckedChanged(object sender, EventArgs e)
        {

            if (_system_setting_file._day_from_selected != null)
                _system_setting_file._day_from_selected._fri =
                ckbFolderBackupFri.Checked;
            else
                ckbFolderBackupFri.Checked = false;
        }

        private void ckbFolderBackupSat_CheckedChanged(object sender, EventArgs e)
        {

            if (_system_setting_file._day_from_selected != null)
                _system_setting_file._day_from_selected._sat =
                ckbFolderBackupSat.Checked;
            else
                ckbFolderBackupSat.Checked = false;
        }

        private void ckbFolderBackupSun_CheckedChanged(object sender, EventArgs e)
        {

            if (_system_setting_file._day_from_selected != null)
                _system_setting_file._day_from_selected._sun =
                ckbFolderBackupSun.Checked;
            else
                ckbFolderBackupSun.Checked = false;
        }

        private void ckbFolderBackupRun_CheckedChanged(object sender, EventArgs e)
        {

            if (_system_setting_file._day_from_selected != null)
                _system_setting_file._day_from_selected._run =
                ckbFolderBackupRun.Checked;
            else
                ckbFolderBackupRun.Checked = false;
        }

        private void btnFolderBackupAdd_Click(object sender, EventArgs e)
        {
            string from_path = txbFolderBackupTargetPath.Text;
            string to_path = txbFolderBackupBackupPath.Text;
            if (from_path.Split('\\').Length < 4)
            {
                MessageBox.Show("타겟 경로가 너무 짧습니다.");
                return;
            }
            if (to_path.Split('\\').Length < 4)
            {
                MessageBox.Show("백업 경로가 너무 짧습니다.");
                return;
            }
            if (from_path == to_path)
            {
                MessageBox.Show("타겟 경로와 백업 경로가 같습니다.");
                return;
            }
            if (!Directory.Exists(from_path))
            {
                MessageBox.Show("타겟 경로에 디렉토리가 없습니다");
                return;
            }
            if (!Directory.Exists(to_path))
            {
                MessageBox.Show("백업 경로에 디렉토리가 없습니다");
                return;
            }
            DayFrom df = _system_setting_file.h_day_from_add(from_path, to_path);
            if (df == null) return;

            lstvFolderBackupTarget.Items.Clear();
            _system_setting_file._day_from_selected = df;
            ckbUpdate(df);
            foreach (DayFrom aa in _system_setting_file._day_from_list)
            {
                lstvFolderBackupTarget.Items.Add(new ListViewItem(new[] { aa._from_path, aa._to_path }));
            }
            MessageBox.Show("백업 디렉토리 추가 완료");
        }

        private void btnFolderBackupCopy_Click(object sender, EventArgs e)
        {
            DayFrom df = _system_setting_file._day_from_selected;
            if (df == null)
            {
                MessageBox.Show("선택한 백업 디렉토리가 없습니다.");
                return;
            }

            DayTo dt = df.h_day_to_backup(_system_setting_file._setting);
            if (dt != null)
            {
                df._day_to_list.Add(dt);
            }
            MessageBox.Show("현재 시간으로 백업 완료");
        }

        private void btnFolderBackupRestore_Click(object sender, EventArgs e)
        {
            DayFrom df = _system_setting_file._day_from_selected;
            if (df == null)
            {
                MessageBox.Show("선택된 백업 디렉토리가 없습니다"); 
                return; }
            if (df._day_to_selected == null) 
            {
                MessageBox.Show("선택된 백업시킬 디렉토리가 없습니다");
                return;
            }
            df._day_to_selected.h_restore(_system_setting_file._setting);
            MessageBox.Show("복원중입니다.");
        }
        private void lstvSyncUpdate()
        {
            lstvFileSync.Items.Clear();

            foreach (Sync e in _system_setting_file._sync_list)
            {
                string from_file_name = new FileInfo(e._from_path).Name;
                string to_file_name = new FileInfo(e._to_path).Name;
                lstvFileSync.Items.Add(new ListViewItem(new string[] { from_file_name, to_file_name }));
            }
        }
        private void btnFileSyncAdd_Click(object sender, EventArgs e)
        {
            string from_path = txbFileSyncTargetPath.Text;
            string to_path = txbFileSyncSyncPath.Text;
            if (from_path.Split("\\").Length < 4)
            {
                MessageBox.Show("싱크로 할 파일의 경로가 너무 짧습니다");
                return;
            }

            if (to_path.Split("\\").Length < 4)
            {
                MessageBox.Show("싱크로 시킬 파일의 경로가 너무 짧습니다");
                return;
            }
            if (from_path == to_path)
            {
                MessageBox.Show("싱크로 시킬 파일과 싱크로 할 파일의 경로가 같습니다");
                return;
            }
            if (!File.Exists(from_path))
            {
                MessageBox.Show("싱크로 할 파일의 경로에 파일이 없습니다.");
                return;
            }

            if (!File.Exists(to_path))
            {
                MessageBox.Show("싱크로 시킬 파일의 경로에 파일이 없습니다.");
                return;
            }

            foreach (Sync a in _system_setting_file._sync_list)
            {
                if (a._from_path == from_path)
                {
                    MessageBox.Show("이미 싱크로 중인 경로입니다.");
                    return;
                }
                if (a._to_path == to_path)
                {
                    MessageBox.Show("이미 싱크로 중인 경로입니다.");
                    return;
                }
            }
            _system_setting_file.h_sync_add(from_path, to_path);
            lstvSyncUpdate();
            MessageBox.Show("싱크로 파일 셋팅 완료.");
        }

        private void btnFileSyncCopy_Click(object sender, EventArgs e)
        {
            bool issync = _system_setting_file.h_all_sync();
            if (issync)
            {
                lstvSyncUpdate();
                MessageBox.Show("복사중입니다.");
            }
            else
            {
                MessageBox.Show("아직 Sync 중인 파일이 있어 복사가 불가능합니다.");
            }
        }

        private void btnFileSyncChange_Click(object sender, EventArgs e)
        {
            if (!is_sync_on)
            {
                _system_setting_file.h_all_sync_swap();
                lstvSyncUpdate();
                MessageBox.Show("Sync Swap!");
            }
        }

        private void btnFileSyncSync_Click(object sender, EventArgs e)
        {
            bool a = !is_sync_on;
            is_sync_on = a;
            lblFileSyncStatus.Text = "Sync : " + (is_sync_on ? "on" : "off");
            if (a)
            {
                btnFileSyncChange.Visible = false;
                button1.Visible           = false;
                btnFileSyncAdd.Visible    = false;
                btnFileSyncChange.Visible = false;
                btnFileSyncCopy.Visible  = false;
            }
            else
            {
                btnFileSyncChange.Visible = true;
                button1.Visible = true;
                btnFileSyncAdd.Visible = true;
                btnFileSyncChange.Visible = true;
                btnFileSyncCopy.Visible = true;
            }
        }

        private void txbCopyFromPath_TextChanged(object sender, EventArgs e)
        {
            string path = txbCopyFromPath.Text;
            trvCopyFrom.Nodes.Clear(); // 기존 트리 뷰 초기화

            if (path.Split("\\").Length < 4)
                return;

            _system_setting_file._copy._from_path = path;
            if (File.Exists(path))
            {
                // 파일이면 부모 노드로 추가
                trvCopyFrom.Nodes.Add(new TreeNode(Path.GetFileName(path)));
            }
            else if (Directory.Exists(path))
            {
                // 디렉터리면 트리 뷰를 생성
                TreeNode rootNode = new TreeNode(path);
                trvCopyFrom.Nodes.Add(rootNode);
                LoadDirectory(path, rootNode);
            }
        }
        private void LoadDirectory(string dir, TreeNode parentNode)
        {
            try
            {
                string[] directories = Directory.GetDirectories(dir);
                string[] files = Directory.GetFiles(dir);

                foreach (string directory in directories)
                {
                    TreeNode dirNode = new TreeNode(Path.GetFileName(directory));
                    parentNode.Nodes.Add(dirNode);
                    LoadDirectory(directory, dirNode); // 재귀 호출
                }

                foreach (string file in files)
                {
                    TreeNode fileNode = new TreeNode(Path.GetFileName(file));
                    parentNode.Nodes.Add(fileNode);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("오류 발생: " + ex.Message);
            }
        }
        private void txbCopyToPath_TextChanged(object sender, EventArgs e)
        {

            string path = txbCopyToPath.Text;
            trvCopyTo.Nodes.Clear(); // 기존 트리 뷰 초기화
            if (path.Split("\\").Length < 4)
                return;

            _system_setting_file._copy._to_path = path;
            if (File.Exists(path))
            {
                // 파일이면 부모 노드로 추가
                trvCopyTo.Nodes.Add(new TreeNode(Path.GetFileName(path)));
            }
            else if (Directory.Exists(path))
            {
                // 디렉터리면 트리 뷰를 생성
                TreeNode rootNode = new TreeNode(path);
                trvCopyTo.Nodes.Add(rootNode);
                LoadDirectory(path, rootNode);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _cts.Cancel(); // 스레드 안전하게 중지
        }

        private void btnFolderTargetLoadFileSystem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog
            {
                Description = "폴더 선택"
            };

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                txbFolderBackupTargetPath.Text
                    = folderBrowserDialog.SelectedPath;
            }
        }

        private void btnFolderBackupLoadFileSystem_Click_1(object sender, EventArgs e)
        {

            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog
            {
                Description = "폴더 선택"
            };

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                txbFolderBackupBackupPath.Text
                    = folderBrowserDialog.SelectedPath;
            }
        }

        private void lstvFolderBackupBackup_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            string day_to_write_string = lstvFolderBackupBackup.Columns[e.Column].Text;
            if (_system_setting_file._day_from_selected == null)
                return;
            DayTo dt = _system_setting_file._day_from_selected.h_day_to_search(day_to_write_string);

            if (dt != null)
            {
                _system_setting_file._day_from_selected._day_to_selected = dt;
                txbFolderBackupBackupPath.Text = dt.ToString();
            }
        }

        private void lstvFolderBackupTarget_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstvFolderBackupTarget.FocusedItem != null) // 현재 클릭한 아이템이 있는지 확인
            {
                string selectedValue = lstvFolderBackupTarget.FocusedItem.SubItems[0].Text; // 첫 번째 컬럼 값 가져오기
                txbFolderBackupTargetPath.Text = selectedValue;
            }
        }

        //Delete
        private void button1_Click(object sender, EventArgs e)
        {
            int index = lstvFileSync.FocusedItem.Index;
            if (index < 0 || index >= _system_setting_file._sync_list.Count)
            {
                MessageBox.Show("삭제시킬 Sync 가 없습니다.");
                return;
            }
            _system_setting_file._sync_list.RemoveAt(index);
            lstvSyncUpdate();
            MessageBox.Show("Sync 삭제 완료.");
        }
    }
}
