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
            // Xoá màu các dòng đã chọn trước đó
            $('.item-selected').removeClass('item-selected');

            // Đổi màu dòng được chọn
            $(this).addClass("item-selected");

            // Enable các nút sửa xoá nhân bản
            $("#btn_edit").prop("disabled", false);
            $("#btn_del").prop("disabled", false);
            $("#btn_doub").prop("disabled", false);
        });

        // khi click vào nút thêm thì hiện form thêm mới
        $("#btn_add").on("click", this.OpenForm);

        // khi click vào nút sửa thì gọi đến hàm sửa
        $("#btn_edit").on("click", this.EditStudent.bind(this));

        // khi click vào nút X đóng lại Form
        $("#model_exit").on("click", this.CloseForm);
        $("#btn-close").on("click", this.CloseForm);
        
    }

    // Hàm mở form nhập liệu lên
    OpenForm() {
        $("#model").show();
    }

    // Hàm đóng lại form
    CloseForm() {
        $("#model").hide();
    }


    // Sửa thông tin sinh viên
    EditStudent() {
        debugger
        // mở form
        this.OpenForm();
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