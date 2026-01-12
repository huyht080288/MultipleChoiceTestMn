IF OBJECT_ID('dbo.SP_InsertBangDiem', 'P') IS NOT NULL
    DROP PROCEDURE dbo.SP_InsertBangDiem;
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Inserts a row into table BangDiem.
-- Parameters assume MASV is nchar(8), MAMH is nchar(5), LAN smallint, DIEM float, NGAYTHI datetime.
-- If a record with the same (MASV, MAMH, LAN) already exists the procedure will raise an error.
CREATE PROCEDURE SP_InsertBangDiem
    @MASV   nchar(8),      -- pass nchar(8) content (NVARCHAR used to avoid client-side trimming issues)
    @MAMH   nchar(5),      -- pass nchar(5) content
    @LAN    SMALLINT,
    @DIEM   FLOAT,
    @NGAYTHI DATETIME
AS
BEGIN
    INSERT INTO BangDiem (MASV, MAMH, LAN, DIEM, NGAYTHI, RowGuid)
    VALUES (
        @MASV,
        @MAMH,
        @LAN,
        @DIEM,
        @NGAYTHI,
        NEWID()
    );
END
GO
