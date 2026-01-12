SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Returns rows from BangDiem for a given MASV.
-- Parameter uses NVARCHAR to avoid client-side padding issues (table may use nchar).
CREATE PROCEDURE SP_GetBangDiemTheoMaSV
    @MASV NCHAR(8)
AS
BEGIN
    SET NOCOUNT ON;

    -- If MASV not provided return empty result set with correct schema
    IF @MASV IS NULL
    BEGIN
    SELECT
        MASV,
        MAMH,
        LAN,
        DIEM,
        NGAYTHI,
        RowGuid
    FROM BangDiem
    WHERE RTRIM(LTRIM(MASV)) = RTRIM(LTRIM(@MASV))
    ORDER BY NGAYTHI DESC, LAN ASC;
END;