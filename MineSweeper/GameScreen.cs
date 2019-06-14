using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Media;
using System.Threading;

namespace MineSweeper
{
    public partial class GameScreen : UserControl
    {
        #region Global Values
        bool gameWin, firstClick, gameLose;

        int bombNumber, bombsLeft;
        public static int blockSize, rowLength, border, moves, gameTime, score;

        public static List<block> blocks = new List<block>();

        Stopwatch gameWatch = new Stopwatch();

        SolidBrush drawBrush = new SolidBrush(Color.Red);
        Pen drawPen = new Pen(Color.Red, 3);

        Font titleFont = new Font("Arial", 24);

        selector gameSelector = new selector(0);
        Point restartBlock, timerPoint, bombPoint;

        SoundPlayer player = new SoundPlayer(Properties.Resources.wahaha);

        Random rng = new Random();
        #endregion

        public GameScreen()
        {
            InitializeComponent();

            //based on the difficulty change how game is setup
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
            //moves the timer to it's correct position
            timerLabel.Location = timerPoint;
            //resets tracking variables
            moves = 0;
            firstClick = true;
            //creates all the block objects
            CreateBlocks(blockSize, rowLength);
            //start the game timer
            gameTimer.Enabled = true;
        }

        #region Start Functions
        private void EasyStart()
        {
            //sets the values that difer based on game difficulty
            blockSize = 50;
            rowLength = 9;
            bombNumber = bombsLeft = 16;
            border = (this.Width - (rowLength * blockSize)) / 2;
            score = 0;
            gameLose = false;
            gameWin = false;

            //clear the blocks just in case
            blocks.Clear();

            //sets points used in drawing that change based on difficulty
            restartBlock = new Point((this.Width - 2 * border) / 2 + 15, ((this.Height - 2 * border) - (blockSize * rowLength)) / 2 + 15);
            timerPoint = new Point(this.Width - border - 66, border + 3);
            bombPoint = new Point(border + 3, border + 3);
        }
        //same as easy but medium
        private void MediumStart()
        {
            blockSize = 30;
            rowLength = 16;
            bombNumber = bombsLeft = 40;
            border = (this.Width - (rowLength * blockSize)) / 2;
            score = 0;
            gameLose = false;
            gameWin = false;

            //clear the blocks just in case
            blocks.Clear();

            restartBlock = new Point((this.Width - 2 * border) / 2 + 15, ((this.Height - 2 * border) - (blockSize * rowLength)) / 2);
            timerPoint = new Point(this.Width - border - 66, border + 3);
            bombPoint = new Point(border + 3, border + 3);
        }
        //same as medium but hard
        public void HardStart()
        {
            blockSize = 20;
            rowLength = 24;
            bombNumber = bombsLeft = 99;
            border = (this.Width - (rowLength * blockSize)) / 2;
            score = 0;
            gameLose = false;
            gameWin = false;

            //clear the blocks just in case
            blocks.Clear();

            restartBlock = new Point((this.Width - 2 * border) / 2 + 15, ((this.Height - 2 * border) - (blockSize * rowLength)) / 2);
            timerPoint = new Point(this.Width - border - 66, border + 3);
            bombPoint = new Point(border + 3, border + 3);
        }
        #endregion

        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //pause function
            if (e.KeyCode == Keys.Escape)
            {
                gameWatch.Stop();

                DialogResult result = PauseForm.Show();

                if (result == DialogResult.Cancel)
                {
                    gameWatch.Start();
                }
                else if (result == DialogResult.Abort)
                {
                    Form1.ChangeScreen(this, "MenuScreen");
                    this.Dispose();
                }
            }

