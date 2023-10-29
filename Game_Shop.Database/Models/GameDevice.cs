using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Shop.Database.Models
{
    public class GameDevice
    {
        public int GameId { get; set; }
        public byte DeviceId { get; set; }

        ///Nav. Properties
        public virtual Game Game { get; set; }
        public virtual Device Device { get; set; }

    }
}
