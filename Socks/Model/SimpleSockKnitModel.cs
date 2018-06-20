using System;
using System.Collections.Generic;
using System.Text;

namespace Socks.Model
{
    public class SimpleSockKnitModel : BaseKnitModel
    {
        protected List<OneRow> knitRows { get; set; }
        protected int _size;
        public List<int> _sizes;
        protected string _currentKnittingSize;
        private int _currRow;

        public SimpleSockKnitModel(BaseSockModel bm, double plotX, double plotY) : base(bm, plotX, plotY)
        {

            _currRow = 0;
            _size = 37;
            _currentKnittingSize = "Вяжем носки " + _size + " размера.";
            sockModel.Toe = (double)_size / 1.5 + 1.5;
            countMainPart(sockModel.Toe, counted4NeedleStitch);
            setKnitRowsDescription();

        }
        public int CurrentRow
        {
            get { return _currRow; }
            set
            {
                if (knitRows == null)
                {
                    _currRow = 0;
                    return;
                }
                if (value >= knitRows.Count)
                    return;
                if (value < 0)
                    return;
                else
                    _currRow = value;
            }
        }
        public int CurrentSize
        {
            get { return _size; }
            set
            {
                if (_size != value && value > 0)
                {
                    _size = value;
                    sockModel.Toe = (double)_size / 1.5 + 1.5;
                    countMainPart(sockModel.Toe, counted4NeedleStitch);
                    setKnitRowsDescription();
                    _currentKnittingSize = "Вяжем носки " + _size + "размера.";
                }
            }
        }
        public string KnittingSize
        {
            get
            {
                return _currentKnittingSize;
            }
            private set { }
        }
        public string CurrentDescription
        {
            get
            {
                return knitRows[CurrentRow].Description;
            }
            private set
            { }
        }
        public List<string> AllDescription
        {
            get
            {
                List<string> ret = new List<string>();
                foreach (OneRow s in knitRows)
                {
                    ret.Add(s.Description);
                }
                return ret;
            }
            private set { }
        }
        public string SockPart
        {
            get
            {
                return knitRows[CurrentRow].partName;
            }
            private set
            { }
        }
        public Parts Part
        {
            get

            {
                if (CurrentRow == 0)
                    return Parts.Zero;
                else
                    return knitRows[CurrentRow].part;
            }
            private set
            { }
        }
        protected void setKnitRowsDescription()
        {
            knitRows = new List<OneRow>();
            OneRow first = new OneRow();
            first.part = Parts.Mangeta;
            first.partName = "Манжета. Вяжем по кругу на 4 спицах";
            first.Stitch = counted4NeedleStitch;
            first.Description = "Набрать на спицы " + counted4NeedleStitch.ToString() + " петель. Распределить поровну по " + (counted4NeedleStitch / 4).ToString() + " на спицу.";
            knitRows.Add(first);
            foreach (int stitch in _mangeta)
            {
                OneRow ooneRow = new OneRow();
                ooneRow.part = Parts.Mangeta;
                ooneRow.partName = "Манжета. Вяжем по кругу на 4 спицах";
                ooneRow.Stitch = stitch;
                ooneRow.Description = "Вязать резинкой " + ooneRow.Stitch.ToString() + " петель: *1 лиц, 1 изн. повторять от*";
                knitRows.Add(ooneRow);
            }
            int s = _top.Count / 4;
            int a = 0;
            foreach (int stitch in _top)
            {
                OneRow ooneRow = new OneRow();
                if (a < s)
                    ooneRow.part = Parts.Top1;
                else if (a < 2 * s)
                    ooneRow.part = Parts.Top2;
                else if (a < 3 * s)
                    ooneRow.part = Parts.Top3;
                else
                    ooneRow.part = Parts.Top4;

                ooneRow.partName = "Верх носка. Вяжем по кругу на 4 спицах";
                ooneRow.Stitch = stitch;
                ooneRow.Description = "Вязать лицевыми " + ooneRow.Stitch.ToString() + " петель.";
                knitRows.Add(ooneRow);
                a++;
            }
            int i = 0;
            foreach (int stitch in _heel)
            {
                OneRow ooneRow = new OneRow();
                if (i < _heel.Count / 2)
                    ooneRow.part = Parts.Heel1;
                else
                    ooneRow.part = Parts.Heel3;
                i++;
                ooneRow.partName = "Пятка. Вяжем на 2 спицах в прямом и обратном направлении";
                ooneRow.Stitch = stitch;
                if (stitch == counted4NeedleStitch)
                {
                    ooneRow.Description = "Вязать ряд на всех петлях на всех спицах по кругу";
                    ooneRow.part = Parts.Heel2;
                }
                else if (stitch == counted4NeedleStitch / 2)
                    ooneRow.Description = "Пятку вяжем на 2 спицах в прямом и обратном направлении. Все петли провязать лицевыми. Всего " + ooneRow.Stitch.ToString() + " петель.";
                else
                   if ((stitch % 2) == 0)
                {
                    ooneRow.Description = "Выполнить двойную кромочную, для этого рабочую нить проложить перед работой, 1-ю петлю снять, как при изнаночном вязании и нить оттянуть назад. Таким образом двойная петля будет на правой спице. Нить вновь проложить за работой и остальные петли вязать лицевыми. Всего " + ooneRow.Stitch.ToString() + " петель.";

                }
                else
                {
                    ooneRow.Description = "Выполнить двойную кромочную, для этого рабочую нить проложить перед работой, 1-ю петлю снять, как при изнаночном вязании и нить оттянуть назад. Таким образом двойная петля будет на правой спице. Нить вновь проложить перед работой и остальные петли вязать изнаночными. Всего " + ooneRow.Stitch.ToString() + " петель.";

                }
                knitRows.Add(ooneRow);
            }
            int m = _mainPart.Count / 4;
            i = 0;
            foreach (int stitch in _mainPart)
            {
                OneRow ooneRow = new OneRow();
                if (i < m)
                    ooneRow.part = Parts.MainPart1;
                else if (i < 2 * m)
                    ooneRow.part = Parts.MainPart2;
                else if (i < 3 * m)
                    ooneRow.part = Parts.MainPart3;
                else if (i < 4 * m)
                    ooneRow.part = Parts.MainPart4;
                else
                    ooneRow.part = Parts.MainPart5;
                ooneRow.partName = "Основная часть. Вяжем по кругу на 4 спицах";
                ooneRow.Stitch = stitch;
                ooneRow.Description = "Вязать лицевыми " + ooneRow.Stitch.ToString() + " петель.";
                knitRows.Add(ooneRow);
                i++;
            }
            int predToe = counted4NeedleStitch;
            i = 0;
            foreach (int stitch in _toe)
            {
                OneRow ooneRow = new OneRow();
                ooneRow.part = Parts.Toe;
                ooneRow.partName = "Мысок. Вяжем по кругу на 4 спицах";
                ooneRow.Stitch = stitch;
                if (stitch == predToe)
                    ooneRow.Description = "Вязать лицевыми " + ooneRow.Stitch.ToString() + " петель ";
                else
                    ooneRow.Description = "Вязать лицевыми " + ooneRow.Stitch.ToString() + " петель (убавить " + decrease.ToString() + " петель в ряду)";
                predToe = stitch;
                knitRows.Add(ooneRow);
            }
			OneRow ooneRow_end = new OneRow();
			ooneRow_end.part = Parts.Toe;
			ooneRow_end.partName = "Мысок. Вяжем по кругу на 4 спицах";
			ooneRow_end.Stitch = 8;
			ooneRow_end.Description = "Закрыть оставшиеся " + ooneRow_end.Stitch.ToString() + " петель. Нить убрать.";
			knitRows.Add(ooneRow_end);
        }
    }
}

