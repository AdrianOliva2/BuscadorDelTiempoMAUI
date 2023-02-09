using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscadorDelTiempoMAUI.MVVM.Models
{
    [AddINotifyPropertyChangedInterface]
    public class Weather
    {
        public float temperature { get; set; }
        public float windspeed { get; set; }
        public float winddirection { get; set; }
        public int weathercode { get; set; }
        public string time { get; set; }
    }
}
