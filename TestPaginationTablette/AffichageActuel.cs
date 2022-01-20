using System;
using System.Collections.Generic;
using System.Text;

namespace TestPaginationTablette
{
    class AffichageActuel
    {
        private readonly List<string> datas;
        private readonly string[] arborescences;

        public AffichageActuel(List<string> datas, int nbArborescences)
        {
            this.datas = datas;
            arborescences = new string[nbArborescences];

            noeudsDisplayed = new string?[nbArborescences];

            DisplayDatas();
        }

        private readonly string?[] noeudsDisplayed;
        private int pageDisplayed = 1;
        private bool hasPreviousPage = false;
        private bool hasNextPage = false;

        private void DisplayDatas(int page = 1)
        {
            pageDisplayed = page;

            int firstNoeudArboIndex = 0;
            int lastNoeudArboIndex;
            int nbNoeudsAlreadyDisplayed = 0;
            int nbMaxNoeudsDisplayable = arborescences.Length;

            if (page == 1)
            {
                hasPreviousPage = false;
            }
            else if (page == 2)
            {
                hasPreviousPage = true;
                firstNoeudArboIndex = 1;
                nbNoeudsAlreadyDisplayed = arborescences.Length - 1;
                nbMaxNoeudsDisplayable = arborescences.Length - 1;
            }
            else if (page > 2)
            {
                hasPreviousPage = true;
                firstNoeudArboIndex = 1;
                nbNoeudsAlreadyDisplayed = arborescences.Length - 1 + (arborescences.Length - 2) * (page - 2);
                nbMaxNoeudsDisplayable = arborescences.Length - 1;
            }

            if (datas.Count - nbNoeudsAlreadyDisplayed > nbMaxNoeudsDisplayable)
            {
                hasNextPage = true;
                lastNoeudArboIndex = arborescences.Length - 2;
            }
            else
            {
                hasNextPage = false;
                lastNoeudArboIndex = datas.Count - nbNoeudsAlreadyDisplayed - 1 + firstNoeudArboIndex;
            }

            if (hasPreviousPage)
            {
                arborescences[0] = "../..";
                noeudsDisplayed[0] = null;
            }
            for (int i = firstNoeudArboIndex; i <= lastNoeudArboIndex; i++)
            {
                arborescences[i] = datas[nbNoeudsAlreadyDisplayed];
                noeudsDisplayed[i] = datas[nbNoeudsAlreadyDisplayed];
                nbNoeudsAlreadyDisplayed++;
            }
            if (hasNextPage)
            {
                arborescences[arborescences.Length - 1] = "../..";
                noeudsDisplayed[arborescences.Length - 1] = null;
            }
            else
            {
                for (int i = lastNoeudArboIndex + 1; i < arborescences.Length; i++)
                {
                    arborescences[i] = string.Empty;
                    noeudsDisplayed[i] = null;
                }
            }

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
            if (int.TryParse(obj, out int index))
            {
                if (index == 0 && hasPreviousPage)
                {
                    DisplayDatas(pageDisplayed - 1);
                }
                else if (index == arborescences.Length - 1 && hasNextPage)
                {
                    DisplayDatas(pageDisplayed + 1);
                }
                else
                {
                    var selectedNoeud = noeudsDisplayed[index];
                    if (selectedNoeud != null)
                    {
                        Console.WriteLine($"Data selectionnée : {selectedNoeud}");
                        DisplayDatas(pageDisplayed);
                    }
                }
            }
        }
    }
}
