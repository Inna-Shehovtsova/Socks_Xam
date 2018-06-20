using System;
using System.Collections.Generic;
using System.Text;

namespace Socks.Model
{
    public class ManSockModel : SimpleSockKnitModel
    {
        public ManSockModel(double plotX, double plotY) : base(new BaseSockModel
        {
            Mangeta = 7,
            Top = 7,
            Toe = 29,
            Thick = 30
        }, plotX, plotY)
        {

            CurrentRow = 0;
            _size = 43;
            _currentKnittingSize = "Вяжем носки " + _size + " размера.";
            _sizes = new List<int> { 40, 41, 42, 43, 44, 45 };
        }
    }
}
