Meu App de Login
Este projeto é uma aplicação web simples que permite que os usuários façam login usando nome de usuário e senha. Ele é composto por uma página de login e uma página de área de trabalho onde rotas adicionais de API podem ser adicionadas.

my-login-app
├── src
│   ├── index.html          # Página de login
│   ├── workspace.html      # Página da área de trabalho para rotas adicionais da API
│   ├── css
│   │   └── styles.css      # Estilos CSS da aplicação
│   └── js
│       ├── login.js        # JavaScript responsável pela funcionalidade de login
│       └── workspace.js    # JavaScript da página da área de trabalho
├── package.json            # Arquivo de configuração do npm
└── README.md               # Documentação do projeto



Clone o repositório:

bash
Copiar
Editar
git clone <url-do-repositório>
cd my-login-app
Instale as dependências (se houver):

bash
Copiar
Editar
npm install
Abra a aplicação:
Abra o arquivo src/index.html no seu navegador para acessar a página de login.

Como Usar
Página de Login: Digite seu nome de usuário e senha e clique no botão de envio para fazer login. A aplicação enviará uma requisição POST para https://localhost:7267/Usuario/login com as credenciais fornecidas.

Página da Área de Trabalho: Após fazer login, você pode navegar até src/workspace.html para acessar funcionalidades adicionais e rotas da API.
