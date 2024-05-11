using laba7.data.OOP1lb.Data;
using laba7.ui;
using System.Collections.Generic;

namespace laba7.data
{
    internal class ZheckListRepository : ZheckRepository
    {
      private List<Zheck> zhecks;
        public ZheckListRepository() {
            zhecks = new List<Zheck>();
        }

        public List<Zheck> getZhecks() { return zhecks; }
        public void addZheck(Zheck zheck) { zhecks.Add(zheck); }
        public void changeZheck(Zheck zheck) {
            var i = zhecks.FindIndex((z) => { return z.Number1 == zheck.Number1; });
            zhecks[i] = zheck;
        }
        public void deleteZheck(long zheckId)
        {
            var i = zhecks.FindIndex((z) => { return z.Number1 == zheckId; });
            zhecks.RemoveAt(i);
        }
    }

    interface ZheckRepository
    {
         void addZheck(Zheck zheck);
         void changeZheck(Zheck zheck);
         void deleteZheck(long zheckId);
         List<Zheck> getZhecks();
    }
}
