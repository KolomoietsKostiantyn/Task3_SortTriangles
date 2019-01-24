using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3_SortTriangles_v2.Intermediate;

namespace Task3_SortTriangles_v2.BL
{
    public class MControler
    {
        private IVisualizer _visualizator;
        private ITrianglStorage _storage;
        private string[] _arr;
        private IInnerDataParser _innerDataParser;
        private IConverterTrianglToTrianglUI _converterTrianglToTrianglUI;

        public MControler(IFactoryBLInitializer BLInitializer, IVisualizer visualizator, string[] arr)
        {
            _visualizator = visualizator;
            _storage = BLInitializer.CreateStorage();
            _innerDataParser = BLInitializer.CreateParser();
            _converterTrianglToTrianglUI = BLInitializer.CreateTrianglConverter();
            _arr = arr;
        }


        public void Start()
        {
            string innerData = string.Empty;
            try
            {
                _innerDataParser.ValidateInputArray(_arr, 4);
                innerData = _innerDataParser.DeleteSeparatorsFromArr(_arr, 4);
            }
            catch (Exception)
            {
                _visualizator.ReturnMessage(ExecutionResult.Instruction);
            }
            TryAddTriangl(innerData, _innerDataParser);
            do
            {
                string data = _visualizator.AskForData();
                TryAddTriangl(data,_innerDataParser);
            } while (_visualizator.ContinueRequest());
            _visualizator.ReturnAnsver(_converterTrianglToTrianglUI.ConvertTriangls(_storage.GetReversSortedList()));
        }

        protected void TryAddTriangl(string toAdd, IInnerDataParser innerDataParser)
        {
            string name;
            double side1;
            double side2;
            double side3;
            if (innerDataParser.SplitStringToValidateParams(toAdd, out name, out side1, out side2, out side3))
            {
                if (_storage.addTriangl(name, side1, side2, side3))
                {
                    _visualizator.ReturnMessage(ExecutionResult.TriangleAdded);
                }
                else
                {
                    _visualizator.ReturnMessage(ExecutionResult.IncorectData);
                }
            }
            else
            {
                _visualizator.ReturnMessage(ExecutionResult.IncorectData);
            }
        }
    }
}
