   M S B A M L   `   `   `  ����K  GStock_Management, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:Stock_Management.AssetsStock_Management.Assets  5   	   ,    &Stock_Management.Assets.Internet_Alert   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:Stock_Management.Assets     5   	     � Title$  Internet_Alert��5   	   
������ $	��265��6<   $	��420��6I    � 
ResizeMode$ NoResize=�6U    � WindowStartupLocation$ CenterScreen=�6k    � WindowStyle$
 None=�6�    � AllowsTransparency$
 True��6�   .��5	      ��    border style#��[  6   $��5q�63   
���  ��._�5
   
   �  � RowDefinitions 5      �� 5      $��50 �6    �� 5      .+�5      �  � ColumnDefinitions 5      �� 5      $��2* �6'   �� 5      $
��3.3* �6'   �� 5      $��* �6'   .+�5      �� $��Network��6     Header text#��[ 6+   $��Center=�6P   $��20 0 5 0q�5      �� 5      -   5        $��1��5      
������ $��30��6B   $��Stretch=�6N   $	��Top=�5      6)   �� 5       -   5        $��2��5         clear_items_button#��[ 6)   $��close��6j   $��
5 10 15 10q�6z   $��16(�6�   
���  ��$'��!./Font/#Font Awesome 6 Free Solid)�6�   5!      � 5#      $��1��6   $��10q�6    .+�5$      �� ���#eff2f7 �� CornerRadius$ 10��6.   ._�5%      �� $��10q�6   $ 10��6)   $��Stretch=�6;   $��Stretch=�6W   
�������._�5&      �� $��Stretch=�6%   $��Center=�6A   .+�5'      �� $��1��6(   $%��Your computer is not connected!��65   $��Center=�6\   $��Center=�6y   ���#4b4b4b$��
10 10 10 0q�5(   .   #��[ 6B   $��19(�6g   �� 5*      $��1��6(   $=��7All network related functionality has been deactivated.��65   $
��Wrap=�6t    �� TextAlignment$ Center=�6�   $��Center=�6�   $��Center=�6�   
���  ��$��
10 5 10 10q�5+   *   #��[ 6>   $��14(�6c   � 5-      .+�5.   "   �� $��8q�6,   $
��wifi��67   $��Center=�6C   $��Center=�5/   %   
�������#��[ 6W   $��45(�6|   $'��!./Font/#Font Awesome 6 Free Solid)�50   %   �� 52   "   $��	8 -12 8 0q�6,   $��Exclamation��6?   $��Center=�6R   $��Center=�53   %   
��� E��#��[ 6W   $��55(�6|   $'��!./Font/#Font Awesome 6 Free Solid)�54   %   56      �� 58      $��1��6(   $%��Please reconnect and try again.��65   $
��Wrap=�6\   $ Center=�6p   $��Center=�6�   $��Center=�6�   
���  ��$��
10 5 10 10q�59   .   #��[ 6B   $��14(�6g   5:      5;      5<      5=      5>      5?      5@      