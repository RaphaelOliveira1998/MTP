# MTP

Teste 01 ->

#ToDo List

Este é um guia passo a passo para configurar e executar o projeto na sua máquina local.


#Pré-requisitos

.NET Core SDK
SQL Server Express
Git


#Passos para a configuração

1. Clone o repositório: Clone o repositório do projeto para a sua máquina local usando o comando git clone.

2. Crie o banco de dados: Abra o SQL Server Management Studio e crie um novo banco de dados chamado master.

3. Atualize a string de conexão: A string de conexão no arquivo appsettings.json já está configurada para usar o SQL Server Express na sua máquina local. Se a sua configuração for diferente, atualize a string de conexão.

4. Instale as dependências do projeto: Na raiz do projeto, execute o comando *dotnet restore* para instalar todas as dependências do projeto.

5. Execute as migrações do Entity Framework: Se você estiver usando o Entity Framework, execute as migrações para criar as tabelas no banco de dados. Você pode fazer isso com o comando *dotnet ef database update*.

6. Compile e execute o projeto: Compile e execute o projeto com o comando *dotnet run*.

7. Acesse a aplicação web: Abra um navegador e acesse [ToDoList](http://localhost:5076/index.html) para iniciar a aplicação web.


Contato
Se você tiver algum problema ou dúvida, por favor, abra uma issue ou entre em contato comigo diretamente.