            switch (e.KeyCode)
            {
                //moves the selector based on inputs
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
                //reveals the selected block
                case Keys.Enter:
                    //resets the game
                    if (gameSelector.index == -1)
                    {
                        gameLose = false;
                        gameWin = false;
                        bombsLeft = bombNumber;
                        blocks.Clear();
                        CreateBlocks(blockSize, rowLength);
                        gameWatch.Reset();
                        moves = 0;
                        score = 0;
                        firstClick = true;
                    }
                    //only happens on the first selection the player makes
                    else if (firstClick)
                    {
                        //starts the timer
                        gameWatch.Start();
                        moves++;
                        //creates all bombs and the next to number
                        CreateBombs(bombNumber, gameSelector.index);
                        CreateNextTo();
                        //reveals the selected block
                        blocks[gameSelector.index].revealed = true;
                        blocks[gameSelector.index].RevealSurroundings(gameSelector.index);
                        //ensures this function doesn't happen again this game
                        firstClick = false;
                    }
                    //when the player reveals a bomb
                    else if (blocks[gameSelector.index].bomb)
                    {
                        //play the death sound effect, stop the timer, set the game loss variable to true
                        player.Play();
                        gameLose = true;
                        gameWatch.Stop();
                        moves++;
                        //reveal the selected block
                        blocks[gameSelector.index].revealed = true;
                    }
                    //when the player reveals a block, they can't reveal a flagged block
                    else if (blocks[gameSelector.index].flag == false)
                    {
                        //reveal the block
                        blocks[gameSelector.index].revealed = true;
                        blocks[gameSelector.index].RevealSurroundings(gameSelector.index);
                        moves++;
                        //check to see if all the blocks that aren't bombs are revealed
                        bool winGame = true;
                        foreach (block b in blocks)
                        {
                            if (b.bomb == false && b.revealed == false)
                            {
                                winGame = false;
                            }
                        }
                        //if they are the player wins the game
                        if (winGame)
                        {
                            gameWin = true;
                            Refresh();
                            WinGame();
                        }
                    }
                    //redraw the screen
                    Refresh();
                    break;
                case Keys.Space:
                    //do nothing if this is the first selection of the game
                    if (firstClick) { }
                    //if the player selects an already flagged block
                    else if (blocks[gameSelector.index].revealed == false && blocks[gameSelector.index].flag)
                    {
                        //unflag the block and increase the displayed number of bombs left
                        blocks[gameSelector.index].flag = false;
                        bombsLeft++;
                    }
                    //if the player selects a block that isn't flaged or revealed
                    else if (blocks[gameSelector.index].revealed == false && blocks[gameSelector.index].flag == false)
                    {
                        //flag the block and decrease the displayed number of bombs left
                        blocks[gameSelector.index].flag = true;
                        bombsLeft--;
                    }
                    //redraw the screen
                    Refresh();
                    break;
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            //displays the time the game has taken
            gameTime = Convert.ToInt32(gameWatch.ElapsedMilliseconds) / 1000;
            timerLabel.Text = gameTime.ToString("000");
            timerLabel.Refresh();
        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            //draws the border around the screen
            Form1.DrawBorders(this.Height, this.Width, border, e.Graphics);

            //draw each block
            foreach (block b in blocks)
            {
                //if it's a bomb and revealed draw a bomb
                if (b.bomb && b.revealed) { e.Graphics.DrawImage(Properties.Resources.revealedBomb, b.x, b.y, b.size, b.size); }
                //if the game is lost and it's a flagged bomb, draw a flag
                else if (gameLose && b.bomb && b.flag) { e.Graphics.DrawImage(Properties.Resources.flagBlock, b.x, b.y, b.size, b.size); }
                //if the game is lost and it's been mis-flagged, draw a false bomb
                else if (gameLose && b.flag && b.bomb == false) { e.Graphics.DrawImage(Properties.Resources.falseBomb, b.x, b.y, b.size, b.size); }
                //if it is flagged, draw a flag
                else if (b.flag) { e.Graphics.DrawImage(Properties.Resources.flagBlock, b.x, b.y, b.size, b.size); }
                //if the game is lost and it is a bomb, draw a bomb
                else if (gameLose && b.bomb) { e.Graphics.DrawImage(Properties.Resources.bombBlock, b.x, b.y, b.size, b.size); }
                //if it is revealed, draw the block with the correct next to number on it
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
                //if it's not revealed, draw a regular block
                else if (b.revealed == false) { e.Graphics.DrawImage(Properties.Resources.block, b.x, b.y, b.size, b.size); }
            }
            //draw the restart button
            e.Graphics.DrawImage(Properties.Resources.restartButton, restartBlock.X, restartBlock.Y, 30, 30);
            //draw the displayed number of bombs left
            drawBrush.Color = Color.Black;
            e.Graphics.FillRectangle(drawBrush, bombPoint.X, bombPoint.Y, 63, 33);
            drawBrush.Color = Color.Red;
            if (bombsLeft <= 0) { e.Graphics.DrawString("000", titleFont, drawBrush, bombPoint); }
            else { e.Graphics.DrawString(bombsLeft.ToString("000"), titleFont, drawBrush, bombPoint); }
            //draw the selector
            if (gameLose || gameSelector.index == -1 || gameWin) { e.Graphics.DrawRectangle(drawPen, restartBlock.X, restartBlock.Y, 30, 30); gameSelector.index = -1; }
            else { e.Graphics.DrawRectangle(drawPen, blocks[gameSelector.index].x, blocks[gameSelector.index].y, blocks[gameSelector.index].size, blocks[gameSelector.index].size); }
        }

        #region Block Setup
        //creates the blocks based on the given row and column length
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
        //creates all the bombs, making sure that the given block and all the blocks around it aren't turned into a bomb
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
                    if (index == startBlock) { validIndex = false; }
                    if (startBlock >= rowLength)
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
                //turn the selected block into a bomb
                blocks[index].bomb = true;
            }
        }
        //create the number that shows how many bombs all blocks are adjacent to
        private void CreateNextTo()
        {
            //find out how many bombs each block is beside while following the grid pattern
            for (int i = 0; i < blocks.Count; i++)
            {
                if (blocks[i].bomb == false)
                {
                    if (i >= rowLength)
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

        private void WinGame()
        {
            //stop the game timer
            gameWatch.Stop();

            //based on the difficulty calculated the score
            foreach (block b in blocks)
            {
                if (b.bomb && b.flag)
                {
                    score += 50;
                }
            }
            score -= gameTime;
            score += 1000;

            //do a pause dialog thingy but its not a puase its the win screen
            DialogResult result = WinForm.Show();

            if (result == DialogResult.Cancel)
            {

            }
            else if (result == DialogResult.Abort)
            {
                Form1.ChangeScreen(this, "MenuScreen");
            }
        }
    }
}
