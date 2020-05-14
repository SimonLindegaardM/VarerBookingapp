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
    public class PersistencyService
    {
        private static readonly string filnavn = "blomster1.json";

        /// <summary>
        /// Gemmer json data fra liste i localfolder
        /// </summary>
        public static async Task GemDataTilDiskAsyncPS(ObservableCollection<TilføjVarer> oc_varer)
        {
            string jsonText = GetJsonPS(oc_varer);
            StorageFolder localfolder = ApplicationData.Current.LocalFolder;
            StorageFile file = await localfolder.CreateFileAsync(filnavn, CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(file, jsonText);
        }

        /// <summary>
        /// Giver mig Jsonformat for OC_blomster object
        /// </summary>
        /// <returns></returns>
        public static string GetJsonPS(ObservableCollection<TilføjVarer> oc_blomst)
        {
            string json = JsonConvert.SerializeObject(oc_blomst);
            return json;
        }


        /// <summary>
        /// metode som modtager en string af json og deserialiserer til objekter af OrdreBlomst
        /// </summary>
        /// <param name="jsonText"></param>
        private static List<TilføjVarer> DeserialiserJson(string jsonText)
        {
            List<TilføjVarer> nyListe = JsonConvert.DeserializeObject<List<TilføjVarer>>(jsonText);
            return nyListe;
        }

        /// <summary>
        /// Henter en json fil fra disken 
        /// </summary>
        public static async Task<List<TilføjVarer>> HentDataFraDiskAsyncPS()
        {
            StorageFolder localfolder = ApplicationData.Current.LocalFolder;
            StorageFile file = await localfolder.GetFileAsync(filnavn);
            string jsonText = await FileIO.ReadTextAsync(file);
            List<TilføjVarer> list = new List<TilføjVarer>();
            list = DeserialiserJson(jsonText);

            return list;
        }

    }
}
