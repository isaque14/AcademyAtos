namespace JogoDaVelha.Entities
{
    public abstract class ToPlay
    {
        private const int MaxMoves = 9;
        private const int ModPVP = 1;
        private const int ModSkynet = 2;

        private static void Player1VSPlayer2()
        {
            var winner = false;
            var moves = 0;
            var game = new GameTable();
            var playerCaracter = 'x';

            Console.WriteLine("Quem começa? (X ou O)");
            playerCaracter = char.Parse(Console.ReadLine());

            while (!winner && moves < MaxMoves)
            {
                var move = new Move { };
                Console.Clear();
                game.PrintBoard();
                do
                {
                    Console.WriteLine($"Vez do jogador {char.ToUpper(playerCaracter)}, Faça sua jogada (Linha, Coluna)");
                    var input = Console.ReadLine();
                    var point = input.Split(' ');
                    var line = int.Parse(point[0]);
                    var column = int.Parse(point[1]);
                    move = new Move(line, column, playerCaracter);
                } while (!game.ValidateMove(move));

                game.ToMarkPosition(move);

                moves++;

                if (game.IsWinner(playerCaracter))
                {
                    Console.Clear();
                    Console.WriteLine($"Parabéns Jogador {char.ToUpper(playerCaracter)}, Você Venceu");
                    winner = true;
                }
                
                playerCaracter = playerCaracter == 'x' ? 'o' : 'x';
            }

            game.PrintBoard();

            if (!winner) Draw();
        }

        private static void PlayerVSSkynet()
        {
            var winner = false;
            var moves = 0;
            var game = new GameTable();
            var playerCaracter = 'x';
            var computerCaracter = 'o';

            Console.WriteLine("Escolha uma Opção (X ou O)");
            playerCaracter = char.Parse(Console.ReadLine());
            var isPlayer = false;
            computerCaracter = playerCaracter == 'x' ? 'o' : 'x';

            while (!winner && moves < 9)
            {
                var move = new Move { };
                Console.Clear();
                game.PrintBoard();

                if (isPlayer)
                {
                    do
                    {
                        Console.WriteLine($"Sua Vez jogador {char.ToUpper(playerCaracter)}, Faça sua jogada (Linha, Coluna)");
                        var input = Console.ReadLine();
                        var point = input.Split(' ');
                        var line = int.Parse(point[0]);
                        var column = int.Parse(point[1]);
                        move = new Move(line, column, playerCaracter);
                    } while (!game.ValidateMove(move));
                }

                else
                {
                    Console.WriteLine("SKYNET Computando...");
                    System.Threading.Thread.Sleep(3 * 1000);
                    move = game.KillerMove(computerCaracter);
                }

                game.ToMarkPosition(move);

                moves++;

                if (game.IsWinner(playerCaracter))
                {
                    Console.Clear();
                    Console.WriteLine($"Parabéns Jogador {playerCaracter}, Você Venceu");
                    winner = true;
                }
                else if (game.IsWinner(computerCaracter))
                {
                    Console.Clear();
                    Console.WriteLine("As IA's dominarão o mundo, SKYNET venceu");
                    winner = true;
                }

                isPlayer = isPlayer == true ? false : true;
            }

            game.PrintBoard();

            if (!winner) Draw();   
        }

        public static void Start()
        {
            var gameMode = -1;

            Console.WriteLine("######### Bem Vindo ao Desafio do Jogo da Velha ########");

            do
            {
                Console.Clear();
                Console.WriteLine("Escolha o Modo de Jogo (1 -> Player1 VS Player2 | 2 -> Player VS SKYNET)");
                gameMode = int.Parse(Console.ReadLine());
            } while (gameMode != ModPVP && gameMode != ModSkynet);

            if (gameMode == ModPVP)
                Player1VSPlayer2();
            else
                PlayerVSSkynet();
        }

        private static void Draw()
        {
            Console.Clear();
            Console.WriteLine("Senhoras e Senhores, Temos um Empate");
        }
    }
}
