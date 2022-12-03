
// Passando a variavel de ambiente para o DbContext

// app.MapGet("/", () => "Hello World!");


//Tabela de relacionamento de um para um

//Tabela de relacionamento de um para muitos
public class Product {
    public int Id {get; set;}
    public string? Code {get; set;}
    public string? Name {get; set;}
    public string? Description {get; set;}

    //Campo de relacionamento de um para um
    public int CategoryId {get; set;}
    public Category Category {get; set;}

    public List<Tag> Tags {get; set;}

}
