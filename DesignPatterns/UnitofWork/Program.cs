using Microsoft.EntityFrameworkCore;
using UnitofWork;
using UnitofWork.Enities;
using UnitofWork.Interface;
using UnitofWork.Services;
using UnitofWork.UnitofWork.Interface;
using UnitofWork.UnitofWork.Service;

Console.WriteLine("Welcome to Unit of Work Example in .NET 6");


using AppDbContext context = new AppDbContext();
context.Database.Migrate(); // Applies any pending migrations

IUnitOfWork unitOfWork = new UnitOfWorkImpl(context);
IBookService bookService = new BookService(unitOfWork);

var book = new Book() { Title = "NewBookC#" };
bookService.AddBooks(book);
var result = bookService.GetBook(book.Id);
book.Title = "ItsNewBook";
bookService.UpdateBook(book);
bookService.RemoveBooks(book.Id);
result = bookService.GetBook(book.Id);
