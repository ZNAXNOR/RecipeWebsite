// Search bar
$(document).ready(function () {
    $('#text-suggestion').autocomplete({
        source: function (request, response) {
            $.ajax({
                url: '@Url.Action("TextSuggestions", "Searchbar")',
                data: { term: request.term },
                dataType: 'json',
                success: function (data) {
                    response(data);
                }
            });
        }
    });
});

