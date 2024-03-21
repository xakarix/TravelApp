using TravelApp;

namespace TravelApp;

public partial class MainPage : ContentPage
{
	int count = 0;
  

    public MainPage()
	{
        InitializeComponent();
        
    }

    void EuropeClicked(System.Object sender, System.EventArgs e)
    {
        
        Navigation.PushAsync(new EuropePage());
        

    }
    void AsiaClicked(System.Object sender, System.EventArgs e)
    {
        Navigation.PushAsync(new AsiaPage());

    }
    void AfricaClicked(System.Object sender, System.EventArgs e)
    {
        Navigation.PushAsync(new AfricaPage());

    }
    void NAmericaClicked(System.Object sender, System.EventArgs e)
    {
        Navigation.PushAsync(new NorthAmericaPage());

    }
    void SAmericaClicked(System.Object sender, System.EventArgs e)
    {
        Navigation.PushAsync(new SouthAmericaPage());

    }
    void OceaniaClicked(System.Object sender, System.EventArgs e)
    {
        Navigation.PushAsync(new OceaniaPage());

    }

}


