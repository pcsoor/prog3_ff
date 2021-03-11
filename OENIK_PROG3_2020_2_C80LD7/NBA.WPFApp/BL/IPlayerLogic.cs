namespace NBA.WPFApp.BL
{
    using NBA.WPFApp.Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    interface IPlayerLogic
    {
        void AddPlayer(IList<PlayerUI> list);
        void ModPlayer(PlayerUI playerToModify);
        // void DelPlayer(IList<PlayerUI> list, PlayerUI player);
        IList<PlayerUI> GetAllPlayers();
    }
}
