USE [THITN]
GO

IF OBJECT_ID('dbo.SP_CheckNgayThiLan1', 'P') IS NOT NULL
    DROP PROCEDURE dbo.SP_CheckNgayThiLan1;
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Trả về Ngày thi của Lần 1 để so sánh logic nghiệp vụ (Thi lần 2 phải sau lần 1)
CREATE PROCEDURE [dbo].[SP_CheckNgayThiLan1]
    @MALOP NCHAR(8),
    @MAMH NCHAR(5)
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT NGAYTHI 
    FROM GiaoVien_DangKy 
    WHERE 
        MALOP = @MALOP 
        AND MAMH = @MAMH 
        AND LAN = 1;
END
GO