   M S B A M L   `   `   `  ����K  GStock_Management, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Stock_ManagementStock_Management  5   P   3clr-namespace:Stock_ManagementStock_Management  5   	   !    Stock_Management.MainWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .srcclr-namespace:Stock_Management     6P   0localclr-namespace:Stock_Management     5   	     � Title$  
MainWindow��5	   	   
������ $	��620��65   $
��1000��6E   $	��620��5
   	   $
��1000��6    � WindowStartupLocation$ CenterScreen=�6#    � WindowStyle$
 None=�6H    � AllowsTransparency$
 True��6[    � 	Resources 5        Stock_Management.Ticker 
  ticker��%   &	          5   
   6   5      .��5      ��   border style#��[ 6   ._�5   
   �  � RowDefinitions 5      �� 5      $��20 �6    �� 5      $��35 �6    �� 5      $��9* �6    �� 5      $
��auto �6    .+�5      �� -   5        
������ $	��600��5   .   $��Center=�6:   6W   �� 5      $��1��6   $��30 0 0 0q�6%     Header text#��[ 6U   $
��Left=�6z   $��Center=�6�   ��67   �� *Current_user+6�   �� 5      -   5        $��	Time_Text��5   %   $��1��6   $��18(�66   $��0 0 30 0q�6D   #��[ 6�   $��Right=�6�   $��Bottom=�6
  ��6V   ��  �� Source# [   �� Path$	 Now� �� Mode$ OneWay=�	 �� StringFormat$	 d MMM, yyyy h:mm tt��6
   � 5       $��2��65     frame style#��[ 6B   ��6   �� *Current_View+6B   �� 5#      $��3��6   $��
20 10 0 10q�6%   $��15(�5$      #��[ 6&   $
��Left=�6K   $��Center=�6f   ��5#   9   �� # [  $
 Year�$ OneWay=�$;	 5Copyright © 2023 - {0} Developed by Luyando Hambala.��5$   f   5%      5&      5'      