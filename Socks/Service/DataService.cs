using System;
using System.Collections.Generic;
using System.Text;
using Socks.Model;

namespace Socks.DataService

{
    public static class DataService
    {

        public static void SaveWomanSockData(WomanSockModel m)
        {
            Save("PlotX", m.PlotX);
            Save("PlotY", m.PlotY);
            Save("CurrentRow", m.CurrentRow);
            Save("CurrentSize", m.CurrentSize);
        }
        public static void SaveMiniWomanSockData(WomanSockModel m)
        {
            Save("PlotX", m.PlotX);
            Save("PlotY", m.PlotY);
            Make("CurrentRow");
            Make("CurrentSize");
        }
        public static WomanSockModel GetSavedWomanSockModelData()
        {
            WomanSockModel m;
            double plotx = GetDouble("PlotX");
            double ploty = GetDouble("PlotY");
            int size = GetInt("CurrentSize");
            int row = GetInt("CurrentRow");
            m = new WomanSockModel(plotx, ploty);
            m.CurrentSize = size;
            m.CurrentRow = row;
            return m;
        }
        private static void Make(string name)
        {
            object a;
            if (!App.Current.Properties.TryGetValue(name, out a))
                App.Current.Properties.Add(name, 0);
        }

        private static void Save(string name, object value)
        {
            object a;
            if (App.Current.Properties.TryGetValue(name, out a))
                App.Current.Properties[name] = value;
            else
                App.Current.Properties.Add(name, value);
        }
        private static object Get(string name)
        {
            object a;
            if (!App.Current.Properties.TryGetValue(name, out a))
                throw new Exception("No saved value  " + name + " !");
            return a;
        }
        private static double GetDouble(string name)
        {
            object a;
            double d;
            if (!App.Current.Properties.TryGetValue(name, out a))
                throw new Exception("No saved value  " + name + " !");

            if (!double.TryParse(a.ToString(), out d))
                throw new Exception("No parsed from double value  " + name + " !");

            return d;
        }
        private static int GetInt(string name)
        {
            object a;
            int d;
            if (!App.Current.Properties.TryGetValue(name, out a))
                throw new Exception("No saved value  " + name + " !");

            if (!int.TryParse(a.ToString(), out d))
                throw new Exception("No parsed from integer value  " + name + " !");

            return d;
        }

        public static void SaveKidSockData(KidSockModel m)
        {
            Save("PlotX_kid", m.PlotX);
            Save("PlotY_kid", m.PlotY);
            Save("CurrentRow_kid", m.CurrentRow);
            Save("CurrentSize_kid", m.CurrentSize);
        }
        public static void SaveMiniKidSockData(KidSockModel m)
        {
            Save("PlotX_kid", m.PlotX);
            Save("PlotY_kid", m.PlotY);
            Make("CurrentRow_kid");
            Make("CurrentSize_kid");
        }
        public static KidSockModel GetSavedKidSockModelData()
        {
            KidSockModel m;
            double plotx = GetDouble("PlotX_kid");
            double ploty = GetDouble("PlotY_kid");
            int size = GetInt("CurrentSize_kid");
            int row = GetInt("CurrentRow_kid");
            m = new KidSockModel(plotx, ploty);
            m.CurrentSize = size;
            m.CurrentRow = row;
            return m;
        }

        public static void SaveYoungerSockData(YoungerSockModel m)
        {
            Save("PlotX_you", m.PlotX);
            Save("PlotY_you", m.PlotY);
            Save("CurrentRow_you", m.CurrentRow);
            Save("CurrentSize_you", m.CurrentSize);
        }
        public static void SaveMiniYoungerSockData(YoungerSockModel m)
        {
            Save("PlotX_you", m.PlotX);
            Save("PlotY_you", m.PlotY);
            Make("CurrentRow_you");
            Make("CurrentSize_you");
        }
        public static YoungerSockModel GetSavedYoungerSockModelData()
        {
            YoungerSockModel m;
            double plotx = GetDouble("PlotX_you");
            double ploty = GetDouble("PlotY_you");
            int size = GetInt("CurrentSize_you");
            int row = GetInt("CurrentRow_you");
            m = new YoungerSockModel(plotx, ploty);
            m.CurrentSize = size;
            m.CurrentRow = row;
            return m;
        }
        public static void SaveManSockData(ManSockModel m)
        {
            Save("PlotX_man", m.PlotX);
            Save("PlotY_man", m.PlotY);
            Save("CurrentRow_man", m.CurrentRow);
            Save("CurrentSize_man", m.CurrentSize);
        }
        public static void SaveMiniManSockData(ManSockModel m)
        {
            Save("PlotX_man", m.PlotX);
            Save("PlotY_man", m.PlotY);
            Make("CurrentRow_man");
            Make("CurrentSize_man");
        }
        public static ManSockModel GetSavedManSockModelData()
        {
            ManSockModel m;
            double plotx = GetDouble("PlotX_man");
            double ploty = GetDouble("PlotY_man");
            int size = GetInt("CurrentSize_man");
            int row = GetInt("CurrentRow_man");
            m = new ManSockModel(plotx, ploty);
            m.CurrentSize = size;
            m.CurrentRow = row;
            return m;
        }
    }
}
