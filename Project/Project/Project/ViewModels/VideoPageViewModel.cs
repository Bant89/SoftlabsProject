using MediaManager;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Project.ViewModels
{
    public class VideoPageViewModel : BaseViewModel
    {
        string url = "https://converter.savefrom.net/joiner?id=HJq3m-Ck2FI&v=https%3A%2F%2Fredirector.googlevideo.com%2Fvideoplayback%3Fexpire%3D1570231863%26ei%3D14GXXfKPBNii-gaol4O4Bg%26ip%3D170.130.62.190%26id%3Do-AFD_7FeTZk5v2gVTjxCCOyfnZZ2F1ovkACtN7Z4noev_%26itag%3D247%26aitags%3D133%252C134%252C135%252C136%252C137%252C160%252C242%252C243%252C244%252C247%252C248%252C271%252C278%252C313%26source%3Dyoutube%26requiressl%3Dyes%26mm%3D31%252C26%26mn%3Dsn-a5mlrn7z%252Csn-q4fl6n7s%26ms%3Dau%252Conr%26mv%3Du%26mvi%3D0%26pl%3D22%26mime%3Dvideo%252Fwebm%26gir%3Dyes%26clen%3D26650554%26dur%3D183.182%26lmt%3D1570205327991374%26mt%3D1570209415%26fvip%3D5%26keepalive%3Dyes%26fexp%3D23842630%26c%3DWEB%26txp%3D5531432%26sparams%3Dexpire%252Cei%252Cip%252Cid%252Caitags%252Csource%252Crequiressl%252Cmime%252Cgir%252Cclen%252Cdur%252Clmt%26lsparams%3Dmm%252Cmn%252Cms%252Cmv%252Cmvi%252Cpl%26lsig%3DAHylml4wRgIhAK2su8I0x3ds8iRWxZS8XcrdvoIQq_tWHzA_BICmsptvAiEA_EUJ7owyprX1geSYxEPNNyxLsvR28MnE50sedpbB_SI%253D%26sig%3DALgxI2wwRQIhAJ10sdIyyT9xjIbNN0XiQYsp4lVGhf4tsGDogwzBVbBhAiAWAY9fsZqH2MyJfBzjN5Uhdb8qQqtJ8WLQWmIU1pq0RA%253D%253D&a=https%3A%2F%2Fredirector.googlevideo.com%2Fvideoplayback%3Fexpire%3D1570231863%26ei%3D14GXXfKPBNii-gaol4O4Bg%26ip%3D170.130.62.190%26id%3Do-AFD_7FeTZk5v2gVTjxCCOyfnZZ2F1ovkACtN7Z4noev_%26itag%3D251%26source%3Dyoutube%26requiressl%3Dyes%26mm%3D31%252C26%26mn%3Dsn-a5mlrn7z%252Csn-q4fl6n7s%26ms%3Dau%252Conr%26mv%3Du%26mvi%3D0%26pl%3D22%26mime%3Daudio%252Fwebm%26gir%3Dyes%26clen%3D3167063%26dur%3D183.221%26lmt%3D1570204515684817%26mt%3D1570209415%26fvip%3D5%26keepalive%3Dyes%26fexp%3D23842630%26c%3DWEB%26txp%3D5531432%26sparams%3Dexpire%252Cei%252Cip%252Cid%252Citag%252Csource%252Crequiressl%252Cmime%252Cgir%252Cclen%252Cdur%252Clmt%26lsparams%3Dmm%252Cmn%252Cms%252Cmv%252Cmvi%252Cpl%26lsig%3DAHylml4wRgIhAK2su8I0x3ds8iRWxZS8XcrdvoIQq_tWHzA_BICmsptvAiEA_EUJ7owyprX1geSYxEPNNyxLsvR28MnE50sedpbB_SI%253D%26sig%3DALgxI2wwRQIhAJSz43jwsnUSz-01nbK7IHE8gJADrkmZCSrYJToLi_1EAiAA8pA4dgvBEAO1JD_ShaIvXxanjr3GhEwsc0bNs8h4ZQ%253D%253D&ts=1570223175&ip=186.149.130.219&sig=000ff05e0ab6b9bebdae967997289dfa&t=FINNEAS+-+Shelter+%28Official+Video%29";
        public ICommand PlayCommand { get; set; }
        public ICommand StopCommand { get; set; }
        public ICommand PauseCommand { get; set; }
        public ICommand PlayPauseCommand { get; set; }
        public VideoPageViewModel()
        {
            PageName = "{0}";

            PlayCommand = new Command(async () =>
           {
               await CrossMediaManager.Current.Play(url);
           });
            PauseCommand = new Command(async () =>
            {
                await CrossMediaManager.Current.Pause();
            });
           PlayPauseCommand = new Command(async () =>
            {
                await CrossMediaManager.Current.PlayPause();
            });
            StopCommand = new Command(async () =>
           {
               await CrossMediaManager.Current.Stop();
           });
        }
    }
}
