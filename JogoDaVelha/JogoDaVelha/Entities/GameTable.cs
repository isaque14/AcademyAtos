namespace JogoDaVelha.Entities
{
    public class GameTable
    {
        public char[,] Board  { get; set; }
        public List<string> Errors { get; set; }

        public GameTable()
        {
            Board = InitializeBoard();
            Errors = new List<string>();
        }

        public char[,] InitializeBoard()
        {
            return new char[3, 3] { { ' ', ' ', ' ' }, { ' ', ' ', ' ' }, { ' ', ' ', ' ' } };
        }

        public void PrintBoard()
        {
            Console.WriteLine("Estado Atual do Tabuleiro");
            Console.WriteLine("  0   1   2");
            Console.WriteLine($"0 {Board[0,0]} | {Board[0,1]} | {Board[0,2]}");
            Console.WriteLine("________________");
            Console.WriteLine($"1 {Board[1,0]} | {Board[1,1]} | {Board[1,2]}");
            Console.WriteLine("________________");
            Console.WriteLine($"2 {Board[2,0]} | {Board[2,1]} | {Board[2,2]}");
        }

        public bool ValidateMove(Move move)
        {
            if (move.Line < 0 || move.Line > 2 || move.Column < 0 || move.Column > 2)
            {
                Console.WriteLine("Ops, dados inválidos, verifique suas entradas e tente novamente");
                return false;
            }

            if (Board[move.Line, move.Column] != ' ')
            {
                Console.WriteLine("Ops, essa posição está ocupada, tente novamente");
                return false;
            }

            if (move.Player != 'x' && move.Player != 'X' && move.Player != 'o' && move.Player != 'O')
            {
                Console.WriteLine("Ops, caracter inválido validos são apenas X e O");
                return false;
            }

            return true;
        }

        public bool IsWinner(char player)
        {
            for (int i = 0; i < 3; i++)
            {
                if (Board[i, 0] == player && Board[i, 1] == player && Board[i, 2] == player)
                    return true;

                if (Board[0, i] == player && Board[1, i] == player && Board[2, i] == player)
                    return true;
            }

            if (Board[0, 0] == player && Board[1, 1] == player && Board[2, 2] == player)
                return true;

            if (Board[0, 2] == player && Board[1, 1] == player && Board[2, 0] == player)
                return true;

            return false;
        }

        public void ToMarkPosition(Move move)
        {
            Board[move.Line, move.Column] = move.Player;
        }

        public Move KillerMove(char player)
        {
            var defaultSkynet = player;
            for (int i = 0; i < 2; i++)
            {
                for (int line = 0; line < 3; line++)
                {
                    for (int column = 0; column < 3; column++)
                    {
                        if (Board[line, column] == ' ')
                        {
                            Board[line, column] = player;

                            if (IsWinner(player))
                            {
                                Board[line, column] = ' ';
                                return new Move(line, column, defaultSkynet);
                            }

                            Board[line, column] = ' ';
                        }
                    }
                }
                var computer = player == 'x' ? 'o' : 'x';
                player = computer;
            }

            return RandomMove(defaultSkynet);
        }

        public Move RandomMove(char player)
        {
            var initialMoves = new List<Move>()
            {
                new Move(0, 0, player),
                new Move(0, 2, player),
                new Move(2, 0, player),
                new Move(2, 2, player)
            };

            foreach (var moviment in initialMoves)
            {
                if (ValidateMove(moviment)) return moviment;
            }

            var random = new Random();
            var move = new Move();

            do
            {
                move = new Move
                {
                    Line = random.Next(0, 3),
                    Column = random.Next(0, 3),
                    Player = player
                };
            }while (!ValidateMove(move));

            return move;
        }
    }
}
