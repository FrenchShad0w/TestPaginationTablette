using System;
using System.Collections.Generic;
using System.Text;

namespace TestPaginationTablette
{
    public class AffichageYoyo
    {
        //
        private DataDto Data;
        private readonly DataService dataService;
        private readonly int nbCaseDispoPourAffichage;

        public AffichageYoyo(DataService dataService, int nbCaseDispoPourAffichage)
        {
            this.dataService = dataService;
            this.nbCaseDispoPourAffichage = nbCaseDispoPourAffichage;
            DisplayData();
        }


        public void DisplayData(int index = 0)
        {
            Data = null;

            if (index < 0)
                index = 0;

            Data = dataService.GetData(index, this.nbCaseDispoPourAffichage);



            var affichage = string.Empty;
            var cnt = 0;
            foreach (var item in Data.Datas)
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
                var selectedNoeud = Data?.Datas[index] ?? string.Empty;
                if (selectedNoeud != null)
                {
                    Console.WriteLine($"Data selectionnée : {selectedNoeud}");

                    if (selectedNoeud == "<-")
                    {

                        var nouveauIndex = Data.Index - (this.nbCaseDispoPourAffichage - 2);

                        DisplayData(nouveauIndex);

                    }
                    else if (selectedNoeud == "->")
                    {
                        var nouveauIndex = Data.Index + Data.NbElementAffiches;
                        DisplayData(nouveauIndex);
                    }

                    DisplayData(Data.Index);

                }

            }
        }
    }
}


