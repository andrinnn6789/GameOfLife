namespace GameOfLife
{
    public class Field
    {
        public int LengthOfField { get; }
        public int HeightOfField { get; }
        public string[,] Cells { get; }

        private readonly string[,] _cellsOldGeneration;

        public Field(int lengthOfField, int heightOfField)
        {
            LengthOfField = lengthOfField;
            HeightOfField = heightOfField;
            Cells = new string[LengthOfField, HeightOfField];

            for (int i = 0; i < LengthOfField; i++)
            {
                for (int j = 0; j < HeightOfField; j++)
                {
                    Cells[i, j] = " ";
                }
            }

            _cellsOldGeneration = new string[LengthOfField, HeightOfField];
            Array.Copy(Cells, _cellsOldGeneration, LengthOfField * HeightOfField);
        }

        public void GoToNextGeneration()
        {
            Array.Copy(Cells, _cellsOldGeneration, LengthOfField * HeightOfField);

            for (int length = 0; length < LengthOfField; length++)
            {
                for (int height = 0; height < HeightOfField; height++)
                {
                    int aliveNeighbours = GetAliveNeighbours(length, height);

                    if (CellIsAlive(length, height) && aliveNeighbours is < 2 or > 3)
                    {
                        SwitchLiveState(length, height);
                    }
                    else if (CellIsDead(length, height) && aliveNeighbours == 3)
                    {
                        SwitchLiveState(length, height);
                    }
                }
            }
        }

        public void SwitchLiveState(int indexLength, int indexHeight)
        {
            if (CellIsDead(indexLength, indexHeight))
            {
                Cells[indexLength, indexHeight] = "*";
            }
            else if (CellIsAlive(indexLength, indexHeight))
            {
                Cells[indexLength, indexHeight] = " ";
            }
        }

        private bool CellIsAlive(int indexLength, int indexHeight)
        {
            return _cellsOldGeneration[indexLength, indexHeight] == "*";
        }

        private bool CellIsDead(int indexLength, int indexHeight)
        {
            return _cellsOldGeneration[indexLength, indexHeight] == " ";
        }

        private int GetAliveNeighbours(int length, int height)
        { 
            var neighbours = new string[8];

            neighbours[0] = IsCellInitialized(length - 1, height - 1) ? _cellsOldGeneration[length - 1, height - 1] : " ";
            neighbours[1] = IsCellInitialized(length - 1, height) ? _cellsOldGeneration[length - 1, height] : " ";
            neighbours[2] = IsCellInitialized(length - 1, height + 1) ? _cellsOldGeneration[length - 1, height + 1] : " ";
            neighbours[3] = IsCellInitialized(length, height - 1) ? _cellsOldGeneration[length, height - 1] : " ";
            neighbours[4] = IsCellInitialized(length, height + 1) ? _cellsOldGeneration[length, height + 1] : " ";
            neighbours[5] = IsCellInitialized(length + 1, height - 1) ? _cellsOldGeneration[length + 1, height - 1] : " ";
            neighbours[6] = IsCellInitialized(length + 1, height) ? _cellsOldGeneration[length + 1, height] : " ";
            neighbours[7] = IsCellInitialized(length + 1, height + 1) ? _cellsOldGeneration[length + 1, height + 1] : " ";

            return neighbours.Count(neighbour => neighbour == "*");
        }

        private bool IsCellInitialized(int length, int height) =>
            !(length >= LengthOfField || length < 0 || height >= HeightOfField|| height < 0);
    }
}
