using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace InterFace_Reflection_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---------------------------------------请输入要调用的dll");

            string s = Console.ReadLine();

            //dll路径
            string dllPath = "Demo.Reflection";

            //加载 dll
            System.Reflection.Assembly ass = Assembly.Load(dllPath);

            //获取相对应的类的类型
            var type = ass.GetType("Demo.Reflection.Test");
            //获取 相对应的 实例化
            Object o = System.Activator.CreateInstance(type);

            //转换成接口对象
            IReflection.IReflection Obj = o as IReflection.IReflection;

            //直接调用即可
            Obj.Name = "Ben";

            Console.WriteLine(Obj.SayHello());


            Console.ReadKey();

        }
    }
}
