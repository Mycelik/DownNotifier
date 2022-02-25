$(document).ready(function () {
    $("#newAppBtn").click(function () {
        var vm =
        {
            Name: $("#txtName").val(),
            Url: $("#txtUrl").val(),
            Active: $("#selecActive").val()
        };
        var json = JSON.stringify(vm); 
        $.ajax({
            url: "https://localhost:44325/api/App/newapp",
            method: 'post',
            dataType: 'json',
            contentType: "application/json; charset=utf-8",
            data: json,
            complete: function () {
                var appsTable = document.getElementById('tableApps').getElementsByTagName('tbody')[0];
                var active = "";
                if (vm.Active == "active") {
                    active="True"
                }
                else {
                    active="False"
                }
                var myHtml = "<td>" + vm.Name + "</td><td>" + vm.Url + "</td ><td>" + active + "</td><td><button type='button' class='btn btn-primary'>Edit</button></td><td><button type='button' class='btn btn-danger'>Delete</button></td>";
                var newRow = appsTable.insertRow(appsTable.rows.length);
                newRow.innerHTML = myHtml;
            }
        });
    });
    $(".btnAppDelete").click(function () {
        var appId = $(this).attr("appId");
        var tr = $(this).parent().parent();
        $.ajax({
            url: "https://localhost:44325/api/App/deleteapp/" + appId,
            method: 'post',
            dataType: 'json',
            contentType: "application/json; charset=utf-8",
            data: { id: appId },
            complete: function () {
                tr.remove();
            }
        });
    });
    $(".btnAppEdit").click(function (e) {
        var appId = $(this).attr("appId");
        var name = $(e.target).closest('tr').find("#tableName").html();
        var url = $(e.target).closest('tr').find("#tableUrl").html();
        $('#myModal').modal('show');
        $(".modal-body #txtName").val(name);
        $(".modal-body #txtUrl").val(url);
        $(".modal-body #modalAppId").val(appId);

    });
    $("#updateAppBtn").click(function () {
        var vm =
        {
            Id: $(".modal-body #modalAppId").val(),
            Name: $(".modal-body #txtName").val(),
            Url: $(".modal-body #txtUrl").val(),
            Active: $(".modal-body #modalActive").val()
        };
        var json = JSON.stringify(vm);
        $.ajax({
            url: "https://localhost:44325/api/App/updateapp",
            method: 'put',
            dataType: 'json',
            contentType: "application/json; charset=utf-8",
            data: json,
            complete: function () {
                alert("Update Done");
                $('#myModal').modal('hide');
            }
        });
    });
    $("#btnUrl").click(function () {
        var newUrl = $("#txtUrl").val();
        var json = JSON.stringify(newUrl);
        $.ajax({
            url: "https://localhost:44325/api/App/getapp",
            method: 'get',
            dataType: 'json',
            contentType: "application/json; charset=utf-8",
            data: { name: newUrl},
        });
    });
});