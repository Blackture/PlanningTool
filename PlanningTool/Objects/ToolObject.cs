using System;
using System.Collections.Generic;
using System.Text;

namespace PlanningTool.Objects
{
    public class ToolObject
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value ?? throw new NullReferenceException("An object name cannot be null"); }
        }

        public ToolObject(string _name)
        {
            name = _name;
        }

    }
}
