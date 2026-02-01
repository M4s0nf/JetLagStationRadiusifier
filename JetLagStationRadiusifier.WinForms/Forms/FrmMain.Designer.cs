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
        grpKmlPaths.SuspendLayout();
        grpColour.SuspendLayout();
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
        btnRun.Location = new Point(694, 398);
        btnRun.Name = "btnRun";
        btnRun.Size = new Size(128, 51);
        btnRun.TabIndex = 5;
        btnRun.Text = "Radiusify";
        btnRun.UseVisualStyleBackColor = true;
        btnRun.Click += this.BtnRun_Click;
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
        grpColour.Location = new Point(27, 225);
        grpColour.Name = "grpColour";
        grpColour.Size = new Size(417, 224);
        grpColour.TabIndex = 9;
        grpColour.TabStop = false;
        grpColour.Text = "Select Colour";
        // 
        // txtGreenPreview
        // 
        txtGreenPreview.Location = new Point(206, 124);
        txtGreenPreview.Name = "txtGreenPreview";
        txtGreenPreview.ReadOnly = true;
        txtGreenPreview.Size = new Size(67, 23);
        txtGreenPreview.TabIndex = 13;
        // 
        // txtBluePreview
        // 
        txtBluePreview.Location = new Point(279, 124);
        txtBluePreview.Name = "txtBluePreview";
        txtBluePreview.ReadOnly = true;
        txtBluePreview.Size = new Size(67, 23);
        txtBluePreview.TabIndex = 12;
        // 
        // txtRedPreview
        // 
        txtRedPreview.Location = new Point(133, 124);
        txtRedPreview.Name = "txtRedPreview";
        txtRedPreview.ReadOnly = true;
        txtRedPreview.Size = new Size(67, 23);
        txtRedPreview.TabIndex = 11;
        // 
        // txtHexPreview
        // 
        txtHexPreview.Location = new Point(133, 156);
        txtHexPreview.Name = "txtHexPreview";
        txtHexPreview.ReadOnly = true;
        txtHexPreview.Size = new Size(213, 23);
        txtHexPreview.TabIndex = 10;
        // 
        // lblHex
        // 
        lblHex.AutoSize = true;
        lblHex.Location = new Point(95, 159);
        lblHex.Name = "lblHex";
        lblHex.Size = new Size(30, 15);
        lblHex.TabIndex = 3;
        lblHex.Text = "Hex:";
        // 
        // lblRgb
        // 
        lblRgb.AutoSize = true;
        lblRgb.Location = new Point(95, 127);
        lblRgb.Name = "lblRgb";
        lblRgb.Size = new Size(32, 15);
        lblRgb.TabIndex = 2;
        lblRgb.Text = "RGB:";
        // 
        // pnlColourPreview
        // 
        pnlColourPreview.BackColor = Color.Red;
        pnlColourPreview.Location = new Point(133, 57);
        pnlColourPreview.Name = "pnlColourPreview";
        pnlColourPreview.Size = new Size(128, 43);
        pnlColourPreview.TabIndex = 1;
        // 
        // btnSelectColour
        // 
        btnSelectColour.Location = new Point(267, 57);
        btnSelectColour.Name = "btnSelectColour";
        btnSelectColour.Size = new Size(79, 43);
        btnSelectColour.TabIndex = 0;
        btnSelectColour.Text = "Select Colour";
        btnSelectColour.UseVisualStyleBackColor = true;
        btnSelectColour.Click += BtnSelectColour_Click;
        // 
        // FrmMain
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(834, 461);
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
}
