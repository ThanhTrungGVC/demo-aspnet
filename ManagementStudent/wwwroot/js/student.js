$(document).ready(function () {
    studentJs = new StudentJS();
})

class StudentJS {
    constructor() {
        this.loadData();
        this.initEvent();
    }

    // hàm khởi tạo các sự kiện
    initEvent() {

        //Xử lý khi click chọn một hàng
        $("#tb_student").on("click", "tbody tr", function () {
            $('.item-selected').removeClass('item-selected');
            $(this).addClass("item-selected");
        });
    }

    ///hàm load thông tin sinh viên ra bảng
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
                    debugger
                    var trHTML = $(`<tr>
                                        <td class="item-center">`+ i + `</td>
                                        <td>`+ item.studentCode + `</td>
                                        <td>`+ item.fullName + `</td>
                                        <td>`+ item.email + `</td>
                                        <td>`+ item.faculty + `</td>
                                        <td>`+ item.className + `</td>
                                        <td class="item-right">`+ item.gpa + `</td>
                                        <td>`+ item.address + `</td>
                                        <td class="item-center item-bold">`+ "..." + `</td>
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