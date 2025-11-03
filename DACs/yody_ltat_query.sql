create database YODY_LTAT_DB;

use YODY_LTAT_DB;

/*
gộp 2 bảng nhân viên + tài khoản
Bảng Nhân viên
- Mã nhân viên (pk)
- Họ
- Tên
- Email
- Ngày sinh
- Địa chỉ
- Giới tính
- Tài khoản (fk 1-1 với Tài khoản bên Bảng Tài khoản)

Bảng Tài khoản
- Tài khoản (pk)
- Mật khẩu
- Vai trò (sử dụng Enum Const của C# để Định nghĩa) (nhân viên/nhân viên kho/admin) 0/1/2
- Trạng thái (Online/Offline) ~ Vẫn hoạt động/Đã nghỉ việc ~ 1/0

Bảng Sản phẩm
- Mã sản phẩm (pk)
- Tên sản phẩm
- Mô tả
- Kích cỡ
- Số lượng sản phẩm
- Giá sản phẩm (đơn vị nghìn đồng)
- Nguồn cung cấp (fk *n-1 với Nhà cung cấp bên Bảng Nhà cung cấp)
- Trạng thái sản phẩm (Đã bán/Nghỉ bán) 0/1
- Phần trăm giảm giá

Bảng Nhà cung cấp
- Mã nhà cung cấp (pk)
- Tên nhà cung cấp
- Email

Bảng Phiếu nhập
- Mã phiếu nhập (pk)
- Ngày nhập
- Mã nhà cung cấp (fk 1-1 với Nhà cung cấp tương ứng của bảng nhà cung cấp)
- Mã nhân viên viết phiếu nhập (fk *n-1 với Nhân viên trong bảng nhân viên)

Bảng Chi tiết phiếu nhập
- Mã phiếu nhập (pk) (fk 1-1 với Mã phiéu nhập bên bảng Phiếu nhập)
- Mã sản phẩm
- Số lượng
- Đơn giá (đơn vị nghìn đồng)

Bảng Đơn hàng
- Mã đơn hàng (pk)
- Mã sản phẩm
- Ngày đặt hàng
- Mã khách hàng (fk *n-1 với mã khách hàng bảng Khach hàng)
- Tổng tiền
- Trạng thái 0/1/2 ~ Chưa thanh toán/Đã thanh toán/Đã huỷ

Bảng Đơn hàng chi tiết
- Mã đơn hàng chi tiết (pk)
- Mã đơn hàng (*n-1 với mã ĐƠn hàng, mỗi đơn hàng chi tiết thuộc về duy nhất 1 đơn hàng)
- Mã sản phẩm
- Số lượng
- Đơn giá

Bảng Khách hàng
- Mã khách hàng (pk)
- Tên khách hàng
- Địa chỉ
- Số điện thoại
- Giới tính
- Loại khách hàng (Khách VIP, Khách thường)
*/

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
    NgayTao DATE NOT NULL DEFAULT GETDATE() 
);


create table NHA_CUNG_CAP (
	MaNhaCungCap int identity(1,1) primary key,
	Ten nvarchar(50) not null,
	Email varchar(100) not null
);

create table SAN_PHAM (
	MaSanPham int identity(1,1) primary key,
	TenSanPham nvarchar(255) not null,
	MoTa nvarchar(1000) not null,
	KichCo int not null,
	SoLuong int not null,
	DonGia decimal(6,2) not null,
	MaNCC int not null,
	TrangThaiSanPham tinyint default 1,
	GiamGia DECIMAL(5,2) NOT NULL DEFAULT 0,
	foreign key (MaNCC) references NHA_CUNG_CAP(MaNhaCungCap),
	CONSTRAINT CHK_GiamGia CHECK (GiamGia >= 0 AND GiamGia <= 100)
);

create table PHIEU_NHAP (
	MaPhieuNhap int identity(1,1) primary key,
	NgayNhap datetime not null default getdate(),
	MaNCC int not null,
	MaNV int not null,
	foreign key (MaNCC) references NHA_CUNG_CAP(MaNhaCungCap),
	foreign key (MaNV) references NHAN_VIEN(MaNhanVien)
);

