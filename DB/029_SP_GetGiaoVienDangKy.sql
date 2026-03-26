USE [THITN]
GO

IF OBJECT_ID('dbo.SP_GetGiaoVienDangKy', 'P') IS NOT NULL
    DROP PROCEDURE dbo.SP_GetGiaoVienDangKy;
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Lấy thông tin chi tiết một đăng ký lịch thi cụ thể
CREATE PROCEDURE [dbo].[SP_GetGiaoVienDangKy]
    @MALOP NCHAR(8),
    @MAMH NCHAR(5),
    @LAN SMALLINT
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
        MALOP = @MALOP 
        AND MAMH = @MAMH 
        AND LAN = @LAN;
END
GO