   M S B A M L   `   `   `  ����U  QHallMark Management System, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:HallMark_Management_System.Views HallMark_Management_System.Views  5      2    ,HallMark_Management_System.Views.ProductView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      @local.clr-namespace:HallMark_Management_System.Views     5      .��5	      � 
�������  � ColumnDefinitions  5
   
   �� 5      $��20 �6   �� 5      $��* �6   �� 5      $��20 �6    � RowDefinitions 5   
   �� 5      $��40 �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $��20 �6   .+�5   
   `� $��0��6   $��1��6#    `� 
Background �#F0DDF4.�5      c� ���#F0DDF4��5      �� 5       �� 
TargetType" c�6   .�5      ��  �� Property �@`�IsLocked �� Value . 6A   �� 5       �@c�OverflowMode$ Never=�69   �� 5       � �� 5      �� 5    "    �� 
TargetType" c�62   .R�5!   &   a�  K� IsItemsHost . ���#F0DDF46F   5"   #   5$      5%      .@�5'      �� $��10,0,0,0q�6   .��5(      �� $%��/Images/toolbargraphics/new.png��6   $��30��6E   $��30��6Q   5)      �� 5*      $��10,0,0,0q�6   .��5+      �� $&�� /Images/toolbargraphics/edit.png��6   $��30��6F   $��30��6R   5,      �� 5-      -   5         ��Name$ btnSave��5-      $��10,0,0,0q�6+   .��5.      �� $&�� /Images/toolbargraphics/save.png��6   $��30��6F   $��30��6R   5/      �� 50      $��10,0,0,0q�6   .��51      �� $)��#/Images/toolbargraphics/discard.png��6   $��30��6I   $��30��6U   52      �� 54      6   �� 55      $��10,0,0,0q�6   .��56      �� $(��"/Images/toolbargraphics/reload.png��6   $��30��6H   $��30��6T   57      �� 58      $��10,0,0,0q�6   .��59      �� $(��"/Images/toolbargraphics/search.png��6   $��30��6H   $��30��6T   5:      �� 5;      $��10,0,0,0q�6   .��5<      �� $'��!/Images/toolbargraphics/print.png��6   $��30��6G   $��30��6S   5=      �� 5>      6   �� 5?      $��10,0,0,0q�6   .��5@      �� $$��/Images/toolbargraphics/up.png��6   $��30��6D   $��30��6P   5A      �� 5B      $��10,0,0,0q�6   .��5C      �� $'��!/Images/toolbargraphics/right.png��6   $��30��6G   $��30��6S   5D      �� 5E      $��10,0,0,0q�6   .��5F      �� $&�� /Images/toolbargraphics/left.png��6   $��30��6F   $��30��6R   5G      �� 5I      $��10,0,0,0q�6   .��5J      �� $&�� /Images/toolbargraphics/down.png��6   $��30��6F   $��30��6R   5K      �� 5L      6   �� 5M      $��10,0,0,0q�6   .��5N      �� $'��!/Images/toolbargraphics/close.png��6   $��30��6G   $��30��6S   5O      �� 5P      $��10,0,0,0q�6   .��5Q      �� $*��$/Images/toolbargraphics/poweroff.png��6   $��30��6J   $��30��6V   5R      5S      5T      �� 5W   
   $��1��6   $��1��6$   
����  �	 �� Padding$	 20,0,0,0q�6C   $��0,20,0,0q�6V   �� 5X      $�Product Master��6   
�������$��18(�6;   $��Medium"�6I   5Y      �� 5[   
   $��0,20,0,0q�5\      $��1q�5]      
��� � �
 �� CornerRadius$
 1��5_      
�������$
��Left=�5a      $	��Top=�5b      $	��900��5c      $	��150��5d      $��1��5e      $��2��5f      ._�5h      �   5i      �� 5j      $
��auto �6'   �� 5k      $
��auto �6'   �� 5l      $
��auto �6'    5o      �� 5p      $
��auto �6$   �� 5q      $
��auto �6$   �� 5r      $
��auto �6$   .+�5u      �� $��0��6   $��0��6)   $��Product Name :��69   $	 
20,10,10,0q�6P   $��16(�6e   $
��Bold"�6s   �� 5v      -   5         ��Name$ product_name��5v      $��	20,10,0,0q�60   $��1��6C   $��0��6S   $	��700��6`   $��30��6l   $��16(�6y   $��Medium"�6�   $
��Left=�6�   $��2��6�   �� 5x      $��1��6   $��0��6)   $��Purity :��69   $	 
20,10,10,0q�6J   $��16(�6_   $
��Bold"�6m   �� 5y      -   5        $ purity��5y      $��	20,10,0,0q�6*   $��1��6=   $��1��6M   $	��300��6Z   $��30��6f   $��16(�6s   $��Medium"�6�   $
��Left=�6�   �� 5{      $��2��6   $��0��6)   $��Sampling Method :��69   $	 
20,10,10,0q�6S   $��16(�6h   $
��Bold"�6v   �� 5|      -   5         ��Name$ sampling_combobox��5|      $��2��66   $��1��6C   $	��300��6S   $��30��6_   $
��Left=�6k   $��
20,10,10,0q�6�   5~      5      5�      5�      5�      