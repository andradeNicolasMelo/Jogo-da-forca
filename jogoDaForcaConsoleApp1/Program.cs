using System.Runtime.Intrinsics.X86;

namespace jogoDaForcaConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                //=========================================
                string palavraSecreta = "";
                //=========================================

                //============== Possiveis palavras secretas ============
                string[] frutas = { "ABACATE", "ABACAXI", "ACEROLA", "ACAI", "ARACA", "ABACATE", "BACABA", "BACURI", "BANANA", "CAJA", "CAJU", "CARAMBOLA", "CUPUACU", "GRAVIOLA", "GOIABA", "JABUTICABA", "JENIPAPO", "MACA", "MANGABA", "MANGA", "MARACUJA", "MURICI", "PEQUI", "PITANGA", "PITAYA", "SAPOTI", "TANGERINA", "UMBU", "UVA", "UVAIA" };
                string[] animais = { "CACHORRO", "GATO", "ELEFANTE", "LEAO", "TIGRE", "ZEBRA", "GIRAFA", "MACACO", "RINOCERONTE", "HIPOPOTAMO", "COBRA", "JACARE", "ARARA", "TUCANO", "PANTERA", "LOBO", "URSO", "CAMELO", "GOLFINHO", "BALEIA", "TARTARUGA", "PINGUIM", "CORUJA", "FOCA", "LEOPARDO", "AVESTRUZ", "GALO", "SAPO", "CARANGUEIJO", "BORBOLETA" };
                string[] paises = { "BRASIL", "ARGENTINA", "CANADA", "CHILE", "COLOMBIA", "CUBA", "EQUADOR", "ESTADOS_UNIDOS", "FRANÇA", "ALEMANHA", "INDIA", "ITALIA", "JAPAO", "MÉXICO", "PORTUGAL", "RUSSIA", "ESPANHA", "SUECIA", "SUICA", "CHINA", "AFRICA_DO_SUL", "AUSTRÁLIA", "BELGICA", "DINAMARCA", "EGITO", "FILIPINAS", "GRECIA", "HOLANDA", "IRLANDA", "NORUEGA" };
                //======================================================

                Console.WriteLine("opções em que a palavra secreta estara relacionada:");
                Console.WriteLine("1 - Frutas");
                Console.WriteLine("2 - Animais");
                Console.WriteLine("3 - Países");
                Console.WriteLine("---------------------------------");
                Console.Write("Escolha uma opção: ");
                string escrolhaPalavraSecreta = Console.ReadLine();
                Console.WriteLine("");

                string categoriaPalavraSecreta = "";

                if (escrolhaPalavraSecreta == "1")
                {
                    Random random = new Random();
                    int escolhedorPalavraSecreta = random.Next(frutas.Length);

                    palavraSecreta = frutas[escolhedorPalavraSecreta];
                    categoriaPalavraSecreta = "É uma Fruta";
                }

                else if (escrolhaPalavraSecreta == "2")
                {
                    Random random = new Random();
                    int escolhedorPalavraSecreta = random.Next(animais.Length);

                    palavraSecreta = animais[escolhedorPalavraSecreta];
                    categoriaPalavraSecreta = "É um Animal";
                }

                else if (escrolhaPalavraSecreta == "3")
                {
                    Random random = new Random();
                    int escolhedorPalavraSecreta = random.Next(paises.Length);

                    palavraSecreta = animais[escolhedorPalavraSecreta];
                    categoriaPalavraSecreta = "É um País";
                }
                //===============================================

                

                //============== ARMAZENAMENTO DE VALORES ==============
                char[] ocultadores = new char[palavraSecreta.Length];
                char[] historicoDeLetras = new char[palavraSecreta.Length];
                //======================================================


                //========================
                //ocultador
                for (int i = 0; i < ocultadores.Length; i++)
                {
                    ocultadores[i] = '-';
                }

                string jogadorVenceu = "";
                string jogadorPerdeu = "";

                //========================
                //Fluxo do jogo
                int contadorErro = 0;

                do
                {
                    //========================
                    //DESIGNE
                    for (int i = 0; i <= 5; i++)
                    {

                        string cabecaDoBoneco = contadorErro >= 1 ? " o " : " ";
                    string tronco = contadorErro >= 2 ? "x" : " ";
                    string troncoBaixo = contadorErro >= 2 ? " x " : " ";
                    string bracoEsquerdo = contadorErro >= 3 ? "/" : " ";
                    string bracoDireito = contadorErro >= 4 ? @"\" : " ";
                    string pernas = contadorErro >= 5 ? "/ \\" : " ";

                    Console.Clear();

                        Console.WriteLine("----------------------------------------------");
                    Console.WriteLine("Jogo da Forca");
                    Console.WriteLine("----------------------------------------------");
                    Console.WriteLine(" ___________        ");
                    Console.WriteLine(" |/        |        ");
                    Console.WriteLine(" |        {0}       ", cabecaDoBoneco);
                    Console.WriteLine(" |        {0}{1}{2} ", bracoEsquerdo, tronco, bracoDireito);
                    Console.WriteLine(" |        {0}       ", troncoBaixo);
                    Console.WriteLine(" |        {0}       ", pernas);
                    Console.WriteLine(" |                  ");
                    Console.WriteLine(" |                  ");
                    Console.WriteLine("_|____              ");
                        //========================
                        //Visao do usuario

                        string censurador = string.Join("", ocultadores);
                        Console.WriteLine("");
                        Console.WriteLine("---------------------------------");
                        Console.WriteLine($"Dica da palavra: {categoriaPalavraSecreta}");
                        Console.WriteLine($"Palavra Secreta: {censurador}");
                        Console.WriteLine("---------------------------------");
                        Console.WriteLine($"Você errou {contadorErro} vezes");
                        Console.WriteLine("---------------------------------");
                        Console.WriteLine("");

                        if (censurador == palavraSecreta)
                        {
                            Console.WriteLine("Você venceu");
                            break;
                        }

                        Console.Write("Deseja arriscar no chute da palavra secreta? ");
                        string opcPalavraInteira = Console.ReadLine().ToUpper()!;
                        
                        if (opcPalavraInteira.Contains("S"))
                        {
                            Console.WriteLine("Escreva a palavra: ");
                            string palavraInteira = Console.ReadLine();

                            if(palavraInteira == palavraSecreta)
                            {
                                Console.WriteLine("parabens! Voce acertou");
                                break;
                            }

                            else
                            {
                                Console.WriteLine("Sua tentativa falha lhe custou 1 tentativa");
                                contadorErro++;
                            }
                        }



                            Console.Write("Chute uma letra: ");
                        char chute = Console.ReadLine().ToUpper()[0];


                        //========================
                        //Armazenamento/Filtragem de letras digitadas

                        int contadorHistorico = 0;
                        while (true)
                        {
                            if(chute == historicoDeLetras[contadorHistorico])
                            {
                                Console.Write($"Voce ja chutou essa letra. digite outra letra: ");
                                chute = Console.ReadLine()[0];
                            }

                                historicoDeLetras[contadorHistorico] = chute;
                            contadorHistorico++;

                            if (chute != historicoDeLetras[contadorHistorico])
                            {
                                break;
                            }
                            
                        }

                        string verificadorDeErros = "contador";

                        for (int c = 0; c < palavraSecreta.Length; c++)
                        {
                            char verificadorDeLetras = palavraSecreta[c];

                            if (chute == verificadorDeLetras)
                            {
                                break;
                            }

                            else if (c == palavraSecreta.Length -1)
                            {
                                verificadorDeErros = "errou";
                            }
                        }

                        if (verificadorDeErros == "errou")
                        {
                            contadorErro++;
                        }
                        

                        //========================
                        //Revelador de letras

                        for (int j = 0; j < palavraSecreta.Length; j++)
                        {
                            char verificador = palavraSecreta[j];

                            if (verificador == chute)
                            {
                                ocultadores[j] = chute;
                            }
                        }

                        if(5 <= contadorErro)
                        {
                            Console.WriteLine("Você perdeu");
                            jogadorVenceu = "venceu";
                        }

                        else
                        {
                            Console.WriteLine("Você venceu");
                            jogadorPerdeu = "perdeu";
                        }

                    }


                } while (jogadorVenceu != "venceu" && jogadorPerdeu != "perdeu");
                Console.WriteLine("----------------------------");
                Console.WriteLine($"A palavra secreta é: {palavraSecreta}");
                Console.WriteLine("----------------------------");
                Console.WriteLine();
                Console.Write("Deseja continuar a jogar(S/N)? ");
                string sair = Console.ReadLine().ToUpper();

                if (sair == "N")
                {
                    break;
                }

                else
                {
                    continue;
                }

            }
        }
    }
}
