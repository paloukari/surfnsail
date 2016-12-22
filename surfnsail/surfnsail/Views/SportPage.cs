using surfnsail.Views.CommonPages;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using Xamarin.Forms;
using surfnsail.Code;

namespace surfnsail.Views
{
    public abstract class SportPage : TabbedPage
    {
        public static List<SportPage> _pages;
        static SportPage()
        {
            _pages = new List<SportPage>();
            var types = FindAllDerivedTypes();
            foreach (var type in types)
                _pages.Add(Activator.CreateInstance(type) as SportPage);
        }

        Dictionary<CommonPageType, Page> _commonPages;
        public SportPage()
        {
            //_commonPages = new Dictionary<CommonPageType, Page>();
            Children.Add(new TodayPage());
            Children.Add(new PlaningPage());
            Children.Add(new TrackingPage());
            Children.Add(new MonitoringPage());
            Children.Add(new HistoryPage());
            Children.Add(new StartPage());
        }


        private int GetSportID()
        {
            var dnAttribute = GetType()
                .GetCustomAttributes(typeof(SportAttribute), true)
                .FirstOrDefault() as SportAttribute;
            if (dnAttribute != null)
                return dnAttribute.SportID;
            return -1;
        }
        private static List<Type> FindAllDerivedTypes()
        {
            var derivesFrom = typeof(SportPage);
            return Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => t != derivesFrom && derivesFrom.IsAssignableFrom(t))
                .ToList();

        }
        public static SportPage GetPage(int sportID)
        {
            return _pages.SingleOrDefault(e => e.GetSportID() == sportID);
        }
    }
}