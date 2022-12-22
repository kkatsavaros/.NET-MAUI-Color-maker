using CommunityToolkit.Maui.Alerts;
using System.Diagnostics;


namespace ColorMaker;

public partial class MainPage : ContentPage

{
    string hexValue;     // για το copy

    public MainPage()
    {
        InitializeComponent();
    }

    private void sldRed_ValueChanged(object sender, ValueChangedEventArgs e)
    {

        var red = sldRed.Value;              // Παίρνω την τιμή από τον πρώτο slider.
        var green = sldGreen.Value;          //
        var blue = sldBlue.Value;            // 

        Color color = Color.FromRgb(red, green, blue);

        SetColor(color);
    }

    private void SetColor(Color color)
    {
        Debug.WriteLine(color.ToString());

        btnRandom.BackgroundColor = color;   // Setting the color.
        Container.BackgroundColor = color;
        lblHex.Text = color.ToHex();         // Μόνο για να το εμφανίσω στο Text
    }

    private void btnRandom_Clicked(object sender, EventArgs e)
    {
        var random = new Random();           // Δημιουργία Instance της κλάσης Random.

        // Δημιουργία Instance της κλάσης Color.
        var color = Color.FromRgb(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256));

        SetColor(color);

        sldRed.Value = color.Red;            // Ορίζω τους slides.
        sldGreen.Value = color.Green;
        sldBlue.Value = color.Blue;
    }

    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
        await Clipboard.SetTextAsync(hexValue);   // Copy to Clipboard.

        var toast = Toast.Make("Color copied", CommunityToolkit.Maui.Core.ToastDuration.Short, 12);

        await toast.Show();
    }
}

