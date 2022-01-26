using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestPaginationTablette
{
    class AffichageJojo
    {
        private readonly string[] arborescences;

        private readonly string?[] noeudsDisplayed;
        private Dictionary<int, List<string>> ElementsToDisplayForEachPage;
        private int pageDisplayed = 1;

        public AffichageJojo(List<string> datas, int nbArborescences)
        {
            arborescences = new string[nbArborescences];
            noeudsDisplayed = new string?[nbArborescences];

            ElementsToDisplayForEachPage = GetElementsToDisplayForEachPage(datas, nbArborescences);
            DisplayDatas(1);
        }

        private void DisplayDatas(int pageIndex)
        {
            arborescences.ToList().ForEach(x => x = string.Empty);
            noeudsDisplayed.ToList().ForEach(x => x = null);
            var affichage = string.Empty;
            var cnt = 0;
            foreach (var item in ElementsToDisplayForEachPage[pageIndex])
            {
                if (item == null)
                    arborescences[cnt] = "../..";
                else
                    arborescences[cnt] = item;
                noeudsDisplayed[cnt] = item;
                affichage += $"{cnt} : {arborescences[cnt]}    ";
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
                if (index == 0 && arborescences[0] == "../.." && noeudsDisplayed[0] == null)
                {
                    DisplayDatas(--pageDisplayed);
                }
                else if (index == arborescences.Length - 1 && arborescences[arborescences.Length - 1] == "../.." && noeudsDisplayed[arborescences.Length - 1] == null)
                {
                    DisplayDatas(++pageDisplayed);
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


        static Dictionary<int, List<string>> GetElementsToDisplayForEachPage(List<string> datas, int nbArborescences)
        {
            int pageNumber = 1;
            int elementsNumber = datas.Count;
            Dictionary<int, List<string>> pageIndexWithRange = new Dictionary<int, List<string>>();
            if (datas.Count <= nbArborescences)
            {
                pageIndexWithRange[pageNumber] = datas.GetRange(0, datas.Count);
            }
            else
            {
                pageIndexWithRange[pageNumber] = datas.GetRange(0, (nbArborescences  - 1));
                pageIndexWithRange[pageNumber].Add(null);
                int remainingElementsNumber = elementsNumber - (nbArborescences - 1);

                while (remainingElementsNumber > 0)
                {
                    pageNumber++;
                    int indeOfFirstElement = elementsNumber - remainingElementsNumber;
                    pageIndexWithRange[pageNumber] = new List<string>();
                    pageIndexWithRange[pageNumber].Add(null);

                    if (remainingElementsNumber < nbArborescences)
                    {
                        pageIndexWithRange[pageNumber].AddRange(datas.GetRange(indeOfFirstElement, remainingElementsNumber));
                        break;
                    }

                    else
                    {
                        pageIndexWithRange[pageNumber].AddRange(datas.GetRange(indeOfFirstElement, (nbArborescences - 2)));
                        pageIndexWithRange[pageNumber].Add(null);
                        remainingElementsNumber -= (nbArborescences - 2);
                    }
                }
            }
            return pageIndexWithRange;
        }
    }
}
