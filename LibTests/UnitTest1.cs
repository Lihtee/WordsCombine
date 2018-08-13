using System;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordsCombine;

namespace LibTests
{
    [TestClass]
    public class LibTests
    {
        private Operations _operations;
        
        public LibTests()
        {
            this._operations = new Operations();
        }
        [TestMethod]
        public void FindCommonTest()
        {
            var sA = "спи";
            var sB = "питон";

            var res = _operations.FindCommonSubstrings(sA, sB).OrderByDescending(x => x.Length()).FirstOrDefault();

            Assert.AreEqual("пи", res.GetCommon(0));
        }

        [TestMethod]
        public void FindCommonMultipleCases()
        {
            var sA = "пипи";
            var sB = "пипипи";

            var sbRes = new StringBuilder();
            var res = _operations.FindCommonSubstrings(sA, sB).OrderByDescending(x => x.Length()).ToList();
            //res.ForEach(x => sbRes.AppendLine($"com: {x.Common}, a: {x.StartPoss[0]} - {x.EndPoss[0]}, b: {x.StartPoss[1]} - {x.EndPoss[1]}"));
            res.ForEach(x => sbRes.AppendLine(x.ToString()));
            string sRes = sbRes.ToString();
        }
    }

    
}
