using InternettoViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace VarerBookingapp
{
    public class InternettoViewModel
    {
        private string navnVarer;
        private int antalVarer;

        public ObservableCollection<TilføjVarer> OC_varer { get; set; }

        public string NavnVarer { get => navnVarer; set => navnVarer = value; }
        public int AntalVarer { get => antalVarer; set => antalVarer = value; }


        private string jsonVarer;

        public string JsonVarer
        {
            get { return jsonVarer; }
            set { jsonVarer = value; }
        }

        StorageFolder localfolder = null;

        private readonly string filnavn = "varer1.json";

        public TilføjVarer SelectedOrdreVarer { get; set; }
        public RelayCommand AddNyVarer { get; set; }
        public RelayCommand SletSelectedVarer { get; set; }
        public RelayCommand GemData { get; set; }
        public RelayCommand HentData { get; set; }

        public InternettoViewModel()
        {
            OC_varer = new ObservableCollection<TilføjVarer>();

            //Testdata 
            OC_varer.Add(new TilføjVarer("Banan", 10));
            OC_varer.Add(new TilføjVarer("Cola", 1));
            OC_varer.Add(new TilføjVarer("Ananas", 3));

            AddNyVarer = new RelayCommand(AddVarer);
            SletSelectedVarer = new RelayCommand(SletVarer, canDeleteVarerListe);

            SelectedOrdreVarer = new TilføjVarer();

            localfolder = ApplicationData.Current.LocalFolder;

            GemData = new RelayCommand(GemDataTilDiskAsync);

            HentData = new RelayCommand(HentDataFraDiskAsync);
            DanData();
        }
 
        public void AddVarer()
        {
            TilføjVarer oVarer = new TilføjVarer(NavnVarer, AntalVarer);

            OC_varer.Add(oVarer);

            SletSelectedVarer.RaiseCanExecuteChanged();
        }

        private void SletVarer()
        {
            OC_varer.Remove(SelectedOrdreVarer);
            SletSelectedVarer.RaiseCanExecuteChanged();
        }

        private bool canDeleteVarerListe()
        {
            return OC_varer.Count > 0;
        }


        private string GetJson()
        {
            string json = JsonConvert.SerializeObject(OC_varer);
            return json;
        }


        private async void GemDataTilDiskAsync()
        {
            this.jsonVarer = GetJson();

            StorageFile file = await localfolder.CreateFileAsync(filnavn, CreationCollisionOption.ReplaceExisting);

            await FileIO.WriteTextAsync(file, this.jsonVarer);

            SletSelectedVarer.RaiseCanExecuteChanged();
        }

        private async void HentDataFraDiskAsync()
        {
            OC_varer.Clear();
            List<TilføjVarer> nyListe = new List<TilføjVarer>();
            nyListe = await PersistencyService.HentDataFraDiskAsyncPS();

            foreach (var varer in nyListe)
            {
                this.OC_varer.Add(varer);
            }
            SletSelectedVarer.RaiseCanExecuteChanged(); 
        }

        private void DanData()
        {
        }

    }
}
