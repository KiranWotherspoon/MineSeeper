using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper
{
    public class block
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

        //check if the given block has any bombs around it, if it doesn't reveal all of the blocks around it, and then call this method on those revealed blocks
        #region Reveal Block
        public void RevealSurroundings(int index)
        {
            if (nextTo == 0)
            {
                if (index >= GameScreen.rowLength)
                {
                    if (index % GameScreen.rowLength != 0)
                    {
                        if (GameScreen.blocks[index - GameScreen.rowLength - 1].flag == false && GameScreen.blocks[index - GameScreen.rowLength - 1].revealed == false) { GameScreen.blocks[index - GameScreen.rowLength - 1].CheckNextTo(index - GameScreen.rowLength - 1); }
                    }
                    if (GameScreen.blocks[index - GameScreen.rowLength].flag == false && GameScreen.blocks[index - GameScreen.rowLength].revealed == false) { GameScreen.blocks[index - GameScreen.rowLength].CheckNextTo(index - GameScreen.rowLength); }
                    if ((index + 1) % GameScreen.rowLength != 0)
                    {
                        if (GameScreen.blocks[index - GameScreen.rowLength + 1].flag == false && GameScreen.blocks[index - GameScreen.rowLength + 1].revealed == false) { GameScreen.blocks[index - GameScreen.rowLength + 1].CheckNextTo(index - GameScreen.rowLength + 1); }
                    }
                }
                if (index % GameScreen.rowLength != 0 && GameScreen.blocks[index - 1].revealed == false)
                {
                    if (GameScreen.blocks[index - 1].flag == false && GameScreen.blocks[index - 1].revealed == false) { GameScreen.blocks[index - 1].CheckNextTo(index - 1); }
                }
                if ((index + 1) % GameScreen.rowLength != 0 && GameScreen.blocks[index + 1].revealed == false)
                {
                    if (GameScreen.blocks[index + 1].flag == false && GameScreen.blocks[index + 1].revealed == false) { GameScreen.blocks[index + 1].CheckNextTo(index + 1); }
                }
                if (index < GameScreen.blocks.Count - GameScreen.rowLength)
                {
                    if (index % GameScreen.rowLength != 0)
                    {
                        if (GameScreen.blocks[index + GameScreen.rowLength - 1].flag == false && GameScreen.blocks[index + GameScreen.rowLength - 1].revealed == false) { GameScreen.blocks[index + GameScreen.rowLength - 1].CheckNextTo(index + GameScreen.rowLength - 1); }
                    }
                    if (GameScreen.blocks[index + GameScreen.rowLength].flag == false && GameScreen.blocks[index + GameScreen.rowLength].revealed == false) { GameScreen.blocks[index + GameScreen.rowLength].CheckNextTo(index + GameScreen.rowLength); }
                    if ((index + 1) % GameScreen.rowLength != 0)
                    {
                        if (GameScreen.blocks[index + GameScreen.rowLength + 1].flag == false && GameScreen.blocks[index + GameScreen.rowLength + 1].revealed == false) { GameScreen.blocks[index + GameScreen.rowLength + 1].CheckNextTo(index + GameScreen.rowLength + 1); }
                    }
                }
            }
        }

        private void CheckNextTo(int index)
        {
            revealed = true;

            if (nextTo == 0)
            {
                RevealSurroundings(index);
            }
        }
        #endregion
    }
}
