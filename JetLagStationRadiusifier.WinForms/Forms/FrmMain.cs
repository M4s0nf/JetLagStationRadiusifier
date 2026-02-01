using JetLagStationRadiusifier.Common.Engine.Abstractions;
using JetLagStationRadiusifier.Common.Models;

namespace JetLagStationRadiusifier.WinForms.Forms;

public partial class FrmMain : Form
{
    private readonly ICatchmentEngine _engine;

    public FrmMain(ICatchmentEngine catchmentEngine)
    {
        InitializeComponent();
        _engine = catchmentEngine;
        Init();
    }

    private void Init()
    {
        SetPreviewColour(Color.Red);
    }

    private void BtnSelectColour_Click(object sender, EventArgs e) => ShowColourPicker();

    private void ShowColourPicker()
    {
        using var colourDialog = new ColorDialog()
        {
            Color = pnlColourPreview.BackColor,
            FullOpen = true,
        };

        if (colourDialog.ShowDialog(this) == DialogResult.OK)
        {
            SetPreviewColour(colourDialog.Color);
        }
    }

    private void SetPreviewColour(Color colour)
    {
        pnlColourPreview.BackColor = colour;

        var hex = "";
        var r = "";
        var g = "";
        var b = "";

        txtRedPreview.Text = r;
        txtGreenPreview.Text = g;
        txtBluePreview.Text = b;
        txtHexPreview.Text = hex;
    }

    private void BtnRun_Click(object sender, EventArgs e)
    {
        var valid = ValidateControls();
        if (valid == false)
        {
            return;
        }

        RunEngine();
    }

    private bool ValidateControls()
    {
        var source = txtInputKmlPath.Text.Trim();
        if (File.Exists(source) == false)
        {
            return false;
        }

        const string kmlFileType = ".kml";
        if (source.EndsWith(kmlFileType) == false)
        {
            return false;
        }

        var destination = txtOutputKmlPath.Text.Trim();
        if (Path.Exists(destination) == false)
        {
            return false;
        }

        return true;
    }

    private void RunEngine(string validatedInputPath, string validatedOutputPath, CatchmentDefinition options)
    {
        _engine.AddCatchments(validatedInputPath, validatedOutputPath, options);
    }
}
