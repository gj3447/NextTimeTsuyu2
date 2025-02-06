using NextTimeTsuyu2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormTest
{
    public partial class SettingForm : Form
    {
        NextTimeTsuyu2.Setting _setting;
        public SettingForm(NextTimeTsuyu2.Setting setting)
        {
            _setting = setting;
            InitializeComponent();
            tkbChunkSize.Value = setting.get_chunk_size;
            tkbMaxMemory.Value = (int)setting.get_memory_size;
            nudWorkerCount.Value = setting.get_worker_count;
            cbbLoadBalancerType.DataSource = Enum.GetValues(typeof(NextTimeTsuyu2.LoadBalancer.TYPE));
            lblChunkSize.Text = $"chunk_size : {_setting.get_chunk_size}";
            lblMaxMemory.Text = $"memory_size : {_setting.get_memory_size}";
            lblProcessCounter.Text = $"PC core count = {Environment.ProcessorCount}";
        }


        private void tkbChunkSize_Scroll(object sender, EventArgs e)
        {
            _setting.set_chunk_size = (int)tkbChunkSize.Value;
            lblChunkSize.Text = $"chunk_size : {_setting.get_chunk_size}";

        }

        private void tkbMaxMemory_Scroll(object sender, EventArgs e)
        {
            _setting.set_memory_size = (int)tkbMaxMemory.Value;
            lblMaxMemory.Text = $"memory_size : {_setting.get_memory_size}";
        }

        private void nudWorkerCount_ValueChanged(object sender, EventArgs e)
        {
            _setting.set_worker_count = (int)nudWorkerCount.Value;
        }

        private void cbbLoadBalancerType_SelectedIndexChanged(object sender, EventArgs e)
        {
            _setting.set_load_balancer_type = (NextTimeTsuyu2.LoadBalancer.TYPE)cbbLoadBalancerType.SelectedItem;

        }
    }
}
