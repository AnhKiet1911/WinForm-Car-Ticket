
use HeThongBanVeXe


--------------------------------------Main.cs--------------------------------------------
---------------> Main.cs - Line 248 <--------------------------							 												
																					    
if OBJECT_ID(N'Source_GridViewDatVeHuyDoiVe',N'P') is not null							
	drop procedure Source_GridViewDatVeHuyDoiVe
	go

create proc Source_GridViewDatVeHuyDoiVe 
as
	
	select * from  ChuyenXe

go


---------------> Main.cs - Line 369 <--------------------------
		
if OBJECT_ID(N'EditAnhNhanVien',N'P') is not null
	drop procedure EditAnhNhanVien
	go

create proc EditAnhNhanVien @AnhNguoiDung image ,@IdNguoiDung varchar(30)
as
	
	update Anh set Images =@AnhNguoiDung where IdNguoiDung = @IdNguoiDung

go



---------------> Main.cs - Line 425 <--------------------------
		
if OBJECT_ID(N'GetInfoNguoiDung_Ten',N'P') is not null
	drop procedure GetInfoNguoiDung_Ten
	go

create proc GetInfoNguoiDung_Ten @ID varchar(30)
as
	
	select nd.HoTen from NguoiDung nd where nd.IdNguoiDung = @ID 

go

---------------> Main.cs - Line 431 <--------------------------
		
if OBJECT_ID(N'GetInfoNguoiDung_Sex',N'P') is not null
	drop procedure GetInfoNguoiDung_Sex
	go

create proc GetInfoNguoiDung_Sex @ID varchar(30)
as
	
	select nd.GioiTinh from NguoiDung nd where nd.IdNguoiDung = @ID

go

---------------> Main.cs - Line 437 <--------------------------
		
if OBJECT_ID(N'GetInfoNguoiDung_NgaySinh',N'P') is not null
	drop procedure GetInfoNguoiDung_NgaySinh
	go

create proc GetInfoNguoiDung_NgaySinh @ID varchar(30)
as
	
	select nd.NgaySinh from NguoiDung nd where nd.IdNguoiDung = @ID

go

---------------> Main.cs - Line 448 <--------------------------
		
if OBJECT_ID(N'GetInfoNguoiDung_SDT',N'P') is not null
	drop procedure GetInfoNguoiDung_SDT
	go

create proc GetInfoNguoiDung_SDT @ID varchar(30)
as
	
	select nd.SoDT from NguoiDung nd where nd.IdNguoiDung = @ID

go

---------------> Main.cs - Line 455 <--------------------------
		
if OBJECT_ID(N'GetInfoNguoiDung_DiaChi',N'P') is not null
	drop procedure GetInfoNguoiDung_DiaChi
	go

create proc GetInfoNguoiDung_DiaChi @ID varchar(30)
as
	
	select nd.DiaChi from NguoiDung nd where nd.IdNguoiDung = @ID

go


---------------> Main.cs - Line 827 <--------------------------
		
if OBJECT_ID(N'metroGridGuiHang',N'P') is not null
	drop procedure metroGridGuiHang
	go

create proc metroGridGuiHang 
as
	
	select * from KiGuiHangHoa

go


---------------> Main.cs - Line 916 <--------------------------
		
if OBJECT_ID(N'GetLoaiNguoiDung',N'P') is not null
	drop procedure GetLoaiNguoiDung
	go

create proc GetLoaiNguoiDung @ID varchar(30)
as
	
	select DISTINCT lnd.TenLoaiND from NguoiDung nd , LoaiNguoiDung lnd where nd.IdNguoiDung = @ID and lnd.IdLoaiND = nd.IdLoaiND 

go


---------------> Main.cs - Line 993 <--------------------------
		
if OBJECT_ID(N'dataGridViewBanVe',N'P') is not null
	drop procedure dataGridViewBanVe
	go

create proc dataGridViewBanVe 
as
	
	select cast(bv.IdVe as char(2)) +' - '+ bv.IdChuyen as Ma ,bv.TenHanhKhach as Ten from BanVe bv 

go


---------------> Main.cs - Line 1015 <--------------------------
		
if OBJECT_ID(N'dataGridViewNikki',N'P') is not null
	drop procedure dataGridViewNikki
	go

create proc dataGridViewNikki 
as
	
	select * from NhatKyKhachHang

go


--------------------------------------DangNhap.cs--------------------------------------------

---------------> DangNhap.cs - Line 83 <--------------------------							 												
																					    
if OBJECT_ID(N'DangNhap',N'P') is not null							
	drop procedure DangNhap
	go

create proc DangNhap @UseName varchar(30), @MatKhau char(32)
as
	
	select Count(*) from NguoiDung where IdNguoiDung=@UseName and PassND = @MatKhau

