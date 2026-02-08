namespace JetLagStationRadiusifier.WinForms.Forms;

partial class FrmMain
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        lblTitle = new Label();
        txtInputKmlPath = new TextBox();
        txtOutputKmlPath = new TextBox();
        btnBrowseSource = new Button();
        btnBrowseOutput = new Button();
        btnRun = new Button();
        lblSourceKml = new Label();
        lblDestinationKml = new Label();
        grpKmlPaths = new GroupBox();
        grpColour = new GroupBox();
        txtGreenPreview = new TextBox();
        txtBluePreview = new TextBox();
        txtRedPreview = new TextBox();
        txtHexPreview = new TextBox();
        lblHex = new Label();
        lblRgb = new Label();
        pnlColourPreview = new Panel();
        btnSelectColour = new Button();
        grpDetails = new GroupBox();
        lblRadiusUnit = new Label();
        cmbRadiusUnit = new ComboBox();
        lblRadiusValue = new Label();
        numRadiusValue = new NumericUpDown();
        grpKmlPaths.SuspendLayout();
        grpColour.SuspendLayout();
        grpDetails.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)numRadiusValue).BeginInit();
        SuspendLayout();
        // 
        // lblTitle
        // 
        lblTitle.AutoSize = true;
        lblTitle.Font = new Font("Segoe UI", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblTitle.Location = new Point(96, 9);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(646, 47);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "Jet Lag: The Game Hide & Seek Radiusifier";
        // 
        // txtInputKmlPath
        // 
        txtInputKmlPath.Location = new Point(133, 42);
        txtInputKmlPath.Name = "txtInputKmlPath";
        txtInputKmlPath.Size = new Size(515, 23);
        txtInputKmlPath.TabIndex = 1;
        // 
        // txtOutputKmlPath
        // 
        txtOutputKmlPath.Location = new Point(133, 87);
        txtOutputKmlPath.Name = "txtOutputKmlPath";
        txtOutputKmlPath.Size = new Size(515, 23);
        txtOutputKmlPath.TabIndex = 2;
        // 
        // btnBrowseSource
        // 
        btnBrowseSource.Location = new Point(667, 45);
        btnBrowseSource.Name = "btnBrowseSource";
        btnBrowseSource.Size = new Size(75, 23);
        btnBrowseSource.TabIndex = 3;
        btnBrowseSource.Text = "Browse";
        btnBrowseSource.UseVisualStyleBackColor = true;
        // 
        // btnBrowseOutput
        // 
        btnBrowseOutput.Location = new Point(667, 86);
        btnBrowseOutput.Name = "btnBrowseOutput";
        btnBrowseOutput.Size = new Size(75, 23);
        btnBrowseOutput.TabIndex = 4;
        btnBrowseOutput.Text = "Browse";
        btnBrowseOutput.UseVisualStyleBackColor = true;
        // 
        // btnRun
        // 
        btnRun.Enabled = false;
        btnRun.Location = new Point(680, 398);
        btnRun.Name = "btnRun";
        btnRun.Size = new Size(128, 51);
        btnRun.TabIndex = 5;
        btnRun.Text = "Radiusify";
        btnRun.UseVisualStyleBackColor = true;
        btnRun.Click += BtnRun_Click;
        // 
        // lblSourceKml
        // 
        lblSourceKml.AutoSize = true;
        lblSourceKml.Location = new Point(57, 45);
        lblSourceKml.Name = "lblSourceKml";
        lblSourceKml.Size = new Size(70, 15);
        lblSourceKml.TabIndex = 6;
        lblSourceKml.Text = "Source KML";
        // 
        // lblDestinationKml
        // 
        lblDestinationKml.AutoSize = true;
        lblDestinationKml.Location = new Point(33, 90);
        lblDestinationKml.Name = "lblDestinationKml";
        lblDestinationKml.Size = new Size(94, 15);
        lblDestinationKml.TabIndex = 7;
        lblDestinationKml.Text = "Destination KML";
        // 
        // grpKmlPaths
        // 
        grpKmlPaths.Controls.Add(txtInputKmlPath);
        grpKmlPaths.Controls.Add(lblDestinationKml);
        grpKmlPaths.Controls.Add(txtOutputKmlPath);
        grpKmlPaths.Controls.Add(lblSourceKml);
        grpKmlPaths.Controls.Add(btnBrowseSource);
        grpKmlPaths.Controls.Add(btnBrowseOutput);
        grpKmlPaths.Location = new Point(27, 76);
        grpKmlPaths.Name = "grpKmlPaths";
        grpKmlPaths.Size = new Size(781, 130);
        grpKmlPaths.TabIndex = 8;
        grpKmlPaths.TabStop = false;
        grpKmlPaths.Text = "Select Source and Destination";
        // 
        // grpColour
        // 
        grpColour.Controls.Add(txtGreenPreview);
        grpColour.Controls.Add(txtBluePreview);
        grpColour.Controls.Add(txtRedPreview);
        grpColour.Controls.Add(txtHexPreview);
        grpColour.Controls.Add(lblHex);
        grpColour.Controls.Add(lblRgb);
        grpColour.Controls.Add(pnlColourPreview);
        grpColour.Controls.Add(btnSelectColour);
        grpColour.Location = new Point(27, 212);
        grpColour.Name = "grpColour";
        grpColour.Size = new Size(303, 237);
        grpColour.TabIndex = 9;
        grpColour.TabStop = false;
        grpColour.Text = "Select Colour";
        // 
        // txtGreenPreview
        // 
        txtGreenPreview.Location = new Point(130, 156);
        txtGreenPreview.Name = "txtGreenPreview";
        txtGreenPreview.ReadOnly = true;
        txtGreenPreview.Size = new Size(67, 23);
        txtGreenPreview.TabIndex = 13;
        // 
        // txtBluePreview
        // 
        txtBluePreview.Location = new Point(203, 156);
        txtBluePreview.Name = "txtBluePreview";
        txtBluePreview.ReadOnly = true;
        txtBluePreview.Size = new Size(67, 23);
        txtBluePreview.TabIndex = 12;
        // 
        // txtRedPreview
        // 
        txtRedPreview.Location = new Point(57, 156);
        txtRedPreview.Name = "txtRedPreview";
        txtRedPreview.ReadOnly = true;
        txtRedPreview.Size = new Size(67, 23);
        txtRedPreview.TabIndex = 11;
        // 
        // txtHexPreview
        // 
        txtHexPreview.Location = new Point(57, 188);
        txtHexPreview.Name = "txtHexPreview";
        txtHexPreview.ReadOnly = true;
        txtHexPreview.Size = new Size(213, 23);
        txtHexPreview.TabIndex = 10;
        // 
        // lblHex
        // 
        lblHex.AutoSize = true;
        lblHex.Location = new Point(19, 191);
        lblHex.Name = "lblHex";
        lblHex.Size = new Size(30, 15);
        lblHex.TabIndex = 3;
        lblHex.Text = "Hex:";
        // 
        // lblRgb
        // 
        lblRgb.AutoSize = true;
        lblRgb.Location = new Point(19, 159);
        lblRgb.Name = "lblRgb";
        lblRgb.Size = new Size(32, 15);
        lblRgb.TabIndex = 2;
        lblRgb.Text = "RGB:";
        // 
        // pnlColourPreview
        // 
        pnlColourPreview.BackColor = Color.Red;
        pnlColourPreview.Location = new Point(57, 86);
        pnlColourPreview.Name = "pnlColourPreview";
        pnlColourPreview.Size = new Size(128, 43);
        pnlColourPreview.TabIndex = 1;
        // 
        // btnSelectColour
        // 
        btnSelectColour.Location = new Point(191, 86);
        btnSelectColour.Name = "btnSelectColour";
        btnSelectColour.Size = new Size(79, 43);
        btnSelectColour.TabIndex = 0;
        btnSelectColour.Text = "Select Colour";
        btnSelectColour.UseVisualStyleBackColor = true;
        btnSelectColour.Click += BtnSelectColour_Click;
        // 
        // grpDetails
        // 
        grpDetails.Controls.Add(lblRadiusUnit);
        grpDetails.Controls.Add(cmbRadiusUnit);
        grpDetails.Controls.Add(lblRadiusValue);
        grpDetails.Controls.Add(numRadiusValue);
        grpDetails.Location = new Point(336, 212);
        grpDetails.Name = "grpDetails";
        grpDetails.Size = new Size(472, 174);
        grpDetails.TabIndex = 10;
        grpDetails.TabStop = false;
        grpDetails.Text = "Additional Details";
        // 
        // lblRadiusUnit
        // 
        lblRadiusUnit.AutoSize = true;
        lblRadiusUnit.Location = new Point(209, 36);
        lblRadiusUnit.Name = "lblRadiusUnit";
        lblRadiusUnit.Size = new Size(72, 15);
        lblRadiusUnit.TabIndex = 3;
        lblRadiusUnit.Text = "Radius Units";
        // 
        // cmbRadiusUnit
        // 
        cmbRadiusUnit.FormattingEnabled = true;
        cmbRadiusUnit.Location = new Point(287, 33);
        cmbRadiusUnit.Name = "cmbRadiusUnit";
        cmbRadiusUnit.Size = new Size(146, 23);
        cmbRadiusUnit.TabIndex = 2;
        // 
        // lblRadiusValue
        // 
        lblRadiusValue.AutoSize = true;
        lblRadiusValue.Location = new Point(208, 64);
        lblRadiusValue.Name = "lblRadiusValue";
        lblRadiusValue.Size = new Size(73, 15);
        lblRadiusValue.TabIndex = 1;
        lblRadiusValue.Text = "Radius value";
        // 
        // numRadiusValue
        // 
        numRadiusValue.Location = new Point(287, 62);
        numRadiusValue.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        numRadiusValue.Name = "numRadiusValue";
        numRadiusValue.Size = new Size(146, 23);
        numRadiusValue.TabIndex = 0;
        numRadiusValue.Value = new decimal(new int[] { 1, 0, 0, 0 });
        // 
        // FrmMain
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(834, 461);
        Controls.Add(grpDetails);
        Controls.Add(grpColour);
        Controls.Add(grpKmlPaths);
        Controls.Add(btnRun);
        Controls.Add(lblTitle);
        MaximizeBox = false;
        MaximumSize = new Size(850, 500);
        MinimizeBox = false;
        MinimumSize = new Size(850, 500);
        Name = "FrmMain";
        Text = "Jet Lag Radiusifier";
        grpKmlPaths.ResumeLayout(false);
        grpKmlPaths.PerformLayout();
        grpColour.ResumeLayout(false);
        grpColour.PerformLayout();
        grpDetails.ResumeLayout(false);
        grpDetails.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)numRadiusValue).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label lblTitle;
    private TextBox txtInputKmlPath;
    private TextBox txtOutputKmlPath;
    private Button btnBrowseSource;
    private Button btnBrowseOutput;
    private Button btnRun;
    private Label lblSourceKml;
    private Label lblDestinationKml;
    private GroupBox grpKmlPaths;
    private GroupBox grpColour;
    private Button btnSelectColour;
    private Panel pnlColourPreview;
    private Label lblHex;
    private Label lblRgb;
    private TextBox txtHexPreview;
    private TextBox txtGreenPreview;
    private TextBox txtBluePreview;
    private TextBox txtRedPreview;
    private GroupBox grpDetails;
    private Label lblRadiusValue;
    private NumericUpDown numRadiusValue;
    private Label lblRadiusUnit;
    private ComboBox cmbRadiusUnit;
}
