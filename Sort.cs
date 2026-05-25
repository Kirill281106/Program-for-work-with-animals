using System;
using System.Collections.Generic;

namespace ООП_курсач_новый
{
    internal class SortByNumber : IComparer<Animal>
    {
        public int Compare(Animal an1, Animal an2)
        {
            if (an1 == null && an2 == null)
                return 0;
            if (an1 == null)
                return -1;
            if (an2 == null)
                return 1;
            
            if (an1.Number < an2.Number)
                return -1;
            if (an1.Number > an2.Number)
                return 1;
            return 0;
        }
    }

    internal class SortByView : IComparer<Animal>
    {
        public int Compare(Animal an1, Animal an2)
        {
            if (an1 == null && an2 == null)
                return 0;
            if (an1 == null)
                return -1;
            if (an2 == null)
                return 1;
            
            return CompareStrings(an1.View, an2.View);
        }

        private int CompareStrings(string view1, string view2)
        {
            if (view1 == null && view2 == null)
                return 0;
            if (view1 == null)
                return -1;
            if (view2 == null)
                return 1;
            
            int minLength = view1.Length;
            if (view2.Length < minLength)
                minLength = view2.Length;
            
            for (int i = 0; i < minLength; i++)
            {
                if (view1[i] < view2[i])
                    return -1;
                if (view1[i] > view2[i])
                    return 1;
            }
            
            if (view1.Length < view2.Length)
                return -1;
            if (view1.Length > view2.Length)
                return 1;
            return 0;
        }
    }

    internal class SortByNextGraft : IComparer<Animal>
    {
        public int Compare(Animal an1, Animal an2)
        {
            if (an1 == null && an2 == null)
                return 0;
            if (an1 == null)
                return -1;
            if (an2 == null)
                return 1;
            
            DateTime date1 = an1.NextGraft;
            DateTime date2 = an2.NextGraft;
            
            if (date1 < date2)
                return -1;
            if (date1 > date2)
                return 1;
            return 0;
        }
    }
}