using NonVisualComponents.HelperModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    public class Data
    {
        public List<Test> test = new List<Test>();

        public Data()
        {
            test.Add(new Test { name = "csscdscd", value = 1 });
            test.Add(new Test { name = "aaa", value = 51 });
            test.Add(new Test { name = "sdcdscd", value = 11 });
            test.Add(new Test { name = "q234", value = 43 });
            test.Add(new Test { name = "Ty", value = 32 });
        }


        public List<string[,]> getListTables(int count, int width, int height)
        {
            List<string[,]> list = new List<string[,]>();

            for (int i = 0; i < count; i++)
            {
                list.Add(getStringTables(width, height));
            }
            return list;
        }

        private string[,] getStringTables(int width, int height)
        {

            string[,] tables = new string[height, width];

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    tables[i, j] = test[i % 8].name + " " + i + "" + j;
                }
            }
            return tables;
        }

        public List<int> getColumnsWidth(int count, int width)
        {
            List<int> list = new List<int>();

            for (int i = 0; i < count; i++)
            {
                list.Add(width);
            }
            return list;
        }

        public List<int> getRowsHeight(int count, int height)
        {
            List<int> list = new List<int>();

            for (int i = 0; i < count; i++)
            {
                list.Add(height);
            }
            return list;
        }

        public List<string> GetHeader(int count)
        {
            List<string> list = new List<string>();
            if (count > 0 && count < 10)
                switch ((count % 10))
                {
                    case 2:
                        list.Add("name");
                        goto case 1;
                    case 1:
                        list.Add("value");
                        break;
                    default:
                        break;
                }
            return list;
        }

        public List<Test> GetTests()
        {
            return test;
        }
    }
}