go





------------------------------------------------------Nhân Viên ---------------------------------------------------------------

--------------------------------------DatVe.cs--------------------------------------------

---------------> DatVe.cs - Line 42 <--------------------------							 												
																					    
if OBJECT_ID(N'GetChoNgoi',N'P') is not null							
	drop procedure GetChoNgoi
	go

create proc GetChoNgoi @IdChuyenDi varchar(30)
as
	
	select cx.SoGheTrong from ChuyenXe cx where cx.IdChuyen = @IdChuyenDi

go


---------------> DatVe.cs - Line 112 <--------------------------							 												
																					    
if OBJECT_ID(N'LoTrinh',N'P') is not null							
	drop procedure LoTrinh
	go

create proc LoTrinh @IdChuyen varchar(30)
as
	
	select cx.DiemXuatPhat +' - '+cx.DiemDich from ChuyenXe cx where cx.IdChuyen = @IdChuyen

go


---------------> DatVe.cs - Line 158 <--------------------------							 												
																					    
if OBJECT_ID(N'GetLoTrinhVe',N'P') is not null							
	drop procedure GetLoTrinhVe
	go

create proc GetLoTrinhVe 
as
	
	select DISTINCT  (xe.DiemXuatPhat +' - '+ xe.DiemDich)as LoTrinh from ChuyenXe xe

go



---------------> DatVe.cs - Line 187 <--------------------------							 												
																					    
if OBJECT_ID(N'GetInfoVe_NgayDi',N'P') is not null							
	drop procedure GetInfoVe_NgayDi
	go

create proc GetInfoVe_NgayDi @DiemXuatPhat nvarchar(50) , @DiemDich nvarchar(50)
as
	
	select  xe.NgayDi from ChuyenXe xe  where xe.DiemXuatPhat = @DiemXuatPhat and xe.DiemDich= @DiemDich

go

---------------> DatVe.cs - Line 199 <--------------------------							 												
																					    
if OBJECT_ID(N'GetInfoVe_GioDi',N'P') is not null							
	drop procedure GetInfoVe_GioDi
	go

create proc GetInfoVe_GioDi @DiemXuatPhat nvarchar(50) , @DiemDich nvarchar(50)
as
	
	select  xe.Gio from ChuyenXe xe  where xe.DiemXuatPhat = @DiemXuatPhat and xe.DiemDich= @DiemDich

go


---------------> DatVe.cs - Line 206 <--------------------------							 												
																					    
if OBJECT_ID(N'GetInfoVe_ID',N'P') is not null							
	drop procedure GetInfoVe_ID
	go

create proc GetInfoVe_ID 
as
	
	select MAX(bv.IdVe) + 1 from BanVe bv

go



---------------> DatVe.cs - Line 213 <--------------------------							 												
																					    
if OBJECT_ID(N'GetInfoVe_IdChuyen',N'P') is not null							
	drop procedure GetInfoVe_IdChuyen
	go

create proc GetInfoVe_IdChuyen @DiemXuatPhat nvarchar(50) , @DiemDich nvarchar(50)
as
	
	select  xe.IdChuyen from ChuyenXe xe  where xe.DiemXuatPhat = @DiemXuatPhat and xe.DiemDich= @DiemDich

go


---------------> DatVe.cs - Line 269 <--------------------------							 												
																					    
if OBJECT_ID(N'ThemVe',N'P') is not null							
	drop procedure ThemVe
	go

create proc ThemVe @IdChuyen varchar(30) , @TenHanhKhach nvarchar(50) , @NgaySinh varchar(50),@SDTHanhKhach varchar(11),@CMND varchar(12),@QueQuan nvarchar(50),@GiaTien varchar(50),@ThoiGianMua nvarchar(50)
as
	
	insert into BanVe(IdChuyen,TenHanhKhach,NgaySinh,SDTHanhKhach,CMND,QueQuan,GiaTien,ThoiGianMuaVe) values( @IdChuyen, @TenHanhKhach, @NgaySinh, @SDTHanhKhach, @CMND, @QueQuan, @GiaTien, @ThoiGianMua)

go

---------------> DatVe.cs - Line 270 <--------------------------							 												
																					    
if OBJECT_ID(N'UpdateChoNgoi',N'P') is not null							
	drop procedure UpdateChoNgoi
	go

create proc UpdateChoNgoi @SoGheTrong int , @IdChuyen varchar(30)
as
	
	update ChuyenXe set SoGheTrong = @SoGheTrong where IdChuyen = @IdChuyen

go


---------------> DatVe.cs - Line 271 <--------------------------							 												
																					    
if OBJECT_ID(N'InsertUuDaiKhachHang',N'P') is not null							
	drop procedure InsertUuDaiKhachHang
	go

