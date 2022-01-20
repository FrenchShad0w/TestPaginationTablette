using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestPaginationTablette
{
    public class DataService
    {
        private readonly List<string> allDatas;

        public DataService(List<string> allDatas)
        {
            this.allDatas = allDatas;
        }


        public DataDto GetData(int index, int nbElement)
        {

            if (index > allDatas.Count - 1)
                index = allDatas.Count - 1;

            if (index < nbElement - 1)
                index = 0;


            var result = new DataDto(index, allDatas.Count);


            for (int i = index; i < nbElement + index; i++)
            {
                var element = i > allDatas.Count - 1 ? string.Empty : allDatas[i];
                result.Datas.Add(element);
            }


            if (result.OnFirstPage == false)
            {
                result.Datas.RemoveAt(result.Datas.Count - 1);
                result.Datas.Insert(0, "<-");
            }

            if(result.OnLastPage == false)
            {
                result.Datas.RemoveAt(result.Datas.Count - 1);
                result.Datas.Add("->");
            }

            return result;
        }
    }


    public class DataDto
    {
        public DataDto(int index, int nombreTotalElements)
        {
            this.Index = index;
            this.NbElementTotal = nombreTotalElements;
        }
        public List<string> Datas { get; set; } = new List<string>();
        public int Index { get; }

        public int NbElementAffiches => Datas?.Where(x => x != "<-" && x != "->" && x != string.Empty)?.Count() ?? 0;
        public int NbElementTotal { get;  }

        public bool OnFirstPage => Index == 0; //on commence index == 0
        public bool OnLastPage => Index + NbElementAffiches >= NbElementTotal;
    }






    
}
