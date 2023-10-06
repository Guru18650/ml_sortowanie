namespace ml_sortowanie
{
    public partial class MainPage : ContentPage
    {

        List<string> data = new List<string>();
        string chars = "qwertyuioplkjhgfdsazxcvbnm";
        static Random rnd = new Random();
        List<String> unsort = new List<string>();

        public MainPage()
        {
            InitializeComponent();
            tryb.SelectedIndex = 0;
        }

       

        private void generuj_Clicked(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(ilosc.Text))
            {
                DisplayAlert("Błąd", "Wpisz wszystkie dane", "OK");
                return;
            }
            data.Clear();
            if(lCheck.IsChecked) {
                for (int i = 0; i < int.Parse(ilosc.Text); i++)
                {
                    data.Add(rnd.Next(0,9).ToString());
                }
            } else
            {
                for (int i = 0; i < int.Parse(ilosc.Text); i++)
                {
                    data.Add(chars[rnd.Next(0, chars.Length)].ToString());
                }
            }

            unsort = new List<string>(data);
            if(tryb.SelectedIndex == 0)
            { 
                data.Sort();
            } else if(tryb.SelectedIndex == 1)
            {
                data.Sort();
                data.Reverse();
            } else
            {
                data.Shuffle();
            }



            sort.IsEnabled = true;
            nosort.IsEnabled = true;
            stats.IsEnabled = true;

        }

        private void sort_Clicked(object sender, EventArgs e)
        {
            var s = "";
            foreach (var item in data)
            {
                s += item+", ";
            }
            DisplayAlert("Posortowane", s, "ok");
        }

        private void nosort_Clicked(object sender, EventArgs e)
        {
            var s = "";
            foreach (var item in unsort)
            {
                s += item + ", ";
            }
            DisplayAlert("Nie posortowane", s, "ok");
        }

        private void stats_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Statystyki(data));
        }

       
    }


}