CREATE TABLE CHI_TIET_PHIEU_NHAP (
    IdChiTiet INT IDENTITY(1,1) PRIMARY KEY,
    MaPhieuNhap INT NOT NULL,
    MaSanPham INT NOT NULL,
    SoLuong INT NOT NULL,
    DonGia DECIMAL(6,2) NOT NULL,
    FOREIGN KEY (MaPhieuNhap) REFERENCES PHIEU_NHAP(MaPhieuNhap),
    FOREIGN KEY (MaSanPham) REFERENCES SAN_PHAM(MaSanPham)
);

create table KHACH_HANG (
	MaKhachHang int identity(1,1) primary key,
	TenKhachHang nvarchar(100) not null,
	DiaChi nvarchar(255) not null,
	SoDienThoai varchar(10) not null,
	GioiTinh tinyint,
	LoaiKhachHang tinyint default 0
);

create table DON_HANG (
	MaDonHang int identity(1,1) primary key,
	NgayDatHang datetime not null default getdate(),
	MaKhachHang int not null,
	TrangThai tinyint not null default 0,
	foreign key (MaKhachHang) references KHACH_HANG(MaKhachHang)
);

create table CHI_TIET_DON_HANG (
	MaDonHangChiTiet int identity(1,1) primary key,
	MaDonHang int not null,
	MaSanPham int not null,
	SoLuong int not null,
	DonGia decimal(6,2) not null,
	foreign key (MaDonHang) references DON_HANG(MaDonHang),
	foreign key (MaSanPham) references SAN_PHAM(MaSanPham),
	UNIQUE(MaDonHang, MaSanPham)
);

INSERT INTO NHAN_VIEN (Ho, Ten, Email, NgaySinh, DiaChi, GioiTinh, TaiKhoan, MatKhau, VaiTro)
VALUES
(N'Nguyễn Văn', N'Luận',  'vanluandvlp@gmail.com', '1999-03-15', N'Trên trời Hà Nội', 0, 'admin', '1', 2),
(N'Nguyễn Đình', N'Tuấn',  'tuannd112025@gmail.com', '1999-03-15', N'Số 10, Phố Hàng Bài, Hoàn Kiếm, Hà Nội', 0, 'tuannd', '1', 1),
(N'Trần Thị',   N'Hoa',   'hoatt112025@gmail.com',   '2001-07-22', N'Ngõ 72, phố Nguyễn Trãi, Thanh Xuân, Hà Nội', 1, 'hoatt', '1', 0),
(N'Lê Minh',    N'Huy',    'huylm112025@gmail.com',   '2000-11-05', N'Số 5, Nguyễn Văn Cừ, Long Biên, Hà Nội', 0, 'huylm', '1', 1),
(N'Phạm Thị',   N'Lan',    'lanpt112025@gmail.com',   '2002-02-18', N'Khu đô thị Cầu Giấy, Cầu Giấy, Hà Nội', 1, 'lanpt', '1', 1),
(N'Vũ Đức',     N'Anh',    'anhvd112025@gmail.com',   '1998-12-09', N'Chung cư Times City, Hai Bà Trưng, Hà Nội', 0, 'anhvd', '1', 0),
(N'Đỗ Thị',     N'Hồng',   'hongdt112025@gmail.com',  '2003-05-30', N'Số 27, Phố Hàng Gai, Hoàn Kiếm, Hà Nội', 1, 'hongdt', '1', 0),
(N'Bùi Văn',    N'Sơn',    'sonbv112025@gmail.com',   '1999-09-12', N'Ngõ 123, Phố Bạch Mai, Hai Bà Trưng, Hà Nội', 0, 'sonbv', '1', 0),
(N'Phan Thị',   N'Vân',    'vanpt112025@gmail.com',   '2004-06-03', N'Số 88, Đường Láng, Đống Đa, Hà Nội', 1, 'vanpt', '1', 0),
(N'Võ Minh',    N'Quân',   'quanvm112025@gmail.com',  '2001-10-28', N'Phố Trần Hưng Đạo, Hoàn Kiếm, Hà Nội', 0, 'quanvm', '1', 1),
(N'Hoàng Thị',  N'Ngọc',   'ngocht112025@gmail.com',  '1999-04-20', N'Tổ 5, Phường Cầu Giấy, Quận Cầu Giấy, Hà Nội', 1, 'ngocht', '1', 1);

