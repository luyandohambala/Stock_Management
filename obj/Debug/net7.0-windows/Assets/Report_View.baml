   M S B A M L   `   `   `  ����K  GStock_Management, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:Stock_Management.AssetsStock_Management.Assets  5   	   )    #Stock_Management.Assets.Report_View   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:Stock_Management.Assets     5   	     � Title$  Report_View��5   	   
������ $	��290��5	   "   $	��430��6/    � 
ResizeMode$ NoResize=�6;    � WindowStartupLocation$ CenterScreen=�6Q    � WindowStyle$
 None=�6v    � AllowsTransparency$
 True��6�   .��5
      ��    border style#��[  6   $��5q�63   
���  ��._�5   
   �  � RowDefinitions 5      �� 5      $��50 �6    �� 5      �� 5      $��50 �6    .+�5      �  � ColumnDefinitions 5      �� 5      $��2* �6'   �� 5      $
��2.5* �6'   .+�5      �� $��Sales Report��6     Header text#��[ 60   $��Center=�6U   $��20 0 5 0q�5      �� 5      -   5        $��1��5      
������ $��30��6B   $��Stretch=�6N   $	��Top=�5      6-   5       � 5"      $��1��6   $��10 20 10 10q�6    .+�5#      �� ���#eff2f7 �� CornerRadius$ 10��6.   ._�5$      �� $��10q�6   $ 10��6)   $��Stretch=�6;   $��Stretch=�6W   
�������._�5%      �� .+�5&      �� $��1��6(   $5��/The Sales Report will now be prepared and sent.��65   $
��Wrap=�6l    �� TextAlignment$ Center=�6�   $��Center=�5'   !   ���#4b4b4b$��
10 30 10 0q�6S   #��[ 6g   $��19(�6�   �� 5)      $��1��6(   $<��6You will be notified once report is successfully sent.��65   $
��Wrap=�6s   $ Center=�6�   $��Center=�5*   !   ���#4b4b4b$��
10 5 10 20q�6S   #��[ 6g   $��14(�6�   5+      5,      5-      5.      � 51      $��2��6    52      �� 53      �� 54      .+�57      �� -   5        $��
Accept_Btn��57      $��Accept��6+   $��Right=�6U     add/edit#��[ 6q   $	��120��6�   �� 59      -   5        $��Not_Ready_Btn��59      $��1��6.   $��Cancel��6>   $
��Left=�6O    
 remove#��[ 6�   $	��120��6�   5;      5=      5>      5?      