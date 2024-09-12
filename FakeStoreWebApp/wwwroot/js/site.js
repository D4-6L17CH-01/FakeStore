window.AgregarClaseElemento = (Id, Classes) => {
    const element = document.getElementById(Id);
    if (element) {
        Classes.forEach(className => {
            element.classList.add(className);
        })
    }
}

window.InicializarTooltips = () => {
    const tooltipTriggerList = document.querySelectorAll('[data-bs-toggle="tooltip"]')
    const tooltipList = [...tooltipTriggerList].map(tooltipTriggerEl => new bootstrap.Tooltip(tooltipTriggerEl))
}

window.BoolNotification = (titulo, mensaje, icono) => {
    return new Promise(resolve => {
        Swal.fire({
            title: titulo,
            text: mensaje,
            icon: icono,
            showDenyButton: true,
            showCancelButton: false,
            confirmButtonText: "Si",
            denyButtonText: "No"
        }).then((result) => {
            resolve(result.isConfirmed);
        });
    })
}

window.printInvoice = (elementId) => {
    var printWindow = window.open('', '', 'height=500,width=800');
    printWindow.document.write('<html><head><title>Imprimir Factura</title>');
    printWindow.document.write('<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous">');
    printWindow.document.write('<link rel = "stylesheet" href = "https://cdn.jsdelivr.net/npm/bootstrap-icons@1.10.5/font/bootstrap-icons.css">'); 
    printWindow.document.write('<link rel="stylesheet" href="css/app.css" />');
    printWindow.document.write('</head><body class="container"><div class="container">');
    printWindow.document.write(document.getElementById(elementId).innerHTML);
    printWindow.document.write('</div></body></html>');
    printWindow.document.close();
    printWindow.print();
    printWindow.onafterprint = function () {
        printWindow.close();
    };
}

window.gotoURl = (url) => {
    window.location.replace(url);
}

//Implementar DataTable
window.initializeDataTable = function initializeDataTable(table) {
    $(document).ready(function () {
        $(table).DataTable();
    });
}