create proc InsertUuDaiKhachHang @MaVeUuDai varchar(20) , @TenHangKhachUuDai nvarchar(50),@SDTUuDai varchar(11),@CMNDUuDai varchar(12),@LoaiGiaoDich nvarchar(100)
as
	
	insert into NhatKyKhachHang(MaVe,TenHanhKhach,SDTHanhKhach,CMND,LoaiGiaoDich) values(@MaVeUuDai,@TenHangKhachUuDai,@SDTUuDai,@CMNDUuDai,@LoaiGiaoDich)

go




--------------------------------------EditNguoiDung.cs--------------------------------------------

---------------> EditNguoiDung.cs - Line 88 <--------------------------							 												
																					    
if OBJECT_ID(N'EditUser',N'P') is not null							
	drop procedure EditUser
	go

create proc EditUser @DiaChi nvarchar(100), @SDT varchar(15) ,@IdNguoiDung varchar(30)
as
	
	update NguoiDung set DiaChi= @DiaChi ,SoDT = @SDT where IdNguoiDung = @IdNguoiDung

go







--------------------------------------GuiHang.cs--------------------------------------------

---------------> GuiHang.cs - Line 137 <--------------------------							 												
																					    
if OBJECT_ID(N'KiGui',N'P') is not null							
	drop procedure KiGui
	go

create proc KiGui @TenNguoiGui nvarchar(50),@SDTNguoiGui varchar(11),@CMNDNguoiGui varchar(12),@TenNguoiNhan nvarchar(50),@SDTNguoiNhan varchar(11),@CMNDNguoiNhan varchar(12),@TenMonHang nvarchar(50),@TrongLuong varchar(10),@KichThuoc varchar(10),@ChiPhiGui varchar(50),@IdChuyen varchar(30)
as
	
	insert into KiGuiHangHoa(TenNguoiGui,SDTNguoiGui,CMNDNguoiGui,TenNguoiNhan,SDTNguoiNhan,CMNDNguoiNhan,TenMonHang,TrongLuong,KichThuoc,ChiPhiGui,IdChuyen)
	values(@TenNguoiGui, @SDTNguoiGui, @CMNDNguoiGui, @TenNguoiNhan, @SDTNguoiNhan, @CMNDNguoiNhan, @TenMonHang, @TrongLuong, @KichThuoc, @ChiPhiGui, @IdChuyen)

go



---------------> GuiHang.cs - Line 139 <--------------------------							 												
																					    
if OBJECT_ID(N'InsertNhatKi',N'P') is not null							
	drop procedure InsertNhatKi
	go

create proc InsertNhatKi @TenNguoiGui nvarchar(50),@SDTNguoiGui varchar(11),@CMNDNguoiGui varchar(12),@LoaiGiaoDichGui nvarchar(100)
as
	
	insert into NhatKyKhachHang(TenHanhKhach,SDTHanhKhach,CMND,LoaiGiaoDich) 
	values(@TenNguoiGui,@SDTNguoiGui,@CMNDNguoiGui,@LoaiGiaoDichGui) 

go



---------------> GuiHang.cs - Line 234 <--------------------------							 												
																					    
if OBJECT_ID(N'GetLoTrinhVe',N'P') is not null							
	drop procedure GetLoTrinhVe
	go

create proc GetLoTrinhVe 
as
	select DISTINCT  (xe.DiemXuatPhat +' - '+ xe.DiemDich)as LoTrinh from ChuyenXe xe
go



---------------> GuiHang.cs - Line 268 <--------------------------							 												
																					    
if OBJECT_ID(N'GetInfoVe_NgayDi',N'P') is not null							
	drop procedure GetInfoVe_NgayDi
	go

create proc GetInfoVe_NgayDi  @DiemXuatPhat nvarchar(50), @DiemDich nvarchar(50)
as
	select  xe.NgayDi from ChuyenXe xe  where xe.DiemXuatPhat = @DiemXuatPhat and xe.DiemDich= @DiemDich
go




---------------> GuiHang.cs - Line 280 <--------------------------							 												
																					    
if OBJECT_ID(N'GetInfoVe_GioDi',N'P') is not null							
	drop procedure GetInfoVe_GioDi
	go

create proc GetInfoVe_GioDi  @DiemXuatPhat nvarchar(50), @DiemDich nvarchar(50)
as
	select  xe.Gio from ChuyenXe xe  where xe.DiemXuatPhat = @DiemXuatPhat and xe.DiemDich= @DiemDich
go




---------------> GuiHang.cs - Line 287 <--------------------------							 												
																					    
if OBJECT_ID(N'GetInfoVe_IdHang',N'P') is not null							
	drop procedure GetInfoVe_IdHang
	go

