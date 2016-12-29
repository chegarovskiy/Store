using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Domain.Entitys;

namespace Store.Domain.Abstract
{
   // вызывающему коду получать последовательность объектов Game, ничего не сообщая о том,
   // как или где хранятся или извлекаются данные. Класс, зависящий от интерфейса IGameRepository,
   // может получать объекты Game, ничего не зная о том, откуда они поступают или каким образом 
   // класс реализации будет их доставлять. В этом и состоит суть шаблона хранилища
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }
    }
}
