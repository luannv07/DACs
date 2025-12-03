select k.tenkhachhang, count(o.madonhang) as tongdonhang from khach_hang k
join DON_HANG o on o.MaKhachHang = k.MaKhachHang
group by k.TenKhachHang
order by tongdonhang desc

-- liet ke san pham ban chay nhat
select s.tensanpham, sum(c.SoLuong) soluong from SAN_PHAM s
join BIEN_THE_SAN_PHAM b on b.MaSanPham = s.MaSanPham
join CHI_TIET_DON_HANG c on c.MaBienThe = b.MaBienThe
group by s.TenSanPham
order by soluong desc

select s.TenSanPham, sum(b.soluong) soluong from SAN_PHAM s
join BIEN_THE_SAN_PHAM b on b.MaSanPham = s.MaSanPham
group by s.TenSanPham
order by soluong desc


bambo khang khuan 54 - 231
				70 - 215


				select top 5 s.masanpham, s.tensanpham, sum(c.SoLuong) soluong from SAN_PHAM s
            join BIEN_THE_SAN_PHAM b on b.MaSanPham = s.MaSanPham
            join CHI_TIET_DON_HANG c on c.MaBienThe = b.MaBienThe
            group by s.TenSanPham, s.masanpham
            order by soluong desc


            SELECT MIN(NgayDatHang) FROM don_hang;
SELECT MAX(NgayDatHang) FROM don_hang;

SELECT 
    SUM(ct.SoLuong * ct.DonGia) AS DoanhThuNgay1611
FROM don_hang dh
JOIN chi_tiet_don_hang ct ON ct.MaDonHang = dh.MaDonHang
WHERE CONVERT(date, dh.NgayDatHang) = '2025-11-16';


CREATE PROCEDURE ClearOldLogs
AS
BEGIN
    DELETE FROM Log_He_Thong WHERE ThoiGian < DATEADD(day, -7, GETDATE());
END;
truncate table Log_He_Thong


select * from Log_He_Thong
