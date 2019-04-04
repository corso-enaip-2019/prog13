using System;
using System.Collections.Generic;

namespace Esercizio1
{
    class Program
    {
        static int CheckMenuNumber()
        {
            string input = Console.ReadLine();
            bool conversionOk = int.TryParse(input, out int convertedValue);
            while (!conversionOk || convertedValue <= 0 || convertedValue > 5)
            {
                Console.Clear();
                Console.Write("1.Add bill to VAT Number\n2.Add expense to VAT Number\n3.Calculate profit of VAT Number\n4.Show all VAT Numbers\n5.Exit\n");
                Console.WriteLine("You can insert only the numbers in the menu");
                input = Console.ReadLine();
                conversionOk = int.TryParse(input, out convertedValue);
                Console.Clear();
            }

            return convertedValue;
        }

        static int VATcode()
        {
            Console.Write("Insert the VAT Number code: ");
            string input = Console.ReadLine();
            bool conversionOk = int.TryParse(input, out int vatCode);
            while (!conversionOk || vatCode <= 0)
            {
                Console.Clear();
                Console.WriteLine("Code not valid, reinsert code: ");
                input = Console.ReadLine();
                conversionOk = int.TryParse(input, out vatCode);
                Console.Clear();
            }

            return vatCode;
        }

        static decimal InsertDecimalAmount()
        {
            Console.Write("Insert the amount: ");
            string input = Console.ReadLine();
            bool conversionOk = decimal.TryParse(input, out decimal convertedDecimalValue);
            while (!conversionOk || convertedDecimalValue <= 0)
            {
                Console.Clear();
                Console.WriteLine("Amount not valid, reinsert amount: ");
                input = Console.ReadLine();
                conversionOk = decimal.TryParse(input, out convertedDecimalValue);
                Console.Clear();
            }

            return convertedDecimalValue;
        }
        
        static TemporalValues CheckBothCodePosition(List<VatNumberNormal> vatsNormal, List<VatNumberSimple> vatsSimple, int vatCode, TemporalValues temporalValues)
        {
            for (int i = 0; i < vatsNormal.Count; i++)
            {
                if (vatCode == vatsNormal[i].CodeId)
                {
                    temporalValues.TemporalPosition = i;
                    temporalValues.VatType = true;
                    return temporalValues;
                }
            }

            for (int i = 0; i < vatsSimple.Count; i++)
            {
                if (vatCode == vatsSimple[i].CodeId)
                {
                    temporalValues.TemporalPosition = i;
                    temporalValues.VatType = false;
                    return temporalValues;
                }
            }

            temporalValues.TemporalPosition = -1;
            return temporalValues;
        }
        
        static void WriteVATSList(List<VatNumberNormal> vatsNormal, List<VatNumberSimple> vatsSimple)
        {
            Console.Write("VAT Number lists: \n");
            Console.WriteLine("VAT number Normal list: \n");
            for (int i = 0; i < vatsNormal.Count; i++)
                Console.Write($"VAT code - {vatsNormal[i].CodeId}\n");

            Console.WriteLine("\nVAT number Simple list: \n");
            for (int i = 0; i < vatsSimple.Count; i++)
                Console.Write($"VAT code - {vatsSimple[i].CodeId}\n");
        }

        static string CalculateProfit(List<VatNumberNormal> vatsNormal, List<VatNumberSimple> vatsSimple, TemporalValues temporalValues)
        {

            decimal totalBill = 0;
            decimal expenseTotal = 0;
            decimal profit = 0;
            string returnProfit = "";

            if (temporalValues.VatType)
            {
                for (int j = 0; j < vatsNormal[temporalValues.TemporalPosition].Bills.Count; j++)
                {
                    totalBill = totalBill + vatsNormal[temporalValues.TemporalPosition].Bills[j];
                    expenseTotal = expenseTotal + vatsNormal[temporalValues.TemporalPosition].Expenses[j];
                }
                profit = totalBill - expenseTotal;
                profit = profit - ((profit * 22) / 100) - ((profit * 23) / 100);

                returnProfit = $"The profit of this VAT number is: {profit} subtracted with 22% of IVA and 23% of IRPEF\n";
                return returnProfit;
            }

            if (temporalValues.VatType == false)
            {
                for (int j = 0; j < vatsSimple[temporalValues.TemporalPosition].Bills.Count; j++)
                {
                    totalBill = totalBill + vatsSimple[temporalValues.TemporalPosition].Bills[j];
                }
                totalBill = totalBill - ((totalBill * 22) / 100);
                totalBill = totalBill - ((totalBill * 15) / 100);
                returnProfit = $"The profit of this VAT number is: {totalBill}, with 78% of the original value due to IVA, subtracted with 15% of taxes\n";
                return returnProfit;
            }

            return returnProfit;
        }