create proc GetInfoVe_IdHang  
as
	select MAX(kghh.IdHangHoa) + 1 from KiGuiHangHoa kghh
go


---------------> GuiHang.cs - Line 294 <--------------------------							 												
																					    
if OBJECT_ID(N'GetInfoVe_IdChuyen',N'P') is not null							
	drop procedure GetInfoVe_IdChuyen
	go

create proc GetInfoVe_IdChuyen  @DiemXuatPhat nvarchar(50), @DiemDich nvarchar(50)
as
	select  xe.IdChuyen from ChuyenXe xe  where xe.DiemXuatPhat = @DiemXuatPhat and xe.DiemDich= @DiemDich
go




---------------> GuiHang.cs - Line 340 <--------------------------							 												
																					    
if OBJECT_ID(N'GetTenNhanVien',N'P') is not null							
	drop procedure GetTenNhanVien
	go

create proc GetTenNhanVien  @IdNguoiDung varchar(30)
as
	select nd.HoTen from NguoiDung nd where nd.IdNguoiDung=@IdNguoiDung
go






--------------------------------------HuyDoiVe.cs--------------------------------------------

---------------> HuyDoiVe.cs - Line 280 <--------------------------							 												
																					    
if OBJECT_ID(N'DoiVe',N'P') is not null							
	drop procedure DoiVe
	go

create proc DoiVe @IdChuyenNow varchar(30),@TenHanhKhach nvarchar(50),@NgaySinh varchar(50),@SDTHanhKhach varchar(11),@CMND varchar(12),@QueQuan nvarchar(50),@GiaTien varchar(50),@ThoiGianMua nvarchar(50),@IdChuyenCanDoi varchar(30),@IdVe int
as
		
	update BanVe set IdChuyen =@IdChuyenNow,TenHanhKhach = @TenHanhKhach ,NgaySinh = @NgaySinh ,SDTHanhKhach = @SDTHanhKhach,CMND = @CMND , QueQuan =@QueQuan, GiaTien =@GiaTien,ThoiGianMuaVe = @ThoiGianMua
	where IdChuyen = @IdChuyenCanDoi and IdVe = @IdVe
go




---------------> HuyDoiVe.cs - Line 375 <--------------------------							 												
																					    
if OBJECT_ID(N'HuyVe',N'P') is not null							
	drop procedure HuyVe
	go

create proc HuyVe @IdChuyen varchar(30),@IdVe int
as
	delete from BanVe where IdChuyen = @IdChuyen and IdVe = @IdVe
go


---------------> HuyDoiVe.cs - Line 433 <--------------------------							 												
																					    
if OBJECT_ID(N'ShowInfoKhachHang_Ten',N'P') is not null							
	drop procedure ShowInfoKhachHang_Ten
	go

create proc ShowInfoKhachHang_Ten @IdChuyen varchar(30),@IdVe int
as
	select bv.TenHanhKhach 
	from BanVe bv , ChuyenXe cx 
	where bv.IdChuyen =cx.IdChuyen and bv.IdVe = @IdVe and bv.IdChuyen = @IdChuyen
go



---------------> HuyDoiVe.cs - Line 440 <--------------------------							 												
																					    
if OBJECT_ID(N'ShowInfoKhachHang_CMND',N'P') is not null							
	drop procedure ShowInfoKhachHang_CMND
	go

create proc ShowInfoKhachHang_CMND @IdChuyen varchar(30),@IdVe int
as
	select bv.CMND 
	from BanVe bv , ChuyenXe cx 
	where bv.IdChuyen =cx.IdChuyen and bv.IdVe = @IdVe and bv.IdChuyen = @IdChuyen
go


---------------> HuyDoiVe.cs - Line 448 <--------------------------							 												
																					    
if OBJECT_ID(N'ShowInfoKhachHang_Que',N'P') is not null							
	drop procedure ShowInfoKhachHang_Que
	go

create proc ShowInfoKhachHang_Que @IdChuyen varchar(30),@IdVe int
as
	select bv.QueQuan 
	from BanVe bv , ChuyenXe cx 
	where bv.IdChuyen =cx.IdChuyen and bv.IdVe = @IdVe and bv.IdChuyen = @IdChuyen
go



---------------> HuyDoiVe.cs - Line 456 <--------------------------							 												
																					    
if OBJECT_ID(N'ShowInfoKhachHang_SDT',N'P') is not null							
	drop procedure ShowInfoKhachHang_SDT
	go

create proc ShowInfoKhachHang_SDT @IdChuyen varchar(30),@IdVe int
as
	select bv.SDTHanhKhach
	from BanVe bv , ChuyenXe cx 
	where bv.IdChuyen =cx.IdChuyen and bv.IdVe = @IdVe and bv.IdChuyen = @IdChuyen
