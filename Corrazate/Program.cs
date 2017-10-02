using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lode
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("LODĚ");
            #region

            /*
             *****  1x 0
             ***    2x 1,2
             **     2x 3,4
             *      4x 5,6,7,8                
             lodeuzivatele = id lodě,zadáno, x, y
             */
            // pole lodí podle celků
            /*
             * 
             * 
             * 
            int[,] lodeuzivatele = new int[19, 4];
            int g = 5;
            //id lodě
            for (int i = 0; i < 19; i++)
            {
                if (i <= 5)
                {
                    //velká *****
                    //id lodě
                    lodeuzivatele[i, 0] = 0;
                    //zadáno?
                    lodeuzivatele[i, 1] = 0;
                }
                else if (i > 5 && i <= 8)
                {
                    //střední ***
                    lodeuzivatele[i, 0] = 1;
                    lodeuzivatele[i, 1] = 0;
                }
                else if (i > 8 && i <= 11)
                {
                    //střední ***
                    lodeuzivatele[i, 0] = 2;
                    lodeuzivatele[i, 1] = 0;
                }
                else if (i > 11 && i <= 13)
                {
                    //menší **
                    lodeuzivatele[i, 0] = 3;
                    lodeuzivatele[i, 1] = 0;
                }
                else if (i > 13 && i <= 15)
                {
                    //menší **
                    lodeuzivatele[i, 0] = 4;
                    lodeuzivatele[i, 1] = 0;
                }
                else if (i > 15)
                {
                    //ponorky *
                    lodeuzivatele[i, 0] = g;
                    lodeuzivatele[i, 1] = 0;
                    g = g + 1;
                }

            }
            /*
            Console.WriteLine(lodeuzivatele[15,0]);
            Console.WriteLine(lodeuzivatele[16, 0]);
            Console.WriteLine(lodeuzivatele[17, 0]);
            
            
            //for(int i = 0; i < )
            //{id lodě,zadáno(0/1), x(řádek), y(sloupec),}
            Console.WriteLine("loď leží na pozici x : " + lodeuzivatele[0, 1]);


            */
            #endregion

            //VYTVOŘENÍ POLE S LODĚMA HRÁČE 0 0 0 0
            // Lichý = sloupce, X, Sudý = řádky, Y
            int[,] lode = new int[10, 10];
            for (int x = 0; x < 10; x++) { for (int y = 0; y < 10; y++) { lode[x, y] = 0; } }
            //1. hodnota = id lodě, 2. hodnota = souřadnice
            int[,] druhy = new int[10, 20];
            //_____________________________________________________________________
            //Z A D Á V Á N Í  L O D Í  U Ž I V A T E L E M 
            #region
            string[] typylodi = new string[10];
            typylodi[0] = "Letadlová Loď - *****";
            typylodi[1] = "Křižník - ***";
            typylodi[2] = "Křižník - ***";
            typylodi[3] = "Torpédoborec - **";
            typylodi[4] = "Torpédoborec - **";
            for (int t = 5; t < 9; t++) { typylodi[t] = "Ponorka - *"; }
            int[] delkylodi = new int[10];
            delkylodi[0] = 5;
            delkylodi[1] = 3;
            delkylodi[2] = 3;
            delkylodi[3] = 2;
            delkylodi[4] = 2;
            for (int t = 5; t < 9; t++) { delkylodi[t] = 1; }
            int typlodeID = 0;
            #endregion
            // m = počet lodí 

            for (int m = 0; m < 8; m++)
            {
                //:::: VYPSÁNÍ MAPY :::::::::::::::::::::::::::::::::::::::::::::::

                //VÝPIS PRVNÍHO ŘÁDKU
                Console.Write(" ");
                for (int l = 0; l < 10; l++)
                {
                    Console.Write(" " + l + " ");
                }
                Console.Write("\n");


                //VÝPIS MAPY
                for (int r = 0; r < 10; r++)
                {
                    Console.Write(r);
                    for (int s = 0; s < 10; s++)
                    {
                        //Console.Write(r);
                        if (lode[r, s] == 0)
                        {
                            Console.Write(" ~ ");
                        }
                        else
                        {
                            Console.Write(" @ ");
                        }
                        //Console.Write(lode[r, n]);

                    }
                    Console.Write("\n");
                }
                //K O N E C VÝPISU MAPY ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

                bool zadano = true;

                //Z A D Á V Á N Í ______________________________________________________________________
                while (zadano)
                {

                    Console.WriteLine("Umisťujete loď typu:" + typylodi[typlodeID]);
                    Console.Write("Kolik bude mít polí?: ");

                    int delkalode = delkylodi[typlodeID];
                    //------------------------------------------------
                    Console.Write("Zadejte číslo sloupce na kterém bude loď začínat 0-9: ");
                    int Uy = Convert.ToInt32(Console.ReadLine());
                    //------------------------------------------------
                    Console.Write("Zadejte číslo řádku na kterém bude loď začínat 0-9 : ");
                    int Ux = Convert.ToInt32(Console.ReadLine());
                    //!!!!ošetřit vstupy

                    //jakým směrem
                    Console.Write("Jakým směrem loď půjde?: 1 vodorovně _ 2 vertikálně:");
                    int kam = Convert.ToInt32(Console.ReadLine());


                    string pouzito = "N";
                    if (kam == 1)
                    {
                        //foreach ux uy podle pozic kde bude loď
                        for (int l = 0; l < delkalode; l++)
                        {
                            if (lode[Ux, Uy + l] == 1)
                            {
                                pouzito = "A";
                            }
                        }

                        if (pouzito == "A")
                        {
                            Console.WriteLine("Tuto pozici již máte obsazenou");
                            //Console.Clear();
                        }
                        else
                        {
                            //zadání :: 
                            int ctr = 0;
                            for (int l = 0; l < delkalode; l++)
                            {
                                lode[Ux, Uy + l] = 1;
                                druhy[typlodeID, ctr] = Ux;
                                ctr = ctr + 1;
                                druhy[typlodeID, ctr] = Uy + l;
                                ctr = ctr + 1;
                            }
                            //                            Console.WriteLine("První souřadnice lodě s ID 0 jsou:" + druhy[0, 0] + druhy[0, 1]);

                            typlodeID = typlodeID + 1;
                            zadano = false;
                            Console.Clear();
                        }
                    }
                    else if (kam == 2)
                    {
                        //příp. dodělat if loď hned vedle jiný lodě
                        for (int l = 0; l < delkalode; l++)
                        {
                            if (lode[Ux, Uy + l] == 1)
                            {
                                pouzito = "A";
                            }
                        }

                        if (pouzito == "A")
                        {
                            Console.WriteLine("Tuto pozici již máte obsazenou");
                            //Console.Clear();
                        }
                        else
                        {
                            //Zadání lodě
                            //if(lode Ux+1,Uy == plná => nejde to) try? 
                            int ctr = 0;
                            for (int l = 0; l < delkalode; l++)
                            {
                                lode[Ux + l, Uy] = 1;
                                druhy[typlodeID, ctr] = Ux + l;
                                ctr = ctr + 1;
                                druhy[typlodeID, ctr] = Uy;
                                ctr = ctr + 1;
                            }
                            //                            Console.WriteLine("První souřadnice lodě s ID 0 jsou:" + druhy[0, 0] + druhy[0, 1]);

                            typlodeID = typlodeID + 1;
                            zadano = false;
                            Console.Clear();
                        }
                    }

                }
            }

            //_______________________________________________________________________________




            int[,] zasahy = new int[10, 10];
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    zasahy[x, y] = 0;
                }
            }

            //________________________________________________________________________________
            //zadání počítačových lodí
            //

            //________________________________________________________________________________
            //AUTO STŘÍLENÍ POČÍTAČE
            bool hit = true;
            int[,] vystreleno = new int[10, 10];
            //naplnění 0
            for (int x = 0; x < 10; x++) { for (int y = 0; y < 10; y++) { vystreleno[x, y] = 0; } }
            Random rnd = new Random();

            while (hit)
            {
                int Rx = rnd.Next(10);
                int Ry = rnd.Next(10);
                //Console.Readline();
                if (vystreleno[Rx, Ry] == 0)
                {
                    //pokud ještě nebylo stříleno na to místo
                    vystreleno[Rx, Ry] = 1;
                    //IF ZÁSAH
                    if (lode[Rx, Ry] == 1)
                    {
                        zasahy[Rx, Ry] = 1;
                        //hit = false;
                    }
                    Console.Clear();
                    Console.WriteLine("Zkouším trefit X:" + Rx + " a Y:" + Ry);

                    //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
                    //ZAZ == 0 ?! 
                    //FUNGUJE AŽ NA 0,0 , CO TO SAKRA JE
                    int[] pocty = new int[] { 5, 3, 3, 2, 2, 1, 1, 1, 1 };

                    for (int t = 0; t < 9; t++)
                    {
                        int zaz = 0;
                        int y = 0;

                        for (int u = 0; u < pocty[t]; u++)
                        {
                            //t = id lode
                            int b = y + 1;
                            if (zasahy[druhy[t, y], druhy[t, b]] == 1)
                            {
                                //něco zasaženýho
                                zaz = zaz + 1;
                            }
                            else if (zasahy[druhy[t, y], druhy[t, b]] == 0)
                            {
                                zaz = zaz - 1;
                                // ! nevyjde to 
                                //break
                            }
                            y = y + 2;
                        }
                        Console.WriteLine("ZAZ JE " + zaz);
                        if (zaz == pocty[t])
                        {
                            int p = 0;
                            for (int u = 0; u < pocty[t]; u++)
                            {
                                int b = p + 1;
                                zasahy[druhy[t, p], druhy[t, b]] = 2;
                                p = p + 2;
                            }
                            //přepsat " X " na " ° "
                            //Console.WriteLine("ČUUUUUUUUUUUS");
                        }

                    }











                    //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
                    //_________________________ M   A    P    A   Z Á S A H Ů    P O Č Í T A Č E  ___
                    //VÝPIS ZÁSAHŮ

                    //VÝPIS PRVNÍHO ŘÁDKU
                    Console.Write(" ");
                    for (int l = 0; l < 10; l++)
                    {
                        Console.Write(" " + l + " ");
                    }
                    Console.Write("\n");
                    //VÝPIS MAPY
                    for (int r = 0; r < 10; r++)
                    {
                        Console.Write(r);
                        for (int s = 0; s < 10; s++)
                        {
                            //Console.Write(r);
                            if (vystreleno[r, s] == 0)
                            {
                                Console.Write(" ~ ");
                            }
                            else if (zasahy[r, s] == 1)
                            {
                                //zásah
                                Console.Write(" X ");
                            }
                            else if (zasahy[r, s] == 2)//else if
                            {
                                //minul
                                Console.Write(" ! ");
                            }
                            else
                            {
                                Console.Write(" @ ");
                            }
                            //Console.Write(lode[r, n]);

                        }
                        Console.Write("\n");
                    }
                    //druhá osoba hraje :: 
                    //hit = false ? 
                    Console.ReadLine();
                }
                else if (vystreleno[Rx, Ry] == 1)
                {
                    //nedělat nic
                    //hit false?
                }
            }
            //______________________________________________________________________________________
        }
    }
}


