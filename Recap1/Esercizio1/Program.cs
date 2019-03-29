using System;
using System.Collections.Generic;

namespace Esercizio1
{
    class Program
    {
        //VatNumberNormal
            //int codeId
            //List<decimal> Bills;
            //List<decimal> Expenses;
            //totalBill(somma della lista bills) - expenseTotal(somma della lista Expenses) = profit --> -22% di iva --> 23% irpef;
        //VatNumberSimple
            //int codeId
            //List<decimal> Bills;
            //totalBill (uguale al profit in questo caso) --> sul 78%(di totalBill), tolgo 15% tasse

        //Funzionalità applicazione
            //Console con scelta (infinita fino all'exit)
            //1)aggiungere bill a partitaiva
            //2)aggiungere expense a partitaiva
            //3)calcola guadagno netto e tasse totali di una partita iva
            //4)elenca tutte p.iva
            //5)exit
        static void Main(string[] args)
        {
            int convertedValue;
            int vatCode;
            decimal convertedDecimalValue;
            bool cycle = true;
            
            List<VatNumberNormal> vatsNormal = new List<VatNumberNormal>();
            List<VatNumberSimple> vatsSimple = new List<VatNumberSimple>();

            vatsNormal.Add(new VatNumberNormal());
            vatsNormal.Add(new VatNumberNormal());
            vatsNormal.Add(new VatNumberNormal());
            vatsNormal.Add(new VatNumberNormal());
            vatsNormal.Add(new VatNumberNormal());

            vatsSimple.Add(new VatNumberSimple());
            vatsSimple.Add(new VatNumberSimple());
            vatsSimple.Add(new VatNumberSimple());
            vatsSimple.Add(new VatNumberSimple());
            vatsSimple.Add(new VatNumberSimple());

            vatsNormal[0].CodeId = 1;
            vatsNormal[1].CodeId = 2;
            vatsNormal[2].CodeId = 3;
            vatsNormal[3].CodeId = 4;
            vatsNormal[4].CodeId = 5;

            vatsSimple[0].CodeId = 6;
            vatsSimple[1].CodeId = 7;
            vatsSimple[2].CodeId = 8;
            vatsSimple[3].CodeId = 9;
            vatsSimple[4].CodeId = 10;

            while (cycle)
            {
                bool checkVatN = true;
                bool checkVatS = true;
                decimal totalBill = 0;
                decimal expenseTotal = 0;
                decimal profit = 0;
                int temporalValue = -1;


                Console.Write("1.Add bill to VAT Number\n2.Add expense to VAT Number\n3.Calculate profit of VAT Number\n4.Show all VAT Numbers\n5.Exit\n");

                string input = Console.ReadLine();
                bool conversionOk = int.TryParse(input, out convertedValue);
                while (!conversionOk || convertedValue <= 0 || convertedValue > 5)
                {
                    Console.Clear();
                    Console.Write("1.Add bill to VAT Number\n2.Add expense to VAT Number\n3.Calculate profit of VAT Number\n4.Show all VAT Numbers\n5.Exit\n");
                    Console.WriteLine($"You can insert only the numbers in the menu");
                    input = Console.ReadLine();
                    conversionOk = int.TryParse(input, out convertedValue);
                    Console.Clear();
                }

                switch (convertedValue)
                {
                    case 1:
                        Console.Write("Insert the VAT Number code: ");
                        input = Console.ReadLine();
                        conversionOk = int.TryParse(input, out vatCode);
                        while (!conversionOk || convertedValue <= 0)
                        {
                            Console.Clear();
                            Console.WriteLine($"Code not valid, reinsert code: ");
                            input = Console.ReadLine();
                            conversionOk = int.TryParse(input, out vatCode);
                            Console.Clear();
                        }

                        for (int i = 0; i < vatsNormal.Count; i++)
                        {
                            if (vatCode == vatsNormal[i].CodeId)
                            {
                                temporalValue = i;
                                checkVatS = false;
                                break;
                            }
                        }

                        for (int i = 0; i < vatsSimple.Count; i++)
                        {
                            if (vatCode == vatsSimple[i].CodeId)
                            {
                                temporalValue = i;
                                checkVatN = false;
                                break;
                            }
                        }

                        if (temporalValue == -1)
                        {
                            Console.Write("The VAT number code doesn't exist.\n");
                            break;
                        }

                        Console.Write("Insert the amount: ");
                        input = Console.ReadLine();
                        conversionOk = decimal.TryParse(input, out convertedDecimalValue);
                        while (!conversionOk || convertedDecimalValue <= 0)
                        {
                            Console.Clear();
                            Console.WriteLine($"Amount not valid, reinsert amount: ");
                            input = Console.ReadLine();
                            conversionOk = decimal.TryParse(input, out convertedDecimalValue);
                            Console.Clear();
                        }
                        
                        if (checkVatN)
                            vatsNormal[temporalValue].Bills.Add(convertedDecimalValue);
                        if (checkVatS)
                            vatsSimple[temporalValue].Bills.Add(convertedDecimalValue);

                        break;

                    case 2:
                        Console.Write("Insert the VAT Number code: ");
                        input = Console.ReadLine();
                        conversionOk = int.TryParse(input, out vatCode);
                        while (!conversionOk || convertedValue <= 0)
                        {
                            Console.Clear();
                            Console.WriteLine($"Code not valide, reinsert code: ");
                            input = Console.ReadLine();
                            conversionOk = int.TryParse(input, out vatCode);
                            Console.Clear();
                        }

                        for (int i = 0; i < vatsNormal.Count; i++)
                        {
                            if (vatCode == vatsNormal[i].CodeId)
                            {
                                temporalValue = i;
                                break;
                            }
                            
                        }

                        if(temporalValue == -1)//scrivere anche se il codice inserito corrisponde ad un simple type, se lo è dare errore e dichiararlo
                        {
                            Console.Write("The VAT number code doesn't exist, you can only insert a code of a VAT number Normal type.\n");
                            break;
                        }
                            
                        Console.Write("Insert the amount: ");
                        input = Console.ReadLine();
                        conversionOk = decimal.TryParse(input, out convertedDecimalValue);
                        while (!conversionOk || convertedDecimalValue <= 0)
                        {
                            Console.Clear();
                            Console.WriteLine($"Amount not valid, reinsert amount: ");
                            input = Console.ReadLine();
                            conversionOk = decimal.TryParse(input, out convertedDecimalValue);
                            Console.Clear();
                        }

                        vatsNormal[temporalValue].Expenses.Add(convertedDecimalValue);

                        break;

                    case 3:
                        Console.Write("Insert the VAT Number code: ");
                        input = Console.ReadLine();
                        conversionOk = int.TryParse(input, out vatCode);
                        while (!conversionOk || convertedValue <= 0)
                        {
                            Console.Clear();
                            Console.WriteLine($"Code not valid, reinsert code: ");
                            input = Console.ReadLine();
                            conversionOk = int.TryParse(input, out vatCode);
                            Console.Clear();
                        }

                        for (int i = 0; i < vatsNormal.Count; i++)
                        {
                            if (vatCode == vatsNormal[i].CodeId)
                            {
                                temporalValue = i;
                                checkVatS = false;
                                break;
                            }
                        }

                        for (int i = 0; i < vatsSimple.Count; i++)
                        {
                            if (vatCode == vatsSimple[i].CodeId)
                            {
                                temporalValue = i;
                                checkVatN = false;
                                break;
                            }
                        }

                        if (temporalValue == -1)
                        {
                            Console.Write("The VAT number code doesn't exist.");
                            break;
                        }

                        if (checkVatN)
                        {
                            for (int j = 0; j < vatsNormal[temporalValue].Bills.Count; j++)
                            {
                                totalBill = totalBill + vatsNormal[temporalValue].Bills[j];
                                expenseTotal = expenseTotal + vatsNormal[temporalValue].Expenses[j];
                            }
                            profit = profit - ((profit * 22) / 100) - ((profit * 23) / 100);
                            Console.Write($"The profit of this VAT number is: {profit} subtracted with 22% of IVA and 23% of IRPEF");
                            break;
                        }
                            
                        if (checkVatS)
                        {
                            for (int j = 0; j < vatsNormal[temporalValue].Bills.Count; j++)
                            {
                                totalBill = totalBill + vatsNormal[temporalValue].Bills[j];
                            }
                            totalBill = totalBill - ((totalBill * 78) / 100);
                            totalBill = totalBill - ((totalBill * 15) / 100);
                            Console.Write($"The profit of this VAT number is: {totalBill} subtracted with 22% of IVA,");
                            break;
                        }

                        break;

                    case 4:
                        Console.Write("VAT Number lists: \n");
                        Console.WriteLine("VAT number Normal list: \n");
                        for (int i = 0; i < vatsNormal.Count; i++)
                            Console.Write($"VAT code - {vatsNormal[i].CodeId}\n");
                        
                        Console.WriteLine("\nVAT number Simple list: \n");
                        for (int i = 0; i < vatsSimple.Count; i++)
                            Console.Write($"VAT code - {vatsSimple[i].CodeId}\n");
                        
                        break;

                    case 5:
                        cycle = false;
                        break;
                }
            }

            Console.Read();
        }

    }

    class VatNumberNormal
    {
        public int CodeId;
        public List<decimal> Bills;
        public List<decimal> Expenses;
    }

    class VatNumberSimple
    {
        public int CodeId;
        public List<decimal> Bills;
    }
}
