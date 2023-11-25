$('input[type="checkbox"]').on('change', function () {
    $(this).siblings('input[type="checkbox"]').not(this).prop('checked', false);
});