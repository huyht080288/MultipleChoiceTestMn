USE [THITN]
GO

IF OBJECT_ID('dbo.SP_DeleteGiaoVienDangKy', 'P') IS NOT NULL
    DROP PROCEDURE dbo.SP_DeleteGiaoVienDangKy;
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Xóa một lịch thi theo khóa chính
CREATE PROCEDURE [dbo].[SP_DeleteGiaoVienDangKy]
    @MALOP NCHAR(8),
    @MAMH NCHAR(5),
    @LAN SMALLINT
AS
BEGIN
    SET NOCOUNT ON;
    
    DELETE FROM GiaoVien_DangKy
    WHERE 
        MALOP = @MALOP 
        AND MAMH = @MAMH 
        AND LAN = @LAN;
END
GO