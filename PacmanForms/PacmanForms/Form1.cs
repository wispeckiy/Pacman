﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PacmanForms
{
    public partial class Form1 : Form
    {
        Pacman pacman;
        Graphics g;
        Maze maze;
        byte k = 0;
        public Form1()
        {
            InitializeComponent();
            this.BackColor = Color.Black;

            pacman = new Pacman();
            maze = new Maze();

            timer1.Interval =20;
            timer1.Enabled = true;
            timer2.Interval = 100;
            timer2.Enabled = true;
            g = this.CreateGraphics();
           
          //  Refresh();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            CheckBorders();
            pacman.Move();
            Invalidate(pacman.GetRect());
            g.DrawImage(pacman.GetPacmanImg(), pacman.GetRect());

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            PaintWalls();
            g.DrawImage(pacman.GetPacmanImg(), pacman.GetRect());
        } 

        private void PaintWalls()
        {
            foreach (Rectangle item in maze.getRectanglesWall())
            {
                g.FillRectangle(Brushes.Blue, item);
            }

        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {

            //if ( == Keys.Right)
            //{
            //    pacman.SetVectorX(1);
            //    pacman.SetVectorY(0);
            //}
            //else if (e.KeyChar. == Keys.Left)
            //{
            //    pacman.SetVectorX(-1);
            //    pacman.SetVectorY(0);
            //}
            //else if (e.KeyCode == Keys.Down)
            //{
            //    pacman.SetVectorX(0);
            //    pacman.SetVectorY(-1);
            //}

            //else if (e.KeyCode == Keys.Up)
            //{
            //    pacman.SetVectorX(0);
            //    pacman.SetVectorY(1);
            //}
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Right)
            {
                pacman.SetVectorX(1);
                pacman.SetVectorY(0);

            }
            else if (e.KeyCode == Keys.Left)
            {
                pacman.SetVectorX(-1);
                pacman.SetVectorY(0);
            }
            else if (e.KeyCode == Keys.Down)
            {
                pacman.SetVectorX(0);
                pacman.SetVectorY(-1);
            }

            else if (e.KeyCode == Keys.Up)
            {
               
                pacman.SetVectorX(0);
                pacman.SetVectorY(1);
            }
            //pacman.Move();
            //Refresh();
            //g.DrawImage(pacman.GetPacmanImg(), pacman.GetRect());
        }

        private void CheckBorders()
        {
            if ((pacman.GetRect().Right + pacman.GetVectorX()>= this.ClientSize.Width && pacman.GetVectorX() > 0) || (pacman.GetRect().X <= 0 && pacman.GetVectorX() < 0))
            {
                pacman.SetVectorX(0);
                return;
            }
            if ((pacman.GetRect().Bottom  + pacman.GetVectorY()>= this.ClientSize.Height && pacman.GetVectorY() < 0) || (pacman.GetRect().Y <= 0 && pacman.GetVectorY() > 0))
            {
                pacman.SetVectorY(0);
                return;
            }


            if (maze[(((pacman.GetRect().X ) / 23) + pacman.GetVectorX()), (((pacman.GetRect().Y) / 23) - pacman.GetVectorY())] == 1)
            {
                pacman.SetVectorX(0);
                pacman.SetVectorY(0);
                return;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            k++;
            pacman.setAnimation(k);
          
            
        }

        //private bool checkBound()
        //{
        //    if (pacman.GetX() < this.Size.Width - Properties.Resources.Pacman_pic.Width && pacman.GetY() < this.Size.Height - Properties.Resources.Pacman_pic.Height)
        //        return true;

        //    return false;
        //}

        //private void t_Tick(object sender, EventArgs e)
        //{
        //    if (checkBound())
        //        pacman.Move();
        //    else
        //        pacman.SetVector(new int[] { 0, 1 });

        //}

        //private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    //if(e.KeyCode == Keys.Up) pacman.SetVector(new int[]{ 0, 1 });
        //    pacman.SetVector(new int[] { 0,-1 });
        //    pacman.Move();
        //}
    }
}
