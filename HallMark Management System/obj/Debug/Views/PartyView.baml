   M S B A M L   `   `   `  ����U  QHallMark Management System, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:HallMark_Management_System.Views HallMark_Management_System.Views  5      0    *HallMark_Management_System.Views.PartyView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      @local.clr-namespace:HallMark_Management_System.Views     5      .��5	      � 
�������  � ColumnDefinitions  5
   
   �� 5      $��20 �6   �� 5      $��* �6   �� 5      $��20 �6    � RowDefinitions 5   
   �� 5      $��40 �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $��20 �6   .+�5   
   `� $��0��6   $��1��6#    `� 
Background �#F0DDF4.�5      c� ���#F0DDF4��5      �� 5       �� 
TargetType" c�6   .�5      ��  �� Property �@`�IsLocked �� Value . 6A   �� 5       �@c�OverflowMode$ Never=�69   �� 5       � �� 5       �� 5!   "    �� 
TargetType" c�62   .R�5"   &   a�  K� IsItemsHost . ���#F0DDF46F   5#   #   5%      5&      .@�5(      �� -   5        $��10,0,0,0q�5(      .��5)      �� $%��/Images/toolbargraphics/new.png��6   $��30��6E   $��30��6Q   5*      �� 5+      $��10,0,0,0q�6   .��5,      �� $&�� /Images/toolbargraphics/edit.png��6   $��30��6F   $��30��6R   5-      �� 5.      -   5         ��Name$ btnSave��5.      $��10,0,0,0q�6+   .��5/      �� $&�� /Images/toolbargraphics/save.png��6   $��30��6F   $��30��6R   50      �� 51      -   5        $��10,0,0,0q�51      .��52      �� $)��#/Images/toolbargraphics/discard.png��6   $��30��6I   $��30��6U   53      �� 55      6   �� 56      $��10,0,0,0q�6   .��57      �� $(��"/Images/toolbargraphics/reload.png��6   $��30��6H   $��30��6T   58      �� 59      $��10,0,0,0q�6   .��5:      �� $(��"/Images/toolbargraphics/search.png��6   $��30��6H   $��30��6T   5;      �� 5<      $��10,0,0,0q�6   .��5=      �� $'��!/Images/toolbargraphics/print.png��6   $��30��6G   $��30��6S   5>      �� 5?      6   �� 5@      $��10,0,0,0q�6   .��5A      �� $$��/Images/toolbargraphics/up.png��6   $��30��6D   $��30��6P   5B      �� 5C      $��10,0,0,0q�6   .��5D      �� $'��!/Images/toolbargraphics/right.png��6   $��30��6G   $��30��6S   5E      �� 5F      $��10,0,0,0q�6   .��5G      �� $&�� /Images/toolbargraphics/left.png��6   $��30��6F   $��30��6R   5H      �� 5J      $��10,0,0,0q�6   .��5K      �� $&�� /Images/toolbargraphics/down.png��6   $��30��6F   $��30��6R   5L      �� 5M      6   �� 5N      $��10,0,0,0q�6   .��5O      �� $'��!/Images/toolbargraphics/close.png��6   $��30��6G   $��30��6S   5P      �� 5Q      $��10,0,0,0q�6   .��5R      �� $*��$/Images/toolbargraphics/poweroff.png��6   $��30��6J   $��30��6V   5S      5T      5U      �� 5W   
   $��1��6   $��1��6$   
����  �	 �� Padding$	 20,0,0,0q�6C   $��0,20,0,0q�6V   �� 5X      $�Jewller Master��6   
�������$��18(�6;   $��Medium"�6I   5Y      �� 5[   
   $��0,20,0,0q�5\      $��1q�5]      
��� � �
 �� CornerRadius$
 1��5_      
