USE [THITN]
GO

IF OBJECT_ID('dbo.SP_UpdateGiaoVienDangKy', 'P') IS NOT NULL
    DROP PROCEDURE dbo.SP_UpdateGiaoVienDangKy;
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Cập nhật thông tin lịch thi (Dựa trên khóa chính MALOP, MAMH, LAN)
CREATE PROCEDURE [dbo].[SP_UpdateGiaoVienDangKy]
    @MAGV NCHAR(8),
    @MALOP NCHAR(8),
    @MAMH NCHAR(5),
    @TRINHDO NCHAR(1),
    @NGAYTHI DATETIME,
    @LAN SMALLINT,
    @SOCAUTHI SMALLINT,
    @THOIGIAN SMALLINT
AS
BEGIN
    SET NOCOUNT ON;
    
    UPDATE GiaoVien_DangKy
    SET 
        MAGV = @MAGV,
        TRINHDO = @TRINHDO,
        NGAYTHI = @NGAYTHI,
        SOCAUTHI = @SOCAUTHI,
        THOIGIAN = @THOIGIAN
    WHERE 
        MALOP = @MALOP 
        AND MAMH = @MAMH 
        AND LAN = @LAN;
END
GO