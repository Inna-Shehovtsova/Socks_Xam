using System;
using System.Collections.Generic;
using System.Text;

namespace Socks.Model
{
    public class KidSockModel : SimpleSockKnitModel
    {

        public KidSockModel(double plotX, double plotY) : base(new BaseSockModel
        {
            Mangeta = 5,
            Top = 4,
            Toe = 18,
            Thick = 22
        }, plotX, plotY)
        {

            CurrentRow = 0;
            _size = 25;
            _currentKnittingSize = "Вяжем носки " + _size + " размера.";
            _sizes = new List<int> { 25, 26, 27, 28, 29, 30 };
        }
    }
}
