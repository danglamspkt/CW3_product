   M S B A M L   `   `   `  ����F  BCw3 Product, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:Cw3_Product.UserControlMenuCw3_Product.UserControlMenu  5      *    $Cw3_Product.UserControlMenu.NhanSuUC   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v22.2, Version=22.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aR NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;local)clr-namespace:Cw3_Product.UserControlMenu     5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5	      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962ac _MaterialDesignThemes.MahApps, Version=0.3.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5         MaterialDesignBody#���   5      $��Medium"�5      $��14(�5        NhanSuVM  � DataContext#  [ 5      .��5      �  � RowDefinitions 5   
   �� 5      $��50 �6   6*   �� 5      6   .+�5   
   � $��0��6    � ColumnDefinitions 5      �� 5      $	��300 �6#   61   �� 5      6%   .+�5       � $��0��6   .+�5!      �� -   5         ��Name$ txbTitle��5"      $��
Nhân sự��5!      $��Center=�5#      $��25(�5$      
������� �� TextAlignment$
 Left=�5&      $��	110 0 0 0q�5'      .  (System.Windows.Interactivity.Interaction   Triggers 5(      /  )System.Windows.Interactivity.EventTrigger  5)         	EventName$ MouseLeftButtonDown��6)   .  (System.Windows.Interactivity.TriggerBase   Actions. 5*      6  0System.Windows.Interactivity.InvokeCommandAction     Command 64   �� *
Homedata+	   CommandParameter	 5+   !   �� 
 �� ElementName$
 UCNhanSu��5,      5.      5/      o� 51      $��1��6   $��Center=�52      )  #MaterialDesignThemes.Wpf.MenuAssist   TopLevelMenuItemHeight$ 25Q�53      .@�54      m� $��Tổng quan��6   
�������.@�55      m� -   5         m�Name$ BP��55      $��Bộ Phận��6|   
���   � m� Command 6+   �� *
BoPhandata+ m� CommandParameter 6J   �� $
 UCNhanSu�� m� Icon 6�   0  *MaterialDesignThemes.Wpf.PackIconExtension     Kind$ MonitorScreenshot=�m� 56      -   5        $ NV��56      $��Nhân Viên��6|   
���   � 6+   �� *
NhanSudata+ 6J   �� $
 UCNhanSu�� 6�     $ MonitorScreenshot=�m� 57      -   5        $ bd��57      $��Biểu đồ nhân sự��6�   
���   � 6+   �� *BieuDoNhanSudata+ 6P   �� $
 UCNhanSu�� 6�     $ MonitorScreenshot=�58      5;      5<      � 5?   
   $��1��6    5@      �� 5A      $��30 �6    6.   �� 5B      6"   .+�5E      � $��0��6   .+�5F      ��  �� Orientation$ 
Horizontal=�6   $��5 5 0 0q�66   .+�5G      �� $��18(�6;   
���������6    �� *	txbTitle1+6]   �� 5H      $��18(�6;   
���������6    �� *	txbTitle2+6]   �� 5I      $��18(�6;   
���   ���6    �� *	txbTitle3+6^   5J      5L      � 5M      -   5         �Name$ UCNhanSu��5M       $��1��6   5O      5P      5Q      5R      