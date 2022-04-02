using System;
using System.Collections.Generic;
using System.Text;

namespace TimberbornAPI.EntityLinkerSystem
{
    public interface IEntityLink<T1, T2>
    {
        public T1 Linker { get; }
         
        public T2 Linkee { get; }

    }
}
