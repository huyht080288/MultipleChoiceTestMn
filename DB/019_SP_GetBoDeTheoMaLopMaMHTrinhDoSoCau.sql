USE [THITN]
GO

/****** Object:  View [dbo].[V_DS_CAUHOI]    Script Date: 1/13/2026 ******/
/* Mục đích: View này giúp truy vấn nhanh xem câu hỏi đó thuộc Cơ sở nào 
   bằng cách Join BODE -> GIAOVIEN -> KHOA
*/
IF OBJECT_ID('V_DS_CAUHOI', 'V') IS NOT NULL
    DROP VIEW V_DS_CAUHOI
GO

CREATE VIEW [dbo].[V_DS_CAUHOI]
AS
SELECT 
    B.CAUHOI,
    B.MAMH,
    B.TRINHDO,
    B.NOIDUNG,
    B.A,
    B.B,
    B.C,
    B.D,
    B.DAPAN,
    B.MAGV,
    K.MACS -- Quan trọng: Để biết câu hỏi này của cơ sở nào
FROM dbo.BODE B
INNER JOIN dbo.GIAOVIEN G ON B.MAGV = G.MAGV
INNER JOIN dbo.KHOA K ON G.MAKH = K.MAKH
GO

/****** Object:  StoredProcedure [dbo].[SP_GetBoDeTheoMaLopMaMHTrinhDoSoCau]    Script Date: 1/13/2026 ******/
/*
   Mục đích: Lấy danh sách câu hỏi thi ngẫu nhiên
   Input: Mã lớp, Môn học, Trình độ thi, Số câu thi
   Output: Danh sách câu hỏi thỏa mãn điều kiện
*/
IF OBJECT_ID('SP_GetBoDeTheoMaLopMaMHTrinhDoSoCau', 'P') IS NOT NULL
    DROP PROC SP_GetBoDeTheoMaLopMaMHTrinhDoSoCau
GO

CREATE PROCEDURE [dbo].[SP_GetBoDeTheoMaLopMaMHTrinhDoSoCau]
    @MALOP NVARCHAR(15), 
    @MAMH NCHAR(5),
    @TRINHDO NCHAR(1), 
    @SOCAUTHI INT
