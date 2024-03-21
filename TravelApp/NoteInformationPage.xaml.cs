namespace TravelApp;

public partial class NoteInformationPage : ContentPage
{
    string name = null;
    string nameOfCountry = null;
    private static List<InfoData> infoList = new List<InfoData>();

    public NoteInformationPage(string nameOfButton)
	{
		InitializeComponent();
        Country.Text = nameOfButton;
        name = nameOfButton;
        LoadInfo();
        startDatePicker.IsEnabled = false;
        endDatePicker.IsEnabled = false;
    }
    void BackClicked(System.Object sender, System.EventArgs e)
    {
        Navigation.PopAsync();

    }

    public static void AddInfo(InfoData info)
    {
        infoList.Add(info);
        Console.WriteLine(info);
    }
    async void LoadInfo()
    {
        var infoList = await DatabaseService.GetInfoDataByCountryAsync(nameOfCountry);

        Console.WriteLine($"Liczba pobranych rekordów: {infoList.Count}");

        // Wyświetl dane w interfejsie użytkownika
        foreach (var selectedInfo in infoList)
        {
            if(selectedInfo.Country == name)
            {
                startDatePicker.Date = selectedInfo.StartDate;
                endDatePicker.Date = selectedInfo.EndDate;
                NoteText.Text = selectedInfo.LabelText;
                
                startDatePicker.IsEnabled = false;
                endDatePicker.IsEnabled = false;
                NoteText.IsEnabled = false;

            }
            Console.WriteLine($"StartDate: {selectedInfo.StartDate}, EndDate: {selectedInfo.EndDate}, LabelText: {selectedInfo.LabelText}");
        }
    }




}
