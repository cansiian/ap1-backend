# API Álbuns do Radiohead

API RESTful minimal desenvolvida em **C#** para o gerenciamento de álbuns da banda **Radiohead**.

O objetivo da aplicação é disponibilizar um CRUD simples para **consulta, cadastro, alteração e remoção** dos álbuns da banda mantidos na biblioteca.

---

# Link do Video

https://drive.google.com/file/d/1VlkuHsi0UWj_k_LaQ3wICZZgfD7D88ub/view?usp=sharing

---

## Requisitos

* **.NET 10 SDK**

---

## Como Executar o Projeto

Abra o terminal na pasta raiz do projeto.

Execute o comando abaixo para iniciar o servidor local:

```bash
dotnet run
```

---

## URL Local para Testes

Após iniciar a aplicação, a API estará disponível no seguinte endereço:

```text
http://localhost:5050
```

> **Observação:** caso a porta configurada no seu ambiente seja diferente ao executar `dotnet run`, utilize a porta indicada no terminal para realizar os testes.

---

## Armazenamento de Dados

Os dados da aplicação são armazenados **apenas em memória**, dentro de uma lista interna (`List`).

Por esse motivo, as alterações realizadas através dos métodos **POST**, **PUT** ou **DELETE** serão perdidas assim que o processo da aplicação for encerrado ou reiniciado.

---

## Endpoints da API

| Método   | Rota               | Descrição                                     | Status de Sucesso |
| -------- | ------------------ | --------------------------------------------- | ----------------- |
| `GET`    | `/`                | Informa que a API está no ar                  | `200 OK`          |
| `GET`    | `/api/albuns`      | Lista todos os álbuns cadastrados             | `200 OK`          |
| `GET`    | `/api/albuns/{id}` | Retorna os detalhes de um álbum pelo ID       | `200 OK`          |
| `POST`   | `/api/albuns`      | Cadastra um novo álbum                        | `201 Created`     |
| `PUT`    | `/api/albuns/{id}` | Atualiza as informações de um álbum existente | `200 OK`          |
| `DELETE` | `/api/albuns/{id}` | Remove um álbum da lista pelo ID              | `204 No Content`  |

---

## Exemplos de Payloads JSON

### Requisição POST

**Endpoint:**

```text
POST /api/albuns
```

**Payload:**

```json
{
  "titulo": "A Moon Shaped Pool",
  "anoLancamento": 2016,
  "numeroFaixas": 11
}
```

---

### Requisição PUT

**Endpoint:**

```text
PUT /api/albuns/{id}
```

**Payload:**

```json
{
  "titulo": "A Moon Shaped Pool (Special Edition)",
  "anoLancamento": 2016,
  "numeroFaixas": 13
}
```

---

## Collection de Testes

Os arquivos de requisição configurados para o **Bruno** estão disponíveis no repositório no seguinte diretório:

/bruno
/bruno
```

A collection pode ser utilizada para realizar os testes dos endpoints da API de forma prática.
