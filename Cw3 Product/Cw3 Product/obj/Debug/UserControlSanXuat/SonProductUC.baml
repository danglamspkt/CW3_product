   M S B A M L   `   `   `  ����F  BCw3 Product, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:Cw3_Product.UserControlSanXuatCw3_Product.UserControlSanXuat  5      1    +Cw3_Product.UserControlSanXuat.SonProductUC   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v22.2, Version=22.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aR NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      >local,clr-namespace:Cw3_Product.UserControlSanXuat     5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962ac _MaterialDesignThemes.MahApps, Version=0.3.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5	         MaterialDesignBody#���   5
      $��Medium"�5      $��14(�5        SonChiTietVM  � DataContext#  [ 5      .��5      � .+�5   
   #  MaterialDesignThemes.Wpf.Card  +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowEdges$	 All=�6      ShadowDepth$ Depth3=�5         UniformCornerRadius$ 10Q�5      .��5      &   System.Windows.Controls.DataGrid     AutoGenerateColumns .  
�������   CanUserAddRows .     CanUserDeleteRows .  ��63   �� *SanLuongList+ �� SelectedItem 6X   �� *SelectedItemSl+ �� Mode$ TwoWay=�	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Header$	
 STT��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ 80 6Q   1  +System.Windows.Controls.DataGridBoundColumn   Binding 66   �� *IdSxDk+6Q     5      $
 Mã phiếu��6)   $	 120 6W    6;   �� *	MaPhieu+6W     5      $
 Ngày��6)   $	 120 6i    67   �� *Ngay+ �� StringFormat$ 
dd/MM/yyyy��6i     5      $
 Ca lv��6)   $ 80 6Q    68   �� *CaLv+6Q     5      $
 Mã máy��6)   $	 100 6S    69   �� *MaMay+6S     5      $
 Nhân viên��6)   $	 170 6Y    6<   �� *
NhanVien+6Y     5      $
 Thời gianbắt đầu��6)   $	 120 6f    6H   �� *	hourstart+6f     5      $
 Thời giankết thúc��6)   $	 120 6f    6J   �� *	hourend+6f     5       $
 Số lô��6)   $	 200 6Q    68   �� *SoLo+6Q     5!      $
 
Số họa��6)   $	 120 6S    69   �� *SoHoa+6S     5"      $
 Số lượngtrên máy��6)   $	 120 6~    6H   �� *	SoLuong+$ {0:#,#.}��6~     5#      $
 
Đơn vị��6)   $ 80 6k    69   �� *IdU+$ {0:#,#.}��6k     5$      $
 Phế��6)   $	 120 6h    66   �� *Phe+$ {0:#,#.}��6h     5%      $
 Nguyên nhân��6)   $	 120 6]    6>   �� *
NguyenNhan+6]   5'      5(      5)      5*      