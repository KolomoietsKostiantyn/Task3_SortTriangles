using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3_SortTriangles.IntermediatLvl;

namespace Task3_SortTriangles.UInterfase
{
    class UI : IUI
    {
        public UI()
        { 
            
        }


        public string[] InitialDate
        {
            set 
            {
                if (_innDate == null)
                {
                    _innDate = value;
                }
            }
        }

        string[] _innDate = null;



        private void ShowRules()
        {
            string rules = "add a triangle in the format <name>, <side length>, <side length>, <side length> "
                                + "if you use floating-point numbers write them through '.'";
            Console.WriteLine(rules);
        
        }


        private string ConvertArrToString(string[] _innDate)
        {
            string result = "";
                for (int i = 0; i < _innDate.Length; i++)
                {
                    if (i == _innDate.Length - 1)
                    {
                        result += _innDate[i];
                    }
                    else
                    {
                        result += _innDate[i] + ",";
                    }
                }
                return result;
        }


        public void Start()
        {
            if (_dataSender == null )
            {
                throw new ArgumentNullException("_dataSender");
            }
            if (_startAgain == null )
            {
                throw new ArgumentNullException("_startAgain");
            }
            if ( _askForSortedList == null)
            {
                throw new ArgumentNullException("_askForSortedList");
            }




            if (_innDate == null)
            {
                ShowRules();
                Console.ReadKey();
            }
            else 
            {
                _dataSender(ConvertArrToString(_innDate));
            }

            do
            {       
                //add triangls
                do
                {
                    Console.Clear();
                    string trToAdd;
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("add triangl in format <name>, <side length>, <side length>, <side length>");
                        trToAdd = Console.ReadLine();
                    } while (!_dataSender(trToAdd));

                } while (continuationRequest());

                List<TrianglILvl> sortedList = _askForSortedList();
                Console.Clear();
                string title = "============= Triangles list: ===============";
                Console.WriteLine(title);
                string trianglInfo = "{0}. [Triangle {1}]: {2} cm";
                for (int i = 0; i < sortedList.Count; i++)
                {
                    string masage = string.Format(trianglInfo, i + 1, sortedList[i].Name, sortedList[i].Square);
                    Console.WriteLine(masage);
                }
                
                _startAgain();
            } while (continuationRequest());

        }

        private bool continuationRequest()
        {
            bool result = false;
            Console.WriteLine("Continue?");
            string continuationRequest = Console.ReadLine();
            continuationRequest = continuationRequest.ToLower();
            if (continuationRequest == "y" || continuationRequest == "yes")
            {
                result = true;
            }

            return result;
        }










        public event DataSender DataSenderDesc
        {
            add
            {
                _dataSender += value;
            }
            remove
            {
                _dataSender -= value;
            }
        }

        DataSender _dataSender;


        public event AskForSortedList AskForSortedListDesc
        {
            add 
            {
                _askForSortedList += value;
            }
            remove 
            {
                _askForSortedList -= value;
            }
        }

        AskForSortedList _askForSortedList;
        public event StartAgain StartAgainDesc
        {
            add 
            {
                _startAgain += value;
            }
            remove 
            {
                _startAgain -= value;
            }
        }

        StartAgain _startAgain;

    }
}
