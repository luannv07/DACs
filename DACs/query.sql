--CREATE DATABASE YODY_LTAT_DB;
GO
USE YODY_LTAT_DB;
GO

-- Xóa bảng nếu đã tồn tại
DROP TABLE IF EXISTS CHI_TIET_DON_HANG;
DROP TABLE IF EXISTS DON_HANG;
DROP TABLE IF EXISTS KHACH_HANG;
DROP TABLE IF EXISTS CHI_TIET_PHIEU_NHAP;
DROP TABLE IF EXISTS PHIEU_NHAP;
DROP TABLE IF EXISTS BIEN_THE_SAN_PHAM;
DROP TABLE IF EXISTS SAN_PHAM;
DROP TABLE IF EXISTS NHA_CUNG_CAP;
DROP TABLE IF EXISTS NHAN_VIEN;
DROP TABLE IF EXISTS Log_He_Thong;
GO

-- Bảng NHAN_VIEN
CREATE TABLE NHAN_VIEN (
    MaNhanVien INT IDENTITY(1,1) PRIMARY KEY,
    Ho NVARCHAR(50) NOT NULL,
    Ten NVARCHAR(50) NOT NULL,
    Email VARCHAR(100) NOT NULL UNIQUE,
    NgaySinh DATE NOT NULL,
    DiaChi NVARCHAR(255) NOT NULL,
    GioiTinh TINYINT NOT NULL,
    TaiKhoan VARCHAR(50) NOT NULL UNIQUE,
    MatKhau VARCHAR(255) NOT NULL,
    VaiTro TINYINT NOT NULL,
    TrangThai TINYINT NOT NULL DEFAULT 1,
    NgayTao DATE NOT NULL DEFAULT GETDATE(),
    XoaTaiKhoan TINYINT NOT NULL DEFAULT 0
);
GO

-- Bảng NHA_CUNG_CAP
CREATE TABLE NHA_CUNG_CAP (
    MaNhaCungCap INT IDENTITY(1,1) PRIMARY KEY,
    Ten NVARCHAR(50) NOT NULL,
    Email VARCHAR(100) NOT NULL
);
GO

-- Bảng SAN_PHAM
CREATE TABLE SAN_PHAM (
    MaSanPham INT IDENTITY(1,1) PRIMARY KEY,
    TenSanPham NVARCHAR(255) NOT NULL,
    MaNCC INT NOT NULL,
    NgayTao DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (MaNCC) REFERENCES NHA_CUNG_CAP(MaNhaCungCap),
    CONSTRAINT CHK_TenSanPham_Length CHECK (LEN(TenSanPham) <= 30)
);


-- Bảng BIEN_THE_SAN_PHAM
CREATE TABLE BIEN_THE_SAN_PHAM (
    MaBienThe INT IDENTITY(1,1) PRIMARY KEY,
    MaSanPham INT NOT NULL,
    MauSac NVARCHAR(50),
    GiamGia DECIMAL(5,2) NOT NULL DEFAULT 0,
    KichCo NVARCHAR(20),
    SoLuong INT DEFAULT 0,
    DonGia DECIMAL(10,2) NOT NULL,
    TrangThaiBienThe TINYINT DEFAULT 1,
    XoaBienThe TINYINT NOT NULL DEFAULT 0
    FOREIGN KEY (MaSanPham) REFERENCES SAN_PHAM(MaSanPham),
    CONSTRAINT CHK_GiamGia CHECK (GiamGia >= 0 AND GiamGia <= 100)
);
ALTER TABLE Bien_The_San_Pham
ADD CONSTRAINT UQ_ProductVariant UNIQUE(MaSanPham, MauSac, KichCo);
-- Bảng PHIEU_NHAP
CREATE TABLE PHIEU_NHAP (
    MaPhieuNhap INT IDENTITY(1,1) PRIMARY KEY,
    NgayNhap DATETIME NOT NULL DEFAULT GETDATE(),
    MaNCC INT NOT NULL,
    MaNV INT NOT NULL,
    GhiChu NVARCHAR(MAX) default '_blank',
    xoaPhieuNhap tinyint default 0,
    FOREIGN KEY (MaNCC) REFERENCES NHA_CUNG_CAP(MaNhaCungCap),
    FOREIGN KEY (MaNV) REFERENCES NHAN_VIEN(MaNhanVien)
);
GO


