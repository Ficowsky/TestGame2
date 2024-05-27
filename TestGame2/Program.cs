using System;

namespace TestGame2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[,] plansza = new string[3, 3];
            InicjalizujPlansze(plansza);
            bool jestGracz1 = true;
            bool wygrana = false;

            while (true)
            {
                Console.Clear();
                WyswietlPlansze(plansza);

                Console.WriteLine("Gracz {0}, wybierz pozycję (1-9):", jestGracz1 ? "1 (X)" : "2 (O)");
                string input = Console.ReadLine();
                int pozycja;

                if (int.TryParse(input, out pozycja) && pozycja >= 1 && pozycja <= 9)
                {
                    if (WykonajRuch(plansza, pozycja, jestGracz1 ? "X" : "O"))
                    {
                        if (SprawdzWygrana(plansza))
                        {
                            Console.Clear();
                            WyswietlPlansze(plansza);
                            Console.WriteLine("Gracz {0} wygrywa!", jestGracz1 ? "1 (X)" : "2 (O)");
                            wygrana = true;
                            break;
                        }
                        jestGracz1 = !jestGracz1;
                    }
                    else
                    {
                        Console.WriteLine("Pozycja już zajęta. Spróbuj ponownie.");
                    }
                }
                else
                {
                    Console.WriteLine("Nieprawidłowe dane wejściowe. Spróbuj ponownie.");
                }
            }

            if (!wygrana)
            {
                Console.WriteLine("Remis!");
            }
        }

        public static void InicjalizujPlansze(string[,] plansza)
        {
            int licznik = 1;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    plansza[i, j] = licznik.ToString();
                    licznik++;
                }
            }
        }

        public static void WyswietlPlansze(string[,] plansza)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write("  {0}  ", plansza[i, j]);
                    if (j < 2) Console.Write("|");
                }
                Console.WriteLine();
                if (i < 2) Console.WriteLine("-----|-----|-----");
            }
        }

        public static bool WykonajRuch(string[,] plansza, int pozycja, string gracz)
        {
            int rzad = (pozycja - 1) / 3;
            int kolumna = (pozycja - 1) % 3;

            if (plansza[rzad, kolumna] != "X" && plansza[rzad, kolumna] != "O")
            {
                plansza[rzad, kolumna] = gracz;
                return true;
            }
            return false;
        }

        public static bool SprawdzWygrana(string[,] plansza)
        {
            // Sprawdzanie wierszy i kolumn
            for (int i = 0; i < 3; i++)
            {
                if ((plansza[i, 0] == plansza[i, 1] && plansza[i, 1] == plansza[i, 2]) ||
                    (plansza[0, i] == plansza[1, i] && plansza[1, i] == plansza[2, i]))
                {
                    return true;
                }
            }

            // Sprawdzanie przekątnych
            if ((plansza[0, 0] == plansza[1, 1] && plansza[1, 1] == plansza[2, 2]) ||
                (plansza[0, 2] == plansza[1, 1] && plansza[1, 1] == plansza[2, 0]))
            {
                return true;
            }

            return false;
        }
    }
}
