document.addEventListener('DOMContentLoaded', () => {
    const loginForm = document.getElementById('loginForm');
    if (!loginForm) return;

    loginForm.addEventListener('submit', async (event) => {
        event.preventDefault();

        const username = document.getElementById('username').value;
        const password = document.getElementById('password').value;

        // Adicione este log para depuração
        console.log('Enviando:', { username, password });

        try {
            const response = await fetch('https://localhost:7267/Usuario/login', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                    'Accept': 'application/json'
                },
                body: JSON.stringify({ username, password }),
            });

            if (!response.ok) {
                throw new Error('Login failed');
            }

            const data = await response.json();
            localStorage.setItem('isLoggedIn', 'true'); // Adicione esta linha
            window.location.href = './html/workspace.html';
        } catch (error) {
            document.getElementById('error-message').textContent = 'Login falhou. Verifique suas credenciais.';
        }
    });
});



const themeToggle = document.getElementById('themeToggle');
        function setTheme(isLight) {
            document.body.classList.toggle('light', isLight);
            themeToggle.textContent = isLight ? '🌚' : '🌙';
            themeToggle.title = isLight ? 'Tema claro' : 'Tema escuro';
        }
        themeToggle.addEventListener('click', () => {
            const isLight = !document.body.classList.contains('light');
            setTheme(isLight);
            localStorage.setItem('theme', isLight ? 'light' : 'dark');
        });
        window.addEventListener('DOMContentLoaded', () => {
            const saved = localStorage.getItem('theme');
            setTheme(saved === 'light');
        });
