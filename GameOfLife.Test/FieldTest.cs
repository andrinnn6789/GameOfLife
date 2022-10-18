using FluentAssertions;

namespace GameOfLife.Test
{
    public class FieldTest
    {
        private Field _testee;

        [Fact]
        public void InitializeField_WithOnlyDeadCells_ExpectCorrectStringArrey()
        {
            _testee = new Field(20, 20);
            var expectedGeneration = CreateDeadGeneration();
            _testee.Cells.Should().BeEquivalentTo(expectedGeneration);
        }

        [Fact]
        public void InitializeField_WithSwitches_ExpectCorrectStringArrey()
        {
            _testee = new Field(20, 20);

            var expectedGeneration = CreateDeadGeneration();
            expectedGeneration[0, 0] = "*";
            expectedGeneration[0, 3] = "*";
            expectedGeneration[4, 8] = "*";

            _testee.SwitchLiveState(0, 0);
            _testee.SwitchLiveState(0, 3);
            _testee.SwitchLiveState(4, 8);
            _testee.Cells.Should().BeEquivalentTo(expectedGeneration);
        }

        [Fact]
        public void GoToNextRound_ExpectCorrectString()
        {
            _testee = new Field(10, 10);

            _testee.SwitchLiveState(1, 1);
            _testee.SwitchLiveState(2, 1);
            _testee.SwitchLiveState(1, 2);
            _testee.GoToNextGeneration();

            var expectedGeneration = CreateDeadGeneration();
            expectedGeneration[1, 1] = "*";
            expectedGeneration[2, 1] = "*";
            expectedGeneration[1, 2] = "*";
            expectedGeneration[2, 2] = "*";

            _testee.Cells.Should().BeEquivalentTo(expectedGeneration);
        }

        private string[,] CreateDeadGeneration()
        {
            var deadGeneration = new string[_testee.LenghtOfField, _testee.HeightOfField];
            for (int i = 0; i < _testee.LenghtOfField; i++)
            {
                for (int j = 0; j < _testee.HeightOfField; j++)
                {
                    deadGeneration[i, j] = ".";
                }
            }

            return deadGeneration;
        }

    }
}