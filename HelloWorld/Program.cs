namespace HelloWorld
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Koodi tähän
            double luku1 = 10.5;
            double luku2 = 5.5;

            double tulo, summa, erotus, osamäärä;

            tulo = luku1 * luku2;
            summa = luku1 + luku2;
            erotus = luku1 - luku2;
            osamäärä = luku1 / luku2;


            
            Console.WriteLine("Peruslaskujen tulokset: ");
            Console.WriteLine("Tulo: " + tulo);
            Console.WriteLine("Summa: " + summa);
            Console.WriteLine("Erotus: " + erotus);
            Console.WriteLine("Osamäärä: " + osamäärä);


        }
    }
}
