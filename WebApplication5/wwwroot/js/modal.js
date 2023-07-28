function openModal(parameters) {
    const id = parameters.data;
    const url = parameters.url;
    const modal = $('#modal');

    if (id == undefined || url == undefined) {
        alert('Упсс...')
        return;
    }

    $.ajax(
        {
            type: 'GET',
            url: url,
            data: { "id": id },
            success: function (response) {
                $('.modal-dialog');
                modal.find(".modal-content").html(response);
                modal.modal('show')
            },
            failure: function () {
                modal.modal('hide')
            },
            error: function (response) {
                alert(response.responseText)
            }
        });
};