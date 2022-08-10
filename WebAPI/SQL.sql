CREATE DATABASE QLNV
GO
USE QLNV
GO
CREATE TABLE PhongBan
(
	MaPB nvarchar(10) PRIMARY KEY,
	TenPB nvarchar(50) NOT NULL
)
GO
CREATE TABLE NhanVien
(
	MaNV nvarchar(10) PRIMARY KEY,
	HoNV nvarchar(50) NOT NULL,
	TenNV nvarchar(10) NOT NULL,
	GioiTinh bit DEFAULT(1),
	NgaySinh date,
	Luong int,
	AnhNV nvarchar(50),
	DiaChi nvarchar(100) NOT NULL,
	MaPB nvarchar(10) NOT NULL FOREIGN KEY REFERENCES PhongBan(MaPB)
	ON UPDATE CASCADE
	ON DELETE CASCADE
)
GO
CREATE TABLE QuanTri
(
	Email varchar(50) PRIMARY KEY,
	Admin bit,
	HoTen nvarchar(50),
	Password nvarchar(50)
)
GO
INSERT INTO PhongBan VALUES('KD',N'Phòng kinh doanh'),(N'KT',N'Phòng Kế toán')
GO
INSERT INTO QuanTri VALUES('thanhbc@ntu.edu.vn',1,N'Bùi Chí Thành','123')
GO
INSERT NhanVien VALUES (N'KD001', N'Vũ Tiến', N'Dương', 1, CAST(N'1995-11-23' AS Date), 6100000, N'employee.png', N'Nha Trang, Khánh Hòa', N'KD')
INSERT NhanVien VALUES (N'KD0012', N'Bùi Chí', N'Thành', 1, CAST(N'1990-01-01' AS Date), 5500000, N'employee.png', N'Nha Trang - Khánh Hòa', N'KD')
INSERT NhanVien VALUES (N'KD002', N'Phạm Thành', N'Ân', 1, CAST(N'1993-12-08' AS Date), 3000000, N'employee.png', N'Nha Trang, Khánh Hòa', N'KD')
INSERT NhanVien VALUES (N'KD003', N'Nguyễn Hồng', N'Chương', 1, CAST(N'1990-02-02' AS Date), 3500000, N'employee.png', N'Nha Trang, Khánh Hòa', N'KD')
INSERT NhanVien VALUES (N'KD004', N'Dương Hồng', N'Đức', 1, CAST(N'1994-04-06' AS Date), 4000000, N'employee.png', N'Nha Trang, Khánh Hòa', N'KD')
INSERT NhanVien VALUES (N'KD005', N'Nguyễn Minh Phương', N'Thảo', 0, CAST(N'1995-03-16' AS Date), 4500000, N'employee.png', N'Nha Trang, Khánh Hòa', N'KD')
INSERT NhanVien VALUES (N'KD006', N'Nguyễn Hồng
', N'Liên', 0, CAST(N'1997-08-12' AS Date), 5000000, N'employee.png', N'Nha Trang, Khánh Hòa', N'KD')
INSERT NhanVien VALUES (N'KT001', N'Lê Thị Thùy', N'Duyên', 0, CAST(N'1970-01-01' AS Date), 6000000, N'employee.png', N'Nha Trang, Khánh Hòa', N'KT')
INSERT NhanVien VALUES (N'KT002', N'Nguyễn Thị Mỹ
', N'Linh', 0, CAST(N'2000-04-30' AS Date), 5500000, N'employee.png', N'Nha Trang, Khánh Hòa', N'KT')
INSERT NhanVien VALUES (N'KT003', N'Nguyễn Hữu Vinh
', N'Quang', 1, CAST(N'2000-03-19' AS Date), 6000000, N'employee.png', N'Nha Trang, Khánh Hòa', N'KT')
INSERT NhanVien VALUES (N'KT004', N'Nguyễn Công', N'Phương', 1, CAST(N'1990-12-19' AS Date), 6000000, N'employee.png', N'Nha Trang, Khánh Hòa', N'KD')

create proc InDS_NhanVien
as
begin 
	select * from NhanVien
end
