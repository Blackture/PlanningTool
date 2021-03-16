using System;
using System.Collections.Generic;
using System.Text;

namespace PlanningTool
{
    public class Management
    {
        Objects.ToolObject toolObject = null; // main object to plan in (could be everthing typeof ToolObject)

        public Exception CreateRolePlay(string _name)
        {
            try
            {
                toolObject = new Objects.RolePlay.RolePlay(_name);
                //(toolObject as Objects.RolePlay.RolePlay)
            }
            catch (Exception e)
            {
                return e;
            }
            return null;
        }
    }
}
