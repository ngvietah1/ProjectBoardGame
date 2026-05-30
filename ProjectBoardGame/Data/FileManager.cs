using Model.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Data
{
    public abstract class FileManager
    {
        public string FilePath { get; private set; }
        public FileManager(string filepath)
        {
            FilePath = filepath;
        }
        public abstract void Serialize(IGameCatalog catalog);
        public abstract IGameCatalog Deserialize();
    }
}
