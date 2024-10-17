namespace Forca
{
    using System;
    using System.Threading;
    using System.Globalization;
    using System.Collections.Generic;
    class Forca
    {
        static void Main()
        {
            string[] listaPalavras = {
                "amarelo",
                "miserável",
                "caatinga",
                "transeunte",
                "quarentena",
                "pokémon"
            };

            Random rng = new Random();

            // Palavra escolhida pro jogo de forca
            string palavra;
            List<char> letrasRepetidas = new List<char>();

            int erros = 0;

            //Hashmap com as dicas para cada palavra
            Dictionary<string,string> dicas = new Dictionary<string,string>();
            dicas.Add("amarelo", "Cor do maior astro próximo da terra");
            dicas.Add("miserável", "Antônimo da palavra pobre");
            dicas.Add("caatinga", "Bioma brasileiro");
            dicas.Add("transeunte", "Aquele ou aquilo em constante movimento");
            dicas.Add("quarentena", "Sinônimo de isolação");
            dicas.Add("pokemon", "Jogo da Nintendo que têm monstrinhos");

            palavra = listaPalavras[rng.Next(0,listaPalavras.Length)];

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
                string read = Console.ReadLine().Trim(' ');
                char letra = read.ToCharArray()[0];
                if (read == "dica")
                {
                    Window.WriteCenter(dicas[palavra],2);
                }
                else if (letrasRepetidas.Contains(letra))
                {
                    Window.WriteCenter("Você já escolheu essa letra!",2);
                    Thread.Sleep(500);
                }
                else
                {
                    bool found = false;
                    char[] cesarArray = cesar.ToCharArray();
                    letrasRepetidas.Add(letra);

                    for (int i = 0; i<palavra.Length; i++)
                    {
                        if (string.Compare(palavra[i].ToString(), letra.ToString(), CultureInfo.CurrentCulture, CompareOptions.IgnoreNonSpace | CompareOptions.IgnoreCase) == 0)
                        {
                            cesarArray[i] = palavra[i];
                            found = true;
                        }
                    }

                    cesar = new string(cesarArray);

                    if (!found)
                    {
                        erros++;
                        Window.WriteCenter("Não há essa letra na palavra escolhida!", 2);
                        Window.WriteCenter($"ERROS: {erros}", Console.BufferHeight/2-3);
                        Thread.Sleep(500);
                    }
                }
            } while(cesar != palavra);

            Window.WriteCenter(cesar,0);
            Thread.Sleep(500);
            Console.Clear();
        }

        static string fmt(string str) 
        {
            return str[0].ToString().ToUpper() + str.Substring(1).ToLower();
        }
    }
}