using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Core
{
    public interface IGameCatalog
    {
        List<BoardGame> Catalog { get; }
        void Add(BoardGame game);
        void Add(BoardGame[] games);
        void Remove(BoardGame games);
        void Serialize();
        void Deserialize();
    }
}
