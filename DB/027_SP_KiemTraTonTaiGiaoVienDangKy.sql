USE [THITN]
GO

IF OBJECT_ID('dbo.SP_KiemTraTonTaiGiaoVienDangKy', 'P') IS NOT NULL
    DROP PROCEDURE dbo.SP_KiemTraTonTaiGiaoVienDangKy;
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Trả về số lượng bản ghi để xác định lịch thi đã tồn tại chưa
CREATE PROCEDURE [dbo].[SP_KiemTraTonTaiGiaoVienDangKy]
    @MALOP NCHAR(8),
    @MAMH NCHAR(5),
    @LAN SMALLINT
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT COUNT(*) 
    FROM GiaoVien_DangKy 
    WHERE 
        MALOP = @MALOP 
        AND MAMH = @MAMH 
        AND LAN = @LAN;
END
GO