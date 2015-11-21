using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionTest.One
{
   public class TestClass
    {
       private string _TestStr;
       public string TestStr { get { return this._TestStr + "TestOne"; } set { this._TestStr = value; } }

       public TestClass() {
           Console.WriteLine("测试一实例化了");
       }

       public void PrintText()
       {
           //return "这是测试一";
           Console.WriteLine("这是测试一");
       }

       public void PrintText(string MyStr) {

           Console.WriteLine("这是测试一打印的："+MyStr);
       }

       public int GetNumUs(int nuOne, int nuTwo)
       {
           return nuOne + nuTwo;
       }

       public TestModel TestGetModel(string name)
       {
           TestModel test = new TestModel();
           test.Name = name + "|TestOne";
           return test;
       }
    }
}
