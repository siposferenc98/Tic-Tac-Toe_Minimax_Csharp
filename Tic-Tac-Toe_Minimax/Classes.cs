using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe_Minimax
{
    public class Lepes
    {
        public static int nyerolehetosegek(char[,] tabla)
        {
            //sorwin
            for(int sorba = 0; sorba < 3; sorba++)
            {
                if(tabla[sorba,0] == tabla[sorba,1] && tabla[sorba,1] == tabla[sorba,2])
                {
                    if (tabla[sorba, 0] == Minimax.jatekos)
                        return 1;
                    else if (tabla[sorba, 0] == Minimax.ellenfel)
                        return -1;
                }
            }
            //oszlopwin
            for (int oszlopba = 0; oszlopba < 3; oszlopba++)
            {
                if (tabla[0,oszlopba] == tabla[1,oszlopba] && tabla[1,oszlopba] == tabla[2,oszlopba])
                {
                    if (tabla[0,oszlopba] == Minimax.jatekos)
                        return 1;
                    else if (tabla[0,oszlopba] == Minimax.ellenfel)
                        return -1;
                }
            }
            //átló
            if (tabla[0, 0] == tabla[1, 1] && tabla[1, 1] == tabla[2, 2])
            {
                if (tabla[0, 0] == Minimax.jatekos)
                    return 1;
                else if (tabla[0, 0] == Minimax.ellenfel)
                    return -1;
            }

            if (tabla[0, 2] == tabla[1, 1] && tabla[1, 1] == tabla[2, 0])
            {
                if (tabla[0, 2] == Minimax.jatekos)
                    return 1;
                else if (tabla[0, 2] == Minimax.ellenfel)
                    return -1;
            }

            return 0;
        }
    }

    public class Tabla
    {
        public static char[,] tablazat;
        public static bool emberjon;
        public static int Esor = 2;
        public static int Eoszlop = 2;


        public static void Rajzol(string a, int x, int y)
        {
            Console.SetCursorPosition(Esor + x, Eoszlop + y);
            Console.Write(a);

        }

        public static void Rajzol()
        {


            for (int i = 1; i < 16; i++)
            {
                Rajzol("|", 0, i);
            }

            for (int i = 1; i < 60; i++)
            {
                Rajzol("-", i, 16);
            }

            for (int i = 15; i > 0; i--)
            {
                Rajzol("|", 60, i);
            }

            for (int i = 59; i > 0; i--)
            {
                Rajzol("-", i, 0);
            }

            for (int i = 1; i < 16; i++)
            {
                Rajzol("|", 20, i);
            }

            for (int i = 1; i < 16; i++)
            {
                Rajzol("|", 40, i);
            }


            for (int i = 1; i < 60; i++)
            {
                Rajzol("-", i, 5);
            }

            for (int i = 1; i < 60; i++)
            {
                Rajzol("-", i, 10);
            }

            
        }

        public static void Kiir()
        {
            
            
            Rajzol(Convert.ToString(tablazat[0, 0]), 10, 3);
            Rajzol(Convert.ToString(tablazat[0, 1]), 30, 3);
            Rajzol(Convert.ToString(tablazat[0, 2]), 50, 3);
            Rajzol(Convert.ToString(tablazat[1, 0]), 10, 8);
            Rajzol(Convert.ToString(tablazat[1, 1]), 30, 8);
            Rajzol(Convert.ToString(tablazat[1, 2]), 50, 8);
            Rajzol(Convert.ToString(tablazat[2, 0]), 10, 13);
            Rajzol(Convert.ToString(tablazat[2, 1]), 30, 13);
            Rajzol(Convert.ToString(tablazat[2, 2]), 50, 13);


            


        }

        public static void kiir()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(tablazat[i, j]+" ");
                }
                Console.WriteLine();
            }
        }

        public static void emberlepes()
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.Write("Első játékos: "+ Minimax.jatekos);
            Rajzol();
            Kiir();

            int x = 70;
            int y = 5;
            
            
            List<int[]> helyek = new List<int[]>();
            
            for (int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                { 
                   if(tablazat[i,j] == '_')
                   {
                        int[] par = new int[] { i, j };
                        helyek.Add(par);
                   }
                }
            }
            Console.SetCursorPosition(x, y);
            Console.WriteLine("Hova szeretnél tenni?(SOR | OSZLOP): ");
            int szamlalo = 0;
            foreach (int[] a in helyek)
            {
                
                
                y++;
                Console.SetCursorPosition(x, y);
                Console.Write(szamlalo + ". lehetőség: ");
                szamlalo++;
                foreach (int b in a)
                {
                    
                    Console.Write(b+1+" ");
                }
                Console.WriteLine();
            }
            Console.SetCursorPosition(0, 20);
            int lepes = 0;
            try
            {
                lepes = Convert.ToInt32(Console.ReadLine());
                tablazat[helyek[lepes][0], helyek[lepes][1]] = Minimax.jatekos;
            }
            catch (Exception)
            {
                emberlepes();
            }
            
            emberjon = false;
            


        }

        public static void gep()
        {
            Ellenfel_lepes geplepese = Minimax.legjobblepes(tablazat);
            tablazat[geplepese.sor, geplepese.oszlop] = Minimax.ellenfel;
            emberjon = true;
            //Console.Clear();
            //Console.WriteLine("Ide léptem: "+geplepese.sor+" "+geplepese.oszlop);
            //kiir();
        }

        public static void emberlepes2()
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.Write("Első játékos: " + Minimax.ellenfel);
            Rajzol();
            Kiir();

            int x = 70;
            int y = 5;
           
            List<int[]> helyek = new List<int[]>();

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (tablazat[i, j] == '_')
                    {
                        int[] par = new int[] { i, j };
                        helyek.Add(par);
                    }
                }
            }
            Console.SetCursorPosition(x, y);
            Console.WriteLine("Hova szeretnél tenni?(SOR | OSZLOP): ");
            int szamlalo = 0;
            foreach (int[] a in helyek)
            {
                
                y++;
                Console.SetCursorPosition(x, y);
                Console.Write(szamlalo + ". lehetőség: ");
                szamlalo++;
                foreach (int b in a)
                {

                    Console.Write(b + 1 + " ");
                }
                Console.WriteLine();
            }
            Console.SetCursorPosition(0, 20);
            int lepes = 0;
            try
            {
                lepes = Convert.ToInt32(Console.ReadLine());
                tablazat[helyek[lepes][0], helyek[lepes][1]] = Minimax.ellenfel;
            }
            catch(Exception)
            {
                emberlepes2();
            }
            
            emberjon = true;
            


        }


        public static int ureshelyek(char[,] t)
        {
            int darab = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if(tablazat[i,j] == '_')
                    {
                        darab++;
                    }
                }
            }
            return darab;
        }



    }
}
