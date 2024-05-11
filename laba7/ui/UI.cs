using laba7.data.OOP1lb.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba7.ui
{
    interface ZheckVeiw
    {
        void SetController(Presenter controller);
        void ShowZheckList(List<ZheckUi> zheckList);
        void Run();
        ZheckUi adding { get; set; }
        ZheckUi changing { get; set; }
        String error { set; }
    }
    class ZheckUi
    {
        public string Region { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public double NumberHabitians { get; set; }
        public double NumberOfBuildings { get; set; }

        public ZheckUi() { }
        public ZheckUi(string region, int number, string name,  double numberHabitians, double numberOfBuildings) {
            Region = region;
            Number = number;
            Name = name;
            NumberHabitians = numberHabitians;
            NumberOfBuildings = numberOfBuildings;
        }

        public override string ToString()
        {
            return "id:"+Number+" Название: "+Name+" Число жителей: "+NumberHabitians+" Число зданий: "+NumberOfBuildings;
        }
    }
}
