using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Text;

namespace TravelApp;

public partial class NorthAmericaPage : ContentPage
{
    public int counter = 0;
    public List<Button> buttonList = new List<Button>();
    public List<Button> createButtonList = new List<Button>();
    Dictionary<string, List<string>> buttonsInfoDictionary = new Dictionary<string, List<string>>();
    List<string> listToSave = new List<string>();
    List<string> clickedButtons = new List<string>();
    string arrayAsString = null;
    public List<string> loadList = new List<string>();

    public NorthAmericaPage()
    {
        InitializeComponent();
        CreateButtons();
        CreateAddButtons();
        //ResetPreferences();
    }

    void ResetPreferences()
    {
        Preferences.Clear();

        counter = 0;
        CounterLabel();

        foreach (var button in createButtonList)
        {
            button.IsEnabled = true;
            button.TextColor = Color.FromHex("#E33780");
        }

        clickedButtons.Clear();
        listToSave.Clear();
        buttonsInfoDictionary.Clear();
    }

    void AddClicked(NorthAmerica item)
    {
        string nameOfButton = item.ToString();
        Button button = AddButtonsStackLayout.Children.OfType<Button>().FirstOrDefault(b => b.StyleId == nameOfButton);

        if (button != null && !clickedButtons.Contains(nameOfButton))
        {
            Navigation.PushAsync(new NotePage(SplitCamelCase(nameOfButton)));
            counter++;
            CounterLabel();
            buttonList.Add(button);

            SaveButtonInfo(nameOfButton);
            listToSave.Add(button.StyleId);
            clickedButtons.Add(nameOfButton);
            arrayAsString = string.Join(",", listToSave);

            Preferences.Set("MyListKey", arrayAsString);
            button.IsEnabled = false;
            button.TextColor = Color.FromHex("#3A3A3A");
            SaveButtonInfo(nameOfButton);
        }
    }


    void CreateButtons()
    {
        foreach (NorthAmerica item in Enum.GetValues(typeof(NorthAmerica)))
        {

            Button countryButton = new Button
            {
                Text = GetEnumDisplayName(item),
                Command = new Command(() => InfoClicked(item)),
                TextColor = Color.FromHex("#E33780"),
                BackgroundColor = Color.FromHex("#565656"),
                MaximumWidthRequest = 240,
                TextTransform = TextTransform.Uppercase

            };

            CountryButtonsStackLayout.Children.Add(countryButton);

        }
    }



    string GetEnumDisplayName(Enum value)
    {
        var field = value.GetType().GetField(value.ToString());
        var attribute = (DisplayNameAttribute)Attribute.GetCustomAttribute(field, typeof(DisplayNameAttribute));

        if (attribute != null)
        {
            return SplitCamelCase(attribute.DisplayName);
        }

        var originalName = SplitCamelCase(value.ToString());
        return originalName;
    }



    string SplitCamelCase(string input)
    {
        var result = new StringBuilder();
        foreach (var character in input)
        {
            if (char.IsUpper(character) && result.Length > 0)
            {
                result.Append(' ');
            }
            result.Append(character);
        }
        return result.ToString();
    }


    void CreateAddButtons()
    {
        foreach (NorthAmerica item in Enum.GetValues(typeof(NorthAmerica)))
        {
            Button countryButton = new Button
            {
                StyleId = item.ToString(),
                Text = "ADD",
                Command = new Command(() => AddClicked(item)),
                TextColor = Color.FromHex("#E33780"),
                BackgroundColor = Color.FromHex("#565656"),
                MaximumWidthRequest = 240,
                TextTransform = TextTransform.Uppercase
            };

            createButtonList.Add(countryButton);
            AddButtonsStackLayout.Children.Add(countryButton);

        }
    }


    void LoadButtonInfo()
    {
        foreach (var item in createButtonList)
        {
            string buttonName = item.StyleId;
            if (Preferences.ContainsKey($"{buttonName}_ButtonInfoList"))
            {
                string buttonInfoAsString = Preferences.Get($"{buttonName}_ButtonInfoList", "");
                List<string> buttonInfoList = buttonInfoAsString.Split(',').ToList();

                if (buttonInfoList.Contains(item.StyleId))
                {
                    item.TextColor = Color.FromHex("#3A3A3A");
                    item.IsEnabled = false;
                }
            }
        }
    }


    protected override void OnDisappearing()
    {
        base.OnDisappearing();
    }



    void BackClicked(System.Object sender, System.EventArgs e)
    {

        Navigation.PopAsync();


    }



    void InfoClicked(NorthAmerica NorthAmerica)
    {

        string nameOfButton = SplitCamelCase(NorthAmerica.ToString());
        Navigation.PushAsync(new NoteInformationPage(nameOfButton));


    }






    void SaveButtonInfo(string buttonName)
    {
        List<string> buttonInfoList = createButtonList
            .Where(button => button.StyleId == buttonName)
            .Select(button => button.StyleId)
            .ToList();

        if (!buttonsInfoDictionary.ContainsKey(buttonName))
        {
            buttonsInfoDictionary.Add(buttonName, buttonInfoList);
        }
        else
        {
            buttonsInfoDictionary[buttonName] = buttonInfoList;
        }

        UpdatePreferences();
    }
    void UpdatePreferences()
    {
        foreach (var buttonInfo in buttonsInfoDictionary)
        {
            string buttonName = buttonInfo.Key;
            List<string> buttonInfoList = buttonInfo.Value;

            string buttonInfoAsString = string.Join(",", buttonInfoList);
            Preferences.Set($"{buttonName}_ButtonInfoList", buttonInfoAsString);
        }
    }

    void CounterLabel()
    {
        if (counter == 0)
        {
            VistedLabel.Text = "You did not visit any country yet.";
        }
        else if (counter == 1)
        {
            VistedLabel.Text = $"You visited {counter} country.";
        }
        else
        {
            VistedLabel.Text = $"You visited {counter} countries.";
        }
        Preferences.Set("VisitCountNAmerica", counter);
    }



    protected override void OnAppearing()
    {
        base.OnAppearing();

        if (Preferences.ContainsKey("VisitCountNAmerica"))
        {
            counter = Preferences.Get("VisitCountNAmerica", 0);
        }
        else
        {
            counter = 0;
        }
        CounterLabel();
        LoadButtonInfo();
    }
}
