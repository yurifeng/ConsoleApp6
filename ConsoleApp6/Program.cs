using System;
using System.Reflection;

namespace ConsoleApp6
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 普通代码

            //Driver driver = new Driver(new HeavyTank());
            //driver.Drive();

            //Driver driver2 = new Driver(new Car());
            //driver2.Drive();

            #endregion

            #region 反射机制调用程序

            ITank tank = new HeavyTank();
            Type type = tank.GetType();
            object instance = Activator.CreateInstance(type);
            MethodInfo methodInfo = type.GetMethod("Fire");
            MethodInfo methodInfo2 = type.GetMethod("Run");
            methodInfo.Invoke(instance, null);
            methodInfo2.Invoke(instance, null);

            #endregion


        }
    }

    interface IWeapon
    {
        void Fire();
    }

    class Driver
    {
        public IVehicle _vehicle;
        //public ITank _tank;

        public Driver(IVehicle vehicle)
        {
            _vehicle = vehicle;
        }

        //public Driver(ITank tank)
        //{
        //    _tank = tank;
        //}

        public void Drive()
        {
            _vehicle.Run();
        }

        //public void Drives()
        //{
        //    _tank.Run();
        //}
    }

    interface IVehicle
    {
        void Run();

    }

    class Car : IVehicle
    {
        public void Run()
        {
            Console.WriteLine("Car在走....");
        }
    }

    class Truck : IVehicle
    {
        public void Run()
        {
            Console.WriteLine("Truck 在走....");
        }
    }

    /// <summary>
    /// 接口继承另外的基接口,数量不限
    /// </summary>
    interface ITank : IWeapon, IVehicle
    {

    }

    class LightTank : ITank
    {
        public void Fire()
        {
            Console.WriteLine("fire in the hole");
        }

        public void Run()
        {
            Console.WriteLine("LightTank 在走...");
        }
    }

    class MediumTank : ITank
    {
        public void Fire()
        {
            Console.WriteLine("fire in the hole.....");
        }

        public void Run()
        {
            Console.WriteLine("MediumTank 在走...");
        }
    }

    class HeavyTank : ITank
    {
        public void Fire()
        {
            Console.WriteLine("fire in the hole.............");
        }

        public void Run()
        {
            Console.WriteLine("HeavyTank 在走...");
        }
    }
}