go



---------------> HuyDoiVe.cs - Line 463 <--------------------------							 												
																					    
if OBJECT_ID(N'ShowInfoKhachHang_NgaySinh',N'P') is not null							
	drop procedure ShowInfoKhachHang_NgaySinh
	go

create proc ShowInfoKhachHang_NgaySinh @IdChuyen varchar(30),@IdVe int
as
	select bv.NgaySinh 
	from BanVe bv , ChuyenXe cx 
	where bv.IdChuyen =cx.IdChuyen and bv.IdVe = @IdVe and bv.IdChuyen = @IdChuyen
go




---------------> HuyDoiVe.cs - Line 470 <--------------------------							 												
																					    
if OBJECT_ID(N'ShowInfoKhachHang_Tien',N'P') is not null							
	drop procedure ShowInfoKhachHang_Tien
	go

create proc ShowInfoKhachHang_Tien @IdChuyen varchar(30),@IdVe int
as
	select bv.GiaTien 
	from BanVe bv , ChuyenXe cx 
	where bv.IdChuyen =cx.IdChuyen and bv.IdVe = @IdVe and bv.IdChuyen = @IdChuyen
go



---------------> HuyDoiVe.cs - Line 477 <--------------------------							 												
																					    
if OBJECT_ID(N'ShowInfoKhachHang_NgayDi',N'P') is not null							
	drop procedure ShowInfoKhachHang_NgayDi
	go

create proc ShowInfoKhachHang_NgayDi @IdChuyen varchar(30),@IdVe int
as
	select cx.NgayDi 
	from BanVe bv , ChuyenXe cx 
	where bv.IdChuyen =cx.IdChuyen and bv.IdVe = @IdVe and bv.IdChuyen = @IdChuyen
go



---------------> HuyDoiVe.cs - Line 484 <--------------------------							 												
																					    
if OBJECT_ID(N'ShowInfoKhachHang_GioDi',N'P') is not null							
	drop procedure ShowInfoKhachHang_GioDi
	go

create proc ShowInfoKhachHang_GioDi @IdChuyen varchar(30),@IdVe int
as
	select cx.Gio 
	from BanVe bv , ChuyenXe cx 
	where bv.IdChuyen =cx.IdChuyen and bv.IdVe = @IdVe and bv.IdChuyen = @IdChuyen
go


---------------> HuyDoiVe.cs - Line 491 <--------------------------							 												
																					    
if OBJECT_ID(N'ShowInfoKhachHang_LoTrinh',N'P') is not null							
	drop procedure ShowInfoKhachHang_LoTrinh
	go

create proc ShowInfoKhachHang_LoTrinh @IdChuyen varchar(30),@IdVe int
as
	select  (cx.DiemXuatPhat +' - '+ cx.DiemDich)as LoTrinh 
	from ChuyenXe cx , BanVe bv 
	where bv.IdChuyen =cx.IdChuyen and bv.IdVe = @IdVe and bv.IdChuyen = @IdChuyen
go




---------------> HuyDoiVe.cs - Line 531 <--------------------------							 												
																					    
if OBJECT_ID(N'KiemTraTonTaiVe',N'P') is not null							
	drop procedure KiemTraTonTaiVe
	go

create proc KiemTraTonTaiVe @IdChuyen varchar(30),@IdVe int
as
	select COUNT(bv.IdVe) 
	from BanVe bv , ChuyenXe cx 
	where bv.IdChuyen =cx.IdChuyen and bv.IdVe = @IdVe and bv.IdChuyen = @IdChuyen
go







--------------------------------------InPhieuDatVe.cs--------------------------------------------
---------------> InPhieuDatVe.cs - Line 45 <--------------------------							 												
																					    
if OBJECT_ID(N'GetInfoKhachHang_IdChuyen',N'P') is not null							
	drop procedure GetInfoKhachHang_IdChuyen
	go

create proc GetInfoKhachHang_IdChuyen  @ID varchar(30)
as
	select bv.IdChuyen from BanVe bv where bv.IdVe = @ID
go



---------------> InPhieuDatVe.cs - Line 51 <--------------------------							 												
																					    
if OBJECT_ID(N'GetInfoKhachHang_Ten',N'P') is not null							
	drop procedure GetInfoKhachHang_Ten
	go

create proc GetInfoKhachHang_Ten  @ID varchar(30)
as
	select bv.TenHanhKhach from BanVe bv where bv.IdVe = @ID
go




---------------> InPhieuDatVe.cs - Line 57 <--------------------------							 												
																					    
if OBJECT_ID(N'GetInfoKhachHang_CMND',N'P') is not null							
	drop procedure GetInfoKhachHang_CMND
	go

