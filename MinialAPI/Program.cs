

using MinialAPI.Model;

var builder = WebApplication.CreateBuilder(args);

//Habilitando o swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//Instanciando Repositrio em Memoria
var repositorio = new RepositorioPessoa(true);

app.UseSwagger();//Ativando Swagger

//Endpoints da Solução
app.MapGet("/", () => "Hello World!");

//buscar pessoa pelo CPF.
app.MapGet("/ListaPessoas/{cpf}", (string cpf) => {
    return repositorio.SelecionarPessoa(cpf);
});

//listar pessoas.
app.MapGet("/ListaPessoas",() =>
{
    return repositorio.ListarPessoas();
});

//adiconar pessoas.
app.MapPost("/ListaPessoas/inserir",(Pessoa pessoa) =>
{
    return repositorio.AdicionarPessoas(pessoa);
});

//atualizar pessoa
app.MapPut("/ListaPessoas/atualizar",(Pessoa pessoa) =>
{
    return repositorio.AtuaizarPessoas(pessoa);
});

//Deletar pessoa
app.MapDelete("/ListaPessoas/deletar",(string cpf) =>
{
    return repositorio.RemoverPessoas(cpf);
});

//Ativando Interface Swagger
app.UseSwaggerUI();

app.Run();