        static List<VatNumberNormal> InitializeNormals(List<VatNumberNormal> vatsNormal)
        {
            vatsNormal.Add(new VatNumberNormal());
            vatsNormal.Add(new VatNumberNormal());
            vatsNormal.Add(new VatNumberNormal());
            vatsNormal.Add(new VatNumberNormal());
            vatsNormal.Add(new VatNumberNormal());

            vatsNormal[0].Bills = new List<decimal>();
            vatsNormal[1].Bills = new List<decimal>();
            vatsNormal[2].Bills = new List<decimal>();
            vatsNormal[3].Bills = new List<decimal>();
            vatsNormal[4].Bills = new List<decimal>();

            vatsNormal[0].Expenses = new List<decimal>();
            vatsNormal[1].Expenses = new List<decimal>();
            vatsNormal[2].Expenses = new List<decimal>();
            vatsNormal[3].Expenses = new List<decimal>();
            vatsNormal[4].Expenses = new List<decimal>();

            vatsNormal[0].CodeId = 1;
            vatsNormal[1].CodeId = 2;
            vatsNormal[2].CodeId = 3;
            vatsNormal[3].CodeId = 4;
            vatsNormal[4].CodeId = 5;

            return vatsNormal;
        }

        static List<VatNumberSimple> InitializeSimples(List<VatNumberSimple> vatsSimple)
        {
            vatsSimple.Add(new VatNumberSimple());
            vatsSimple.Add(new VatNumberSimple());
            vatsSimple.Add(new VatNumberSimple());
            vatsSimple.Add(new VatNumberSimple());
            vatsSimple.Add(new VatNumberSimple());

            vatsSimple[0].Bills = new List<decimal>();
            vatsSimple[1].Bills = new List<decimal>();
            vatsSimple[2].Bills = new List<decimal>();
            vatsSimple[3].Bills = new List<decimal>();
            vatsSimple[4].Bills = new List<decimal>();

            vatsSimple[0].CodeId = 6;
            vatsSimple[1].CodeId = 7;
            vatsSimple[2].CodeId = 8;
            vatsSimple[3].CodeId = 9;
            vatsSimple[4].CodeId = 10;

            return vatsSimple;
        }

        static void Main(string[] args)
        {
            int convertedValue;
            int vatCode;
            decimal convertedDecimalValue;
            bool cycle = true;
            
            List<VatNumberNormal> vatsNormal = new List<VatNumberNormal>();

            InitializeNormals(vatsNormal);

            List<VatNumberSimple> vatsSimple = new List<VatNumberSimple>();

            InitializeSimples(vatsSimple);
            
            while (cycle)
            {
                TemporalValues temporalValues = new TemporalValues();

                Console.Write("1.Add bill to VAT Number\n2.Add expense to VAT Number\n3.Calculate profit of VAT Number\n4.Show all VAT Numbers\n5.Exit\n");

                convertedValue = CheckMenuNumber();

                switch (convertedValue)
                {
                    case 1:
                        vatCode = VATcode();

                        temporalValues = CheckBothCodePosition(vatsNormal, vatsSimple, vatCode, temporalValues);

                        if (temporalValues.TemporalPosition == -1)
                        {
                            Console.Write("The VAT number code doesn't exist.\n");
                            break;
                        }

                        convertedDecimalValue = InsertDecimalAmount();
                        
                        if (temporalValues.VatType)
                            vatsNormal[temporalValues.TemporalPosition].Bills.Add(convertedDecimalValue);
                        if (temporalValues.VatType == false)
                            vatsSimple[temporalValues.TemporalPosition].Bills.Add(convertedDecimalValue);

                        break;

                    case 2:
                        vatCode = VATcode();

                        temporalValues = CheckBothCodePosition(vatsNormal, vatsSimple, vatCode, temporalValues);

                        if (temporalValues.TemporalPosition == -1)
                        {
                            Console.Write("The VAT number code doesn't exist.\n");
                            break;
                        }

                        if (temporalValues.VatType == false)
                        {
                            Console.Write("The VAT number code is of a Simple type, reinsert a valid one.\n");
                            break;
                        }

                        convertedDecimalValue = InsertDecimalAmount();

                        vatsNormal[temporalValues.TemporalPosition].Expenses.Add(convertedDecimalValue);

                        break;

                    case 3:
                        vatCode = VATcode();

                        temporalValues = CheckBothCodePosition(vatsNormal, vatsSimple, vatCode, temporalValues);

                        if (temporalValues.TemporalPosition == -1)
                        {
                            Console.Write("The VAT number code doesn't exist.");
                            break;
                        }

                        Console.Write(CalculateProfit(vatsNormal, vatsSimple, temporalValues));

                        break;

                    case 4:
                        WriteVATSList(vatsNormal, vatsSimple);
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

    class TemporalValues
    {
        public int TemporalPosition;
        public bool VatType;
    }
}