create proc GetInfoKhachHang_CMND  @ID varchar(30)
as
	select bv.CMND from BanVe bv where bv.IdVe = @ID
go




---------------> InPhieuDatVe.cs - Line 64 <--------------------------							 												
																					    
if OBJECT_ID(N'GetInfoKhachHang_NgaySinh',N'P') is not null							
	drop procedure GetInfoKhachHang_NgaySinh
	go

create proc GetInfoKhachHang_NgaySinh  @ID varchar(30)
as
	select bv.NgaySinh from BanVe bv where bv.IdVe = @ID
go






---------------> InPhieuDatVe.cs - Line 76 <--------------------------							 												
																					    
if OBJECT_ID(N'GetInfoKhachHang_SDT',N'P') is not null							
	drop procedure GetInfoKhachHang_SDT
	go

create proc GetInfoKhachHang_SDT  @ID varchar(30)
as
	select bv.SDTHanhKhach from BanVe bv where bv.IdVe = @ID
go



---------------> InPhieuDatVe.cs - Line 82 <--------------------------							 												
																					    
if OBJECT_ID(N'GetInfoKhachHang_DiaChi',N'P') is not null							
	drop procedure GetInfoKhachHang_DiaChi
	go

create proc GetInfoKhachHang_DiaChi  @ID varchar(30)
as
	select bv.QueQuan from BanVe bv where bv.IdVe = @ID
go




---------------> InPhieuDatVe.cs - Line 91 <--------------------------							 												
																					    
if OBJECT_ID(N'GetInfoKhachHang_SoXe',N'P') is not null							
	drop procedure GetInfoKhachHang_SoXe
	go

create proc GetInfoKhachHang_SoXe  @IdChuyen varchar(30)
as
	select cx.So_Xe from ChuyenXe cx where cx.IdChuyen = @IdChuyen
go




---------------> InPhieuDatVe.cs - Line 97 <--------------------------							 												
																					    
if OBJECT_ID(N'GetInfoKhachHang_NgayDi',N'P') is not null							
	drop procedure GetInfoKhachHang_NgayDi
	go

create proc GetInfoKhachHang_NgayDi  @IdChuyen varchar(30)
as
	select cx.NgayDi from ChuyenXe cx where cx.IdChuyen = @IdChuyen
go




---------------> InPhieuDatVe.cs - Line 103 <--------------------------							 												
																					    
if OBJECT_ID(N'GetInfoKhachHang_GioDi',N'P') is not null							
	drop procedure GetInfoKhachHang_GioDi
	go

create proc GetInfoKhachHang_GioDi  @IdChuyen varchar(30)
as
	select cx.Gio from ChuyenXe cx where cx.IdChuyen = @IdChuyen
go




---------------> InPhieuDatVe.cs - Line 109 <--------------------------							 												
																					    
if OBJECT_ID(N'GetInfoKhachHang_HieuXe',N'P') is not null							
	drop procedure GetInfoKhachHang_HieuXe
	go

create proc GetInfoKhachHang_HieuXe  @IdChuyen varchar(30)
as
	select cx.Hieu_Xe from ChuyenXe cx where cx.IdChuyen = @IdChuyen
go



---------------> InPhieuDatVe.cs - Line 115 <--------------------------							 												
																					    
if OBJECT_ID(N'GetInfoKhachHang_LoTrinh',N'P') is not null							
	drop procedure GetInfoKhachHang_LoTrinh
	go

create proc GetInfoKhachHang_LoTrinh  @IdChuyen varchar(30)
as
	select cx.DiemXuatPhat +' - '+ cx.DiemDich as LoTrinh  from ChuyenXe cx where cx.IdChuyen = @IdChuyen
go




---------------> InPhieuDatVe.cs - Line 123 <--------------------------							 												
																					    
if OBJECT_ID(N'GetInfoKhachHang_TenNhanVien',N'P') is not null							
	drop procedure GetInfoKhachHang_TenNhanVien
	go

create proc GetInfoKhachHang_TenNhanVien  @IdNguoiDung varchar(30)
as
	select nd.HoTen from NguoiDung nd where nd.IdNguoiDung=@IdNguoiDung
go

	
 

 --------------------------------------NhanHang.cs--------------------------------------------
---------------> NhanHang.cs - Line 50 <--------------------------							 												
																					    
if OBJECT_ID(N'KiemTraTonTai_Hang',N'P') is not null							
	drop procedure KiemTraTonTai_Hang
	go

create proc KiemTraTonTai_Hang  @IdHangHoa varchar(30) , @IdChuyen varchar(30)
as
	select COUNT(hh.IdHangHoa) from KiGuiHangHoa hh, ChuyenXe cx  where hh.IdChuyen =cx.IdChuyen and hh.IdHangHoa = @IdHangHoa and hh.IdChuyen = @IdChuyen
