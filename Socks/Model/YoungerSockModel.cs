using System;
using System.Collections.Generic;
using System.Text;

namespace Socks.Model
{
    public class YoungerSockModel : SimpleSockKnitModel
    {
        public YoungerSockModel(double plotX, double plotY) : base(new BaseSockModel
        {
            Mangeta = 5,
            Top = 6,
            Toe = 22,
            Thick = 25
        }, plotX, plotY)
        {

            CurrentRow = 0;
            _size = 35;
            _currentKnittingSize = "Вяжем носки " + _size + " размера.";
            _sizes = new List<int> { 30, 31, 32, 33, 34, 35 };
        }
    }
}
