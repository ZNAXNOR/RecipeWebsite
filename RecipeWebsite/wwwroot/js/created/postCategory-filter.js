$(document).ready(function () {

    var selectedValue = sessionStorage.getItem('selectedPostCategory') || 'All';
    $('#post-filter').val(selectedValue);

    $('#post-filter').change(function () {
        var selectedValue = $(this).val();
        sessionStorage.setItem('selectedPostCategory', selectedValue);
    });
});