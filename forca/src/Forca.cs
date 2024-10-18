namespace Forca
{
    using System;
    using System.Threading;
    using System.Globalization;
    using System.Collections.Generic;
    class Game
    {
        static List<string> listaPalavras;
        static Dictionary<string,string> dicas;
        static int erros = 0;

        static void Main()
        {
            // Todas as palavras disponíveis para o jogo escolher aleatoriamente 
            listaPalavras = new List<string>() {
                /*"amarelo",
                "miserável",
                "caatinga",
                "transeunte",
                "quarentena",*/
                "pokémon"
            };

            // Hashmap com as dicas para cada palavra
            dicas = new Dictionary<string, string>
            {
                { "amarelo", "Cor do maior astro próximo da terra" },
                { "miserável", "Antônimo da palavra pobre" },
                { "caatinga", "Bioma brasileiro" },
                { "transeunte", "Aquele ou aquilo em constante movimento" },
                { "quarentena", "Sinônimo de isolação" },
                { "pokemon", "Jogo da Nintendo que têm monstrinhos" }
            };

            // Palavra escolhida pro jogo de forca
            Palavra wrd = new Palavra(listaPalavras.ToArray(),dicas);
            // Versão string da palavra
            string palavra = wrd.Get();
            // Uma lista com todas as letras que o usuário já tentou.
            List<char> letrasRepetidas = new List<char>();

            string cesar = new string('_',palavra.Length);

            do 
            {
                if (erros == 0)
                {
                    Console.Clear();
                    Window.DrawBG();
                }

                Window.ClearPos(Console.WindowWidth/2-40,Console.WindowHeight/2+2,80);
                Window.WriteCenter(cesar,0);
                Window.WriteCenter("Escreva uma letra: ",1);
                char[] read = Console.ReadLine().Trim(' ').ToCharArray();
                char letra = read[0];
                if (read.ToString() == "dica")
                {
                    Window.WriteCenter(wrd.GetDica(palavra),2);
                }
                else if (letrasRepetidas.Contains(letra))
                {
                    Window.WriteCenter("Você já escolheu essa letra!",2);
                    Thread.Sleep(500);
                }
                else if (wrd.HasChar(letra))
                {
                    char[] cesarArray = cesar.ToCharArray();
                    letrasRepetidas.Add(letra);

                    for (int i = 0; i < palavra.Length; i++)
                    {
                        if (string.Compare(palavra[i].ToString(), letra.ToString(), CultureInfo.CurrentCulture, CompareOptions.IgnoreNonSpace | CompareOptions.IgnoreCase) == 0)
                        {
                            cesarArray[i] = palavra[i];
                        }
                    }
                    cesar = new string(cesarArray);
                }
                else
                {
                    erros++;
                    Window.WriteCenter("Não há essa letra na palavra escolhida!", 2);
                    Window.WriteCenter($"ERROS: {erros}", Console.BufferHeight/2-3);
                    Thread.Sleep(500);
                }
            } while(cesar != palavra);

            Window.WriteCenter(cesar,0);
            Thread.Sleep(500);
            Console.Clear();
        }

        /*static void Init(palavras)
        {

        }*/
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
}