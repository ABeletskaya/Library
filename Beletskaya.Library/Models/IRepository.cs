using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Beletskaya.Library.Models
{
    interface IRepository<T> : IDisposable
        where T : class
    {
        IEnumerable<T> GetBookList(); 
        T GetBook(int? id); 
        void Create(T item); 
        void Update(T item); 
        void Delete(int id); 
        void Save();  
    }
}