go




---------------> NhanHang.cs - Line 79 <--------------------------							 												
																					    
if OBJECT_ID(N'InfoNhanHang_TenNG',N'P') is not null							
	drop procedure InfoNhanHang_TenNG
	go

create proc InfoNhanHang_TenNG  @IdHangHoa varchar(30) , @IdChuyen varchar(30)
as
	select hh.TenNguoiGui from KiGuiHangHoa hh, ChuyenXe cx  where hh.IdChuyen =cx.IdChuyen and hh.IdHangHoa = @IdHangHoa and hh.IdChuyen = @IdChuyen
go



---------------> NhanHang.cs - Line 86 <--------------------------		
if OBJECT_ID(N'InfoNhanHang_TenNN',N'P') is not null							
	drop procedure InfoNhanHang_TenNN
	go

create proc InfoNhanHang_TenNN  @IdHangHoa varchar(30) , @IdChuyen varchar(30)
as
	select hh.TenNguoiNhan from KiGuiHangHoa hh, ChuyenXe cx  where hh.IdChuyen =cx.IdChuyen and hh.IdHangHoa = @IdHangHoa and hh.IdChuyen = @IdChuyen
go


---------------> NhanHang.cs - Line 95 <--------------------------		
if OBJECT_ID(N'InfoNhanHang_CMNDNG',N'P') is not null							
	drop procedure InfoNhanHang_CMNDNG
	go

create proc InfoNhanHang_CMNDNG  @IdHangHoa varchar(30) , @IdChuyen varchar(30)
as
	select hh.CMNDNguoiGui from KiGuiHangHoa hh, ChuyenXe cx  where hh.IdChuyen =cx.IdChuyen and hh.IdHangHoa = @IdHangHoa and hh.IdChuyen = @IdChuyen
go



---------------> NhanHang.cs - Line 103 <--------------------------		
if OBJECT_ID(N'InfoNhanHang_CMNDNN',N'P') is not null							
	drop procedure InfoNhanHang_CMNDNN
	go

create proc InfoNhanHang_CMNDNN  @IdHangHoa varchar(30) , @IdChuyen varchar(30)
as
	select hh.CMNDNguoiNhan from KiGuiHangHoa hh, ChuyenXe cx  where hh.IdChuyen =cx.IdChuyen and hh.IdHangHoa = @IdHangHoa and hh.IdChuyen = @IdChuyen
go



---------------> NhanHang.cs - Line 110 <--------------------------		
if OBJECT_ID(N'InfoNhanHang_SDTNG',N'P') is not null							
	drop procedure InfoNhanHang_SDTNG
	go

create proc InfoNhanHang_SDTNG  @IdHangHoa varchar(30) , @IdChuyen varchar(30)
as
	select hh.SDTNguoiGui from KiGuiHangHoa hh, ChuyenXe cx  where hh.IdChuyen =cx.IdChuyen and hh.IdHangHoa = @IdHangHoa and hh.IdChuyen = @IdChuyen
go


---------------> NhanHang.cs - Line 117 <--------------------------		
if OBJECT_ID(N'InfoNhanHang_SDTNN',N'P') is not null							
	drop procedure InfoNhanHang_SDTNN
	go

create proc InfoNhanHang_SDTNN  @IdHangHoa varchar(30) , @IdChuyen varchar(30)
as
	select hh.SDTNguoiNhan from KiGuiHangHoa hh, ChuyenXe cx  where hh.IdChuyen =cx.IdChuyen and hh.IdHangHoa = @IdHangHoa and hh.IdChuyen = @IdChuyen
go




---------------> NhanHang.cs - Line 125 <--------------------------		
if OBJECT_ID(N'InfoNhanHang_TenHang',N'P') is not null							
	drop procedure InfoNhanHang_TenHang
	go

create proc InfoNhanHang_TenHang  @IdHangHoa varchar(30) , @IdChuyen varchar(30)
as
	select hh.TenMonHang from KiGuiHangHoa hh, ChuyenXe cx  where hh.IdChuyen =cx.IdChuyen and hh.IdHangHoa = @IdHangHoa and hh.IdChuyen = @IdChuyen
go




---------------> NhanHang.cs - Line 132 <--------------------------		
if OBJECT_ID(N'InfoNhanHang_TrongLuong',N'P') is not null							
	drop procedure InfoNhanHang_TrongLuong
	go

create proc InfoNhanHang_TrongLuong  @IdHangHoa varchar(30) , @IdChuyen varchar(30)
as
	select hh.TrongLuong from KiGuiHangHoa hh, ChuyenXe cx  where hh.IdChuyen =cx.IdChuyen and hh.IdHangHoa = @IdHangHoa and hh.IdChuyen = @IdChuyen
