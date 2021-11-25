using System;
using Raminagrobis.DAL;

namespace Raminagrobis
{
    class Program
    {
        static void Main(string[] args)
        {
            var depo = new FournisseurGlobal_DAL();

            var f1 = new Fournisseur_DAL("societeTest", false, "Giroud", "Olivier", "olivier.giroud@gmail.com", "10 rue des avenues", false);

            depo.Insert(f1);

            Console.WriteLine(f1.ID);

        }
    }
}
