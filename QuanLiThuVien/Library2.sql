


CREATE DATABASE THUVIEN 
GO 
USE THUVIEN 
GO 



CREATE TABLE docgia (
  mathe INT NOT NULL PRIMARY KEY ,
  hoten NVARCHAR(50) NOT NULL ,
  email VARCHAR(50) ,
  ngaysinh DATETIME NOT NULL ,
  ngaydk DATETIME NOT NULL ,
  diachi NVARCHAR(50) , 
  loaidocgia INT NOT NULL , 
  tongtienno MONEY  ,

)
GO



CREATE TABLE sach (
  masach INT NOT NULL PRIMARY KEY , 
  tensach NVARCHAR(50) NOT NULL ,
  theloai VARCHAR(50) NOT NULL ,
  nxb NVARCHAR(50) ,
  ngayxb DATETIME NOT NULL , 
  giatri MONEY NOT	NULL ,
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
 tienphatkinay MONEY NOT NULL ,
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
 tienphatsach MONEY NOT NULL ,

 mapt INT NOT NULL FOREIGN KEY REFERENCES dbo.phieutra (mapt), 
 masach INT NOT NULL  FOREIGN KEY REFERENCES dbo.sach (masach),


 )
 GO
 

 INSERT INTO dbo.docgia
 VALUES  ( 0 , -- mathe - int
           N'nguy?n minh t�n  ' , -- hoten - nvarchar(50)
           'mh@gmail.com' , -- email - varchar(50)
           convert(datetime,'18-06-2012 10:34:09 PM',103) , -- ngaysinh - datetime
           convert(datetime,'18-06-2016 10:34:09 PM',103) , -- ngaydk - datetime
           N'vvvvv' , -- diachi - nvarchar(50)
            2 , -- loaidocgia - int 
           123000  -- tongtienno - money
         )

INSERT INTO	 dbo.sach 
VALUES  ( 2 , -- masach - int
          N'codedaokisu' , -- tensach - nvarchar(50)
          'progaming' , -- theloai - varchar(50)
          N'codedao' , -- nxb - nvarchar(50)
         convert(datetime,'18-06-2016 10:34:09 PM',103) , -- ngayxb - datetime
          20 , -- giatri - money
          1  -- trangthai - int
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
 -- ??a DTO c?a QUYDINH len h?t l�n bus s? l� 
 -- 



--