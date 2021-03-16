using System;
using System.Collections.Generic;
using System.Text;

namespace PlanningTool.Objects.RolePlay
{
    public class RolePlay : Management
    {
        public Dictionary<string, Character> players;

        public RolePlay(string _name) : base(_name)
        {
            players = new Dictionary<string, Character>();
        }
    }
}