-- Bảng CHI_TIET_PHIEU_NHAP
CREATE TABLE CHI_TIET_PHIEU_NHAP (
    IdChiTiet INT IDENTITY(1,1) PRIMARY KEY,
    MaPhieuNhap INT NOT NULL,
    MaBienThe INT NOT NULL,
    SoLuong INT NOT NULL,
    DonGia DECIMAL(6,2) NOT NULL,

    FOREIGN KEY (MaPhieuNhap) REFERENCES PHIEU_NHAP(MaPhieuNhap),
    FOREIGN KEY (MaBienThe) REFERENCES BIEN_THE_SAN_PHAM(MaBienThe)  -- **Sửa chỗ này**
);
-- SQL Server
ALTER TABLE CHI_TIET_PHIEU_NHAP
ADD CONSTRAINT UQ_Phieu_BienThe UNIQUE(MaPhieuNhap, MaBienThe);
GO

-- Bảng KHACH_HANG
CREATE TABLE KHACH_HANG (
    MaKhachHang INT IDENTITY(1,1) PRIMARY KEY,
    TenKhachHang NVARCHAR(100) NOT NULL,
    DiaChi NVARCHAR(255) NOT NULL,
    SoDienThoai VARCHAR(10) NOT NULL unique,
    GioiTinh TINYINT,
    LoaiKhachHang TINYINT DEFAULT 0
);

GO

-- Bảng DON_HANG
CREATE TABLE DON_HANG (
    MaDonHang INT IDENTITY(1,1) PRIMARY KEY,
    NgayDatHang DATETIME NOT NULL DEFAULT GETDATE(),
    MaKhachHang INT NOT NULL,
    MaNhanVien INT NOT NULL,     -- <-- thêm ở đây
    TrangThai TINYINT NOT NULL DEFAULT 0,
    FOREIGN KEY (MaKhachHang) REFERENCES KHACH_HANG(MaKhachHang),
    FOREIGN KEY (MaNhanVien) REFERENCES NHAN_VIEN(MaNhanVien)
);
GO

-- Bảng CHI_TIET_DON_HANG
CREATE TABLE CHI_TIET_DON_HANG (
    MaDonHangChiTiet INT IDENTITY(1,1) PRIMARY KEY,
    MaDonHang INT NOT NULL,
    MaBienThe INT NOT NULL,  -- **Sửa từ MaSanPham → MaBienThe** để đúng logic với BIEN_THE_SAN_PHAM
    SoLuong INT NOT NULL,
    DonGia DECIMAL(6,2) NOT NULL,
    FOREIGN KEY (MaDonHang) REFERENCES DON_HANG(MaDonHang),
    FOREIGN KEY (MaBienThe) REFERENCES BIEN_THE_SAN_PHAM(MaBienThe),
    UNIQUE(MaDonHang, MaBienThe)
);
GO


ALTER TABLE CHI_TIET_DON_HANG
ADD CONSTRAINT FK_CT_DH_MaDonHang
FOREIGN KEY (MaDonHang) REFERENCES DON_HANG(MaDonHang)
ON DELETE CASCADE;

GO

CREATE TRIGGER TRG_UpdateCustomerType_AfterOrder
ON DON_HANG
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE KH
    SET KH.LoaiKhachHang = 1
    FROM KHACH_HANG KH
    INNER JOIN (
        SELECT MaKhachHang, COUNT(*) AS TotalOrders
        FROM DON_HANG
        GROUP BY MaKhachHang
    ) DH ON KH.MaKhachHang = DH.MaKhachHang
    INNER JOIN INSERTED I ON I.MaKhachHang = KH.MaKhachHang
    WHERE DH.TotalOrders > 5;
END;
GO

CREATE TABLE Log_He_Thong (
    MaLog INT IDENTITY(1,1) PRIMARY KEY,
    MaNhanVien INT NOT NULL,
    HanhDong NVARCHAR(50) NOT NULL,
    NoiDung NVARCHAR(MAX) NOT NULL,
    ThoiGian DATETIME NOT NULL DEFAULT GETDATE()
);


