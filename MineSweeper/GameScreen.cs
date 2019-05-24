﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace MineSweeper
{
    public partial class GameScreen : UserControl
    {
        #region Global Values
        bool gameLose, firstClick;

        int bombNumber, bombsLeft;
        public static int blockSize, rowLength, border;

        List<block> blocks = new List<block>();

        Stopwatch gameWatch = new Stopwatch();

        SolidBrush drawBrush = new SolidBrush(Color.White);
        Pen drawPen = new Pen(Color.Red);

        Font titleFont = new Font("Arial", 32);

        selector gameSelector = new selector(0);
        Point restartBlock;

        Random rng = new Random();
        #endregion

        public GameScreen()
        {
            InitializeComponent();

            switch (Form1.difficulty)
            {
                case "easy":
                    EasyStart();
                    break;
                case "medium":
                    MediumStart();
                    break;
                case "hard":
                    HardStart();
                    break;
            }
        }

        #region Start Functions
        private void EasyStart()
        {
            blockSize = 50;
            rowLength = 9;
            bombNumber = bombsLeft = 16;
            border = (this.Width - (rowLength * blockSize)) / 2;

            restartBlock = new Point((this.Width - 2 * border) / 2 + 15, ((this.Height - 2 * border) - (blockSize * rowLength)) / 2 + 15);

            CreateBlocks(blockSize, rowLength);

            firstClick = true;
        }

        private void MediumStart()
        {
            blockSize = 30;
            rowLength = 16;
            bombNumber = bombsLeft = 40;
            border = (this.Width - (rowLength * blockSize)) / 2;

            restartBlock = new Point((this.Width - 2 * border) / 2 + 15, ((this.Height - 2 * border) - (blockSize * rowLength)) / 2);

            CreateBlocks(blockSize, rowLength);
            
            firstClick = true;
        }

        public void HardStart()
        {
            blockSize = 20;
            rowLength = 24;
            bombNumber = bombsLeft = 99;
            border = (this.Width - (rowLength * blockSize)) / 2;

            restartBlock = new Point((this.Width - 2 * border) / 2 + 15, ((this.Height - 2 * border) - (blockSize * rowLength)) / 2);

            CreateBlocks(blockSize, rowLength);
           
            firstClick = true;
        }
        #endregion

        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //pause screen function
            if (e.KeyCode == Keys.Escape)
            {

                DialogResult result = PauseForm.Show();

                if (result == DialogResult.Cancel)
                {
                }
                else if (result == DialogResult.Abort)
                {
                    MenuScreen ms = new MenuScreen();
                    Form1.ChangeScreen(this, ms);
                }
            }

            switch (e.KeyCode)
            {
                case Keys.Right:
                    gameSelector.Move("right", blocks);
                    Refresh();
                    break;
                case Keys.Left:
                    gameSelector.Move("left", blocks);
                    Refresh();
                    break;
                case Keys.Up:
                    gameSelector.Move("up", blocks);
                    Refresh();
                    break;
                case Keys.Down:
                    gameSelector.Move("down", blocks);
                    Refresh();
                    break;
                case Keys.Enter:
                    if (gameSelector.index == -1)
                    {
                        gameLose = false;
                        blocks.Clear();
                        CreateBlocks(blockSize, rowLength);
                        firstClick = true;
                    }
                    else if (firstClick)
                    {
                        firstClick = false;
                        CreateBombs(bombNumber, gameSelector.index);
                        CreateNextTo();
                        blocks[gameSelector.index].Reveal(gameSelector.index, blocks);
                    }
                    else if (blocks[gameSelector.index].bomb)
                    {
                        gameLose = true;
                        blocks[gameSelector.index].revealed = true;
                    }
                    else if (blocks[gameSelector.index].flag == false)
                    {
                        blocks[gameSelector.index].Reveal(gameSelector.index, blocks);
                        bool winGame = true;
                        foreach (block b in blocks)
                        {
                            if (b.bomb == false && b.revealed == false)
                            {
                                winGame = false;
                            }
                        }
                        if (winGame) {  }
                    }
                    Refresh();
                    break;
                case Keys.Space:
                    if (blocks[gameSelector.index].revealed == false && blocks[gameSelector.index].flag)
                    {
                        blocks[gameSelector.index].flag = false;
                        bombsLeft++;
                    }
                    else if (blocks[gameSelector.index].revealed == false && blocks[gameSelector.index].flag == false)
                    {
                        blocks[gameSelector.index].flag = true;
                        bombsLeft--;
                    }
                    Refresh();
                    break;
            }
        }

        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Right:
                    break;
                case Keys.Left:
                    break;
                case Keys.Up:
                    break;
                case Keys.Down:
                    break;
                case Keys.Enter:
                    break;
                case Keys.Space:
                    break;
            }
        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            #region border drawing
            e.Graphics.DrawImage(Properties.Resources.border, 0, 0, border, this.Height);
            e.Graphics.DrawImage(Properties.Resources.borderHorizontal, 0, 0, this.Width, border);
            e.Graphics.DrawImage(Properties.Resources.border, this.Width - border, 0, border, this.Height);
            e.Graphics.DrawImage(Properties.Resources.borderHorizontal, 0, this.Height - border, this.Width, border);
            e.Graphics.DrawImage(Properties.Resources.borderCornerTL, 0, 0, border, border);
            e.Graphics.DrawImage(Properties.Resources.borderCornerTR, this.Width - border, 0, border, border);
            e.Graphics.DrawImage(Properties.Resources.borderCornerBR, this.Width - border, this.Height - border, border, border);
            e.Graphics.DrawImage(Properties.Resources.borderCorner, 0, this.Height - border, border, border);
            #endregion

            foreach (block b in blocks)
            {
                if (b.bomb && b.revealed) { e.Graphics.DrawImage(Properties.Resources.revealedBomb, b.x, b.y, b.size, b.size); }
                else if (gameLose && b.bomb && b.flag) { e.Graphics.DrawImage(Properties.Resources.flagBlock, b.x, b.y, b.size, b.size); }
                else if (gameLose && b.flag && b.bomb == false) { e.Graphics.DrawImage(Properties.Resources.falseBomb, b.x, b.y, b.size, b.size); }
                else if (gameLose && b.bomb) { e.Graphics.DrawImage(Properties.Resources.bombBlock, b.x, b.y, b.size, b.size); }
                else if (b.flag) { e.Graphics.DrawImage(Properties.Resources.flagBlock, b.x, b.y, b.size, b.size); }
                else if (b.revealed)
                {
                    switch (b.nextTo)
                    {
                        case 0:
                            e.Graphics.DrawImage(Properties.Resources.blankBlock, b.x, b.y, b.size, b.size);
                            break;
                        case 1:
                            e.Graphics.DrawImage(Properties.Resources.oneBlock, b.x, b.y, b.size, b.size);
                            break;
                        case 2:
                            e.Graphics.DrawImage(Properties.Resources.twoBlock, b.x, b.y, b.size, b.size);
                            break;
                        case 3:
                            e.Graphics.DrawImage(Properties.Resources.threeBlock, b.x, b.y, b.size, b.size);
                            break;
                        case 4:
                            e.Graphics.DrawImage(Properties.Resources.fourBlock, b.x, b.y, b.size, b.size);
                            break;
                        case 5:
                            e.Graphics.DrawImage(Properties.Resources.fiveBlock, b.x, b.y, b.size, b.size);
                            break;
                        case 6:
                            e.Graphics.DrawImage(Properties.Resources.sixBlock, b.x, b.y, b.size, b.size);
                            break;
                        case 7:
                            e.Graphics.DrawImage(Properties.Resources.sevenBlock, b.x, b.y, b.size, b.size);
                            break;
                        case 8:
                            e.Graphics.DrawImage(Properties.Resources.eightBlock, b.x, b.y, b.size, b.size);
                            break;
                        default:
                            break;
                    }
                }
                else if (b.revealed == false) { e.Graphics.DrawImage(Properties.Resources.block, b.x, b.y, b.size, b.size); }
            }

            e.Graphics.DrawImage(Properties.Resources.restartButton, restartBlock.X, restartBlock.Y, 30, 30);
            //e.Graphics.DrawString();

            if (gameLose || gameSelector.index == -1) { e.Graphics.DrawRectangle(drawPen, restartBlock.X, restartBlock.Y, 30, 30); gameSelector.index = -1; }
            else { e.Graphics.DrawRectangle(drawPen, blocks[gameSelector.index].x, blocks[gameSelector.index].y, blocks[gameSelector.index].size, blocks[gameSelector.index].size); }
        }

        #region Block Setup
        private void CreateBlocks(int size, int length)
        {
            for (int y = 0; y < length; y++)
            {
                for (int x = 0; x < length; x++)
                {
                    block b = new block(border + (size * x), 40 + border + (size * y), size, 0, false, false, false);
                    blocks.Add(b);
                }
            }
        }

        private void CreateBombs(int number, int startBlock)
        {
            //create the number of bombs specified
            for (int i = 0; i < number; i++)
            {
                //choose the bombs randomly
                int index = rng.Next(0, blocks.Count);

                bool validIndex = false;

                //make sure that the random number generator does not create the same number twice
                while (blocks[index].bomb || validIndex == false)
                {
                    validIndex = true;
                    index = rng.Next(0, blocks.Count);

                    if (startBlock > rowLength)
                    {
                        if (startBlock % rowLength != 0)
                        {
                            if (index == startBlock - rowLength - 1) { validIndex = false; }
                        }
                        if (index == startBlock - rowLength) { validIndex = false; }
                        if ((startBlock + 1) % rowLength != 0)
                        {
                            if (index == startBlock - rowLength + 1) { validIndex = false; }
                        }
                    }
                    if (startBlock % rowLength != 0)
                    {
                        if (index == startBlock - 1) { validIndex = false; }
                    }
                    if ((startBlock + 1) % rowLength != 0)
                    {
                        if (index == startBlock + 1) { validIndex = false; }
                    }
                    if (startBlock < blocks.Count - rowLength)
                    {
                        if (startBlock % rowLength != 0)
                        {
                            if (index == startBlock + rowLength - 1) { validIndex = false; }
                        }
                        if (index == startBlock + rowLength) { validIndex = false; }
                        if ((startBlock + 1) % rowLength != 0)
                        {
                            if (index == startBlock + rowLength + 1) { validIndex = false; }
                        }
                    }
                }

                //turn the block into a bomb
                blocks[index].bomb = true;
            }
        }

        private void CreateNextTo()
        {
            //find out how many bombs each block is beside while following the grid pattern
            for (int i = 0; i < blocks.Count; i++)
            {
                if (blocks[i].bomb == false)
                {
                    if (i > rowLength)
                    {
                        if (i % rowLength != 0)
                        {
                            if (blocks[i - rowLength - 1].bomb) { blocks[i].nextTo++; }
                        }
                        if (blocks[i - rowLength].bomb) { blocks[i].nextTo++; }
                        if ((i + 1) % rowLength != 0)
                        {
                            if (blocks[i - rowLength + 1].bomb) { blocks[i].nextTo++; }
                        }
                    }
                    if (i % rowLength != 0)
                    {
                        if (blocks[i - 1].bomb) { blocks[i].nextTo++; }
                    }
                    if ((i + 1) % rowLength != 0)
                    {
                        if (blocks[i + 1].bomb) { blocks[i].nextTo++; }
                    }
                    if (i < blocks.Count - rowLength)
                    {
                        if (i % rowLength != 0)
                        {
                            if (blocks[i + rowLength - 1].bomb) { blocks[i].nextTo++; }
                        }
                        if (blocks[i + rowLength].bomb) { blocks[i].nextTo++; }
                        if ((i + 1) % rowLength != 0)
                        {
                            if (blocks[i + rowLength + 1].bomb) { blocks[i].nextTo++; }
                        }
                    }
                }
            }
        }
        #endregion

        private void GameWin ()
        {
            MenuScreen ms = new MenuScreen();
            Form1.ChangeScreen(this, ms);
        }
    }
}