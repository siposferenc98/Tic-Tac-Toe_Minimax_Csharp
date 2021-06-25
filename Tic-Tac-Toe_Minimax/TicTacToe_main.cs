using System;

namespace Tic_Tac_Toe_Minimax
{

    class TicTacToe_main
    {
        static int valaszt()
        {
            int valasz = 0;
            do
            {
                Console.WriteLine("Válassz ki ellen szeretnél játszani!: ");
                Console.WriteLine("1. Másik játékos ellen           2. AI ellen");
                try
                {
                    valasz = Convert.ToInt32(Console.ReadLine());
                }
                catch(Exception)
                {
                    Console.WriteLine("Nem megfelelő opció!");
                    
                }
            } while (valasz < 1 || valasz > 2);

            return valasz;
        }

        static void kezdes(int valasztas)
        {
            Console.Clear();
            char elso =' ';
            char evalaszt = ' ';
            Console.WriteLine("Válassz mivel szeretnél lenni (o/x): ");
            while(true)
            {
                try
                {
                   evalaszt = Convert.ToChar(Console.ReadLine().ToUpper());
                   if (evalaszt != 'O' || evalaszt != 'X')
                   {
                       throw new Exception();
                   }
                }
                catch(Exception)
                {
                    Console.WriteLine("Nem megfelelő karakter,válassz 'o'-t vagy 'x'-et.");
                }
                if(evalaszt == 'O' || evalaszt == 'X')
                {
                    break;
                }

            }
            Console.Clear();
             
            Minimax.jatekos = evalaszt;
            Minimax.gephelyzet();
            Console.WriteLine("Elsőnek szeretnél kezdeni?(i/n): ");
            while (true)
            {
                try
                {
                    elso = Convert.ToChar(Console.ReadLine());
                    if (elso !='i' || elso != 'n')
                    {
                        throw new Exception();
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Nem megfelelő karakter, írj 'i'-t vagy 'n'-t"); 
                }
                if (elso == 'i' || elso == 'n')
                {
                    break;
                }
            }
            switch (elso)
            {
                case 'i':
                    Tabla.emberjon = true;
                    break;
                case 'n':
                    Tabla.emberjon = false;
                    break;
            }
            Console.Clear();
            switch (valasztas)
            {
                
                case 1:
                    Tabla.Rajzol();
                    p_v_p();
                    break;
                case 2:
                    Tabla.Rajzol();
                    p_v_ai();
                    break;
            }
            
            
        }

        static void p_v_ai()
        {
            while (Tabla.ureshelyek(Tabla.tablazat) > 0 && Lepes.nyerolehetosegek(Tabla.tablazat) == 0)
            {

                if (Tabla.emberjon)
                {
                    
                    Tabla.emberlepes();
                    Lepes.nyerolehetosegek(Tabla.tablazat);
                }
                else
                {
                    Tabla.gep();
                    Lepes.nyerolehetosegek(Tabla.tablazat);
                }

            }

        }

        static void p_v_p()
        {
            while (Tabla.ureshelyek(Tabla.tablazat) > 0 && Lepes.nyerolehetosegek(Tabla.tablazat) == 0)
            {

                if (Tabla.emberjon)
                {
                    Tabla.emberlepes();
                    Lepes.nyerolehetosegek(Tabla.tablazat);
                }
                else
                {
                    Tabla.emberlepes2();
                    Lepes.nyerolehetosegek(Tabla.tablazat);
                }

            }
        }


        static void Main(string[] args)
        {
            char[,] tabla =
            {
                {'_','_','_'},
                {'_','_','_'},
                {'_','_','_'},
            };

            Tabla.tablazat = tabla;

            int valasztas = valaszt();
            kezdes(valasztas);

            Console.Clear();
            Tabla.Rajzol();
            Tabla.Kiir();
            Console.SetCursorPosition(0, 20);
            if (Lepes.nyerolehetosegek(Tabla.tablazat) == 1)
            {
                Console.WriteLine(Minimax.jatekos + " nyert!");
                Console.ReadLine();
            }
            else if (Lepes.nyerolehetosegek(Tabla.tablazat) == -1)
            {
                Console.WriteLine(Minimax.ellenfel + " nyert!");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Döntetlen!");
                Console.ReadLine();
            }





        }
    }
}
