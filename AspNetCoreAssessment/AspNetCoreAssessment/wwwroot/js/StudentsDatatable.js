$(document).ready(function () {
    $('#StudentsList').dataTable({
        "processing": true,
        "serverSide": true,
        "filter": true,
        "responsive": true,
        "scrollY": '400px',
        "scrollCollapse": true,
        "scrollX": true,
        "paging": true,
        "searching": true,
        "ordering": true,

        "info": true,
        "ajax": {
            "url": "/api/StudentList",
            "type": "POST",
            "datatype": "json"
        },
        "columnDefs": [{
            "targets": [0],
            "visible": true,
            "searchable": false,
            "autoWidth": true,
        }],
        "columns": [

            {
                "data": "ssn", "name": "Ssn", "autowidth": true
            },
            {
                "render": function (data, type, row) {
                    return '<img src=' + row.photo + '  /> '
                },
                "orderable": false,
                "autowidth": true
            },
            {
                "data": "firstName", "name": "FirstName", "autowidth": true
            },
            {
                "data": "lastName", "name": "LastName", "autowidth": true
            },
            {
              
                "data": "genderNavigation.name", "name": "GenderNavigation.Name", "autowidth": true
            },
            {
                "data": "phoneNumber", "name": "PhoneNumber", "autowidth": true
            },
            {
                "data": "birthday", "name": "Birthday", "autowidth": true
            },      
            {
                "data": "stageNavigation.name", "name": "StageNavigation.Name", "autowidth": true
            },             
            {
                "data": "emailAddress", "name": "EmailAddress", "autowidth": true
            },              
            {
                "data": "address", "name": "Address", "autowidth": true
            } 
        ]
    });
});