USE [THITN]
GO

IF OBJECT_ID('dbo.SP_GetAllGiaoVienDangKy', 'P') IS NOT NULL
    DROP PROCEDURE dbo.SP_GetAllGiaoVienDangKy;
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Lấy danh sách đăng ký thi của toàn bộ giáo viên
CREATE PROCEDURE [dbo].[SP_GetAllGiaoVienDangKy]
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
    ORDER BY 
        NGAYTHI DESC;
END
GO