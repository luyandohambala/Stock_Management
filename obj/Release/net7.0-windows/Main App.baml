   M S B A M L   `   `   `  ���� K  GStock_Management, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Stock_ManagementStock_Management  3clr-namespace:Stock_ManagementStock_Management  !    Stock_Management.MainWindow   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     .srcclr-namespace:Stock_Management     0localclr-namespace:Stock_Management       � Title$  
MainWindow��
������ $	��620��$
��1000��$	��620��$
��1000�� � WindowStartupLocation$ CenterScreen=� � WindowStyle$
 None=� � AllowsTransparency$
 True�� � 	Resources   Stock_Management.Ticker 
  ticker��%   &	          .����   border style#��[ ._��  � RowDefinitions �� $��20 ��� $��35 ��� $��9* ��� $
��auto �.+��� -   
������ $	��600��$��Center=��� $��1��$��30 0 0 0q�  Header text#��[ $
��Left=�$��Center=����� *Current_user+�� -   $��	Time_Text��$��1��$��18(�$��0 0 30 0q�#��[ $��Right=�$��Bottom=�����  �� Source# [   �� Path$	 Now� �� Mode$ OneWay=�	 �� StringFormat$	 d MMM, yyyy h:mm tt��]� $��2��$��2q�.+��� $
��Left=�#��[ $��	9 20 9 20q����#eff2f7._�]� .+��� -   $��home_button��$	��Top=�$	����  header navigation#��[ �� -   $��sales_button��$	��Top=�$	����#��[ �� -   $��services_button��$	��Top=�$��print��#��[ �� -   $��Stock_button��$	��Top=�$	����#��[ �� -   $��quotation_button��$	��Top=�$��	clipboard��#��[ �� -   $��Settings_button��$	��Top=�$
��gear��#��[ �� -	   $��Logout_button��$��Bottom=�$��Bottom=�$	����  	exit logo#��[ ���� *	close_app+ � -
   
  �Name$
 Display_Frame��  frame style#��[ �� $��3��$��
20 10 0 10q�$��15(�#��[ $
��Left=�$��Center=����� # [  $
 Year�$ OneWay=�$;	 5Copyright © 2023 - {0} Developed by Luyando Hambala.��