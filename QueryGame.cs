using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using System.Threading;

namespace Abfragespiel
{
    class Program
    {
        static void Main(string[] args)
        {
            var words = new List<string>();
            var first = new List<string>();
            var second = new List<string>();
            Stopwatch stopwatch = new Stopwatch();
            var list = File.ReadAllLines(@"C:\Users\greyf\OneDrive - BBBaden\IMS\BBB\Lernatelier\403\Abfragespiel\Abfragespiel\Abfragespiel\words.txt");
            foreach (var line in list) words.Add(line);
            Console.WriteLine("Hier können Sie Ihre Wörter lernen.");
            Console.WriteLine("Stellen Sie sicher, dass Sie Ihre Liste mit dem richtigen Pfad im Code eingefügt haben.");
            Console.WriteLine("Der Highscore wird wie folgt berechnet:");
            Console.WriteLine("1. Mal richtig = 2 Punkte");
            Console.WriteLine("2. & und 3. Mal = 1 Punkt");
            Console.WriteLine("mehr als 3 Versuche = 0 Punkte");
            Console.WriteLine("Drücken Sie Enter um zu starten");
            Console.ReadLine();
            int Highscore = 0;
            string rep = "ja";
            int counter = 0;
            stopwatch.Start();
            while (rep == "ja")
            {
                counter++;
                Console.WriteLine("Wählen Sie 0 um auf Deutsch oder 1 um in die Fremdsprache zu übersetzen.");
                int x = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                int lenght = words.Count;
                if (x == 0)
                {
                    for (int i = 0; i < lenght; i += 2)
                    {
                        int indexOfWord = words.IndexOf(words[x]);
                        Console.WriteLine(words[indexOfWord]);
                        string eingabe = Console.ReadLine();

                        if (eingabe == words[indexOfWord + 1])
                        {
                            Console.WriteLine("Richtige Antwort!");
                            string eng = words[indexOfWord];
                            string deu = words[indexOfWord + 1];
                            words.RemoveAt(indexOfWord);
                            words.RemoveAt(indexOfWord);
                            if (counter == 1)
                            {
                                first.Add(eng);
                                first.Add(deu);
                                Highscore += 2;
                            }
                            else if (counter >= 4)
                            {
                                second.Add(eng);
                                second.Add(deu);
                                
                            }
                            else
                            {
                                second.Add(eng);
                                second.Add(deu);
                                Highscore += 1;
                            }

                        }
                        else
                        {
                            Console.WriteLine($"Falsche Antwort. Die richtige Antwort wäre {words[indexOfWord + 1]}."); 
                            Console.WriteLine("Falls Ihre Antwort doch richtig ist, drücken Sie bitte T und dann Enter.");
                            Console.WriteLine("Ansonsten können Sie mit Enter fortfahren.");
                            string correct = Console.ReadLine();
                            if (correct == "T")
                            {
                                string eng = words[indexOfWord];
                                string deu = words[indexOfWord + 1];
                                words.RemoveAt(indexOfWord);
                                words.RemoveAt(indexOfWord);
                                if (counter == 1)
                                {
                                    first.Add(eng);
                                    first.Add(deu);
                                    Highscore += 2;
                                }
                                else if (counter >= 4)
                                {
                                    second.Add(eng);
                                    second.Add(deu);

                                }
                                else
                                {
                                    second.Add(eng);
                                    second.Add(deu);
                                    Highscore += 1;
                                }
                            }
                            else
                            {
                                x += 2;
                            }
                        }

                    }
                }
                else if (x == 1)
                {
                    for (int i = 0; i < lenght; i += 2)
                    {
                        int indexOfWord = words.IndexOf(words[x]);
                        Console.WriteLine(words[indexOfWord]);
                        string eingabe = Console.ReadLine();
                        if (eingabe == words[indexOfWord - 1])
                        {
                            Console.WriteLine("Richtige Antwort!");
                            string deu = words[indexOfWord];
                            string eng = words[indexOfWord - 1];
                            words.RemoveAt(indexOfWord - 1);
                            words.RemoveAt(indexOfWord - 1);
                            if (counter == 1)
                            {
                                first.Add(eng);
                                first.Add(deu);
                                Highscore += 2;
                            }
                            else if (counter >= 4)
                            {
                                second.Add(eng);
                                second.Add(deu);

                            }
                            else
                            {
                                second.Add(eng);
                                second.Add(deu);
                                Highscore += 1;
                            }

                        }
                        else
                        {
                            Console.WriteLine($"Falsche Antwort. Die richtige Antwort wäre {words[indexOfWord - 1]}.");
                            Console.WriteLine("Falls Ihre Antwort doch richtig ist, drücken Sie bitte T und dann Enter.");
                            Console.WriteLine("Ansonsten können Sie mit Enter fortfahren.");
                            string correct = Console.ReadLine();
                            if (correct == "T")
                            {
                                string eng = words[indexOfWord];
                                string deu = words[indexOfWord - 1];
                                words.RemoveAt(indexOfWord - 1);
                                words.RemoveAt(indexOfWord - 1);
                                if (counter == 1)
                                {
                                    first.Add(eng);
                                    first.Add(deu);
                                    Highscore += 2;
                                }
                                else if (counter >= 4)
                                {
                                    second.Add(eng);
                                    second.Add(deu);

                                }
                                else
                                {
                                    second.Add(eng);
                                    second.Add(deu);
                                    Highscore += 1;
                                }
                            }
                            else
                            {
                                x += 2;
                            }
                        }


                    }
                }
                else
                {
                    Console.WriteLine("Ungültige Eingabe, bitte versuchen Sie es erneut.");
                }
                if (words.Count > 0)
                {
                    Console.WriteLine("Glückwunsch Sie haben es durchgeschafft.");
                    Console.WriteLine(" Möchten Sie die Wörter, welche Sie falsch hatten nochmals durchgehen? Tippen Sie ja!");
                    rep = Console.ReadLine();
                }
                else
                {
                    rep = "nah";
                }

            }

            Console.Clear();
            stopwatch.Stop();
            TimeSpan ts = stopwatch.Elapsed;
            string Zeit = String.Format("{0:00}:{1:00}", ts.Minutes, ts.Seconds);
            Console.WriteLine("Egal ob Sie nun entweder alle richtig haben oder einfach keine Lust mehr zu wiederholen hatten,");
            Console.WriteLine("Sie haben es geschafft! Herzlichen Glückwunsch!");
            Console.WriteLine($"Ihr Highscore lautet {Highscore}.");
            Console.WriteLine($"Sie haben {Zeit} Minuten gebraucht.");
            Console.WriteLine("Diese Wörter hatten Sie beim 1. Mal bereit korrekt:");
            Console.ReadLine();
            foreach (var item in first)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(" ");
            Console.WriteLine("Diese Wörter sollten Sie vielleicht nochmals üben:");
            Console.ReadLine();
            foreach (var item in second)
            {
                Console.WriteLine(item);
            }

        }
    }
}