�������$
��Left=�5a      $	��Top=�5b      $	��900��5c      $	��500��5d      $��1��5e      $��2��5f      ._�5h      �   5i      �� 5j      $
��auto �6'   �� 5k      $
��auto �6'   �� 5l      $
��auto �6'   �� 5m      $
��auto �6'    5p      �� 5q      $
��auto �6$   �� 5r      $
��auto �6$   �� 5s      $
��auto �6$   �� 5t      $
��auto �6$   �� 5u      $
��auto �6$   �� 5v      $
��auto �6$   �� 5w      $
��auto �6$   �� 5x      $
��auto �6$   �� 5y      $
��auto �6$   �� 5z      $
��auto �6$   �� 5{      $
��auto �6$   .+�5~      �� $��0��6   $��0��6)   $��Logo:��69   $	 
20,10,10,0q�6G   $��16(�6\   $
��Bold"�6j   �� 5      -   5         ��Name$
 logo��5      $��	20,10,0,0q�6(   $��1��6;   $��0��6K   $	��300��6X   $��30��6d   $��16(�6q   $��Medium"�6   $
��Left=�6�   �� 5�      $��0��6   $��2��6)   $��IGST :��69   $	 
20,10,10,0q�6H   $��16(�6]   $
��Bold"�6k   �� 5�      -   5        $
��igst��5�      $��0��6'   $��4��64   $
��Left=�6D   $��	0,15,10,0q�6_   �� 5�      $��1��6   $��0��6)   $��Jewller Name :��69   $	 
20,10,10,0q�6P   $��16(�6e   $
��Bold"�6s   �� 5�      -   5        $ jewller_name��5�      $��	20,10,0,0q�60   $��1��6C   $��1��6S   $	��700��6`   $��30��6l   $��16(�6y   $��Medium"�6�   $
��Left=�6�   $��3��6�   �� 5�      $��2��6   $��0��6)   $��	CML/ No :��69   $	 
20,10,10,0q�6K   $��16(�6`   $
��Bold"�6n   �� 5�      -   5        $ cml_no��5�      $��	20,10,0,0q�6*   $��1��6=   $��2��6M   $	��300��6Z   $��30��6f   $��16(�6s   $��Medium"�6�   $
��Left=�6�   �� 5�      $��2��6   $��2��6)   $��Valid Date :��69   $	 
20,10,10,0q�6N   $��16(�6c   $
��Bold"�6q   (  "System.Windows.Controls.DatePicker  5�      -   5        $
��date��5�      $��2��6)   $��4��66   $
��Left=�6F   $��	0,10,10,0q�6a   $	��280��6t   �� 5�      $��3��6   $��0��6)   $��	Address :��69   $	 
20,10,10,0q�6K   $��16(�6`   $
��Bold"�6n   �� 5�      -	   5        $��address��5�       �� TextWrapping$
 Wrap=�6)    �� AcceptsReturn . " �� VerticalScrollBarVisibility$ Visible=�5�      $��	20,10,0,0q�5�      $��1��6)   $��3��69   $��60��5�      $��3��6#   $	��701��67   �� 5�      $��4��6   $��0��6)   $��Mobile :��69   $	 
20,10,10,0q�6J   $��16(�6_   $
��Bold"�6m   �� 5�      -
   5        $ mobile��5�      $��	20,10,0,0q�6*   $��1��6=   $��4��6M   $	��300��6Z   $��30��6f   $��16(�6s   $��Medium"�6�   $
��Left=�6�   �� 5�      $��4��6   $��2��6)   $��State :��69   $	 
20,10,10,0q�6I   $��16(�6^   $
��Bold"�6l   �� 5�      -   5        $ state��5�      $��0,10,0,0q�6)   $��4��6;   $��4��6K   $	��280��6X   $��30��6d   $��16(�6q   $��Medium"�6   $
��Left=�6�   �� 5�      $��5��6   $��0��6)   $��Place Of Supply :��69   $	 
20,10,10,0q�6S   $��16(�6h   $
��Bold"�6v   �� 5�      -   5        $ place_of_supply��5�      $��	20,10,0,0q�63   $��1��6F   $��5��6V   $	��300��6c   $��30��6o   $��16(�6|   $��Medium"�6�   $
��Left=�6�   �� 5�      $��5��6   $��2��6)   $��State Code :��69   $	 
20,10,10,0q�6N   $��16(�6c   $
��Bold"�6q   �� 5�      -   5        $ 
state_code��5�      $��0,10,0,0q�6.   $��4��6@   $��5��6P   $	��280��6]   $��30��6i   $��16(�6v   $��Medium"�6�   $
��Left=�6�   �� 5�      $��6��6   $��0��6)   $��Phone (1) :��69   $	 
20,10,10,0q�6M   $��16(�6b   $
��Bold"�6p   �� 5�      -   5        $ phone_1��5�      $��	20,10,0,0q�6+   $��1��6>   $��6��6N   $	��300��6[   $��30��6g   $��16(�6t   $��Medium"�6�   $
��Left=�6�   �� 5�      $��6��6   $��2��6)   $��Phone (2) :��69   $	 
20,10,10,0q�6M   $��16(�6b   $
��Bold"�6p   �� 5�      -   5        $ phone_2��5�      $��0,10,0,0q�6+   $��4��6=   $��6��6M   $	��280��6Z   $��30��6f   $��16(�6s   $��Medium"�6�   $
��Left=�6�   �� 5�      $��7��6   $��0��6)   $��Phone (3) :��69   $	 
20,10,10,0q�6M   $��16(�6b   $
��Bold"�6p   �� 5�      -   5        $ phone_3��5�      $��	20,10,0,0q�6+   $��1��6>   $��7��6N   $	��300��6[   $��30��6g   $��16(�6t   $��Medium"�6�   $
��Left=�6�   �� 5�      $��7��6   $��2��6)   $��CIN No :��69   $	 
20,10,10,0q�6J   $��16(�6_   $
��Bold"�6m   �� 5�      -   5        $ cin_no��5�      $��0,10,0,0q�6*   $��4��6<   $��7��6L   $	��280��6Y   $��30��6e   $��16(�6r   $��Medium"�6�   $
��Left=�6�   �� 5�      $��8��6   $��0��6)   $��Email :��69   $	 
20,10,10,0q�6I   $��16(�6^   $
��Bold"�6l   �� 5�      -   5        $ email��5�      $��	20,10,0,0q�6)   $��1��6<   $��8��6L   $	��701��6Y   $��30��6e   $��16(�6r   $��Medium"�6�   $
��Left=�6�   $��3��6�   �� 5�      $��9��6   $��0��6)   $��Contact Person :��69   $	 
20,10,10,0q�6R   $��16(�6g   $
��Bold"�6u   �� 5�      -   5        $ contact_person��5�      $��	20,10,0,0q�62   $��1��6E   $��9��6U   $	��701��6b   $��30��6n   $��16(�6{   $��Medium"�6�   $
��Left=�6�   $��3��6�   �� 5�      $��10��6   $��0��6*   $��GST No :��6:   $	 
20,10,10,0q�6K   $��16(�6`   $
��Bold"�6n   �� 5�      -   5        $ gst_no��5�      $��	20,10,0,0q�6*   $��1��6=   $��10��6M   $	��300��6[   $��30��6g   $��16(�6t   $��Medium"�6�   $
��Left=�6�   �� 5�      $��10��6   $��2��6*   $��PAN No :��6:   $	 
20,10,10,0q�6K   $��16(�6`   $
��Bold"�6n   �� 5�      -   5        $ pan_no��5�      $��0,10,0,0q�6*   $��4��6<   $��10��6L   $	��280��6Z   $��30��6f   $��16(�6s   $��Medium"�6�   $
��Left=�6�   5�      5�      5�      5�      