   M S B A M L   `   `   `  ����F  BCw3 Product, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:Cw3_Product.UserControlSanXuatCw3_Product.UserControlSanXuat  5      0    *Cw3_Product.UserControlSanXuat.GcDkCheckUC   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v22.2, Version=22.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aR NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      >local,clr-namespace:Cw3_Product.UserControlSanXuat     5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962ac _MaterialDesignThemes.MahApps, Version=0.3.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5	         MaterialDesignBody#���   5
      $��Medium"�5      $��14(�5        GcDkChiTietVM  � DataContext#  [ 5      .��5      � .+�5   
   #  MaterialDesignThemes.Wpf.Card  +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowEdges$	 All=�6      ShadowDepth$ Depth3=�5         UniformCornerRadius$ 10Q�5      .��5      &   System.Windows.Controls.DataGrid     AutoGenerateColumns .  
�������   CanUserAddRows .     CanUserDeleteRows .  ��63   �� *	CheckList+ �� SelectedItem 6U   �� *SelectedItemCheck+ �� Mode$ TwoWay=�	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Header$	
 STT��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ 80 6V   1  +System.Windows.Controls.DataGridBoundColumn   Binding 66   �� *IdEnKiemTra+6V     5      $
 Mã phiếu��6)   $	 120 6W    6;   �� *	MaPhieu+6W     5      $
 Ngày��6)   $	 120 6i    67   �� *Ngay+ �� StringFormat$ 
dd/MM/yyyy��6i     5      $
 Ca lv��6)   $ 80 6Q    68   �� *CaLv+6Q     5      $
 Mã máy��6)   $	 100 6S    69   �� *MaMay+6S     5      $
 Nhân viên��6)   $	 170 6Y    6<   �� *
NhanVien+6Y     5      $
 Thời gian��6)   $	 120 6Y    6<   �� *
ThoiGian+6Y     5      $
 
Số họa��6)   $	 120 6S    69   �� *SoHoa+6S     5       $
 Hụt nhựa��6)   $	 120 6u    6<   �� *
Kichthuoc1+$ {0:#,#.}��6u     5!      $
 
Màu sắc��6)   $	 120 6s    6:   �� *
Kichthuoc2+$ {0:#,#.}��6s     5"      $
 Bavia��6)   $	 120 6q    68   �� *
Kichthuoc3+$ {0:#,#.}��6q     5#      $
 Gợn sóng��6)   $	 120 6t    6;   �� *
Kichthuoc4+$ {0:#,#.}��6t     5$      $
 Đường kính��6)   $	 120 6v    6=   �� *
Kichthuoc5+$ {0:#,#.}��6v     5%      $
 Trục giữa��6)   $	 120 6u    6<   �� *
Kichthuoc6+$ {0:#,#.}��6u   5'      5(      5)      5*      