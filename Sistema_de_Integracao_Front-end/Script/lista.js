const apiUrl = 'https://localhost:7180/Cliente';
const statusApiUrl = 'https://localhost:7180/SituacaoCliente'; 


const situacaoClienteMap = {
    1: { descricao: 'Ativo', classe: 'situacao-ativo' },
    2: { descricao: 'Inativo', classe: 'situacao-inativo' },
    3: { descricao: 'Bloqueado', classe: 'situacao-bloqueado' }
};

document.addEventListener('DOMContentLoaded', () => {
    loadClients();
});

async function loadClients() {
    try {
        const response = await fetch(apiUrl);
        if (!response.ok) {
            throw new Error('Erro ao carregar clientes');
        }
        const clients = await response.json();
        console.log(clients); // Adicione esta linha para depurar
        const clientList = document.getElementById('clientList');
        clientList.innerHTML = '';
        clients.forEach(client => {
            const listItem = document.createElement('li');
            
            const situacao = situacaoClienteMap[client.situacaoClienteId] || { descricao: 'Desconhecida', classe: '' };
            listItem.textContent = `ID: ${client.id}, Nome: ${client.nome}, CPF: ${client.cpf}, Situação: ${situacao.descricao}`;
            
           
            if (situacao.classe) {
                listItem.classList.add(situacao.classe);
            } else {
               
                listItem.classList.add('default-status');
            }
            
            const deleteButton = document.createElement('button');
            deleteButton.textContent = 'Deletar';
            deleteButton.style.backgroundColor = '#e74c3c'; // Cor vermelha
            deleteButton.style.color = 'white'; // Cor do texto
            deleteButton.style.border = 'none'; // Sem borda
            deleteButton.style.borderRadius = '4px'; // Bordas arredondadas
            deleteButton.style.padding = '6px 12px'; // Espaçamento interno
            deleteButton.style.fontSize = '14px'; // Tamanho da fonte
            deleteButton.style.cursor = 'pointer'; // Cursor de pointer
            deleteButton.style.marginLeft = '10px'; // Espaçamento entre o nome e o botão
            deleteButton.addEventListener('click', () => deleteClient(client.id));

            listItem.appendChild(deleteButton);
            clientList.appendChild(listItem);
        });
    } catch (error) {
        displayMessage('Erro ao carregar a lista de clientes', true);
    }
}

async function deleteClient(id) {
    try {
        const response = await fetch(`${apiUrl}/${id}`, {
            method: 'DELETE'
        });
        if (!response.ok) {
            throw new Error('Erro ao deletar cliente');
        }
        displayMessage('Cliente deletado com sucesso', false);
        loadClients();  // Atualizar a lista de clientes após deletar
    } catch (error) {
        displayMessage('Algo deu errado ao deletar o cliente', true);
    }
}

function displayMessage(message, isError = false) {
    const messageBox = document.getElementById('message');
    messageBox.textContent = message;
    if (isError) {
        messageBox.className = 'error-message';
    } else {
        messageBox.className = 'success-message';
    }
}

// Configuração do CORS no servidor
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy => policy
            .WithOrigins(
                "http://localhost:5500",
                "http://127.0.0.1:5500",
                "http://localhost:5502",      // Adicione esta linha
                "http://127.0.0.1:5502"       // Adicione esta linha
            )
            .AllowAnyHeader()
            .AllowAnyMethod()
    );
});



// Alternância de tema
const themeToggle = document.getElementById('themeToggle');
const prefersDark = window.matchMedia('(prefers-color-scheme: dark)').matches;
const savedTheme = localStorage.getItem('theme');
if (savedTheme === 'light' || (!savedTheme && !prefersDark)) {
    document.body.classList.add('light');
    themeToggle.textContent = '🌞';
}
themeToggle.addEventListener('click', () => {
    document.body.classList.toggle('light');
    const isLight = document.body.classList.contains('light');
    themeToggle.textContent = isLight ? '🌞' : '🌙';
    localStorage.setItem('theme', isLight ? 'light' : 'dark');
});
