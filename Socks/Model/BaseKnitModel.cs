using System;
using System.Collections.Generic;
using System.Text;

namespace Socks.Model
{
    public class OneRow
    {
        public int Stitch { get; set; }
        public string Description { get; set; }
        public Parts part { get; set; }
        public string partName { get; set; }
    }

    public class BaseKnitModel
    {
        protected List<int> _mangeta;
        protected List<int> _mainPart;
        protected List<int> _top;
        protected List<int> _heel;
        protected List<int> _toe;
        protected const int decrease = 4;
        protected int counted4NeedleStitch;
        public BaseSockModel sockModel;
        public double PlotX { get; private set; }
        public double PlotY { get; private set; }
        public BaseKnitModel(BaseSockModel sm, double plotnostX, double PlotnostY)
        {
            sockModel = sm;
            PlotX = plotnostX;
            PlotY = PlotnostY;
            double quantityStitchPred = sm.Thick * PlotX / 10.0;
            int need1stich = (int)(quantityStitchPred / 4);
            int need4stich = need1stich * 4 - quantityStitchPred < -3 ? (need1stich + 1) * 4 : need1stich * 4;
            need1stich = need4stich / 4;
            counted4NeedleStitch = need4stich;
            _mangeta = new List<int>();
            for (int i = 0; i < CountRow(sm.Mangeta); i++)
            {
                _mangeta.Add(need4stich);
            }

            _top = new List<int>();
            for (int i = 0; i < CountRow(sm.Top); i++)
            {
                _top.Add(need4stich);
            }
            //_toe = new List<int>();
            //for (int i = 0; i < CountDecreaseRow(need4stich, decrease); i++)
            //{
            //    _toe.Add(need4stich - decrease * (i + 1));
            //}
            CountDecreaseRow(need4stich, decrease);

            int heelRest = need4stich / 6;
            _heel = new List<int>()
                ;
            for (int i = 0; i < heelRest * 2; i++)
            {
                //_heel.Add(need1stich*2 -i*2-2);
                _heel.Add(need1stich * 2 - i);
            }
            for (int i = 0; i < 2; i++)
            {
                _heel.Add(need4stich);
            }
            for (int i = heelRest * 2 - 1; i > -1; i--)
            {
                _heel.Add(need1stich * 2 - i);
            }
            countMainPart(sm.Toe, need4stich);
        }

        int CountRow(double length)
        {
            return (int)(length * PlotY / 10.0);

        }
        int CountDecreaseRow(int allstitich, int decrease)
        {
            _toe = new List<int>();
            int _slow_decrease = (allstitich - 8) / 2;
            int row_slow_decrease = _slow_decrease / decrease;
            int restToe = 0;
            for (int i = 0; i < row_slow_decrease; i++)
            {
                restToe = allstitich - decrease * (i + 1);
                _toe.Add(restToe);
                _toe.Add(restToe);
            }
            int row_max_decrease = (restToe - 8) / decrease;
            for (int i = 0; i < row_max_decrease; i++)
            {
                _toe.Add(restToe - decrease * (i + 1));

            }
            return _toe.Capacity;

        }
        protected void countMainPart(double Toe, int stitch)
        {
            _mainPart = new List<int>();
            for (int i = 0; i < CountRow(Toe) - _top.Count - (_heel.Count - 2) / 2; i++)
            {
                _mainPart.Add(stitch);
            }
        }

    }
}
public enum Parts
{
    Zero,
    Mangeta,
    Top1, Top2, Top3, Top4,
    Heel1, Heel2, Heel3,
    MainPart1, MainPart2, MainPart3, MainPart4, MainPart5,
    Toe
}
