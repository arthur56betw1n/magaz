using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace simpleCalc
{
    public static class Helper
    {
        public static ObservableCollection<T> ToObservableCollection<T> (this IEnumerable<T> collection)
        {
            return new ObservableCollection<T>(collection);
        }
    }
}
