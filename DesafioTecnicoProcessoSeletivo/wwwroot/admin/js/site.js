function init() {
    console.log("Iniciou");
    setSearchIntoInput();
    setClearFilterButton();
    listenerCleanFilter();
    listenerSearchSubmit();

}

function setSearchIntoInput() {
    var search = window.location.search;
    var urlParams = new URLSearchParams(search);
    var searchTerm = urlParams.get('searchTerm');

    if (searchTerm) {
        var input = document.querySelector(".js-search-input");
        input.value = searchTerm;
    }
}

function setClearFilterButton() {
    var input = document.querySelector(".js-search-input");
    var clearButton = document.querySelector(".js-clear-filter-button");

    if (input.value != "") {
        clearButton.style.display = "block";
    } else {
        clearButton.style.display = "none";
    }
}

function listenerSearchSubmit() {
    const button = document.querySelector(".js-search-button");

    button.addEventListener("click", (e) => {
        var input = document.querySelector(".js-search-input");
        var url = window.location.pathname;

        if (input.value != "") {
            url = url + "?searchTerm=" + input.value;

            const link = document.createElement('a');
            link.href = url;
            link.style.display = 'none';
            document.body.appendChild(link);
            link.click();
        }
    });
}

function listenerCleanFilter() {
    var clearButton = document.querySelector(".js-clear-filter-button");

    clearButton.addEventListener("click", function () {
        var input = document.querySelector(".js-search-input");
        if (input) {
            input.value = "";
        }

        var currentUrl = new URL(window.location.href);
        currentUrl.searchParams.delete("searchTerm");
        window.location.href = currentUrl.toString();
    });
}

document.addEventListener('DOMContentLoaded', () => {
    init();
});