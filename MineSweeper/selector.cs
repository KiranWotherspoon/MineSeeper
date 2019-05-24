using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper
{
    class selector
    {
        public int index;

        public selector(int _index)
        {
            index = _index;
        }

        public void Move(string direction, List<block> blocks)
        {
            switch (direction)
            {
                case "left":
                    if (index % GameScreen.rowLength != 0 && index != -1) { index--; }
                    break;
                case "right":
                    if ((index + 1) % GameScreen.rowLength != 0 && index != -1) { index++; }
                    break;
                case "down":
                    if (index == -1) { index = 0; }
                    else if (index < blocks.Count - GameScreen.rowLength) { index += GameScreen.rowLength; }
                    break;
                case "up":
                    if (index > GameScreen.rowLength - 1) { index -= GameScreen.rowLength; }
                    else if (index < GameScreen.rowLength) { index = -1; }
                    break;
            }
        }
    }
}
