using NBA.WPFApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBA.WPFApp.BL
{
    public interface IPlayerUiLogic
    {
        /// <summary>
        /// Adds new player to the list.
        /// </summary>
        /// <param name="list">list of players in ui.</param>
        void AddPlayer(IList<PlayerUI> list);

        /// <summary>
        /// Modify one player's props.
        /// </summary>
        /// <param name="playerToModify">player in ui to modify.</param>
        void ModPlayer(PlayerUI playerToModify);

        /// <summary>
        /// Deletes one player from the list and from the db as well.
        /// </summary>
        /// <param name="list">list of players in ui.</param>
        /// <param name="player">player in ui to delete.</param>
        void DelPlayer(IList<PlayerUI> list, PlayerUI player);

        /// <summary>
        /// Retruns a list of players in ui.
        /// </summary>
        /// <returns>IList collection.</returns>
        IList<PlayerUI> GetAllPlayers();
    }
}
