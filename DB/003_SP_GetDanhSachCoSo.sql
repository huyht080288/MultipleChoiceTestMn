IF OBJECT_ID('dbo.SP_GetDanhSachCoSo', 'P') IS NOT NULL
    DROP PROCEDURE dbo.SP_GetDanhSachCoSo;
GO

SET QUOTED_IDENTIFIER ON;
SET ANSI_NULLS ON;
GO

CREATE PROCEDURE dbo.SP_GetDanhSachCoSo
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        TENCS = PUBS.description,
        SERVER_NAME = SUBS.subscriber_server
    FROM
        sysmergepublications AS PUBS
        INNER JOIN sysmergesubscriptions AS SUBS
            ON PUBS.pubid = SUBS.pubid
    WHERE
        PUBS.publisher <> SUBS.subscriber_server;
END;
GO