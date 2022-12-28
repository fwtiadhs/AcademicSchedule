using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GLib.data.module
{
    public interface IDataModule
    {
        bool Load();
        bool Save();
    }
}