INSERT INTO NHAN_VIEN (Ho, Ten, Email, NgaySinh, DiaChi, GioiTinh, TaiKhoan, MatKhau, VaiTro)
VALUES
-- Admin
(N'Nguyễn', N'Văn Luận', 'vanluan.admin@yody.vn', '2005-07-31', N'Hà Nội', 0, 'admin', '1', 2),

-- Nhân viên bán hàng
(N'Phạm', N'Thảo', 'thaopv@yody.vn', '1996-07-20', N'Hà Nội', 1, 'thaopv', '1', 1),
(N'Trần', N'Minh', 'minhtt@yody.vn', '1994-02-18', N'Đà Nẵng', 0, 'minhtt', '1', 1),
(N'Lê', N'Vân', 'vanlt@yody.vn', '1998-10-05', N'Hồ Chí Minh', 1, 'vanlt', '1', 1),
(N'Hoàng', N'Quân', 'quanhh@yody.vn', '1995-08-11', N'Hà Nam', 0, 'quanhh', '1', 1),

-- Nhân viên kho
(N'Võ', N'Khánh', 'khanhvo@yody.vn', '1993-12-01', N'Hải Phòng', 0, 'khanhvo', '1', 0),
(N'Bùi', N'Hải Yến', 'yenbh@yody.vn', '1999-03-22', N'Nghệ An', 1, 'yenbh', '1', 0),
(N'Đỗ', N'Tiến', 'tiendh@yody.vn', '1992-05-19', N'Bắc Giang', 0, 'tiendh', '1', 0),
(N'Ngô', N'Thu', 'thung@yody.vn', '1997-01-25', N'Hà Tĩnh', 1, 'thung', '1', 0),
(N'Lý', N'Long', 'longly@yody.vn', '1994-09-09', N'Quảng Ninh', 0, 'longly', '1', 0);

INSERT INTO NHA_CUNG_CAP (Ten, Email) VALUES
(N'Công ty May Mặc Ánh Kim', 'contact@anhkim-apparel.com'),
(N'Xưởng Thời Trang Mặc Đẹp', 'hello@macdep-fashion.com'),
(N'Tổng Kho Áo Xuất Khẩu Hưng Phát', 'sales@hungphat-garment.com'),
(N'Nhà Máy Dệt May Hà Thành', 'info@hathanh-textile.com'),
(N'Thời Trang Trẻ AzoWear', 'support@azowear.com'),
(N'Công ty May Áo 365', 'contact@ao365.vn'),
(N'Tập Đoàn Vải & Áo Cotton Việt', 'inbox@cottonviet.vn'),
(N'Xưởng May Thời Trang Mây Studio', 'cs@maystudio.vn'),
(N'Nhà Cung Cấp Áo Chất Việt Style', 'orders@vietstyle-clothes.com'),
(N'Công ty Sản Xuất Áo Thời Đại Mới', 'service@thoidaimoi-fashion.com');

INSERT INTO SAN_PHAM (TenSanPham, MaNCC) VALUES
(N'Thun Nam Basic Cotton 360', 1),
(N'Polo CoolTech Premium', 2),
(N'Hoodie Form Rộng UrbanWear', 3),
(N'Sơ Mi Oxford Trắng Chuẩn Form', 4),
(N'Graphic Tee Streetstyle', 5),
(N'Polo Bamboo Kháng Khuẩn', 6),
(N'Khoác Nỉ Zipper Everyday', 7),
(N'Sơ Mi Caro Vintage RedBlue', 8),
(N'Sweater Unisex Fleece', 9),
(N'Tee QuickDry Running', 10),
(N'Gile Len Hàn Quốc', 2),
(N'Len Dệt Mịn Classic', 3),
(N'Satin Shirt Luxury Fit', 4),
(N'Polo Cá Sấu Thoáng Khí 2024', 5),
(N'Hoodie Zipper MixColor', 6),
(N'Windbreaker Hai Lớp UltraLight', 7),
(N'Oversize Cotton Tee 280gsm', 8),
(N'Polo Classic Fit Everyday', 9),
(N'Sơ Mi Trắng Công Sở SlimFit', 1),
(N'Sweatshirt Minimal Form Rộng', 10);

