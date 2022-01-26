using System;
using System.Collections.Generic;

namespace TestPaginationTablette
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> datas = new List<string>();
            for (int i = 1; i < 51; i++)
            {
                datas.Add(i.ToString());
            }

            int nbCaseDispo = 14;

            //new AffichageActuel(datas, nbCaseDispo);
            //new TestNouveauAffichage(datas, nbArboresecences);
            //new AffichageYoyo(new DataService(datas), nbCaseDispo);
            new AffichageJojo(datas, nbCaseDispo);
        }
    }
}
