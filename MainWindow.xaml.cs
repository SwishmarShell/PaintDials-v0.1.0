using System.Text;
using System.IO;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PaintDials;

    public partial class MainWindow : Window
    {
        private double _brushSize = 25.0;

        private double _opacity = 1.0;

        private double _sizeStep = 1;

        private double _opacityStep = 0.01;

        private List<Ellipse> _sizeDialMarks;

        private Ellipse? _selectedSizeMark;

        private Ellipse? _selectedOpacityMark;


    public MainWindow()
    {
        InitializeComponent();

        _sizeDialMarks =
        [
            SizeStep100,
            SizeStep10,
            SizeStep1,
            SizeStep01,
            SizeStep001
        ];

        SetSizeDialSelection(
            SizeStep1);

        _sizeStep = 1.0;

        UpdateView();
        SaveJson();
    }

    private void SizeStep_Checked(
        object sender,
        RoutedEventArgs e)
    {
        var rb = (RadioButton)sender;

        _sizeStep =
        double.Parse(
        rb.Tag.ToString()!);
    }

    private void OpacityStep_Checked(
    object sender,
    RoutedEventArgs e)
    {
        var rb = (RadioButton)sender;

        _opacityStep =
            double.Parse(
                rb.Tag.ToString()!);
    }

    private void Size_MouseWheel(
        object sender,
        MouseWheelEventArgs e)
    {
        if (!Keyboard.IsKeyDown(Key.LeftCtrl) &&
        !Keyboard.IsKeyDown(Key.RightCtrl))
        {
            return;
        }

        _brushSize +=
        e.Delta > 0
        ? _sizeStep
        : -_sizeStep;

        if (_brushSize < 0.01)
            _brushSize = 0.01;

        UpdateView();
        SaveJson();
    }

    private void Opacity_MouseWheel(
        object sender,
        MouseWheelEventArgs e)
    {
        if (!Keyboard.IsKeyDown(Key.LeftCtrl) &&
        !Keyboard.IsKeyDown(Key.RightCtrl))
        {
            return;
        }

        _opacity +=
            e.Delta > 0
            ? _opacityStep
            : -_opacityStep;

        _opacity = Math.Clamp(
        _opacity,
        0.0,
        1.0);

        UpdateView();
        SaveJson();
    }

    private void OpacityStep10_Click(
        object sender,
        MouseButtonEventArgs e)
    {
        _opacityStep = 0.10;

        OpacityStep10.Fill = Brushes.Orange;
        OpacityStep1.Fill = Brushes.Gray;

        _selectedOpacityMark = OpacityStep10;
    }

    private void OpacityStep1_Click(
        object sender,
        MouseButtonEventArgs e)
    {
        _opacityStep = 0.01;

        OpacityStep10.Fill = Brushes.Gray;
        OpacityStep1.Fill = Brushes.Orange;

        _selectedOpacityMark = OpacityStep1;
    }

    private static readonly Brush HoverBrush =
        new SolidColorBrush(
            Color.FromRgb(
                255,
                235,
                200));

    private void DialPoint_MouseEnter(
        object sender,
        MouseEventArgs e)
    {
        if (sender is not Ellipse mark)
            return;

        if (mark != _selectedSizeMark)
        {
            mark.Fill = HoverBrush;
        }
    }

    private void DialPoint_MouseLeave(
        object sender,
        MouseEventArgs e)
    {
        if (sender is not Ellipse mark)
            return;

        if (mark == _selectedSizeMark)
            return;

        if (mark == _selectedOpacityMark)
            return;

        mark.Fill = Brushes.Gray;
    }

    private void DialPoint_MouseEnter_Cercle(
        object sender,
        MouseEventArgs e)
    {
        OpacityDialCircle.Fill =
        new SolidColorBrush(
        Color.FromArgb(
        80,
        255,
        220,
        180));
    }

    private void DialPoint_MouseLeave_Cercle(
        object sender,
        MouseEventArgs e)
    {
        OpacityDialCircle.Fill =
        Brushes.Transparent;
    }

        private void DialPoint_MouseEnter_Cercle2(
        object sender,
        MouseEventArgs e)
    {
        SizeDialCircle.Fill =
            new SolidColorBrush(
                Color.FromArgb(
                    80,
                    255,
                    220,
                    180));
    }

    private void DialPoint_MouseLeave_Cercle2(
    object sender,
    MouseEventArgs e)
    {
        SizeDialCircle.Fill =
        Brushes.Transparent;
    }


    private void SetSizeDialSelection(
        Ellipse active)
    {
        SizeStep100.Fill = Brushes.Gray;
        SizeStep10.Fill = Brushes.Gray;
        SizeStep1.Fill = Brushes.Gray;
        SizeStep01.Fill = Brushes.Gray;
        SizeStep001.Fill = Brushes.Gray;

        active.Fill = Brushes.Orange;

        _selectedSizeMark = active;
    }

    

    private void SelectSizeStep(
        Ellipse selected,
        double step)
    {
        foreach (var mark in _sizeDialMarks)
        {
            mark.Fill = Brushes.Gray;
        }

        selected.Fill = Brushes.Orange;

        _selectedSizeMark = selected;

        _sizeStep = step;
    }

    private void SizeStep_Click(
        object sender,
        MouseButtonEventArgs e)
    {
        var ellipse = (Ellipse)sender;

        double step =
        double.Parse(
        ellipse.Tag!.ToString()!);

        SelectSizeStep(
        ellipse,
        step);
    }

    private void UpdateView()
    {
        SizeText.Text =
        _brushSize.ToString("0.00") + "px";

        OpacityText.Text =
            (_opacity * 100).ToString("0") + "%";
    }

    private void SaveJson()
    {
        string dir = System.IO.Path.Combine(
         Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
        "PaintDials");

        Directory.CreateDirectory(dir);

        var data = new
        {
            Size = _brushSize,
            Opacity = _opacity
        };

        string json =
        JsonSerializer.Serialize(
        data,
        new JsonSerializerOptions
        {
            WriteIndented = true
        });

        File.WriteAllText(
        System.IO.Path.Combine(
        dir,
        "Command.json"),
        json);
    }
}
