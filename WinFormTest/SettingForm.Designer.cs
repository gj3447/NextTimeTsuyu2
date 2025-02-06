namespace WinFormTest
{
    partial class SettingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tkbChunkSize = new TrackBar();
            lblChunkSize = new Label();
            cbbLoadBalancerType = new ComboBox();
            tkbMaxMemory = new TrackBar();
            lblMaxMemory = new Label();
            nudWorkerCount = new NumericUpDown();
            lblLoadBalancerType = new Label();
            lblWorkerCount = new Label();
            lblProcessCounter = new Label();
            ((System.ComponentModel.ISupportInitialize)tkbChunkSize).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tkbMaxMemory).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudWorkerCount).BeginInit();
            SuspendLayout();
            // 
            // tkbChunkSize
            // 
            tkbChunkSize.LargeChange = 1024;
            tkbChunkSize.Location = new Point(45, 62);
            tkbChunkSize.Maximum = 4194304;
            tkbChunkSize.Minimum = 1024;
            tkbChunkSize.Name = "tkbChunkSize";
            tkbChunkSize.Size = new Size(330, 45);
            tkbChunkSize.SmallChange = 1024;
            tkbChunkSize.TabIndex = 0;
            tkbChunkSize.Value = 1024;
            tkbChunkSize.Scroll += tkbChunkSize_Scroll;
            // 
            // lblChunkSize
            // 
            lblChunkSize.AutoSize = true;
            lblChunkSize.Location = new Point(182, 44);
            lblChunkSize.Name = "lblChunkSize";
            lblChunkSize.Size = new Size(64, 15);
            lblChunkSize.TabIndex = 1;
            lblChunkSize.Text = "ChunkSize";
            // 
            // cbbLoadBalancerType
            // 
            cbbLoadBalancerType.FormattingEnabled = true;
            cbbLoadBalancerType.Location = new Point(237, 239);
            cbbLoadBalancerType.Name = "cbbLoadBalancerType";
            cbbLoadBalancerType.Size = new Size(138, 23);
            cbbLoadBalancerType.TabIndex = 2;
            cbbLoadBalancerType.SelectedIndexChanged += cbbLoadBalancerType_SelectedIndexChanged;
            // 
            // tkbMaxMemory
            // 
            tkbMaxMemory.LargeChange = 1048576;
            tkbMaxMemory.Location = new Point(37, 131);
            tkbMaxMemory.Maximum = 16777216;
            tkbMaxMemory.Minimum = 1048576;
            tkbMaxMemory.Name = "tkbMaxMemory";
            tkbMaxMemory.Size = new Size(330, 45);
            tkbMaxMemory.SmallChange = 1048576;
            tkbMaxMemory.TabIndex = 4;
            tkbMaxMemory.Value = 1048576;
            tkbMaxMemory.Scroll += tkbMaxMemory_Scroll;
            // 
            // lblMaxMemory
            // 
            lblMaxMemory.AutoSize = true;
            lblMaxMemory.Location = new Point(182, 113);
            lblMaxMemory.Name = "lblMaxMemory";
            lblMaxMemory.Size = new Size(75, 15);
            lblMaxMemory.TabIndex = 5;
            lblMaxMemory.Text = "MaxMemory";
            // 
            // nudWorkerCount
            // 
            nudWorkerCount.Location = new Point(39, 241);
            nudWorkerCount.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudWorkerCount.Name = "nudWorkerCount";
            nudWorkerCount.Size = new Size(138, 23);
            nudWorkerCount.TabIndex = 6;
            nudWorkerCount.Value = new decimal(new int[] { 1, 0, 0, 0 });
            nudWorkerCount.ValueChanged += nudWorkerCount_ValueChanged;
            // 
            // lblLoadBalancerType
            // 
            lblLoadBalancerType.AutoSize = true;
            lblLoadBalancerType.Location = new Point(237, 211);
            lblLoadBalancerType.Name = "lblLoadBalancerType";
            lblLoadBalancerType.Size = new Size(108, 15);
            lblLoadBalancerType.TabIndex = 7;
            lblLoadBalancerType.Text = "load_balancer_type";
            // 
            // lblWorkerCount
            // 
            lblWorkerCount.AutoSize = true;
            lblWorkerCount.Location = new Point(45, 216);
            lblWorkerCount.Name = "lblWorkerCount";
            lblWorkerCount.Size = new Size(79, 15);
            lblWorkerCount.TabIndex = 8;
            lblWorkerCount.Text = "worker_count";
            // 
            // lblProcessCounter
            // 
            lblProcessCounter.AutoSize = true;
            lblProcessCounter.Location = new Point(44, 283);
            lblProcessCounter.Name = "lblProcessCounter";
            lblProcessCounter.Size = new Size(39, 15);
            lblProcessCounter.TabIndex = 9;
            lblProcessCounter.Text = "label1";
            // 
            // SettingForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(405, 307);
            Controls.Add(lblProcessCounter);
            Controls.Add(lblWorkerCount);
            Controls.Add(lblLoadBalancerType);
            Controls.Add(nudWorkerCount);
            Controls.Add(lblMaxMemory);
            Controls.Add(tkbMaxMemory);
            Controls.Add(cbbLoadBalancerType);
            Controls.Add(lblChunkSize);
            Controls.Add(tkbChunkSize);
            Name = "SettingForm";
            Text = "SettingForm";
            ((System.ComponentModel.ISupportInitialize)tkbChunkSize).EndInit();
            ((System.ComponentModel.ISupportInitialize)tkbMaxMemory).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudWorkerCount).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TrackBar tkbChunkSize;
        private Label lblChunkSize;
        private ComboBox cbbLoadBalancerType;
        private TrackBar tkbMaxMemory;
        private Label lblMaxMemory;
        private NumericUpDown nudWorkerCount;
        private Label lblLoadBalancerType;
        private Label lblWorkerCount;
        private Label lblProcessCounter;
    }
}