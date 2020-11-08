$(document).ready(function () {
    studentJs = new StudentJS();
})

var error = { code: "", firstName: "", lastName: "", email: "", className: "" };

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

        // khi click vào nút Lưu thì gọi đến hàm lưu thông tin
        $("#btn-save").on("click", this.SaveValueForm.bind(this));
        
    }

    // Hàm mở form nhập liệu lên
    OpenForm() {
        // hiện model
        $("#model").show();

        // focus vào ô đầu tiên
        $('#model input')[0].focus();
    }

    // Hàm đóng lại form
    CloseForm() {
        $("#model").hide();
    }

    // Sửa thông tin sinh viên
    EditStudent() {
        // mở form
        this.OpenForm();

        // in thông tin lên form

    }

    // lưu thông tin
    SaveValueForm() {
        // kiểm tra nhập liệu
        var hasError = this.Validate();

        // nếu có lỗi thì thông báo lỗi
        if (hasError) {
            alert("Các trường đánh dấu (*) không được để trống. Vui lòng kiểm tra lại!");
        } else {
            // lấy thông tin từ form
            var student = this.GetValueForm();
            $.ajax({
                url: "/api/Students",
                method: "POST",
                dataType: 'json',
                data: JSON.stringify(student),
                contentType: 'application/json'
            }).done(function (e) {
                alert("Thêm mới sinh viên thành công!");
                this.CloseForm();
            }).fail(function (e) {
                alert("Thất bại, vui lòng thử lại");
            })
        }

    }

    // Lấy dữ liệu từ form và map lên đối tượng student
    GetValueForm() {
        var student = {
            studentCode: $("#studentCode").val(),
            firstName: $("#firstName").val(),
            lastName: $("#lastName").val(),
            email: $("#email").val(),
            gender: parseInt($("#gender").val()),
            className: $("#className").val(),
            faculty: $("#faculty").val(),
            birthday: $("#birthday").val(),
            address: $("#address").val()
        };

        return student;
    }

    // Kiểm tra nhập liệu người dùng
    Validate() {
        // lấy dữ liệu
        var code = $("#studentCode").val();
        var firstName = $("#firstName").val();

        // biến check
        var hasError = false;

        // kiểm tra trường mã sinh viên
        if (code == null || code == "") {
            hasError = true;
        }

        // kiểm tra trường họ đệm
        if (firstName == null || firstName == "") {
            hasError = true;
        }

        // trả về kết quả có lỗi / không có lỗi
        return hasError;
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
                //alert(res)
            })

        } catch (e) {
            alert(e);
        }

    }
}