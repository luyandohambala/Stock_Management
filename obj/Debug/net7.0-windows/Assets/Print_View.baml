   M S B A M L   `   `   `  ����K  GStock_Management, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:Stock_Management.AssetsStock_Management.Assets  5   	   (    "Stock_Management.Assets.Print_View   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:Stock_Management.Assets     5   	     � Title$  
Print_View��5   	   
������ $	��400��5	   "   $	��595��6/    � 
ResizeMode$ NoResize=�6;    � WindowStartupLocation$ CenterScreen=�6Q    � WindowStyle$
 None=�6v    � AllowsTransparency$
 True��6�   .��5
      ��    border style#��[  6   $��5q�63   
���  ��._�5   
   �  � RowDefinitions 5      �� 5      $��50 �6    �� 5      �� 5      $��50 �6    .+�5      �  � ColumnDefinitions 5      �� 5      $��2* �6'   �� 5      $��3* �6'   �� 5      $��1* �6'   .+�5      �� $��Select Printer��6     Header text#��[ 62   $��Center=�6W   $
��20 0q�5      �� 5      -   5        $��1��5      
������ $	��330��6B   $��30��6N   $��Center=�6Z   $	��Top=�5       61   �� 5"      -   5        $��2��5"      
���  ��$��close��6:   $��20(�6_     clear_items_button#��[ 6m   $
��10 0q�5#      $'��!./Font/#Font Awesome 6 Free Solid)�6(   5$      �� 5&      $��1��6   $>��8The selected printer will be used for printing requests.��6%   ���#4b4b4b$��25 10 10 20q�5'   -   #��[ 6B   $��14(�6g   � 5(      $��1��6   $��10 40 10 10q�6    .+�5)      �� ���#eff2f7 �� CornerRadius$ 10��6.   ._�5*      �� .+�5+      �� $��10q�6!   $ 10��6-   $��Stretch=�6?   
�������._�5,      �� -   5        $��printer_listview��5,   '   $	��150��6?   $��False��5-   %     notification style#��[ 5.   %   $��Center=�5/   %   $��10q�6B   ��5.   Q   �� *Printer_list+��50   "   �� 51   &   .R�52   *   ]� $��10q�64   $��Stretch=�6@   $��Stretch=�6^   .+�53   .   �� $��Bottom=�68   
���  ��$��2q�6f   �� 54   .   $	��Top=�68   
���  ��$��2q�6c   �� 57   .   $��print��68   $��60��6E   $'��!./Font/#Font Awesome 6 Free Solid)�6P   $��10q�6   $
��Left=�58   5   #��[ 6K   $��23(�59   5   $��Center=�6C   ���#4b4b4b6^   �� 5;   .   $
��Wrap=�68   $��-30 10q�6L   #��[ 6\   $��14(�5<   5   $��Center=�6C   ���#4b4b4b��5=   2   `� 5>   6    �� StringFormat$ {0}, Status: {1}��6C   .1�5?   :   �� 	 �� Path$
	 Name�6B   �� 5@   :   $	 Status�6B   5A   7   5C   /   5E   +   5F   '   ��5I   "   �� 5J   &   
 �� 
TargetType"
 ��6,   .�5K   *   ��  �� Property � �� �� Value 5L   .   �� 5M   2    �� 
TargetType" ��6B   .R�5N   6   �� $��Stretch=�6G   $	��500��6e   $��Stretch=�6q   5O   3   5Q   +   �� 5S   *    � ��$ Stretch=�6W   5T   '   5V      5X      5Y      5Z      �� 5\      $��10q�6   $ 10��6%   
�������$��Stretch=�6J   $��Bottom=�6h   ._�5]      ��  �� Orientation$ 
Horizontal=�6!   .+�5^      �� $��8q�6$   $��Selected Printer: ��6/   $��Center=�5_      #��[ 64   $��16(�6Y   �� 5a      $	��0 8q�6$   $��Center=�5b      #��[ 64   $��16(�6Y   ��5a   1   ��  �� ElementName$ printer_listview��$	 SelectedItem.Name�5b   Y   5c      5d      5e      �� 5g      -   5        $��2��5g      $
��Save��6"     add/edit#��[ 6H   $	��150��6j   ��5h      �� *save_printer_command+��5i      �� $ printer_listview��$	 SelectedItem.Name�5j      5k      5l      