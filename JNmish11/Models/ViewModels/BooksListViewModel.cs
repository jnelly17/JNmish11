﻿namespace JNmish11.Models.ViewModels
{
    public class BooksListViewModel
    {
        public IQueryable<Book> Books { get; set;}
        public PaginationInfo PaginationInfo { get; set;} = new PaginationInfo();
        public string? CurrentBookCat { get; set;}
    }
}
