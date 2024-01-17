using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitofWork.Enities;

namespace UnitofWork.Interface
{
    public interface IBookService
    {
        public List<Book> GetBooks();
        public Book GetBook(int Id);
        public void AddBooks(Book book);
        public bool RemoveBooks(int Id);
        public bool UpdateBook(Book book);

        
    }
}
