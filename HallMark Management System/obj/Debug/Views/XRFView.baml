   M S B A M L   `   `   `  ����U  QHallMark Management System, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:HallMark_Management_System.Views HallMark_Management_System.Views  5      .    (HallMark_Management_System.Views.XRFView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      @local.clr-namespace:HallMark_Management_System.Views     5      
�������  � 	Resources  5       	  Ctrl1 �� Text�� 5   
   %0   &	        �� 5      $ Another text��6,   5       J� InputBindings 5      �� 5   
   
 �� Key$ F5��6    �� Command# [  6    J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command# [  5      6:   .��5      �  � ColumnDefinitions 5   
   �� 5      $��20 �6   �� 5      $��* �6   �� 5       $��20 �6    � RowDefinitions 5#   
   �� 5$      $��40 �6   �� 5%      $��* �6   �� 5&      $��20 �6   .+�5)   
   `� $��0��6   $��0��6#   	 `� 
Background	 �#F0DDF4$��3��6H   .�5*      c� ���#F0DDF4��5+      �� 5,      
 �� 
TargetType"
 c�6   .�5.      ��  �� Property �@`�IsLocked �� Value . 6A   �� 50       �@c�OverflowMode$ Never=�69   �� 51       � �� 52      �� 53   "    �� 
TargetType" c�62   .R�54   &   a�  K� IsItemsHost . ���#F0DDF46F   55   #   57      58      .@�5:      �� $��10,0,0,0q�6   .��5;      �� $%��/Images/toolbargraphics/new.png��6   $��30��6E   $��30��6Q   5<      �� 5=      $��10,0,0,0q�6   .��5>      �� $&�� /Images/toolbargraphics/edit.png��6   $��30��6F   $��30��6R   5?      �� 5@      -   5         ��Name$ btnSave��5@      $��10,0,0,0q�6+   .��5A      �� $&�� /Images/toolbargraphics/save.png��6   $��30��6F   $��30��6R   5B      �� 5D      $��10,0,0,0q�6   .��5E      �� $)��#/Images/toolbargraphics/discard.png��6   $��30��6I   $��30��6U   5F      �� 5H      6   �� 5I      $��10,0,0,0q�6   .��5J      �� $(��"/Images/toolbargraphics/reload.png��6   $��30��6H   $��30��6T   5K      �� 5L      $��10,0,0,0q�6   .��5M      �� $(��"/Images/toolbargraphics/search.png��6   $��30��6H   $��30��6T   5N      �� 5O      $��10,0,0,0q�6   .��5P      �� $'��!/Images/toolbargraphics/print.png��6   $��30��6G   $��30��6S   5Q      �� 5R      6   �� 5S      $��10,0,0,0q�6   .��5T      �� $$��/Images/toolbargraphics/up.png��6   $��30��6D   $��30��6P   5U      �� 5V      $��10,0,0,0q�6   .��5W      �� $'��!/Images/toolbargraphics/right.png��6   $��30��6G   $��30��6S   5X      �� 5Y      $��10,0,0,0q�6   .��5Z      �� $&�� /Images/toolbargraphics/left.png��6   $��30��6F   $��30��6R   5[      �� 5]      $��10,0,0,0q�6   .��5^      �� $&�� /Images/toolbargraphics/down.png��6   $��30��6F   $��30��6R   5_      �� 5`      6   �� 5a      $��10,0,0,0q�6   .��5b      �� $'��!/Images/toolbargraphics/close.png��6   $��30��6G   $��30��6S   5c      �� 5d      $��10,0,0,0q�6   .��5e      �� $*��$/Images/toolbargraphics/poweroff.png��6   $��30��6J   $��30��6V   5f      5g      5h      � 5k   
   $��1��6   $��1��6    5m      �� 5n      $��* �6#    5q      �� 5r      $
