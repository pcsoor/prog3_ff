﻿using NBA.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace NBA.Logic
{
    public interface ITeamLogic
    {
        IList<Teams> GetAllTeams();
    }
}
