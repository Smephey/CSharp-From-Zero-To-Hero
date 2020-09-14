namespace BootCamp.Chapter
{
    class Program
    {
        static void Main(string[] args)
        {
            TextTable.Build("Hello\r\nWorld!\r\nAnother\r\nDay", 3);
            // Print each of the statistical output using Text Table with padding 3:
            TextTable.Build(BalanceStats.FindHighestBalanceEver(PeoplesBalances.Balances), 3);
            //FindPersonWithBiggestLoss
            //FindRichestPerson
            //FindMostPoorPerson
        }
    }
}