INSERT INTO NHA_CUNG_CAP (Ten, Email)
VALUES
(N'Công ty ABC', 'abc@gmail.com'),
(N'Công ty DEF', 'def@gmail.com'),
(N'Công ty GHI', 'ghi@gmail.com'),
(N'Công ty JKL', 'jkl@gmail.com'),
(N'Công ty MNO', 'mno@gmail.com'),
(N'Công ty PQR', 'pqr@gmail.com'),
(N'Công ty STU', 'stu@gmail.com'),
(N'Công ty VWX', 'vwx@gmail.com'),
(N'Công ty YZA', 'yza@gmail.com'),
(N'Công ty BCD', 'bcd@gmail.com'),
(N'Công ty EFG', 'efg@gmail.com'),
(N'Công ty HIJ', 'hij@gmail.com'),
(N'Công ty KLM', 'klm@gmail.com'),
(N'Công ty NOP', 'nop@gmail.com'),
(N'Công ty QRS', 'qrs@gmail.com');

INSERT INTO SAN_PHAM
(TenSanPham, MoTa, KichCo, SoLuong, DonGia, MaNCC, TrangThaiSanPham, GiamGia)
VALUES
(N'Áo Vest Nữ', N'Áo vest công sở, hai hàng nút, màu đen', 38, 50, 890, 10, 1, 1.1),
(N'Quần Âu Nam', N'Quần tây slim fit, chất liệu co giãn, màu xanh navy', 33, 140, 520, 6, 1, 2.7),
(N'Váy Maxi Voan', N'Váy dài maxi, cổ V, họa tiết chấm bi', 36, 95, 450, 1, 1, 3.4),
(N'Áo Polo Nam', N'Áo polo cotton, cổ bẻ, màu xám chuột', 42, 250, 280, 13, 1, 1.9),
(N'Quần Short Vải', N'Quần short linen nữ, cạp chun, màu trắng', 30, 310, 190, 4, 1, 3.1),
(N'Áo Khoác Da', N'Áo khoác da PU, kiểu biker, màu nâu đậm', 44, 40, 990, 11, 1, 1.5),
(N'Chân Váy Jean', N'Chân váy chữ A, xẻ tà nhẹ, màu xanh nhạt', 34, 180, 360, 7, 1, 2.3),
(N'Áo Sweater Nữ', N'Áo nỉ sweater in hình, form rộng, màu vàng pastel', 40, 200, 310, 15, 1, 2.0),
(N'Quần Legging Thể Thao', N'Quần legging cạp cao, vải thun co giãn, màu đen', 38, 500, 140, 2, 1, 3.0);

INSERT INTO PHIEU_NHAP (NgayNhap, MaNCC, MaNV) VALUES
('2025-10-25 10:30:00', 3, 1),
('2025-10-26 14:45:00', 8, 3),
('2025-10-27 09:15:00', 1, 2),
('2025-10-28 11:00:00', 5, 4),
('2025-10-29 16:20:00', 10, 5),
('2025-10-30 08:50:00', 2, 1),
('2025-10-31 13:35:00', 7, 3),
('2025-11-01 17:00:00', 4, 2),
('2025-11-01 10:05:00', 9, 4),
('2025-11-02 11:55:00', 6, 5),
('2025-10-20 15:10:00', 1, 1),
('2025-10-23 09:40:00', 3, 3);

INSERT INTO CHI_TIET_PHIEU_NHAP (MaPhieuNhap, MaSanPham, SoLuong, DonGia) VALUES
(1, 4, 150, 290.00),
(1, 7, 200, 350.00),
(2, 1, 100, 145.00),
(2, 5, 120, 180.00),
(3, 8, 80, 280.00),
(3, 3, 110, 420.00),
(4, 9, 300, 130.00),
(4, 2, 70, 850.00),
(5, 6, 50, 950.00),
(5, 8, 150, 320.00),
(6, 4, 180, 295.00),
(6, 5, 250, 185.00),
(7, 3, 90, 410.00),
(7, 7, 130, 345.00),
(8, 2, 60, 840.00),
(8, 8, 100, 275.00),
(9, 6, 80, 960.00),
(10, 9, 200, 135.00),
(11, 1, 150, 140.00),
(12, 4, 120, 300.00);

