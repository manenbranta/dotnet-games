namespace Forca
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Globalization;
    using System.Collections.Generic;

    class Game
    {
        static List<string> listaPalavras;
        static Dictionary<string,string> dicas;

        static string[] frames = {
            #region FRAMES
            @"      ╔═══╗   " + '\n' +
            @"      |   ║   " + '\n' +
            @"          ║   " + '\n' +
            @"          ║   " + '\n' +
            @"          ║   " + '\n' +
            @"     ███  ║   " + '\n' +
            @"    ══════╩═══",

            @"      ╔═══╗   " + '\n' +
            @"      |   ║   " + '\n' +
            @"      O   ║   " + '\n' +
            @"          ║   " + '\n' +
            @"          ║   " + '\n' +
            @"     ███  ║   " + '\n' +
            @"    ══════╩═══",
            
            @"      ╔═══╗   " + '\n' +
            @"      |   ║   " + '\n' +
            @"      O   ║   " + '\n' +
            @"      |   ║   " + '\n' +
            @"          ║   " + '\n' +
            @"     ███  ║   " + '\n' +
            @"    ══════╩═══",
            
            @"      ╔═══╗   " + '\n' +
            @"      |   ║   " + '\n' +
            @"      O   ║   " + '\n' +
            @"      |\  ║   " + '\n' +
            @"          ║   " + '\n' +
            @"     ███  ║   " + '\n' +
            @"    ══════╩═══",
            
            @"      ╔═══╗   " + '\n' +
            @"      |   ║   " + '\n' +
            @"      O   ║   " + '\n' +
            @"     /|\  ║   " + '\n' +
            @"          ║   " + '\n' +
            @"     ███  ║   " + '\n' +
            @"    ══════╩═══",
            
            @"      ╔═══╗   " + '\n' +
            @"      |   ║   " + '\n' +
            @"      O   ║   " + '\n' +
            @"     /|\  ║   " + '\n' +
            @"       \  ║   " + '\n' +
            @"     ███  ║   " + '\n' +
            @"    ══════╩═══",
            
            @"      ╔═══╗   " + '\n' +
            @"      |   ║   " + '\n' +
            @"      O   ║   " + '\n' +
            @"     /|\  ║   " + '\n' +
            @"     / \  ║   " + '\n' +
            @"     ███  ║   " + '\n' +
            @"    ══════╩═══",
            // Death
            @"      ╔═══╗   " + '\n' +
            @"      |   ║   " + '\n' +
            @"      O   ║   " + '\n' +
            @"     /|\  ║   " + '\n' +
            @"     / \  ║   " + '\n' +
            @"          ║   " + '\n' +
            @"    ══════╩═══",
            #endregion
        };
        static void Main()
        {
            // Todas as palavras disponíveis para o jogo escolher aleatoriamente 
            listaPalavras = new List<string>() {
                #region PALAVRAS
                "amarelo",
                "miserável",
                "caatinga",
                "transeunte",
                "quarentena",
                "abacate",
                "ajuda",
                "cachorro",
                "gato",
                "maçã",
                "rápido",
                "fascinante",
                "nebuloso",
                "xaxim",
                "solilóquio",
                "transcendência",
                "sussurro",
                "abissal",
                "introspecção",
                "carinho",
                "felicidade",
                "coração",
                "estrela",
                "amigo",
                "sabedoria",
                "ventania",
                "aventura",
                "luz",
                "paz",
                "natureza",
                "guarda-chuva",
                "pé-de-moleque",
                "pérola negra",
                "guia turístico",
                "avô materno"
                #endregion
            };

            // Hashmap com as dicas para cada palavra
            dicas = new Dictionary<string, string>
            {
                #region DICAS
                { "amarelo", "Cor do maior astro próximo da terra" },
                { "miserável", "Sinônimo da palavra pobre" },
                { "caatinga", "Bioma brasileiro" },
                { "transeunte", "Aquele ou aquilo em constante movimento" },
                { "quarentena", "Sinônimo de isolação" },
                { "abacate", "Fruta verde por fora e cremosa por dentro, rica em gordura saudável." },
                { "ajuda", "Ato de oferecer suporte ou assistência a alguém." },
                { "cachorro", "Animal de estimação conhecido como melhor amigo do homem." },
                { "gato", "Animal de estimação que adora caçar ratos." },
                { "maçã", "Fruta geralmente vermelha ou verde, famosa por ser 'proibida'." },
                { "rápido", "Sinônimo de veloz, que se move com agilidade." },
                { "fascinante", "Que causa fascínio; atraente." },
                { "nebuloso", "Que apresenta nuvens ou neblina; obscuro." },
                { "xaxim", "Planta do tipo samambaia, utilizada em jardinagem." },
                { "solilóquio", "Discurso que uma pessoa faz em voz alta, consigo mesma." },
                { "transcendência", "Ato ou efeito de transcender; superação." },
                { "sussurro", "Som suave e baixo; murmurio." },
                { "abissal", "Relativo a grandes profundidades; extremamente profundo." },
                { "introspecção", "Exame da própria vida ou sentimentos." },
                { "carinho", "Sentimento de afeto e cuidado." },
                { "felicidade", "Estado de bem-estar e contentamento." },
                { "coração", "Órgão que bombeia sangue, simboliza amor." },
                { "estrela", "Corpo celeste que brilha no céu." },
                { "amigo", "Pessoa com quem se tem uma relação de afeto." },
                { "sabedoria", "Capacidade de fazer julgamentos sensatos." },
                { "ventania", "Vento forte e tempestuoso." },
                { "aventura", "Experiência emocionante e inesperada." },
                { "luz", "Radiação visível que ilumina." },
                { "paz", "Estado de tranquilidade e harmonia." },
                { "natureza", "Conjunto de seres e fenômenos do mundo natural." },
                { "guarda-chuva", "Acessório usado para se proteger da chuva." },
                { "pé-de-moleque", "Doce feito de amendoim e açúcar." },
                { "pérola negra", "Tipo raro de pérola com coloração escura." },
                { "guia turístico", "Pessoa que acompanha e informa sobre um lugar." },
                { "avô materno", "Pai da mãe." }
                #endregion
            };
            
            do 
            {
                int erros = 0;
                // Palavra escolhida pro jogo de forca
                Palavra wrd = new Palavra(listaPalavras.ToArray(),dicas);
                // Versão string da palavra
                string palavra = wrd.Get();
                // Uma lista com todas as letras que o usuário já tentou.
                HashSet<char> letrasRepetidas = new HashSet<char>();

                string cesar = new string('_',palavra.Length);
                string caracteres;

                bool ganhou = false;

                GameMode? modo = null;

                Console.Clear();
                Window.DrawBG();

                do
                {
                    Window.WriteCenter("Escolha o modo de jogo ([S]ingleplayer/[M]ultiplayer): ",0);
                    string modoDeJogo = Console.ReadLine();

                    if (modoDeJogo.ToLower() == "s" || modoDeJogo.ToLower() == "singleplayer")
                    {
                        modo = GameMode.SINGLEPLAYER;
                    }
                    else if (modoDeJogo.ToLower() == "m" || modoDeJogo.ToLower() == "multiplayer")
                    {
                        modo = GameMode.MULTIPLAYER;
                    }
                    else
                    {
                        Window.WriteCenter("Escolha um modo válido!", 1);
                        Window.WriteCenter("Aperte ENTER para continuar.", 2);
                        Console.ReadLine();
                        Window.ClearPos(Console.WindowWidth/2-30, Console.WindowHeight/2+1, 80);
                        Window.ClearPos(Console.WindowWidth/2-30, Console.WindowHeight/2+2, 80);
                    }
                } while(modo == null);

                if (modo == GameMode.MULTIPLAYER)
                {
                    Window.WriteCenter("Escreva uma palavra: ",20);
                    wrd.Set(Console.ReadLine().ToLower());
                    Window.ClearPos(Console.WindowWidth/2-40,Console.WindowHeight/2+20,80);
                    Window.WriteCenter("Escreva uma dica para sua palavra: ",20);
                    wrd.SetDica(Console.ReadLine().ToLower());
                    palavra = wrd.Get();
                    cesar = new string('_', palavra.Length);
                }

                do 
                {
                    if (erros <= 0)
                    {
                        Console.Clear();
                        Window.DrawBG();
                    }

                    Window.PrintCentered(frames[erros]);
                    
                    caracteres = "(" + string.Join(", ", letrasRepetidas.AsEnumerable()) + ")";
                    Window.WriteCenter($"LETRAS ESCOLHIDAS: {caracteres}", Console.WindowHeight/2-4);
                    Window.WriteCenter($"ERROS: {erros}", Console.WindowHeight/2-3);

                    if (erros >= 6)
                    {
                        ganhou = false;
                        break;
                    }

                    Window.ClearPos(Console.WindowWidth/2-40,Console.WindowHeight/2+22,80);
                    Window.WriteCenter(cesar,20);
                    Window.WriteCenter("Escreva uma letra: ",21);

                    string read = Console.ReadLine().Trim(' ').ToLower();
                    char letra = read[0];
                    if (new string(read).ToLower() == "dica")
                    {
                        Window.WriteCenter(wrd.GetDica(palavra),22);
                        Window.WriteCenter("Pressione ENTER para continuar",23);
                        Console.ReadLine();
                        Window.ClearPos(Console.WindowWidth/2-40,Console.WindowHeight/2+22,80);
                        continue;
                    }
                    else if (!string.IsNullOrEmpty(read) && wrd.HasChar(letra))
                    {
                        // O jogador ganhará imediatamente se ele digitar a palavra inteira.
                        if (string.Compare(read, palavra, CultureInfo.CurrentCulture, CompareOptions.IgnoreNonSpace | CompareOptions.IgnoreCase) == 0)
                        {
                            cesar = palavra;
                        }
                        else if (letrasRepetidas.Contains(letra))
                        {
                            Window.WriteCenter("Você já escolheu essa letra!",22);
                            Thread.Sleep(1000);
                        }
                        else
                        {
                            char[] cesarArray = cesar.ToCharArray();

                            for (int i = 0; i < palavra.Length; i++)
                            {
                                if (string.Compare(palavra[i].ToString(), letra.ToString(), CultureInfo.CurrentCulture, CompareOptions.IgnoreNonSpace | CompareOptions.IgnoreCase) == 0)
                                {
                                    cesarArray[i] = palavra[i];
                                }
                            }
                            cesar = new string(cesarArray);
                        }
                    }
                    else
                    {
                        erros++;
                        Window.WriteCenter("Não há essa letra na palavra escolhida!", 22);
                        Thread.Sleep(1000);
                    }
                    letrasRepetidas.Add(letra);

                    if (cesar == palavra)
                    {
                        ganhou = true;
                        break;
                    }

                } while(true);

                if (ganhou)
                {
                    Window.WriteCenter(cesar, 20);

                    Window.ClearPos(Console.WindowWidth/2-40,Console.WindowHeight/2+21,80);
                    deslizaLetras("Parabéns, você ganhou!", 21, 15);
                }
                else
                {
                    Thread.Sleep(1000);
                    Window.PrintCentered(frames[7]);
                    Window.ClearPos(Console.WindowWidth/2-40,Console.WindowHeight/2+22,80);
                    Window.WriteCenter($"A palavra era {wrd.GetFormatted()}",20);
                    Window.WriteCenter("Você perdeu! Aperte ENTER para sair. ",21);
                    Console.ReadLine();
                }

                Window.WriteCenter("Deseja jogar novamente? (s/n): ", 22);

                string retry = Console.ReadLine().Trim().ToLower();

                if (retry == "s" || retry == "sim")
                    continue;
                else
                    break;

            } while(true);

            Window.ClearPos(Console.WindowWidth/2-40,Console.WindowHeight/2+21,80);
            Window.ClearPos(Console.WindowWidth/2-40,Console.WindowHeight/2+22,80);
            Window.WriteCenter("Obrigado por jogar!",20);
            Thread.Sleep(1000);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
        }

        static void deslizaLetras(string str, int yAdd=0, int delay=25)
        {
            string curSub;

            ConsoleColor prevColor = Console.BackgroundColor;

            for (int i=0; i<str.Length; i++)
            {
                Console.BackgroundColor = ConsoleColor.Magenta;
                Console.SetCursorPosition(Console.WindowWidth/2-str.Length/2, Console.WindowHeight/2+yAdd);
                curSub = str.Substring(i, 1);
                for (int j=Console.WindowWidth/2+str.Length/2; j>i+Console.WindowWidth/2-str.Length/2; j--)
                {
                    Console.SetCursorPosition(j, Console.WindowHeight/2+yAdd);
                    Console.Write(curSub + " ");
                    Thread.Sleep(delay);
                }

            }

            Console.BackgroundColor = prevColor;
        }
    }

    class Palavra 
    {
        string _palavra;
        string[] _listaPalavras;

        Dictionary<string,string> _dicas;

        Random _rng;

        public Palavra(string[] list, Dictionary<string,string> dicas)
        {
            _rng = new Random();
            _listaPalavras = list;
            _palavra = _listaPalavras[_rng.Next(0,_listaPalavras.Length)];

            /* 
            * Inicializar o hashmap assim faz com que as keys ignorem a capitalização das palavras.
            * Então, por exemplo `_dicas["CaAtInGa"]`, `_dicas["CAATINGA"]` e `_dicas["caatinga"]`
            * todos retornam a mesma coisa.
            */
            _dicas = new Dictionary<string, string>(dicas, StringComparer.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Usado pro modo multiplayer, onde um dos jogadores tem de escolher
        /// a palavra que o outro irá tentar adivinhar.
        /// </summary>
        public void Set(string palavra)
        {
            _palavra = palavra;
        }

        /// <summary>
        /// Usado pro modo multiplayer, onde um dos jogadores tem de escolher
        /// a palavra que o outro irá tentar adivinhar.
        /// </summary>
        public void SetDica(string dica)
        {
            _dicas[_palavra] = dica;
        }

        public bool HasChar(char character)
        {
            foreach (char s in _palavra)
            {
                if (CharsEqual(s, character))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Essa é uma função que retorna uma dica para o usuário
        /// que irá ajudá-lo a descobrir a palavra atual.
        /// </summary>
        /// <param name="word">A palavra do qual o usuário quer a dica.</param>
        /// <returns>A dica, em uma string.</returns>
        public string GetDica(string word)
        {
            return _dicas[word];
        }

        /// <summary>
        /// Um getter é usado aqui pois a palavra não pode ser alterada, a não ser em seu construtor.
        /// </summary>
        /// <returns>A palavra atual.</returns>
        public string Get() 
        {
            return _palavra;
        }

        /// <summary>
        /// Essa função é usada em lugares como a tela de derrota, onde é mostrado na tela a palavra que
        /// foi sorteada na rodada onde o jogador perdeu.
        /// </summary>
        /// <returns>A palavra atual, formatada</returns>
        /// <example>
        /// <code>
        /// Palavra wrd = new Palavra(["CaAtInGa"],{{"CaAtInGa","Bioma brasileiro"}});
        /// string palavra = wrd.Get(); // Digamos que a palavra escolhida foi CaAtInGa.
        /// palavra = wrd.GetFormatted();
        /// System.Console.WriteLine(palavra); // -> Caatinga
        /// </code>
        /// </example>
        public string GetFormatted() 
        {
            return _palavra[0].ToString().ToUpper() + _palavra.Substring(1).ToLower();
        }

        bool CharsEqual(char char1, char char2)
        {
            if (string.Compare(char1.ToString(), char2.ToString(), CultureInfo.CurrentCulture, CompareOptions.IgnoreNonSpace | CompareOptions.IgnoreCase) == 0)
            {
                return true;
            }
            
            return false;
        }
    }

    enum GameMode 
    {
        SINGLEPLAYER,
        MULTIPLAYER
    }
}