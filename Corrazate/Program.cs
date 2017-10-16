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
            /*
             *****  1x 0
             ***    2x 1,2
             **     2x 3,4
             *      4x 5,6,7,8                
             */

            Console.WriteLine("LODĚ");
            /*Legenda : 
             X = Zásah lodě!
            ! = potopená loď! 
            @ = mimo
             ~ = voda
             
             
             */
            Console.WriteLine("Vyberte typ hry: \n1. Proti počítači\n2. Proti dalšímu hráči");
            int vyber = DokudCislo();
            switch (vyber)
            {
                case 1:
                    HracPocitac();
                    break;
                case 2:
                    HracHrac();
                    break;
                default:
                    Console.WriteLine("Takovou možnost nemáme :( ");
                    break;
            }
        }


        static void HracPocitac()
        {

            // VYTVOŘENÍ POLE S LODĚMA HRÁČE 0 0 0 0 A PROMĚNNÝCH
            #region
            Random rnd = new Random();
            // Lichý = sloupce, X, Sudý = řádky, Y
            int[,] lode = new int[10, 10];
            for (int x = 0; x < 10; x++) { for (int y = 0; y < 10; y++) { lode[x, y] = 0; } }

            int[,] lodePC = new int[10, 10];
            for (int x = 0; x < 10; x++) { for (int y = 0; y < 10; y++) { lodePC[x, y] = 0; } }

            int[,] druhy = new int[10, 20];


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
            //________________________________________________________________________________________

            //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            //Z A D Á V Á N Í  L O D Í  U Ž I V A T E L E M 
            #region
            // m = počet lodí 

            for (int m = 0; m < 8; m++)
            {
                
                //VÝPIS MAPY______________________________________________________________________
                #region
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
                //K O N E C VÝPISU MAPY ________________________________________________________________
                #endregion

                bool zadano = true;
                
                //Z A D Á V Á N Í ______________________________________________________________________
                while (zadano)
                {
                    int kam = 0;
                    Console.WriteLine("Umisťujete loď typu:" + typylodi[typlodeID]);
                    int delkalode = delkylodi[typlodeID];
                    //------------------------------------------------
                    Console.Write("Zadejte číslo sloupce na kterém bude loď začínat 0-9: ");
                    int Uy = DokudCislo();
                                        //------------------------------------------------
                    Console.Write("Zadejte číslo řádku na kterém bude loď začínat 0-9 : ");
                    int Ux = DokudCislo();
                    //jakým směrem
                    Console.Write("Jakým směrem loď půjde?: 1 vodorovně _ 2 vertikálně:");
                    kam = DokudCislo();

                    string pouzito = "N";
                    if (kam == 1)
                    {
                        //foreach ux uy podle pozic kde bude loď
                        for (int l = 0; l < delkalode; l++)
                        {
                            //je už tam obsazeno?
                            try
                            {
                                //lode[Ux, Uy + l] = 3;
                                if (lode[Ux, Uy + l] == 1)
                                {

                                    pouzito = "A";
                                }
                            }
                            catch (IndexOutOfRangeException ior)
                            {
                                //pokud je index mimo pole = > nejde to tam dát
                                pouzito = "M";

                            }
                        }

                        if (pouzito == "A")
                        {
                            Console.WriteLine("Tuto pozici již máte obsazenou");
                            //Console.Clear();
                        } else if (pouzito == "M")
                        {
                            Console.WriteLine("Loď zasahuje mimo hrací pole");
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
                            try
                            {
                                //lode[Ux, Uy + l] = 3;
                                if (lode[Ux, Uy + l] == 1)
                                {

                                    pouzito = "A";
                                }
                            }
                            catch (IndexOutOfRangeException ior)
                            {
                                //pokud je index mimo pole = > nejde to tam dát
                                pouzito = "M";

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
                    /*else if (kam == 3)
                    {
                        Console.WriteLine("Vložena špatná hodnota");
                    }*/

                }
            }

            //K O N E C  Z A D Á V Á N Í 
            #endregion
            //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

            //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            //ZADÁNÍ POČÍTAČOVÝCH LODÍ
            //
            #region
            int[,] druhyPC = new int[10, 20];
            int TLID = 0;
            //bool PCZ = true;
            for (int m = 0; m < 8; m++)
            {
                bool PCZ = true;
                while (PCZ)
                {

                    //Console.WriteLine("Umisťujete loď typu:" + typylodi[typlodeID]);
                    int delkalode = delkylodi[TLID];
                    //Console.Write(delkalode);
                    //Console.ReadLine();
                    //------------------------------------------------
                    //Console.Write("Zadejte číslo sloupce na kterém bude loď začínat 0-9: ");
                    int Uy = rnd.Next(9);
                    //Console.Write(Uy);
                    //Console.ReadLine();
                    //RANDINT
                    //------------------------------------------------
                    //Console.Write("Zadejte číslo řádku na kterém bude loď začínat 0-9 : ");
                    int Ux = rnd.Next(9);
                    //Console.Write(Ux);
                    //Console.ReadLine();
                    //RANDINT


                    //rnd.Next(9);
                    //jakým směrem
                    //Console.Write("Jakým směrem loď půjde?: 1 vodorovně _ 2 vertikálně:");
                    int kam = rnd.Next(0, 2);
                    string pouzito = "N";
                    if (kam == 0)
                    {
                        //foreach ux uy podle pozic kde bude loď
                        for (int l = 0; l < delkalode; l++)
                        {
                            //je už tam obsazeno?
                            try
                            {
                                //lode[Ux, Uy + l] = 3;
                                if (lodePC[Ux, Uy + l] == 1)
                                {
                                    pouzito = "A";
                                }
                            }
                            catch (IndexOutOfRangeException ior)
                            {
                                //pokud je index mimo pole = > nejde to tam dát
                                pouzito = "M";

                            }
                        }

                        if (pouzito == "A")
                        {
                            //Console.WriteLine("Tuto pozici již máte obsazenou");
                            //Console.Clear();
                        }
                        else if (pouzito == "M")
                        {
                            //Console.WriteLine("Loď zasahuje mimo hrací pole");
                        }
                        else
                        {
                            //zadání :: 
                            int ctr = 0;
                            for (int l = 0; l < delkalode; l++)
                            {
                                lodePC[Ux, Uy + l] = 1;
                                druhyPC[typlodeID, ctr] = Ux;
                                ctr = ctr + 1;
                                druhyPC[typlodeID, ctr] = Uy + l;
                                ctr = ctr + 1;
                            }
                            // Console.WriteLine("První souřadnice lodě s ID 0 jsou:" + druhy[0, 0] + druhy[0, 1]);

                            TLID = TLID + 1;
                            PCZ = false;
                            Console.Clear();
                        }
                    }
                    else if (kam == 1)
                    {
                        //příp. dodělat if loď hned vedle jiný lodě
                        for (int l = 0; l < delkalode; l++)
                        {
                            try
                            {
                                //lode[Ux, Uy + l] = 3;
                                if (lodePC[Ux, Uy + l] == 1)
                                {

                                    pouzito = "A";
                                }
                            }
                            catch (IndexOutOfRangeException ior)
                            {
                                //pokud je index mimo pole = > nejde to tam dát
                                pouzito = "M";

                            }
                        }

                        if (pouzito == "A")
                        {
                           //Console.WriteLine("Tuto pozici již máte obsazenou");
                            //Console.Clear();
                        }
                        else if (pouzito == "M")
                        {//znova
                        }
                        else
                        {
                            //Zadání lodě
                            //if(lode Ux+1,Uy == plná => nejde to) try? 
                            int ctr = 0;
                            for (int l = 0; l < delkalode; l++)
                            {
                                lodePC[Ux + l, Uy] = 1;
                                druhyPC[typlodeID, ctr] = Ux + l;
                                ctr = ctr + 1;
                                druhyPC[typlodeID, ctr] = Uy;
                                ctr = ctr + 1;
                            }
                            //                            Console.WriteLine("První souřadnice lodě s ID 0 jsou:" + druhy[0, 0] + druhy[0, 1]);

                            TLID = TLID + 1;
                            PCZ = false;
                            Console.Clear();
                        }
                    }


                }
            }
            #endregion

#region
            /*
            
            //VÝPIS MAPY______________________________________________________________________
            //VÝPIS PRVNÍHO ŘÁDKU
            Console.WriteLine("Lodě Počítače :) ");
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
                    if (lodePC[r, s] == 0)
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
            Console.ReadLine();
            //K O N E C VÝPISU MAPY ________________________________________________________________
            
    */
#endregion   
            //::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

            //::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            //proměnné
            #region
            bool hit = true;
            //vystřeleno počítač
            int[,] vystreleno = new int[10, 10];
            //naplnění 0
            for (int x = 0; x < 10; x++) { for (int y = 0; y < 10; y++) { vystreleno[x, y] = 0; } }

            //vystřeleno uživatel
            int[,] vystrelenoUZI = new int[10, 10];
            //naplnění 0
            for (int x = 0; x < 10; x++) { for (int y = 0; y < 10; y++) { vystrelenoUZI[x, y] = 0; } }

            //Pole se zasaženými loděmi počítače
            int[,] zasahy = new int[10, 10];
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    zasahy[x, y] = 0;
                }
            }
            //Pole se zasaženými loděmi uživatele (1)
            int[,] zasahyUZI = new int[10, 10];
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    zasahyUZI[x, y] = 0;
                }
            }
            //Random rnd = new Random();
            #endregion

            //je dohráno??
            bool won = true;
            //_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_- HRA_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-
            while (won)
            {
                hit = true;
                //A U T O  S T Ř Í L E N Í  P O Č Í T A Č E::::::::::::::::::::::::::::::::::::::::::::::
                while (hit)
                {

                    int Rx = rnd.Next(9);
                    int Ry = rnd.Next(9);
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
                        Console.WriteLine("Počítač střílí X:" + Rx + " a Y:" + Ry);

                        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
                        //ZAZ == 0 ?! 
                       
                        int[] pocty = new int[] { 5, 3, 3, 2, 2, 1, 1, 1, 1 };

                        //POTOPENÍ CELÉ LODĚ :::::::::::::::::::::::::::::::::::::::::
                        int celkem = 0;
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
                                    //zaz = zaz - 1;
                                    // ! nevyjde to 
                                    //break
                                }
                                y = y + 2;
                            }
                            //Console.WriteLine("ZAZ JE " + zaz);
                            if (zaz == pocty[t])
                            {
                                celkem = celkem + 1;
                                int p = 0;
                                for (int u = 0; u < pocty[t]; u++)
                                {
                                    int b = p + 1;
                                    zasahy[druhy[t, p], druhy[t, b]] = 2;
                                    p = p + 2;
                                }
                                //přepsat " X " na " ° "
                                
                            }
                            if (celkem == 8)
                            {
                                Console.WriteLine("Konec hry! vyhrál Počítač!!");
                                Console.ReadLine();
                                won = true;
                            }

                        }
                        //KONEC POTOPENÍ CELÉ LODI::::::::::::::::::::::::::::::::::::

                        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

                        //_________________________ M   A    P    A   Z Á S A H Ů    P O Č Í T A Č E  ___


                        //VÝPIS MAPY_________________________________________________

                        //VÝPIS PRVNÍHO ŘÁDKU
                        Console.Write(" ");
                        for (int l = 0; l < 10; l++)
                        {
                            Console.Write(" " + l + " ");
                        }
                        Console.Write("\n");
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
                        //KONEC VÝPISU MAPY__________________________________________
                        //Console.ReadLine();

                        //druhá osoba hraje 
                        hit = false;
                    }

                    else if (vystreleno[Rx, Ry] == 1)
                    {
                        //NA TUTO POZICI SE JIŽ STŘÍLELO = NEDĚLAT NIC
                        //ZKUSIT TREFIT ZNOVA                   
                    }
                }
                //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

                // S T Ř Í L E N Í  U Ž I V A T E L E :::::::::::::::::::::::::::::::::::::::::::::::::::               
                Console.Write("LEGENDA : \nX = Zásah lodě!\n! = Potopená loď!\n@ = Zásah mimo\n~ = Voda\n");         
                Console.Write("\n\n\n VAŠE LODĚ \n");
                #region
                //VÝPIS MAPY______________________________________________________________________
                    //VÝPIS PRVNÍHO ŘÁDKU
                    Console.Write(" ");
                    for (int l = 0; l < 10; l++)
                    {
                        Console.Write(" " + l + " ");
                    }
                    Console.Write("\n");


                    //VÝPIS CELK. MAPY
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

                                Console.Write(" O ");

                            }
                            //Console.Write(lode[r, n]);

                        }
                        Console.Write("\n");
                    }
                //K O N E C VÝPISU MAPY ________________________________________________________________



                #endregion
                Console.Write("(Enter)");
                Console.ReadLine();
                Console.Clear();
               
                //VYPSAT MAPU VÝSTŘELŮ UŽIVATELE

                //VÝPIS MAPY_________________________________________________
                #region
                //VÝPIS PRVNÍHO ŘÁDKU
                Console.Write(" ");
                for (int l = 0; l < 10; l++)
                {
                    Console.Write(" " + l + " ");
                }
                Console.Write("\n");
                for (int r = 0; r < 10; r++)
                {
                    Console.Write(r);
                    for (int s = 0; s < 10; s++)
                    {
                        //Console.Write(r);
                        if (vystrelenoUZI[r, s] == 0)
                        {
                            Console.Write(" ~ ");
                        }
                        else if (zasahyUZI[r, s] == 1)
                        {
                            //zásah
                            Console.Write(" X ");
                        }
                        else if (zasahyUZI[r, s] == 2)//else if
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
                #endregion
                //KONEC VÝPISU MAPY__________________________________________
                //Console.ReadLine();


                Console.Write("\n\nKam Vystřelíte?\nŘádek: ");
                int radek = DokudCislo();
                Console.Write("\nSloupec: ");
                int sloupec = DokudCislo();
                hit = true;
                //S T Ř E L B A 
                while (hit)
                {
                    //Console.Readline();
                    if (vystrelenoUZI[radek, sloupec] == 0)
                    {
                        //pokud ještě nebylo stříleno na to místo
                        vystrelenoUZI[radek, sloupec] = 1;
                        //IF ZÁSAH
                        if (lodePC[radek, sloupec] == 1)
                        {
                            zasahyUZI[radek, sloupec] = 1;
                            //hit = false;
                        }
                        Console.Clear();
                        Console.WriteLine("Střílíte na pozice X:" + radek + " a Y:" + sloupec);
                        Console.Write("LEGENDA : \nX = Zásah lodě!\n! = Potopená loď!\n@ = Zásah mimo\n~ = Voda\n");
                        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
                        //ZAZ == 0 ?! 


                        int[] pocty = new int[] { 5, 3, 3, 2, 2, 1, 1, 1, 1 };

                        //POTOPENÍ CELÉ LODĚ :::::::::::::::::::::::::::::::::::::::::
                        int celkem = 0;
                        for (int t = 0; t < 9; t++)
                        {
                            int zaz = 0;
                            int y = 0;

                            for (int u = 0; u < pocty[t]; u++)
                            {
                                //t = id lode
                                int b = y + 1;
                                if (zasahyUZI[druhyPC[t, y], druhyPC[t, b]] == 1)
                                {
                                    //něco zasaženýho
                                    zaz = zaz + 1;
                                }
                                else if (zasahyUZI[druhyPC[t, y], druhyPC[t, b]] == 0)
                                {
                                    //zaz = zaz - 1;
                                    // ! nevyjde to 
                                    //break
                                }
                                y = y + 2;
                            }
                            //Console.WriteLine("ZAZ JE " + zaz);
                            if (zaz == pocty[t])
                            {
                                celkem = celkem + 1;
                                int p = 0;
                                for (int u = 0; u < pocty[t]; u++)
                                {
                                    int b = p + 1;
                                    zasahyUZI[druhyPC[t, p], druhyPC[t, b]] = 2;
                                    p = p + 2;
                                    
                                }
                                //přepsat " X " na " ° 
                            }
                            if(celkem == 8)
                            {
                                Console.WriteLine("Konec hry! vyhrál uživatel!");
                                Console.ReadLine();
                                won = true;
                            }
                        }
                        //KONEC POTOPENÍ CELÉ LODI::::::::::::::::::::::::::::::::::::

                        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

                        //_________________________ M   A    P    A   Z Á S A H Ů  ___


                        //VÝPIS MAPY_________________________________________________
                        Console.WriteLine("\n");
                        //VÝPIS PRVNÍHO ŘÁDKU
                        Console.Write(" ");
                        for (int l = 0; l < 10; l++)
                        {
                            Console.Write(" " + l + " ");
                        }
                        Console.Write("\n");
                        for (int r = 0; r < 10; r++)
                        {
                            Console.Write(r);
                            for (int s = 0; s < 10; s++)
                            {
                                //Console.Write(r);
                                if (vystrelenoUZI[r, s] == 0)
                                {
                                    Console.Write(" ~ ");
                                }
                                else if (zasahyUZI[r, s] == 1)
                                {
                                    //zásah
                                    Console.Write(" X ");
                                }
                                else if (zasahyUZI[r, s] == 2)
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
                        //KONEC VÝPISU MAPY__________________________________________
                        //Console.ReadLine();

                        //druhá osoba hraje 
                        hit = false;
                    }
                    else if (vystrelenoUZI[radek, sloupec] == 1)
                    {
                        Console.WriteLine("Na tuto pozici jste již střílel!(Enter)");
                        Console.ReadLine();//NA TUTO POZICI SE JIŽ STŘÍLELO = NEDĚLAT NIC
                        //ZKUSIT TREFIT ZNOVA                   
                    }


                }
                //vypsat zásahy uživatele
                Console.Write("(Enter)");
                Console.ReadLine();
                hit = true;

                //if zasahy = lodě, == konec
                //Výhra = won = true;
                //
            }
            Console.WriteLine("Konec hry!");

        }


        static void HracHrac()
        {
            Console.WriteLine("Zvolili jste hru proti dalšímu hráči");



        }


        static int DokudCislo()
        {
            bool incislo = true;
            int returnCislo = 0;
            while (incislo)
            {
                string inputcisla = Console.ReadLine();
                try
                {
                    int cisloparse = int.Parse(inputcisla);
                    returnCislo = cisloparse;
                    incislo = false;
                }
                catch (Exception e)
                {
                    Console.Write(" ! Nesprávný vstup !\n");
                }
            }
            return returnCislo;


        }
    }
}


