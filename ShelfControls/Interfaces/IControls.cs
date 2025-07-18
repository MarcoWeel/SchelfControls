using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShelfControls.Interfaces
{
    public interface IControls
    {
        public Task<bool> TurnOn();
        public Task<bool> TurnOff();
        public Task<bool> ChangeColor(int red, int blue, int green, int white);
    }
}
