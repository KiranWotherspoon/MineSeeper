using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper
{
    class block
    {
        public int x, y, size, nextTo;
        public bool bomb, revealed, flag;

        public block(int _x, int _y, int _size, int _nextTo, bool _bomb, bool _revealed, bool _flag)
        {
            x = _x;
            y = _y;
            size = _size;
            nextTo = _nextTo;
            bomb = _bomb;
            revealed = _revealed;
            flag = _flag;
        }

        public void Reveal(int index, List<block> blocks)
        {
            //if the block isn't revealed, reveal it
            if (revealed == false)
            {
                revealed = true;
            }

            //if the block has no bombs next to it (and isn't a bomb itself), reveal all the blocks around it HOWEVER, don't reveal blocks that are flagged
            if (nextTo == 0 && bomb == false)
            {
                if (index > GameScreen.rowLength)
                {
                    if (index % GameScreen.rowLength != 0)
                    {
                        if (blocks[index - GameScreen.rowLength - 1].flag == false) { blocks[index - GameScreen.rowLength - 1].revealed = true; }
                    }
                    if (blocks[index - GameScreen.rowLength].flag == false) { blocks[index - GameScreen.rowLength].revealed = true; }
                    if ((index + 1) % GameScreen.rowLength != 0)
                    {
                        if (blocks[index - GameScreen.rowLength + 1].flag == false) { blocks[index - GameScreen.rowLength + 1].revealed = true; }
                    }
                }
                if (index % GameScreen.rowLength != 0)
                {
                    if (blocks[index - 1].flag == false) { blocks[index - 1].revealed = true; }
                }
                if ((index + 1) % GameScreen.rowLength != 0)
                {
                    if (blocks[index + 1].flag == false) { blocks[index + 1].revealed = true; }
                }
                if (index < blocks.Count - GameScreen.rowLength)
                {
                    if (index % GameScreen.rowLength != 0)
                    {
                        if (blocks[index + GameScreen.rowLength - 1].flag == false) { blocks[index + GameScreen.rowLength - 1].revealed = true; }
                    }
                    if (blocks[index + GameScreen.rowLength].flag == false) { blocks[index + GameScreen.rowLength].revealed = true; }
                    if ((index + 1) % GameScreen.rowLength != 0)
                    {
                        if (blocks[index + GameScreen.rowLength + 1].flag == false) { blocks[index + GameScreen.rowLength + 1].revealed = true; }
                    }
                }
            }
        }
    }
}
