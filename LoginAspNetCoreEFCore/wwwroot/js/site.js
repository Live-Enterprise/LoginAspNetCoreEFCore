function Sucesso(data) {
    Swal.fire(
        'Sucesso',
        data.msg,
        'success'
    );
}

function Falha() {
    Swal.fire(
        'Falha',
        'Ocorreu um erro inesperado! Tente novamente mais tarde!',
        'error'
    );
}