AS
BEGIN
    SET NOCOUNT ON;

    -- 1. Xác định CƠ SỞ của sinh viên (Dựa vào Lớp -> Khoa -> Cơ sở)
    -- Giả sử sinh viên thi tại máy thuộc cơ sở dữ liệu phân tán nơi lớp đó thuộc về
    DECLARE @MACS_SV NCHAR(3)
    
    SELECT TOP 1 @MACS_SV = K.MACS
    FROM dbo.LOP L
    INNER JOIN dbo.KHOA K ON L.MAKH = K.MAKH
    WHERE L.MALOP = @MALOP

    -- Nếu không tìm thấy mã cơ sở (lỗi dữ liệu), gán mặc định hoặc báo lỗi
    IF @MACS_SV IS NULL
    BEGIN
        RAISERROR('Lớp không tồn tại hoặc dữ liệu Lớp-Khoa bị lỗi.', 16, 1)
        RETURN
    END

    -- 2. Xác định trình độ thấp hơn (để lấy bù nếu thiếu)
    DECLARE @TRINHDO_THAP NCHAR(1) = NULL
    IF @TRINHDO = 'A' SET @TRINHDO_THAP = 'B'
    ELSE IF @TRINHDO = 'B' SET @TRINHDO_THAP = 'C'
    -- Nếu trình độ là C thì không có trình độ thấp hơn

    -- 3. Tạo bảng tạm chứa đề thi
    CREATE TABLE #DE_THI_TEMP (
        CAUHOI INT,
        MAMH NCHAR(5),
        TRINHDO NCHAR(1),
        NOIDUNG NTEXT,
        A NTEXT, B NTEXT, C NTEXT, D NTEXT,
        DAPAN NCHAR(1),
        MAGV NCHAR(8),
        MACS NCHAR(3)
    )

    -- ---------------------------------------------------------
    -- BƯỚC A: LẤY CÂU HỎI TRÌNH ĐỘ CHÍNH (VÍ DỤ: A)
    -- Ưu tiên: Cùng cơ sở trước -> Khác cơ sở sau -> Random
    -- ---------------------------------------------------------
    
    INSERT INTO #DE_THI_TEMP
    SELECT TOP (@SOCAUTHI) 
        CAUHOI, MAMH, TRINHDO, NOIDUNG, A, B, C, D, DAPAN, MAGV, MACS
    FROM V_DS_CAUHOI
    WHERE MAMH = @MAMH AND TRINHDO = @TRINHDO
    ORDER BY 
        (CASE WHEN MACS = @MACS_SV THEN 0 ELSE 1 END), -- Ưu tiên 1: Cùng cơ sở
        NEWID() -- Ưu tiên 2: Random ngẫu nhiên

    -- Kiểm tra số lượng đã lấy được
    DECLARE @SO_CAU_DA_LAY INT
    SELECT @SO_CAU_DA_LAY = COUNT(*) FROM #DE_THI_TEMP

    -- ---------------------------------------------------------
    -- BƯỚC B: KIỂM TRA ĐIỀU KIỆN 70% VÀ LẤY BÙ (NẾU CẦN)
    -- ---------------------------------------------------------
    
    -- Tính số câu tối thiểu trình độ chính phải đạt (70%)
    DECLARE @MIN_REQ_MAIN FLOAT = @SOCAUTHI * 0.7

    -- Nếu số câu đã lấy < 70% tổng số câu => KHÔNG ĐỦ ĐỀ => BÁO LỖI
    IF @SO_CAU_DA_LAY < @MIN_REQ_MAIN
    BEGIN
        DROP TABLE #DE_THI_TEMP
        RAISERROR('Không đủ câu hỏi trình độ %s (Yêu cầu tối thiểu 70%%). Hãy bổ sung thêm câu hỏi vào bộ đề.', 16, 1, @TRINHDO)
        RETURN
    END

    -- Nếu vẫn chưa đủ tổng số câu yêu cầu (nhưng đã >= 70%) => LẤY BÙ TRÌNH ĐỘ THẤP
    IF @SO_CAU_DA_LAY < @SOCAUTHI AND @TRINHDO_THAP IS NOT NULL
    BEGIN
        DECLARE @SO_CAU_CAN_BU INT = @SOCAUTHI - @SO_CAU_DA_LAY
        
        -- Lấy thêm câu hỏi trình độ thấp
        INSERT INTO #DE_THI_TEMP
        SELECT TOP (@SO_CAU_CAN_BU) 
            CAUHOI, MAMH, TRINHDO, NOIDUNG, A, B, C, D, DAPAN, MAGV, MACS
        FROM V_DS_CAUHOI
        WHERE MAMH = @MAMH AND TRINHDO = @TRINHDO_THAP
        ORDER BY 
            (CASE WHEN MACS = @MACS_SV THEN 0 ELSE 1 END), -- Vẫn ưu tiên cơ sở
            NEWID()
    END

    -- ---------------------------------------------------------
    -- BƯỚC C: KIỂM TRA LẠI TỔNG SỐ LẦN CUỐI
    -- ---------------------------------------------------------
    DECLARE @TOTAL_FINAL INT
    SELECT @TOTAL_FINAL = COUNT(*) FROM #DE_THI_TEMP

    IF @TOTAL_FINAL < @SOCAUTHI
    BEGIN
        DROP TABLE #DE_THI_TEMP
        RAISERROR('Không đủ câu hỏi để tổ chức thi (Thiếu cả trình độ %s và %s).', 16, 1, @TRINHDO, @TRINHDO_THAP)
        RETURN
    END

    -- ---------------------------------------------------------
    -- BƯỚC D: TRẢ VỀ KẾT QUẢ (XÁO TRỘN LẦN CUỐI)
    -- ---------------------------------------------------------
    -- App sẽ nhận danh sách này. Lưu ý thứ tự câu A và B sẽ bị trộn lẫn ở đây để sinh viên không đoán được
    SELECT 
        ROW_NUMBER() OVER(ORDER BY NEWID()) AS STT, -- Đánh số lại từ 1..n
        CAUHOI,
        NOIDUNG,
        A, B, C, D,
        DAPAN,
        TRINHDO
        -- Không cần trả về MAGV, MACS cho sinh viên
    FROM #DE_THI_TEMP
    ORDER BY NEWID()

    -- Dọn dẹp
    DROP TABLE #DE_THI_TEMP
END
GO