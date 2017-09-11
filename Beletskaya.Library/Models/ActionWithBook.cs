using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;

namespace Beletskaya.Library.Models
{
    public class ActionWithBook
    {
        private string _connectionString;
        public ActionWithBook(string connectionString)
        {
            _connectionString = connectionString;
        }

        public bool AddBook(Book book)
        {
            bool isSuccess = true;
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    using (var Context = new LibraryContext())
                    {
                        Context.Books.Add(new Book
                        {
                            Name = book.Name,
                            Author = book.Author,
                            Publisher = book.Publisher,
                            Year = book.Year
                        });
                        Context.SaveChanges();
                    }
                }
            }
            catch (Exception ex) // предусмотреть возможность писать логи в таблицу в БД
            {
                isSuccess = false;
                File.AppendAllText(@"Exception Entity log.txt", DateTime.Now.ToString() + "   AddBook method   " + ex.ToString());
            }
            return isSuccess;
        }

        public bool UpdateBook0(Book book, int Id)
        {
            bool isSuccess = true;
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    using (var Context = new LibraryContext())
                    {
                        var updateBook = Context.Books.Where(b => b.Id == Id).FirstOrDefault();

                        updateBook.Name = book.Name;
                        updateBook.Author = book.Author;
                        updateBook.Publisher = book.Publisher;
                        updateBook.Year = book.Year;
                        Context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                isSuccess = false;
                File.AppendAllText(@"Exception Entity log.txt", DateTime.Now.ToString() + "   UpdateBook method   " + ex.ToString());
            }
            return isSuccess;
        }

        public bool UpdateBook(Book book)
        {
            bool isSuccess = true;
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    using (var Context = new LibraryContext())
                    {
                        var updateBook = Context.Books.Where(b => b.Id == book.Id).FirstOrDefault();
                        updateBook.Name = book.Name;
                        updateBook.Author = book.Author;
                        updateBook.Publisher = book.Publisher;
                        updateBook.Year = book.Year;

                        Context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                isSuccess = false;
                File.AppendAllText(@"Exception Entity log.txt", DateTime.Now.ToString() + "   UpdateBook method   " + ex.ToString());
            }
            return isSuccess;
        }

        public bool RemoveBook(int Id)
        {
            bool isSuccess = true;
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    using (var Context = new LibraryContext())
                    {
                        var removeBook = Context.Books.Where(b => b.Id == Id).FirstOrDefault();
                        Context.Books.Remove(removeBook);
                        Context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                isSuccess = false;
                File.AppendAllText(@"Exception Entity log.txt", DateTime.Now.ToString() + "   RemoveBook method   " + ex.ToString());
            }
            return isSuccess;
        }
    }
}