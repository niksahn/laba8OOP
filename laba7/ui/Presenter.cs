using laba7.data;
using laba7.data.OOP1lb.Data;
using laba7.others;
using System;
using System.Collections.Generic;

namespace laba7.ui
{
    internal class Presenter
    {
        ZheckRepository _repo;
        ZheckVeiw _view;
        public Presenter(ZheckVeiw view, ZheckRepository repo)
        {
            _view = view;
            _repo = repo;
            view.SetController(this);
        }

        public void setChanging(long id)
        {
            _view.changing = getUiZheck(_repo.getZhecks().Find((z)=> { return z.Number1 == id; }));
        }

        public void addZheck()
        {
            try
            {
                var addingZheck = _view.adding;
                _repo.addZheck(
                    new Zheck
                    (
                     addingZheck.Region,
                     addingZheck.Name,
                     addingZheck.NumberHabitians,
                     addingZheck.NumberOfBuildings
                    )
                );
                showList();
            }
            catch (MyException e)
            {
                _view.error = e.Message;
            }
            catch (Exception){
                _view.error = "Неверное значение одного или нескольких полей ";
            }
        }

        public void changeZheck()
        {
            try
            {
                var addingZheck = _view.changing;
                _repo.changeZheck(
                    new Zheck
                    (
                     addingZheck.Number,
                     addingZheck.Region,
                     addingZheck.Name,
                     addingZheck.NumberHabitians,
                     addingZheck.NumberOfBuildings
                    )
                );
                showList();
            }
            catch(MyException e)
            {
                _view.error = e.Message;
            }
            catch (Exception)
            {
                _view.error = "Неверное значение одного или нескольких полей ";
            }
        }

        public void showList()
        {
            var zheckList = new List<ZheckUi>();
            _repo.getZhecks().ForEach((z) => { zheckList.Add(getUiZheck(z)); });
            _view.ShowZheckList(zheckList);
        }
        public void removeZheck()
        {
            try
            {
                var removeingZheck = _view.changing;
                _repo.deleteZheck(removeingZheck.Number);
                showList();
                _view.changing = new ZheckUi();
            }
            catch (Exception)
            {
                _view.error = "Не выбран элемент ";
            }
        }
        public void removeZheck(string id)
        {
            try
            {
                _repo.deleteZheck(Int32.Parse(id));
                showList();
            }
            catch (Exception)
            {
                _view.error = "Несуществующий элемент ";
            }
        }
        public void RunView()
        {
            _view.Run();
        }
        private ZheckUi getUiZheck(Zheck zheck)
        {
            return new ZheckUi(name:zheck.Name1, number:zheck.Number1, numberHabitians: zheck.NumberHabitians1, numberOfBuildings: zheck.NumberOfBuildings1, region: zheck.Region1);
        }
    }
}