INSERT INTO BIEN_THE_SAN_PHAM (MaSanPham, MauSac, GiamGia, KichCo, SoLuong, DonGia, TrangThaiBienThe) VALUES
-- Sản phẩm 1
(1, N'Đen', 5.2, N'M', 40, 189.5, 1),
(1, N'Trắng', 12.0, N'L', 60, 210.9, 1),
(1, N'Xám', 7.8, N'XL', 80, 172.4, 1),
(1, N'Xanh dương', 3.3, N'S', 50, 199.0, 1),

-- Sản phẩm 2
(2, N'Đỏ', 8.5, N'M', 60, 259.9, 1),
(2, N'Be', 14.2, N'L', 40, 230.5, 1),
(2, N'Xanh lá', 10.0, N'XL', 20, 249.7, 1),
(2, N'Nâu', 6.4, N'S', 80, 270.3, 1),

-- Sản phẩm 3
(3, N'Đen', 9.9, N'M', 100, 320.0, 1),
(3, N'Cam', 4.1, N'L', 60, 305.8, 1),
(3, N'Hồng', 11.3, N'XL', 40, 298.4, 1),

-- Sản phẩm 4
(4, N'Trắng', 6.2, N'M', 50, 240.0, 1),
(4, N'Xám', 17.0, N'L', 70, 259.9, 1),
(4, N'Be', 8.8, N'S', 80, 230.7, 1),
(4, N'Tím', 12.5, N'XS', 40, 280.4, 1),

-- Sản phẩm 5
(5, N'Đen', 5.0, N'M', 40, 180.6, 1),
(5, N'Đỏ', 19.3, N'L', 60, 210.2, 1),
(5, N'Xanh dương', 11.4, N'XL', 20, 220.9, 1),

-- Sản phẩm 6
(6, N'Hồng', 4.7, N'M', 80, 205.3, 1),
(6, N'Trắng', 6.8, N'S', 40, 190.5, 1),
(6, N'Cam', 9.2, N'L', 60, 214.0, 1),
(6, N'Nâu', 13.1, N'XL', 100, 230.4, 1),

-- Sản phẩm 7
(7, N'Xanh lá', 10.3, N'M', 60, 260.0, 1),
(7, N'Be', 6.6, N'S', 50, 245.7, 1),
(7, N'Xanh dương', 8.9, N'XL', 40, 270.5, 1),

-- Sản phẩm 8
(8, N'Tím', 14.0, N'M', 80, 280.0, 1),
(8, N'Đen', 7.1, N'L', 60, 290.4, 1),
(8, N'Trắng', 3.9, N'S', 40, 266.8, 1),
(8, N'Đỏ', 5.5, N'XL', 20, 250.4, 1),

-- Sản phẩm 9
(9, N'Xám', 4.0, N'M', 100, 200.0, 1),
(9, N'Xanh lá', 12.4, N'L', 60, 219.4, 1),
(9, N'Be', 8.6, N'XL', 40, 230.3, 1),

-- Sản phẩm 10
(10, N'Xanh dương', 6.5, N'L', 40, 310.5, 1),
(10, N'Đỏ', 14.7, N'XL', 60, 305.5, 1),
(10, N'Đen', 12.8, N'M', 100, 280.0, 1),

-- Sản phẩm 11
(11, N'Hồng', 3.2, N'M', 40, 190.0, 1),
(11, N'Cam', 18.0, N'L', 60, 210.8, 1),
(11, N'Be', 6.6, N'XL', 80, 215.4, 1),
(11, N'Nâu', 7.5, N'S', 40, 198.0, 1),

-- Sản phẩm 12
(12, N'Xanh lá', 4.4, N'M', 60, 320.0, 1),
(12, N'Tím', 9.3, N'S', 50, 310.6, 1),
(12, N'Trắng', 11.1, N'L', 40, 300.5, 1),

-- Sản phẩm 13
(13, N'Đỏ', 5.7, N'M', 80, 350.9, 1),
(13, N'Đen', 10.0, N'L', 60, 340.5, 1),
(13, N'Be', 7.9, N'XL', 20, 330.0, 1),

-- Sản phẩm 14
(14, N'Trắng', 11.4, N'M', 60, 299.9, 1),
(14, N'Xám', 8.8, N'S', 40, 310.2, 1),
(14, N'Nâu', 3.5, N'XL', 80, 320.8, 1),
(14, N'Hồng', 6.1, N'L', 20, 315.3, 1),

