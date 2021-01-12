// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function home()
{
    var home = document.getElementById("home");
    home.removeAttribute('class');
    home.setAttribute('class', "nav-link active");
    home.setAttribute('aria-selected', "true");
}
function privacy()
{
    var privacy = document.getElementById("privacy");
    privacy.removeAttribute('class');
    privacy.setAttribute('class', "nav-link active");
    privacy.setAttribute('aria-selected', "true");
}
function games()
{
    var games = document.getElementById("games");
    games.removeAttribute('class');
    games.setAttribute('class', "nav-link active");
    games.setAttribute('aria-selected', "true");
}
function articles()
{
    var articles = document.getElementById("articles");
    articles.removeAttribute('class');
    articles.setAttribute('class', "nav-link active");
    articles.setAttribute('aria-selected', "true");
}