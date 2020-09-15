using System;
using System.Globalization;
using System.Runtime.InteropServices.ComTypes;
using System.Xml;

namespace BootCamp.Chapter
{
    public static class BalanceStats
    {
        /// <summary>
        /// Return name and balance(current) of person who had the biggest historic balance.
        /// </summary>
        public static string FindHighestBalanceEver(string[] peopleAndBalances)
        {
            if (peopleAndBalances.Length <= 0) return "N/A.";

            var name = "";
            var highestBalance = 0;


            foreach (var personAndBalances in peopleAndBalances)
            {
                var splitFields = personAndBalances.Split(", ");

                for (var i = 0; i < splitFields.Length; i++)
                {
                    var balance = ParseNumber(splitFields[i]);
                    if (balance > highestBalance)
                    {
                        highestBalance = balance;
                        name = splitFields[0];
                    }
                }
            }

            //"Thor had the most money ever. ¤1002.
            var convertedBalance = ConvertToCurrency(highestBalance);
            return $"{name} had the most money ever. {convertedBalance}.";
        }

        /// <summary>
        /// Return name and loss of a person with a biggest loss (balance change negative).
        /// </summary>
        public static string FindPersonWithBiggestLoss(string[] peopleAndBalances)
        {
            return "";
        }

        /// <summary>
        /// Return name and current money of the richest person.
        /// </summary>
        public static string FindRichestPerson(string[] peopleAndBalances)
        {
            return "";
        }

        /// <summary>
        /// Return name and current money of the most poor person.
        /// </summary>
        public static string FindMostPoorPerson(string[] peopleAndBalances)
        {
            return "";
        }

        private static int ParseNumber(string input)
        {
            bool isNumber = int.TryParse(input, out int number);
            if (!isNumber)
            {
                return 0;
            }
            else
            {
                return number;
            }
        }

        private static string ConvertToCurrency(int number)
        {
            var customCulture = CultureInfo.CreateSpecificCulture("");
            customCulture.NumberFormat.CurrencyGroupSeparator = "";

            return string.Format(customCulture, "{0:C0}", number);
        }
    }
}
