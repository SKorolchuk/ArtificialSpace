using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MenuList
{
    internal static class Commander
    {
        public static BehaviorFunc Process(string cmd)
        {
            switch (cmd)
            {
                case "LAUNCH":
                    return ((time, batch, game) => { });
                    break;
                case "EXIT":
                    return ((time, batch, game) => { game.Exit(); });
                    break;
                default:
                    break;
            }
            return ((time, batch, game) => { });
        }
    }
}
