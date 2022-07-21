function urlSearch(key, val) {
    var url = new URL(window.location.href);
    url.searchParams.set(key, val);
    if (key != "pageNum")
        url.searchParams.set("pageNum", 1);
    document.location.search = url.search;
}
