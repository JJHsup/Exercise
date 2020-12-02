using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Response_Test.Helper;
using Response_Test.Repository;

namespace Response_Test.Service
{
    public class DataforTest
    {
        public List<string> TestOne()
        {
            List<string> receive = new List<string>();
            List<string> result = new List<string>();
            QuestionsHelper questions = new QuestionsHelper();
            CatchNowTester tester = new CatchNowTester();
            receive.AddRange(questions.Result());
            receive.Add(tester.Name());
            Random random = new Random();
            for(int i = 1; i < 21; i++)
            {
                string item = receive[random.Next(1, receive.Count())];
                if(result.Where(x => x == item).Any())
                {
                    i -= 1;
                }
                else
                {
                    result.Add(item);
                }
            }
            return result;
        }

    }
}