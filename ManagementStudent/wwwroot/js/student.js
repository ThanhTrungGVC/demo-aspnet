$(document).ready(function () {
    studentJs = new StudentJS();
})

class StudentJS {
    constructor() {
        this.loadData();
    }

    loadData() {
        try {
            $.ajax({
                url: "/api/Students",
                method: "GET",
                dataType: 'json',
                contentType: 'application/json'
            }).done(function (res) {
                $("#tb_student tbody").empty();
                var i = 1;
                $.each(res, function (index, item) {
                    var trHTML = $(`<tr>
                                        <td>`+ i + `</td>
                                        <td>`+ item.studentCode + `</td>
                                        <td>`+ item.fullName + `</td>
                                    </tr>`);
                    $('#tb_student tbody').append(trHTML);
                    i++;
                })
            }).fail(function (res) {
                debugger;
                //alert(res)
            })

        } catch (e) {
            alert(e);
        }

    }
}