using System.Collections.ObjectModel;

namespace ml_sortowanie;

public partial class Statystyki : ContentPage
{
	List<lstat> staty = new List<lstat>();

	public Statystyki(List<string> s)
	{
        foreach (var item in s)
        {
			int i = staty.IndexOf(staty.Find(r => r.litera == item));
			if(i == -1)
			{
				staty.Add(new lstat() { ilosc = 1, litera = item });
			} else
			{
            staty[i].ilosc = staty[i].ilosc + 1;
            }
        }

        InitializeComponent();
		lista.ItemsSource = staty;
	}

	public class lstat
	{
		public string litera { get; set; }
		public int ilosc { get ; set;}
	}
}