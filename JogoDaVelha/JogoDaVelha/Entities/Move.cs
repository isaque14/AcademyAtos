namespace JogoDaVelha.Entities
{
    public class Move
    {
        public int Line { get; set; }
        public int Column { get; set; }
        public char Player { get; set; }

        public Move(int line, int column, char player)
        {
            Line = line;
            Column = column;
            Player = player;
        }

        public Move() { }
    }
}
