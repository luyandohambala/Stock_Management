   M S B A M L   `   `   `  ����K  GStock_Management, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:Stock_Management.Assets.PagesStock_Management.Assets.Pages  5      2    ,Stock_Management.Assets.Pages.Quotation_Page   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      =local+clr-namespace:Stock_Management.Assets.Pages     5         
page style#��[  5        N� Title$  
stock_Page��5	       � 	Resources 5        	BoolToVis��%   &	       �� 5   
   6'   5      .��5      ��   border style#��[ 6   ���#eff2f7 �� CornerRadius$ 7��6H   ._�5   
   �  � RowDefinitions 5      �� 5      $
��auto �6    �� 5      $��9* �6    .+�5      �   Quotation_Page_ViewModel � DataContext# [ 6    � ColumnDefinitions 5      �� 5      $��4* �6'   �� 5      $
��2.5* �6'   .+�5      �� $��20 10 10 10q�6   $#��Quotation/ Invoice Management��61     Header text#��[ 6V   $
��Left=�6{   $��Bottom=�6�   �� 5"      $��1��6    �� Orientation$ 
Horizontal=�6-   $	��Top=�6F   $��Center=�6^   $	��5 7q�6{   .+�5#      �� -   5        $��Quote��5#      $��quote��5$      $��	Quotation��5%        category_button#��[ 61   ��5#   >   �� *change_table_State+5%   1   �� 5&      -   5        $��Invoice��5&      $��invoice��5'      $��Invoice��5(      #��[ 6/   ��5&   B   �� *change_table_State+5(   /   5)      5*      � 5-      $��1��6    5.      �� 5/      $��4* �6'   �� 50      $
��2.5* �6'   .+�55      � # [ 6    56      �� 57      $
��auto �6(   �� 58       � FocusVisualStyle 6(   Z� .+�5<      �� $��1��6   $��	10 0 10 0q�6*   $	��460��6=   $��Right=�6I   $	��Top=�6e   $ 7��6}   ._�5=      �  5>      �� 5?   "   $��* �63   �� 5@   "   $��* �63   .+�5C      � -   5        $��
quote_view��5C   #   $��Stretch=�65    5D   "   �� 5E   &   $��3* �67   �� 5F   &   $��3* �67   .+�5I   "   �� ���#4b4b4b$��Center=�6A   $��17(�6^   $��SemiBold"�6l   $��	5 13 5 10q�6�   $��Center=�6�   $��Inv/Order Ref.��5J   %   #��[ 6;   �� 5M   "   $��1��6*   $��Center=�6:   $��90��6�   $��10q�6�   $��Right=�6�     entrytextbox#��[ 6�   ��6U   �� *Invoice_reference_number+ �� UpdateSourceTrigger$ PropertyChanged=�6�   5N      � 5P      $��1��6#   $��Stretch=�63    5Q   "   �� 5R   &   $��3* �67   �� 5S   &   $��2* �67   .+�5V   "   �� -   5        $��quote_invoice_no��5V   ,   ���#4b4b4b$��Right=�6Y   $��17(�6u   $��SemiBold"�6�   $��10 13 10 10q�6�   $��Center=�6�   $��	Quote No.��5W   )   #��[ 6:   �� 5Z   "   $��1��6*   $��Center=�6:   $��60��6�   $��10q�6�   $
��Left=�6�   #��[ 6�   ��6U   �� *Quotation_number+$ PropertyChanged=�6�   5[      5\      5]      �� 5_      $��1��6   
�������$ 10��6=   $��10 50 10 60q�6O   ._�5`      &   System.Windows.Controls.DataGrid  -   5        $��
items_grid��5`   #   $��10q�5a   H     DataGridStyle2#���  5b   !     DataGridCellStyle1	   	CellStyle#	 �  6J    	 DataGridColumnHeaderStyle2
   ColumnHeaderStyle#
 � 	 5c   !    
 DataGridRowStyle1   RowStyle# � 
 6b    �� SelectedItem 5`   5   �� *Value3+��5a   !   �� *Quotation_list+   Columns 5d      0  *System.Windows.Controls.DataGridTextColumn  5g   "   ,  &System.Windows.Controls.DataGridColumn   Header$	 S/N��66      
