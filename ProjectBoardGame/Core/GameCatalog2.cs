using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Core
{
    public partial class GameCatalog
    {
        public void Sort()
        {
            int index = 0;
            BoardGame[] array = new BoardGame[_catalog.Count];
            for(int i = 0; i < _catalog.Count; i++)
            {
                array[i] = _catalog[i];
            }
            while (index < array.Length)
            {
                if(index==0 || (int)array[index].Name[0] > (int)array[index - 1].Name[0])
                {
                    index++;
                }
                else if((int)array[index].Name[0] == (int)array[index - 1].Name[0])
                {
                    int length = (array[index].Name.Length <= array[index - 1].Name.Length) ? array[index].Name.Length : array[index - 1].Name.Length;
                    if (string.Equals(array[index].Name, array[index - 1].Name, StringComparison.OrdinalIgnoreCase))
                    {
                        index++;
                    }
                    else
                    {
                        bool check = false;
                        for (int i = 0; i < length; i++)
                        {
                            if (!((int)array[index].Name[i] >= (int)array[index - 1].Name[i]))
                            {
                                check = true;
                                break;
                            }
                        }
                        if (check)
                        {
                            BoardGame tmp = array[index];
                            array[index] = array[index - 1];
                            array[index - 1] = tmp;
                        }
                        index++;
                    }
                }
                else
                {
                    BoardGame tmp = array[index];
                    array[index] = array[index - 1];
                    array[index - 1] = tmp;
                    index--;
                }
            }
            _catalog = new List<BoardGame>();
            Add(array);
        }
    }
}