��auto �6    �� 5s      $
��auto �6    �� 5t      $
��auto �6    .+�5w      �� $��0��6   $��0��6(   
����  � �� Padding$ 20,0,0,0q�6G   $��0,20,0,0q�6Z   �� 5x      $�Company Master��6   
�������$��18(�6;   $��Medium"�6I   5y      �� 5{      $��0��6   $��1��6%   
��� � �$��1q�5|   )   $��80��6=   $��
0,20,361,0q�6I   ._�5~      �  5      �� 5�      $
��auto �6+   �� 5�      $
��auto �6+   �� 5�      $
��auto �6+    5�      �� 5�      $
��auto �6(   �� 5�      $
��auto �6(   .+�5�      �� $��0��6    $��0��60   $��Job Card No :��6=   $��14(�6R   $��Medium"�6`   $��	10,10,0,0q�6t   �� 5�      -   5         ��Name$ job_card_no��5�      $��1��63   $��0��6C   $��	TC/2021/1��6P   $��	10,10,0,0q�6b   $��14(�6u   $��Medium"�6�   $	��200��5�      $
��Left=�5�      �� 5�      $��0��6    $��1��60   $��Correction Factor :��6=   $��14(�6X   $��Medium"�6f   $��	10,10,0,0q�6z   �� 5�      -   5        $ correction_factor��5�      $��1��69   $��1��6I   $
��0.03��6V   $��	10,10,0,0q�6c   $��14(�6v   $��Medium"�6�   $	��600��5�      6V   �� 5�      $��2��6   $��0��6-   $	��100��6:   $��	10,10,0,0q�6F   .��5�      �� $�Print��6   
���  ��$��14(�6<   $��Medium"�6J   5�      5�      5�      �� 5�      $��0��6   $��2��6%   
��� � �$��1q�5�   )   $	��400��6=   $��
0,20,361,0q�6J   ._�5�      �  5�      �� 5�      $��* �6+    5�      �� 5�      $
��auto �6(   .+�5�      &   System.Windows.Controls.DataGrid  -   5          Name$ mainXRFDataGrid��5�      $��0��5�      $��0��6,   $
��auto��5�      $	��380��5�         SelectionUnit$
 Cell=�5�         SelectionMode$ Single=�5�         AutoGenerateColumns .    5�      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� BasedOn��%o  '        7 �� 5�      8   "
  6]   .�5�   "   ��  � ��
 �����6?   �� 5�   "    � ��
 �   �6?   �� 5�   "    � ��
 �   �6@   �� 5�   "    � ��$ 1 1 1 1q�6D   �� 5�   "    � ��$ 	-1,-1,0,0q�6;   �� 5�   "    � ��$ 48��6;   �� 5�   "    � ��$
 auto��6:   �� 5�   "    � ��$ Center=�6O   5�      5�         RowStyle 5�      �� 5�      )  #System.Windows.Controls.DataGridRow"
  6$   .�5�   "   -   5        5�         Columns 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,  &System.Windows.Controls.DataGridColumn   Header$ Job Card No��61      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6i      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6F   ��  �� Path$ 	jobCardNo�6u     5�      $ Name Of Jewellery��61   $	 200 6t    .  6L   �� $ nameOfJewllery�6�     5�      $ Declared  
   Purity��61   $ 80 6|    .  6T   �� $ declaredPurity�6�     5�      $ Finess��61   $ 80 6A    6L   �� $ finess�  5�      $ Result��61   $ 80 6A    6L   �� $ result�  5�      $ Ag��61   $ 60 6=    6H   �� $ ag�  5�      $ CU��61   $ 60 6=    6H   �� $ cu�  5�      $ PB��61   $ 60 6=    6H   �� $ pb�  5�      $ IR
 %��61   $ 60 6E    6P   �� $ ir�  5�      $ RU
 %��61   $ 60 6E    6P   �� $ ru�  5�      $ CD
 %��61   $ 60 6E    6P   �� $ cd�  5�      $ Remark��61   $ 60 6A    6L   �� $ remark�5�      5�      5�      5�      5�      5�      