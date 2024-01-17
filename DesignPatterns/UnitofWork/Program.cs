using UnitofWork;
using UnitofWork.Enities;
using UnitofWork.Interface;
using UnitofWork.Services;
using UnitofWork.UnitofWork.Interface;
using UnitofWork.UnitofWork.Service;

Console.WriteLine("Welcome to Unit of Work Example in .NET 6");


AppDbContext context = new AppDbContext();
IUnitOfWork unitOfWork = new UnitOfWorkImpl(context);
IBookService bookService = new BookService(unitOfWork);

var book = new Book() { Title = "NewBookC#" };
bookService.AddBooks(book);
bookService.GetBook(book.Id);
bookService.UpdateBook(book);
bookService.RemoveBooks(book.Id);
