USE [THITN]
GO

IF OBJECT_ID('dbo.SP_GetGiaoVienDangKyTheoMaGV', 'P') IS NOT NULL
    DROP PROCEDURE dbo.SP_GetGiaoVienDangKyTheoMaGV;
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Lấy danh sách đăng ký thi của một giáo viên cụ thể (Lọc theo MAGV)
CREATE PROCEDURE [dbo].[SP_GetGiaoVienDangKyTheoMaGV]
    @MAGV NCHAR(8)
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        MAGV, 
        MALOP, 
        MAMH, 
        TRINHDO, 
        NGAYTHI, 
        LAN, 
        SOCAUTHI, 
        THOIGIAN, 
        RowGuid
    FROM 
        GiaoVien_DangKy
    WHERE 
        RTRIM(LTRIM(MAGV)) = RTRIM(LTRIM(@MAGV))
    ORDER BY 
        NGAYTHI DESC;
END
GO