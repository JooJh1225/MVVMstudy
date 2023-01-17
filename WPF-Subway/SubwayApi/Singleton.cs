using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Subway.SubwayApi
{
    public class Singleton<T> where T : class, new()
    {
        private static object _obj = new object();
        private static volatile T _instance = null;
        public static T Instance
        {
            get
            {
                if(_instance == null)
                {
                    lock (_obj)
                    {
                        if(_instance == null)
                        {
                            _instance = new T();
                        }
                    }
                }
                return _instance;
            }
        }
    }
}
