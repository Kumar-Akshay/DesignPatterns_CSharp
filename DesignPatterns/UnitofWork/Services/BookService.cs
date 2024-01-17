using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitofWork.Enities;
using UnitofWork.Interface;
using UnitofWork.Repository;
using UnitofWork.UnitofWork.Interface;

namespace UnitofWork.Services
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<Book> _bookRepository;
        public BookService(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
            _bookRepository = _unitOfWork.GetRepository<Book>();
        }

        public void AddBooks(Book book)
        {
            _bookRepository.Add(book);
            _unitOfWork.Commit();
        }

        public Book GetBook(int Id)
        {
            return _bookRepository.GetById(Id);
        }

        public List<Book> GetBooks()
        {
            return _bookRepository.GetAll().ToList();
        }

        public bool RemoveBooks(int Id)
        {
            var book = _bookRepository.GetById(Id);
            if(book != null)
            {
                _bookRepository.Delete(book);
                _unitOfWork.Commit();
                return true;
            }
            return false;
        }

        public bool UpdateBook(Book book)
        {
            if (book == null) return false;
            var _book = _bookRepository.GetById(book.Id);
            if (_book != null)
            {
                _bookRepository.Update(book);
                _unitOfWork.Commit();
                return true;
            }
            return false;
        }
    }
}
