using JetLagStationRadiusifier.Common.Contracts;
using JetLagStationRadiusifier.Common.Enums;
using JetLagStationRadiusifier.Common.Runners.Abstractions;

namespace JetLagStationRadiusifier.WinForms.Forms;

public partial class FrmMain : Form
{
    private readonly ICatchmentRunner _runner;
    public FrmMain(ICatchmentRunner runner)
    {
        InitializeComponent();

        _runner = runner;

        Init();
    }

    private void Init()
    {
        SetPreviewColour(Color.Red);
        SetRadiusUnits();
    }

    private void SetRadiusUnits()
    {
        cmbRadiusUnit.DataSource = Enum.GetValues<DistanceUnit>()
            .OrderBy(x => x.ToString())
            .ToList();
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
        var catchmentRequest = BuildRequest();
        if (catchmentRequest is null)
        {
            MessageBox.Show(
                this,
                "Please check your inputs and try again.",
                "Invalid Inputs",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );

            return;
        }

        var runResult = _runner.Run(catchmentRequest);
        if (runResult.IsSuccess == false)
        {
            MessageBox.Show(
                this,
                $"An error occurred while running the process: {runResult.ErrorMessage}", 
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );

            return;
        }

        // TODO: show success message
    }

    private CatchmentRequestDto? BuildRequest()
    {
        if (ValidateControls() == false)
        {
            return null;
        }

        if (cmbRadiusUnit.SelectedItem is not DistanceUnit unit)
        {
            return null;
        }

        var colour = pnlColourPreview.BackColor;

        return new CatchmentRequestDto
        {
            InputKmlPath = txtInputKmlPath.Text.Trim(),
            OutputKmlPath = txtOutputKmlPath.Text.Trim(),
            RadiusUnit = unit,
            Radius = (int)numRadiusValue.Value,
            Red = colour.R,
            Green = colour.G,
            Blue = colour.B,
        };
    }

    private bool ValidateControls()
    {
        var source = txtInputKmlPath.Text.Trim();
        if (File.Exists(source) == false)
        {
            return false;
        }

        if (string.Equals(Path.GetExtension(source), ".kml", StringComparison.OrdinalIgnoreCase) == false)
        {
            return false;
        }

        var destination = txtOutputKmlPath.Text.Trim();
        if (Directory.Exists(destination) == false)
        {
            return false;
        }

        if (numRadiusValue.Value <= 0)
        {
            return false;
        }

        if (cmbRadiusUnit.SelectedItem is not DistanceUnit)
        {
            return false;
        }

        return true;
    }
}
