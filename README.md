# MTP

Teste 01 ->

Instruções para Executar a Aplicação ToDoList

Pré-requisitos

.NET Core SDK
SQL Server Express


Configuração do Banco de Dados

Instale o SQL Server Express na sua máquina.
Crie um banco de dados no SQL Server Express. Anote o nome do banco de dados, pois você precisará dele para configurar a string de conexão.
Abra o arquivo .env na raiz do projeto e substitua os valores das variáveis de ambiente pelos detalhes do seu banco de dados:
Substitua seu_servidor pelo nome do seu servidor SQL Server Express (por exemplo, localhost\\SQLEXPRESS) e seu_banco_de_dados pelo nome do banco de dados que você criou.


Executando a Aplicação

Abra um terminal na raiz do projeto.
Execute o comando dotnet restore para restaurar os pacotes NuGet.
Execute o comando dotnet run para iniciar a aplicação.
Abra um navegador e navegue até http://localhost:5076/index.html para ver a aplicação em execução.


Se você tiver algum problema para executar a aplicação, verifique se a string de conexão no arquivo .env está correta, se o banco de dados está acessível e se o endereço está igual ao mostrado no terminal da API.

Abrir link: http://localhost:5076/index.html