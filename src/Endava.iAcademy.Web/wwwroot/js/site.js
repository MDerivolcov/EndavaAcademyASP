// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function changeSort(value) {
    window.location.replace('?sortParam=' + value.value)
}

function changeCategory(value) {
    window.location.replace('?categoryParam=' + value.value)
}
