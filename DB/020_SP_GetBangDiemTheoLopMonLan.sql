USE [THITN]
GO

IF OBJECT_ID('SP_GetBangDiemTheoLopMonLan', 'P') IS NOT NULL
    DROP PROC SP_GetBangDiemTheoLopMonLan
GO

CREATE PROCEDURE [dbo].[SP_GetBangDiemTheoLopMonLan]
    @MALOP NCHAR(15), 
    @MAMH NCHAR(5),
    @LAN SMALLINT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        SV.MASV, 
        SV.HO, 
        SV.TEN, 
        BD.DIEM,
		BD.NGAYTHI
    FROM dbo.SINHVIEN SV
    -- Dùng LEFT JOIN kết hợp điều kiện Môn và Lần thi ngay trong mệnh đề ON
    -- Để đảm bảo lấy đủ 100% sinh viên của lớp đó
    LEFT JOIN dbo.BANGDIEM BD ON SV.MASV = BD.MASV 
                              AND BD.MAMH = @MAMH 
                              AND BD.LAN = @LAN
    WHERE SV.MALOP = @MALOP
    -- Sắp xếp theo vần Alpha B của Tên, sau đó đến Họ (Chuẩn danh sách VN)
    ORDER BY SV.TEN ASC, SV.HO ASC
END
GO