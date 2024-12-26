using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using WPF_MVVM.Entity;
using WPF_MVVM.ViewModels;

namespace WPF_MVVM.Models
{
    public class Server : BaseVM
    {
        public Server()
        {
            Timer timer = new Timer();

            timer.Interval = 1000;

            timer.Elapsed += Timer_Elapsed;

            timer.Start();
        }

        //============================================= Fields =========================================

        Random _random = new Random();

        //============================================= Methods =========================================
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Trade trade = new Trade();

            trade.Volume = _random.Next(-10, 10);

            trade.Price = _random.Next(50000, 60000);

            trade.DateTime = DateTime.Now;

            //EventTradeDelegate?.Invoke(trade);

            if (EventTradeDelegate != null) 
            {
                EventTradeDelegate(trade);
            }

        }

        //============================================= Event =========================================

        public delegate void tradeDelegate(Trade trade);

        public event tradeDelegate EventTradeDelegate;
    }
}
