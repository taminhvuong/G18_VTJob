Create database BTL_VTJob;
Create table Nguoidung(
UserID varchar (10) primary Key,
Hoten nvarchar(50)  NOT NULL,
MatKhau varchar(20) NOT NULL,
Email varchar(50) unique  NOT NULL,
Quyen VARCHAR(10) NOT NULL CHECK (Quyen IN('Admin', 'Management', 'User')),
TenCT nvarchar(50),
Mota text,
DiaChi nvarchar(150)
)
Create TABLE BaiTuyenDung(
MaBai varchar (10) primary Key,
TieuDe nvarchar(250),
LoaiCongViec nvarchar(50),
MucLuong float ,
SoLuongTuyen int,
MoTaCV TEXT,
YeuCau Text,
QuyenLoi Text ,
NgayDang Date now,
HanNopCV Date,
UserID varchar(10),
FOREIGN KEY (UserID) REFERENCES NguoiDung(UserID)

)
Create TABLE CVUngTuyen(
MaCV varchar (10) primary Key,
CV Text,
MaBai varchar(10),
UserID varchar(10),
FOREIGN KEY (UserID) REFERENCES NguoiDung(UserID),
FOREIGN KEY (MaBai) REFERENCES BaiTuyenDung(MaBai)
)