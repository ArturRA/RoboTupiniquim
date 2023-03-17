using System.Security.Cryptography.X509Certificates;

namespace RoboTupiniquim.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region Input de Dados

            int maxposicaoX = 0;
            int maxposicaoY = 0;

            int[] posicaoXDoRobo = new int[2];
            int[] posicaoYDoRobo = new int[2];
            char[] direcaoDoRobo = new char[2];
            char[][] comandoRobo = new char[2][];

            // Tamanho da área Ex: 5 7. Onde X = 5 e Y = 7
            Console.Write("Digite o tamanho da área: ");
            string area = Console.ReadLine();
            string[] areaArray = area.Split(" ");
            maxposicaoX = Convert.ToInt32(areaArray[0]);
            maxposicaoY = Convert.ToInt32(areaArray[1]);

            // Robo 01
            Console.Write("Informe a localização do robô 01: ");
            string localizaçãoRobo01 = Console.ReadLine();
            string[] localizaçãoRobo01Array = localizaçãoRobo01.Split(" ");
            posicaoXDoRobo[0] = Convert.ToInt32(localizaçãoRobo01Array[0]);
            posicaoYDoRobo[0] = Convert.ToInt32(localizaçãoRobo01Array[1]);
            direcaoDoRobo[0] = Convert.ToChar(localizaçãoRobo01Array[2]);

            Console.Write("Informe o comando do robô 01: ");
            string comando1 = Console.ReadLine();
            comandoRobo[0] = comando1.ToCharArray();

            // Robo 02
            Console.Write("Informe a localização do robô 02: ");
            string localizaçãoRobo02 = Console.ReadLine();
            string[] localizaçãoRobo02Array = localizaçãoRobo02.Split(" ");
            posicaoXDoRobo[1] = Convert.ToInt32(localizaçãoRobo02Array[0]);
            posicaoYDoRobo[1] = Convert.ToInt32(localizaçãoRobo02Array[1]);
            direcaoDoRobo[1] = Convert.ToChar(localizaçãoRobo02Array[2]);

            Console.Write("Informe o comando do robô 02: ");
            string comando2 = Console.ReadLine();
            comandoRobo[1] = comando2.ToCharArray();
            #endregion

            #region Operações

            void Move(int numeroDoRobo)
            {
                switch (direcaoDoRobo[numeroDoRobo])
                {
                    case 'N':
                        posicaoYDoRobo[numeroDoRobo] += 1;
                        break;
                    case 'S':
                        posicaoYDoRobo[numeroDoRobo] -= 1;
                        break;
                    case 'L':
                        posicaoXDoRobo[numeroDoRobo] += 1;
                        break;
                    case 'O':
                        posicaoXDoRobo[numeroDoRobo] -= 1;
                        break;
                }
            }

            void TurnLeft(int numeroDoRobo)
            {
                switch (direcaoDoRobo[numeroDoRobo])
                {
                    case 'N':
                        direcaoDoRobo[numeroDoRobo] = 'O';
                        break;
                    case 'O':
                        direcaoDoRobo[numeroDoRobo] = 'S';
                        break;
                    case 'S':
                        direcaoDoRobo[numeroDoRobo] = 'L';
                        break;
                    case 'L':
                        direcaoDoRobo[numeroDoRobo] = 'N';
                        break;
                    
                }
            }

            void TurnRight(int numeroDoRobo)
            {
                switch (direcaoDoRobo[numeroDoRobo])
                {
                    case 'N':
                        direcaoDoRobo[numeroDoRobo] = 'L';
                        break;
                    case 'L':
                        direcaoDoRobo[numeroDoRobo] = 'S';
                        break;
                    case 'S':
                        direcaoDoRobo[numeroDoRobo] = 'O';
                        break;
                    case 'O':
                        direcaoDoRobo[numeroDoRobo] = 'N';
                        break;
                }
            }

            #endregion

            #region Processamento

            void ProcessCommands(char[] commands, int numeroDoRobo)
            {
                foreach (char command in commands)
                {
                    switch (command)
                    {
                        case 'M':
                            Move(numeroDoRobo);
                            break;
                        case 'E':
                            TurnLeft(numeroDoRobo);
                            break;
                        case 'D':
                            TurnRight(numeroDoRobo);
                            break;
                        default:
                            throw new ArgumentException($"Comando invalido: {command}, para o robo {numeroDoRobo}");
                    }
                }
            }
            #endregion

            ProcessCommands(comandoRobo[0], 0);
            ProcessCommands(comandoRobo[1], 1);

            Console.WriteLine($"Posição final robo 01: X = {posicaoXDoRobo[0]}, Y = {posicaoYDoRobo[0]}, Direção = {direcaoDoRobo[0]}");
            Console.WriteLine($"Posição final robo 02: X = {posicaoXDoRobo[1]}, Y = {posicaoYDoRobo[1]}, Direção = {direcaoDoRobo[1]}");

            Console.Write("\nDigite qualquer tecla para continuar o programa.");
            Console.ReadLine();
        }
    }
}