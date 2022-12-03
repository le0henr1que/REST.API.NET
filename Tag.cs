
// Passando a variavel de ambiente para o DbContext

// app.MapGet("/", () => "Hello World!");


//Tabela de relacionamento de um para um
//Tabela de relacionamento de um para muitos
public class Tag {
    public int Id {get; set;}

    public string Name {get; set;}

    public int ProductId {get; set;}
}
