using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using WPF_MVVM.Models;
using WPF_MVVM.Entity;

namespace WPF_MVVM.ViewModels
{
    public class VM : BaseVM  //VM Запущенный робот
    {                         //Внутри робота запускаем подключение к биржи - Класс Server
        public VM()
        {
            _server = new Server();

            _server.EventTradeDelegate += _server_EventTradeDelegate; 
        }

       

        //============================================= Fields =========================================

        Server _server;

        //============================================= Properties =========================================

        public decimal Volume
        { 
            get => _volume;

            set
            {
                _volume = value;
                OnPropertyChanged(nameof(Volume));// OnPropertyChanged("Number") переделал на OnPropertyChanged(nameof(Number)); легче редактировать.
            } 
        }
        decimal _volume;

        public decimal Price
        {
            get => _price;

            set
            {
                _price = value;
                OnPropertyChanged(nameof(Price));
            }
        }
        decimal _price;

        public DateTime DateTimeTrade
        {
            get => _dateTimeTrade;

            set
            {
                _dateTimeTrade = value;
                OnPropertyChanged(nameof(DateTimeTrade));// OnPropertyChanged("Number") переделал на OnPropertyChanged(nameof(Number)); легче редактировать.
            }
        }
        DateTime _dateTimeTrade;

        public Side Side
        {
            get => side;

            set
            {               
                if (value > 0)
                {
                    side = Side.Long;
                    OnPropertyChanged(nameof(Side));
                }
                else if (value < 0)
                {
                    side = Side.Short;
                    OnPropertyChanged(nameof(Side));
                }
            }
        }
        Side side;



        //============================================= Methods =========================================

        private void _server_EventTradeDelegate(Trade trade)
        {
            Volume = trade.Volume;
            Price = trade.Price;
            DateTimeTrade = trade.DateTime;
            Side = (Side)trade.Volume;
        }







    }
}
