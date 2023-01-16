using System.ComponentModel.DataAnnotations.Schema;

namespace InitialAssignment.CRUD.Entities;

public partial class Book
{
    public int Id { get; set; }

    public string Author { get; set; } = null!;

    public string Classification { get; set; } = null!;

    public int Edition { get; set; }

    public string Editorial { get; set; } = null!;

    public string Title { get; set; } = null!;

    public decimal Price { get; set; }

    public DateTime PublicationDate { get; set; }

    [NotMapped]
    public int Top_Aux { get; set; }
}
