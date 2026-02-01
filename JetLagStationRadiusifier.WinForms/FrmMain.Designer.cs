namespace JetLagStationRadiusifier.WinForms;

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
        SuspendLayout();
        // 
        // lblTitle
        // 
        lblTitle.AutoSize = true;
        lblTitle.Font = new Font("Segoe UI", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblTitle.Location = new Point(69, 9);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(646, 47);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "Jet Lag: The Game Hide & Seek Radiusifier";
        // 
        // txtInputKmlPath
        // 
        txtInputKmlPath.Location = new Point(148, 116);
        txtInputKmlPath.Name = "txtInputKmlPath";
        txtInputKmlPath.Size = new Size(367, 23);
        txtInputKmlPath.TabIndex = 1;
        // 
        // txtOutputKmlPath
        // 
        txtOutputKmlPath.Location = new Point(148, 161);
        txtOutputKmlPath.Name = "txtOutputKmlPath";
        txtOutputKmlPath.Size = new Size(367, 23);
        txtOutputKmlPath.TabIndex = 2;
        // 
        // btnBrowseSource
        // 
        btnBrowseSource.Location = new Point(544, 120);
        btnBrowseSource.Name = "btnBrowseSource";
        btnBrowseSource.Size = new Size(75, 23);
        btnBrowseSource.TabIndex = 3;
        btnBrowseSource.Text = "button1";
        btnBrowseSource.UseVisualStyleBackColor = true;
        // 
        // btnBrowseOutput
        // 
        btnBrowseOutput.Location = new Point(544, 161);
        btnBrowseOutput.Name = "btnBrowseOutput";
        btnBrowseOutput.Size = new Size(75, 23);
        btnBrowseOutput.TabIndex = 4;
        btnBrowseOutput.Text = "button1";
        btnBrowseOutput.UseVisualStyleBackColor = true;
        // 
        // btnRun
        // 
        btnRun.Location = new Point(694, 398);
        btnRun.Name = "btnRun";
        btnRun.Size = new Size(128, 51);
        btnRun.TabIndex = 5;
        btnRun.Text = "Radiusify";
        btnRun.UseVisualStyleBackColor = true;
        // 
        // FrmMain
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(834, 461);
        Controls.Add(btnRun);
        Controls.Add(btnBrowseOutput);
        Controls.Add(btnBrowseSource);
        Controls.Add(txtOutputKmlPath);
        Controls.Add(txtInputKmlPath);
        Controls.Add(lblTitle);
        MaximizeBox = false;
        MaximumSize = new Size(850, 500);
        MinimizeBox = false;
        MinimumSize = new Size(850, 500);
        Name = "FrmMain";
        Text = "Jet Lag Radiusifier";
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
}
