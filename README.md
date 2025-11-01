# MultipleChoiceTestMn
# Đồ án môn học: Cơ sở dữ liệu Phân tán
## Đề tài: Xây dựng Hệ thống Thi Trắc nghiệm (THITN)

### 1. Mô tả Đề tài

[cite_start]Đây là dự án cho môn học Cơ sở dữ liệu Phân tán, cài đặt một hệ thống thi trắc nghiệm trực tuyến[cite: 1]. [cite_start]Hệ thống được thiết kế để hỗ trợ nghiệp vụ cho một trường đại học có hai cơ sở (CS1, CS2), với cơ sở dữ liệu `THITN` được phân tán làm 3 mảnh[cite: 2].

---

### 2. Kiến trúc Phân tán

[cite_start]Hệ thống được triển khai trên 3 máy chủ (server) với chiến lược phân mảnh CSDL như sau[cite: 2]:

* [cite_start]**Máy chủ 1 (Phân mảnh 1):** Đặt tại Cơ sở 1. Chứa thông tin các lớp và các lượt đăng ký thi trắc nghiệm của các lớp thuộc Cơ sở 1[cite: 3].
* [cite_start]**Máy chủ 2 (Phân mảnh 2):** Đặt tại Cơ sở 2. Chứa thông tin các lớp và các lượt đăng ký thi trắc nghiệm của các lớp thuộc Cơ sở 2[cite: 4].
* **Máy chủ 3 (Phân mảnh 3):** Máy chủ tra cứu. [cite_start]Chứa thông tin các lớp và sinh viên của cả hai cơ sở 1 và 2, dùng cho mục đích tra cứu[cite: 5].

---

### 3. Chức năng chính của Ứng dụng

Chương trình bao gồm các chức năng nghiệp vụ sau:

1.  [cite_start]**Đăng nhập:** Hỗ trợ đăng nhập cho nhiều vai trò với giao diện 2 tab (Giảng viên và Sinh viên), yêu cầu chọn Cơ sở, Login và Password[cite: 6].
2.  [cite_start]**Quản lý Môn học:** Form cho phép Thêm, Xóa, Ghi, Phục hồi, Reload dữ liệu môn học[cite: 7].
3.  [cite_start]**Quản lý Khoa, lớp:** Form nhập liệu dạng SubForm (Master-Detail) cho cả 2 bảng Khoa và Lớp[cite: 8].
4.  [cite_start]**Quản lý Sinh viên:** Form nhập liệu dạng SubForm cho phép quản lý sinh viên theo từng lớp[cite: 9].
5.  [cite_start]**Quản lý Giáo viên:** Form nhập liệu dạng SubForm cho phép quản lý giáo viên theo từng khoa[cite: 10].
6.  **Nhập Đề:** Form dành cho giáo viên nhập bộ đề (bảng `Bo_de`). [cite_start]Giáo viên chỉ thấy và cập nhật được các câu hỏi do chính mình soạn[cite: 11].
7.  [cite_start]**Chuẩn bị Thi:** Chức năng cho phép "Nhân viên" (vai trò Cơ sở) đăng ký lịch thi cho các lớp, bao gồm môn thi, trình độ, số câu, ngày thi, thời gian...[cite: 12].
8.  **Thi:** Chức năng chính dành cho sinh viên.
    * [cite_start]Hệ thống tự động lọc câu hỏi ngẫu nhiên dựa trên lịch thi đã đăng ký[cite: 13].
    * [cite_start]**Giao tác phân tán:** Ưu tiên lấy câu hỏi tại cơ sở của lớp, nếu thiếu mới lấy thêm ở cơ sở còn lại[cite: 16].
    * [cite_start]Hỗ trợ logic phân phối trình độ (70% trình độ cao, 30% trình độ thấp hơn)[cite: 15].
    * [cite_start]Tự động chấm điểm, thông báo kết quả và ghi vào `Bangdiem` khi hết giờ[cite: 14].
9.  [cite_start]**Xem Kết quả:** Cho phép sinh viên xem lại chi tiết bài thi đã làm (Câu hỏi, Các lựa chọn, Đáp án đúng, Đáp án đã chọn)[cite: 17].
10. [cite_start]**Bảng điểm Môn học:** Báo cáo dành cho giáo viên, in bảng điểm của một lớp theo môn học và lần thi[cite: 18].
11. [cite_start]**Báo cáo Đăng ký (Phân tán):** Báo cáo tổng hợp danh sách đăng ký thi từ cả 2 cơ sở, lọc theo ngày và nhóm theo từng cơ sở[cite: 19].
12. [cite_start]**Phân quyền:** Quản lý tài khoản và quyền hạn người dùng[cite: 20].

---

### 4. Phân quyền Hệ thống

[cite_start]Hệ thống sử dụng 4 nhóm quyền (Database Roles) để quản lý truy cập[cite: 20]:

* **Truong:**
    * [cite_start]Có thể đăng nhập vào bất kỳ phân mảnh nào để *xem dữ liệu*[cite: 21].
    * [cite_start]Xem được các báo cáo[cite: 22].
    * [cite_start]Được phép tạo login mới thuộc nhóm `Truong`[cite: 23].
* **CoSo:**
    * [cite_start]Có *toàn quyền* làm việc (Thêm, Xóa, Sửa) trên cơ sở của mình[cite: 24].
    * [cite_start]Không được phép đăng nhập vào cơ sở khác[cite: 24].
    * [cite_start]Được tạo tài khoản mới cho nhóm `Coso` và `Giangvien`[cite: 24].
* **Giangvien:**
    * [cite_start]Chỉ được quyền cập nhật đề thi và chỉ thấy/sửa các câu hỏi do mình soạn[cite: 25].
    * [cite_start]Được thi thử (không ghi điểm)[cite: 25].
* **Sinhvien:**
    * [cite_start]Sử dụng một tài khoản SQL chung để kết nối CSDL (sau khi đã xác thực bằng `MASV` và `PASSWORD` cá nhân)[cite: 26].
    * [cite_start]Có 2 quyền chính: **Thi** và **Xem lại bài thi**[cite: 26].

---

### 5. Cấu trúc Cơ sở dữ liệu

CSDL `THI_TN` bao gồm 9 bảng chính:

1.  [cite_start]`CoSo` [cite: 27]
2.  [cite_start]`Khoa` [cite: 28]
3.  [cite_start]`Lop` [cite: 29]
4.  [cite_start]`Monhoc` [cite: 30]
5.  [cite_start]`Sinhvien` (chứa `PASSWORD` để sinh viên xác thực) [cite: 31]
6.  [cite_start]`Giaovien` [cite: 32]
7.  [cite_start]`Giaovien_Dangky` (Bảng nghiệp vụ đăng ký thi) [cite: 33]
8.  [cite_start]`BODE` (Ngân hàng câu hỏi) [cite: 34]
9.  [cite_start]`BangDiem` (Kết quả thi của sinh viên) [cite: 35]