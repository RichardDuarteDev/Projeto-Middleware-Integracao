
// const themeToggle = document.getElementById('themeToggle');
// function setTheme(isLight) {
//     document.body.classList.toggle('light', isLight);
//     themeToggle.textContent = isLight ? '🌚' : '🌙';
//     themeToggle.title = isLight ? 'Tema claro' : 'Tema escuro';
// }
// themeToggle.addEventListener('click', () => {
//     const isLight = !document.body.classList.contains('light');
//     setTheme(isLight);
//     localStorage.setItem('theme', isLight ? 'light' : 'dark');
// });
// window.addEventListener('DOMContentLoaded', () => {
//     const saved = localStorage.getItem('theme');
//     setTheme(saved === 'light');
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
    const saved = localStorage.getItem('theme');
    setTheme(saved === 'light');
});
