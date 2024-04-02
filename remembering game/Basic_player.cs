using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace remembering_game
{
    abstract class Basic_player
    {
        #region fields
        public int Score { get; set; }
        public string Name { get;private set; }
        #endregion
        #region methods
        public Basic_player(string name)
        {
            this.Name = name;
        }
        #endregion
    }
}
