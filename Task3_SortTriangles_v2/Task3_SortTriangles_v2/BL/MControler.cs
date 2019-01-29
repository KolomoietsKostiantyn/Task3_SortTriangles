﻿using System;
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

        public MControler(IVisualizer visualizator, IFactoryBLInitializer factoryBLInitializer, string[] arr)
        {
            _visualizator = visualizator;
            _storage = factoryBLInitializer.CreateStorage();
            _innerDataParser = factoryBLInitializer.CreateInnerDataParser();
            _converterTrianglToTrianglUI = factoryBLInitializer.CreateConverterTrianglToTrianglUI();
            _arr = arr;
        }


        public void Start()
        {
            string innerData = string.Empty;
            if (_innerDataParser.ValidateInputArray(_arr))
            {
                innerData = _innerDataParser.ConvertToCorrectStringWithoutSeparators(_arr);
            }
            else
            {
                _visualizator.ReturnMessage(ExecutionResult.Instruction);
            }
            
            TryAddTriangl(innerData);
            do
            {
                string data = _visualizator.AskForData();
                TryAddTriangl(data);
            } while (_visualizator.ContinueRequest());
            _visualizator.ReturnAnsver(_converterTrianglToTrianglUI.ConvertTriangls(_storage.GetReversSortedList()));
        }

        protected bool TryAddTriangl(string toAdd)
        {
            try
            {
                toAdd = _innerDataParser.ConvertToCorrectStringWithoutSeparatorsString(toAdd);
            }
            catch (ArgumentException)
            {
                _visualizator.ReturnMessage(ExecutionResult.IncorectData);
                return false;
            }
            string name;
            double side1;
            double side2;
            double side3;
            bool result = false;
            if (_innerDataParser.SplitStringToValidateParams(toAdd, out name, out side1, out side2, out side3))
            {
                if (_storage.AddTriangl(name, side1, side2, side3))
                {
                    _visualizator.ReturnMessage(ExecutionResult.TriangleAdded);
                    result = true;
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

            return result;
        }
    }
}
