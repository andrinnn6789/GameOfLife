using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public class Field
    {
        public int LenghtOfField { get; }
        public int HeightOfField { get; }
        public string[,] Cells { get; set; }

        public Field(int lenghtOfField, int heightOfField)
        {
            LenghtOfField = lenghtOfField;
            HeightOfField = heightOfField;
            Cells = new string[LenghtOfField, HeightOfField];

            for (int i = 0; i < LenghtOfField; i++)
            {
                for (int j = 0; j < HeightOfField; j++)
                {
                    Cells[i, j] = ".";
                }
            }
        }

        public void SwitchLiveState(int indexLenght, int indexHeight)
        {
            if (CellIsDead(indexLenght, indexHeight))
            {
                Cells[indexLenght, indexHeight] = "*";
            }
            else if (CellIsAlive(indexLenght, indexHeight))
            {
                Cells[indexLenght, indexHeight] = ".";
            }
        }
        public void GoToNextGeneration()
        {
            for (int lenght = 0; lenght < LenghtOfField; lenght++)
            {
                for (int height = 0; height < HeightOfField; height++)
                {
                    int aliveNeighbours = GetAliveNeighbours(lenght, height);

                    if (CellIsAlive(lenght, height) && (aliveNeighbours < 2 || aliveNeighbours > 3))
                    {
                        SwitchLiveState(lenght, height);
                    }
                    else if (CellIsDead(lenght, height) && aliveNeighbours == 3)
                    {
                        SwitchLiveState(lenght, height);
                    }
                }
            }
        }

        private bool CellIsAlive(int indexLenght, int indexHeight)
        {
            return Cells[indexLenght, indexHeight] == "*";
        }

        private bool CellIsDead(int indexLenght, int indexHeight)
        {
            return Cells[indexLenght, indexHeight] == ".";
        }

        private int GetAliveNeighbours(int lenght, int height)
        {
            throw new NotImplementedException(); //TODO
        }
    }
}
