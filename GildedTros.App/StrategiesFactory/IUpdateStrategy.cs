using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedTros.App.StrategiesFactory
{
    public interface IUpdateStrategy
    {
        void Update(Item item);
    }
}
