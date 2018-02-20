using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace web_app_pizza.Models
{
    public interface IRepository<T>
    {
        List<T> Read();
        List<T> Read(Func<T, bool> predicate);
        T Read(int id);
    }
}
