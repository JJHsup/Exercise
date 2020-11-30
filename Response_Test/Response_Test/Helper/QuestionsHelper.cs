using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Response_Test.Helper
{
    public class QuestionsHelper
    {
        public List<string> Left(int i)
        {
            List<string> result = new List<string>();
            if (i == 1)
            {
                result.AddRange(Nature());
                return result;
            }
            return null;
        }

        public List<string> Right(int i)
        {
            List<string> result = new List<string>();
            if (i == 1)
            {
                result.AddRange(Artificial());
                result.AddRange(Color());
                return result;
            }
            return null;
        }

        private List<string> Nature()
        {
            List<string> nature = new List<string>
            {
                "松樹" , "榕樹" , "向日葵" , "太陽" , "月亮" , "海洋" , "薰衣草"
            };
            return nature;
        }

        private List<string> Personal()
        {
            List<string> name = new List<string>();
            return name;
        }

        private List<string> Artificial()
        {
            List<string> item = new List<string>
            {
                "汽車" , "房子" , "機車" , "政府" , "輪船" , "風車" , "電視"
            };
            return item;
        }

        private List<string> Color()
        {
            List<string> color = new List<string>
            {
                "Yellow" , "Black" , "Blue" , "Red" , "Green" , "Pink" , "White"
            };
            return color;
        }
    }
}