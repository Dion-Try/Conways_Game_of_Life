using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Conways_Game
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        static int columns = 12;
        static int rows = 12;
        int cellWidth = 30;
        int cellHeight = 30;
        string[,] cellGrid = new string[columns, rows];
        Panel Panel1 = new Panel();


        

        public void Form1_Load(object sender, EventArgs e)
        {
            this.Controls.Add(Panel1);
            Panel1.Location = new Point(0, 0);
            Panel1.Size = new Size(cellWidth * columns, cellHeight * rows);
            Panel1.Visible = true;



            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Button cell = new Button();
                    cellGrid[j, i] = "dead";
                    cell.Location = new Point((j * cellWidth), (i * cellHeight));
                    cell.Size = new Size(cellWidth, cellHeight);
                    cell.BackColor = Color.White;
                    cell.Click += werdeRot;
                    Panel1.Controls.Add(cell);
                }

            }
        }

        public int Neighbours(int x,int y)
        {      
                    int neighbours = 0;

                    for (int k = y - 1; k < y + 2; k++)
                    {
                        for (int l = x - 1; l < x + 2; l++)
                        {
                            try
                            {
                                if (l == y && k == x) 
                                { 
                                    neighbours += 0;

                                    
                                }
                                else if (cellGrid[l, k] == "Alive") 
                                { 
                                    neighbours += 1;

                                   
                                }
                            }

                            catch (Exception e)
                            {
                                
                            }
                            
                        }
                    }
            return neighbours;
            cellGrid[x, y] = neighbours.ToString();
        }
        

        public void werdeRot(object sender, EventArgs e)
        {
            Control cell = sender as Control;
            Button thisButton = ((Button)sender);
            
            int xIndex = thisButton.Location.X / cellWidth;
            int yIndex = thisButton.Location.Y / cellHeight;
            if (thisButton.BackColor == Color.White)
            {
                thisButton.BackColor = Color.Black; 
                cellGrid[xIndex, yIndex] = "Alive"; 

            }

            else
            {
                thisButton.BackColor = Color.White;
                cellGrid[xIndex, yIndex] = "dead";

            }
        }

        public async Task nextGrid(object sender, EventArgs e)
        {
           
            foreach (Control cell in Panel1.Controls)
            {
                bool isAlive;
                int xIndex = cell.Location.X / cellWidth;
                int yIndex = cell.Location.Y / cellHeight;
                int neighbours = Neighbours(xIndex,yIndex);

                if (neighbours < 2 | neighbours > 3)
                {
                    cellGrid[xIndex, yIndex] = "dead";
                    cell.BackColor = Color.White;

                    btnReset.Text = "Geht nicht";
                }
                else if (neighbours == 3)
                {
                    cellGrid[xIndex, yIndex] = "Alive";
                    cell.BackColor = Color.Black;

                    buttonStart.Text = "Get doch";
                }
                else if(cellGrid[xIndex, yIndex] == "Alive" && neighbours == 2)
                {
                    cellGrid[xIndex, yIndex] = "Alive";
                    cell.BackColor = Color.Black;
                }

            }

        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            nextGrid(sender ,e);
            
        }
    }
}
