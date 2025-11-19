CREATE DATABASE YODY_LTAT_DB;
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
    FOREIGN KEY (MaNCC) REFERENCES NHA_CUNG_CAP(MaNhaCungCap),
    FOREIGN KEY (MaNV) REFERENCES NHAN_VIEN(MaNhanVien)
);
alter table phieu_nhap
add xoaPhieuNhap tinyint default 0
GO
alter table phieu_nhap
add ghichu text default '_blank'

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
ALTER TABLE CHI_TIET_PHIEU_NHAP
ADD CONSTRAINT UQ_MaBt UNIQUE (mabienthe);
GO
alter table chi_tiet_phieu_nhap
add ThoiGianNhap datetime default GETDATE()

-- Bảng KHACH_HANG
CREATE TABLE KHACH_HANG (
    MaKhachHang INT IDENTITY(1,1) PRIMARY KEY,
    TenKhachHang NVARCHAR(100) NOT NULL,
    DiaChi NVARCHAR(255) NOT NULL,
    SoDienThoai VARCHAR(10) NOT NULL,
    GioiTinh TINYINT,
    LoaiKhachHang TINYINT DEFAULT 0
);
GO

-- Bảng DON_HANG
CREATE TABLE DON_HANG (
    MaDonHang INT IDENTITY(1,1) PRIMARY KEY,
    NgayDatHang DATETIME NOT NULL DEFAULT GETDATE(),
    MaKhachHang INT NOT NULL,
    TrangThai TINYINT NOT NULL DEFAULT 0,
    FOREIGN KEY (MaKhachHang) REFERENCES KHACH_HANG(MaKhachHang)
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



INSERT INTO NHAN_VIEN (Ho, Ten, Email, NgaySinh, DiaChi, GioiTinh, TaiKhoan, MatKhau, VaiTro)
VALUES
(N'Lê Văn', N'An', 'anlv1234@ltat.com', '1988-01-10', N'Hà Nội', 0, 'anlv1234', '1', 2), -- user admin thêm đầu
(N'Nguyễn Văn', N'Luận', 'luannv6354@ltat.com', '1995-01-01', N'Hà Nội', 0, 'admin', '1', 2),
(N'Trá Văn', N'Anh', 'anhvt1234@ltat.com', '1994-02-15', N'Hồ Chí Minh', 0, 'anhvt1234', '1', 1),
(N'Lê Quang', N'Tuấn', 'tuanlq2345@ltat.com', '1996-03-20', N'Đà Nẵng', 0, 'tuanlq2345', '1', 1),
(N'Phạm Hoàng', N'Hà', 'haph1234@ltat.com', '1997-05-05', N'Quảng Ninh', 1, 'haph1234', '1', 1),
(N'Võ Minh', N'Hưng', 'hungvm3456@ltat.com', '1992-06-18', N'Hà Tĩnh', 0, 'hungvm3456', '1', 1),
(N'Đặng Thị', N'Mai', 'maidt4567@ltat.com', '1998-07-22', N'Hà Nam', 1, 'maidt4567', '1', 1),
(N'Bùi Thị', N'Lan', 'lanbt5678@ltat.com', '1995-08-08', N'Bình Dương', 1, 'lanbt5678', '1', 1),
(N'Lê Văn', N'Long', 'longlv6789@ltat.com', '1994-09-12', N'Bắc Ninh', 0, 'longlv6789', '1', 1),
(N'Nguyễn Hải', N'Hải', 'hainh7890@ltat.com', '1996-10-20', N'Nam Định', 0, 'hainh7890', '1', 1),
(N'Phạm Thị', N'Thủy', 'thuypf8901@ltat.com', '1997-11-25', N'Quảng Bình', 1, 'thuypf8901', '1', 0),
(N'Trần Văn', N'Khanh', 'khanhtv9012@ltat.com', '1993-12-30', N'Thanh Hóa', 0, 'khanhtv9012', '1', 0),
(N'Hoàng Minh', N'Tùng', 'tunghm0123@ltat.com', '1995-01-15', N'Bắc Giang', 0, 'tunghm0123', '1', 0),
(N'Võ Thị', N'Nga', 'ngavt1234@ltat.com', '1996-02-10', N'Bình Thuận', 1, 'ngavt1234', '1', 0),
(N'Đặng Thị', N'Hạnh', 'hanhdt2345@ltat.com', '1994-03-05', N'Quảng Nam', 1, 'hanhdt2345', '1', 0),
(N'Bùi Văn', N'Anh', 'anhbv3456@ltat.com', '1992-04-22', N'Hà Giang', 0, 'anhbv3456', '1', 0),
(N'Lê Văn', N'Phong', 'phonglv4567@ltat.com', '1993-05-18', N'Lạng Sơn', 0, 'phonglv4567', '1', 0),
(N'Nguyễn Thị', N'Vy', 'vynt5678@ltat.com', '1995-06-30', N'Quảng Trị', 1, 'vynt5678', '1', 0),
(N'Phạm Văn', N'Dương', 'duongpv6789@ltat.com', '1996-07-12', N'Nam Định', 0, 'duongpv6789', '1', 0),
(N'Trần Minh', N'Minh', 'minhtm7890@ltat.com', '1994-08-25', N'Hà Nội', 0, 'minhtm7890', '1', 0);
GO
select * from Nha_cung_cap;
INSERT INTO NHA_CUNG_CAP (Ten, Email) VALUES
(N'Công ty Thời Trang Vi Diệu', 'contact@vidieu-fashion.com'),
(N'Công ty Quần Áo Huyền Ảo', 'hello@huyenao-style.com'),
(N'Xưởng May Mặc Mộc Mạc', 'sales@mocmac-apparel.com'),
(N'Thời Trang Ánh Ngọc', 'info@anhngoc-boutique.com'),
(N'Nhà Máy May Sắc Màu', 'orders@sacmau-factory.com'),
(N'Quần Áo Bản Sắc Việt', 'support@bansacviet.co'),
(N'Vật Liệu May Mặc Kim Tuyến', 'contact@kimtuyen-supply.com'),
(N'Thời Trang Pháp Vị', 'inbox@phapvi-fashion.com'),
(N'Xưởng Thiết Kế Đẹp Đẽ', 'design@depde-studio.com'),
(N'Công ty May Mặc Thời Đại Mới', 'service@thoidai-moi.com');
GO

INSERT INTO SAN_PHAM (TenSanPham, MaNCC) VALUES
(N'Áo Thun Nam Basic', 1),
(N'Áo Sơ Mi Nữ Công Sở', 2),
(N'Quần Jean Nam Skinny', 3),
(N'Váy Dài Nữ Dạo Phố', 4),
(N'Áo Khoác Nam Hoodie', 5),
(N'Áo Len Nữ Ấm Áp', 6),
(N'Quần Short Nam Thể Thao', 7),
(N'Áo Thun Nữ Họa Tiết', 8),
(N'Đầm Dạ Hội Nữ', 9),
(N'Áo Khoác Jean Nam', 10),
(N'Quần Legging Nữ', 1),
(N'Áo Polo Nam', 2),
(N'Váy Ngắn Nữ Đi Biển', 3),
(N'Áo Khoác Dù Nam', 4),
(N'Áo Thun Oversize Nữ', 5);
GO

INSERT INTO BIEN_THE_SAN_PHAM (MaSanPham, MauSac, GiamGia, KichCo, SoLuong, DonGia, TrangThaiBienThe)
VALUES
-- Biến thể cho sản phẩm 1
(1, N'Đen', 0, N'M', 50, 150, 1),
(1, N'Trắng', 10, N'L', 30, 170, 1),
(1, N'Xanh', 5, N'XL', 20, 190, 1),

-- Biến thể cho sản phẩm 2
(2, N'Hồng', 0, N'S', 40, 200, 1),
(2, N'Trắng', 0, N'M', 25, 250, 1),
(2, N'Đen', 15, N'L', 15, 299, 1),

-- Biến thể cho sản phẩm 3
(3, N'Xanh Đậm', 5, N'S', 35, 150, 1),
(3, N'Xanh Nhạt', 0, N'L', 20, 250, 1),
(3, N'Đen', 0, N'XL', 15, 350, 1),

-- Biến thể cho sản phẩm 4
(4, N'Đỏ', 0, N'S', 20, 300, 1),
(4, N'Vàng', 10, N'M', 25, 300, 1),

-- Biến thể cho sản phẩm 5
(5, N'Xám', 0, N'M', 50, 180, 1),
(5, N'Đen', 5, N'L', 30, 280, 1),

-- Biến thể cho sản phẩm 6
(6, N'Tím', 0, N'S', 40, 220, 1),
(6, N'Hồng', 10, N'M', 20, 220, 1),

-- Biến thể cho sản phẩm 7
(7, N'Xanh', 0, N'M', 60, 120, 1),
(7, N'Đen', 5, N'L', 40, 120, 1),

-- Biến thể cho sản phẩm 8
(8, N'Hồng', 0, N'S', 30, 180, 1),
(8, N'Trắng', 5, N'M', 20, 180, 1),

-- Biến thể cho sản phẩm 9
(9, N'Đỏ', 0, N'M', 15, 500, 1),
(9, N'Đen', 10, N'L', 10, 600, 1),

-- Biến thể cho sản phẩm 10
(10, N'Xanh', 0, N'M', 25, 200, 1),
(10, N'Đen', 0, N'L', 20, 225, 1),

-- Biến thể cho sản phẩm 11
(11, N'Hồng', 0, N'S', 30, 150, 1),
(11, N'Đen', 5, N'M', 25, 150, 1),

-- Biến thể cho sản phẩm 12
(12, N'Trắng', 0, N'M', 40, 180, 1),
(12, N'Xanh', 10, N'L', 30, 180, 1),

-- Biến thể cho sản phẩm 13
(13, N'Vàng', 0, N'S', 15, 220, 1),
(13, N'Đỏ', 5, N'M', 10, 220, 1),

-- Biến thể cho sản phẩm 14
(14, N'Xanh', 0, N'M', 20, 250, 1),
(14, N'Đen', 0, N'L', 15, 250, 1),

-- Biến thể cho sản phẩm 15
(15, N'Hồng', 0, N'S', 30, 180, 1),
(15, N'Tím', 5, N'M', 20, 180, 1);
GO

-- PHIEU_NHAP
INSERT INTO PHIEU_NHAP (NgayNhap, MaNCC, MaNV)
VALUES
(GETDATE(), 1, 2),
(GETDATE(), 2, 3),
(GETDATE(), 3, 4),
(GETDATE(), 4, 5),
(GETDATE(), 5, 6),
(GETDATE(), 6, 7),
(GETDATE(), 7, 8),
(GETDATE(), 8, 9),
(GETDATE(), 9, 10),
(GETDATE(), 10, 11);
GO

-- CHI_TIET_PHIEU_NHAP
INSERT INTO CHI_TIET_PHIEU_NHAP (MaPhieuNhap, MaBienThe, SoLuong, DonGia)
VALUES
(1, 1, 50, 150),
(1, 2, 30, 150),
(2, 4, 40, 200),
(2, 5, 25, 200),
(3, 7, 35, 250),
(3, 8, 20, 250),
(4, 10, 20, 300),
(4, 11, 25, 300),
(5, 12, 50, 180),
(5, 13, 30, 180),
(6, 14, 40, 220),
(6, 15, 20, 220),
(7, 16, 60, 120),
(7, 17, 40, 120),
(8, 18, 30, 180),
(8, 19, 20, 180),
(9, 20, 15, 500),
(9, 21, 10, 500),
(10, 22, 25, 200),
(10, 23, 20, 200);
GO

-- KHACH_HANG
INSERT INTO KHACH_HANG (TenKhachHang, DiaChi, SoDienThoai, GioiTinh, LoaiKhachHang)
VALUES
(N'Nguyễn Văn An', N'123 Lê Lợi, Hà Nội', '0912345678', 0, 0),
(N'Trần Thị Bình', N'456 Nguyễn Trãi, Hà Nội', '0923456789', 1, 1),
(N'Lê Văn Cường', N'789 Trần Phú, Hà Nội', '0934567890', 0, 0),
(N'Phạm Thị Dung', N'12 Lý Thường Kiệt, Hà Nội', '0945678901', 1, 0),
(N'Hoàng Văn Hùng', N'34 Hai Bà Trưng, Hà Nội', '0956789012', 0, 1),
(N'Vũ Thị Lan', N'56 Bà Triệu, Hà Nội', '0967890123', 1, 0),
(N'Đặng Văn Minh', N'78 Xuân Thủy, Hà Nội', '0978901234', 0, 0),
(N'Ngô Thị Nga', N'90 Nguyễn Huệ, Hà Nội', '0989012345', 1, 1),
(N'Bùi Văn Quang', N'11 Trần Nhân Tông, Hà Nội', '0990123456', 0, 0),
(N'Phan Thị Hạnh', N'22 Phan Chu Trinh, Hà Nội', '0901234567', 1, 0);
GO

-- DON_HANG
INSERT INTO DON_HANG (NgayDatHang, MaKhachHang, TrangThai)
VALUES
(GETDATE(), 1, 0),
(GETDATE(), 2, 1),
(GETDATE(), 3, 0),
(GETDATE(), 4, 1),
(GETDATE(), 5, 0),
(GETDATE(), 6, 1),
(GETDATE(), 7, 0),
(GETDATE(), 8, 1),
(GETDATE(), 9, 0),
(GETDATE(), 10, 1);
GO

-- CHI_TIET_DON_HANG
INSERT INTO CHI_TIET_DON_HANG (MaDonHang, MaBienThe, SoLuong, DonGia)
VALUES
(1, 1, 2, 150),
(1, 2, 1, 150),
(2, 4, 3, 200),
(2, 5, 2, 200),
(3, 7, 1, 250),
(3, 8, 2, 250),
(4, 10, 1, 300),
(4, 11, 1, 300),
(5, 12, 2, 180),
(5, 13, 1, 180),
(6, 14, 1, 220),
(6, 15, 1, 220),
(7, 16, 3, 120),
(7, 17, 2, 120),
(8, 18, 1, 180),
(8, 19, 1, 180),
(9, 20, 2, 500),
(9, 21, 1, 500),
(10, 22, 1, 200),
(10, 23, 1, 200);
GO



select * from San_pham;
select * from Bien_the_san_pham;
delete from BIEN_THE_SAN_PHAM
where MauSac = '-1'

select pd.mabienthe, p.masanpham, p.tensanpham, p.mancc,
pd.mausac, pd.kichco, pd.soluong, pd.dongia, pd.giamgia,
pd.trangthaibienthe, p.ngaytao from san_pham as p
left join bien_the_san_pham as pd on pd.masanpham = p.masanpham
where pd.xoabienthe = 0

select pd.mabienthe, p.masanpham, p.tensanpham, p.mancc,
pd.mausac, pd.kichco, pd.soluong, pd.dongia, pd.giamgia,
pd.trangthaibienthe, p.ngaytao from san_pham as p
left join bien_the_san_pham as pd on pd.masanpham = p.masanpham
where pd.xoabienthe = 0 and p.TenSanPham like '%Áo Thun Nam Basic%'

select * from nha_cung_cap;
select * from phieu_nhap;
select * from chi_tiet_phieu_nhap;

update chi_tiet_phieu_nhap
set thoigiannhap = GETDATE()
where thoigiannhap is null;


select tensanpham from san_pham


select pd.mabienthe, p.masanpham, p.tensanpham,
                pd.mausac, pd.kichco, pd.soluong, pd.dongia, pd.giamgia,
                pd.trangthaibienthe, p.ngaytao, p.mancc from san_pham as p
                left join bien_the_san_pham as pd on pd.masanpham = p.masanpham
                where pd.xoabienthe = 0

select * from san_pham as s
left join bien_the_san_pham as bt on s.masanpham = bt.masanpham
where bt.xoabienthe = 0

select b.dongia from san_pham p
left join bien_the_san_pham b on b.masanpham = p.masanpham
where p.masanpham = 10 and b.MauSac = 'Xanh' and b.kichco = 'M'