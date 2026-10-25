# API Álbuns do Radiohead

API RESTful desenvolvida em **C# com .NET 10**, utilizando **Entity Framework Core** e **SQLite** para o gerenciamento dos álbuns da banda Radiohead.

O projeto implementa operações CRUD (*Create, Read, Update e Delete*), permitindo consultar, cadastrar, atualizar e remover álbuns por meio de endpoints HTTP.

## Tecnologias Utilizadas

- **C#** — linguagem de programação.
- **.NET 10** — plataforma de desenvolvimento.
- **ASP.NET Core Minimal APIs** — criação dos endpoints REST.
- **Entity Framework Core** — mapeamento objeto-relacional e acesso aos dados.
- **SQLite** — banco de dados relacional.
- **Bruno** — ferramenta para testes das requisições HTTP.

## Vídeos do Projeto

- [Vídeo AP1](https://drive.google.com/file/d/1VlkuHsi0UWj_k_LaQ3wICZZgfD7D88ub/view?usp=sharing)
- [Vídeo AP2](https://drive.google.com/file/d/1hbZv-y5ZDE9FvZgv5vpQfCjR9tmKMQc-/view?usp=sharing)

## Requisitos

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- Pacotes NuGet do Entity Framework Core e do provedor SQLite configurados no projeto.
- String de conexão `Padrao` configurada no arquivo `appsettings.json`.

## Como Executar o Projeto

1. Clone o repositório e acesse a pasta raiz do projeto.
2. Verifique se a string de conexão `Padrao` está configurada corretamente no `appsettings.json`.
3. Confirme que o banco de dados SQLite e sua estrutura estão inicializados conforme a configuração do projeto.
4. Execute a aplicação pelo terminal:

```bash
dotnet restore
dotnet run
```

A aplicação será iniciada na URL informada pelo terminal. Caso esteja configurada para utilizar a porta `5050`, o endereço local será:

```text
http://localhost:5050
```

> **Observação:** a porta pode variar conforme as configurações de execução do projeto.

## Endpoints da API

| Método | Rota | Descrição | Sucesso |
|---|---|---|---|
| `GET` | `/api` | Verifica se a API está online | `200 OK` |
| `GET` | `/api/albuns` | Lista todos os álbuns cadastrados | `200 OK` |
| `GET` | `/api/albuns/{id}` | Busca um álbum pelo ID | `200 OK` |
| `POST` | `/api/albuns` | Cadastra um novo álbum | `201 Created` |
| `PUT` | `/api/albuns/{id}` | Atualiza um álbum existente | `200 OK` |
| `DELETE` | `/api/albuns/{id}` | Remove um álbum existente | `204 No Content` |

### Respostas de erro

As operações de busca, atualização e remoção retornam `404 Not Found` quando o álbum solicitado não existe.

O retorno contém uma mensagem informando que o álbum com o ID especificado não foi encontrado.

## Exemplos de Requisições

### 1. Verificar o status da API

**Requisição:**

```http
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

**Requisição:**

```http
GET /api/albuns
```

Retorna uma lista com os álbuns cadastrados no banco de dados.

### 3. Buscar álbum por ID

**Requisição:**

```http
GET /api/albuns/1
```

Retorna os dados do álbum correspondente ao ID informado ou `404 Not Found` caso ele não exista.

### 4. Cadastrar álbum

**Requisição:**

```http
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

**Requisição:**

```http
PUT /api/albuns/1
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

**Requisição:**

```http
DELETE /api/albuns/1
```

**Resposta:** `204 No Content` quando a remoção for concluída com sucesso.

Se o álbum não existir, será retornado `404 Not Found`.

## Banco de Dados

A aplicação utiliza **SQLite** para armazenar os dados dos álbuns e **Entity Framework Core** para realizar as operações de consulta e persistência.

Diferentemente de uma implementação que mantém os dados apenas em uma lista em memória, as alterações são gravadas no banco por meio de `SaveChangesAsync()`.

Dessa forma, os registros podem permanecer disponíveis após o encerramento da aplicação
