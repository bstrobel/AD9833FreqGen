namespace AD9833Control
{
    partial class MainWindowForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gbMainFreqSetting = new System.Windows.Forms.GroupBox();
            this.gbOutputEnable = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnEnableOutput = new System.Windows.Forms.Button();
            this.btnDisableOutput = new System.Windows.Forms.Button();
            this.gbOutVoltage = new System.Windows.Forms.GroupBox();
            this.tblLayPnlOutVoltage = new System.Windows.Forms.TableLayoutPanel();
            this.tbOutVoltage = new System.Windows.Forms.TrackBar();
            this.lblOutVoltage = new System.Windows.Forms.Label();
            this.lblUeff = new System.Windows.Forms.Label();
            this.btn1Vpp = new System.Windows.Forms.Button();
            this.gbFreqSetting = new System.Windows.Forms.GroupBox();
            this.tblLayPnlFrequencySliders = new System.Windows.Forms.TableLayoutPanel();
            this.lblAdjFreqHigh = new System.Windows.Forms.Label();
            this.lblAdjFreqLow = new System.Windows.Forms.Label();
            this.lblActFreq = new System.Windows.Forms.Label();
            this.lblFreqSbHz10 = new System.Windows.Forms.Label();
            this.lblFreqSbHz100 = new System.Windows.Forms.Label();
            this.lblFreqSbkHz1 = new System.Windows.Forms.Label();
            this.lblFreqSbkHz10 = new System.Windows.Forms.Label();
            this.lblFreqSbkHz100 = new System.Windows.Forms.Label();
            this.lblFreqSbMHz = new System.Windows.Forms.Label();
            this.lblFreqSbHz1 = new System.Windows.Forms.Label();
            this.tbFreqAdjust = new System.Windows.Forms.TrackBar();
            this.btnFreqAdjustReset = new System.Windows.Forms.Button();
            this.gbWaveForm = new System.Windows.Forms.GroupBox();
            this.rbWfSquare = new System.Windows.Forms.RadioButton();
            this.rbWfTriangular = new System.Windows.Forms.RadioButton();
            this.rbWfSine = new System.Windows.Forms.RadioButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusSerialPort = new System.Windows.Forms.ToolStripStatusLabel();
            this.timerSerialConnect = new System.Windows.Forms.Timer(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.tbFreqMHz = new System.Windows.Forms.NumericUpDown();
            this.tbFreqkHz100 = new System.Windows.Forms.NumericUpDown();
            this.tbFreqkHz10 = new System.Windows.Forms.NumericUpDown();
            this.tbFreqkHz1 = new System.Windows.Forms.NumericUpDown();
            this.tbFreqHz100 = new System.Windows.Forms.NumericUpDown();
            this.tbFreqHz10 = new System.Windows.Forms.NumericUpDown();
            this.tbFreqHz1 = new System.Windows.Forms.NumericUpDown();
            this.progBarOutVoltage = new AD9833ControlCustomForms.VerticalProgressBar();
            this.gbMainFreqSetting.SuspendLayout();
            this.gbOutputEnable.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.gbOutVoltage.SuspendLayout();
            this.tblLayPnlOutVoltage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbOutVoltage)).BeginInit();
            this.gbFreqSetting.SuspendLayout();
            this.tblLayPnlFrequencySliders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbFreqAdjust)).BeginInit();
            this.gbWaveForm.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbFreqMHz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbFreqkHz100)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbFreqkHz10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbFreqkHz1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbFreqHz100)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbFreqHz10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbFreqHz1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbMainFreqSetting
            // 
            this.gbMainFreqSetting.AutoSize = true;
            this.gbMainFreqSetting.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gbMainFreqSetting.Controls.Add(this.gbOutputEnable);
            this.gbMainFreqSetting.Controls.Add(this.gbOutVoltage);
            this.gbMainFreqSetting.Controls.Add(this.gbFreqSetting);
            this.gbMainFreqSetting.Controls.Add(this.gbWaveForm);
            this.gbMainFreqSetting.Location = new System.Drawing.Point(12, 12);
            this.gbMainFreqSetting.Name = "gbMainFreqSetting";
            this.gbMainFreqSetting.Size = new System.Drawing.Size(969, 320);
            this.gbMainFreqSetting.TabIndex = 0;
            this.gbMainFreqSetting.TabStop = false;
            this.gbMainFreqSetting.Text = "Main Frequency";
            // 
            // gbOutputEnable
            // 
            this.gbOutputEnable.Controls.Add(this.tableLayoutPanel1);
            this.gbOutputEnable.Location = new System.Drawing.Point(176, 205);
            this.gbOutputEnable.Name = "gbOutputEnable";
            this.gbOutputEnable.Size = new System.Drawing.Size(179, 96);
            this.gbOutputEnable.TabIndex = 13;
            this.gbOutputEnable.TabStop = false;
            this.gbOutputEnable.Text = "Output Enable";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btnEnableOutput, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnDisableOutput, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(173, 77);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnEnableOutput
            // 
            this.btnEnableOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEnableOutput.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnableOutput.ForeColor = System.Drawing.Color.Green;
            this.btnEnableOutput.Location = new System.Drawing.Point(3, 3);
            this.btnEnableOutput.Name = "btnEnableOutput";
            this.btnEnableOutput.Size = new System.Drawing.Size(167, 32);
            this.btnEnableOutput.TabIndex = 0;
            this.btnEnableOutput.Text = "Enable";
            this.btnEnableOutput.UseVisualStyleBackColor = true;
            this.btnEnableOutput.Click += new System.EventHandler(this.OutputEnable_Clicked);
            // 
            // btnDisableOutput
            // 
            this.btnDisableOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDisableOutput.Enabled = false;
            this.btnDisableOutput.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDisableOutput.Location = new System.Drawing.Point(3, 41);
            this.btnDisableOutput.Name = "btnDisableOutput";
            this.btnDisableOutput.Size = new System.Drawing.Size(167, 33);
            this.btnDisableOutput.TabIndex = 1;
            this.btnDisableOutput.Text = "Disable";
            this.btnDisableOutput.UseVisualStyleBackColor = true;
            this.btnDisableOutput.Click += new System.EventHandler(this.OutputEnable_Clicked);
            // 
            // gbOutVoltage
            // 
            this.gbOutVoltage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbOutVoltage.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gbOutVoltage.Controls.Add(this.tblLayPnlOutVoltage);
            this.gbOutVoltage.Location = new System.Drawing.Point(6, 19);
            this.gbOutVoltage.Name = "gbOutVoltage";
            this.gbOutVoltage.Size = new System.Drawing.Size(349, 179);
            this.gbOutVoltage.TabIndex = 12;
            this.gbOutVoltage.TabStop = false;
            this.gbOutVoltage.Text = "Output Voltage";
            // 
            // tblLayPnlOutVoltage
            // 
            this.tblLayPnlOutVoltage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tblLayPnlOutVoltage.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tblLayPnlOutVoltage.ColumnCount = 3;
            this.tblLayPnlOutVoltage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblLayPnlOutVoltage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblLayPnlOutVoltage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblLayPnlOutVoltage.Controls.Add(this.tbOutVoltage, 0, 2);
            this.tblLayPnlOutVoltage.Controls.Add(this.lblOutVoltage, 0, 0);
            this.tblLayPnlOutVoltage.Controls.Add(this.lblUeff, 0, 1);
            this.tblLayPnlOutVoltage.Controls.Add(this.btn1Vpp, 1, 1);
            this.tblLayPnlOutVoltage.Controls.Add(this.progBarOutVoltage, 2, 0);
            this.tblLayPnlOutVoltage.Location = new System.Drawing.Point(7, 19);
            this.tblLayPnlOutVoltage.Name = "tblLayPnlOutVoltage";
            this.tblLayPnlOutVoltage.RowCount = 3;
            this.tblLayPnlOutVoltage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblLayPnlOutVoltage.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblLayPnlOutVoltage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tblLayPnlOutVoltage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblLayPnlOutVoltage.Size = new System.Drawing.Size(336, 151);
            this.tblLayPnlOutVoltage.TabIndex = 0;
            // 
            // tbOutVoltage
            // 
            this.tblLayPnlOutVoltage.SetColumnSpan(this.tbOutVoltage, 3);
            this.tbOutVoltage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbOutVoltage.Location = new System.Drawing.Point(0, 106);
            this.tbOutVoltage.Margin = new System.Windows.Forms.Padding(0);
            this.tbOutVoltage.Maximum = 255;
            this.tbOutVoltage.Name = "tbOutVoltage";
            this.tbOutVoltage.Size = new System.Drawing.Size(336, 45);
            this.tbOutVoltage.TabIndex = 1;
            this.tbOutVoltage.TickFrequency = 16;
            this.tbOutVoltage.TickStyle = System.Windows.Forms.TickStyle.Both;
            // 
            // lblOutVoltage
            // 
            this.lblOutVoltage.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tblLayPnlOutVoltage.SetColumnSpan(this.lblOutVoltage, 2);
            this.lblOutVoltage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOutVoltage.Font = new System.Drawing.Font("Consolas", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOutVoltage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblOutVoltage.Location = new System.Drawing.Point(0, 0);
            this.lblOutVoltage.Margin = new System.Windows.Forms.Padding(0);
            this.lblOutVoltage.Name = "lblOutVoltage";
            this.lblOutVoltage.Size = new System.Drawing.Size(312, 83);
            this.lblOutVoltage.TabIndex = 9;
            this.lblOutVoltage.Text = "Û= 0,00 Vpp";
            this.lblOutVoltage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUeff
            // 
            this.lblUeff.AutoSize = true;
            this.lblUeff.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblUeff.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUeff.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUeff.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblUeff.Location = new System.Drawing.Point(0, 83);
            this.lblUeff.Margin = new System.Windows.Forms.Padding(0);
            this.lblUeff.Name = "lblUeff";
            this.lblUeff.Size = new System.Drawing.Size(156, 23);
            this.lblUeff.TabIndex = 15;
            this.lblUeff.Text = "Ueff= 0.00V";
            this.lblUeff.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn1Vpp
            // 
            this.btn1Vpp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn1Vpp.Location = new System.Drawing.Point(156, 83);
            this.btn1Vpp.Margin = new System.Windows.Forms.Padding(0);
            this.btn1Vpp.Name = "btn1Vpp";
            this.btn1Vpp.Size = new System.Drawing.Size(156, 23);
            this.btn1Vpp.TabIndex = 16;
            this.btn1Vpp.Text = "1Vpp";
            this.btn1Vpp.UseVisualStyleBackColor = true;
            this.btn1Vpp.Click += new System.EventHandler(this.btn1Vpp_Clicked);
            // 
            // gbFreqSetting
            // 
            this.gbFreqSetting.AutoSize = true;
            this.gbFreqSetting.Controls.Add(this.tblLayPnlFrequencySliders);
            this.gbFreqSetting.Location = new System.Drawing.Point(361, 19);
            this.gbFreqSetting.Name = "gbFreqSetting";
            this.gbFreqSetting.Size = new System.Drawing.Size(602, 282);
            this.gbFreqSetting.TabIndex = 11;
            this.gbFreqSetting.TabStop = false;
            this.gbFreqSetting.Text = "Output Frequency";
            // 
            // tblLayPnlFrequencySliders
            // 
            this.tblLayPnlFrequencySliders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tblLayPnlFrequencySliders.ColumnCount = 7;
            this.tblLayPnlFrequencySliders.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tblLayPnlFrequencySliders.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tblLayPnlFrequencySliders.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tblLayPnlFrequencySliders.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tblLayPnlFrequencySliders.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tblLayPnlFrequencySliders.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tblLayPnlFrequencySliders.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tblLayPnlFrequencySliders.Controls.Add(this.tbFreqHz1, 6, 1);
            this.tblLayPnlFrequencySliders.Controls.Add(this.lblAdjFreqHigh, 6, 3);
            this.tblLayPnlFrequencySliders.Controls.Add(this.tbFreqHz10, 5, 1);
            this.tblLayPnlFrequencySliders.Controls.Add(this.lblAdjFreqLow, 0, 3);
            this.tblLayPnlFrequencySliders.Controls.Add(this.tbFreqHz100, 4, 1);
            this.tblLayPnlFrequencySliders.Controls.Add(this.lblActFreq, 0, 0);
            this.tblLayPnlFrequencySliders.Controls.Add(this.tbFreqkHz1, 3, 1);
            this.tblLayPnlFrequencySliders.Controls.Add(this.tbFreqMHz, 0, 1);
            this.tblLayPnlFrequencySliders.Controls.Add(this.tbFreqkHz10, 2, 1);
            this.tblLayPnlFrequencySliders.Controls.Add(this.tbFreqAdjust, 1, 3);
            this.tblLayPnlFrequencySliders.Controls.Add(this.tbFreqkHz100, 1, 1);
            this.tblLayPnlFrequencySliders.Controls.Add(this.btnFreqAdjustReset, 2, 4);
            this.tblLayPnlFrequencySliders.Controls.Add(this.lblFreqSbMHz, 0, 2);
            this.tblLayPnlFrequencySliders.Controls.Add(this.lblFreqSbkHz100, 1, 2);
            this.tblLayPnlFrequencySliders.Controls.Add(this.lblFreqSbkHz10, 2, 2);
            this.tblLayPnlFrequencySliders.Controls.Add(this.lblFreqSbkHz1, 3, 2);
            this.tblLayPnlFrequencySliders.Controls.Add(this.lblFreqSbHz100, 4, 2);
            this.tblLayPnlFrequencySliders.Controls.Add(this.lblFreqSbHz10, 5, 2);
            this.tblLayPnlFrequencySliders.Controls.Add(this.lblFreqSbHz1, 6, 2);
            this.tblLayPnlFrequencySliders.Location = new System.Drawing.Point(6, 19);
            this.tblLayPnlFrequencySliders.Name = "tblLayPnlFrequencySliders";
            this.tblLayPnlFrequencySliders.RowCount = 5;
            this.tblLayPnlFrequencySliders.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tblLayPnlFrequencySliders.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblLayPnlFrequencySliders.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblLayPnlFrequencySliders.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblLayPnlFrequencySliders.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblLayPnlFrequencySliders.Size = new System.Drawing.Size(586, 255);
            this.tblLayPnlFrequencySliders.TabIndex = 8;
            // 
            // lblAdjFreqHigh
            // 
            this.lblAdjFreqHigh.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAdjFreqHigh.AutoSize = true;
            this.lblAdjFreqHigh.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdjFreqHigh.Location = new System.Drawing.Point(501, 170);
            this.lblAdjFreqHigh.Name = "lblAdjFreqHigh";
            this.lblAdjFreqHigh.Size = new System.Drawing.Size(82, 51);
            this.lblAdjFreqHigh.TabIndex = 15;
            this.lblAdjFreqHigh.Text = "10.000.000";
            this.lblAdjFreqHigh.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAdjFreqLow
            // 
            this.lblAdjFreqLow.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAdjFreqLow.AutoSize = true;
            this.lblAdjFreqLow.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdjFreqLow.Location = new System.Drawing.Point(3, 170);
            this.lblAdjFreqLow.Name = "lblAdjFreqLow";
            this.lblAdjFreqLow.Size = new System.Drawing.Size(77, 51);
            this.lblAdjFreqLow.TabIndex = 14;
            this.lblAdjFreqLow.Text = "100.000";
            this.lblAdjFreqLow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblActFreq
            // 
            this.lblActFreq.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblActFreq.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tblLayPnlFrequencySliders.SetColumnSpan(this.lblActFreq, 7);
            this.lblActFreq.Font = new System.Drawing.Font("Consolas", 50F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActFreq.ForeColor = System.Drawing.SystemColors.Info;
            this.lblActFreq.Location = new System.Drawing.Point(0, 0);
            this.lblActFreq.Margin = new System.Windows.Forms.Padding(0);
            this.lblActFreq.Name = "lblActFreq";
            this.lblActFreq.Size = new System.Drawing.Size(586, 100);
            this.lblActFreq.TabIndex = 2;
            this.lblActFreq.Text = "10,000,000 Hz";
            this.lblActFreq.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFreqSbHz10
            // 
            this.lblFreqSbHz10.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFreqSbHz10.AutoSize = true;
            this.lblFreqSbHz10.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFreqSbHz10.Location = new System.Drawing.Point(418, 151);
            this.lblFreqSbHz10.Name = "lblFreqSbHz10";
            this.lblFreqSbHz10.Size = new System.Drawing.Size(77, 19);
            this.lblFreqSbHz10.TabIndex = 13;
            this.lblFreqSbHz10.Text = "10 Hz";
            this.lblFreqSbHz10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFreqSbHz100
            // 
            this.lblFreqSbHz100.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFreqSbHz100.AutoSize = true;
            this.lblFreqSbHz100.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFreqSbHz100.Location = new System.Drawing.Point(335, 151);
            this.lblFreqSbHz100.Name = "lblFreqSbHz100";
            this.lblFreqSbHz100.Size = new System.Drawing.Size(77, 19);
            this.lblFreqSbHz100.TabIndex = 12;
            this.lblFreqSbHz100.Text = "100 Hz";
            this.lblFreqSbHz100.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFreqSbkHz1
            // 
            this.lblFreqSbkHz1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFreqSbkHz1.AutoSize = true;
            this.lblFreqSbkHz1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFreqSbkHz1.Location = new System.Drawing.Point(252, 151);
            this.lblFreqSbkHz1.Name = "lblFreqSbkHz1";
            this.lblFreqSbkHz1.Size = new System.Drawing.Size(77, 19);
            this.lblFreqSbkHz1.TabIndex = 11;
            this.lblFreqSbkHz1.Text = "1 kHz";
            this.lblFreqSbkHz1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFreqSbkHz10
            // 
            this.lblFreqSbkHz10.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFreqSbkHz10.AutoSize = true;
            this.lblFreqSbkHz10.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFreqSbkHz10.Location = new System.Drawing.Point(169, 151);
            this.lblFreqSbkHz10.Name = "lblFreqSbkHz10";
            this.lblFreqSbkHz10.Size = new System.Drawing.Size(77, 19);
            this.lblFreqSbkHz10.TabIndex = 10;
            this.lblFreqSbkHz10.Text = "10 kHz";
            this.lblFreqSbkHz10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFreqSbkHz100
            // 
            this.lblFreqSbkHz100.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFreqSbkHz100.AutoSize = true;
            this.lblFreqSbkHz100.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFreqSbkHz100.Location = new System.Drawing.Point(86, 151);
            this.lblFreqSbkHz100.Name = "lblFreqSbkHz100";
            this.lblFreqSbkHz100.Size = new System.Drawing.Size(77, 19);
            this.lblFreqSbkHz100.TabIndex = 9;
            this.lblFreqSbkHz100.Text = "100 kHz";
            this.lblFreqSbkHz100.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFreqSbMHz
            // 
            this.lblFreqSbMHz.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFreqSbMHz.AutoSize = true;
            this.lblFreqSbMHz.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFreqSbMHz.Location = new System.Drawing.Point(3, 151);
            this.lblFreqSbMHz.Name = "lblFreqSbMHz";
            this.lblFreqSbMHz.Size = new System.Drawing.Size(77, 19);
            this.lblFreqSbMHz.TabIndex = 8;
            this.lblFreqSbMHz.Text = " MHz";
            this.lblFreqSbMHz.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFreqSbHz1
            // 
            this.lblFreqSbHz1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFreqSbHz1.AutoSize = true;
            this.lblFreqSbHz1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFreqSbHz1.Location = new System.Drawing.Point(501, 151);
            this.lblFreqSbHz1.Name = "lblFreqSbHz1";
            this.lblFreqSbHz1.Size = new System.Drawing.Size(82, 19);
            this.lblFreqSbHz1.TabIndex = 7;
            this.lblFreqSbHz1.Text = "1 Hz";
            this.lblFreqSbHz1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbFreqAdjust
            // 
            this.tbFreqAdjust.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tblLayPnlFrequencySliders.SetColumnSpan(this.tbFreqAdjust, 5);
            this.tbFreqAdjust.LargeChange = 100;
            this.tbFreqAdjust.Location = new System.Drawing.Point(86, 173);
            this.tbFreqAdjust.Maximum = 500;
            this.tbFreqAdjust.Minimum = -500;
            this.tbFreqAdjust.Name = "tbFreqAdjust";
            this.tbFreqAdjust.Size = new System.Drawing.Size(409, 45);
            this.tbFreqAdjust.TabIndex = 2;
            this.tbFreqAdjust.TickFrequency = 100;
            this.tbFreqAdjust.TickStyle = System.Windows.Forms.TickStyle.Both;
            // 
            // btnFreqAdjustReset
            // 
            this.tblLayPnlFrequencySliders.SetColumnSpan(this.btnFreqAdjustReset, 3);
            this.btnFreqAdjustReset.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFreqAdjustReset.Location = new System.Drawing.Point(169, 224);
            this.btnFreqAdjustReset.Name = "btnFreqAdjustReset";
            this.btnFreqAdjustReset.Size = new System.Drawing.Size(243, 30);
            this.btnFreqAdjustReset.TabIndex = 24;
            this.btnFreqAdjustReset.Text = "Reset Frequency Adjustment";
            this.btnFreqAdjustReset.UseVisualStyleBackColor = true;
            this.btnFreqAdjustReset.Click += new System.EventHandler(this.btnFreqAdjustRest_Clicked);
            // 
            // gbWaveForm
            // 
            this.gbWaveForm.Controls.Add(this.rbWfSquare);
            this.gbWaveForm.Controls.Add(this.rbWfTriangular);
            this.gbWaveForm.Controls.Add(this.rbWfSine);
            this.gbWaveForm.Location = new System.Drawing.Point(6, 204);
            this.gbWaveForm.Name = "gbWaveForm";
            this.gbWaveForm.Size = new System.Drawing.Size(163, 97);
            this.gbWaveForm.TabIndex = 0;
            this.gbWaveForm.TabStop = false;
            this.gbWaveForm.Text = "Waveform";
            // 
            // rbWfSquare
            // 
            this.rbWfSquare.AutoSize = true;
            this.rbWfSquare.Location = new System.Drawing.Point(7, 68);
            this.rbWfSquare.Name = "rbWfSquare";
            this.rbWfSquare.Size = new System.Drawing.Size(61, 17);
            this.rbWfSquare.TabIndex = 2;
            this.rbWfSquare.TabStop = true;
            this.rbWfSquare.Text = "Square";
            this.rbWfSquare.UseVisualStyleBackColor = true;
            // 
            // rbWfTriangular
            // 
            this.rbWfTriangular.AutoSize = true;
            this.rbWfTriangular.Location = new System.Drawing.Point(7, 44);
            this.rbWfTriangular.Name = "rbWfTriangular";
            this.rbWfTriangular.Size = new System.Drawing.Size(85, 17);
            this.rbWfTriangular.TabIndex = 1;
            this.rbWfTriangular.TabStop = true;
            this.rbWfTriangular.Text = "Triangular";
            this.rbWfTriangular.UseVisualStyleBackColor = true;
            // 
            // rbWfSine
            // 
            this.rbWfSine.AutoSize = true;
            this.rbWfSine.Location = new System.Drawing.Point(7, 20);
            this.rbWfSine.Name = "rbWfSine";
            this.rbWfSine.Size = new System.Drawing.Size(49, 17);
            this.rbWfSine.TabIndex = 0;
            this.rbWfSine.TabStop = true;
            this.rbWfSine.Text = "Sine";
            this.rbWfSine.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusSerialPort});
            this.statusStrip1.Location = new System.Drawing.Point(0, 341);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.ShowItemToolTips = true;
            this.statusStrip1.Size = new System.Drawing.Size(990, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 1;
            // 
            // toolStripStatusSerialPort
            // 
            this.toolStripStatusSerialPort.AutoToolTip = true;
            this.toolStripStatusSerialPort.Name = "toolStripStatusSerialPort";
            this.toolStripStatusSerialPort.Size = new System.Drawing.Size(79, 17);
            this.toolStripStatusSerialPort.Text = "Disconnected";
            // 
            // timerSerialConnect
            // 
            this.timerSerialConnect.Enabled = true;
            this.timerSerialConnect.Interval = 3000;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // tbFreqMHz
            // 
            this.tbFreqMHz.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbFreqMHz.Font = new System.Drawing.Font("Consolas", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFreqMHz.Location = new System.Drawing.Point(12, 103);
            this.tbFreqMHz.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.tbFreqMHz.Name = "tbFreqMHz";
            this.tbFreqMHz.Size = new System.Drawing.Size(59, 45);
            this.tbFreqMHz.TabIndex = 2;
            this.tbFreqMHz.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbFreqkHz100
            // 
            this.tbFreqkHz100.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbFreqkHz100.Font = new System.Drawing.Font("Consolas", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFreqkHz100.Location = new System.Drawing.Point(104, 103);
            this.tbFreqkHz100.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.tbFreqkHz100.Name = "tbFreqkHz100";
            this.tbFreqkHz100.Size = new System.Drawing.Size(40, 45);
            this.tbFreqkHz100.TabIndex = 3;
            this.tbFreqkHz100.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbFreqkHz10
            // 
            this.tbFreqkHz10.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbFreqkHz10.Font = new System.Drawing.Font("Consolas", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFreqkHz10.Location = new System.Drawing.Point(187, 103);
            this.tbFreqkHz10.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.tbFreqkHz10.Name = "tbFreqkHz10";
            this.tbFreqkHz10.Size = new System.Drawing.Size(40, 45);
            this.tbFreqkHz10.TabIndex = 14;
            this.tbFreqkHz10.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbFreqkHz1
            // 
            this.tbFreqkHz1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbFreqkHz1.Font = new System.Drawing.Font("Consolas", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFreqkHz1.Location = new System.Drawing.Point(270, 103);
            this.tbFreqkHz1.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.tbFreqkHz1.Name = "tbFreqkHz1";
            this.tbFreqkHz1.Size = new System.Drawing.Size(40, 45);
            this.tbFreqkHz1.TabIndex = 14;
            this.tbFreqkHz1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbFreqHz100
            // 
            this.tbFreqHz100.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbFreqHz100.Font = new System.Drawing.Font("Consolas", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFreqHz100.Location = new System.Drawing.Point(353, 103);
            this.tbFreqHz100.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.tbFreqHz100.Name = "tbFreqHz100";
            this.tbFreqHz100.Size = new System.Drawing.Size(40, 45);
            this.tbFreqHz100.TabIndex = 14;
            this.tbFreqHz100.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbFreqHz10
            // 
            this.tbFreqHz10.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbFreqHz10.Font = new System.Drawing.Font("Consolas", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFreqHz10.Location = new System.Drawing.Point(436, 103);
            this.tbFreqHz10.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.tbFreqHz10.Name = "tbFreqHz10";
            this.tbFreqHz10.Size = new System.Drawing.Size(40, 45);
            this.tbFreqHz10.TabIndex = 14;
            this.tbFreqHz10.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbFreqHz1
            // 
            this.tbFreqHz1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbFreqHz1.Font = new System.Drawing.Font("Consolas", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFreqHz1.Location = new System.Drawing.Point(522, 103);
            this.tbFreqHz1.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.tbFreqHz1.Name = "tbFreqHz1";
            this.tbFreqHz1.Size = new System.Drawing.Size(40, 45);
            this.tbFreqHz1.TabIndex = 14;
            this.tbFreqHz1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // progBarOutVoltage
            // 
            this.progBarOutVoltage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progBarOutVoltage.Enabled = false;
            this.progBarOutVoltage.Location = new System.Drawing.Point(312, 0);
            this.progBarOutVoltage.Margin = new System.Windows.Forms.Padding(0);
            this.progBarOutVoltage.MarqueeAnimationSpeed = 0;
            this.progBarOutVoltage.Maximum = 255;
            this.progBarOutVoltage.Name = "progBarOutVoltage";
            this.tblLayPnlOutVoltage.SetRowSpan(this.progBarOutVoltage, 2);
            this.progBarOutVoltage.Size = new System.Drawing.Size(24, 106);
            this.progBarOutVoltage.TabIndex = 17;
            this.progBarOutVoltage.Value = 50;
            this.progBarOutVoltage.WarningLevel = 0;
            // 
            // MainWindowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(990, 363);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.gbMainFreqSetting);
            this.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.Name = "MainWindowForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "AD9833 Control";
            this.gbMainFreqSetting.ResumeLayout(false);
            this.gbMainFreqSetting.PerformLayout();
            this.gbOutputEnable.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.gbOutVoltage.ResumeLayout(false);
            this.tblLayPnlOutVoltage.ResumeLayout(false);
            this.tblLayPnlOutVoltage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbOutVoltage)).EndInit();
            this.gbFreqSetting.ResumeLayout(false);
            this.tblLayPnlFrequencySliders.ResumeLayout(false);
            this.tblLayPnlFrequencySliders.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbFreqAdjust)).EndInit();
            this.gbWaveForm.ResumeLayout(false);
            this.gbWaveForm.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbFreqMHz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbFreqkHz100)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbFreqkHz10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbFreqkHz1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbFreqHz100)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbFreqHz10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbFreqHz1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox gbMainFreqSetting;
        private System.Windows.Forms.GroupBox gbWaveForm;
        private System.Windows.Forms.RadioButton rbWfSquare;
        private System.Windows.Forms.RadioButton rbWfTriangular;
        private System.Windows.Forms.RadioButton rbWfSine;
        private System.Windows.Forms.TableLayoutPanel tblLayPnlFrequencySliders;
        private System.Windows.Forms.Label lblOutVoltage;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusSerialPort;
        private System.Windows.Forms.Timer timerSerialConnect;
        private System.Windows.Forms.Label lblFreqSbHz10;
        private System.Windows.Forms.Label lblFreqSbHz100;
        private System.Windows.Forms.Label lblFreqSbkHz1;
        private System.Windows.Forms.Label lblFreqSbkHz10;
        private System.Windows.Forms.Label lblFreqSbkHz100;
        private System.Windows.Forms.Label lblFreqSbMHz;
        private System.Windows.Forms.Label lblFreqSbHz1;
        private System.Windows.Forms.GroupBox gbFreqSetting;
        private System.Windows.Forms.Label lblActFreq;
        private System.Windows.Forms.GroupBox gbOutVoltage;
        private System.Windows.Forms.TableLayoutPanel tblLayPnlOutVoltage;
        private System.Windows.Forms.Label lblAdjFreqHigh;
        private System.Windows.Forms.Label lblAdjFreqLow;
        private System.Windows.Forms.TrackBar tbOutVoltage;
        private System.Windows.Forms.TrackBar tbFreqAdjust;
        private System.Windows.Forms.Label lblUeff;
        private System.Windows.Forms.Button btn1Vpp;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private AD9833ControlCustomForms.VerticalProgressBar progBarOutVoltage;
        private System.Windows.Forms.Button btnFreqAdjustReset;
        private System.Windows.Forms.GroupBox gbOutputEnable;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnEnableOutput;
        private System.Windows.Forms.Button btnDisableOutput;
        private System.Windows.Forms.NumericUpDown tbFreqHz10;
        private System.Windows.Forms.NumericUpDown tbFreqHz100;
        private System.Windows.Forms.NumericUpDown tbFreqkHz1;
        private System.Windows.Forms.NumericUpDown tbFreqkHz10;
        private System.Windows.Forms.NumericUpDown tbFreqkHz100;
        private System.Windows.Forms.NumericUpDown tbFreqMHz;
        private System.Windows.Forms.NumericUpDown tbFreqHz1;
    }
}

