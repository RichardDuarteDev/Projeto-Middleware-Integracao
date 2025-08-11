// // This file contains the JavaScript logic for the workspace page.
// // Additional API routes and functionalities will be implemented here.

// document.addEventListener('DOMContentLoaded', function() {
//     // Code to initialize the workspace and set up API routes will go here.

//     // Example function to fetch data from an API endpoint
//     function fetchData(apiEndpoint) {
//         fetch(apiEndpoint)
//             .then(response => {
//                 if (!response.ok) {
//                     throw new Error('Network response was not ok');
//                 }
//                 return response.json();
//             })
//             .then(data => {
//                 console.log(data);
//                 // Process and display the data as needed
//             })
//             .catch(error => {
//                 console.error('There was a problem with the fetch operation:', error);
//             });
//     }

//     // Example usage of fetchData function
//     // fetchData('https://localhost:7267/SomeOtherApiEndpoint');
// });



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
    // Validação de sessão
    if (localStorage.getItem('isLoggedIn') !== 'true') {
        window.location.href = '../Index_Login.html';
        return;
    }
    const saved = localStorage.getItem('theme');
    setTheme(saved === 'light');
});
