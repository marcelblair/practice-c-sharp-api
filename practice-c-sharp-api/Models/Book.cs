using System;
namespace practice_c_sharp_api.Models;

public class Book
{
    public int id { get; set; }
    public string name { get; set; }
    public string author { get; set; }
    public string publisher { get; set; }

    public Book() { }

    public Book(int id, string name, string author, string publisher)
    {
        this.id = id;
        this.name = name;
        this.author = author;
        this.publisher = publisher;
    }
} 