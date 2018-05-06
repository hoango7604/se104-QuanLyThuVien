CREATE DATABASE THUVIEN 
GO 
USE THUVIEN
GO 



CREATE TABLE docgia (
  mathe INT NOT NULL PRIMARY KEY ,
  hoten NVARCHAR(50) NOT NULL ,
  email NVARCHAR(50) ,
  ngaysinh DATETIME NOT NULL ,
  ngaydk DATETIME NOT NULL ,
  diachi NVARCHAR(50) , 
  loaidocgia INT NOT NULL , 
  tongtienno INT  ,

)
GO


CREATE TABLE sach (
  masach INT NOT NULL PRIMARY KEY , 
  tensach NVARCHAR(50) NOT NULL ,
  theloai VARCHAR(50) NOT NULL ,
  tacgia NVARCHAR(50) NOT NULL ,
  nxb NVARCHAR(50) ,
  ngaynhap DATETIME NOT NULL ,
  ngayxb DATETIME NOT NULL , 
  giatri INT NOT	NULL ,
  trangthai INT NOT NULL
 
)
GO

CREATE TABLE quydinh (
  tuoimax INT NOT NULL ,
  tuoimin INT NOT NULL , 
  songayduocmuon INT NOT NULL ,
  sosachduocmuon INT NOT NULL, 
  kcnamxuatban INT NOT	NULL ,
 
 )
 GO
 
 CREATE TABLE cacloaidocgia (
   loaidg INT NOT NULL 

 )
 GO
 

 CREATE TABLE phieumuon (
 mapm INT NOT NULL  PRIMARY KEY ,
 ngaymuon DATETIME NOT NULL ,
 mathe INT FOREIGN KEY REFERENCES dbo.docgia (mathe) 
 )
 GO 

CREATE TABLE phieutra (
 mapt INT NOT NULL PRIMARY KEY ,
 ngaytra DATETIME NOT NULL ,
 tienphatkinay INT NOT NULL ,
 mathe INT FOREIGN KEY REFERENCES dbo.docgia (mathe) 
)
GO

CREATE TABLE ct_phieumuon (
 mapm INT FOREIGN KEY REFERENCES dbo.phieumuon (mapm), 
 masach INT FOREIGN KEY REFERENCES dbo.sach (masach)


)
GO 
 CREATE TABLE ct_phieutra (
 songaydamuon INT NOT NULL , 
 tienphatsach INT NOT NULL ,

 mapt INT NOT NULL FOREIGN KEY REFERENCES dbo.phieutra (mapt), 
 masach INT NOT NULL  FOREIGN KEY REFERENCES dbo.sach (masach),


 )
 GO
 

 INSERT INTO dbo.docgia
 VALUES  ( 0 , -- mathe - int
           N'nguyễn minh tín  ' , -- hoten - nvarchar(50)
           'mh@gmail.com' , -- email - varchar(50)
           convert(datetime,'18-06-2012 10:34:09 PM',103) , -- ngaysinh - datetime
           convert(datetime,'18-06-2016 10:34:09 PM',103) , -- ngaydk - datetime
           N'vvvvv' , -- diachi - nvarchar(50)
            2 , -- loaidocgia - int 
           123000  -- tongtienno - INT
         )

INSERT INTO dbo.docgia
 VALUES  ( 1 , -- mathe - int
           N'Ngô Đức Hòa  ' , -- hoten - nvarchar(50)
           'hoa@gmail.com' , -- email - varchar(50)
           convert(datetime,'18-06-2012 10:34:09 PM',103) , -- ngaysinh - datetime
           convert(datetime,'18-06-2016 10:34:09 PM',103) , -- ngaydk - datetime
           N'aaaa' , -- diachi - nvarchar(50)
            2 , -- loaidocgia - int 
           123000  -- tongtienno - INT
         )



INSERT INTO dbo.quydinh
        ( tuoimax ,
          tuoimin ,
          songayduocmuon ,
          sosachduocmuon ,
          kcnamxuatban
        )
VALUES  ( 50 , -- tuoimax - int
          18 , -- tuoimin - int
          14 , -- songayduocmuon - int
          3 , -- sosachduocmuon - int
          8  -- kcnamxuatban - int
        ) 

INSERT INTO	dbo.cacloaidocgia 
        ( loaidg )
VALUES  ( 2  -- loaidg - int
          )

--constrant 
 --tb [quydinh][docgia] :ngaysinh-ngayhientai >= tuoimin  and <=50  them dg 
 --tb [quydinh][sach] : ngayxb -ngayhientai ,= 8 nam                them sach
 --tb [quydinh][phieumuon] ngaymuon-ngaydk <= hanthesudung          them phieumuon      
 --tb [phieumuon][quydinh] ngayhientai -ngaymuon <= songayduocmuon  them phieumuon 
 --tb [] 
 -- ??a DTO c?a QUYDINH len h?t lên bus s? lí 
 -- 


