using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace findDuplicates
{
    class findDuplicates_class
    {
        public findDuplicates_class(List<string> list)
        {
            findDup(list, duplicates, boolDup);
        }
        
        private void findDup(List<string> _list, List<int> _duplicates, List<bool> _boolDup)
        {            
            for(int i = 0; i < _list.Count(); i++)
            {
                int temp = 0;
                for(int j = 0; j < _list.Count(); j++)
                {
                    if(_list[i] == _list[j] && i != j)
                    {
                        temp++;
                    }
                }
                duplicates.Add(temp);
                if(temp == 0)
                {
                    _boolDup.Add(false);
                }
                else
                {
                    _boolDup.Add(true);
                }
            }            
        }

        public List<int> duplicates = new List<int>();
        public List<bool> boolDup = new List<bool>();
    }
}
