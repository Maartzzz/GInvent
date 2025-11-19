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