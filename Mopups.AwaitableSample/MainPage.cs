using AsyncAwaitBestPractices.MVVM;

using Mopups.Animations;
using Mopups.Awaitable.PopupPages.SingleResponse;
using Mopups.Pages;
using Mopups.Services;


using Button = Microsoft.Maui.Controls.Button;
using ScrollView = Microsoft.Maui.Controls.ScrollView;

namespace SampleMaui.CSharpMarkup;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        BuildContent();
    }

    private int PopupType { get; set; }

    protected void BuildContent()
    {
        BackgroundColor = Color.FromRgb(255, 255, 255);
        Title = "Popup Demo";
        Content = new ScrollView
        {
            VerticalOptions = LayoutOptions.FillAndExpand,
            Content = GenerateMainPageStackLayout()
        };
    }

    private StackLayout GenerateMainPageStackLayout()
    {
        var mainStackLayout = new StackLayout
        {
            Spacing = 20,
            Margin = new Thickness(10, 15)
        };
        mainStackLayout.Add(PremadePopupTypePicker());
        mainStackLayout.Add(GeneratePopupButton("Generate Popup", AttemptPopupPage()));
        return mainStackLayout;

        Picker PremadePopupTypePicker()
        {
            var PremadePopupPicker = new Picker
            {
                Items = { nameof(Mopups.Awaitable.PopupPages.SingleResponse),
                            nameof(Mopups.Awaitable.PopupPages.DualResponse),
                            nameof(Mopups.Awaitable.PopupPages.Login),
                            nameof(Mopups.Awaitable.PopupPages.Loader),
                            nameof(Mopups.Awaitable.PopupPages.EntryInput),
                            nameof(Mopups.Awaitable.PopupPages.TextInput)
                }
            };
            PremadePopupPicker.SelectedIndexChanged += OnPopupPickerSelectedIndexChanged;
            return PremadePopupPicker;

        }

    }


    void OnPopupPickerSelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;
        PopupType = selectedIndex;
    }




    private static Button GeneratePopupButton(string buttonText, AsyncCommand buttonCommand)
    {
        return new Button
        {
            Text = buttonText,
            BackgroundColor = Color.FromArgb("#FF7DBBE6"),
            TextColor = Color.FromRgb(255, 255, 255),
            Command = buttonCommand,
        };
    }

    private AsyncCommand AttemptPopupPage()
    {
        return new AsyncCommand(async () =>
        {
            try
            {
                var random = new Random();
                switch (PopupType)
                {
                    case 0: // single response
                        var guff =await SingleResponseViewModel.AutoGenerateBasicPopup
                        (Color.FromRgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255)),
                        Color.FromRgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255)),
                        "Random Popup",
                        Color.FromRgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255)),
                        "Popup Info",
                        "noDisplay",
                        random.Next(100, 400),
                        random.Next(100, 400));
                        Console.WriteLine(guff);
                        break;
                    case 1: // dual response
                        
                        break;
                    case 2: // login
                        
                        break;
                    case 3: //loader
                        
                        break;
                    case 4: // entryinput
                        
                        break;
                    case 5: // text input
                        
                        break;
                }
            }
            catch (Exception)
            {
                throw;
            }
        });
    }
}