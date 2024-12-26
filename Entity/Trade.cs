using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_MVVM.Entity
{
    public class Trade
    {
        public decimal Volume
        {
            get => _volume;

            set
            {
                
                _volume = value;

                if (value > 0)
                {
                    Side = Side.Long;

                }
                else if (value < 0) 
                { 
                    Side = Side.Short;                
                }


            } 
        }
        decimal _volume;




        public decimal Price;

        public Side Side = Side.None;

        public DateTime DateTime = DateTime.MinValue;// 1 Января 1971г.

        public string SecName;
    }
}
