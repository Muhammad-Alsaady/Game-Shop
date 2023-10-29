$(document).ready(function () {
    $('.js-delete').on('click', function () {
        var btn = $(this);
        console.log(btn.data('id'));
        const swalAlert = Swal.mixin({
            customClass: {
                confirmButton: 'btn btn-danger mx-2',
                cancelButton: 'btn btn-light'
            },
            buttonsStyling: false
        });
        swalAlert.fire({
            title: 'Are you sure you want to delete?',
            text: "You wont be able to revert this!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonText: 'Yes, delete it!',
            cancelButtonText: 'No, cancel!',
            reverseButtons: true
        }).then((result) => {
            console.log(result);

            if (result.isConfirmed) {
                $.ajax({
                    url: `Administrator/Games/DeleteGame/${btn.data('id')}`,
                    method: 'DELETE',
                    success: function () {
                        swal.fire(
                            'Deleted!',
                            'Game has been deleted.',
                            'success'
                        );
                        btn.parents('tr').fadeOut(500);
                    },
                    error: function () {
                        swal.fire(
                            'Oooops!',
                            'Something went wrong !',
                            'error'
                        );
                    }
                });
            }
        });
    });
});