go



---------------> NhanHang.cs - Line 132 <--------------------------		
if OBJECT_ID(N'InfoNhanHang_KichThuoc',N'P') is not null							
	drop procedure InfoNhanHang_KichThuoc
	go

create proc InfoNhanHang_KichThuoc  @IdHangHoa varchar(30) , @IdChuyen varchar(30)
as
	select hh.KichThuoc from KiGuiHangHoa hh, ChuyenXe cx  where hh.IdChuyen =cx.IdChuyen and hh.IdHangHoa = @IdHangHoa and hh.IdChuyen = @IdChuyen
go




---------------> NhanHang.cs - Line 146 <--------------------------		
if OBJECT_ID(N'InfoNhanHang_LoTrinh',N'P') is not null							
	drop procedure InfoNhanHang_LoTrinh
	go

create proc InfoNhanHang_LoTrinh   @IdChuyen varchar(30)
as
	select cx.DiemXuatPhat +' - '+cx.DiemDich from ChuyenXe cx  where cx.IdChuyen = @IdChuyen
go



---------------> NhanHang.cs - Line 153 <--------------------------		
if OBJECT_ID(N'InfoNhanHang_DiemGui',N'P') is not null							
	drop procedure InfoNhanHang_DiemGui
	go

create proc InfoNhanHang_DiemGui   @IdChuyen varchar(30)
as
	select cx.DiemXuatPhat from ChuyenXe cx  where cx.IdChuyen = @IdChuyen
go


---------------> NhanHang.cs - Line 159 <--------------------------		
if OBJECT_ID(N'InfoNhanHang_DiemNhan',N'P') is not null							
	drop procedure InfoNhanHang_DiemNhan
	go

create proc InfoNhanHang_DiemNhan   @IdChuyen varchar(30)
as
	select cx.DiemDich from ChuyenXe cx  where cx.IdChuyen = @IdChuyen
go



---------------> NhanHang.cs - Line 165 <--------------------------		
if OBJECT_ID(N'InfoNhanHang_NgayChay',N'P') is not null							
	drop procedure InfoNhanHang_NgayChay
	go

create proc InfoNhanHang_NgayChay   @IdChuyen varchar(30)
as
	select cx.NgayDi from ChuyenXe cx  where cx.IdChuyen = @IdChuyen
go



---------------> NhanHang.cs - Line 171 <--------------------------		
if OBJECT_ID(N'InfoNhanHang_Gio',N'P') is not null							
	drop procedure InfoNhanHang_Gio
	go

create proc InfoNhanHang_Gio   @IdChuyen varchar(30)
as
	select cx.Gio from ChuyenXe cx  where cx.IdChuyen = @IdChuyen
go





---------------> NhanHang.cs - Line 254 <--------------------------		
if OBJECT_ID(N'NhanHang',N'P') is not null							
	drop procedure NhanHang
	go

create proc NhanHang   @IdChuyen varchar(30) , @IdHangHoa varchar(30) 
as
	delete from KiGuiHangHoa where IdChuyen = @IdChuyen and IdHangHoa = @IdHangHoa
go



---------------> NhanHang.cs - Line 255 <--------------------------		
if OBJECT_ID(N'InsertNikki',N'P') is not null							
	drop procedure InsertNikki
	go

create proc InsertNikki   @TenNguoiNhan varchar(50) , @SDTNguoiNhan varchar(11), @CMNDNguoiNhan varchar(12),@LoaiGiaoDichNhan nvarchar(100)
as
	insert into NhatKyKhachHang(TenHanhKhach,SDTHanhKhach,CMND,LoaiGiaoDich) 
	values(@TenNguoiNhan,@SDTNguoiNhan,@CMNDNguoiNhan,@LoaiGiaoDichNhan)
go


	

--------------------------------------XepLich.cs--------------------------------------------

---------------> XepLich.cs - Line 104 <--------------------------							 												
																					    
if OBJECT_ID(N'XepLichChayXe',N'P') is not null							
	drop procedure XepLichChayXe
	go

create proc XepLichChayXe @IdChuyen varchar(30),@So_Xe varchar(10),@NgayDi varchar(50),@Gio varchar(10),@HieuXe varchar(50),@SoGhe int , @XuatPhat nvarchar(50),@DiemDich nvarchar(50)
as
	
	insert into ChuyenXe(IdChuyen,So_Xe,NgayDi,Gio,Hieu_Xe,SoGheTrong,DiemXuatPhat,DiemDich) 
	values(@IdChuyen,@So_Xe,@NgayDi,@Gio,@HieuXe,@SoGhe,@XuatPhat,@DiemDich)

go