--constrant 
 --tb [quydinh][docgia] :ngaysinh-ngayhientai >= tuoimin  and <=50  them dg 
 --tb [quydinh][sach] : ngayxb -ngayhientai ,= 8 nam                them sach
 --tb [quydinh][phieumuon] ngaymuon-ngaydk <= hanthesudung          them phieumuon      
 --tb [phieumuon][quydinh] ngayhientai -ngaymuon <= songayduocmuon  them phieumuon 
 --tb [] 
 -- ??a DTO c?a QUYDINH len h?t lên bus s? lí 




INSERT dbo.docgia
(
    mathe,
    hoten,
    email,
    ngaysinh,
    ngaydk,
    diachi,
    loaidocgia,
    tongtienno
)
VALUES
(   341919229,         -- mathe - int
    N'Nguyễn Thị Mai',       -- hoten - nvarchar(50)
    'mai@gmail.com',        -- email - varchar(50)
    GETDATE(), -- ngaysinh - datetime
    GETDATE(), -- ngaydk - datetime
    N'VietNam',       -- diachi - nvarchar(50)
    1,         -- loaidocgia - int
    0       -- tongtienno - money
)
INSERT dbo.docgia
(
    mathe,
    hoten,
    email,
    ngaysinh,
    ngaydk,
    diachi,
    loaidocgia,
    tongtienno
)
VALUES
(   341221939,         -- mathe - int
    N'Lê Thị Phượng',       -- hoten - nvarchar(50)
    'phuong@gmail.com',        -- email - varchar(50)
    GETDATE(), -- ngaysinh - datetime
    GETDATE(), -- ngaydk - datetime
    N'VietNam',       -- diachi - nvarchar(50)
    1,         -- loaidocgia - int
    0       -- tongtienno - money
)
INSERT dbo.docgia
(
    mathe,
    hoten,
    email,
    ngaysinh,
    ngaydk,
    diachi,
    loaidocgia,
    tongtienno
)
VALUES
(   351829259,         -- mathe - int
    N'Phan Văn Mai',       -- hoten - nvarchar(50)
    'maipv@gmail.com',        -- email - varchar(50)
    GETDATE(), -- ngaysinh - datetime
    GETDATE(), -- ngaydk - datetime
    N'VietNam',       -- diachi - nvarchar(50)
    1,         -- loaidocgia - int
    0       -- tongtienno - money
)
INSERT dbo.docgia
(
    mathe,
    hoten,
    email,
    ngaysinh,
    ngaydk,
    diachi,
    loaidocgia,
    tongtienno
)
VALUES
(   344569569,         -- mathe - int
    N'Phan Thị Phan',       -- hoten - nvarchar(50)
    'Phanphan@gmail.com',        -- email - varchar(50)
    GETDATE(), -- ngaysinh - datetime
    GETDATE(), -- ngaydk - datetime
    N'VietNam',       -- diachi - nvarchar(50)
    1,         -- loaidocgia - int
    0       -- tongtienno - money
)
INSERT dbo.docgia
(
    mathe,
    hoten,
    email,
    ngaysinh,
    ngaydk,
    diachi,
    loaidocgia,
    tongtienno
)
VALUES
(   343573829,         -- mathe - int
    N'Dương Quá',       -- hoten - nvarchar(50)
    'duongqua@gmail.com',        -- email - varchar(50)
    GETDATE(), -- ngaysinh - datetime
    GETDATE(), -- ngaydk - datetime
    N'VietNam',       -- diachi - nvarchar(50)
    1,         -- loaidocgia - int
    0       -- tongtienno - money
)
INSERT dbo.docgia
(
    mathe,
    hoten,
    email,
    ngaysinh,
    ngaydk,
    diachi,
    loaidocgia,
    tongtienno
)
VALUES
(   345924334,         -- mathe - int
    N'Thần Điêu',       -- hoten - nvarchar(50)
    'dieu@gmail.com',        -- email - varchar(50)
    GETDATE(), -- ngaysinh - datetime
    GETDATE(), -- ngaydk - datetime
    N'VietNam',       -- diachi - nvarchar(50)
    1,         -- loaidocgia - int
    0       -- tongtienno - money
)
INSERT dbo.docgia
(
    mathe,
    hoten,
    email,
    ngaysinh,
    ngaydk,
    diachi,
    loaidocgia,
    tongtienno
)
VALUES
(   344657629,         -- mathe - int
    N'Hoàng Châu Cách Cách',       -- hoten - nvarchar(50)
    'cachcachchau@gmail.com',        -- email - varchar(50)
    GETDATE(), -- ngaysinh - datetime
    GETDATE(), -- ngaydk - datetime
    N'VietNam',       -- diachi - nvarchar(50)
    1,         -- loaidocgia - int
    0       -- tongtienno - money
)
INSERT dbo.docgia
(
    mathe,
    hoten,
    email,
    ngaysinh,
    ngaydk,
    diachi,
    loaidocgia,
    tongtienno
)
VALUES
(   352648829,         -- mathe - int
    N'Tên Gì Đây',       -- hoten - nvarchar(50)
    'wtf@gmail.com',        -- email - varchar(50)
    GETDATE(), -- ngaysinh - datetime
    GETDATE(), -- ngaydk - datetime
    N'VietNam',       -- diachi - nvarchar(50)
    1,         -- loaidocgia - int
    0       -- tongtienno - money
)
INSERT dbo.docgia
(
    mathe,
    hoten,
    email,
    ngaysinh,
    ngaydk,
    diachi,
    loaidocgia,
    tongtienno
)
VALUES
(   341945548,         -- mathe - int
    N'Đây Là Cái Tên',       -- hoten - nvarchar(50)
    'name@gmail.com',        -- email - varchar(50)
    GETDATE(), -- ngaysinh - datetime
    GETDATE(), -- ngaydk - datetime
    N'VietNam',       -- diachi - nvarchar(50)
    1,         -- loaidocgia - int
    0       -- tongtienno - money
)
INSERT dbo.docgia
(
    mathe,
    hoten,
    email,
    ngaysinh,
    ngaydk,
    diachi,
    loaidocgia,
    tongtienno
)
VALUES
(   333664448,         -- mathe - int
    N'Phạm Thị Phan',       -- hoten - nvarchar(50)
    'phamphan@gmail.com',        -- email - varchar(50)
    GETDATE(), -- ngaysinh - datetime
    GETDATE(), -- ngaydk - datetime
    N'VietNam',       -- diachi - nvarchar(50)
    1,         -- loaidocgia - int
    0       -- tongtienno - money
)
INSERT dbo.docgia
(
    mathe,
    hoten,
    email,
    ngaysinh,
    ngaydk,
    diachi,
    loaidocgia,
    tongtienno
)
VALUES
(   341944536,         -- mathe - int
    N'Lê Thị Phan',       -- hoten - nvarchar(50)
    'phan@gmail.com',        -- email - varchar(50)
    GETDATE(), -- ngaysinh - datetime
    GETDATE(), -- ngaydk - datetime
    N'VietNam',       -- diachi - nvarchar(50)
    1,         -- loaidocgia - int
    1       -- tongtienno - money
)