-- Sản phẩm 15
(15, N'Đen', 4.2, N'M', 40, 270.0, 1),
(15, N'Be', 17.0, N'L', 80, 260.7, 1),
(15, N'Tím', 9.4, N'XL', 60, 280.3, 1),

-- Sản phẩm 16
(16, N'Xanh dương', 13.3, N'M', 100, 350.0, 1),
(16, N'Trắng', 7.2, N'L', 60, 340.7, 1),
(16, N'Xám', 4.8, N'XL', 20, 360.3, 1),

-- Sản phẩm 17
(17, N'Đỏ', 5.9, N'M', 40, 210.0, 1),
(17, N'Cam', 16.7, N'L', 60, 225.9, 1),
(17, N'Be', 9.4, N'XL', 80, 230.0, 1),

-- Sản phẩm 18
(18, N'Nâu', 6.7, N'M', 40, 260.0, 1),
(18, N'Hồng', 12.9, N'L', 80, 250.5, 1),
(18, N'Xanh lá', 14.0, N'S', 60, 240.8, 1),

-- Sản phẩm 19
(19, N'Tím', 9.1, N'M', 100, 330.0, 1),
(19, N'Trắng', 6.4, N'XL', 40, 315.9, 1),
(19, N'Đen', 4.3, N'L', 60, 320.2, 1),

-- Sản phẩm 20
(20, N'Cam', 13.6, N'M', 60, 280.3, 1),
(20, N'Xanh dương', 7.8, N'L', 40, 290.7, 1),
(20, N'Đỏ', 11.2, N'XL', 100, 300.4, 1);

INSERT INTO PHIEU_NHAP (NgayNhap, MaNCC, MaNV)
VALUES
('2025-11-01', 3, 1),
('2025-11-02', 7, 2),
('2025-11-04', 1, 5),
('2025-11-05', 9, 3),
('2025-11-07', 4, 6),
('2025-11-10', 2, 4),
('2025-11-12', 8, 7),
('2025-11-15', 6, 9),
('2025-11-18', 10, 8),
('2025-11-22', 5, 10);

INSERT INTO CHI_TIET_PHIEU_NHAP (MaPhieuNhap, MaBienThe, SoLuong, DonGia) VALUES
-- Phiếu 1
(1, 3, 40, 120),
(1, 7, 60, 140),
(1, 12, 20, 110),

-- Phiếu 2
(2, 5, 30, 150),
(2, 9, 40, 160),
(2, 14, 20, 145),

-- Phiếu 3
(3, 11, 50, 200),
(3, 16, 30, 220),

-- Phiếu 4
(4, 8, 60, 130),
(4, 17, 40, 180),
(4, 22, 20, 175),

-- Phiếu 5
(5, 6, 30, 140),
(5, 10, 50, 150),
(5, 19, 40, 160),

-- Phiếu 6
(6, 21, 60, 200),
(6, 25, 40, 210),

-- Phiếu 7
(7, 13, 50, 190),
(7, 18, 30, 180),
(7, 27, 40, 175),

-- Phiếu 8
(8, 4, 40, 100),
(8, 15, 30, 120),
(8, 24, 20, 115),

-- Phiếu 9
(9, 20, 50, 160),
(9, 28, 40, 180),

-- Phiếu 10
(10, 23, 30, 140),
(10, 29, 50, 150),
(10, 31, 40, 155);

INSERT INTO KHACH_HANG (TenKhachHang, DiaChi, SoDienThoai, GioiTinh, LoaiKhachHang) VALUES
(N'Nguyễn Văn An', N'12 Lê Lợi, Hà Nội', '0912345678', 0, 0),
(N'Trần Thị Bình', N'85 Trần Hưng Đạo, Hà Nội', '0987654321', 1, 0),
(N'Lê Hoàng Nam', N'23 Nguyễn Huệ, TP. Hồ Chí Minh', '0901122334', 0, 0),
(N'Phạm Thị Hương', N'45 Hai Bà Trưng, Đà Nẵng', '0934567890', 1, 0),
(N'Võ Minh Quân', N'78 Lý Thường Kiệt, Huế', '0978899001', 0, 0),
(N'Đặng Thị Lan', N'150 Phan Chu Trinh, Quảng Nam', '0919988776', 1, 0),
(N'Bùi Văn Khánh', N'32 Nguyễn Trãi, Hải Phòng', '0962233445', 0, 0),
(N'Hoàng Thị Mai', N'64 Võ Văn Kiệt, Cần Thơ', '0945566778', 1, 0),
(N'Phan Thanh Tùng', N'101 Quang Trung, Hà Nội', '0923344556', 0, 0),
(N'Ngô Thị Thu', N'56 Điện Biên Phủ, TP. Hồ Chí Minh', '0938899776', 1, 0);
INSERT INTO DON_HANG (NgayDatHang, MaKhachHang, TrangThai, MaNhanVien) VALUES
('2025-11-01', 6, 0, 2),
('2025-11-01', 6, 0, 2),
('2025-11-05', 6, 2, 3),
('2025-11-12', 6, 1, 4),

