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
  theloai NVARCHAR(50) NOT NULL ,
  tacgia NVARCHAR(50) NOT NULL ,
  nxb NVARCHAR(50) ,
  ngaynhap DATETIME NOT NULL ,
  ngayxb DATETIME NOT NULL , 
  giatri INT NOT	NULL ,
  trangthai INT NOT NULL -- 0: dang muon; 1: chua muon 2: mat
 
)
GO

CREATE TABLE quydinh (
  tienphattrasachtremoingay INT NOT NULL,
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
 
 CREATE TABLE cacloaisach(
	loaisach NVARCHAR(50)
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

 PRIMARY KEY (mapt,masach)
 )


 GO

 

CREATE TABLE giahan (

solangiahan INT NOT NULL ,
masach INT NOT NULL FOREIGN KEY REFERENCES dbo.sach (masach)  

)
 GO
 
CREATE TABLE phieuthutienphat 
(
  maphieuthu INT NOT NULL PRIMARY KEY ,
  ngaythu DATETIME NOT NULL , 
  tienthu INT NOT NULL , 
  mathe INT NOT NULL FOREIGN KEY REFERENCES dbo.docgia(mathe) 


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

GO

 

 --SELECT s.masach, trangthai ,MAX(ngaymuon) AS ngaymuon FROM dbo.sach s, dbo.ct_phieumuon ct, dbo.phieumuon pm WHERE s.masach = ct.masach AND s.trangthai = 0  AND ct.mapm = pm.mapm AND pm.mapm IN(  SELECT mapm  FROM dbo.phieumuon pm, dbo.docgia dg   WHERE pm.mathe = dg.mathe AND DG.mathe = 6   ) GROUP BY s.masach ,s.trangthai 