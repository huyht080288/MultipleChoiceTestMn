
USE [THITN]
GO

INSERT INTO [dbo].[MonHoc] ([MAMH], [TENMH]) VALUES
(N'AV001', N'Anh Văn Căn Bản'),
(N'AV002', N'Anh Văn Chuyên Ngành'),
(N'CSDL1', N'Cơ Sở Dữ Liệu'),
(N'CTDL1', N'Cấu Trúc Dữ Liệu & Giải Thuật'),
(N'LTC01', N'Lập Trình C/C++'),
(N'LTC02', N'Lập Trình C# .NET'),
(N'LTJ01', N'Lập Trình Java'),
(N'LTW01', N'Lập Trình Web'),
(N'MMT01', N'Mạng Máy Tính Căn Bản'),
(N'HDH01', N'Hệ Điều Hành'),
(N'CNPM1', N'Công Nghệ Phần Mềm'),
(N'PTTK1', N'Phân Tích Thiết Kế Hệ Thống'),
(N'TTNT1', N'Trí Tuệ Nhân Tạo'),
(N'ANM01', N'An Ninh Mạng'),
(N'TOAN1', N'Toán Cao Cấp A1'),
(N'TOAN2', N'Toán Cao Cấp A2'),
(N'TRR01', N'Toán Rời Rạc'),
(N'XSTK1', N'Xác Suất Thống Kê'),
(N'PLDC1', N'Pháp Luật Đại Cương'),
(N'TRIET', N'Triết Học Mác - Lênin');
GO


-- Xóa dữ liệu cũ nếu muốn test lại (Cẩn thận khi chạy trên production)
-- DELETE FROM [dbo].[GiaoVien_DangKy]; 

INSERT INTO [dbo].[GiaoVien_DangKy] 
([MAGV], [MALOP], [MAMH], [TRINHDO], [NGAYTHI], [LAN], [SOCAUTHI], [THOIGIAN]) 
VALUES
-- =============================================
-- ĐỢT 1: LỚP 01 (20 Môn - Lần 1)
-- =============================================
(N'gv01', N'lop01', N'ANM01', N'A', CAST(N'2026-06-01' AS DateTime), 1, 40, 60),
(N'gv02', N'lop01', N'AV001', N'A', CAST(N'2026-06-02' AS DateTime), 1, 50, 60),
(N'gv03', N'lop01', N'AV002', N'B', CAST(N'2026-06-03' AS DateTime), 1, 50, 60),
(N'gv04', N'lop01', N'CNPM1', N'B', CAST(N'2026-06-04' AS DateTime), 1, 40, 45),
(N'gv05', N'lop01', N'CSDL1', N'C', CAST(N'2026-06-05' AS DateTime), 1, 60, 90),
(N'gv06', N'lop01', N'CTDL1', N'C', CAST(N'2026-06-06' AS DateTime), 1, 40, 60),
(N'gv07', N'lop01', N'HDH01', N'A', CAST(N'2026-06-07' AS DateTime), 1, 40, 45),
(N'gv08', N'lop01', N'LTC01', N'A', CAST(N'2026-06-08' AS DateTime), 1, 30, 45),
(N'gv01', N'lop01', N'LTC02', N'B', CAST(N'2026-06-09' AS DateTime), 1, 40, 60),
(N'gv02', N'lop01', N'LTJ01', N'B', CAST(N'2026-06-10' AS DateTime), 1, 40, 60),
(N'gv03', N'lop01', N'LTW01', N'A', CAST(N'2026-06-11' AS DateTime), 1, 50, 60),
(N'gv04', N'lop01', N'MMT01', N'A', CAST(N'2026-06-12' AS DateTime), 1, 40, 45),
(N'gv05', N'lop01', N'PLDC1', N'C', CAST(N'2026-06-13' AS DateTime), 1, 60, 60),
(N'gv06', N'lop01', N'PTTK1', N'B', CAST(N'2026-06-14' AS DateTime), 1, 40, 60),
(N'gv07', N'lop01', N'TOAN1', N'C', CAST(N'2026-06-15' AS DateTime), 1, 30, 60),
(N'gv08', N'lop01', N'TOAN2', N'C', CAST(N'2026-06-16' AS DateTime), 1, 30, 60),
(N'gv01', N'lop01', N'TRIET', N'A', CAST(N'2026-06-17' AS DateTime), 1, 50, 45),
(N'gv02', N'lop01', N'TRR01', N'B', CAST(N'2026-06-18' AS DateTime), 1, 40, 60),
(N'gv03', N'lop01', N'TTNT1', N'B', CAST(N'2026-06-19' AS DateTime), 1, 40, 60),
(N'gv04', N'lop01', N'XSTK1', N'A', CAST(N'2026-06-20' AS DateTime), 1, 30, 45),

