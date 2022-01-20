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
            var result = new DataDto(index, allDatas.Count);

            if (index > allDatas.Count - 1)
                index = allDatas.Count - 1;



            for (int i = index; i < nbElement + index; i++)
            {
                var element = i > allDatas.Count - 1 ? string.Empty : allDatas[i];
                result.Datas.Add(element);
            }


            if (result.FirstPage == false)
            {
                result.Datas.RemoveAt(result.Datas.Count - 1);
                result.Datas.Insert(0, "<-");
            }

            if(result.LastPage == false)
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

        public int NbElementAffiches => Datas?.Where(x => x != "<-" && x != "->")?.Count() ?? 0;
        public int NbElementTotal { get;  }

        public bool FirstPage => Index == 0; //on commence index == 0
        public bool LastPage => Index + NbElementAffiches >= NbElementTotal;
    }
}
