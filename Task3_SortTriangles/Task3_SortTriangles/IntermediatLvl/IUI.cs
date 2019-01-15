using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3_SortTriangles.IntermediatLvl
{
    public interface IUI
    {
        event DataSender DataSenderDesc;
        event AskForSortedList AskForSortedListDesc;
        event StartAgain StartAgainDesc;
    }
}