-- =============================================
-- ĐỢT 2: LỚP 02 (20 Môn - Lần 1)
-- =============================================
(N'gv05', N'lop02', N'ANM01', N'A', CAST(N'2026-07-01' AS DateTime), 1, 40, 60),
(N'gv06', N'lop02', N'AV001', N'B', CAST(N'2026-07-02' AS DateTime), 1, 50, 60),
(N'gv07', N'lop02', N'AV002', N'B', CAST(N'2026-07-03' AS DateTime), 1, 50, 60),
(N'gv08', N'lop02', N'CNPM1', N'A', CAST(N'2026-07-04' AS DateTime), 1, 40, 45),
(N'gv01', N'lop02', N'CSDL1', N'C', CAST(N'2026-07-05' AS DateTime), 1, 60, 90),
(N'gv02', N'lop02', N'CTDL1', N'C', CAST(N'2026-07-06' AS DateTime), 1, 40, 60),
(N'gv03', N'lop02', N'HDH01', N'A', CAST(N'2026-07-07' AS DateTime), 1, 40, 45),
(N'gv04', N'lop02', N'LTC01', N'B', CAST(N'2026-07-08' AS DateTime), 1, 30, 45),
(N'gv05', N'lop02', N'LTC02', N'A', CAST(N'2026-07-09' AS DateTime), 1, 40, 60),
(N'gv06', N'lop02', N'LTJ01', N'B', CAST(N'2026-07-10' AS DateTime), 1, 40, 60),
(N'gv07', N'lop02', N'LTW01', N'B', CAST(N'2026-07-11' AS DateTime), 1, 50, 60),
(N'gv08', N'lop02', N'MMT01', N'A', CAST(N'2026-07-12' AS DateTime), 1, 40, 45),
(N'gv01', N'lop02', N'PLDC1', N'C', CAST(N'2026-07-13' AS DateTime), 1, 60, 60),
(N'gv02', N'lop02', N'PTTK1', N'A', CAST(N'2026-07-14' AS DateTime), 1, 40, 60),
(N'gv03', N'lop02', N'TOAN1', N'C', CAST(N'2026-07-15' AS DateTime), 1, 30, 60),
(N'gv04', N'lop02', N'TOAN2', N'C', CAST(N'2026-07-16' AS DateTime), 1, 30, 60),
(N'gv05', N'lop02', N'TRIET', N'A', CAST(N'2026-07-17' AS DateTime), 1, 50, 45),
(N'gv06', N'lop02', N'TRR01', N'B', CAST(N'2026-07-18' AS DateTime), 1, 40, 60),
(N'gv07', N'lop02', N'TTNT1', N'B', CAST(N'2026-07-19' AS DateTime), 1, 40, 60),
(N'gv08', N'lop02', N'XSTK1', N'A', CAST(N'2026-07-20' AS DateTime), 1, 30, 45),

-- =============================================
-- ĐỢT 3: THI LẠI CHO LỚP 01 (10 Môn Khó - Lần 2)
-- =============================================
(N'gv01', N'lop01', N'CSDL1', N'B', CAST(N'2026-08-05' AS DateTime), 2, 60, 90), -- Thi lai CSDL
(N'gv02', N'lop01', N'CTDL1', N'B', CAST(N'2026-08-06' AS DateTime), 2, 40, 60), -- Thi lai CTDL
(N'gv03', N'lop01', N'LTC01', N'B', CAST(N'2026-08-08' AS DateTime), 2, 30, 45), -- Thi lai C++
(N'gv04', N'lop01', N'LTC02', N'A', CAST(N'2026-08-09' AS DateTime), 2, 40, 60), -- Thi lai C#
(N'gv05', N'lop01', N'LTJ01', N'A', CAST(N'2026-08-10' AS DateTime), 2, 40, 60), -- Thi lai Java
(N'gv06', N'lop01', N'TOAN1', N'B', CAST(N'2026-08-15' AS DateTime), 2, 30, 60), -- Thi lai Toan 1
(N'gv07', N'lop01', N'TOAN2', N'B', CAST(N'2026-08-16' AS DateTime), 2, 30, 60), -- Thi lai Toan 2
(N'gv08', N'lop01', N'TRR01', N'A', CAST(N'2026-08-18' AS DateTime), 2, 40, 60), -- Thi lai Toan Roi Rac
(N'gv01', N'lop01', N'XSTK1', N'B', CAST(N'2026-08-20' AS DateTime), 2, 30, 45), -- Thi lai Xac Suat
(N'gv02', N'lop01', N'AV002', N'A', CAST(N'2026-08-03' AS DateTime), 2, 50, 60); -- Thi lai Anh Van CN
GO