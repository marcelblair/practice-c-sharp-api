using System;
using practice_c_sharp_api.Models;

namespace practice_c_sharp_api.Services
{
	public class BookService
	{
        static int nextId = 4;
        private static List<Book> bookRepo = new List<Book>{ new Book(1, "Beach Road", "James Patterson", "MRB Publishing Inc"),
			new Book(2, "Beach Road 2", "James Patterson", "MRB Publishing Inc"),
			new Book(3, "Beach Road 3", "James Patterson", "MRB Publishing Inc")}; 

        public BookService()
		{
		}

		public static IEnumerable<Book> GetAllBooks()
		{
			return bookRepo; 
		}

		public static Book GetBookById(int id)
		{
			return bookRepo.FirstOrDefault((book) => book.id == id); 
		}

		public static void Add(Book book)
		{
			book.id = nextId;
			bookRepo.Add(book);
			nextId++;
		}

        public static void Delete(int id)
        {
            var book = GetBookById(id);
            if (book is null)
                return;

            bookRepo.Remove(book);
        }

        public static void Update(Book book)
        {
            var index = bookRepo.FindIndex(b => b.id == book.id);
            if (index == -1)
                return;

            bookRepo[index] = book;
        }
    }
}