INSERT dbo.sach
(
    masach,
    tensach,
    theloai,
    tacgia,
    nxb,
    ngaynhap,
    ngayxb,
    giatri,
    trangthai
)
VALUES
(   3,         -- masach - int
    N'Lập Trình C',       -- tensach - nvarchar(50)
    'code',        -- theloai - varchar(50)
    N'UIT',       -- tacgia - nvarchar(50)
    N'UITer',       -- nxb - nvarchar(50)
    GETDATE(), -- ngaynhap - datetime
    GETDATE(), -- ngayxb - datetime
    10000,         -- giatri - int
    1          -- trangthai - int
)

INSERT dbo.sach
(
    masach,
    tensach,
    theloai,
    tacgia,
    nxb,
    ngaynhap,
    ngayxb,
    giatri,
    trangthai
)
VALUES
(   4,         -- masach - int
    N'Lập Trình C#',       -- tensach - nvarchar(50)
    'code',        -- theloai - varchar(50)
    N'UIT',       -- tacgia - nvarchar(50)
    N'UITer',       -- nxb - nvarchar(50)
    GETDATE(), -- ngaynhap - datetime
    GETDATE(), -- ngayxb - datetime
    10000,         -- giatri - int
    1          -- trangthai - int
)

INSERT dbo.sach
(
    masach,
    tensach,
    theloai,
    tacgia,
    nxb,
    ngaynhap,
    ngayxb,
    giatri,
    trangthai
)
VALUES
(   5,         -- masach - int
    N'Lập Trình C++',       -- tensach - nvarchar(50)
    'code',        -- theloai - varchar(50)
    N'UIT',       -- tacgia - nvarchar(50)
    N'UITer',       -- nxb - nvarchar(50)
    GETDATE(), -- ngaynhap - datetime
    GETDATE(), -- ngayxb - datetime
    10000,         -- giatri - int
    1          -- trangthai - int
)

INSERT dbo.sach
(
    masach,
    tensach,
    theloai,
    tacgia,
    nxb,
    ngaynhap,
    ngayxb,
    giatri,
    trangthai
)
VALUES
(   6,         -- masach - int
    N'Đây là cuốn sách',       -- tensach - nvarchar(50)
    'code',        -- theloai - varchar(50)
    N'Phạm Nhật Trường',       -- tacgia - nvarchar(50)
    N'UITer',       -- nxb - nvarchar(50)
    GETDATE(), -- ngaynhap - datetime
    GETDATE(), -- ngayxb - datetime
    10000,         -- giatri - int
    1          -- trangthai - int
)

INSERT dbo.sach
(
    masach,
    tensach,
    theloai,
    tacgia,
    nxb,
    ngaynhap,
    ngayxb,
    giatri,
    trangthai
)
VALUES
(   7,         -- masach - int
    N'Đây cũng là cuốn sách',       -- tensach - nvarchar(50)
    'code',        -- theloai - varchar(50)
    N'Phạm Nhậx Trường',       -- tacgia - nvarchar(50)
    N'UITer',       -- nxb - nvarchar(50)
    GETDATE(), -- ngaynhap - datetime
    GETDATE(), -- ngayxb - datetime
    10000,         -- giatri - int
    1          -- trangthai - int
)


