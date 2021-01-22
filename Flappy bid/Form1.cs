// january 2021
// Adrian
// A Flappy Bird type game
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flappy_bid
{
    public partial class Form1 : Form
    {
        int topx = 700;
        int topy = 300;
        int score = 0;

        int bottomx = 700;
        int bottomy = -260;

        int bottomWidth = 140;
        int bottomHeight = 300;

        int paddleWidth = 140;
        int paddleHeight = 400;
        int paddleSpeed = -10;


        int groundx = 0;
        int groundy = 440;
        int groundWidth = 1000;
        int groundHeight = 10;

        int fall = 10;
        int ballX = 220;
        int ballY = 80;
        int ballXSpeed = 0;
        int ballYSpeed = 15;
        int ballWidth = 50;
        int ballHeight = 40;

        int topx2 = 1100;
        int topy2 = -250;

        int topx3 = 1400;
        int topy3 = -150;

        int bottomx2 = 1100;
        int bottomy2 = 220;

        int bottomx3 = 1400;
        int bottomy3 = 320;

        bool wDown = false;
        bool upArrowDown = false;

        SolidBrush redBrush = new SolidBrush(Color.Green);
        SolidBrush whiteBrush = new SolidBrush(Color.Yellow);   
        SolidBrush Blackbrush = new SolidBrush(Color.Turquoise);
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = true;
                    break;

                case Keys.Up:
                    upArrowDown = true;
                    break;

            }
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = false;
                    break;
                case Keys.Up:
                    upArrowDown = false;
                    break;

            }


        }
        private void gametimer_Tick(object sender, EventArgs e)
        {
            // move the pipes and make the ball fall

            scoretext.Text = "score:" + score;
            bottomx += paddleSpeed;
            topx += paddleSpeed;
            bottomx2 += paddleSpeed;
            topx2 += paddleSpeed;
            bottomx3 += paddleSpeed;
            topx3 += paddleSpeed;
            ballX += ballXSpeed;
            ballY += fall;
         // make the pipes show up to the right after the went to the left

            if (topx < -150)
            {
                bottomx = 800;
            }
            if (topx < -150)
            {
                topx = 800;
                score++;
            }
            if (topx2 < -150)
            {
                bottomx2 = 800;

            }
            if (topx2 < -150)
            {
                topx2 = 800;
                score++;
            }
            if (topx3 < -150)
            {
                bottomx3 = 800;
            }
            if (topx3 < -150)
            {
                topx3 = 800;
                score++;
            }
        // when the score reaches 5 the pipes go faster

            if (score > 5)
            {
                paddleSpeed = -15;
            }
           
         // when the player presses w or up arrow the bird moves up

            if (wDown == true && topy > 0)
            {
                ballY -= ballYSpeed;
            }


            if (upArrowDown == true && topy > 0)
            {
                ballY -= ballYSpeed;
            }
            // make collision for the pipes

            Rectangle top1 = new Rectangle(topx, topy, paddleWidth, paddleHeight);
            Rectangle bottom1 = new Rectangle(bottomx, bottomy, paddleWidth, paddleHeight);
            Rectangle ballRec = new Rectangle(ballX, ballY, ballWidth, ballHeight);
            Rectangle ground = new Rectangle(groundx, groundy, groundWidth, groundHeight);
            Rectangle top2 = new Rectangle(topx2, topy2, bottomWidth, bottomHeight);
            Rectangle bottom2 = new Rectangle(bottomx2, bottomy2, bottomWidth, bottomHeight);
            Rectangle top3 = new Rectangle(topx3, topy3, bottomWidth, bottomHeight);
            Rectangle bottom3 = new Rectangle(bottomx3, bottomy3, bottomWidth, bottomHeight);
          
            // when the bird hits the pipe the game ends

            if (bottom1.IntersectsWith(ballRec))
            {
                gametimer.Enabled = false;
            }
            else if (top1.IntersectsWith(ballRec))
            {
                gametimer.Enabled = false;
            }
            else if (ground.IntersectsWith(ballRec))
            {
                gametimer.Enabled = false;
            }
            else if (top2.IntersectsWith(ballRec))
            {
                gametimer.Enabled = false;
            }
            else if (bottom2.IntersectsWith(ballRec))
            {
                gametimer.Enabled = false;
            }
            else if (top3.IntersectsWith(ballRec))
            {
                gametimer.Enabled = false;
            }
            else if (bottom3.IntersectsWith(ballRec))
            {
                gametimer.Enabled = false;
            }
            Refresh();
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            // make the paint

            e.Graphics.FillRectangle(whiteBrush, ballX, ballY, ballWidth, ballHeight);
            e.Graphics.FillRectangle(redBrush, topx, topy, paddleWidth, paddleHeight);
            e.Graphics.FillRectangle(redBrush, bottomx, bottomy, paddleWidth, paddleHeight);
            e.Graphics.FillRectangle(Blackbrush, groundx, groundy, groundWidth, groundHeight);
            e.Graphics.FillRectangle(redBrush, topx2, topy2, bottomWidth, bottomHeight);
            e.Graphics.FillRectangle(redBrush, bottomx2, bottomy2, bottomWidth, bottomHeight);
            e.Graphics.FillRectangle(redBrush, topx3, topy3, bottomWidth, bottomHeight);
            e.Graphics.FillRectangle(redBrush, bottomx3, bottomy3, bottomWidth, bottomHeight);
        }
    }
}


