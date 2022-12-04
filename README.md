# Rest API ASP.NET

<p align="center">
  <img width="460" height="300" src="https://user-images.githubusercontent.com/68018921/205516952-7f91b047-97fd-4778-9817-ce775c970a4a.png">
</p>


CRUD Básico em ASP.NET com Mysql Docekr e EntityFrameworkCore

## 🚀 Começando

Para obter uma copia do projeto para execução basta seguir as etapas:

Clonar repositorio:

```
git clone https://github.com/le0henr1que/REST.API.NET.git
```

### 📋 Pré-requisitos

Para execução do projeto é preciso:

* .NET 6;
* MySql
* Docker (Opcional)



### 🔧 Execução

Para executar o projeto basta seguir as etapas:


Projeto por padrão rodando na porta:

`5068`

### Instalação das Dependências run:
```
dotnet build
```

### Para executar o projeto:

```
dotnet watch run
```


## 🏁 Rotas

### Publicas 

`GET`
```
/products/{id}
```
`DELETE
```
/products/{id}
```
`POST`
```
/products
```
```json
{
    "code": "5",
    "name": "Memory 16gb",
    "Description": "teste",
    "categoryId": 1, 
    "tags":["Computer", "Teste"]
}
```

`PUT`
```
/products/{id}
```
```json
{
    "code": "5",
    "name": "Memory 18gb",
    "Description": "teste",
    "categoryId": 1, 
    "tags":["Computer2", "Teste2", "Memory2"]
}
```


## 📄 Notas

🐋 Para que o banco de dados funcione, é necessário a instalação e conexão do MySql local ou em um container Docker


## 🎁 Feature

* Criar validação acertiva de dados 📢;


