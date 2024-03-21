using System.Text;

namespace TravelApp;

public partial class NotePage : ContentPage
{
    string noteText = null;
    private Europe selectedCountry;
    string nameOfCountry = null;

    public NotePage(string nameOfButton)
	{
		InitializeComponent();
        Country.Text = nameOfButton;
        //this.selectedCountry = selectedCountry;
        nameOfCountry = nameOfButton;
        BindingContext = new InfoData();
        
	}

    async void NoteClicked(System.Object sender, System.EventArgs e)
    {
        try
        {
            InfoData info = new InfoData
            {
                Country = nameOfCountry,
                StartDate = startDatePicker.Date,
                EndDate = endDatePicker.Date,
                LabelText = Note.Text
            };

            await DatabaseService.AddInfoData(info);
            //await DatabaseService.DeleteAllEntitiesAsync();
            await Navigation.PopAsync();

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception: {ex.Message}");
        }
    }

    void Note_TextChanged(System.Object sender, Microsoft.Maui.Controls.TextChangedEventArgs e)
    {
        if (e.NewTextValue == "Write a note...")
        {
            Note.Text = string.Empty;
        }
    }

    private void OnStartDateSelected(object sender, DateChangedEventArgs e)
    {
        if (e.NewDate > endDatePicker.Date)
        {
            startDatePicker.Date = endDatePicker.Date;
        }
        DateTime selectedDate = startDatePicker.Date;

    }
    private void OnEndDateSelected(object sender, DateChangedEventArgs e)
    {
        if (e.NewDate < startDatePicker.Date)
        {
            endDatePicker.Date = startDatePicker.Date;
        }
    }
}
