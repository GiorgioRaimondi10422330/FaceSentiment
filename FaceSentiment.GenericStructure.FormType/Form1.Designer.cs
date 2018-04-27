namespace FaceSentiment.GenericStructure.FormType
{
    partial class AcquisitionForm
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
            this.ShowBox = new System.Windows.Forms.PictureBox();
            this.StartStream_Button = new System.Windows.Forms.Button();
            this.StopStream_Button = new System.Windows.Forms.Button();
            this.StartSaving_Button = new System.Windows.Forms.Button();
            this.StopSave_Button = new System.Windows.Forms.Button();
            this.OutputResult = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.StreamConnection_Box = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.DatabaseConnection_Box = new System.Windows.Forms.TextBox();
            this.FaceApiKey_Box = new System.Windows.Forms.TextBox();
            this.FaceApiUri_Box = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Reset_Button = new System.Windows.Forms.Button();
            this.TrackPrecision_ComboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SecondForAnalysis_ComboBox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.VideoStatus = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.SaveStatus = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.ComputerCamera_checkBox = new System.Windows.Forms.CheckBox();
            this.Save_ProgresBar = new System.Windows.Forms.ProgressBar();
            this.UseFreeApi_CheckBox = new System.Windows.Forms.CheckBox();
            this.WarningPay_Label = new System.Windows.Forms.Label();
            this.User_TextBox = new System.Windows.Forms.TextBox();
            this.Password_TextBox = new System.Windows.Forms.TextBox();
            this.User_Label = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.settaggiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dimensioneMinimaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minimalDimensionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FaceMD_toolStripComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.percentageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FacePerc_toolStripComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.Faceneighboors_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FaceNeighboor_toolStripComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.percentualeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minimalDimensionToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.EyeMinimal_toolStripComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.percentageToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.EyePerc_toolStripComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.neighboorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EyeNeighBoors_toolStripComboBox2 = new System.Windows.Forms.ToolStripComboBox();
            this.cameraSettingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newCameraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectCameraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SelectCamera_toolStripComboBox = new System.Windows.Forms.ToolStripComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.ShowBox)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ShowBox
            // 
            this.ShowBox.Location = new System.Drawing.Point(299, 36);
            this.ShowBox.Name = "ShowBox";
            this.ShowBox.Size = new System.Drawing.Size(1313, 720);
            this.ShowBox.TabIndex = 0;
            this.ShowBox.TabStop = false;
            // 
            // StartStream_Button
            // 
            this.StartStream_Button.Location = new System.Drawing.Point(21, 217);
            this.StartStream_Button.Name = "StartStream_Button";
            this.StartStream_Button.Size = new System.Drawing.Size(172, 51);
            this.StartStream_Button.TabIndex = 1;
            this.StartStream_Button.Text = "Start Stream";
            this.StartStream_Button.UseVisualStyleBackColor = true;
            this.StartStream_Button.Click += new System.EventHandler(this.StartStream_Button_Click);
            // 
            // StopStream_Button
            // 
            this.StopStream_Button.Location = new System.Drawing.Point(21, 274);
            this.StopStream_Button.Name = "StopStream_Button";
            this.StopStream_Button.Size = new System.Drawing.Size(172, 51);
            this.StopStream_Button.TabIndex = 2;
            this.StopStream_Button.Text = "Stop Stream";
            this.StopStream_Button.UseVisualStyleBackColor = true;
            this.StopStream_Button.Click += new System.EventHandler(this.StopStream_Button_Click);
            // 
            // StartSaving_Button
            // 
            this.StartSaving_Button.Location = new System.Drawing.Point(21, 509);
            this.StartSaving_Button.Name = "StartSaving_Button";
            this.StartSaving_Button.Size = new System.Drawing.Size(172, 51);
            this.StartSaving_Button.TabIndex = 3;
            this.StartSaving_Button.Text = "Start Saving";
            this.StartSaving_Button.UseVisualStyleBackColor = true;
            this.StartSaving_Button.Click += new System.EventHandler(this.StartSaving_Button_Click);
            // 
            // StopSave_Button
            // 
            this.StopSave_Button.Location = new System.Drawing.Point(21, 566);
            this.StopSave_Button.Name = "StopSave_Button";
            this.StopSave_Button.Size = new System.Drawing.Size(172, 51);
            this.StopSave_Button.TabIndex = 4;
            this.StopSave_Button.Text = "Stop Saving";
            this.StopSave_Button.UseVisualStyleBackColor = true;
            this.StopSave_Button.Click += new System.EventHandler(this.StopSave_Button_Click);
            // 
            // OutputResult
            // 
            this.OutputResult.AutoSize = true;
            this.OutputResult.Location = new System.Drawing.Point(17, 772);
            this.OutputResult.Name = "OutputResult";
            this.OutputResult.Size = new System.Drawing.Size(64, 20);
            this.OutputResult.TabIndex = 5;
            this.OutputResult.Text = "Nothing";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 640);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Stream Status:";
            // 
            // StreamConnection_Box
            // 
            this.StreamConnection_Box.Location = new System.Drawing.Point(12, 67);
            this.StreamConnection_Box.Name = "StreamConnection_Box";
            this.StreamConnection_Box.Size = new System.Drawing.Size(231, 26);
            this.StreamConnection_Box.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Stream Connection Ip";
            // 
            // DatabaseConnection_Box
            // 
            this.DatabaseConnection_Box.Location = new System.Drawing.Point(12, 357);
            this.DatabaseConnection_Box.Name = "DatabaseConnection_Box";
            this.DatabaseConnection_Box.Size = new System.Drawing.Size(231, 26);
            this.DatabaseConnection_Box.TabIndex = 9;
            // 
            // FaceApiKey_Box
            // 
            this.FaceApiKey_Box.Location = new System.Drawing.Point(12, 410);
            this.FaceApiKey_Box.Name = "FaceApiKey_Box";
            this.FaceApiKey_Box.Size = new System.Drawing.Size(231, 26);
            this.FaceApiKey_Box.TabIndex = 10;
            // 
            // FaceApiUri_Box
            // 
            this.FaceApiUri_Box.Location = new System.Drawing.Point(12, 462);
            this.FaceApiUri_Box.Name = "FaceApiUri_Box";
            this.FaceApiUri_Box.Size = new System.Drawing.Size(231, 26);
            this.FaceApiUri_Box.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 334);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(208, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "DataBase ConnectionString";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 386);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 20);
            this.label4.TabIndex = 13;
            this.label4.Text = "Face Api Key";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 439);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 20);
            this.label5.TabIndex = 14;
            this.label5.Text = "Face Api UriBase";
            // 
            // Reset_Button
            // 
            this.Reset_Button.Location = new System.Drawing.Point(703, 789);
            this.Reset_Button.Name = "Reset_Button";
            this.Reset_Button.Size = new System.Drawing.Size(92, 47);
            this.Reset_Button.TabIndex = 15;
            this.Reset_Button.Text = "Reset";
            this.Reset_Button.UseVisualStyleBackColor = true;
            this.Reset_Button.Click += new System.EventHandler(this.Reset_Button_Click);
            // 
            // TrackPrecision_ComboBox
            // 
            this.TrackPrecision_ComboBox.FormattingEnabled = true;
            this.TrackPrecision_ComboBox.Location = new System.Drawing.Point(1024, 768);
            this.TrackPrecision_ComboBox.Name = "TrackPrecision_ComboBox";
            this.TrackPrecision_ComboBox.Size = new System.Drawing.Size(71, 28);
            this.TrackPrecision_ComboBox.TabIndex = 16;
            this.TrackPrecision_ComboBox.SelectedIndexChanged += new System.EventHandler(this.TrackPrecision_ComboBox_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(835, 776);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(165, 20);
            this.label6.TabIndex = 17;
            this.label6.Text = "Tracking Precision (%)";
            // 
            // SecondForAnalysis_ComboBox
            // 
            this.SecondForAnalysis_ComboBox.FormattingEnabled = true;
            this.SecondForAnalysis_ComboBox.Location = new System.Drawing.Point(1024, 824);
            this.SecondForAnalysis_ComboBox.Name = "SecondForAnalysis_ComboBox";
            this.SecondForAnalysis_ComboBox.Size = new System.Drawing.Size(70, 28);
            this.SecondForAnalysis_ComboBox.TabIndex = 18;
            this.SecondForAnalysis_ComboBox.SelectedIndexChanged += new System.EventHandler(this.SecondForAnalysis_ComboBox_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(846, 827);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(154, 20);
            this.label7.TabIndex = 19;
            this.label7.Text = "Time for Analysis (s) ";
            // 
            // VideoStatus
            // 
            this.VideoStatus.AutoSize = true;
            this.VideoStatus.Location = new System.Drawing.Point(165, 640);
            this.VideoStatus.Name = "VideoStatus";
            this.VideoStatus.Size = new System.Drawing.Size(85, 20);
            this.VideoStatus.TabIndex = 20;
            this.VideoStatus.Text = "No Stream";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 690);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 20);
            this.label8.TabIndex = 21;
            this.label8.Text = "Save Status:";
            // 
            // SaveStatus
            // 
            this.SaveStatus.AutoSize = true;
            this.SaveStatus.Location = new System.Drawing.Point(165, 690);
            this.SaveStatus.Name = "SaveStatus";
            this.SaveStatus.Size = new System.Drawing.Size(81, 20);
            this.SaveStatus.TabIndex = 22;
            this.SaveStatus.Text = "No Saving";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(17, 748);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(110, 20);
            this.label9.TabIndex = 23;
            this.label9.Text = "Comunication:";
            // 
            // ComputerCamera_checkBox
            // 
            this.ComputerCamera_checkBox.AutoSize = true;
            this.ComputerCamera_checkBox.Checked = true;
            this.ComputerCamera_checkBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ComputerCamera_checkBox.Location = new System.Drawing.Point(1145, 789);
            this.ComputerCamera_checkBox.Name = "ComputerCamera_checkBox";
            this.ComputerCamera_checkBox.Size = new System.Drawing.Size(198, 24);
            this.ComputerCamera_checkBox.TabIndex = 24;
            this.ComputerCamera_checkBox.Text = "Use Computer Camera";
            this.ComputerCamera_checkBox.UseVisualStyleBackColor = true;
            this.ComputerCamera_checkBox.CheckedChanged += new System.EventHandler(this.ComputerCamera_checkBox_CheckedChanged);
            // 
            // Save_ProgresBar
            // 
            this.Save_ProgresBar.Location = new System.Drawing.Point(21, 713);
            this.Save_ProgresBar.Name = "Save_ProgresBar";
            this.Save_ProgresBar.Size = new System.Drawing.Size(229, 20);
            this.Save_ProgresBar.TabIndex = 26;
            // 
            // UseFreeApi_CheckBox
            // 
            this.UseFreeApi_CheckBox.AutoSize = true;
            this.UseFreeApi_CheckBox.Checked = true;
            this.UseFreeApi_CheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.UseFreeApi_CheckBox.Location = new System.Drawing.Point(1145, 822);
            this.UseFreeApi_CheckBox.Name = "UseFreeApi_CheckBox";
            this.UseFreeApi_CheckBox.Size = new System.Drawing.Size(168, 24);
            this.UseFreeApi_CheckBox.TabIndex = 27;
            this.UseFreeApi_CheckBox.Text = "Use Free Face Api";
            this.UseFreeApi_CheckBox.UseVisualStyleBackColor = true;
            this.UseFreeApi_CheckBox.CheckedChanged += new System.EventHandler(this.UseFreeApi_CheckBox_CheckedChanged);
            // 
            // WarningPay_Label
            // 
            this.WarningPay_Label.AutoSize = true;
            this.WarningPay_Label.Location = new System.Drawing.Point(308, 789);
            this.WarningPay_Label.Name = "WarningPay_Label";
            this.WarningPay_Label.Size = new System.Drawing.Size(0, 20);
            this.WarningPay_Label.TabIndex = 28;
            // 
            // User_TextBox
            // 
            this.User_TextBox.Location = new System.Drawing.Point(12, 120);
            this.User_TextBox.Name = "User_TextBox";
            this.User_TextBox.Size = new System.Drawing.Size(231, 26);
            this.User_TextBox.TabIndex = 30;
            // 
            // Password_TextBox
            // 
            this.Password_TextBox.Location = new System.Drawing.Point(12, 172);
            this.Password_TextBox.Name = "Password_TextBox";
            this.Password_TextBox.PasswordChar = '*';
            this.Password_TextBox.Size = new System.Drawing.Size(231, 26);
            this.Password_TextBox.TabIndex = 31;
            this.Password_TextBox.UseSystemPasswordChar = true;
            // 
            // User_Label
            // 
            this.User_Label.AutoSize = true;
            this.User_Label.Location = new System.Drawing.Point(17, 97);
            this.User_Label.Name = "User_Label";
            this.User_Label.Size = new System.Drawing.Size(43, 20);
            this.User_Label.TabIndex = 32;
            this.User_Label.Text = "User";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(17, 149);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(78, 20);
            this.label10.TabIndex = 33;
            this.label10.Text = "Password";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settaggiToolStripMenuItem,
            this.cameraSettingToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1624, 33);
            this.menuStrip1.TabIndex = 34;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // settaggiToolStripMenuItem
            // 
            this.settaggiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dimensioneMinimaToolStripMenuItem,
            this.percentualeToolStripMenuItem});
            this.settaggiToolStripMenuItem.Name = "settaggiToolStripMenuItem";
            this.settaggiToolStripMenuItem.Size = new System.Drawing.Size(169, 29);
            this.settaggiToolStripMenuItem.Text = "Detection Settings";
            // 
            // dimensioneMinimaToolStripMenuItem
            // 
            this.dimensioneMinimaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.minimalDimensionToolStripMenuItem,
            this.percentageToolStripMenuItem,
            this.Faceneighboors_ToolStripMenuItem});
            this.dimensioneMinimaToolStripMenuItem.Name = "dimensioneMinimaToolStripMenuItem";
            this.dimensioneMinimaToolStripMenuItem.Size = new System.Drawing.Size(131, 30);
            this.dimensioneMinimaToolStripMenuItem.Text = "Face";
            // 
            // minimalDimensionToolStripMenuItem
            // 
            this.minimalDimensionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FaceMD_toolStripComboBox});
            this.minimalDimensionToolStripMenuItem.Name = "minimalDimensionToolStripMenuItem";
            this.minimalDimensionToolStripMenuItem.Size = new System.Drawing.Size(249, 30);
            this.minimalDimensionToolStripMenuItem.Text = "Minimal Dimension";
            // 
            // FaceMD_toolStripComboBox
            // 
            this.FaceMD_toolStripComboBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "7",
            "10",
            "15",
            "20",
            "25"});
            this.FaceMD_toolStripComboBox.Name = "FaceMD_toolStripComboBox";
            this.FaceMD_toolStripComboBox.Size = new System.Drawing.Size(121, 33);
            this.FaceMD_toolStripComboBox.Click += new System.EventHandler(this.FaceMD_toolStripComboBox_Click);
            // 
            // percentageToolStripMenuItem
            // 
            this.percentageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FacePerc_toolStripComboBox});
            this.percentageToolStripMenuItem.Name = "percentageToolStripMenuItem";
            this.percentageToolStripMenuItem.Size = new System.Drawing.Size(249, 30);
            this.percentageToolStripMenuItem.Text = "Percentage";
            // 
            // FacePerc_toolStripComboBox
            // 
            this.FacePerc_toolStripComboBox.Items.AddRange(new object[] {
            "1,1",
            "1,2",
            "1,3",
            "1,4",
            "1,5",
            "1,7",
            "2,0",
            "2,5",
            "3,0"});
            this.FacePerc_toolStripComboBox.Name = "FacePerc_toolStripComboBox";
            this.FacePerc_toolStripComboBox.Size = new System.Drawing.Size(121, 33);
            this.FacePerc_toolStripComboBox.Click += new System.EventHandler(this.FacePerc_toolStripComboBox_Click);
            // 
            // Faceneighboors_ToolStripMenuItem
            // 
            this.Faceneighboors_ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FaceNeighboor_toolStripComboBox});
            this.Faceneighboors_ToolStripMenuItem.Name = "Faceneighboors_ToolStripMenuItem";
            this.Faceneighboors_ToolStripMenuItem.Size = new System.Drawing.Size(249, 30);
            this.Faceneighboors_ToolStripMenuItem.Text = "Neighboors";
            // 
            // FaceNeighboor_toolStripComboBox
            // 
            this.FaceNeighboor_toolStripComboBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "7",
            "10",
            "15",
            "20",
            "30",
            "40",
            "50"});
            this.FaceNeighboor_toolStripComboBox.Name = "FaceNeighboor_toolStripComboBox";
            this.FaceNeighboor_toolStripComboBox.Size = new System.Drawing.Size(121, 33);
            this.FaceNeighboor_toolStripComboBox.Click += new System.EventHandler(this.FaceNeighboor_toolStripComboBox_Click);
            // 
            // percentualeToolStripMenuItem
            // 
            this.percentualeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.minimalDimensionToolStripMenuItem1,
            this.percentageToolStripMenuItem1,
            this.neighboorsToolStripMenuItem});
            this.percentualeToolStripMenuItem.Name = "percentualeToolStripMenuItem";
            this.percentualeToolStripMenuItem.Size = new System.Drawing.Size(131, 30);
            this.percentualeToolStripMenuItem.Text = "Eye";
            // 
            // minimalDimensionToolStripMenuItem1
            // 
            this.minimalDimensionToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EyeMinimal_toolStripComboBox});
            this.minimalDimensionToolStripMenuItem1.Name = "minimalDimensionToolStripMenuItem1";
            this.minimalDimensionToolStripMenuItem1.Size = new System.Drawing.Size(249, 30);
            this.minimalDimensionToolStripMenuItem1.Text = "Minimal Dimension";
            // 
            // EyeMinimal_toolStripComboBox
            // 
            this.EyeMinimal_toolStripComboBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "7",
            "10",
            "12",
            "15",
            "20",
            "25",
            "30",
            "40",
            "50"});
            this.EyeMinimal_toolStripComboBox.Name = "EyeMinimal_toolStripComboBox";
            this.EyeMinimal_toolStripComboBox.Size = new System.Drawing.Size(121, 33);
            this.EyeMinimal_toolStripComboBox.Click += new System.EventHandler(this.EyeMinimal_toolStripComboBox_Click);
            // 
            // percentageToolStripMenuItem1
            // 
            this.percentageToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EyePerc_toolStripComboBox});
            this.percentageToolStripMenuItem1.Name = "percentageToolStripMenuItem1";
            this.percentageToolStripMenuItem1.Size = new System.Drawing.Size(249, 30);
            this.percentageToolStripMenuItem1.Text = "Percentage";
            // 
            // EyePerc_toolStripComboBox
            // 
            this.EyePerc_toolStripComboBox.Items.AddRange(new object[] {
            "1,1",
            "1,2",
            "1,3",
            "1,4",
            "1,5",
            "1,7",
            "2,0",
            "2,5",
            "3,0"});
            this.EyePerc_toolStripComboBox.Name = "EyePerc_toolStripComboBox";
            this.EyePerc_toolStripComboBox.Size = new System.Drawing.Size(121, 33);
            this.EyePerc_toolStripComboBox.Click += new System.EventHandler(this.EyePerc_toolStripComboBox_Click);
            // 
            // neighboorsToolStripMenuItem
            // 
            this.neighboorsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EyeNeighBoors_toolStripComboBox2});
            this.neighboorsToolStripMenuItem.Name = "neighboorsToolStripMenuItem";
            this.neighboorsToolStripMenuItem.Size = new System.Drawing.Size(249, 30);
            this.neighboorsToolStripMenuItem.Text = "Neighboors";
            // 
            // EyeNeighBoors_toolStripComboBox2
            // 
            this.EyeNeighBoors_toolStripComboBox2.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "7",
            "10",
            "15",
            "20",
            "25",
            "30",
            "40",
            "50"});
            this.EyeNeighBoors_toolStripComboBox2.Name = "EyeNeighBoors_toolStripComboBox2";
            this.EyeNeighBoors_toolStripComboBox2.Size = new System.Drawing.Size(121, 33);
            this.EyeNeighBoors_toolStripComboBox2.Click += new System.EventHandler(this.EyeNeighBoors_toolStripComboBox2_Click);
            // 
            // cameraSettingToolStripMenuItem
            // 
            this.cameraSettingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newCameraToolStripMenuItem,
            this.selectCameraToolStripMenuItem});
            this.cameraSettingToolStripMenuItem.Name = "cameraSettingToolStripMenuItem";
            this.cameraSettingToolStripMenuItem.Size = new System.Drawing.Size(145, 29);
            this.cameraSettingToolStripMenuItem.Text = "Camera Setting";
            // 
            // newCameraToolStripMenuItem
            // 
            this.newCameraToolStripMenuItem.Name = "newCameraToolStripMenuItem";
            this.newCameraToolStripMenuItem.Size = new System.Drawing.Size(252, 30);
            this.newCameraToolStripMenuItem.Text = "New Camera";
            this.newCameraToolStripMenuItem.Click += new System.EventHandler(this.newCamera_DoubleClickEvent);
            this.newCameraToolStripMenuItem.DoubleClick += new System.EventHandler(this.newCamera_DoubleClickEvent);
            // 
            // selectCameraToolStripMenuItem
            // 
            this.selectCameraToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SelectCamera_toolStripComboBox});
            this.selectCameraToolStripMenuItem.Name = "selectCameraToolStripMenuItem";
            this.selectCameraToolStripMenuItem.Size = new System.Drawing.Size(252, 30);
            this.selectCameraToolStripMenuItem.Text = "Select Camera";
            // 
            // SelectCamera_toolStripComboBox
            // 
            this.SelectCamera_toolStripComboBox.Name = "SelectCamera_toolStripComboBox";
            this.SelectCamera_toolStripComboBox.Size = new System.Drawing.Size(350, 33);
            this.SelectCamera_toolStripComboBox.SelectedIndexChanged += new System.EventHandler(this.SelectCamera_toolStripComboBox_SelectionChanged);
            this.SelectCamera_toolStripComboBox.Click += new System.EventHandler(this.SelectCamera_toolStripComboBox_Click);
            // 
            // AcquisitionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1624, 858);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.User_Label);
            this.Controls.Add(this.Password_TextBox);
            this.Controls.Add(this.User_TextBox);
            this.Controls.Add(this.WarningPay_Label);
            this.Controls.Add(this.UseFreeApi_CheckBox);
            this.Controls.Add(this.Save_ProgresBar);
            this.Controls.Add(this.ComputerCamera_checkBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.SaveStatus);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.VideoStatus);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.SecondForAnalysis_ComboBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.TrackPrecision_ComboBox);
            this.Controls.Add(this.Reset_Button);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.FaceApiUri_Box);
            this.Controls.Add(this.FaceApiKey_Box);
            this.Controls.Add(this.DatabaseConnection_Box);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.StreamConnection_Box);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.OutputResult);
            this.Controls.Add(this.StopSave_Button);
            this.Controls.Add(this.StartSaving_Button);
            this.Controls.Add(this.StopStream_Button);
            this.Controls.Add(this.StartStream_Button);
            this.Controls.Add(this.ShowBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "AcquisitionForm";
            this.Text = "Acquisition Form";
            ((System.ComponentModel.ISupportInitialize)(this.ShowBox)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ShowBox;
        private System.Windows.Forms.Button StartStream_Button;
        private System.Windows.Forms.Button StopStream_Button;
        private System.Windows.Forms.Button StartSaving_Button;
        private System.Windows.Forms.Button StopSave_Button;
        private System.Windows.Forms.Label OutputResult;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox StreamConnection_Box;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox DatabaseConnection_Box;
        private System.Windows.Forms.TextBox FaceApiKey_Box;
        private System.Windows.Forms.TextBox FaceApiUri_Box;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button Reset_Button;
        private System.Windows.Forms.ComboBox TrackPrecision_ComboBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox SecondForAnalysis_ComboBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label VideoStatus;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label SaveStatus;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox ComputerCamera_checkBox;
        private System.Windows.Forms.ProgressBar Save_ProgresBar;
        private System.Windows.Forms.CheckBox UseFreeApi_CheckBox;
        private System.Windows.Forms.Label WarningPay_Label;
        private System.Windows.Forms.TextBox User_TextBox;
        private System.Windows.Forms.TextBox Password_TextBox;
        private System.Windows.Forms.Label User_Label;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem settaggiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dimensioneMinimaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem percentualeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem minimalDimensionToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox FaceMD_toolStripComboBox;
        private System.Windows.Forms.ToolStripMenuItem percentageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Faceneighboors_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox FaceNeighboor_toolStripComboBox;
        private System.Windows.Forms.ToolStripComboBox FacePerc_toolStripComboBox;
        private System.Windows.Forms.ToolStripMenuItem minimalDimensionToolStripMenuItem1;
        private System.Windows.Forms.ToolStripComboBox EyeMinimal_toolStripComboBox;
        private System.Windows.Forms.ToolStripMenuItem percentageToolStripMenuItem1;
        private System.Windows.Forms.ToolStripComboBox EyePerc_toolStripComboBox;
        private System.Windows.Forms.ToolStripMenuItem neighboorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox EyeNeighBoors_toolStripComboBox2;
        private System.Windows.Forms.ToolStripMenuItem cameraSettingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newCameraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectCameraToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox SelectCamera_toolStripComboBox;
    }
}

