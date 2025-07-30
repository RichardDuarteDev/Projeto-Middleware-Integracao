
# Projeto Middleware - Arquitetura Distribuída

Este projeto apresenta um modelo de integração de sistemas com arquitetura distribuída, utilizando aplicações monolíticas e APIs RESTful. O objetivo é integrar múltiplos sistemas internos de uma empresa por meio de uma camada de middleware, com autenticação JWT, gerenciamento de workspaces e comunicação segura via HTTPS.

---

# Diagrama do Projeto
![image](https://github.com/user-attachments/assets/e3d9bf39-b7d5-479c-9a02-ab96ce1b86fb)


## 🔧 Tecnologias Utilizadas

- **.NET MVC** (Aplicações monolíticas)
- **Web API REST** com **HTTPS**
- **SQL Server** (banco de dados para todos os sistemas)
- **JWT Token** (para autenticação segura)
- **Arquitetura distribuída** com separação de responsabilidades (UI, Backend, Integrações)

---

## 🎯 Objetivo

Permitir a autenticação centralizada dos usuários via `UI LOGIN` e integrar múltiplos sistemas corporativos com um sistema de integração robusto, escalável e seguro.

---

## 🧩 Visão Geral da Arquitetura

### 🔐 UI LOGIN (Front-end)
- Interface Web acessada via navegador.
- Exibe tela de login ao usuário.
- Envia requisição HTTPS com autenticação JWT à API Login.
- Ao autenticar, retorna um catálogo de sistemas disponíveis (workspaces).

### 🧠 API Login (Back-end)
- Responsável por autenticar usuários e gerar tokens JWT.
- Consulta banco de dados de usuários e permissões.
- Envia os dados autenticados para o front-end.
- Banco: **SQL Server - API Login**

### 🧱 MVC (Aplicação Monolítica)
- Aplicação legada corporativa integrada ao sistema.
- Integra via sistema de front-end de integração.
- Banco: **SQL Server - Banco MVC**

### 🔄 Sistema de Integração Front-End
- Interface responsável por agrupar as aplicações legadas (como o MVC).
- Encaminha chamadas REST para os respectivos back-ends.

### 🌐 Sistema de Integração Back-End
- Responsável por consumir dados dos sistemas de origem.
- Expõe endpoints REST (HTTPS).
- Trata e normaliza dados recebidos antes de persistir no banco ou devolver ao front-end.
- Banco: **SQL Server - Banco SI**

---

## 🔁 Fluxo de Trabalho (Workflow)

1. **Ator** acessa o sistema via navegador.
2. É exibida a **tela de login** (UI LOGIN).
3. A interface faz uma requisição HTTPS à **API Login**, passando as credenciais.
4. O backend valida o acesso no banco e, se válido, retorna um **JWT Token**.
5. Após login bem-sucedido, é carregada uma lista de **workspaces** dos sistemas integrados.
6. O usuário escolhe um workspace e interage com o sistema (ex: MVC).
7. O **Sistema de Integração Front-End** orquestra chamadas entre o usuário e os sistemas integrados.
8. Os dados fluem para o **Sistema de Integração Back-End**, que acessa os bancos e entrega as respostas.

---

## 📌 Observações

- O acesso à interface ocorre diretamente do dispositivo do usuário.
- Neste modelo, **NGINX não é abordado**, mas poderia ser incorporado em cenários com controle de carga ou proxy reverso.
- O **MVC e o UI LOGIN são sistemas monolíticos legados**, mas ainda fazem parte da arquitetura integrada.
- Toda comunicação entre front-end e back-end é feita via **HTTPS com autenticação JWT**.

---

## 🗂️ Organização dos Bancos de Dados

| Sistema                | Banco              | Tipo       |
|------------------------|--------------------|------------|
| MVC                    | Banco MVC          | SQL Server |
| API Login              | Banco API Login    | SQL Server |
| Integração Back-End    | Banco SI           | SQL Server |

---

## 📎 Considerações Finais

Este projeto é uma base sólida para ambientes corporativos que precisam integrar múltiplos sistemas legados com segurança e controle de acesso centralizado. A arquitetura proposta permite fácil expansão para novas aplicações, modularização e aplicação de boas práticas modernas em sistemas distribuídos.
