namespace Claudio
{
    using System;
    using System.Globalization;
    using System.Collections.Generic;
    using System.Linq;

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
                "pokemon"
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
            Console.WriteLine(cesar);

            do 
            {
                Console.WriteLine("\nEscreva uma letra: ");
                string read = Console.ReadLine();
                char letra = read.ToCharArray()[0];
                if (read == "dica")
                {
                    Console.WriteLine(dicas[palavra]);
                }
                else if (letrasRepetidas.Contains(letra))
                {
                    Console.WriteLine("Você já escolheu essa letra!");
                }
                else if (palavra.Contains(letra.ToString()))
                {
                    char[] cesarArray = cesar.ToCharArray();
                    letrasRepetidas.Add(letra);

                    for (int i=0; i<palavra.Length; i++) 
                    {
                        if (string.Compare(palavra[i].ToString(), letra.ToString(), CultureInfo.CurrentCulture, CompareOptions.IgnoreNonSpace) == 0)
                        {
                            cesarArray[i] = letra;
                        }
                        cesar = new string(cesarArray);
                    }

                    Console.WriteLine(cesar);
                }
                else 
                {
                    erros++;
                    Console.WriteLine("Não há essa letra na palavra escolhida!");
                    Console.WriteLine($"ERROS: {erros}");
                }
            } while(cesar != palavra);
        }

        static string fmt(string str) 
        {
            return str[0].ToString().ToUpper() + str.Substring(1).ToLower();
        }
    }
}