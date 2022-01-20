using System;
using System.Collections.Generic;
using System.Text;

namespace TestPaginationTablette
{
    class TestNouveauAffichage
    {
        private readonly List<string> datas;
        private readonly string[] arborescences;

        public TestNouveauAffichage(List<string> datas, int nbArborescences)
        {
            this.datas = datas;
            arborescences = new string[nbArborescences];

            DisplayDatas();
        }

        private void DisplayDatas()
        {
            //remplir arborescences avec des données

            var affichage = string.Empty;
            var cnt = 0;
            foreach (var item in arborescences)
            {
                affichage += $"{cnt} : {item}    ";
                cnt++;
            }
            Console.WriteLine(affichage);
            Console.WriteLine("Tapez index Arborescence");
            ArborescencesSelected(Console.ReadLine().ToString());
        }

        private void ArborescencesSelected(string obj)
        {
            //(Afficher data sélectionné) et réafficher

            var changerPage = false;
            if (changerPage)
            {
                DisplayDatas();
            }
            else
            {
                var selectedNoeud = string.Empty;
                Console.WriteLine($"Data selectionnée : {selectedNoeud}");
                DisplayDatas();
            }
        
        }
    }
}