IsReadOnly$
 True��6e      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6w   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6C   �� *Serial_number+   ElementStyle 5h   &   �� 5i   *   .�5j   .   ��  �� Property � �� �� Value$
 Wrap=�6W   5k   +   5m   #     5p   "   $ Description��66   $
 True��6k   $ 3* 6}    6K   �� *Description+ 5q   &   �� 5r   *   .�5s   .   ��  � ��$
 Wrap=�6W   5t   +   5v   #     5y   "   $	 Qty��66   $
 True��6a   $ 70 6s    6C   �� *	Quantity2+ 5z   &   �� 5{   *   .�5|   .   ��  � ��$
 Wrap=�6W   5}   +   5   #     5�   "   $ 
Unit Price��66   $
 True��6i   $ 95 6{    6J   �� *
Unit_price+ 5�   &   �� 5�   *   .�5�   .   ��  � ��$
 Wrap=�6W   5�   +   5�   #     5�   "   $ Total��66   $
 True��6i   $ 95 6{    6E   �� *Row_total_price+ 5�   &   �� 5�   *   .�5�   .   ��  � ��$
 Wrap=�6W   5�   +   5�   #   5�      5�      �� 5�      $��1��6   $��10 10 10 10q�6*   $��40��6?   $��Stretch=�6K   $��Bottom=�6i   $ 7��6�   ._�5�      �  5�      �� 5�   "   $
��auto �63   �� 5�   "   $��2* �63   �� 5�   "   $��3* �63   .+�5�      �� -   5        $��print_quote��5�   %   $
��Left=�68   $	��140��6S   $��Print��6_   $��Center=�6�     add/edit#��[ 6�   ��6o   �� *print_quotation+6�   �� 5�      $��1��6(   ���#4b4b4b$��Right=�6M   $��17(�6i   $��SemiBold"�5�   (   $��	10 5 10 0q�6>   $��Center=�6Q   #��[ 6�   ��6l   �� *Currency_value+ �� StringFormat$ Total ({0})��6�   �� 5�      $ 
Horizontal=�6)   $��2��6B   $��Right=�6R   .+�5�   "   �� 
�������$	��5 2q�6<   $ 8��6I   ._�5�   &   �� ���#4b4b4b$��Right=�6E   $��17(�6a   $
��Bold"�5�   1   $��	10 5 10 0q�6C   $��Center=�6V   #��[ 5�   -   ��5�   0   �� *Quot_total_price+$ N2��$ PropertyChanged=�5�   -   5�   #   �� 5�   "   
�������$	��5 2q�6<   $ 8��6I   ._�5�   &   �� ���#4b4b4b$��Right=�6E   $��17(�6a   $
��Bold"�5�   %   $��	10 5 10 0q�67   $��Center=�6J   #��[ 5�   %   ��5�   e   �� *	Tax_value+$ PropertyChanged=�5�   %   5�   #   5�      5�      5�      5�      �� 5�      -   5        $��
input_view��5�      # [ 6+   $y�Visible=�6c   $��1��6x   
�������$��10q�6�   $ 15��6�   ._�5�      ]� $��10q�6    .+�5�      � $��
10 10 10 5q�6   $	��Top=�63   $	��Top=�6K    5�      �� 5�   "   $��* �63   �� 5�   "   $��* �63   �� 5�   "   $��* �63   .+�5�      �� $
��Left=�6(   $��14(�6C   $��
0 10 10 10q�6Q    �� Padding$ 0 2 0 0q�5�   (   ���#4b4b4b$��Description��6O   #��[ 6b   �� 5�      $��1��6%   $��Right=�65   $��Clear Table��6Q     clear_items_button#��[ 5�   M   ��6%   �� *clear_table_command+6M   �� 5�      $��2��6%   $��	Clear all��65   $��Center=�6I   #��[ 5�   C   ��6%   �� *	clearall3+6C   5�      � 5�      $��	0 10 0 10q�6   $��Bottom=�62   $��Bottom=�6J    5�      �� 5�   "   $��2* �63   �� 5�   "   $��2* �63   �� 5�   "   $��2* �63   .+�5�      �� -   5        $��add_edit_button��5�   %   $��Stretch=�6Z   $	��Add��6x   $��Center=�6�   #��[ 6�   ��6�   �� *add_record2+6�   �� 5�      $��1��6%   $��Stretch=�65   $��Center=�5�   %   #��[ 6@   ��5�   S   �� *Button_state2+��6u   �� *edit_users_command2+5�   @   �� 5�      $��2��6%   $��Stretch=�65   $��Remove��6S   $��Center=�6�    
 remove#��[ 6�   ��6d   �� *remove_record2+6�   5�      �� 5�      ���#eff2f7$ 7��66   ._�5�      �� .��5�   "   �  5�   &   �� 5�   *   $��* �68   �� 5�   *   $��* �68   �� 5�   *   $��* �68   .+�5�   &   �  5�   *   �� 5�   .   �� 5�   .   $
��2.5* �6?   .+�5�   *   ]� $	��Top=�64   .+�5�   .   �� $	��Top=�68   ���#4b4b4b$
��Left=�6b   $��17(�6}   $��
10 20 8 14q�6�   $��Center=�6�   $	��S/N��6�   #��[ 5�   5   �� 5�   .   $	��Top=�68   ���#4b4b4b$��WrapWithOverflow=�6b   $
��Left=�6�   $��17(�6�   $��	8 20 0 14q�6�   $��Center=�6�   $��Description��6�   #��[ 5�   5   �� 5�   .   $	��Top=�68   ���#4b4b4b$
��Left=�6b   $��17(�6}   $��
10 20 8 12q�6�   $��Center=�6�   $	��Qty��6�   #��[ 5�   5   �� 5�   .   $	��Top=�68   ���#4b4b4b$��WrapWithOverflow=�6b   $
��Left=�6�   $��17(�6�   $��
10 20 8 12q�6�   $��Center=�6�   $��
Unit Price��6�   #��[ 5�   5   5�   +   ]� 5�   *   $��1��64   $	��Top=�6D   .+�5�   .   �� $	��Top=�66   #��[ 6j   ��6K   �� *Serial_number+6j   �� 5�   .   -	   5        $��description_entry��5�   6   $	��Top=�6O   #��[ 5�   5   ��5�   d   �� *Description+$ PropertyChanged=�5�   5   �� 5�   .   -
   5        $��quantity_entry��5�   6   $	��Top=�6u   #��[ 5�   u   ��65   �� *	Quantity2+$ PropertyChanged=�6u   �� 5�   .   -   5        $��unit_price_entry��5�   6   $	��Top=�6y   #��[ 5�   v   ��65   �� *
Unit_price+$ PropertyChanged=�6v   5   +   5  '   �� 5  &   
���   �$��4q�6D   $��1��6X   $	��Top=�6e   $��
10 20 10 0q�6}   $	��300��6�   � 5  &   $��1��6+   $��Bottom=�68   $��	0 40 0 10q�6S   $��Stretch=�6f    5  *   �� 5  .   $
��auto �6<   �� 5	  .   $
��auto �6<   .+�5  *   ]� $	��Top=�64   .+�5  .   �� $	��Top=�68   ���#4b4b4b$
��Left=�5  5   $��17(�6P   $��
10 10 10 0q�6^   $
��Wrap=�6r   $��Center=�5  8   $��Address to:��6S   #��[ 6f   �� 5  .   -   5        $��
To_textbox��5  -    �� AcceptsReturn$
 True��5  6   $��1��6K   $	��100��6[    �� TextWrapping$
 Wrap=�6h    �� 	IsEnabled$
 True��6|    �� 
AcceptsTab$
 True��6�   $	��Top=�5  ?   #��[ 6s   ��6T   �� *Receiver_text+6s   5  +   ]� 5  *   $��1��64   $	��Top=�6A   .+�5  .   �� $	��Top=�68   ���#4b4b4b$
��Left=�5  5   $��17(�6P   $��
10 20 10 0q�6^   $
��Wrap=�6r   $��Center=�5  5   $��Delivery Period:��6P   #��[ 6h   �� 5  .   -   5        $��delivery_textbox��5  6   $	��Top=�6N   #��[ 6�   ��6c   �� *Delivery_text+6�   5  +   5  '   � 5  &   $��2��6+   $��Bottom=�68   $��Center=�6S    5   *   �� 5!  .   $
��auto �6?   �� 5"  .   $
��auto �6?   .+�5%  *   �� 
�������$ 3��6D   $��10q�6U   $��Right=�6a   $��Center=�6}   ._�5&  .   �� $��1q�6s   $��0q�6�   $��Center=�6�   $��Right=�6�   ��67   �� *tax_command+ � FocusVisualStyle 6W   Z�  d� 	IsChecked 6~   �� *	Use_tax+6�   5'  +   �� 5)  *   $��1��64   ���#4b4b4b$
��Left=�6Y   $��17(�6t   $
��0 10q�6�   $��Center=�6�   $��Tick to include VAT��6�   #��[ 5*  -   5+  '   5,  #   5-     5.     50     51     53     55     56     57     