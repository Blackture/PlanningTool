using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace PlanningTool.Objects
{
    [Serializable]
    public class Stat : ToolObject
    {
        private string statName;

        public string StatName
        {
            get { return statName; }
            set
            {
                statName = value ?? throw new NullReferenceException("this cannot be null");
                Name = value;
            }
        }

        private string operationStr;

        public string OperationStr
        {
            get { return operationStr; }
            set { operationStr = value ?? throw new NullReferenceException("This is not be allowed to be null. Use an empty string for no specific operation"); }
        }

        private float value;

        public float Value
        {
            get { return value; }
            set { this.value = value; }
        }

        public Stat(string _name, string _operation, float _value = 0) : base(_name) //_operation needs to be sth like "a + 3" (starts of with "a" and ends with "z", excpet "e" because it is the number of euler, use "~" to insert to current value)
        {
            if (_name == null || _name == "")
                throw new Exception("The name cannot be null or empty");
            statName = _name;
            operationStr = _operation ?? throw new NullReferenceException("This is not be allowed to be null. Use an empty string for no specific operation");
            value = _value;
        }

        public void Calculate(float input)
        {
            if (operationStr == "") value = input;
            else
            {
                string math = operationStr.Replace("a", input.ToString());
                math = math.Replace("~", value.ToString());
                object val = new DataTable().Compute(math, null);
                if (val != DBNull.Value)
                {
                    value = (float)val;
                }
                else throw new Exception("Sorry something in your calculation failed");
            }
        }

        public void Calculate(float[] input)
        {
            if (operationStr == "") throw new Exception("Empty operation string with array input is not allowed");
            else
            {
                if (input.Length > 26 || input.Length <= 0)
                    throw new Exception("Input float array length cannot be greater than 25 and not less than or equal to 0");
                string math = operationStr;
                for (int i = 0; i < input.Length; i++)
                {
                    math = math.Replace(indexedABC[i], input[i].ToString());
                }
                math = math.Replace("~", value.ToString());
                object val = new DataTable().Compute(math, null);
                if (val != DBNull.Value)
                {
                    value = (float)val;
                }
                else throw new Exception("Sorry something in your calculation failed");
            }
        }

        static readonly string[] indexedABC = new string[]
        {
            "a",
            "b",
            "c",
            "d",
            "f",
            "g",
            "h",
            "i",
            "j",
            "k",
            "l",
            "m",
            "n",
            "o",
            "p",
            "q",
            "r",
            "s",
            "t",
            "u",
            "v",
            "w",
            "x",
            "y",
            "z"
        };
    }
}
