using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace laba7.ui.console
{
    class ConsoleUi:ZheckVeiw
    {
        Presenter _presenter;
        private delegate void listenCommand();
        private event listenCommand _listenCommand;
        public ZheckUi adding {
            get
            {
                Console.WriteLine("Введите название добавляемого объекта");
                var name = Console.ReadLine();
                Console.WriteLine("Введите регион добавляемого объекта");
                var region = Console.ReadLine();
                Console.WriteLine("Введите число жителей добавляемого объекта");
                var numberHab = Console.ReadLine();
                Console.WriteLine("Введите число зданий добавляемого объекта");
                var numberBuild = Console.ReadLine();
                return new ZheckUi(
                    region: region,
                    number: 0,
                    name: name,
                    numberHabitians: Int32.Parse(numberHab),
                    numberOfBuildings: Int32.Parse(numberBuild)
                    );
            }
            set
            {
                Console.WriteLine(value);
                _listenCommand.Invoke();
            }
        }
        public ZheckUi changing {
            get
            {
                Console.WriteLine("Введите id изменяемого объекта");
                var id = Console.ReadLine();
                Console.WriteLine("Введите название изменяемого объекта");
                var name = Console.ReadLine();
                Console.WriteLine("Введите регион изменяемого объекта");
                var region = Console.ReadLine();
                Console.WriteLine("Введите число жителей изменяемого объекта");
                var numberHab = Console.ReadLine();
                Console.WriteLine("Введите число зданий изменяемого объекта");
                var numberBuild = Console.ReadLine();
                return new ZheckUi(
                    region: region,
                    number: Int32.Parse(id),
                    name: name,
                    numberHabitians: Int32.Parse(numberHab),
                    numberOfBuildings: Int32.Parse(numberBuild)
                    );
            }
            set {
                Console.WriteLine(value);
                _listenCommand.Invoke();
            }
        }
        public string error { set { Console.WriteLine(value); _listenCommand.Invoke(); } }

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        public void Run()
        {
            AllocConsole();
            _listenCommand += () =>
            {
                Console.WriteLine("Выберите команду: 1 показать список текущих объектов жэк; 2 добавить объект; 3 изменить объект; 4 удалить объект");
                var command = Console.ReadLine();
                switch(command)
                {
                    case "1": 
                    { 
                            _presenter.showList();
                            break;
                    };
                    case "2":
                    {
                            _presenter.addZheck();
                            break;
                    }
                    case "3":
                    {
                            _presenter.changeZheck();
                            break;
                    }
                    case "4": 
                    {
                            var id = Console.ReadLine();
                            _presenter.removeZheck(id);
                            break;
                    }
                    default:
                        {
                            Console.WriteLine("Неверная команда");
                            _listenCommand.Invoke();
                            break;
                        }
                }
            };
            _listenCommand.Invoke();
        }

        public void SetController(Presenter controller)
        {
            _presenter = controller;
        }

        public void ShowZheckList(List<ZheckUi> zheckList)
        {
           foreach(var z in zheckList)
           {
                Console.WriteLine(z);
           }
           if(zheckList.Count == 0) { Console.WriteLine("Список пока пуст"); }
            _listenCommand.Invoke();
        }
    }
}
