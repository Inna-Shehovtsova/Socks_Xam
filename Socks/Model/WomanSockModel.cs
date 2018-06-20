using System;
using System.Collections.Generic;
using System.Text;

namespace Socks.Model
{
    public class WomanSockModel : SimpleSockKnitModel
    {

        public WomanSockModel(double plotX, double plotY) : base(new BaseSockModel
        {
            Mangeta = 5,
            Top = 10,
            Toe = 24,
            Thick = 30
        }, plotX, plotY)
        {

            CurrentRow = 0;
            _size = 37;
            _currentKnittingSize = "Вяжем носки " + _size + " размера.";
            _sizes = new List<int> { 36, 37, 38, 39, 40 };
        }
    }
}

