$(document).ready(function () {
    $('#proveedorForm').submit(function (e) {
        e.preventDefault();

        const idProveedor = $('#idProveedorEdit').val();
        const url = idProveedor
            ? `/Proveedor/EditarProv`
            : `/Proveedor/IngresarProv`;

        const datosForm = $(this).serialize();

        $.post(url, datosForm)
            .done(() => {
                alert(idProveedor ? 'Proveedor actualizado con éxito.' : 'Proveedor guardado con éxito.');
                location.reload();
            })
            .fail(() => {
                alert('Error al procesar la solicitud');
            });
    });
});


async function eliminarProv(idProveedor) {
    if (!confirm(`¿Está seguro de que desea eliminar el Proveedor con ID ${idProveedor}?`)) {
        return;
    }

    const url = `/Proveedor/EliminarProv?id=${idProveedor}`;

    try {
        const response = await fetch(url, {
            method: 'DELETE',
            headers: {
                'Content-Type': 'application/json'
            }
        });
        if (response.ok) {
            alert('Proveedor eliminado con éxito.');
            window.location.reload();

        } else if (response.status === 404) {
            alert('Error: Proveedor no encontrado.');
        } else {
            alert('Error al eliminar el proveedor: ' + response.statusText);
        }

    } catch (error) {
        console.error('Error de red o desconocido:', error);
        alert('Ocurrió un error inesperado al intentar eliminar.');
    }
}
async function editarProv(idProveedor) {
    $.get(`/Proveedor/BuscarProv?id=${idProveedor}`, function (data) {
        $('#nombreProveedor').val(data.nombreProveedor);
        $('#contactoProveedor').val(data.contactoProveedor);

        if ($('#idProveedorEdit').length === 0) {
            $('#proveedorForm').prepend(`<input type="hidden" id="idProveedorEdit" name="idProveedor" />`);
        }
        $('#idProveedorEdit').val(data.idProveedor);

        const submitButton = $('#proveedorForm button[type="submit"]');
        submitButton.text('Actualizar Proveedor').removeClass('btn-primary').addClass('btn-success');
    });
}
d