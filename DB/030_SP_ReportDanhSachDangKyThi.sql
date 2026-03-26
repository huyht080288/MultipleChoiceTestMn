USE [THITN]
GO

IF OBJECT_ID('dbo.SP_ReportDanhSachDangKyThi', 'P') IS NOT NULL
    DROP PROCEDURE dbo.SP_ReportDanhSachDangKyThi;
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Lấy danh sách đăng ký thi từ 2 cơ sở (Phân tán)
CREATE PROCEDURE [dbo].[SP_ReportDanhSachDangKyThi]
    @TUNGAY DATETIME,
    @DENNGAY DATETIME
AS
BEGIN
    SET NOCOUNT ON;

    -- 1. LẤY DỮ LIỆU Ở CƠ SỞ HIỆN TẠI (LOCAL)
    SELECT 
		CS.MACS AS MaCoSo,
        CS.TENCS AS TenCoSo,
        GV.HO + ' ' + GV.TEN AS TenGiaoVien,
        L.TENLOP AS TenLop,
        M.TENMH AS TenMonHoc,
        DK.TRINHDO AS TrinhDo,
        DK.NGAYTHI AS NgayThi,
        DK.LAN AS LanThi,
        DK.SOCAUTHI AS SoCau,
        DK.THOIGIAN AS ThoiGian
    FROM GiaoVien_DangKy DK
    INNER JOIN GiaoVien GV ON DK.MAGV = GV.MAGV
    INNER JOIN Lop L ON DK.MALOP = L.MALOP
    INNER JOIN MonHoc M ON DK.MAMH = M.MAMH
    INNER JOIN Khoa K ON GV.MAKH = K.MAKH
    INNER JOIN CoSo CS ON K.MACS = CS.MACS
    WHERE DK.NGAYTHI BETWEEN @TUNGAY AND @DENNGAY

    UNION ALL

    -- 2. LẤY DỮ LIỆU Ở CƠ SỞ CÒN LẠI (THÔNG QUA LINKED SERVER: LINK1)
    SELECT 
		CS.MACS AS MaCoSo,
        CS.TENCS AS TenCoSo,
        GV.HO + ' ' + GV.TEN AS TenGiaoVien,
        L.TENLOP AS TenLop,
        M.TENMH AS TenMonHoc,
        DK.TRINHDO AS TrinhDo,
        DK.NGAYTHI AS NgayThi,
        DK.LAN AS LanThi,
        DK.SOCAUTHI AS SoCau,
        DK.THOIGIAN AS ThoiGian
    FROM LINK1.THITN.dbo.GiaoVien_DangKy DK
    INNER JOIN LINK1.THITN.dbo.GiaoVien GV ON DK.MAGV = GV.MAGV
    INNER JOIN LINK1.THITN.dbo.Lop L ON DK.MALOP = L.MALOP
    INNER JOIN LINK1.THITN.dbo.MonHoc M ON DK.MAMH = M.MAMH
    INNER JOIN LINK1.THITN.dbo.Khoa K ON GV.MAKH = K.MAKH
    INNER JOIN LINK1.THITN.dbo.CoSo CS ON K.MACS = CS.MACS
    WHERE DK.NGAYTHI BETWEEN @TUNGAY AND @DENNGAY
    
    -- Sắp xếp tổng hợp theo Ngày thi giảm dần
    ORDER BY NgayThi DESC;
END
GO