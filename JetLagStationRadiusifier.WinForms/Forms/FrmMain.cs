using JetLagStationRadiusifier.Common.Consts;
using JetLagStationRadiusifier.Common.Contracts;
using JetLagStationRadiusifier.Common.Enums;
using JetLagStationRadiusifier.Common.Helpers;
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
        InitGameSizeRadios();
    }

    private void SetRadiusUnits()
    {
        cmbRadiusUnit.DataSource = Enum.GetValues<DistanceUnit>().ToList();
    }

    private void InitGameSizeRadios()
    {
        radGameSizeSmall.Tag = GameSize.Small;
        radGameSizeMedium.Tag = GameSize.Medium;
        radGameSizeLarge.Tag = GameSize.Large;
        radGameSizeCustom.Tag = GameSize.Custom;

        radGameSizeSmall.Checked = true;
        cmbRadiusUnit.SelectedValueChanged += CmbRadiusUnit_SelectedIndexChanged;
    }

    private void BtnSelectColour_Click(object sender, EventArgs e) => ShowColourPicker();

    private void CmbRadiusUnit_SelectedIndexChanged(object? sender, EventArgs e) => RecalculateRadiusValue();

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

        var hex = $"#{colour.R:X2}{colour.G:X2}{colour.B:X2}";
        var r = colour.R.ToString();
        var g = colour.G.ToString();
        var b = colour.B.ToString();

        txtRedPreview.Text = r;
        txtGreenPreview.Text = g;
        txtBluePreview.Text = b;
        txtHexPreview.Text = hex;
    }

    private void BtnRun_Click(object sender, EventArgs e) => RunRequest();

    private void RunRequest()
    {
        try
        {
            var catchmentRequest = BuildRequest();
            if (catchmentRequest is null)
            {
                MessageBox.Show(
                    this,
                    "Please check your inputs and try again.",
                    "Invalid Inputs",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            var runResult = _runner.Run(catchmentRequest);
            if (runResult.IsSuccess == false || runResult.Value is null)
            {
                MessageBox.Show(
                    this,
                    $"An error occurred while running the process: {runResult.ErrorMessage}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            var radiusifiedKml = runResult.Value;
            var inputPath = txtInputKmlPath.Text.Trim();
            var outputDirectory = txtOutputKmlPath.Text.Trim();
            var outputFileName = $"{Path.GetFileNameWithoutExtension(inputPath)}-radiusified{Path.GetExtension(inputPath)}";
            var outputKmlPath = Path.Combine(outputDirectory, outputFileName);
            radiusifiedKml.Save(outputKmlPath);
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                this,
                $"An unexpected error occurred: {ex.Message}",
                "Unexpected Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        MessageBox.Show(this, "Map has been radiusified. Enjoy JetLagging!");
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
        var inputPath = txtInputKmlPath.Text.Trim();
        var inputStream = File.OpenRead(inputPath);

        return new CatchmentRequestDto
        {
            InputKmlStream = inputStream,
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

        if (string.Equals(Path.GetExtension(source), FileTypes.Kml, StringComparison.OrdinalIgnoreCase) == false)
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

    private void BtnBrowseSource_Click(object sender, EventArgs e)
    {
        using var fileDialog = new OpenFileDialog()
        {
            Filter = $"kml files (*{FileTypes.Kml})|*{FileTypes.Kml}",
        };

        if (fileDialog.ShowDialog() != DialogResult.OK)
        {
            return;
        }

        txtInputKmlPath.Text = fileDialog.FileName;
        EnableBtnRunIfUiStateAllows();
    }

    private void BtnBrowseOutput_Click(object sender, EventArgs e)
    {
        using var folderDialog = new FolderBrowserDialog()
        {
            Multiselect = false,
        };

        if (folderDialog.ShowDialog() != DialogResult.OK)
        {
            return;
        }

        txtOutputKmlPath.Text = folderDialog.SelectedPath;
        EnableBtnRunIfUiStateAllows();
    }

    private void EnableBtnRunIfUiStateAllows()
    {
        btnRun.Enabled = ValidateControls();
    }

    private void SizeRadio_CheckedChanged(object sender, EventArgs e)
    {
        if (sender is not RadioButton sizeRadio)
        {
            return;
        }

        if (sizeRadio.Checked == false)
        {
            return;
        }

        if (sizeRadio.Tag is not GameSize size)
        {
            throw new ArgumentException($"{sizeRadio.Name} Tag must be set to a GameSize value.");
        }

        if (cmbRadiusUnit.SelectedItem is not DistanceUnit)
        {
            throw new ArgumentException($"{cmbRadiusUnit.SelectedItem} is not a valid DistanceUnit");
        }

        RecalculateRadiusValue();
        numRadiusValue.Enabled = size == GameSize.Custom;
    }

    private void RecalculateRadiusValue()
    {
        if (cmbRadiusUnit.SelectedItem is not DistanceUnit selectedUnit)
        {
            throw new ArgumentException($"{cmbRadiusUnit.SelectedItem} is not a valid DistanceUnit");
        }

        var selectedSizeRadio = new[] { radGameSizeSmall, radGameSizeMedium, radGameSizeLarge, radGameSizeCustom }
            .FirstOrDefault(radio => radio.Checked) ?? throw new InvalidOperationException("No size radio button is checked.");

        if (selectedSizeRadio.Tag is not GameSize size)
        {
            throw new ArgumentException($"{selectedSizeRadio.Name} Tag must be set to a GameSize value.");
        }

        if (size == GameSize.Custom)
        {
            return;
        }

        numRadiusValue.Value = RadiusPresetHelper.GetPreset(selectedUnit, size);
    }
}
