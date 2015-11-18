using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionTest
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("---------------------------------------请输入要调用的dll");

                string s = Console.ReadLine();

                //dll路径
                string dllPath = ConfigurationManager.AppSettings["Assembly"] + s + ".dll";

                //加载dll
                System.Reflection.Assembly ass = Assembly.LoadFrom(dllPath);

                //传入类型的命名空间和名称获得类型
                Type type = ass.GetType("ReflectionTest." + s + ".TestClass");

                //创建实例 
                object o = System.Activator.CreateInstance(type);

                #region 如果 有构造方法 并且有参数
                //Object[] parameters = new Object[2]; // 定义构造函数需要的参数，所有参数都必须为Object
                //parameters[0] = 3;
                //parameters[1] = 5;
                //Object obj = System.Activator.CreateInstance(type, true, System.Reflection.BindingFlags.Default,null, parameters, null, null);
                #endregion

                #region 关于 属性

                //获取属性对象
                System.Reflection.PropertyInfo propertyInfo = type.GetProperty("TestStr");
                #region 给属性赋值
                //type.GetProperty("TestStr").SetValue(o,"你妈逼",null);

                propertyInfo.SetValue(o, "123", null);
                #endregion

                #region 获取 属性的值

                //获取属性值
                string value_Old = (string)propertyInfo.GetValue(o, null);

                //输出方法
                Console.WriteLine("参数值：" + value_Old);
                #endregion 

                #endregion

                #region 关于方法

                #region 调用一个没有返回值并且没有参数的方法

                //获取方法   //如果调用重载方法一定要 加上参数类型 如果没有参数则数组为空 否则会找不到相对应的方法的
                MethodInfo method = type.GetMethod("PrintText", new Type[] { });

                //执行方法
                method.Invoke(o, null);

                #endregion

                //设置方法中的参数类型
                Type[] params_Type = null;

                //设置 方法中的参数值
                Object[] params_Obj = null;

                #region 调用一个带参数的方法

                //设置方法中的参数类型
                params_Type = new Type[1] { typeof(string) };
                //设置 方法中的参数值
                params_Obj = new Object[1] { "你好啊" };

                //开始执行方法    实例化方法的时候讲参数类型带进去    执行方法的时候 将参数带进去
                type.GetMethod("PrintText", params_Type).Invoke(o, params_Obj);
                #endregion

                #region 调用一个带参数并有返回值的方法
                //设置方法中的参数类型
                params_Type = new Type[2] { typeof(int), typeof(int) };
                //设置 方法中的参数值
                params_Obj = new Object[2] { 1, 2 };
                //开始执行方法    实例化方法的时候讲参数类型带进去    执行方法的时候 将参数带进去
                Console.WriteLine(type.GetMethod("GetNumUs", params_Type).Invoke(o, params_Obj).ToString());
                #endregion 

                #endregion

            }

        }
    }
}
