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
        void AddPlayer(IList<Player> list);
        void ModPlayer(Player playerToModify);
        void DelPlayer(IList<Player> list, Player player);
        IList<Player> GetAllPlayers();
    }
}
