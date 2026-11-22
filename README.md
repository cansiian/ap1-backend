# API Álbuns do Radiohead

API RESTful desenvolvida em **C# com .NET 10**, utilizando **Entity Framework Core** e **SQLite** para o gerenciamento dos álbuns da banda Radiohead.

O projeto implementa operações CRUD (*Create, Read, Update e Delete*), permitindo consultar, cadastrar, atualizar e remover álbuns por meio de endpoints HTTP. Na avaliação semestral (AS), o código das avaliações AP1 e AP2 foi reorganizado em pastas e namespaces por responsabilidade, sem alterar o comportamento da API.

## Tecnologias Utilizadas

- **C#** — linguagem de programação.
- **.NET 10** — plataforma de desenvolvimento.
- **ASP.NET Core Minimal APIs** — criação dos endpoints REST.
- **Entity Framework Core** — mapeamento objeto-relacional e acesso aos dados.
- **SQLite** — banco de dados relacional.
- **Bruno** — ferramenta para testes das requisições HTTP.

## Vídeos do Projeto

- [Vídeo AP1](https://drive.google.com/file/d/1VlkuHsi0UWj_k_LaQ3wICZZgfD7D88ub/view)
- [Vídeo AP2](https://drive.google.com/file/d/1hbZv-y5ZDE9FvZgv5vpQfCjR9tmKMQc-/view?usp=sharing)

### Vídeo de demonstração — AS

- [Vídeo AS]()

## Requisitos

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- Ferramenta do Entity Framework Core para a linha de comando (`dotnet-ef`):

  ```
  dotnet tool install --global dotnet-ef
  ```

- String de conexão `Padrao` configurada no arquivo `appsettings.json`.
- [Bruno](https://www.usebruno.com/) para executar a Collection de testes.

## Como Executar o Projeto

O projeto usa **migrations** do Entity Framework Core. O arquivo do banco (`albuns.db`) não é versionado: ele é criado a partir das migrations, que também inserem os três álbuns iniciais da AP1 (OK Computer, Kid A e In Rainbows).

1. Clone o repositório e acesse a pasta raiz do projeto.
2. Restaure os pacotes, crie o banco e inicie a API:

```
dotnet restore
dotnet ef database update
dotnet run
```

A aplicação será iniciada na URL informada pelo terminal. Caso esteja configurada para utilizar a porta `5050`, o endereço local será:

```
http://localhost:5050
```

> **Observação:** a porta pode variar conforme as configurações de execução do projeto. Confira o valor no terminal e, se necessário, ajuste a variável de ambiente da Collection do Bruno.

## Estrutura de Pastas

```
ap1-backend/
├── Data/
│   └── AppDbContext.cs        # contexto do EF Core: DbSet<Album> e dados iniciais (seed)
├── Dtos/
│   └── AlbumEntradaDto.cs     # record com os dados recebidos no POST e no PUT
├── Models/
│   └── Album.cs               # entidade Album, mapeada para a tabela do banco
├── Migrations/                # histórico de migrations do EF Core (cria a tabela e o seed)
├── Properties/                # configurações de execução (launchSettings.json)
├── bruno/
│   └── Api Albuns/            # Collection do Bruno com as requisições e o ambiente local
├── wwwroot/                   # interface web já existente, servida como arquivos estáticos
├── Program.cs                 # inicialização, contexto, middleware e rotas
├── ApiAlbuns.csproj           # arquivo de projeto
├── appsettings.json           # configuração, incluindo a string de conexão "Padrao"
├── appsettings.Development.json
└── .gitignore                 # ignora bin/, obj/ e bancos locais
```

Namespaces: `ApiAlbuns.Models`, `ApiAlbuns.Dtos` e `ApiAlbuns.Data`. O `Program.cs` os importa com `using`.

## Endpoints da API

| Método   | Rota               | Descrição                         | Sucesso          |
| -------- | ------------------ | --------------------------------- | ---------------- |
| `GET`    | `/api`             | Verifica se a API está online     | `200 OK`         |
| `GET`    | `/api/albuns`      | Lista todos os álbuns cadastrados | `200 OK`         |
| `GET`    | `/api/albuns/{id}` | Busca um álbum pelo ID            | `200 OK`         |
| `POST`   | `/api/albuns`      | Cadastra um novo álbum            | `201 Created`    |
| `PUT`    | `/api/albuns/{id}` | Atualiza um álbum existente       | `200 OK`         |
| `DELETE` | `/api/albuns/{id}` | Remove um álbum existente         | `204 No Content` |

### Respostas de erro

As operações de busca, atualização e remoção retornam `404 Not Found` quando o álbum solicitado não existe.

O retorno contém uma mensagem informando que o álbum com o ID especificado não foi encontrado:

```json
{
  "mensagem": "Álbum com ID 99 não encontrado."
}
```

## Exemplos de Requisições

### 1. Verificar o status da API

```
GET /api
```

**Resposta — `200 OK`:**

```json
{
  "mensagem": "API de Álbuns do Radiohead no ar!",
  "status": "Online"
}
```

### 2. Listar álbuns

```
GET /api/albuns
```

Retorna uma lista com os álbuns cadastrados no banco de dados.

### 3. Buscar álbum por ID

```
GET /api/albuns/{id}
```

Retorna os dados do álbum correspondente ao ID informado ou `404 Not Found` caso ele não exista.

### 4. Cadastrar álbum

```
POST /api/albuns
Content-Type: application/json
```

**Payload:**

```json
{
  "titulo": "A Moon Shaped Pool",
  "anoLancamento": 2016,
  "numeroFaixas": 11
}
```

**Resposta:** `201 Created`, contendo os dados do álbum criado, incluindo o ID gerado pelo banco de dados.

### 5. Atualizar álbum

```
PUT /api/albuns/{id}
Content-Type: application/json
```

**Payload:**

```json
{
  "titulo": "A Moon Shaped Pool (Special Edition)",
  "anoLancamento": 2016,
  "numeroFaixas": 13
}
```

**Resposta:** `200 OK`, contendo os dados atualizados do álbum.

Se o ID não existir, a API retornará `404 Not Found`.

### 6. Remover álbum

```
DELETE /api/albuns/{id}
```

**Resposta:** `204 No Content` quando a remoção for concluída com sucesso.

Se o álbum não existir, será retornado `404 Not Found`.

## Collection do Bruno

A Collection está na pasta [`bruno/Api Albuns`](bruno/Api%20Albuns). Para usá-la:

1. Abra o Bruno e escolha **Open Collection**, selecionando a pasta `bruno/Api Albuns`.
2. Selecione o ambiente local e confirme que a porta é a mesma exibida pela API no terminal.
3. Execute as requisições na ordem: listar, cadastrar, buscar por ID, atualizar, excluir e buscar novamente (`404`).

A Collection não contém credenciais.

## Banco de Dados

A aplicação utiliza **SQLite** para armazenar os dados dos álbuns e **Entity Framework Core** para realizar as operações de consulta e persistência. O banco é preparado por **migrations** (`dotnet ef database update`); não há criação automática do banco ao iniciar a API.

Diferentemente de uma implementação que mantém os dados apenas em uma lista em memória, as alterações são gravadas no banco por meio de `SaveChangesAsync()`. Dessa forma, os registros permanecem disponíveis após o encerramento e a reinicialização da aplicação.