INSERT INTO KHACH_HANG (TenKhachHang, DiaChi, SoDienThoai, GioiTinh, LoaiKhachHang) VALUES
(N'Nguyễn Thị Hồng Anh', N'Số 15, Ngõ 40, P. Cầu Giấy, Hà Nội', '0987123456', 0, 1),
(N'Trần Văn Bảo', N'Đường 3/2, Q. Ninh Kiều, Cần Thơ', '0912345678', 1, 1),
(N'Lê Thanh Duy', N'22/5 Hẻm 12, P. Thảo Điền, TP. HCM', '0909876543', 1, 0),
(N'Phạm Hải Yến', N'Tòa S1, KĐT Vinhomes Ocean Park, Gia Lâm', '0388990011', 0, 0),
(N'Hoàng Minh Đức', N'56 Trần Phú, P. Hải Châu, Đà Nẵng', '0966778899', 1, 1),
(N'Đỗ Thu Hà', N'Chung cư The Sun, Q. Thanh Xuân, Hà Nội', '0944556677', 0, 0),
(N'Võ Tấn Lộc', N'Lô A4, KCN Biên Hòa 2, Đồng Nai', '0977889900', 1, 0),
(N'Bùi Mai Phương', N'345 Lê Lợi, P. Bến Thành, TP. HCM', '0933221100', 0, 1),
(N'Đinh Công Quyết', N'Khu phố 3, P. Hòa Minh, Đà Nẵng', '0868121314', 1, 0),
(N'Cao Ngọc Diệp', N'Số 10, Đường 19/5, Q. Hà Đông, Hà Nội', '0922334455', 0, 0);

INSERT INTO DON_HANG (NgayDatHang, MaKhachHang, TrangThai) VALUES
('2025-10-15 11:20:00', 3, 2), -- Lê Thanh Duy (Đã giao)
('2025-10-16 15:40:00', 8, 2), -- Bùi Mai Phương (Đã giao)
('2025-10-18 09:30:00', 1, 1), -- Nguyễn Thị Hồng Anh (Đã xác nhận)
('2025-10-20 10:00:00', 5, 1), -- Hoàng Minh Đức (Đã xác nhận)
('2025-10-21 17:05:00', 10, 0), -- Cao Ngọc Diệp (Chờ xác nhận)
('2025-10-22 14:15:00', 2, 2), -- Trần Văn Bảo (Đã giao)
('2025-10-24 16:55:00', 7, 0), -- Võ Tấn Lộc (Chờ xác nhận)
('2025-10-25 08:45:00', 4, 1), -- Phạm Hải Yến (Đã xác nhận)
('2025-10-27 12:25:00', 9, 2), -- Đinh Công Quyết (Đã giao)
('2025-10-28 13:30:00', 6, 1); -- Đỗ Thu Hà (Đã xác nhận)

INSERT INTO CHI_TIET_DON_HANG (MaDonHang, MaSanPham, SoLuong, DonGia) VALUES
(1, 6, 1, 990.00),  -- Áo Khoác Da (DH 1)
(2, 3, 1, 520.00),  -- Quần Âu Nam (DH 2)
(4, 7, 2, 360.00),  -- Chân Váy Jean (DH 4)
(5, 6, 1, 990.00),  -- Áo Khoác Da (DH 5)
(6, 1, 1, 150.00),  -- Túi Đeo Chéo (DH 6)
(8, 2, 1, 890.00),  -- Áo Vest Nữ (DH 8)
(9, 6, 1, 990.00),  -- Áo Khoác Da (DH 9)
(10, 1, 1, 150.00), -- Túi Đeo Chéo (DH 10)
(10, 2, 1, 890.00), -- Áo Vest Nữ (DH 11)
(5, 3, 1, 520.00),  -- Quần Âu Nam (DH 5) - *SP mới cho DH 5*
(8, 5, 1, 190.00);  -- Quần Short Vải (DH 8) - *SP mới cho DH 8*