('2025-11-01', 6, 0, 1),
('2025-11-01', 3, 0, 1),
('2025-11-05', 7, 2, 1),
('2025-11-12', 1, 1, 1),

('2025-11-03', 5, 0, 2),
('2025-11-10', 8, 2, 2),
('2025-11-14', 2, 1, 2),
('2025-11-20', 9, 3, 2),

('2025-11-02', 4, 0, 3),
('2025-11-11', 1, 2, 3),

('2025-11-04', 6, 1, 4),
('2025-11-13', 10, 0, 4),
('2025-11-18', 2, 2, 4),
('2025-11-22', 8, 1, 4),

('2025-11-06', 3, 0, 5),

('2025-11-07', 9, 1, 6),
('2025-11-15', 5, 2, 6),
('2025-11-19', 4, 0, 6),
('2025-11-21', 6, 3, 6),

('2025-11-08', 7, 0, 7),
('2025-11-16', 3, 1, 7),

('2025-11-05', 1, 0, 8),
('2025-11-12', 10, 2, 8),
('2025-11-18', 5, 1, 8),

('2025-11-09', 2, 1, 9),
('2025-11-14', 6, 0, 9),
('2025-11-20', 9, 2, 9),
('2025-11-22', 3, 1, 9),

('2025-11-01', 8, 0, 10),
('2025-11-11', 4, 1, 10),
('2025-11-17', 7, 2, 10),
('2025-11-21', 6, 0, 10);

INSERT INTO CHI_TIET_DON_HANG (MaDonHang, MaBienThe, SoLuong, DonGia) VALUES

(1, 34, 1, 199.50),

(2, 7, 1, 320.00),
(2, 18, 3, 285.50),

(3, 55, 2, 150.00),

(4, 22, 1, 178.50),
(4, 39, 2, 210.00),

(5, 61, 3, 305.00),

(6, 5, 2, 199.00),
(6, 49, 1, 260.50),

(7, 33, 4, 140.00),

(8, 14, 2, 330.00),
(8, 52, 1, 380.50),

(9, 27, 1, 165.00),

(10, 8, 3, 120.00),
(10, 64, 1, 210.00),

(11, 29, 2, 299.50),

(12, 46, 3, 180.00),

(13, 11, 2, 260.00),
(13, 36, 1, 199.50),

(14, 17, 1, 150.00),

(15, 40, 2, 310.00),
(15, 63, 1, 350.50),

(16, 9, 2, 200.00),

(17, 21, 3, 140.00),

(18, 30, 1, 185.50),

(19, 4, 2, 270.00),
(19, 24, 1, 160.00),

(20, 58, 3, 199.00),

(21, 32, 2, 260.00),

(22, 3, 1, 155.00),
(22, 47, 2, 220.00),

(23, 56, 2, 310.00),

(24, 2, 3, 145.00),

(25, 44, 1, 250.00),
(25, 15, 2, 189.50),

(26, 51, 4, 290.00),

(27, 19, 1, 300.00),

(28, 6, 2, 140.00),
(28, 48, 1, 210.00),

(29, 35, 3, 180.00),

(30, 10, 2, 330.00),
(30, 59, 1, 350.50),

(31, 16, 1, 199.00)


update don_hang
set trangthai=0
where trangthai=3

update DON_HANG
set MaNhanVien = 6
where MaNhanVien = 2 or MaNhanVien =3 or MaNhanVien = 4 or MaNhanVien = 5
