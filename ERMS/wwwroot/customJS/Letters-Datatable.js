$(document).ready(function () {
    $("#Letters").DataTable({
        responsive: true,
        processing: true,
        serverSide: true,
        language: { "info": "Showing _START_ to _END_ of _TOTAL_ entries" },
        filter: false,


        ajax: {
            url: "/api/Letters",
            dataSrc: "data"




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