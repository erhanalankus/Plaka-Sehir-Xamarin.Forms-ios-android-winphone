using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace PlakaSehir
{
    public class MainPage : ContentPage
    {
        protected override void OnAppearing()
        {
            base.OnAppearing();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        List<City> sehirler = new List<City>();
        string selectedNumber;
        City cityToGo;

        public MainPage()
        {
            this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 105);

            PopulateCitylist();

            View advertisement;
            Label header;
            Label pickerTip;
            Picker picker;
            Button button;

            CreateUI(out advertisement, out header, out pickerTip, out picker, out button);

            PopulatePicker(picker);

            picker.SelectedIndexChanged += (sender, args) =>
            {
                if (picker.SelectedIndex < 9)
                {
                    selectedNumber = "0" + (picker.SelectedIndex + 1).ToString();
                }
                else
                {
                    selectedNumber = (picker.SelectedIndex + 1).ToString();
                }
            };

            button.Clicked += (sender, args) =>
            {
                cityToGo = sehirler.FirstOrDefault(p => p.Plate == selectedNumber);
                Navigation.PushAsync(new DetailPage(cityToGo));
            };

            this.Content = new StackLayout
            {
                Children =
                {
                    advertisement,
                    header,
                    pickerTip,
                    picker,
                    button
                }
            };
        }

        private void CreateUI(out View advertisement, out Label header, out Label pickerTip, out Picker picker, out Button button)
        {
            advertisement = new AdControl
            {
                VerticalOptions = LayoutOptions.StartAndExpand
            };
            header = new Label
            {
                Text = "Plaka seç",
                FontAttributes = FontAttributes.Bold,
                FontSize = 50,
                HorizontalOptions = LayoutOptions.Center,
            };
            pickerTip = new Label
            {
                Text = "Plaka seçmek için alt satıra dokun",
                FontSize = 15,
                Opacity = 0.4,
                VerticalOptions = LayoutOptions.EndAndExpand

            };
            picker = new Picker
            {
                Title = "Plaka",
                VerticalOptions = LayoutOptions.StartAndExpand
            };
            button = new Button
            {
                Text = " Göster ",
                FontSize = 30,
                BorderWidth = 1,
                HorizontalOptions = LayoutOptions.Center,
            };
        }

        private void PopulatePicker(Picker picker)
        {
            for (int i = 0; i < sehirler.Count; i++)
            {
                picker.Items.Add(sehirler[i].Plate);
            }
            picker.SelectedIndex = 0;
            selectedNumber = "01";
        }

        private void PopulateCitylist()
        {
            sehirler.Add(new City
            {
                Plate = "01",
                Name = "Adana",
                PictureAddress = "adana640.png",
                TriviaList = new List<Trivia>
                {
                    new Trivia() {Question=AppResources.SoruNufus, Answer="Adana'nın nüfusu: 2.165.595 kişi" },
                    new Trivia() {Question=AppResources.SoruNufusPerKmSq, Answer="Adana'da km\xB2 başına düşen insan sayısı: 153 kişi" },
                    new Trivia() {Question=AppResources.SoruBelediyeBaskani, Answer="Adana'nın Belediye Başkanı: MHP'den Hüzeyin Sözlü" },
                    new Trivia() {Question=AppResources.SoruIlceSayisi, Answer="Adana iline bağlı 15 adet ilçe bulunmaktadır." },
                    new Trivia() {Question=AppResources.SoruIlceBelediyeler, Answer="MHP'de 8 ilçe: Saimbeyli, Feke, Kozan, İmamoğlu, Sarıçam, Karaisalı, Pozantı, Yumurtalık. \nAKP'de 4 ilçe: Aladağ, Ceyhan, Tufanbeyli, Yüreğir. \nCHP'de 3 ilçe: Çukurova, Seyhan, Karataş" },
                    new Trivia() {Question=AppResources.SoruTelefonKod, Answer="Adana'nın telefon alan kodu: (+90)322" },
                    new Trivia() {Question=AppResources.SoruMaxTemp, Answer="Adana'da şimdiye kadarki en yüksek sıcaklık, 24 Ağustos 1958'de 45,6 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruMinTemp, Answer="Adana'da şimdiye kadarki en düşük sıcaklık, 20 Ocak 1964'te -8,1 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruUniSayisi, Answer="Adana ilinde 3 adet üniversite bulunmaktadır. Çukurova Üniversitesi(1973), Adana Bilim ve Teknoloji Üniversitesi(2011), Kanuni Üniversitesi(2013)." }                    
                }
            });
            sehirler.Add(new City
            {
                Plate = "02",
                Name = "Adıyaman",
                PictureAddress = "adiyaman640.png",
                TriviaList = new List<Trivia>
                {
                    new Trivia() {Question=AppResources.SoruNufus, Answer="Adıyaman'ın nüfusu: 597.835 kişi" },
                    new Trivia() {Question=AppResources.SoruNufusPerKmSq, Answer="Adıyaman'da km\xB2 başına düşen insan sayısı: 78 kişi " },
                    new Trivia() {Question=AppResources.SoruBelediyeBaskani, Answer="Adıyaman'ın Belediye Başkanı: AKP'den Fehmi Hüsrev Kutlu " },
                    new Trivia() {Question=AppResources.SoruIlceSayisi, Answer="Adıyaman iline bağlı Merkez dahil 9 adet ilçe bulunmaktadır." },
                    new Trivia() {Question=AppResources.SoruIlceBelediyeler, Answer="AKP'de 5 ilçe: Merkez, Gölbaşı, Samsat, Kahta, Çelikhan. \nSP'de 2 ilçe: Besni, Gerger. \nCHP'de 1 ilçe: Tut. \nBBP'de 1 ilçe: Sincik." },
                    new Trivia() {Question=AppResources.SoruTelefonKod, Answer="Adıyaman'ın telefon alan kodu: (+90)416" },
                    new Trivia() {Question=AppResources.SoruMaxTemp, Answer="Adıyaman'da şimdiye kadarki en yüksek sıcaklık, 30 Temmuz 2000'de 45,3 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruMinTemp, Answer="Adıyaman'da şimdiye kadarki en düşük sıcaklık, 24 Ocak 1972'de -14,4 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruUniSayisi, Answer="Adıyaman ilinde 1 adet üniversite bulunmaktadır. Adıyaman Üniversitesi(2006)." }
                }
            });
            sehirler.Add(new City
            {
                Plate = "03",
                Name = "Afyonkarahisar",
                PictureAddress = "afyonkarahisar640.png",
                TriviaList = new List<Trivia>
                {
                    new Trivia() {Question=AppResources.SoruNufus, Answer="Afyonkarahisar'ın nüfusu: 706.371 kişi" },
                    new Trivia() {Question=AppResources.SoruNufusPerKmSq, Answer="Afyonkarahisar'da km\xB2 başına düşen insan sayısı: 48 kişi " },
                    new Trivia() {Question=AppResources.SoruBelediyeBaskani, Answer="Afyonkarahisar'ın Belediye Başkanı: AKP'den Burhanettin Çoban" },
                    new Trivia() {Question=AppResources.SoruIlceSayisi, Answer="Afyonkarahisar iline bağlı Merkez dahil 18 adet ilçe bulunmaktadır." },
                    new Trivia() {Question=AppResources.SoruIlceBelediyeler, Answer="AKP'de 8 ilçe: Merkez, Hocalar, Sandıklı, Sinanpaşa, Şuhut, İscehisar, Çobanlar, Bolvadin. \nMHP'de 6 ilçe: Emirdağ, Çay, İhsaniye, Dinar, Başmakçı, Kızılören. \nCHP'de 4 ilçe: Bayat, Sultandağı, Evciler, Dazkırı" },
                    new Trivia() {Question=AppResources.SoruTelefonKod, Answer="Afyonkarahisar'ın telefon alan kodu: (+90)272" },
                    new Trivia() {Question=AppResources.SoruMaxTemp, Answer="Afyonkarahisar'da şimdiye kadarki en yüksek sıcaklık, 29 Temmuz 2000'de 39,8 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruMinTemp, Answer="AfyonKarahisar'da şimdiye kadarki en düşük sıcaklık, 28 Ocak 1954'te -27,0 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruUniSayisi, Answer="Afyonkarahisar ilinde 1 adet üniversite bulunmaktadır. Afyon Kocatepe Üniversitesi(1992)." }
                }
            });
            sehirler.Add(new City
            {
                Plate = "04",
                Name = "Ağrı",
                PictureAddress = "agri640.png",
                TriviaList = new List<Trivia>
                {
                    new Trivia() {Question=AppResources.SoruNufus, Answer="Ağrı'nın nüfusu: 549.435 kişi" },
                    new Trivia() {Question=AppResources.SoruNufusPerKmSq, Answer="Ağrı'da km\xB2 başına düşen insan sayısı: 48 kişi " },
                    new Trivia() {Question=AppResources.SoruBelediyeBaskani, Answer="Ağrı'ın Belediye Eş Başkanları: BDP'den Mukaddes Kubilay ve Sırrı Sakık" },
                    new Trivia() {Question=AppResources.SoruIlceSayisi, Answer="Ağrı iline bağlı Merkez dahil 8 adet ilçe bulunmaktadır." },
                    new Trivia() {Question=AppResources.SoruIlceBelediyeler, Answer="BDP'de 4 ilçe: Merkez, Tutak, Diyadin, Doğubeyazıt. \nAKP'de 4 ilçe: Taşlıçay, Hamur, Patnos, Eleşkirt." },
                    new Trivia() {Question=AppResources.SoruTelefonKod, Answer="Ağrı'nın telefon alan kodu: (+90)472" },
                    new Trivia() {Question=AppResources.SoruMaxTemp, Answer="Ağrı'da şimdiye kadarki en yüksek sıcaklık, 10 Ağustos 1961'de 39,9 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruMinTemp, Answer="Ağrı'da şimdiye kadarki en düşük sıcaklık, 20 Ocak 1972'de -45,6 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruUniSayisi, Answer="Ağrı ilinde 1 adet üniversite bulunmaktadır. Ağrı İbrahim Çeçen Üniversitesi(2007)." }
                }
            });
            sehirler.Add(new City
            {
                Plate = "05",
                Name = "Amasya",
                PictureAddress = "amasya640.png",
                TriviaList = new List<Trivia>
                {
                    new Trivia() {Question=AppResources.SoruNufus, Answer="Amasya'nın nüfusu: 321.913 kişi" },
                    new Trivia() {Question=AppResources.SoruNufusPerKmSq, Answer="Amasya'da km\xB2 başına düşen insan sayısı: 56 kişi " },
                    new Trivia() {Question=AppResources.SoruBelediyeBaskani, Answer="Amasya'nın Belediye Başkanı: AKP'den Cafer Özdemir" },
                    new Trivia() {Question=AppResources.SoruIlceSayisi, Answer="Amasya iline bağlı Merkez dahil 7 adet ilçe bulunmaktadır." },
                    new Trivia() {Question=AppResources.SoruIlceBelediyeler, Answer="AKP'de 4 ilçe: Merkez, Göynücek, Suluova, Taşova. \nCHP'de 2 ilçe: Merzifon, Gümüşhacıköy. \nSP'de 1 ilçe: Hamamözü." },
                    new Trivia() {Question=AppResources.SoruTelefonKod, Answer="Amasya'nın telefon alan kodu: (+90)358" },
                    new Trivia() {Question=AppResources.SoruMaxTemp, Answer="Amasya'da şimdiye kadarki en yüksek sıcaklık, 30 Temmuz 2000'de 45,0 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruMinTemp, Answer="Amasya'da şimdiye kadarki en düşük sıcaklık, 15 Ocak 2008'de -21,0 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruUniSayisi, Answer="Amasya ilinde 1 adet üniversite bulunmaktadır. Amasya Üniversitesi(2006)." }
                }
            });
            sehirler.Add(new City
            {
                Plate = "06",
                Name = "Ankara",
                PictureAddress = "ankara640.png",
                TriviaList = new List<Trivia>
                {
                    new Trivia() {Question=AppResources.SoruNufus, Answer="Ankara'nın nüfusu: 5.150.072 kişi" },
                    new Trivia() {Question=AppResources.SoruNufusPerKmSq, Answer="Ankara'da km\xB2 başına düşen insan sayısı: 202 kişi " },
                    new Trivia() {Question=AppResources.SoruBelediyeBaskani, Answer="Ankara'nın Belediye Başkanı: AKP'den İbrahim Melih Gökçek" },
                    new Trivia() {Question=AppResources.SoruIlceSayisi, Answer="Ankara iline bağlı 25 adet ilçe bulunmaktadır." },
                    new Trivia() {Question=AppResources.SoruIlceBelediyeler, Answer="AKP'de 20 ilçe: Akyurt, Altındağ, Ayaş, Bala, Beypazarı, Çamlıdere, Çubuk, Elmadağ, Evren, Gölbaşı, Güdül, Kalecik, Kazan, Keçiören, Kızılcahamam, Mamak, Nallıhan, Pursaklar, Sincan, Şereflikoçhisar. \nCHP'de 2 ilçe: Çankaya, Yenimahalle. \nMHP'de 2 ilçe: Polatlı, Etimesgut. \nDP'de 1 ilçe: Haymana." },
                    new Trivia() {Question=AppResources.SoruTelefonKod, Answer="Ankara'nın telefon alan kodu: (+90)312" },
                    new Trivia() {Question=AppResources.SoruMaxTemp, Answer="Ankara'da şimdiye kadarki en yüksek sıcaklık, 27 Temmuz 2012'de 41,0 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruMinTemp, Answer="Ankara'da şimdiye kadarki en düşük sıcaklık, 25 Ocak 1950'de -24,4 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruUniSayisi, Answer="Ankara ilinde 18 adet üniversite bulunmaktadır. Anka Teknoloji Üniversitesi(2013), Ankara Üniversitesi(1946), Ankara Sosyal Bilimler Üniversitesi(2013), Atılım Üniversitesi(1996), Başkent Üniversitesi(1994), Bilkent Üniversitesi(1984), Çankaya Üniversitesi(1997), Gazi Üniversitesi(1926), Hacettepe Üniversitesi(1967), İpek Üniversitesi(2011), Orta Doğu Teknik Üniversitesi(1956), TED Üniversitesi(2012), TOBB Ekonomi ve Teknoloji Üniversitesi(2003), Turgut Özal Üniversitesi(2009), Türk Hava Kurumu Üniversitesi(2011), Ufuk Üniversitesi(1999), Yıldırım Beyazıt Üniversitesi(2010), Yüksek İhtisas Üniversitesi(2011)." }
                }
            });
            sehirler.Add(new City
            {
                Plate = "07",
                Name = "Antalya",
                PictureAddress = "antalya640.png",
                TriviaList = new List<Trivia>
                {
                    new Trivia() {Question=AppResources.SoruNufus, Answer="Antalya'nın nüfusu: 2.222.562 kişi" },
                    new Trivia() {Question=AppResources.SoruNufusPerKmSq, Answer="Antalya'da km\xB2 başına düşen insan sayısı: 106 kişi " },
                    new Trivia() {Question=AppResources.SoruBelediyeBaskani, Answer="Antalya'nın Belediye Başkanı: AKP'den Menderes Mehmet Tevfik Türel" },
                    new Trivia() {Question=AppResources.SoruIlceSayisi, Answer="Antalya iline bağlı 19 adet ilçe bulunmaktadır." },
                    new Trivia() {Question=AppResources.SoruIlceBelediyeler, Answer="AKP'de 10 ilçe: Kaş, Demre, Elmalı, Kumluca, Kepez, Aksu, Serik, Akseki, Gündoğmuş, Gazipaşa. \nCHP'de 5 ilçe: Konyaaltı, Döşemealtı, Muratpaşa, Manavgat, İbradı. \nMHP'de 4 ilçe: Finike, Kemer, Korkuteli, Alanya." },
                    new Trivia() {Question=AppResources.SoruTelefonKod, Answer="Antalya'nın telefon alan kodu: (+90)242" },
                    new Trivia() {Question=AppResources.SoruMaxTemp, Answer="Antalya'da şimdiye kadarki en yüksek sıcaklık, 12 Temmuz 2000'de 45,0 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruMinTemp, Answer="Antalya'da şimdiye kadarki en düşük sıcaklık, 5 Şubat 1950'de -4,6 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruUniSayisi, Answer="Antalya ilinde 5 adet üniversite bulunmaktadır. Akdeniz Üniversitesi(1982), Alanya Alaaddin Keykubat Üniversitesi(2015), Alanya Hamdullah Emin Paşa Üniversitesi(2011), Antalya AKEV Üniversitesi(2015), Uluslararası Antalya Üniversitesi(2009)." }
                }
            });
            sehirler.Add(new City
            {
                Plate = "08",
                Name = "Artvin",
                PictureAddress = "artvin640.png",
                TriviaList = new List<Trivia>
                {
                    new Trivia() {Question=AppResources.SoruNufus, Answer="Artvin'in nüfusu: 169.674 kişi" },
                    new Trivia() {Question=AppResources.SoruNufusPerKmSq, Answer="Artvin'de km\xB2 başına düşen insan sayısı: 23 kişi " },
                    new Trivia() {Question=AppResources.SoruBelediyeBaskani, Answer="Artvin'in Belediye Başkanı: AKP'den Mehmet Kocatepe" },
                    new Trivia() {Question=AppResources.SoruIlceSayisi, Answer="Artvin iline bağlı Merkez dahil 8 adet ilçe bulunmaktadır." },
                    new Trivia() {Question=AppResources.SoruIlceBelediyeler, Answer="AKP'de 7 ilçe: Merkez, Yusufeli, Murgul, Arhavi, Hopa, Borçka, Şavşat. \nCHP'de 1 ilçe: Ardanuç." },
                    new Trivia() {Question=AppResources.SoruTelefonKod, Answer="Artvin'in telefon alan kodu: (+90)466" },
                    new Trivia() {Question=AppResources.SoruMaxTemp, Answer="Artvin'de şimdiye kadarki en yüksek sıcaklık, 18 Ağustos 1961'de 43,0 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruMinTemp, Answer="Artvin'de şimdiye kadarki en düşük sıcaklık, 14 Ocak 1950'de -16,1 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruUniSayisi, Answer="Artvin ilinde 1 adet üniversite bulunmaktadır. Artvin Çoruh Üniversitesi(2007)." }
                }
            });
            sehirler.Add(new City
            {
                Plate = "09",
                Name = "Aydın",
                PictureAddress = "aydin640.png",
                TriviaList = new List<Trivia>
                {
                    new Trivia() {Question=AppResources.SoruNufus, Answer="Aydın'ın nüfusu: 1.041.979 kişi" },
                    new Trivia() {Question=AppResources.SoruNufusPerKmSq, Answer="Aydın'da km\xB2 başına düşen insan sayısı: 131 kişi " },
                    new Trivia() {Question=AppResources.SoruBelediyeBaskani, Answer="Aydın'ın Belediye Başkanı: CHP'den Özlem Çerçioğlu" },
                    new Trivia() {Question=AppResources.SoruIlceSayisi, Answer="Aydın iline bağlı 17 adet ilçe bulunmaktadır." },
                    new Trivia() {Question=AppResources.SoruIlceBelediyeler, Answer="CHP'de 9 ilçe: Bozdoğan, Çine, Didim, Efeler, Karacasu, Koçarlı, Kuşadası, Söke, Sultanhisar. \nMHP'de 4 ilçe: Germencik, İncirliova, Karpuzlu, Nazilli. \nAKP'de 4 ilçe: Köşk, Kuyucak, Yenipazar, Buharkent" },
                    new Trivia() {Question=AppResources.SoruTelefonKod, Answer="Aydın'ın telefon alan kodu: (+90)256" },
                    new Trivia() {Question=AppResources.SoruMaxTemp, Answer="Aydın'da şimdiye kadarki en yüksek sıcaklık, 27 Temmuz 1987'de'de 44,6 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruMinTemp, Answer="Aydın'da şimdiye kadarki en düşük sıcaklık, 18 Ocak 1964'te -7,6 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruUniSayisi, Answer="Aydın ilinde 1 adet üniversite bulunmaktadır. Adnan Menderes Üniversitesi(1992)." }
                }
            });
            sehirler.Add(new City
            {
                Plate = "10",
                Name = "Balıkesir",
                PictureAddress = "balikesir640.png",
                TriviaList = new List<Trivia>
                {
                    new Trivia() {Question=AppResources.SoruNufus, Answer="Balıkesir'in nüfusu: 1.189.057 kişi" },
                    new Trivia() {Question=AppResources.SoruNufusPerKmSq, Answer="Balıkesir'de km\xB2 başına düşen insan sayısı: 83 kişi " },
                    new Trivia() {Question=AppResources.SoruBelediyeBaskani, Answer="Balıkesir'in Belediye Başkanı: AKP'den Ahmet Edip Uğur" },
                    new Trivia() {Question=AppResources.SoruIlceSayisi, Answer="Balıkesir iline bağlı 20 adet ilçe bulunmaktadır." },
                    new Trivia() {Question=AppResources.SoruIlceBelediyeler, Answer="AKP'de 14 ilçe: Gömeç, Burhaniye, Havran, İvrindi, Savaştepe, Altıeylül, Sındırgı, Bigadiç, Dursunbey, Kepsut, Susurluk, Karesi, Gönen, Marmara. \nCHP'de 5 ilçe: Ayvalık, Edremit, Manyas, Bandırma, Erdek. \nMHP'de 1 ilçe: Balya." },
                    new Trivia() {Question=AppResources.SoruTelefonKod, Answer="Balıkesir'in telefon alan kodu: (+90)266" },
                    new Trivia() {Question=AppResources.SoruMaxTemp, Answer="Balıkesir'de şimdiye kadarki en yüksek sıcaklık, 25 Ağustos 1958'de 43,7 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruMinTemp, Answer="Balıkesir'de şimdiye kadarki en düşük sıcaklık, 15 Şubat 2004'te -18,8 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruUniSayisi, Answer="Balıkesir ilinde 2 adet üniversite bulunmaktadır. Balıkesir Üniversitesi(1992), Bandırma Onyedi Eylül Üniversitesi(2015)." }
                }
            });
            sehirler.Add(new City
            {
                Plate = "11",
                Name = "Bilecik",
                PictureAddress = "bilecik640.png",
                TriviaList = new List<Trivia>
                {
                    new Trivia() {Question=AppResources.SoruNufus, Answer="Bilecik'in nüfusu: 209.925 kişi" },
                    new Trivia() {Question=AppResources.SoruNufusPerKmSq, Answer="Bilecik'te km\xB2 başına düşen insan sayısı: 49 kişi " },
                    new Trivia() {Question=AppResources.SoruBelediyeBaskani, Answer="Bilecik'in Belediye Başkanı: AKP'den Selim Yağcı" },
                    new Trivia() {Question=AppResources.SoruIlceSayisi, Answer="Bilecik iline bağlı Merkez dahil 8 adet ilçe bulunmaktadır." },
                    new Trivia() {Question=AppResources.SoruIlceBelediyeler, Answer="AKP'de 4 ilçe: Merkez, Bozüyük, Pazaryeri, Osmaneli. \nMHP'de 3 ilçe: Söğüt, İnhisar, Yenipazar. \nCHP'de 1 ilçe: Gölpazarı." },
                    new Trivia() {Question=AppResources.SoruTelefonKod, Answer="Bilecik'in telefon alan kodu: (+90)228" },
                    new Trivia() {Question=AppResources.SoruMaxTemp, Answer="Bilecik'te şimdiye kadarki en yüksek sıcaklık, 13 Temmuz 2000'de 41,0 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruMinTemp, Answer="Bilecik'te şimdiye kadarki en düşük sıcaklık, 13 Ocak 1950'de -16,0 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruUniSayisi, Answer="Bilecik ilinde 1 adet üniversite bulunmaktadır. Bilecik Şeyh Edebali Üniversitesi(2007)." }
                }
            });
            sehirler.Add(new City
            {
                Plate = "12",
                Name = "Bingöl",
                PictureAddress = "bingol640.png",
                TriviaList = new List<Trivia>
                {
                    new Trivia() {Question=AppResources.SoruNufus, Answer="Bingöl'ün nüfusu: 266.019 kişi" },
                    new Trivia() {Question=AppResources.SoruNufusPerKmSq, Answer="Bingöl'de km\xB2 başına düşen insan sayısı: 32 kişi " },
                    new Trivia() {Question=AppResources.SoruBelediyeBaskani, Answer="Bingöl'ün Belediye Başkanı: AKP'den Yücel Barakazi" },
                    new Trivia() {Question=AppResources.SoruIlceSayisi, Answer="Bingöl iline bağlı Merkez dahil 8 adet ilçe bulunmaktadır." },
                    new Trivia() {Question=AppResources.SoruIlceBelediyeler, Answer="AKP'de 6 ilçe: Merkez, Genç, Solhan, Karlıova, Adaklı, Yedisu. \nCHP'de 2 ilçe: Yayladere, Kiğı" },
                    new Trivia() {Question=AppResources.SoruTelefonKod, Answer="Bingöl'ün telefon alan kodu: (+90)426" },
                    new Trivia() {Question=AppResources.SoruMaxTemp, Answer="Bingöl'de şimdiye kadarki en yüksek sıcaklık, 26 Temmuz 2001'de 42,0 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruMinTemp, Answer="Bingöl'de şimdiye kadarki en düşük sıcaklık, 27 Aralık 1992'de -25,1 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruUniSayisi, Answer="Bingöl ilinde 1 adet üniversite bulunmaktadır. Bingöl Üniversitesi(2007)" }
                }
            });
            sehirler.Add(new City
            {
                Plate = "13",
                Name = "Bitlis",
                PictureAddress = "bitlis640.png",
                TriviaList = new List<Trivia>
                {
                    new Trivia() {Question=AppResources.SoruNufus, Answer="Bitlis'in nüfusu: 338.023 kişi" },
                    new Trivia() {Question=AppResources.SoruNufusPerKmSq, Answer="Bitlis'de km\xB2 başına düşen insan sayısı: 38 kişi " },
                    new Trivia() {Question=AppResources.SoruBelediyeBaskani, Answer="Bitlis'in Belediye Eş Başkanları: BDP'den Nevin Daşdemir Dağkıran ve Hüseyin Olan." },
                    new Trivia() {Question=AppResources.SoruIlceSayisi, Answer="Bitlis iline bağlı Merkez dahil 7 adet ilçe bulunmaktadır." },
                    new Trivia() {Question=AppResources.SoruIlceBelediyeler, Answer="BDP'de 4 ilçe: Merkez, Güroymak, Hizan, Mutki. \nAKP'de 3 ilçe: Adilcevaz, Ahlat, Tatvan." },
                    new Trivia() {Question=AppResources.SoruTelefonKod, Answer="Bitlis'in telefon alan kodu: (+90)434" },
                    new Trivia() {Question=AppResources.SoruMaxTemp, Answer="Bitlis'te şimdiye kadarki en yüksek sıcaklık, 17 Temmuz 2000'de 38,0 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruMinTemp, Answer="Bitlis'te şimdiye kadarki en düşük sıcaklık, 15 Şubat 1993'te -22,0 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruUniSayisi, Answer="Bitlis ilinde 1 adet üniversite bulunmaktadır. Bitlis Eren Üniversitesi(2007)." }
                }
            });
            sehirler.Add(new City
            {
                Plate = "14",
                Name = "Bolu",
                PictureAddress = "bolu640.png",
                TriviaList = new List<Trivia>
                {
                    new Trivia() {Question=AppResources.SoruNufus, Answer="Bolu'nun nüfusu: 284.789 kişi" },
                    new Trivia() {Question=AppResources.SoruNufusPerKmSq, Answer="Bolu'da km\xB2 başına düşen insan sayısı: 34 kişi " },
                    new Trivia() {Question=AppResources.SoruBelediyeBaskani, Answer="Bolu'nun Belediye Başkanı: AKP'den Alaaddin Yılmaz" },
                    new Trivia() {Question=AppResources.SoruIlceSayisi, Answer="Bolu iline bağlı Merkez dahil 9 adet ilçe bulunmaktadır." },
                    new Trivia() {Question=AppResources.SoruIlceBelediyeler, Answer="AKP'de 6 ilçe: Merkez, Göynük, Seben, Dörtdivan, Yeniçağa, Gerede. \nCHP'de 3 ilçe: Mudurnu, Kıbrıscık, Mengen." },
                    new Trivia() {Question=AppResources.SoruTelefonKod, Answer="Bolu'nun telefon alan kodu: (+90)374" },
                    new Trivia() {Question=AppResources.SoruMaxTemp, Answer="Bolu'da şimdiye kadarki en yüksek sıcaklık, 6 Ağustos 2006'da 39,8 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruMinTemp, Answer="Bolu'da şimdiye kadarki en düşük sıcaklık, 15 Ocak 1950'de -28,9 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruUniSayisi, Answer="Bolu ilinde 1 adet üniversite bulunmaktadır. Abant İzzet Baysal Üniversitesi(1992)." }
                }
            });
            sehirler.Add(new City
            {
                Plate = "15",
                Name = "Burdur",
                PictureAddress = "burdur640.png",
                TriviaList = new List<Trivia>
                {
                    new Trivia() {Question=AppResources.SoruNufus, Answer="Burdur'un nüfusu: 256.898 kişi" },
                    new Trivia() {Question=AppResources.SoruNufusPerKmSq, Answer="Burdur'da km\xB2 başına düşen insan sayısı: 36 kişi " },
                    new Trivia() {Question=AppResources.SoruBelediyeBaskani, Answer="Burdur'un Belediye Başkanı: CHP'den Ali Orkun Ercengiz" },
                    new Trivia() {Question=AppResources.SoruIlceSayisi, Answer="Burdur iline bağlı Merkez dahil 11 adet ilçe bulunmaktadır." },
                    new Trivia() {Question=AppResources.SoruIlceBelediyeler, Answer="AKP'de 6 ilçe: Altınyayla, Gölhisar, Çavdır, Karamanlı, Kemer, Bucak. \nCHP'de 3 ilçe: Merkez, Yeşilova, Çeltikçi. \nMHP'de 2 ilçe: Tefenni, Ağlasun" },
                    new Trivia() {Question=AppResources.SoruTelefonKod, Answer="Burdur'un telefon alan kodu: (+90)248" },
                    new Trivia() {Question=AppResources.SoruMaxTemp, Answer="Burdur'da şimdiye kadarki en yüksek sıcaklık, 17 Ağustos 2006'da 41,0 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruMinTemp, Answer="Burdur'da şimdiye kadarki en düşük sıcaklık, 5 Şubat 1950'de -14,6 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruUniSayisi, Answer="Burdur ilinde 1 adet üniversite bulunmaktadır. Mehmet Akif Ersoy Üniversitesi(2006)." }
                }
            });
            sehirler.Add(new City
            {
                Plate = "16",
                Name = "Bursa",
                PictureAddress = "bursa640.png",
                TriviaList = new List<Trivia>
                {
                    new Trivia() {Question=AppResources.SoruNufus, Answer="Bursa'nın nüfusu: 2.787.539 kişi" },
                    new Trivia() {Question=AppResources.SoruNufusPerKmSq, Answer="Bursa'da km\xB2 başına düşen insan sayısı: 256 kişi " },
                    new Trivia() {Question=AppResources.SoruBelediyeBaskani, Answer="Bursa'nın Belediye Başkanı: AKP'den Recep Altepe" },
                    new Trivia() {Question=AppResources.SoruIlceSayisi, Answer="Bursa iline bağlı 17 adet ilçe bulunmaktadır." },
                    new Trivia() {Question=AppResources.SoruIlceBelediyeler, Answer="AKP'de 15 ilçe: Karacabey, Mustafakemalpaşa, Orhaneli, Büyükorhan, Harmancık, Keles, Osmangazi, Yıldırım, Gürsu, Kestel, İnegöl, Yenişehir, Gemlik, Orhangazi, İznik. \nCHP'de 2 ilçe: Mudanya, Nilüfer." },
                    new Trivia() {Question=AppResources.SoruTelefonKod, Answer="Bursa'nın telefon alan kodu: (+90)224" },
                    new Trivia() {Question=AppResources.SoruMaxTemp, Answer="Bursa'da şimdiye kadarki en yüksek sıcaklık, 13 Temmuz 2000'de 43,8 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruMinTemp, Answer="Bursa'da şimdiye kadarki en düşük sıcaklık, 21 Ocak 1967'de -19,2 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruUniSayisi, Answer="Bursa ilinde 3 adet üniversite bulunmaktadır. Bursa Orhangazi Üniversitesi(2011), Bursa Teknik Üniversitesi(2010), Uludağ Üniversitesi(1975)" }
                }
            });
            sehirler.Add(new City
            {
                Plate = "17",
                Name = "Çanakkale",
                PictureAddress = "canakkale640.png",
                TriviaList = new List<Trivia>
                {
                    new Trivia() {Question=AppResources.SoruNufus, Answer="Çanakkale'nin nüfusu: 511.790 kişi" },
                    new Trivia() {Question=AppResources.SoruNufusPerKmSq, Answer="Çanakkale'de km\xB2 başına düşen insan sayısı: 51 kişi " },
                    new Trivia() {Question=AppResources.SoruBelediyeBaskani, Answer="Çanakkale'nin Belediye Başkanı: CHP'den Ülgür GÖKHAN" },
                    new Trivia() {Question=AppResources.SoruIlceSayisi, Answer="Çanakkale iline bağlı Merkez dahil 12 adet ilçe bulunmaktadır." },
                    new Trivia() {Question=AppResources.SoruIlceBelediyeler, Answer="AKP'de 6 ilçe: Lapseki, Çan, Yenice, Bayramiç, Ezine, Ayvacık. \nCHP'de 4 ilçe: Merkez, Bozcaada, Gelibolu, Biga. \nMHP'de 2 ilçe: Gökçeada, Ecebat." },
                    new Trivia() {Question=AppResources.SoruTelefonKod, Answer="Çanakkale'nin telefon alan kodu: (+90)286" },
                    new Trivia() {Question=AppResources.SoruMaxTemp, Answer="Çanakkale'de şimdiye kadarki en yüksek sıcaklık, 24 Temmuz 2007'de 39,0 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruMinTemp, Answer="Çanakkale'de şimdiye kadarki en düşük sıcaklık, 14 Şubat 2004'te -11,2 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruUniSayisi, Answer="Çanakkale ilinde 1 adet üniversite bulunmaktadır. Çanakkale Onsekiz Mart Üniversitesi(1992)." }
                }
            });
            sehirler.Add(new City
            {
                Plate = "18",
                Name = "Çankırı",
                PictureAddress = "cankiri640.png",
                TriviaList = new List<Trivia>
                {
                    new Trivia() {Question=AppResources.SoruNufus, Answer="Çankırı'nın nüfusu: 183.550 kişi" },
                    new Trivia() {Question=AppResources.SoruNufusPerKmSq, Answer="Çankırı'da km\xB2 başına düşen insan sayısı: 25 kişi"  },
                    new Trivia() {Question=AppResources.SoruBelediyeBaskani, Answer="Çankırı'nın Belediye Başkanı: AKP'den İrfan Dinç" },
                    new Trivia() {Question=AppResources.SoruIlceSayisi, Answer="Çankırı iline bağlı Merkez dahil 12 adet ilçe bulunmaktadır." },
                    new Trivia() {Question=AppResources.SoruIlceBelediyeler, Answer="AKP'de 8 ilçe: Merkez, Kurşunlu, Atkaracalar, Orta, Kızılırmak, Çerkeş, Korgun, Yapraklı. \nMHP'de 4 ilçe: Eldivan, Ilgaz, Bayramören, Şabanözü." },
                    new Trivia() {Question=AppResources.SoruTelefonKod, Answer="Çankırı'nın telefon alan kodu: (+90)376" },
                    new Trivia() {Question=AppResources.SoruMaxTemp, Answer="Çankırı'da şimdiye kadarki en yüksek sıcaklık, 30 Temmuz 2000'de 42,4 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruMinTemp, Answer="Çankırı'da şimdiye kadarki en düşük sıcaklık, 25 Ocak 1950'de -25,0 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruUniSayisi, Answer=" Çankırı ilinde 1 adet üniversite bulunmaktadır. Çankırı Karatekin Üniversitesi(2007)." }
                }
            });
            sehirler.Add(new City
            {
                Plate = "19",
                Name = "Çorum",
                PictureAddress = "corum640.png",
                TriviaList = new List<Trivia>
                {
                    new Trivia() {Question=AppResources.SoruNufus, Answer="Çorum'un nüfusu: 527.220 kişi" },
                    new Trivia() {Question=AppResources.SoruNufusPerKmSq, Answer="Çorum'da km\xB2 başına düşen insan sayısı: 41 kişi"  },
                    new Trivia() {Question=AppResources.SoruBelediyeBaskani, Answer="Çorum'un Belediye Başkanı: AKP'den Muzaffer Külcü" },
                    new Trivia() {Question=AppResources.SoruIlceSayisi, Answer="Çorum iline bağlı Merkez dahil 14 adet ilçe bulunmaktadır." },
                    new Trivia() {Question=AppResources.SoruIlceBelediyeler, Answer="AKP'de 8 ilçe: Merkez, Kargı, Osmancık, İskilip, Bayat, Ortaköy, Alaca, Boğazkale. \nMHP'de 3 ilçe: Sungurlu, Uğurludağ, Laçin. \nCHP'de 2 ilçe: Mecitözü, Oğuzlar. \nDP'de 1 ilçe: Dodurga." },
                    new Trivia() {Question=AppResources.SoruTelefonKod, Answer="Çorum'un telefon alan kodu: (+90)364" },
                    new Trivia() {Question=AppResources.SoruMaxTemp, Answer="Çorum'da şimdiye kadarki en yüksek sıcaklık, 30 Temmuz 2000'de 42,6 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruMinTemp, Answer="Çorum'da şimdiye kadarki en düşük sıcaklık, 23 Şubat 1985'te -27,2 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruUniSayisi, Answer="Çorum ilinde 1 adet üniversite bulunmaktadır. Hitit Üniversitesi(2006)." }
                }
            });
            sehirler.Add(new City
            {
                Plate = "20",
                Name = "Denizli",
                PictureAddress = "denizli640.png",
                TriviaList = new List<Trivia>
                {
                    new Trivia() {Question=AppResources.SoruNufus, Answer="Denizli'nin nüfusu: 978.700 kişi" },
                    new Trivia() {Question=AppResources.SoruNufusPerKmSq, Answer="Denizli'de km\xB2 başına düşen insan sayısı: 83 kişi"  },
                    new Trivia() {Question=AppResources.SoruBelediyeBaskani, Answer="Denizli'nın Belediye Başkanı: AKP'den Osman Zolan" },
                    new Trivia() {Question=AppResources.SoruIlceSayisi, Answer="Denizli iline bağlı 19 adet ilçe bulunmaktadır." },
                    new Trivia() {Question=AppResources.SoruIlceBelediyeler, Answer="AKP'de 15 ilçe: Kale, Çameli, Acıpayam, Beyağaç, Tavas, Serinhisar, Çardak, Honaz, Pamukkale, Merkezefendi, Babadağ, Sarayköy, Güney, Baklan, Çivril. \nCHP'de 3 ilçe: Buldan, Bozkurt, Bekilli. \nMHP'de 1 ilçe: Çal" },
                    new Trivia() {Question=AppResources.SoruTelefonKod, Answer="Denizli'nin telefon alan kodu: (+90)258" },
                    new Trivia() {Question=AppResources.SoruMaxTemp, Answer="Denizli'de şimdiye kadarki en yüksek sıcaklık, 15 Ağustos 2007'de 44,4 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruMinTemp, Answer="Denizli'de şimdiye kadarki en düşük sıcaklık, 9 Şubat 1965'te -11,4 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruUniSayisi, Answer="Denizli ilinde 1 adet üniversite bulunmaktadır. Pamukkale Üniversitesi(1992)." }
                }
            });
            sehirler.Add(new City
            {
                Plate = "21",
                Name = "Diyarbakır",
                PictureAddress = "diyarbakir640.png",
                TriviaList = new List<Trivia>
                {
                    new Trivia() {Question=AppResources.SoruNufus, Answer="Diyarbakır'ın nüfusu: 1.635.048 kişi" },
                    new Trivia() {Question=AppResources.SoruNufusPerKmSq, Answer="Diyarbakır'da km\xB2 başına düşen insan sayısı: 107 kişi"  },
                    new Trivia() {Question=AppResources.SoruBelediyeBaskani, Answer="Diyarbakır'ın Belediye Eş Başkanları: BDP'den Gülten Kışanak ve Fırat Anlı" },
                    new Trivia() {Question=AppResources.SoruIlceSayisi, Answer="Diyarbakır iline bağlı 17 adet ilçe bulunmaktadır." },
                    new Trivia() {Question=AppResources.SoruIlceBelediyeler, Answer="BDP'de 15 ilçe: Ergani, Dicle, Eğil, Yenişehir, Kayapınar, Bağlar, Çınar, Sur, Kocaköy, Hani, Lice, Hazro, Silvan, Bismil, Kulp. \nAKP'de 2 ilçe: Çüngüş, Çermik." },
                    new Trivia() {Question=AppResources.SoruTelefonKod, Answer="Diyarbakır'ın telefon alan kodu: (+90)412" },
                    new Trivia() {Question=AppResources.SoruMaxTemp, Answer="Diyarbakır'da şimdiye kadarki en yüksek sıcaklık, 3 Ağustos 1957'de 45,9 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruMinTemp, Answer="Diyarbakır'da şimdiye kadarki en düşük sıcaklık, 30 Aralık 2006'da -23,4 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruUniSayisi, Answer="Diyarbakır ilinde 2 adet üniversite bulunmaktadır. Dicle Üniversitesi(1974), Selahaddin Eyyubi Üniversitesi(2013)." }
                }
            });
            sehirler.Add(new City
            {
                Plate = "22",
                Name = "Edirne",
                PictureAddress = "edirne640.png",
                TriviaList = new List<Trivia>
                {
                    new Trivia() {Question=AppResources.SoruNufus, Answer="Edirne'nin nüfusu: 400.280 kişi" },
                    new Trivia() {Question=AppResources.SoruNufusPerKmSq, Answer="Edirne'de km\xB2 başına düşen insan sayısı: 65 kişi"  },
                    new Trivia() {Question=AppResources.SoruBelediyeBaskani, Answer="Edirne'nin Belediye Başkanı: CHP'den Recep Gürkan" },
                    new Trivia() {Question=AppResources.SoruIlceSayisi, Answer="Edirne iline bağlı Merkez dahil 9 adet ilçe bulunmaktadır." },
                    new Trivia() {Question=AppResources.SoruIlceBelediyeler, Answer="CHP'de 5 ilçe: Merkez, Keşan, Uzunköprü, Havsa, Süloğlu. \nAKP'de 3 ilçe: Enez, İpsala, Meriç. \nMHP'de 1 ilçe: Lalapaşa" },
                    new Trivia() {Question=AppResources.SoruTelefonKod, Answer="Edirne'nin telefon alan kodu: (+90)284" },
                    new Trivia() {Question=AppResources.SoruMaxTemp, Answer="Edirne'de şimdiye kadarki en yüksek sıcaklık, 25 Temmuz 2007'de 44,1 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruMinTemp, Answer="Edirne'de şimdiye kadarki en düşük sıcaklık, 14 Ocak 1954'te -19,5 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruUniSayisi, Answer="Edirne ilinde 1 adet üniversite bulunmaktadır. Trakya Üniversitesi(1982)." }
                }
            });
            sehirler.Add(new City
            {
                Plate = "23",
                Name = "Elazığ",
                PictureAddress = "elazig640.png",
                TriviaList = new List<Trivia>
                {
                    new Trivia() {Question=AppResources.SoruNufus, Answer="Elazığ'ın nüfusu: 568.753 kişi" },
                    new Trivia() {Question=AppResources.SoruNufusPerKmSq, Answer="Elazığ'da km\xB2 başına düşen insan sayısı: 61 kişi"  },
                    new Trivia() {Question=AppResources.SoruBelediyeBaskani, Answer="Elazığ'ın Belediye Başkanı: AKP'den Mücahit Yanılmaz" },
                    new Trivia() {Question=AppResources.SoruIlceSayisi, Answer="Elazığ iline bağlı Merkez dahil 11 adet ilçe bulunmaktadır." },
                    new Trivia() {Question=AppResources.SoruIlceBelediyeler, Answer="AKP'de 6 ilçe: Merkez, Sivrice, Baskil, Keban, Kovancılar, Palu. \nDP'de 2 ilçe: Maden, Arıcak. \nBDP'de 1 ilçe: Karakoçan. \nMHP'de 1 ilçe: Ağın. \nBağımsız 1 ilçe: Alacakaya." },
                    new Trivia() {Question=AppResources.SoruTelefonKod, Answer="Elazığ'ın telefon alan kodu: (+90)424" },
                    new Trivia() {Question=AppResources.SoruMaxTemp, Answer="Elazığ'da şimdiye kadarki en yüksek sıcaklık, 30 Temmuz 2000'de 42,2 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruMinTemp, Answer="Elazığ'da şimdiye kadarki en düşük sıcaklık, 30 Aralık 1951 ve 20 Ocak 1972'de -22,6 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruUniSayisi, Answer="Elazığ ilinde 1 adet üniversite bulunmaktadır. Fırat Üniversitesi(1975)." }
                }
            });
            sehirler.Add(new City
            {
                Plate = "24",
                Name = "Erzincan",
                PictureAddress = "erzincan640.png",
                TriviaList = new List<Trivia>
                {
                    new Trivia() {Question=AppResources.SoruNufus, Answer="Erzincan'ın nüfusu: 223.633 kişi" },
                    new Trivia() {Question=AppResources.SoruNufusPerKmSq, Answer="Erzincan'da km\xB2 başına düşen insan sayısı: 19 kişi"  },
                    new Trivia() {Question=AppResources.SoruBelediyeBaskani, Answer="Erzincan'ın Belediye Başkanı: AKP'den Cemalettin Başsoy" },
                    new Trivia() {Question=AppResources.SoruIlceSayisi, Answer="Erzincan iline bağlı Merkez dahil 9 adet ilçe bulunmaktadır." },
                    new Trivia() {Question=AppResources.SoruIlceBelediyeler, Answer="AKP'de 5 ilçe: Merkez, Kemaliye, Üzümlü, Çayırlı, Otlukbeli. \nMHP'de 4 ilçe: Tercan, Kemah, Refahiye, İliç." },
                    new Trivia() {Question=AppResources.SoruTelefonKod, Answer="Erzincan'ın telefon alan kodu: (+90)446" },
                    new Trivia() {Question=AppResources.SoruMaxTemp, Answer="Erzincan'da şimdiye kadarki en yüksek sıcaklık, 30 Temmuz 2000'de 40,6 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruMinTemp, Answer="Erzincan'da şimdiye kadarki en düşük sıcaklık, 14 Ocak 1950'de -32,5 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruUniSayisi, Answer="Erzincan ilinde 1 adet üniversite bulunmaktadır. Erzincan Üniversitesi(2006)." }
                }
            });
            sehirler.Add(new City
            {
                Plate = "25",
                Name = "Erzurum",
                PictureAddress = "erzurum640.png",
                TriviaList = new List<Trivia>
                {
                    new Trivia() {Question=AppResources.SoruNufus, Answer="Erzurum'un nüfusu: 763.320 kişi" },
                    new Trivia() {Question=AppResources.SoruNufusPerKmSq, Answer="Erzurum'da km\xB2 başına düşen insan sayısı: 30 kişi"  },
                    new Trivia() {Question=AppResources.SoruBelediyeBaskani, Answer="Erzurum'un Belediye Başkanı: AKP'den Mehmet Sekmen" },
                    new Trivia() {Question=AppResources.SoruIlceSayisi, Answer="Erzurum iline bağlı 20 adet ilçe bulunmaktadır." },
                    new Trivia() {Question=AppResources.SoruIlceBelediyeler, Answer="AKP'de 14 ilçe: Olur, Şenkaya, Oltu, Uzundere, Narman, Köprüköy, Pasinler, Palandöken, Tortum, Yakutiye, Aziziye, Aşkale, Pazaryolu, İspir. \nBDP'de 4 ilçe: Karayazı, Karaçoban, Hınıs, Tekman. \nCHP'de 1 ilçe: Çat. \nSP'de 1 ilçe: Horasan." },
                    new Trivia() {Question=AppResources.SoruTelefonKod, Answer="Erzurum'un telefon alan kodu: (+90)442" },
                    new Trivia() {Question=AppResources.SoruMaxTemp, Answer="Erzurum'da şimdiye kadarki en yüksek sıcaklık, 11 Ağustos 2006'da 36,5 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruMinTemp, Answer="Erzurum'da şimdiye kadarki en düşük sıcaklık, 28 Aralık 2002'de -37,2 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruUniSayisi, Answer="Erzurum ilinde 2 adet üniversite bulunmaktadır. Atatürk Üniversitesi(1954), Erzurum Teknik Üniversitesi(2010)." }
                }
            });
            sehirler.Add(new City
            {
                Plate = "26",
                Name = "Eskişehir",
                PictureAddress = "eskisehir640.png",
                TriviaList = new List<Trivia>
                {
                    new Trivia() {Question=AppResources.SoruNufus, Answer="Eskişehir'in nüfusu: 812.320 kişi" },
                    new Trivia() {Question=AppResources.SoruNufusPerKmSq, Answer="Eskişehir'de km\xB2 başına düşen insan sayısı: 58 kişi"  },
                    new Trivia() {Question=AppResources.SoruBelediyeBaskani, Answer="Eskişehir'in Belediye Başkanı: CHP'den Yılmaz Büyükerşen" },
                    new Trivia() {Question=AppResources.SoruIlceSayisi, Answer="Eskişehir iline bağlı 14 adet ilçe bulunmaktadır." },
                    new Trivia() {Question=AppResources.SoruIlceBelediyeler, Answer="AKP'de 10 ilçe: Sarıcakaya, Günyüzü, Mihalgazi, Seyitgazi, Alpu, Mihalıççık, Sivrihisar, Beylikova, İnönü, Çifteler. \nCHP'de 4 ilçe: Han, Odunpazarı, Tepebaşı, Mahmudiye." },
                    new Trivia() {Question=AppResources.SoruTelefonKod, Answer="Eskişehir'in telefon alan kodu: (+90)222" },
                    new Trivia() {Question=AppResources.SoruMaxTemp, Answer="Eskişehir'de şimdiye kadarki en yüksek sıcaklık, 29 Temmuz 2000'de 40,6 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruMinTemp, Answer="Eskişehir'de şimdiye kadarki en düşük sıcaklık, 30 Ocak 2006'da -27,8 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruUniSayisi, Answer="Eskişehir ilinde 2 adet üniversite bulunmaktadır. Anadolu Üniversitesi(1982), Eskişehir Osmangazi Üniversitesi(1993)." }
                }
            });
            sehirler.Add(new City
            {
                Plate = "27",
                Name = "Gaziantep",
                PictureAddress = "gaziantep640.png",
                TriviaList = new List<Trivia>
                {
                    new Trivia() {Question=AppResources.SoruNufus, Answer="Gaziantep'in nüfusu: 1.889.466 kişi" },
                    new Trivia() {Question=AppResources.SoruNufusPerKmSq, Answer="Gaziantep'te km\xB2 başına düşen insan sayısı: 274 kişi"  },
                    new Trivia() {Question=AppResources.SoruBelediyeBaskani, Answer="Gaziantep'in Belediye Başkanı: AKP'den Fatma Şahin" },
                    new Trivia() {Question=AppResources.SoruIlceSayisi, Answer="Gaziantep iline bağlı 9 adet ilçe bulunmaktadır." },
                    new Trivia() {Question=AppResources.SoruIlceBelediyeler, Answer="AKP'de 8 ilçe: İslahiye, Nurdağı, Şehitkamil, Şahinbey, Karkamış, Nizip, Yavuzeli, Araban. \nMHP'de 1 ilçe: Oğuzeli." },
                    new Trivia() {Question=AppResources.SoruTelefonKod, Answer="Gaziantep'in telefon alan kodu: (+90)342" },
                    new Trivia() {Question=AppResources.SoruMaxTemp, Answer="Gaziantep'te şimdiye kadarki en yüksek sıcaklık, 30 Temmuz 2000'de 44,0 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruMinTemp, Answer="Gaziantep'te şimdiye kadarki en düşük sıcaklık, 15 Ocak 1950'de -17,5 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruUniSayisi, Answer="Gaziantep ilinde 4 adet üniversite bulunmaktadır. Gaziantep Üniversitesi(1987), Hasan Kalyoncu Üniversitesi(2008), Zirve Üniversitesi(2009), Sanko Üniversitesi(2013)." }
                }
            });
            sehirler.Add(new City
            {
                Plate = "28",
                Name = "Giresun",
                PictureAddress = "giresun640.png",
                TriviaList = new List<Trivia>
                {
                    new Trivia() {Question=AppResources.SoruNufus, Answer="Giresun'un nüfusu: 429.984 kişi" },
                    new Trivia() {Question=AppResources.SoruNufusPerKmSq, Answer="Giresun'da km\xB2 başına düşen insan sayısı: 63 kişi"  },
                    new Trivia() {Question=AppResources.SoruBelediyeBaskani, Answer="Giresun'un Belediye Başkanı: CHP'den Kerim Aksu" },
                    new Trivia() {Question=AppResources.SoruIlceSayisi, Answer="Giresun iline bağlı Merkez dahil 16 adet ilçe bulunmaktadır." },
                    new Trivia() {Question=AppResources.SoruIlceBelediyeler, Answer="AKP'de 13 ilçe: Eynesil, Görele, Çanakçı, Tirebolu, Güce, Espiye, Yağlıdere, Keşap, Dereli, Bulancak, Şebinkarahisar, Alucra, Çamoluk. \nCHP'de 2 ilçe: Merkez, Piraziz. \nMHP'de 1 ilçe: Doğankent." },
                    new Trivia() {Question=AppResources.SoruTelefonKod, Answer="Giresun'un telefon alan kodu: (+90)454" },
                    new Trivia() {Question=AppResources.SoruMaxTemp, Answer="Giresun'da şimdiye kadarki en yüksek sıcaklık, 4 Haziran 1969'da 36,2 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruMinTemp, Answer="Giresun'da şimdiye kadarki en düşük sıcaklık, 6 Şubat 1960'da -9,8 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruUniSayisi, Answer="Giresun ilinde 1 adet üniversite bulunmaktadır. Giresun Üniversitesi(2006)." }
                }
            });
            sehirler.Add(new City
            {
                Plate = "29",
                Name = "Gümüşhane",
                PictureAddress = "gumushane640.png",
                TriviaList = new List<Trivia>
                {
                    new Trivia() {Question=AppResources.SoruNufus, Answer="Gümüşhane'nin nüfusu: 146.353 kişi" },
                    new Trivia() {Question=AppResources.SoruNufusPerKmSq, Answer="Gümüşhane'de km\xB2 başına düşen insan sayısı: 23 kişi"  },
                    new Trivia() {Question=AppResources.SoruBelediyeBaskani, Answer="Gümüşhane'nin Belediye Başkanı: AKP'den Ercan Çimen" },
                    new Trivia() {Question=AppResources.SoruIlceSayisi, Answer="Gümüşhane iline bağlı Merkez dahil 6 adet ilçe bulunmaktadır." },
                    new Trivia() {Question=AppResources.SoruIlceBelediyeler, Answer="AKP'de 6 ilçe: Merkez, Kürtün, Torul, Köse, Şiran, Kelkit." },
                    new Trivia() {Question=AppResources.SoruTelefonKod, Answer="Gümüşhane'nin telefon alan kodu: (+90)456" },
                    new Trivia() {Question=AppResources.SoruMaxTemp, Answer="Gümüşhane'de şimdiye kadarki en yüksek sıcaklık, 30 Temmuz 2000'de 41,0 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruMinTemp, Answer="Gümüşhane'de şimdiye kadarki en düşük sıcaklık, 22 Şubat 1985'te -25,7 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruUniSayisi, Answer="Gümüşhane ilinde 1 adet üniversite bulunmaktadır. Gümüşhane Üniversitesi(2008)." }
                }
            });
            sehirler.Add(new City
            {
                Plate = "30",
                Name = "Hakkari",
                PictureAddress = "hakkari640.png",
                TriviaList = new List<Trivia>
                {
                    new Trivia() {Question=AppResources.SoruNufus, Answer="Hakkari'nin nüfusu: 276.287 kişi" },
                    new Trivia() {Question=AppResources.SoruNufusPerKmSq, Answer="Hakkari'de km\xB2 başına düşen insan sayısı: 38 kişi"  },
                    new Trivia() {Question=AppResources.SoruBelediyeBaskani, Answer="Hakkari'nin Belediye Başkanı: BDP'den Dilek Hatipoğlu ve Nurullah Çiftçi" },
                    new Trivia() {Question=AppResources.SoruIlceSayisi, Answer="Hakkari iline bağlı Merkez dahil 4 adet ilçe bulunmaktadır." },
                    new Trivia() {Question=AppResources.SoruIlceBelediyeler, Answer="BDP'de 4 ilçe: Merkez, Çukurca, Yüksekova, Şemdinli." },
                    new Trivia() {Question=AppResources.SoruTelefonKod, Answer="Hakkari'nin telefon alan kodu: (+90)438" },
                    new Trivia() {Question=AppResources.SoruMaxTemp, Answer="Hakkari'de şimdiye kadarki en yüksek sıcaklık, 27 Temmuz 1966'da 38,8 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruMinTemp, Answer="Hakkari'de şimdiye kadarki en düşük sıcaklık, 3 Ocak 2009'da -23,4 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruUniSayisi, Answer="Hakkari ilinde 1 adet üniversite bulunmaktadır. Hakkari Üniversitesi(2008)." }
                }
            });
            sehirler.Add(new City
            {
                Plate = "31",
                Name = "Hatay",
                PictureAddress = "hatay640.png",
                TriviaList = new List<Trivia>
                {
                    new Trivia() {Question=AppResources.SoruNufus, Answer="Hatay'ın nüfusu: 1.519.836 kişi" },
                    new Trivia() {Question=AppResources.SoruNufusPerKmSq, Answer="Hatay'da km\xB2 başına düşen insan sayısı: 259 kişi"  },
                    new Trivia() {Question=AppResources.SoruBelediyeBaskani, Answer="Hatay'ın Belediye Başkanı: CHP'den Lütfü Savaş" },
                    new Trivia() {Question=AppResources.SoruIlceSayisi, Answer="Hatay iline bağlı 15 adet ilçe bulunmaktadır." },
                    new Trivia() {Question=AppResources.SoruIlceBelediyeler, Answer="AKP'de 11 ilçe: Erzin, Hassa, Payas, İskenderun, Kırıkhan, Belen, Kumlu, Reyhanlı, Antakya, Altınözü, Yayladağı. \nCHP'de 3 ilçe: Defne, Samandağ, Arsuz. \nMHP'de 1 ilçe: Dörtyol." },
                    new Trivia() {Question=AppResources.SoruTelefonKod, Answer="Hatay'ın telefon alan kodu: (+90)326" },
                    new Trivia() {Question=AppResources.SoruMaxTemp, Answer="Hatay'da şimdiye kadarki en yüksek sıcaklık, 26 Ağustos 1962'de 43,9 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruMinTemp, Answer="Hatay'da şimdiye kadarki en düşük sıcaklık, 15 Ocak 1950'de -14,6 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruUniSayisi, Answer="Hatay ilinde 2 adet üniversite bulunmaktadır. Mustafa Kemal Üniversitesi(1992), İskenderun Teknik Üniversitesi(2015)." }
                }
            });
            sehirler.Add(new City
            {
                Plate = "32",
                Name = "Isparta",
                PictureAddress = "isparta640.png",
                TriviaList = new List<Trivia>
                {
                    new Trivia() {Question=AppResources.SoruNufus, Answer="Isparta'nın nüfusu: 418.780 kişi" },
                    new Trivia() {Question=AppResources.SoruNufusPerKmSq, Answer="Isparta'da km\xB2 başına düşen insan sayısı: 47 kişi"  },
                    new Trivia() {Question=AppResources.SoruBelediyeBaskani, Answer="Isparta'ın Belediye Başkanı: MHP'den Yusuf Ziya Günaydın" },
                    new Trivia() {Question=AppResources.SoruIlceSayisi, Answer="Isparta iline bağlı Merkez dahil 13 adet ilçe bulunmaktadır." },
                    new Trivia() {Question=AppResources.SoruIlceBelediyeler, Answer="AKP'de 6 ilçe: Sütçüler, Gelendost, Atabey, Gönen, Uluborlu, Keçiborlu. \nMHP'de 3 ilçe: Merkez, Senirkent, Yalvaç. \nCHP'de 2 ilçe: Yenişarbademli, Aksu. \nDP'de 1 ilçe: Eğirdir. \nBBP'de 1 ilçe: Şarkikaraağaç." },
                    new Trivia() {Question=AppResources.SoruTelefonKod, Answer="Isparta'nın telefon alan kodu: (+90)246" },
                    new Trivia() {Question=AppResources.SoruMaxTemp, Answer="Isparta'da şimdiye kadarki en yüksek sıcaklık, 28 Temmuz 2011'de 42,3 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruMinTemp, Answer="Isparta'da şimdiye kadarki en düşük sıcaklık, 3 Şubat 1974'te -21,0 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruUniSayisi, Answer="Isparta ilinde 1 adet üniversite bulunmaktadır. Süleyman Demirel Üniversitesi(1992)." }
                }
            });
            sehirler.Add(new City
            {
                Plate = "33",
                Name = "Mersin",
                PictureAddress = "mersin640.png",
                TriviaList = new List<Trivia>
                {
                    new Trivia() {Question=AppResources.SoruNufus, Answer="Mersin'in nüfusu: 1.727.255 kişi" },
                    new Trivia() {Question=AppResources.SoruNufusPerKmSq, Answer="Mersin'de km\xB2 başına düşen insan sayısı: 111 kişi"  },
                    new Trivia() {Question=AppResources.SoruBelediyeBaskani, Answer="Mersin'in Belediye Başkanı: MHP'den Burhanettin Kocamaz" },
                    new Trivia() {Question=AppResources.SoruIlceSayisi, Answer="Mersin iline bağlı 13 adet ilçe bulunmaktadır." },
                    new Trivia() {Question=AppResources.SoruIlceBelediyeler, Answer="MHP'de 8 ilçe: Anamur, Bozyazı, Gülnar, Mut, Erdemli, Toroslar, Çamlıyayla, Tarsus. \nCHP'de 3 ilçe: Yenişehir, Mezitli, Silifke. \nBDP'de 1 ilçe: Akdeniz. \nAKP'de 1 ilçe: Aydıncık." },
                    new Trivia() {Question=AppResources.SoruTelefonKod, Answer="Mersin'in telefon alan kodu: (+90)324" },
                    new Trivia() {Question=AppResources.SoruMaxTemp, Answer="Mersin'de şimdiye kadarki en yüksek sıcaklık, 26 Ağustos 1962'de 39,8 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruMinTemp, Answer="Mersin'de şimdiye kadarki en düşük sıcaklık, 6 Şubat 1950'de -6,6 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruUniSayisi, Answer="Mersin ilinde 3 adet üniversite bulunmaktadır. Mersin Üniversitesi(1992), Çağ Üniversitesi(1997), Toros Üniversitesi(2009)." }
                }
            });
            sehirler.Add(new City
            {
                Plate = "34",
                Name = "İstanbul",
                PictureAddress = "istanbul640.png",
                TriviaList = new List<Trivia>
                {
                    new Trivia() {Question=AppResources.SoruNufus, Answer="İstanbul'un nüfusu: 14.377.018 kişi" },
                    new Trivia() {Question=AppResources.SoruNufusPerKmSq, Answer="İstanbul'da km\xB2 başına düşen insan sayısı: 2.706 kişi"  },
                    new Trivia() {Question=AppResources.SoruBelediyeBaskani, Answer="İstanbul'un Belediye Başkanı: AKP'den Kadir Topbaş" },
                    new Trivia() {Question=AppResources.SoruIlceSayisi, Answer="İstanbul iline bağlı 39 adet ilçe bulunmaktadır." },
                    new Trivia() {Question=AppResources.SoruIlceBelediyeler, Answer="AKP'de 25 ilçe: Şile, Beykoz, Üsküdar, Ümraniye, Çekmeköy, Sancaktepe, Sultanbeyli, Pendik, Tuzla, Beyoğlu, Kağıthane, Fatih, Zeytinburnu, Eyüp, Güngören, Bayrampaşa, Gaziosmanpaşa, Sultangazi, Esenler, Bağcılar, Bahçelievler, Küçükçekmece, Başakşehir, Esenyurt, Arnavutköy. CHP'de 14 ilçe: Kartal, Adalar, Maltepe, Ataşehir, Kadıköy, Sarıyer, Beşiktaş, Şişli, Bakırköy, Avcılar, Beylikdüzü, Büyükçekmece, Çatalca, Silivri." },
                    new Trivia() {Question=AppResources.SoruTelefonKod, Answer="İstanbul'un telefon alan kodları: (+90)212 ve (+90)216" },
                    new Trivia() {Question=AppResources.SoruMaxTemp, Answer="İstanbul'da şimdiye kadarki en yüksek sıcaklık, 13 Temmuz 2000'de 41,5 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruMinTemp, Answer="İstanbul'da şimdiye kadarki en düşük sıcaklık, 17 Ocak 1963'te -11,0 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruUniSayisi, Answer="İstanbul'da 11 adet devlet ve 41 adet vakıf olmak üzere toplam 52 adet üniversite bulunmaktadır. " }
                }
            });
            sehirler.Add(new City
            {
                Plate = "35",
                Name = "İzmir",
                PictureAddress = "izmir640.png",
                TriviaList = new List<Trivia>
                {
                    new Trivia() {Question=AppResources.SoruNufus, Answer="İzmir'in nüfusu: 4.113.072 kişi" },
                    new Trivia() {Question=AppResources.SoruNufusPerKmSq, Answer="İzmir'de km\xB2 başına düşen insan sayısı: 343 kişi"  },
                    new Trivia() {Question=AppResources.SoruBelediyeBaskani, Answer="İzmir'in Belediye Başkanı: CHP'den Aziz Kocaoğlu" },
                    new Trivia() {Question=AppResources.SoruIlceSayisi, Answer="İzmir iline bağlı 30 adet ilçe bulunmaktadır." },
                    new Trivia() {Question=AppResources.SoruIlceBelediyeler, Answer="CHP'de 22 ilçe: Çeşme, Urla, Karaburun, Güzelbahçe, Seferihisar, Narlıdere, Karabağlar, Balçova, Gaziemir, Buca, Konak, Bornova, Bayraklı, Karşıyaka, Çiğli, Menemen, Foça, Dikili, Bergama, Bayındır, Tire, Beydağ. \nAKP'de 6 ilçe: Ödemiş, Selçuk, Menderes, Torbalı, Kemalpaşa, Kınık. \nMHP'de 2 ilçe: Aliağa, Kiraz." },
                    new Trivia() {Question=AppResources.SoruTelefonKod, Answer="İzmir'in telefon alan kodu: (+90)232" },
                    new Trivia() {Question=AppResources.SoruMaxTemp, Answer="İzmir'de şimdiye kadarki en yüksek sıcaklık, 12 Ağustos 2002'de 43,0 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruMinTemp, Answer="İzmir'de şimdiye kadarki en düşük sıcaklık, 18 Ocak 1964'te -6,4 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruUniSayisi, Answer="İzmir ilinde 9 adet üniversite bulunmaktadır. Ege Üniversitesi(1955), Dokuz Eylül Üniversitesi(1981), İzmir Yüksek Teknoloji Enstitüsü(1992), İzmir Katip Çelebi Üniversitesi(2010), İzmir Ekonomi Üniversitesi(2001), İzmir Üniversitesi(2007), Yaşar Üniversitesi(2001), Gediz Üniversitesi(2008), Şifa Üniversitesi(2011) " }
                }
            });
            sehirler.Add(new City
            {
                Plate = "36",
                Name = "Kars",
                PictureAddress = "kars640.png",
                TriviaList = new List<Trivia>
                {
                    new Trivia() {Question=AppResources.SoruNufus, Answer="Kars'ın nüfusu: 296.466 kişi" },
                    new Trivia() {Question=AppResources.SoruNufusPerKmSq, Answer="Kars'ta km\xB2 başına düşen insan sayısı: 30 kişi"  },
                    new Trivia() {Question=AppResources.SoruBelediyeBaskani, Answer="Kars'ın Belediye Başkanı: MHP'den Murtaza Karaçanta" },
                    new Trivia() {Question=AppResources.SoruIlceSayisi, Answer="Kars iline bağlı Merkez dahil 8 adet ilçe bulunmaktadır." },
                    new Trivia() {Question=AppResources.SoruIlceBelediyeler, Answer="MHP'de 2 ilçe: Merkez, Kağızman. \nAKP'de 3 ilçe: Sarıkamış, Selim, Arpaçay. \nBDP'de 1 ilçe: Digor. \nCHP'de 1 ilçe: Akyaka. \nDSP'de 1 ilçe: Susuz." },
                    new Trivia() {Question=AppResources.SoruTelefonKod, Answer="Kars'ın telefon alan kodu: (+90)474" },
                    new Trivia() {Question=AppResources.SoruMaxTemp, Answer="Kars'ta şimdiye kadarki en yüksek sıcaklık, 30 Ağustos 1998 ve 30 Temmuz 2000'de 35,4 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruMinTemp, Answer="Kars'ta şimdiye kadarki en düşük sıcaklık, 27 Ocak 1950'de -36,7 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruUniSayisi, Answer="Kars ilinde 1 adet üniversite bulunmaktadır. Kafkas Üniversitesi(1992)." }
                }
            });
            sehirler.Add(new City
            {
                Plate = "37",
                Name = "Kastamonu",
                PictureAddress = "kastamonu640.png",
                TriviaList = new List<Trivia>
                {
                    new Trivia() {Question=AppResources.SoruNufus, Answer="Kastamonu'nun nüfusu: 368.907 kişi" },
                    new Trivia() {Question=AppResources.SoruNufusPerKmSq, Answer="Kastamonu'nda km\xB2 başına düşen insan sayısı: 28 kişi"  },
                    new Trivia() {Question=AppResources.SoruBelediyeBaskani, Answer="Kastamonu'nun Belediye Başkanı: AKP'den Tahsin Babaş" },
                    new Trivia() {Question=AppResources.SoruIlceSayisi, Answer="Kastamonu iline bağlı Merkez dahil 20 adet ilçe bulunmaktadır." },
                    new Trivia() {Question=AppResources.SoruIlceBelediyeler, Answer="AKP'de 14 ilçe: Merkez, Tosya, Araç, İhsangazi, Taşköprü, Hanönü, Seydiler, Çatalzeytin, Abana, Azdavay, Şenpazar, Doğanyurt, Cide, Pınarbaşı. \nMHP'de 4 ilçe: Ağlı, Küre, İnebolu, Bozkurt. \nCHP'de 1 ilçe: Daday. \nBağımsız 1 ilçe: Devrekani." },
                    new Trivia() {Question=AppResources.SoruTelefonKod, Answer="Kastamonu'nun telefon alan kodu: (+90)366" },
                    new Trivia() {Question=AppResources.SoruMaxTemp, Answer="Kastamonu'nda şimdiye kadarki en yüksek sıcaklık, 30 Temmuz 2000'de 42,2 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruMinTemp, Answer="Kastamonu'nda şimdiye kadarki en düşük sıcaklık, 15 Ocak 1950'de -23,7 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruUniSayisi, Answer="Kastamonu ilinde 1 adet üniversite bulunmaktadır. Kastamonu Üniversitesi(2006)." }
                }
            });
            sehirler.Add(new City
            {
                Plate = "38",
                Name = "Kayseri",
                PictureAddress = "kayseri640.png",
                TriviaList = new List<Trivia>
                {
                    new Trivia() {Question=AppResources.SoruNufus, Answer="Kayseri'nin nüfusu: 1.322.376 kişi" },
                    new Trivia() {Question=AppResources.SoruNufusPerKmSq, Answer="Kayseri'de km\xB2 başına düşen insan sayısı: 77 kişi"  },
                    new Trivia() {Question=AppResources.SoruBelediyeBaskani, Answer="Kayseri'nin Belediye Başkanı: AKP'den Mustafa Çelik" },
                    new Trivia() {Question=AppResources.SoruIlceSayisi, Answer="Kayseri iline bağlı 16 adet ilçe bulunmaktadır." },
                    new Trivia() {Question=AppResources.SoruIlceBelediyeler, Answer="AKP'de 12 ilçe: Yahyalı, Yeşilhisar, Develi, Tomarza, Talas, Melikgazi, Hacılar, İncesu, Kocasinan, Bünyan, Felahiye, Akkışla. \nMHP'de 3 ilçe: Özvatan, Sarıoğlan, Pınarbaşı. \nCHP'de 1 ilçe: Sarız." },
                    new Trivia() {Question=AppResources.SoruTelefonKod, Answer="Kayseri'nin telefon alan kodu: (+90)352" },
                    new Trivia() {Question=AppResources.SoruMaxTemp, Answer="Kayseri'de şimdiye kadarki en yüksek sıcaklık, 30 Temmuz 2000'de 40,7 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruMinTemp, Answer="Kayseri'de şimdiye kadarki en düşük sıcaklık, 18 Ocak 1972'de -31,4 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruUniSayisi, Answer="Kayseri ilinde 4 adet üniversite bulunmaktadır. Erciyes Üniversitesi(1978), Melikşah Üniversitesi(2008), Nuh Naci Yazgan Üniversitesi(2009), Abdullah Gül Üniversitesi(2010)." }
                }
            });
            sehirler.Add(new City
            {
                Plate = "39",
                Name = "Kırklareli",
                PictureAddress = "kirklareli640.png",
                TriviaList = new List<Trivia>
                {
                    new Trivia() {Question=AppResources.SoruNufus, Answer="Kırklareli'nin nüfusu: 343.723 kişi" },
                    new Trivia() {Question=AppResources.SoruNufusPerKmSq, Answer="Kırklareli'nde km\xB2 başına düşen insan sayısı: 55 kişi"  },
                    new Trivia() {Question=AppResources.SoruBelediyeBaskani, Answer="Kırklareli'nin Belediye Başkanı: CHP'den Mehmet Siyam Kesimoğlu" },
                    new Trivia() {Question=AppResources.SoruIlceSayisi, Answer="Kırklareli iline bağlı Merkez dahil 8 adet ilçe bulunmaktadır." },
                    new Trivia() {Question=AppResources.SoruIlceBelediyeler, Answer="CHP'de 5 ilçe: Merkez, Kofçaz, Pınarhisar, Lüleburgaz, Babaeski. \nMHP'de 2 ilçe: Demirköy, Vize. \nAKP'de 1 ilçe: Pehlivanköy." },
                    new Trivia() {Question=AppResources.SoruTelefonKod, Answer="Kırklareli'nin telefon alan kodu: (+90)288" },
                    new Trivia() {Question=AppResources.SoruMaxTemp, Answer="Kırklareli'nde şimdiye kadarki en yüksek sıcaklık, 27 Temmuz 2000'de 42,5 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruMinTemp, Answer="Kırklareli'nde şimdiye kadarki en düşük sıcaklık, 14 Ocak 1972'de -15,8 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruUniSayisi, Answer="Kırklareli ilinde 1 adet üniversite bulunmaktadır. Kırklareli Üniversitesi(2007)." }
                }
            });
            sehirler.Add(new City
            {
                Plate = "40",
                Name = "Kırşehir",
                PictureAddress = "kirsehir640.png",
                TriviaList = new List<Trivia>
                {
                    new Trivia() {Question=AppResources.SoruNufus, Answer="Kırşehir'in nüfusu: 222.707 kişi" },
                    new Trivia() {Question=AppResources.SoruNufusPerKmSq, Answer="Kırşehir'de km\xB2 başına düşen insan sayısı: 34 kişi"  },
                    new Trivia() {Question=AppResources.SoruBelediyeBaskani, Answer="Kırşehir'in Belediye Başkanı: AKP'den Yaşar Bahçeci" },
                    new Trivia() {Question=AppResources.SoruIlceSayisi, Answer="Kırşehir iline bağlı Merkez dahil 7 adet ilçe bulunmaktadır." },
                    new Trivia() {Question=AppResources.SoruIlceBelediyeler, Answer="AKP'de 4 ilçe: Merkez, Boztepe, Akpınar, Akçakent. \nMHP'de 3 ilçe: Mucur, Kaman, Çiçekdağı." },
                    new Trivia() {Question=AppResources.SoruTelefonKod, Answer="Kırşehir'in telefon alan kodu: (+90)386" },
                    new Trivia() {Question=AppResources.SoruMaxTemp, Answer="Kırşehir'de şimdiye kadarki en yüksek sıcaklık, 30 Temmuz 2000'de 40,2 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruMinTemp, Answer="Kırşehir'de şimdiye kadarki en düşük sıcaklık, 6 Şubat 1960'ta -24,6 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruUniSayisi, Answer="Kırşehir ilinde 1 adet üniversite bulunmaktadır. Ahi Evran Üniversitesi(2006)." }
                }
            });
            sehirler.Add(new City
            {
                Plate = "41",
                Name = "Kocaeli",
                PictureAddress = "kocaeli640.png",
                TriviaList = new List<Trivia>
                {
                    new Trivia() {Question=AppResources.SoruNufus, Answer="Kocaeli'nin nüfusu: 1.722.795 kişi" },
                    new Trivia() {Question=AppResources.SoruNufusPerKmSq, Answer="Kocaeli'nde km\xB2 başına düşen insan sayısı: 476 kişi"  },
                    new Trivia() {Question=AppResources.SoruBelediyeBaskani, Answer="Kocaeli'nin Belediye Başkanı: AKP'den İbrahim Karaosmanoğlu" },
                    new Trivia() {Question=AppResources.SoruIlceSayisi, Answer="Kocaeli iline bağlı 12 adet ilçe bulunmaktadır." },
                    new Trivia() {Question=AppResources.SoruIlceBelediyeler, Answer="AKP'de 12 ilçe: Kandıra, İzmit, Derince, Körfez, Gebze, Dilovası, Çayırova, Darıca, Kartepe, Başiskele, Gölcük, Karamürsel." },
                    new Trivia() {Question=AppResources.SoruTelefonKod, Answer="Kocaeli'nin telefon alan kodu: (+90)262" },
                    new Trivia() {Question=AppResources.SoruMaxTemp, Answer="Kocaeli'nde şimdiye kadarki en yüksek sıcaklık, 13 Temmuz 2000'de 44,1 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruMinTemp, Answer="Kocaeli'nde şimdiye kadarki en düşük sıcaklık, 14 Ocak 2009'da -9,7 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruUniSayisi, Answer="Kocaeli ilinde 2 adet üniversite bulunmaktadır. Kocaeli Üniversitesi(1992), Gebze Teknik Üniversitesi(1992)." }
                }
            });
            sehirler.Add(new City
            {
                Plate = "42",
                Name = "Konya",
                PictureAddress = "konya640.png",
                TriviaList = new List<Trivia>
                {
                    new Trivia() {Question=AppResources.SoruNufus, Answer="Konya'nın nüfusu: 2.108.808 kişi" },
                    new Trivia() {Question=AppResources.SoruNufusPerKmSq, Answer="Konya'da km\xB2 başına düşen insan sayısı: 51 kişi"  },
                    new Trivia() {Question=AppResources.SoruBelediyeBaskani, Answer="Konya'nın Belediye Başkanı: AKP'den Tahir Akyürek" },
                    new Trivia() {Question=AppResources.SoruIlceSayisi, Answer="Konya iline bağlı 31 adet ilçe bulunmaktadır." },
                    new Trivia() {Question=AppResources.SoruIlceBelediyeler, Answer="AKP'de 26 ilçe: Selçuklu, Meram, Karatay, Ereğli, Akşehir, Beyşehir, Çumra, Seydişehir, Ilgın, Cihanbeyli, Kulu, Karapınar, Kadınhanı, Bozkır, Sarayönü, Yunak, Hüyük, Altınekin, Hadim, Çeltik, Güneysınır, Derebucak, Taşkent, Ahırlı, Derbent, Yalıhüyük. \nMHP'de 3 ilçe: Emirgazi, Akören, Doğanhisar. \nCHP'de 1 ilçe: Tuzlukçu. \nSP'de 1 ilçe: Halkapınar." },
                    new Trivia() {Question=AppResources.SoruTelefonKod, Answer="Konya'nın telefon alan kodu: (+90)332" },
                    new Trivia() {Question=AppResources.SoruMaxTemp, Answer="Konya'da şimdiye kadarki en yüksek sıcaklık, 30 Temmuz 2000'de 40,6 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruMinTemp, Answer="Konya'da şimdiye kadarki en düşük sıcaklık, 6 Şubat 1972'de -26,5 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruUniSayisi, Answer="Konya ilinde 5 adet üniversite bulunmaktadır. Selçuk Üniversitesi(1975), Mevlana Üniversitesi(2009), Necmettin Erbakan Üniversitesi(2010), KTO Karatay Üniversitesi(2010), Konya Gıda ve Tarım Üniversitesi(2013)." }
                }
            });
            sehirler.Add(new City
            {
                Plate = "43",
                Name = "Kütahya",
                PictureAddress = "kutahya640.png",
                TriviaList = new List<Trivia>
                {
                    new Trivia() {Question=AppResources.SoruNufus, Answer="Kütahya'nın nüfusu: 571.554 kişi" },
                    new Trivia() {Question=AppResources.SoruNufusPerKmSq, Answer="Kütahya'da km\xB2 başına düşen insan sayısı: 47 kişi"  },
                    new Trivia() {Question=AppResources.SoruBelediyeBaskani, Answer="Kütahya'nın Belediye Başkanı: AKP'den Kamil Saraçoğlu" },
                    new Trivia() {Question=AppResources.SoruIlceSayisi, Answer="Kütahya iline bağlı Merkez dahil 13 adet ilçe bulunmaktadır." },
                    new Trivia() {Question=AppResources.SoruIlceBelediyeler, Answer="AKP'de 9 ilçe: Merkez, Altıntaş, Aslanapa, Tavşanlı, Gediz, Çavdarhisar, Emet, Hisarcık, Simav. \nMHP'de 3 ilçe: Domaniç, Dumlupınar, Pazarlar. \nCHP'de 1 ilçe: Şaphane. " },
                    new Trivia() {Question=AppResources.SoruTelefonKod, Answer="Kütahya'nın telefon alan kodu: (+90)274" },
                    new Trivia() {Question=AppResources.SoruMaxTemp, Answer="Kütahya'da şimdiye kadarki en yüksek sıcaklık, 31 Temmuz 2010'da 39,5 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruMinTemp, Answer="Kütahya'da şimdiye kadarki en düşük sıcaklık, 2 Şubat 1950'de -27,4 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruUniSayisi, Answer="Kütahya ilinde 1 adet üniversite bulunmaktadır. Dumlupınar Üniversitesi(1992)." }
                }
            });
            sehirler.Add(new City
            {
                Plate = "44",
                Name = "Malatya",
                PictureAddress = "malatya640.png",
                TriviaList = new List<Trivia>
                {
                    new Trivia() {Question=AppResources.SoruNufus, Answer="Malatya'nın nüfusu: 769.544 kişi" },
                    new Trivia() {Question=AppResources.SoruNufusPerKmSq, Answer="Malatya'da km\xB2 başına düşen insan sayısı: 63 kişi"  },
                    new Trivia() {Question=AppResources.SoruBelediyeBaskani, Answer="Malatya'nın Belediye Başkanı: AKP'den Ahmet Çakır" },
                    new Trivia() {Question=AppResources.SoruIlceSayisi, Answer="Malatya iline bağlı 13 adet ilçe bulunmaktadır." },
                    new Trivia() {Question=AppResources.SoruIlceBelediyeler, Answer="AKP'de 11 ilçe: Doğanyol, Pütürge, Kale, Battalgazi, Yeşilyurt, Doğanşehir, Akçadağ, Yazıhan, Darende, Kuluncak, Arapgir. \nCHP'de 2 ilçe: Hekimhan, Arguvan." },
                    new Trivia() {Question=AppResources.SoruTelefonKod, Answer="Malatya'nın telefon alan kodu: (+90)422" },
                    new Trivia() {Question=AppResources.SoruMaxTemp, Answer="Malatya'da şimdiye kadarki en yüksek sıcaklık, 31 Temmuz 2000'de 42,2 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruMinTemp, Answer="Malatya'da şimdiye kadarki en düşük sıcaklık, 28 Aralık 1953'te -22,2 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruUniSayisi, Answer="Malatya ilinde 1 adet üniversite bulunmaktadır. İnönü Üniversitesi(1975)." }
                }
            });
            sehirler.Add(new City
            {
                Plate = "45",
                Name = "Manisa",
                PictureAddress = "manisa640.png",
                TriviaList = new List<Trivia>
                {
                    new Trivia() {Question=AppResources.SoruNufus, Answer="Manisa'nın nüfusu: 1.367.905 kişi" },
                    new Trivia() {Question=AppResources.SoruNufusPerKmSq, Answer="Manisa'da km\xB2 başına düşen insan sayısı: 103 kişi"  },
                    new Trivia() {Question=AppResources.SoruBelediyeBaskani, Answer="Manisa'nın Belediye Başkanı: MHP'den Cengiz Ergün" },
                    new Trivia() {Question=AppResources.SoruIlceSayisi, Answer="Manisa iline bağlı 17 adet ilçe bulunmaktadır." },
                    new Trivia() {Question=AppResources.SoruIlceBelediyeler, Answer="AKP'de 11 ilçe: Demirci, Köprübaşı, Gördes, Akhisar, Kırkağaç, Soma, Gölmarmara, Ahmetli, Saruhanlı, Şehzadeler, Yunusemre. \nMHP'de 6 ilçe: Selendi, Kula, Alaşehir, Sarıgöl, Salihli, Turgutlu." },
                    new Trivia() {Question=AppResources.SoruTelefonKod, Answer="Manisa'nın telefon alan kodu: (+90)236" },
                    new Trivia() {Question=AppResources.SoruMaxTemp, Answer="Manisa'da şimdiye kadarki en yüksek sıcaklık, 25 Temmuz 2007'de 45,5 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruMinTemp, Answer="Manisa'da şimdiye kadarki en düşük sıcaklık, 28 Ocak 1954'te -13,1 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruUniSayisi, Answer="Manisa ilinde 1 adet üniversite bulunmaktadır. Celal Bayar Üniversitesi(1992)." }
                }
            });
            sehirler.Add(new City
            {
                Plate = "46",
                Name = "Kahramanmaraş",
                PictureAddress = "kahramanmaras640.png",
                TriviaList = new List<Trivia>
                {
                    new Trivia() {Question=AppResources.SoruNufus, Answer="Kahramanmaraş'ın nüfusu: 1.089.038 kişi" },
                    new Trivia() {Question=AppResources.SoruNufusPerKmSq, Answer="Kahramanmaraş'ta km\xB2 başına düşen insan sayısı: 75 kişi"  },
                    new Trivia() {Question=AppResources.SoruBelediyeBaskani, Answer="Kahramanmaraş'ın Belediye Başkanı: AKP'den Fatih Mehmet Erkoç" },
                    new Trivia() {Question=AppResources.SoruIlceSayisi, Answer="Kahramanmaraş iline bağlı 11 adet ilçe bulunmaktadır." },
                    new Trivia() {Question=AppResources.SoruIlceBelediyeler, Answer="AKP'de 10 ilçe: Elbistan, Afşin, Göksun, Ekinözü, Onikişubat, Andırın, Dulkadiroğlu, Çağlayancerit, Pazarcık, Türkoğlu. \nCHP'de 1 ilçe: Nurhak." },
                    new Trivia() {Question=AppResources.SoruTelefonKod, Answer="Kahramanmaraş'ın telefon alan kodu: (+90)344" },
                    new Trivia() {Question=AppResources.SoruMaxTemp, Answer="Kahramanmaraş'ta şimdiye kadarki en yüksek sıcaklık, 30 Temmuz 2007'de 45,2 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruMinTemp, Answer="Kahramanmaraş'ta şimdiye kadarki en düşük sıcaklık, 6 Şubat 1997'de -9,6 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruUniSayisi, Answer="Kahramanmaraş ilinde 1 adet üniversite bulunmaktadır. Kahramanmaraş Sütçü İmam Üniversitesi(1992)." }
                }
            });
            sehirler.Add(new City
            {
                Plate = "47",
                Name = "Mardin",
                PictureAddress = "mardin640.png",
                TriviaList = new List<Trivia>
                {
                    new Trivia() {Question=AppResources.SoruNufus, Answer="Mardin'in nüfusu: 788.996 kişi" },
                    new Trivia() {Question=AppResources.SoruNufusPerKmSq, Answer="Mardin'de km\xB2 başına düşen insan sayısı: 89 kişi"  },
                    new Trivia() {Question=AppResources.SoruBelediyeBaskani, Answer="Mardin'in Belediye Eş Başkanları: Ahmet Türk ve Februniye Akyol AKAY (Bağımsız)" },
                    new Trivia() {Question=AppResources.SoruIlceSayisi, Answer="Mardin iline bağlı 10 adet ilçe bulunmaktadır." },
                    new Trivia() {Question=AppResources.SoruIlceBelediyeler, Answer="BDP'de 8 ilçe: Dargeçit, Nusaybin, Ömerli, Savur, Artuklu, Kızıltepe, Mazıdağı, Derik. \nAKP'de 2 ilçe: Midyat, Yeşilli." },
                    new Trivia() {Question=AppResources.SoruTelefonKod, Answer="Mardin'in telefon alan kodu: (+90)482" },
                    new Trivia() {Question=AppResources.SoruMaxTemp, Answer="Mardin'de şimdiye kadarki en yüksek sıcaklık, 31 Temmuz 2000'de 42,5 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruMinTemp, Answer="Mardin'de şimdiye kadarki en düşük sıcaklık, 22 Şubat 1985'te -14,0 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruUniSayisi, Answer="Mardin ilinde 1 adet üniversite bulunmaktadır. Mardin Artuklu Üniversitesi(2007)." }
                }
            });
            sehirler.Add(new City
            {
                Plate = "48",
                Name = "Muğla",
                PictureAddress = "mugla640.png",
                TriviaList = new List<Trivia>
                {
                    new Trivia() {Question=AppResources.SoruNufus, Answer="Muğla'nın nüfusu: 894.509 kişi" },
                    new Trivia() {Question=AppResources.SoruNufusPerKmSq, Answer="Muğla'da km\xB2 başına düşen insan sayısı: 69 kişi"  },
                    new Trivia() {Question=AppResources.SoruBelediyeBaskani, Answer="Muğla'nın Belediye Başkanı: CHP'den Osman Gürün" },
                    new Trivia() {Question=AppResources.SoruIlceSayisi, Answer="Muğla iline bağlı 13 adet ilçe bulunmaktadır." },
                    new Trivia() {Question=AppResources.SoruIlceBelediyeler, Answer="CHP'de 9 ilçe: Bodrum, Milas, Yatağan, Menteşe, Ula, Marmaris, Datça, Ortaca, Dalaman. \nAKP'de 3 ilçe: Kavaklıdere, Köyceğiz, Seydikemer. \nDP'de 1 ilçe: Fethiye." },
                    new Trivia() {Question=AppResources.SoruTelefonKod, Answer="Muğla'nın telefon alan kodu: (+90)252" },
                    new Trivia() {Question=AppResources.SoruMaxTemp, Answer="Muğla'da şimdiye kadarki en yüksek sıcaklık, 27 Temmuz 2007'de 42,1 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruMinTemp, Answer="Muğla'da şimdiye kadarki en düşük sıcaklık, 13 Ocak 1954'te -11,0 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruUniSayisi, Answer="Muğla ilinde 1 adet üniversite bulunmaktadır. Muğla Sıtkı Koçman Üniversitesi(1992)." }
                }
            });
            sehirler.Add(new City
            {
                Plate = "49",
                Name = "Muş",
                PictureAddress = "mus640.png",
                TriviaList = new List<Trivia>
                {
                    new Trivia() {Question=AppResources.SoruNufus, Answer="Muş'un nüfusu: 411.216 kişi" },
                    new Trivia() {Question=AppResources.SoruNufusPerKmSq, Answer="Muş'ta km\xB2 başına düşen insan sayısı: 51 kişi"  },
                    new Trivia() {Question=AppResources.SoruBelediyeBaskani, Answer="Muş'un Belediye Başkanı: AKP'den Feyat Asya" },
                    new Trivia() {Question=AppResources.SoruIlceSayisi, Answer="Muş iline bağlı Merkez dahil 6 adet ilçe bulunmaktadır." },
                    new Trivia() {Question=AppResources.SoruIlceBelediyeler, Answer="AKP'de 3 ilçe: Merkez, Hasköy, Korkut. \nBDP'de 3 ilçe: Varto, Bulanık, Malazgirt." },
                    new Trivia() {Question=AppResources.SoruTelefonKod, Answer="Muş'un telefon alan kodu: (+90)436" },
                    new Trivia() {Question=AppResources.SoruMaxTemp, Answer="Muş'ta şimdiye kadarki en yüksek sıcaklık, 16 Temmuz 2000'de 41,6 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruMinTemp, Answer="Muş'ta şimdiye kadarki en düşük sıcaklık, 9 Şubat 1982'de -34,4 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruUniSayisi, Answer="Muş ilinde 1 adet üniversite bulunmaktadır. Muş Alparslan Üniversitesi(2007)." }
                }
            });
            sehirler.Add(new City
            {
                Plate = "50",
                Name = "Nevşehir",
                PictureAddress = "nevsehir640.png",
                TriviaList = new List<Trivia>
                {
                    new Trivia() {Question=AppResources.SoruNufus, Answer="Nevşehir'in nüfusu: 286.250 kişi" },
                    new Trivia() {Question=AppResources.SoruNufusPerKmSq, Answer="Nevşehir'de km\xB2 başına düşen insan sayısı: 53 kişi"  },
                    new Trivia() {Question=AppResources.SoruBelediyeBaskani, Answer="Nevşehir'in Belediye Başkanı: AKP'den Hasan Ünver" },
                    new Trivia() {Question=AppResources.SoruIlceSayisi, Answer="Nevşehir iline bağlı Merkez dahil 8 adet ilçe bulunmaktadır." },
                    new Trivia() {Question=AppResources.SoruIlceBelediyeler, Answer="AKP'de 3 ilçe: Merkez, Acıgöl, Ürgüp. \nMHP'de 3 ilçe: Kozaklı, Gülşehir, Derinkuyu. \nCHP'de 1 ilçe: Avanos. \nBağımsız 1 ilçe: Hacıbektaş" },
                    new Trivia() {Question=AppResources.SoruTelefonKod, Answer="Nevşehir'in telefon alan kodu: (+90)384" },
                    new Trivia() {Question=AppResources.SoruMaxTemp, Answer="Nevşehir'de şimdiye kadarki en yüksek sıcaklık, 30 Temmuz 2000'de 39,5 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruMinTemp, Answer="Nevşehir'de şimdiye kadarki en düşük sıcaklık, 4 Şubat 1960'te -23,6 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruUniSayisi, Answer="Nevşehir ilinde 1 adet üniversite bulunmaktadır. Nevşehir Hacı Bektaş Veli Üniversitesi(2007)." }
                }
            });
            sehirler.Add(new City
            {
                Plate = "51",
                Name = "Niğde",
                PictureAddress = "nigde640.png",
                TriviaList = new List<Trivia>
                {
                    new Trivia() {Question=AppResources.SoruNufus, Answer="Niğde'nin nüfusu: 343.898 kişi" },
                    new Trivia() {Question=AppResources.SoruNufusPerKmSq, Answer="Niğde'de km\xB2 başına düşen insan sayısı: 46 kişi"  },
                    new Trivia() {Question=AppResources.SoruBelediyeBaskani, Answer="Niğde'nin Belediye Başkanı: AKP'den Faruk Akdoğan" },
                    new Trivia() {Question=AppResources.SoruIlceSayisi, Answer="Niğde iline bağlı Merkez dahil 6 adet ilçe bulunmaktadır." },
                    new Trivia() {Question=AppResources.SoruIlceBelediyeler, Answer="AKP'de 5 ilçe: Merkez, Çamardı, Ulukışla, Bor, Altunhisar. \nMHP'de 1 ilçe: Çiftlik." },
                    new Trivia() {Question=AppResources.SoruTelefonKod, Answer="Niğde'nin telefon alan kodu: (+90)388" },
                    new Trivia() {Question=AppResources.SoruMaxTemp, Answer="Niğde'de şimdiye kadarki en yüksek sıcaklık, 27 Temmuz 2012'de 38,5 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruMinTemp, Answer="Niğde'de şimdiye kadarki en düşük sıcaklık, 27 Şubat 1985'te -24,2 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruUniSayisi, Answer="Niğde ilinde 1 adet üniversite bulunmaktadır. Niğde Üniversitesi(1992)" }
                }
            });
            sehirler.Add(new City
            {
                Plate = "52",
                Name = "Ordu",
                PictureAddress = "ordu640.png",
                TriviaList = new List<Trivia>
                {
                    new Trivia() {Question=AppResources.SoruNufus, Answer="Ordu'nun nüfusu: 724.268 kişi" },
                    new Trivia() {Question=AppResources.SoruNufusPerKmSq, Answer="Ordu'da km\xB2 başına düşen insan sayısı: 122 kişi"  },
                    new Trivia() {Question=AppResources.SoruBelediyeBaskani, Answer="Ordu'nun Belediye Başkanı: AKP'den Enver Yılmaz" },
                    new Trivia() {Question=AppResources.SoruIlceSayisi, Answer="Ordu iline bağlı 19 adet ilçe bulunmaktadır." },
                    new Trivia() {Question=AppResources.SoruIlceBelediyeler, Answer="AKP'de 19 ilçe: Çamaş, Gölköy, Kabadüz, Mesudiye, Akkuş, Çatalpınar, Gülyalı, Kabataş, Perşembe, Altınordu, Çaybaşı, Gürgentepe, Korgan, Ulubey, Aybastı, Fatsa, İkizce, Kumru, Ünye." },
                    new Trivia() {Question=AppResources.SoruTelefonKod, Answer="Ordu'nun telefon alan kodu: (+90)452" },
                    new Trivia() {Question=AppResources.SoruMaxTemp, Answer="Ordu'da şimdiye kadarki en yüksek sıcaklık, 6 Haziran 1994'te 37,3 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruMinTemp, Answer="Ordu'da şimdiye kadarki en düşük sıcaklık, 29 Ocak 1964'te -7,2 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruUniSayisi, Answer="Ordu ilinde 1 adet üniversite bulunmaktadır. Ordu Üniversitesi(2006)." }
                }
            });
            sehirler.Add(new City
            {
                Plate = "53",
                Name = "Rize",
                PictureAddress = "rize640.png",
                TriviaList = new List<Trivia>
                {
                    new Trivia() {Question=AppResources.SoruNufus, Answer="Rize'nin nüfusu: 329.779 kişi" },
                    new Trivia() {Question=AppResources.SoruNufusPerKmSq, Answer="Rize'de km\xB2 başına düşen insan sayısı: 84 kişi"  },
                    new Trivia() {Question=AppResources.SoruBelediyeBaskani, Answer="Rize'nin Belediye Başkanı: AKP'den Reşat Kasap" },
                    new Trivia() {Question=AppResources.SoruIlceSayisi, Answer="Rize iline bağlı Merkez dahil 12 adet ilçe bulunmaktadır." },
                    new Trivia() {Question=AppResources.SoruIlceBelediyeler, Answer="AKP'de 11 ilçe: Merkez, Fındıklı, Ardeşen, Pazar, Çamlıhemşin, Hemşin, Çayeli, Güneysu, Derepazarı, İyidere, İkizdere. \nSP'de 1 ilçe: Kalkandere." },
                    new Trivia() {Question=AppResources.SoruTelefonKod, Answer="Rize'nin telefon alan kodu: (+90)464" },
                    new Trivia() {Question=AppResources.SoruMaxTemp, Answer="Rize'de şimdiye kadarki en yüksek sıcaklık, 21 Mayıs 1980'de 38,2 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruMinTemp, Answer="Rize'de şimdiye kadarki en düşük sıcaklık, 19 Mart 1963'te -7,0 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruUniSayisi, Answer="Rize ilinde 1 adet üniversite bulunmaktadır. Recep Tayyip Erdoğan Üniversitesi(2006)." }
                }
            });
            sehirler.Add(new City
            {
                Plate = "54",
                Name = "Sakarya",
                PictureAddress = "sakarya640.png",
                TriviaList = new List<Trivia>
                {
                    new Trivia() {Question=AppResources.SoruNufus, Answer="Sakarya'nın nüfusu: 932.706 kişi" },
                    new Trivia() {Question=AppResources.SoruNufusPerKmSq, Answer="Sakarya'da km\xB2 başına düşen insan sayısı: 191 kişi"  },
                    new Trivia() {Question=AppResources.SoruBelediyeBaskani, Answer="Sakarya'nın Belediye Başkanı: AKP'den Zeki Toçoğlu" },
                    new Trivia() {Question=AppResources.SoruIlceSayisi, Answer="Sakarya iline bağlı 16 adet ilçe bulunmaktadır." },
                    new Trivia() {Question=AppResources.SoruIlceBelediyeler, Answer="AKP'de 16 ilçe: Erenler, Karapürçek, Pamukova, Taraklı, Adapazarı, Ferizli, Karasu, Sapanca, Akyazı, Geyve, Kaynarca, Serdivan, Arifiye, Hendek, Kocaali, Söğütlü." },
                    new Trivia() {Question=AppResources.SoruTelefonKod, Answer="Sakarya'nın telefon alan kodu: (+90)264" },
                    new Trivia() {Question=AppResources.SoruMaxTemp, Answer="Sakarya'da şimdiye kadarki en yüksek sıcaklık, 13 Temmuz 2000'de 44,0 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruMinTemp, Answer="Sakarya'da şimdiye kadarki en düşük sıcaklık, 22 Ocak 1961'de -14,5 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruUniSayisi, Answer="Sakarya ilinde 1 adet üniversite bulunmaktadır. Sakarya Üniversitesi(1992)." }
                }
            });
            sehirler.Add(new City
            {
                Plate = "55",
                Name = "Samsun",
                PictureAddress = "samsun640.png",
                TriviaList = new List<Trivia>
                {
                    new Trivia() {Question=AppResources.SoruNufus, Answer="Samsun'un nüfusu: 1.269.989 kişi" },
                    new Trivia() {Question=AppResources.SoruNufusPerKmSq, Answer="Samsun'da km\xB2 başına düşen insan sayısı: 136 kişi"  },
                    new Trivia() {Question=AppResources.SoruBelediyeBaskani, Answer="Samsun'un Belediye Başkanı: AKP'den Yusuf Ziya Yılmaz" },
                    new Trivia() {Question=AppResources.SoruIlceSayisi, Answer="Samsun iline bağlı 17 adet ilçe bulunmaktadır." },
                    new Trivia() {Question=AppResources.SoruIlceBelediyeler, Answer="AKP'de 16 ilçe: Ayvacık, Havza, 19Mayıs, Vezirköprü, Alaçam, Bafra, İlkadım, Salıpazarı, Yakakent, Canik, Kavak, Tekkeköy, Atakum, Çarşamba, Ladik, Terme. \nMHP'de 1 ilçe: Asarcık." },
                    new Trivia() {Question=AppResources.SoruTelefonKod, Answer="Samsun'un telefon alan kodu: (+90)362" },
                    new Trivia() {Question=AppResources.SoruMaxTemp, Answer="Samsun'da şimdiye kadarki en yüksek sıcaklık, 25 Temmuz 1973'te 37,5 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruMinTemp, Answer="Samsun'da şimdiye kadarki en düşük sıcaklık, 13 Ocak 1950'de -8,1 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruUniSayisi, Answer="Samsun ilinde 2 adet üniversite bulunmaktadır. Ondokuz Mayıs Üniversitesi(1975), Canik Başarı Üniversitesi(2010)." }
                }
            });
            sehirler.Add(new City
            {
                Plate = "56",
                Name = "Siirt",
                PictureAddress = "siirt640.png",
                TriviaList = new List<Trivia>
                {
                    new Trivia() {Question=AppResources.SoruNufus, Answer="Siirt'in nüfusu: 318.366 kişi" },
                    new Trivia() {Question=AppResources.SoruNufusPerKmSq, Answer="Siirt'te km\xB2 başına düşen insan sayısı: 58 kişi"  },
                    new Trivia() {Question=AppResources.SoruBelediyeBaskani, Answer="Siirt'in Belediye Eş Başkanları: BDP'den Belkiza Beştaş Epözdemir ve Tuncer Bakırhan" },
                    new Trivia() {Question=AppResources.SoruIlceSayisi, Answer="Siirt iline bağlı Merkez dahil 7 adet ilçe bulunmaktadır." },
                    new Trivia() {Question=AppResources.SoruIlceBelediyeler, Answer="AKP'de 4 ilçe: Kurtalan, Tillo, Şirvan, Pervari. \nBDP'de 3 ilçe: Merkez, Eruh, Baykan." },
                    new Trivia() {Question=AppResources.SoruTelefonKod, Answer="Siirt'in telefon alan kodu: (+90)484" },
                    new Trivia() {Question=AppResources.SoruMaxTemp, Answer="Siirt'te şimdiye kadarki en yüksek sıcaklık, 6 Ağustos 1973'te 46,0 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruMinTemp, Answer="Siirt'te şimdiye kadarki en düşük sıcaklık, 16 Ocak 1950'de -19,3 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruUniSayisi, Answer="Siirt ilinde 1 adet üniversite bulunmaktadır. Siirt Üniversitesi(2007)." }
                }
            });
            sehirler.Add(new City
            {
                Plate = "57",
                Name = "Sinop",
                PictureAddress = "sinop640.png",
                TriviaList = new List<Trivia>
                {
                    new Trivia() {Question=AppResources.SoruNufus, Answer="Sinop'un nüfusu: 204.526 kişi" },
                    new Trivia() {Question=AppResources.SoruNufusPerKmSq, Answer="Sinop'ta km\xB2 başına düşen insan sayısı: 35 kişi"  },
                    new Trivia() {Question=AppResources.SoruBelediyeBaskani, Answer="Sinop'un Belediye Başkanı: CHP'den Baki Ergül" },
                    new Trivia() {Question=AppResources.SoruIlceSayisi, Answer="Sinop iline bağlı Merkez dahil 9 adet ilçe bulunmaktadır." },
                    new Trivia() {Question=AppResources.SoruIlceBelediyeler, Answer="CHP'de 4 ilçe: Merkez, Erfelek, Gerze, Dikmen. \nAKP'de 4 ilçe: Ayancık, Boyabat, Saraydüzü, Durağan. \nMHP'de 1 ilçe: Türkeli." },
                    new Trivia() {Question=AppResources.SoruTelefonKod, Answer="Sinop'un telefon alan kodu: (+90)368" },
                    new Trivia() {Question=AppResources.SoruMaxTemp, Answer="Sinop'ta şimdiye kadarki en yüksek sıcaklık, 6 Temmuz 2000'de 34,4 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruMinTemp, Answer="Sinop'ta şimdiye kadarki en düşük sıcaklık, 21 Şubat 1985'te -7,5 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruUniSayisi, Answer="Sinop ilinde 1 adet üniversite bulunmaktadır. Sinop Üniversitesi(2007)" }
                }
            });
            sehirler.Add(new City
            {
                Plate = "58",
                Name = "Sivas",
                PictureAddress = "sivas640.png",
                TriviaList = new List<Trivia>
                {
                    new Trivia() {Question=AppResources.SoruNufus, Answer="Sivas'ın nüfusu: 623.116 kişi" },
                    new Trivia() {Question=AppResources.SoruNufusPerKmSq, Answer="Sivas'ta km\xB2 başına düşen insan sayısı: 22 kişi"  },
                    new Trivia() {Question=AppResources.SoruBelediyeBaskani, Answer="Sivas'ın Belediye Başkanı: AKP'den Sami Aydın" },
                    new Trivia() {Question=AppResources.SoruIlceSayisi, Answer="Sivas iline bağlı Merkez dahil 17 adet ilçe bulunmaktadır." },
                    new Trivia() {Question=AppResources.SoruIlceBelediyeler, Answer="AKP'de 10 ilçe: Merkez, Şarkışla, Altınyayla, Kangal, Hafik, Doğanşar, Zara, Suşehri, Akıncılar, Gölova. \nMHP'de 4 ilçe: Gürün, Yıldızeli, İmranlı, Koyulhisar. \nCHP'de 2 ilçe: Divriği, Ulaş. \nBBP'de 1 ilçe: Gemerek." },
                    new Trivia() {Question=AppResources.SoruTelefonKod, Answer="Sivas'ın telefon alan kodu: (+90)346" },
                    new Trivia() {Question=AppResources.SoruMaxTemp, Answer="Sivas'ta şimdiye kadarki en yüksek sıcaklık, 30 Temmuz 2000'de 40,0 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruMinTemp, Answer="Sivas'ta şimdiye kadarki en düşük sıcaklık, 20 Ocak 1972'de -34,6 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruUniSayisi, Answer="Sivas ilinde 1 adet üniversite bulunmaktadır. Cumhuriyet Üniversitesi(1974)." }
                }
            });
            sehirler.Add(new City
            {
                Plate = "59",
                Name = "Tekirdağ",
                PictureAddress = "tekirdag640.png",
                TriviaList = new List<Trivia>
                {
                    new Trivia() {Question=AppResources.SoruNufus, Answer="Tekirdağ'ın nüfusu: 906.732 kişi" },
                    new Trivia() {Question=AppResources.SoruNufusPerKmSq, Answer="Tekirdağ'da km\xB2 başına düşen insan sayısı: 143 kişi"  },
                    new Trivia() {Question=AppResources.SoruBelediyeBaskani, Answer="Tekirdağ'ın Belediye Başkanı: CHP'den Kadir Albayrak" },
                    new Trivia() {Question=AppResources.SoruIlceSayisi, Answer="Tekirdağ iline bağlı 11 adet ilçe bulunmaktadır." },
                    new Trivia() {Question=AppResources.SoruIlceBelediyeler, Answer="CHP'de 11 ilçe: Çerkezköy, Çorlu, Ergene, Hayrabolu, Kapaklı, Malkara, Marmaraereğlisi, Muratlı, Saray, Süleymanpaşa, Şarköy." },
                    new Trivia() {Question=AppResources.SoruTelefonKod, Answer="Tekirdağ'ın telefon alan kodu: (+90)282" },
                    new Trivia() {Question=AppResources.SoruMaxTemp, Answer="Tekirdağ'da şimdiye kadarki en yüksek sıcaklık, 27 Haziran 2007'de 40,2 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruMinTemp, Answer="Tekirdağ'da şimdiye kadarki en düşük sıcaklık, 5 Şubat 1950'de -13,3 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruUniSayisi, Answer="Tekirdağ ilinde 1 adet üniversite bulunmaktadır. Namık Kemal Üniversitesi(2006)." }
                }
            });
            sehirler.Add(new City
            {
                Plate = "60",
                Name = "Tokat",
                PictureAddress = "tokat640.png",
                TriviaList = new List<Trivia>
                {
                    new Trivia() {Question=AppResources.SoruNufus, Answer="Tokat'ın nüfusu: 597.920 kişi" },
                    new Trivia() {Question=AppResources.SoruNufusPerKmSq, Answer="Tokat'ta km\xB2 başına düşen insan sayısı: 59 kişi"  },
                    new Trivia() {Question=AppResources.SoruBelediyeBaskani, Answer="Tokat'ın Belediye Başkanı: AKP'den Eyüp Eroğlu" },
                    new Trivia() {Question=AppResources.SoruIlceSayisi, Answer="Tokat iline bağlı Merkez dahil 12 adet ilçe bulunmaktadır." },
                    new Trivia() {Question=AppResources.SoruIlceBelediyeler, Answer="AKP'de 12 ilçe: Merkez, Erbaa, Sulusaray, Almus, Niksar, Turhal, Artova, Pazar, Yeşilyurt, Başçiftlik, Reşadiye, Zile." },
                    new Trivia() {Question=AppResources.SoruTelefonKod, Answer="Tokat'ın telefon alan kodu: (+90)356" },
                    new Trivia() {Question=AppResources.SoruMaxTemp, Answer="Tokat'ta şimdiye kadarki en yüksek sıcaklık, 30 Temmuz 2000'de 45,0 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruMinTemp, Answer="Tokat'ta şimdiye kadarki en düşük sıcaklık, 20 Ocak 1972'de -23,4 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruUniSayisi, Answer="Tokat ilinde 1 adet üniversite bulunmaktadır. Gaziosmanpaşa Üniversitesi(1992)." }
                }
            });
            sehirler.Add(new City
            {
                Plate = "61",
                Name = "Trabzon",
                PictureAddress = "trabzon640.png",
                TriviaList = new List<Trivia>
                {
                    new Trivia() {Question=AppResources.SoruNufus, Answer="Trabzon'un nüfusu: 766.782 kişi" },
                    new Trivia() {Question=AppResources.SoruNufusPerKmSq, Answer="Trabzon'da km\xB2 başına düşen insan sayısı: 164 kişi"  },
                    new Trivia() {Question=AppResources.SoruBelediyeBaskani, Answer="Trabzon'un Belediye Başkanı: AKP'den Orhan Fevzi Gümrükçüoğlu" },
                    new Trivia() {Question=AppResources.SoruIlceSayisi, Answer="Trabzon iline bağlı 18 adet ilçe bulunmaktadır." },
                    new Trivia() {Question=AppResources.SoruIlceBelediyeler, Answer="AKP'de 16 ilçe: Beşikdüzü, Vakfıkebir, Tonya, Çarşıbaşı, Akçaabat, Maçka, Ortahisar, Yomra, Arsin, Araklı, Sürmene, Köprübaşı, Of, Dernekpazarı, Çaykara, Hayrat. \nCHP'de 1 ilçe: Düzköy. \nMHP'de 1 ilçe: Şalpazarı." },
                    new Trivia() {Question=AppResources.SoruTelefonKod, Answer="Trabzon'un telefon alan kodu: (+90)462" },
                    new Trivia() {Question=AppResources.SoruMaxTemp, Answer="Trabzon'da şimdiye kadarki en yüksek sıcaklık, 17 Mayıs 1988'de 37,8 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruMinTemp, Answer="Trabzon'da şimdiye kadarki en düşük sıcaklık, 15 Ocak 1950'de -7,0 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruUniSayisi, Answer="Trabzon ilinde 2 adet üniversite bulunmaktadır. Karadeniz Teknik Üniversitesi(1955), Avrasya Üniversitesi(2010)." }
                }
            });
            sehirler.Add(new City
            {
                Plate = "62",
                Name = "Tunceli",
                PictureAddress = "tunceli640.png",
                TriviaList = new List<Trivia>
                {
                    new Trivia() {Question=AppResources.SoruNufus, Answer="Tunceli'nin nüfusu: 86.527 kişi" },
                    new Trivia() {Question=AppResources.SoruNufusPerKmSq, Answer="Tunceli'de km\xB2 başına düşen insan sayısı: 11 kişi"  },
                    new Trivia() {Question=AppResources.SoruBelediyeBaskani, Answer="Tunceli'nin Belediye Eş Başkanları: BDP'den Nurhayat Altun ve Mehmet Ali Bul" },
                    new Trivia() {Question=AppResources.SoruIlceSayisi, Answer="Tunceli iline bağlı Merkez dahil 8 adet ilçe bulunmaktadır." },
                    new Trivia() {Question=AppResources.SoruIlceBelediyeler, Answer="CHP'de 4 ilçe: Pülümür, Nazımiye, Hozat, Çemişgezek. \nBDP'de 1 ilçe: Merkez. \nTKP'de 1 ilçe: Ovacık. \nAKP'de 1 ilçe: Pertek. \nMHP'de 1 ilçe: Mazgirt." },
                    new Trivia() {Question=AppResources.SoruTelefonKod, Answer="Tunceli'nin telefon alan kodu: (+90)428" },
                    new Trivia() {Question=AppResources.SoruMaxTemp, Answer="Tunceli'de şimdiye kadarki en yüksek sıcaklık, 26 Temmuz 1961 ve 17 Ağustos 1961'de 43,5 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruMinTemp, Answer="Tunceli'de şimdiye kadarki en düşük sıcaklık, 20 Ocak 1972'de -30,3 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruUniSayisi, Answer="Tunceli ilinde 1 adet üniversite bulunmaktadır. Tunceli Üniversitesi(2008)." }
                }
            });
            sehirler.Add(new City
            {
                Plate = "63",
                Name = "Şanlıurfa",
                PictureAddress = "sanliurfa640.png",
                TriviaList = new List<Trivia>
                {
                    new Trivia() {Question=AppResources.SoruNufus, Answer="Şanlıurfa'nın nüfusu: 1.845.667 kişi" },
                    new Trivia() {Question=AppResources.SoruNufusPerKmSq, Answer="Şanlıurfa'da km\xB2 başına düşen insan sayısı: 95 kişi"  },
                    new Trivia() {Question=AppResources.SoruBelediyeBaskani, Answer="Şanlıurfa'nın Belediye Başkanı: AKP'den Nihat Çiftçi" },
                    new Trivia() {Question=AppResources.SoruIlceSayisi, Answer="Şanlıurfa iline bağlı 13 adet ilçe bulunmaktadır." },
                    new Trivia() {Question=AppResources.SoruIlceBelediyeler, Answer="AKP'de 9 ilçe: Siverek, Hilvan, Karaköprü, Haliliye, Ceylanpınar, Eyyübiye, Harran, Akçakale, Birecik. \nBDP'de 4 ilçe: Viranşehir, Suruç, Bozova, Halfeti." },
                    new Trivia() {Question=AppResources.SoruTelefonKod, Answer="Şanlıurfa'nın telefon alan kodu: (+90)414" },
                    new Trivia() {Question=AppResources.SoruMaxTemp, Answer="Şanlıurfa'da şimdiye kadarki en yüksek sıcaklık, 30 Temmuz 2000'de 46,8 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruMinTemp, Answer="Şanlıurfa'da şimdiye kadarki en düşük sıcaklık, 5 Şubat 1950'de -11,4 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruUniSayisi, Answer="Şanlıurfa ilinde 1 adet üniversite bulunmaktadır. Harran Üniversitesi(1992)." }
                }
            });
            sehirler.Add(new City
            {
                Plate = "64",
                Name = "Uşak",
                PictureAddress = "usak640.png",
                TriviaList = new List<Trivia>
                {
                    new Trivia() {Question=AppResources.SoruNufus, Answer="Uşak'ın nüfusu: 349.459 kişi" },
                    new Trivia() {Question=AppResources.SoruNufusPerKmSq, Answer="Uşak'ta km\xB2 başına düşen insan sayısı: 65 kişi"  },
                    new Trivia() {Question=AppResources.SoruBelediyeBaskani, Answer="Uşak'ın Belediye Başkanı: AKP'den Nurullah Cahan" },
                    new Trivia() {Question=AppResources.SoruIlceSayisi, Answer="Uşak iline bağlı Merkez dahil 6 adet ilçe bulunmaktadır." },
                    new Trivia() {Question=AppResources.SoruIlceBelediyeler, Answer="AKP'de 4 ilçe: Merkez, Banaz, Karahallı, Eşme. \nCHP'de 2 ilçe: Ulubey, Sivaslı." },
                    new Trivia() {Question=AppResources.SoruTelefonKod, Answer="Uşak'ın telefon alan kodu: (+90)276" },
                    new Trivia() {Question=AppResources.SoruMaxTemp, Answer="Uşak'ta şimdiye kadarki en yüksek sıcaklık, 29 Temmuz 2000'de 40,2 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruMinTemp, Answer="Uşak'ta şimdiye kadarki en düşük sıcaklık, 15 Ocak 1968'de -19,7 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruUniSayisi, Answer="Uşak ilinde 1 adet üniversite bulunmaktadır. Uşak Üniversitesi(2006)." }
                }
            });
            sehirler.Add(new City
            {
                Plate = "65",
                Name = "Van",
                PictureAddress = "van640.png",
                TriviaList = new List<Trivia>
                {
                    new Trivia() {Question=AppResources.SoruNufus, Answer="Van'ın nüfusu: 1.085.542 kişi" },
                    new Trivia() {Question=AppResources.SoruNufusPerKmSq, Answer="Van'da km\xB2 başına düşen insan sayısı: 51 kişi"  },
                    new Trivia() {Question=AppResources.SoruBelediyeBaskani, Answer="Van'ın Belediye Eş Başkanları: BDP'den Hatice Çoban ve Bekir Kaya" },
                    new Trivia() {Question=AppResources.SoruIlceSayisi, Answer="Van iline bağlı 13 adet ilçe bulunmaktadır." },
                    new Trivia() {Question=AppResources.SoruIlceBelediyeler, Answer="BDP'de 11 ilçe: Erciş, Muradiye, Çaldıran, Özalp, İpekyolu, Saray, Gürpınar, Başkale, Edremit, Çatak, Bahçesaray. \nAKP'de 2 ilçe: Tuşba, Gevaş." },
                    new Trivia() {Question=AppResources.SoruTelefonKod, Answer="Van'ın telefon alan kodu: (+90)432" },
                    new Trivia() {Question=AppResources.SoruMaxTemp, Answer="Van'da şimdiye kadarki en yüksek sıcaklık, 27 Temmuz 1966'da 37,5 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruMinTemp, Answer="Van'da şimdiye kadarki en düşük sıcaklık, 19 Ocak 1964'te -28,7 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruUniSayisi, Answer="Van ilinde 1 adet üniversite bulunmaktadır. Yüzüncü Yıl Üniversitesi(1982)." }
                }
            });
            sehirler.Add(new City
            {
                Plate = "66",
                Name = "Yozgat",
                PictureAddress = "yozgat640.png",
                TriviaList = new List<Trivia>
                {
                    new Trivia() {Question=AppResources.SoruNufus, Answer="Yozgat'ın nüfusu: 432.560 kişi" },
                    new Trivia() {Question=AppResources.SoruNufusPerKmSq, Answer="Yozgat'ta km\xB2 başına düşen insan sayısı: 31 kişi"  },
                    new Trivia() {Question=AppResources.SoruBelediyeBaskani, Answer="Yozgat'ın Belediye Başkanı: AKP'den Kazım Arslan" },
                    new Trivia() {Question=AppResources.SoruIlceSayisi, Answer="Yozgat iline bağlı Merkez dahil 14 adet ilçe bulunmaktadır." },
                    new Trivia() {Question=AppResources.SoruIlceBelediyeler, Answer="AKP'de 13 ilçe: Merkez, Yerköy, Sorgun, Aydıncık, Çekerek, Kadışehri, Saraykent, Akdağmadeni, Çayıralan, Çandır, Boğazlıyan, Yenifakılı, Şefaatli. \nMHP'de 1 ilçe: Sarıkaya. " },
                    new Trivia() {Question=AppResources.SoruTelefonKod, Answer="Yozgat'ın telefon alan kodu: (+90)354" },
                    new Trivia() {Question=AppResources.SoruMaxTemp, Answer="Yozgat'ta şimdiye kadarki en yüksek sıcaklık, 30 Temmuz 2000'de 38,8 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruMinTemp, Answer="Yozgat'ta şimdiye kadarki en düşük sıcaklık, 23 Şubat 1985'te -24,4 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruUniSayisi, Answer="Yozgat ilinde 1 adet üniversite bulunmaktadır. Bozok Üniversitesi(2006)." }
                }
            });
            sehirler.Add(new City
            {
                Plate = "67",
                Name = "Zonguldak",
                PictureAddress = "zonguldak640.png",
                TriviaList = new List<Trivia>
                {
                    new Trivia() {Question=AppResources.SoruNufus, Answer="Zonguldak'ın nüfusu: 598.796 kişi" },
                    new Trivia() {Question=AppResources.SoruNufusPerKmSq, Answer="Zonguldak'ta km\xB2 başına düşen insan sayısı: 181 kişi"  },
                    new Trivia() {Question=AppResources.SoruBelediyeBaskani, Answer="Zonguldak'ın Belediye Başkanı: CHP'den Muharrem Akdemir" },
                    new Trivia() {Question=AppResources.SoruIlceSayisi, Answer="Zonguldak iline bağlı Merkez dahil 8 adet ilçe bulunmaktadır." },
                    new Trivia() {Question=AppResources.SoruIlceBelediyeler, Answer="CHP'de 4 ilçe: Merkez, Alaplı, Kilimli, Çaycuma. \nAKP'de 4 ilçe: Kozlu, Ereğli, Devrek, Gökçebey." },
                    new Trivia() {Question=AppResources.SoruTelefonKod, Answer="Zonguldak'ın telefon alan kodu: (+90)372" },
                    new Trivia() {Question=AppResources.SoruMaxTemp, Answer="Zonguldak'ta şimdiye kadarki en yüksek sıcaklık, 13 Temmuz 2000'de 39,5 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruMinTemp, Answer="Zonguldak'ta şimdiye kadarki en düşük sıcaklık, 4 Şubat 1950'de -8,0 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruUniSayisi, Answer="Zonguldak ilinde 1 adet üniversite bulunmaktadır. Bülent Ecevit Üniversitesi(1992)." }
                }
            });
            sehirler.Add(new City
            {
                Plate = "68",
                Name = "Aksaray",
                PictureAddress = "aksaray640.png",
                TriviaList = new List<Trivia>
                {
                    new Trivia() {Question=AppResources.SoruNufus, Answer="Aksaray'ın nüfusu: 384.252 kişi" },
                    new Trivia() {Question=AppResources.SoruNufusPerKmSq, Answer="Aksaray'da km\xB2 başına düşen insan sayısı: 48 kişi"  },
                    new Trivia() {Question=AppResources.SoruBelediyeBaskani, Answer="Aksaray'ın Belediye Başkanı: AKP'den Haluk Şahin Yazgı" },
                    new Trivia() {Question=AppResources.SoruIlceSayisi, Answer="Aksaray iline bağlı Merkez dahil 7 adet ilçe bulunmaktadır." },
                    new Trivia() {Question=AppResources.SoruIlceBelediyeler, Answer="AKP'de 6 ilçe: Merkez, Eskil, Güzelyurt, Gülağaç, Ağaçören, Sarıyahşi. \nMHP'de 1 ilçe: Ortaköy." },
                    new Trivia() {Question=AppResources.SoruTelefonKod, Answer="Aksaray'ın telefon alan kodu: (+90)382" },
                    new Trivia() {Question=AppResources.SoruMaxTemp, Answer="Aksaray'da şimdiye kadarki en yüksek sıcaklık, 30 Temmuz 2000'de 40,0 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruMinTemp, Answer="Aksaray'da şimdiye kadarki en düşük sıcaklık, 7 Şubat 1991'de -29,0 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruUniSayisi, Answer="Aksaray ilinde 1 adet üniversite bulunmaktadır. Aksaray Üniversitesi(2006)." }
                }
            });
            sehirler.Add(new City
            {
                Plate = "69",
                Name = "Bayburt",
                PictureAddress = "bayburt640.png",
                TriviaList = new List<Trivia>
                {
                    new Trivia() {Question=AppResources.SoruNufus, Answer="Bayburt'un nüfusu: 80.607 kişi" },
                    new Trivia() {Question=AppResources.SoruNufusPerKmSq, Answer="Bayburt'ta km\xB2 başına düşen insan sayısı: 22 kişi"  },
                    new Trivia() {Question=AppResources.SoruBelediyeBaskani, Answer="Bayburt'un Belediye Başkanı: AKP'den Mete Memiş" },
                    new Trivia() {Question=AppResources.SoruIlceSayisi, Answer="Bayburt iline bağlı Merkez dahil 3 adet ilçe bulunmaktadır." },
                    new Trivia() {Question=AppResources.SoruIlceBelediyeler, Answer="AKP'de 2 ilçe: Merkez, Demirözü. \nMHP'de 1 ilçe: Aydıntepe." },
                    new Trivia() {Question=AppResources.SoruTelefonKod, Answer="Bayburt'un telefon alan kodu: (+90)458" },
                    new Trivia() {Question=AppResources.SoruMaxTemp, Answer="Bayburt'ta şimdiye kadarki en yüksek sıcaklık, 14 Ağustos 2006'da 37,1 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruMinTemp, Answer="Bayburt'ta şimdiye kadarki en düşük sıcaklık, 20 Ocak 1972'de -31,3 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruUniSayisi, Answer="Bayburt ilinde 1 adet üniversite bulunmaktadır. Bayburt Üniversitesi(2008)." }
                }
            });
            sehirler.Add(new City
            {
                Plate = "70",
                Name = "Karaman",
                PictureAddress = "karaman640.png",
                TriviaList = new List<Trivia>
                {
                    new Trivia() {Question=AppResources.SoruNufus, Answer="Karaman'ın nüfusu: 240.362 kişi" },
                    new Trivia() {Question=AppResources.SoruNufusPerKmSq, Answer="Karaman'da km\xB2 başına düşen insan sayısı: 27 kişi"  },
                    new Trivia() {Question=AppResources.SoruBelediyeBaskani, Answer="Karaman'ın Belediye Başkanı: AKP'den Ertuğrul Çalışkan" },
                    new Trivia() {Question=AppResources.SoruIlceSayisi, Answer="Karaman iline bağlı Merkez dahil 6 adet ilçe bulunmaktadır." },
                    new Trivia() {Question=AppResources.SoruIlceBelediyeler, Answer="AKP'de 4 ilçe: Merkez, Kazımkarabekir, Ermenek, Başyayla. \nMHP'de 2 ilçe: Ayrancı, Sarıveliler." },
                    new Trivia() {Question=AppResources.SoruTelefonKod, Answer="Karaman'ın telefon alan kodu: (+90)338" },
                    new Trivia() {Question=AppResources.SoruMaxTemp, Answer="Karaman'da şimdiye kadarki en yüksek sıcaklık, 29 Temmuz 2000 ve 1 Ağustos 2010'da 40,4 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruMinTemp, Answer="Karaman'da şimdiye kadarki en düşük sıcaklık, 5 Şubat 1991'de -28,0 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruUniSayisi, Answer="Karaman ilinde 1 adet üniversite bulunmaktadır. Karamanoğlu Mehmetbey Üniversitesi(2007)." }
                }
            });
            sehirler.Add(new City
            {
                Plate = "71",
                Name = "Kırıkkale",
                PictureAddress = "kirikkale640.png",
                TriviaList = new List<Trivia>
                {
                    new Trivia() {Question=AppResources.SoruNufus, Answer="Kırıkkale'nin nüfusu: 271.092 kişi" },
                    new Trivia() {Question=AppResources.SoruNufusPerKmSq, Answer="Kırıkkale'de km\xB2 başına düşen insan sayısı: 59 kişi"  },
                    new Trivia() {Question=AppResources.SoruBelediyeBaskani, Answer="Kırıkkale'nin Belediye Başkanı: AKP'den Mehmet Saygılı" },
                    new Trivia() {Question=AppResources.SoruIlceSayisi, Answer="Kırıkkale iline bağlı Merkez dahil 9 ilçe adet bulunmaktadır." },
                    new Trivia() {Question=AppResources.SoruIlceBelediyeler, Answer="AKP'de 6 ilçe: Merkez, Balışeyh, Yahşihan, Bahşili, Karakeçili, Çelebi. \nBBP'de 1 ilçe: Keskin. \nMHP'de 1 ilçe: Sulakyurt. \nSP'de 1 ilçe: Delice." },
                    new Trivia() {Question=AppResources.SoruTelefonKod, Answer="Kırıkkale'nin telefon alan kodu: (+90)318" },
                    new Trivia() {Question=AppResources.SoruMaxTemp, Answer="Kırıkkale'de şimdiye kadarki en yüksek sıcaklık, 26 Temmuz 2012'de 41,8 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruMinTemp, Answer="Kırıkkale'de şimdiye kadarki en düşük sıcaklık, 16 Ocak 1980'de -22,4 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruUniSayisi, Answer="Kırıkkale ilinde 1 adet üniversite bulunmaktadır. Kırıkkale Üniversitesi(1992)." }
                }
            });
            sehirler.Add(new City
            {
                Plate = "72",
                Name = "Batman",
                PictureAddress = "batman640.png",
                TriviaList = new List<Trivia>
                {
                    new Trivia() {Question=AppResources.SoruNufus, Answer="Batman'ın nüfusu: 557.593 kişi" },
                    new Trivia() {Question=AppResources.SoruNufusPerKmSq, Answer="Batman'da km\xB2 başına düşen insan sayısı: 119 kişi"  },
                    new Trivia() {Question=AppResources.SoruBelediyeBaskani, Answer="Batman'ın Belediye Eş Başkanları: BDP'den Gülüstan Akel ve Sabri Özdemir" },
                    new Trivia() {Question=AppResources.SoruIlceSayisi, Answer="Batman iline bağlı Merkez dahil 6 adet ilçe bulunmaktadır." },
                    new Trivia() {Question=AppResources.SoruIlceBelediyeler, Answer="BDP'de 3 ilçe: Merkez, Beşiri, Gercüş. \nAKP'de 2 ilçe: Hasankeyf, Kozluk. \nSP'de 1 ilçe: Sason." },
                    new Trivia() {Question=AppResources.SoruTelefonKod, Answer="Batman'ın telefon alan kodu: (+90)488" },
                    new Trivia() {Question=AppResources.SoruMaxTemp, Answer="Batman'da şimdiye kadarki en yüksek sıcaklık, 10 Temmuz 1962'de 48,8 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruMinTemp, Answer="Batman'da şimdiye kadarki en düşük sıcaklık, 1 Ocak 2007'de -24,0 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruUniSayisi, Answer="Batman ilinde 1 adet üniversite bulunmaktadır. Batman Üniversitesi(2007)." }
                }
            });
            sehirler.Add(new City
            {
                Plate = "73",
                Name = "Şırnak",
                PictureAddress = "sirnak640.png",
                TriviaList = new List<Trivia>
                {
                    new Trivia() {Question=AppResources.SoruNufus, Answer="Şırnak'ın nüfusu: 488.966 kişi" },
                    new Trivia() {Question=AppResources.SoruNufusPerKmSq, Answer="Şırnak'ta km\xB2 başına düşen insan sayısı: 68 kişi"  },
                    new Trivia() {Question=AppResources.SoruBelediyeBaskani, Answer="Şırnak'ın Belediye Eş Başkanları: BDP'den Özlem Onuk ve Serhat Kadırhan " },
                    new Trivia() {Question=AppResources.SoruIlceSayisi, Answer="Şırnak iline bağlı Merkez dahil 7 adet ilçe bulunmaktadır." },
                    new Trivia() {Question=AppResources.SoruIlceBelediyeler, Answer="BDP'de 6 ilçe: Merkez, İdil, Cizre, Silopi, Uludere, Beytüşşebap. \nAKP'de 1 ilçe: Güçlükonak." },
                    new Trivia() {Question=AppResources.SoruTelefonKod, Answer="Şırnak'ın telefon alan kodu: (+90)486" },
                    new Trivia() {Question=AppResources.SoruMaxTemp, Answer="Şırnak'ta şimdiye kadarki en yüksek sıcaklık, 28 Temmuz 2011'de 40,4 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruMinTemp, Answer="Şırnak'ta şimdiye kadarki en düşük sıcaklık, 2 Ocak 2009'da -14,5 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruUniSayisi, Answer="Şırnak ilinde 1 adet üniversite bulunmaktadır. Şırnak Üniversitesi(2008)." }
                }
            });
            sehirler.Add(new City
            {
                Plate = "74",
                Name = "Bartın",
                PictureAddress = "bartin640.png",
                TriviaList = new List<Trivia>
                {
                    new Trivia() {Question=AppResources.SoruNufus, Answer="Bartın'ın nüfusu: 189.405 kişi" },
                    new Trivia() {Question=AppResources.SoruNufusPerKmSq, Answer="Bartın'da km\xB2 başına düşen insan sayısı: 91 kişi"  },
                    new Trivia() {Question=AppResources.SoruBelediyeBaskani, Answer="Bartın'ın Belediye Başkanı: MHP'den Cemal Akın" },
                    new Trivia() {Question=AppResources.SoruIlceSayisi, Answer="Bartın iline bağlı Merkez dahil 4 adet ilçe bulunmaktadır." },
                    new Trivia() {Question=AppResources.SoruIlceBelediyeler, Answer="MHP'de 1 ilçe: Merkez. \nAKP'de 2 ilçe: Ulus, Kurucaşile. \nCHP'de 1 ilçe: Amasra." },
                    new Trivia() {Question=AppResources.SoruTelefonKod, Answer="Bartın'ın telefon alan kodu: (+90)378" },
                    new Trivia() {Question=AppResources.SoruMaxTemp, Answer="Bartın'da şimdiye kadarki en yüksek sıcaklık, 13 Temmuz 2000'de 42,8 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruMinTemp, Answer="Bartın'da şimdiye kadarki en düşük sıcaklık, 23 Şubat 1985'te -18,6 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruUniSayisi, Answer="Bartın ilinde 1 adet üniversite bulunmaktadır. Bartın Üniversitesi(2008)." }
                }
            });
            sehirler.Add(new City
            {
                Plate = "75",
                Name = "Ardahan",
                PictureAddress = "ardahan640.png",
                TriviaList = new List<Trivia>
                {
                    new Trivia() {Question=AppResources.SoruNufus, Answer="Ardahan'ın nüfusu: 100.809 kişi" },
                    new Trivia() {Question=AppResources.SoruNufusPerKmSq, Answer="Ardahan'da km\xB2 başına düşen insan sayısı: 20 kişi"  },
                    new Trivia() {Question=AppResources.SoruBelediyeBaskani, Answer="Ardahan'ın Belediye Başkanı: AKP'den Faruk Köksoy" },
                    new Trivia() {Question=AppResources.SoruIlceSayisi, Answer="Ardahan iline bağlı Merkez dahil 6 adet ilçe bulunmaktadır." },
                    new Trivia() {Question=AppResources.SoruIlceBelediyeler, Answer="AKP'de 3 ilçe: Merkez, Göle, Posof. \nCHP'de 2 ilçe: Hanak, Damal. \nDSP'de 1 ilçe: Çıldır." },
                    new Trivia() {Question=AppResources.SoruTelefonKod, Answer="Ardahan'ın telefon alan kodu: (+90)478" },
                    new Trivia() {Question=AppResources.SoruMaxTemp, Answer="Ardahan'da şimdiye kadarki en yüksek sıcaklık, 29 Ağustos 1998'de 35,0 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruMinTemp, Answer="Ardahan'da şimdiye kadarki en düşük sıcaklık, 21 Ocak 1972'de -39,8 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruUniSayisi, Answer="Ardahan ilinde 1 adet üniversite bulunmaktadır. Ardahan Üniversitesi(2008)." }
                }
            });
            sehirler.Add(new City
            {
                Plate = "76",
                Name = "Iğdır",
                PictureAddress = "igdir640.png",
                TriviaList = new List<Trivia>
                {
                    new Trivia() {Question=AppResources.SoruNufus, Answer="Iğdır'ın nüfusu: 192.056 kişi" },
                    new Trivia() {Question=AppResources.SoruNufusPerKmSq, Answer="Iğdır'da km\xB2 başına düşen insan sayısı: 54 kişi"  },
                    new Trivia() {Question=AppResources.SoruBelediyeBaskani, Answer="Iğdır'ın Belediye Başkanı: BDP'den Şaziye Önder ve Murat Yikit" },
                    new Trivia() {Question=AppResources.SoruIlceSayisi, Answer="Iğdır iline bağlı Merkez dahil 4 adet ilçe bulunmaktadır." },
                    new Trivia() {Question=AppResources.SoruIlceBelediyeler, Answer="BDP'de 2 ilçe: Merkez, Tuzluca. \nCHP'de 1 ilçe: Karakoyunlu. \nDP'de 1 ilçe: Aralık." },
                    new Trivia() {Question=AppResources.SoruTelefonKod, Answer="Iğdır'ın telefon alan kodu: (+90)476" },
                    new Trivia() {Question=AppResources.SoruMaxTemp, Answer="Iğdır'da şimdiye kadarki en yüksek sıcaklık, 12 Ağustos 2003'te 42,0 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruMinTemp, Answer="Iğdır'da şimdiye kadarki en düşük sıcaklık, 29 Aralık 1953'te -30,3 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruUniSayisi, Answer="Iğdır ilinde 1 adet üniversite bulunmaktadır. Iğdır Üniversitesi(2008)." }
                }
            });
            sehirler.Add(new City
            {
                Plate = "77",
                Name = "Yalova",
                PictureAddress = "yalova640.png",
                TriviaList = new List<Trivia>
                {
                    new Trivia() {Question=AppResources.SoruNufus, Answer="Yalova'nın nüfusu: 226.514 kişi" },
                    new Trivia() {Question=AppResources.SoruNufusPerKmSq, Answer="Yalova'da km\xB2 başına düşen insan sayısı: 266 kişi"  },
                    new Trivia() {Question=AppResources.SoruBelediyeBaskani, Answer="Yalova'nın Belediye Başkanı: CHP'den Vefa Salman" },
                    new Trivia() {Question=AppResources.SoruIlceSayisi, Answer="Yalova iline bağlı Merkez dahil 6 adet ilçe bulunmaktadır." },
                    new Trivia() {Question=AppResources.SoruIlceBelediyeler, Answer="AKP'de 4 ilçe: Altınova, Çiftlikköy, Termal, Armutlu. \nCHP'de 2 ilçe: Merkez, Çınarcık." },
                    new Trivia() {Question=AppResources.SoruTelefonKod, Answer="Yalova'nın telefon alan kodu: (+90)226" },
                    new Trivia() {Question=AppResources.SoruMaxTemp, Answer="Yalova'da şimdiye kadarki en yüksek sıcaklık, 13 Temmuz 2000'de 45,4 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruMinTemp, Answer="Yalova'da şimdiye kadarki en düşük sıcaklık, 22 Şubat 1985'te -11,0 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruUniSayisi, Answer="Yalova ilinde 1 adet üniversite bulunmaktadır. Yalova Üniversitesi(2008)." }
                }
            });
            sehirler.Add(new City
            {
                Plate = "78",
                Name = "Karabük",
                PictureAddress = "karabuk640.png",
                TriviaList = new List<Trivia>
                {
                    new Trivia() {Question=AppResources.SoruNufus, Answer="Karabük'ün nüfusu: 231.333 kişi" },
                    new Trivia() {Question=AppResources.SoruNufusPerKmSq, Answer="Karabük'te km\xB2 başına düşen insan sayısı: 56 kişi"  },
                    new Trivia() {Question=AppResources.SoruBelediyeBaskani, Answer="Karabük'ün Belediye Başkanı: MHP'den Rafet Vergili" },
                    new Trivia() {Question=AppResources.SoruIlceSayisi, Answer="Karabük iline bağlı Merkez dahil 6 adet ilçe bulunmaktadır." },
                    new Trivia() {Question=AppResources.SoruIlceBelediyeler, Answer="AKP'de 4 ilçe: Eflani, Safranbolu, Yenice, Eskipazar. \nMHP'de 2 ilçe: Merkez, Ovacık." },
                    new Trivia() {Question=AppResources.SoruTelefonKod, Answer="Karabük'ün telefon alan kodu: (+90)370" },
                    new Trivia() {Question=AppResources.SoruMaxTemp, Answer="Karabük'de şimdiye kadarki en yüksek sıcaklık, 11 Ağustos 1970'de 44,1 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruMinTemp, Answer="Karabük'de şimdiye kadarki en düşük sıcaklık, 25 Ocak 1974'de -15,1 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruUniSayisi, Answer="Karabük ilinde 1 adet üniversite bulunmaktadır. Karabük Üniversitesi(2007)." }
                }
            });
            sehirler.Add(new City
            {
                Plate = "79",
                Name = "Kilis",
                PictureAddress = "kilis640.png",
                TriviaList = new List<Trivia>
                {
                    new Trivia() {Question=AppResources.SoruNufus, Answer="Kilis'in nüfusu: 128.781 kişi" },
                    new Trivia() {Question=AppResources.SoruNufusPerKmSq, Answer="Kilis'te km\xB2 başına düşen insan sayısı: 89 kişi"  },
                    new Trivia() {Question=AppResources.SoruBelediyeBaskani, Answer="Kilis'in Belediye Başkanı: AKP'den Hasan Kara" },
                    new Trivia() {Question=AppResources.SoruIlceSayisi, Answer="Kilis iline bağlı Merkez dahil 4 adet ilçe bulunmaktadır." },
                    new Trivia() {Question=AppResources.SoruIlceBelediyeler, Answer="AKP'de 4 ilçe: Merkez, Elbeyli, Polateli, Musabeyli." },
                    new Trivia() {Question=AppResources.SoruTelefonKod, Answer="Kilis'in telefon alan kodu: (+90)348" },
                    new Trivia() {Question=AppResources.SoruMaxTemp, Answer="Kilis'te şimdiye kadarki en yüksek sıcaklık, 3 Ağustos 2010'da 45,0 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruMinTemp, Answer="Kilis'te şimdiye kadarki en düşük sıcaklık, 19 Ocak 1964 ve 2 Şubat 1967'de -12,0 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruUniSayisi, Answer="Kilis ilinde 1 adet üniversite bulunmaktadır. Kilis 7 Aralık Üniversitesi(2007)." }
                }
            });
            sehirler.Add(new City
            {
                Plate = "80",
                Name = "Osmaniye",
                PictureAddress = "osmaniye640.png",
                TriviaList = new List<Trivia>
                {
                    new Trivia() {Question=AppResources.SoruNufus, Answer="Osmaniye'nin nüfusu: 506.807 kişi" },
                    new Trivia() {Question=AppResources.SoruNufusPerKmSq, Answer="Osmaniye'de km\xB2 başına düşen insan sayısı: 158 kişi"  },
                    new Trivia() {Question=AppResources.SoruBelediyeBaskani, Answer="Osmaniye'nin Belediye Başkanı: MHP'den Kadir Kara" },
                    new Trivia() {Question=AppResources.SoruIlceSayisi, Answer="Osmaniye iline bağlı Merkez dahil 7 adet ilçe bulunmaktadır." },
                    new Trivia() {Question=AppResources.SoruIlceBelediyeler, Answer="MHP'de 4 ilçe: Merkez, Hasanbeyli, Kadirli, Sumbas. \nAKP'de 2 ilçe: Düziçi, Bahçe. \nCHP'de 1 ilçe: Toprakkale." },
                    new Trivia() {Question=AppResources.SoruTelefonKod, Answer="Osmaniye'nin telefon alan kodu: (+90)328" },
                    new Trivia() {Question=AppResources.SoruMaxTemp, Answer="Osmaniye'de şimdiye kadarki en yüksek sıcaklık, 6 Temmuz 2004'te 42,8 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruMinTemp, Answer="Osmaniye'de şimdiye kadarki en düşük sıcaklık, 4 Ocak 1989'da -8,5 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruUniSayisi, Answer="Osmaniye ilinde 1 adet üniversite bulunmaktadır. Osmaniye Korkut Ata Üniversitesi(2007)." }
                }
            });
            sehirler.Add(new City
            {
                Plate = "81",
                Name = "Düzce",
                PictureAddress = "duzce640.png",
                TriviaList = new List<Trivia>
                {
                    new Trivia() {Question=AppResources.SoruNufus, Answer="Düzce'nin nüfusu: 355.549 kişi" },
                    new Trivia() {Question=AppResources.SoruNufusPerKmSq, Answer="Düzce'de km\xB2 başına düşen insan sayısı: 138 kişi"  },
                    new Trivia() {Question=AppResources.SoruBelediyeBaskani, Answer="Düzce'nin Belediye Başkanı: AKP'den Mehmet Keleş" },
                    new Trivia() {Question=AppResources.SoruIlceSayisi, Answer="Düzce iline bağlı Merkez dahil 8 adet ilçe bulunmaktadır." },
                    new Trivia() {Question=AppResources.SoruIlceBelediyeler, Answer="AKP'de 8 ilçe: Merkez, Yığılca, Akçakoca, Çilimli, Cumayeri, Gümüşova, Gölyaka, Kaynaşlı." },
                    new Trivia() {Question=AppResources.SoruTelefonKod, Answer="Düzce'nin telefon alan kodu: (+90)380" },
                    new Trivia() {Question=AppResources.SoruMaxTemp, Answer="Düzce'de şimdiye kadarki en yüksek sıcaklık, 13 Temmuz 2000'de 42,4 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruMinTemp, Answer="Düzce'de şimdiye kadarki en düşük sıcaklık, 22 Ocak 1967'de -20,5 °C olarak ölçülmüştür." },
                    new Trivia() {Question=AppResources.SoruUniSayisi, Answer="Düzce ilinde 1 adet üniversite bulunmaktadır. Düzce Üniversitesi(2006)." }
                }
            });

        }

    }
}
