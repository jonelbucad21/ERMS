$(document).ready(function () {
    
    $("#Letters").DataTable({
     //   serverSide: true,
        responsive: true,
        processing: true,
        language: { // "info": "Showing _START_ to _END_ of _TOTAL_ entries"
            "lengthMenu": "Display _MENU_ records per page",
            "zeroRecords": "Nothing found - sorry",
            "info": "Showing page _PAGE_ of _PAGES_ from _MAX_ total records",
            "infoEmpty": "No records available",
            "infoFiltered": "(filtered from _MAX_ total records)"
        },
  
       
        filter: false,
        paginate: false,
        info: false,
        ajax: {
            url: "/api/Letters/1/10",
            dataSrc: "aadata"

        },
        columns: [
            {
                data: "Id",
                name: "Id",
                autoWidth: true

            },
            {
                data: "Title",
                name: "Title",
                autoWidth: true
            },
            {
                data: "Summary",
                name: "Summary",
                autoWidth: true
            },
            {
                data: "LetterType.Name",
                name: "LetterType",
                autoWidth: true
            },
            {
                data: "Sender.Name",
                name: "Sender",
                autoWidth: true
            },
            {
                data: "GetDateCreated",
                name: "DateCreated",
                autoWidth: true
            },
            {

                data: "GetEntryDate",
                name: "EntryDate",
                autoWidth: true
            }
        ]
    });
    
});

