using System;
using System.Collections.Generic;
using System.Text;

namespace FinPort.Services
{
    public interface BaseExtensions<T, E> where T : class where E : class
    {
        E MapToModel(T entity1);
        T MapToEntity(E entity2);
    }
}
