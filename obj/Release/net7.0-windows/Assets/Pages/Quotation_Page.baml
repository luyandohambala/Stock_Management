   M S B A M L   `   `   `  ���� K  GStock_Management, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:Stock_Management.Assets.PagesStock_Management.Assets.Pages  2    ,Stock_Management.Assets.Pages.Quotation_Page   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     =local+clr-namespace:Stock_Management.Assets.Pages        
page style#��[    N� Title$  
stock_Page�� � 	Resources   	BoolToVis��%   &	       �� .����   border style#��[ ���#eff2f7 �� CornerRadius$ 7��._��  � RowDefinitions �� $
��auto ��� $��9* �.+��  � ColumnDefinitions �� $��4* ��� $
��2.5* �.+��� $��20 10 10 10q�$#��Quotation/ Invoice Management��  Header text#��[ $
��Left=�$��Bottom=��� $��1�� �� Orientation$ 
Horizontal=�$	��Top=�$��Center=�$	��5 7q�.+��� -   $��Quote��$��	Quotation��  category_button#��[ ���� *quote_command+�� -   $��Invoice��$��Invoice��#��[ ���� *invoice_command+� $��1�� �� $��4* ��� $
��2.5* �.+��  �� $
��auto ���  � FocusVisualStyle Z� .+��� $��1��$��	10 0 10 0q�$	��460��$��Right=�$	��Top=�$ 7��._��  �� $��* ��� $��* �.+�� -   $��
quote_view��$��Stretch=� �� $��3* ��� $��3* �.+��� ���#4b4b4b$��Center=�$��17(�$��SemiBold"�$��	5 13 5 10q�$��Center=�$��Inv/Order Ref.��#��[ �� $��1��$��Center=�$��90��$��10q�$��Right=�  entrytextbox#��[ ���� *Invoice_reference_number+ �� UpdateSourceTrigger$ PropertyChanged=�� $��1��$��Stretch=� �� $��3* ��� $��2* �.+��� -   $��quote_invoice_no�����#4b4b4b$��Right=�$��17(�$��SemiBold"�$��10 13 10 10q�$��Center=�$��	Quote No.��#��[ �� $��1��$��Center=�$��60��$��10q�$
��Left=�#��[ ���� *Quotation_number+$ PropertyChanged=��� $��1��
�������$ 10��$��10 50 10 60q�._�&   System.Windows.Controls.DataGrid  -   $��
items_grid��$��10q�  DataGridStyle2#���    DataGridCellStyle1   	CellStyle# �    DataGridColumnHeaderStyle2	   ColumnHeaderStyle#	 �   	 DataGridRowStyle1
   RowStyle#
 � 	  �� SelectedItem �� *Value3+���� *Quotation_list+   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$	 S/N��   
IsReadOnly$
 True��   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Serial_number+   ElementStyle �� .���  �� Property � �� �� Value$
 Wrap=�  $ Description��$
 True��$ 3*  �� *Description+ �� .���  � ��$
 Wrap=�  $	 Qty��$
 True��$ 70  �� *	Quantity2+ �� .���  � ��$
 Wrap=�  $ 
Unit Price��$
 True��$ 95  �� *
Unit_price+ �� .���  � ��$
 Wrap=�  $ Total��$
 True��$ 95  �� *Row_total_price+ �� .���  � ��$
 Wrap=��� $��1��$��10 10 10 10q�$��40��$��Stretch=�$��Bottom=�$ 7��._��  �� $
��auto ��� $��2* ��� $��3* �.+��� -   $��print_quote��$
��Left=�$	��140��$��Print��$��Center=� 
 add/edit#��[
 ���� *print_quotation+�� $��1�����#4b4b4b$��Right=�$��17(�$��SemiBold"�$��	10 5 10 0q�$��Center=�#��[ ���� *Currency_value+ �� StringFormat$ Total ({0})���� $ 
Horizontal=�$��2��$��Right=�.+��� 
�������$	��5 2q�$ 8��._��� ���#4b4b4b$��Right=�$��17(�$
��Bold"�$��	10 5 10 0q�$��Center=�#��[ ���� *Quot_total_price+$ N2��$ PropertyChanged=��� 
�������$	��5 2q�$ 8��._��� ���#4b4b4b$��Right=�$��17(�$
��Bold"�$��	10 5 10 0q�$��Center=�#��[ ���� *	Tax_value+$ PropertyChanged=��� -   $��
input_view��$y�Visible=�$��1��
�������$��10q�$ 15��._�]� $��10q�.+�]� $��
10 10 10 5q�$	��Top=�$	��Top=�.+��� $
��Left=�$��14(�$��10q� �� Padding$ 0 2 0 0q����#4b4b4b$��Description��#��[ �� $��	Clear all��  clear_items_button#��[ ���� *	clearall3+� $��	0 10 0 10q�$��Bottom=�$��Bottom=� �� $��2* ��� $��2* ��� $��2* �.+��� -   $��add_edit_button��$��Stretch=�$	��Add��$��Center=�#��[
 ���� *add_record2+�� $��1��$��Stretch=�$��Center=�#��[
 ���� *Button_state2+���� *edit_users_command2+�� $��2��$��Stretch=�$��Remove��$��Center=� 
 remove#��[ ���� *remove_record2+�� ���#eff2f7$ 7��._��� .���  �� $��* ��� $��* ��� $��* �.+��  �� �� $
��2.5* �.+�]� $	��Top=�.+��� $	��Top=����#4b4b4b$
��Left=�$��17(�$��
10 20 8 14q�$��Center=�$	��S/N��#��[ �� $	��Top=����#4b4b4b$��WrapWithOverflow=�$
��Left=�$��17(�$��	8 20 0 14q�$��Center=�$��Description��#��[ �� $	��Top=����#4b4b4b$
��Left=�$��17(�$��
10 20 8 12q�$��Center=�$	��Qty��#��[ �� $	��Top=����#4b4b4b$��WrapWithOverflow=�$
��Left=�$��17(�$��
10 20 8 12q�$��Center=�$��
Unit Price��#��[ ]� $��1��$	��Top=�.+��� $	��Top=�#��[ ���� *Serial_number+�� -	   $��description_entry��$	��Top=�#��[ ���� *Description+$ PropertyChanged=��� -
   $��quantity_entry��$	��Top=�#��[ ���� *	Quantity2+$ PropertyChanged=��� -   $��unit_price_entry��$	��Top=�#��[ ���� *
Unit_price+$ PropertyChanged=��� 
���   �$��4q�$��1��$	��Top=�$��
10 20 10 0q�$	��300��� $��1��$��Bottom=�$��	0 40 0 10q�$��Stretch=� �� $
��auto ��� $
��auto �.+�]� $	��Top=�.+��� $	��Top=����#4b4b4b$
��Left=�$��17(�$��
10 10 10 0q�$
��Wrap=�$��Center=�$��Address to:��#��[ �� -   $��
To_textbox�� �� AcceptsReturn$
 True��$��1��$	��100�� �� TextWrapping$
 Wrap=� �� 	IsEnabled$
 True�� �� 
AcceptsTab$
 True��$	��Top=�#��[ ���� *Receiver_text+]� $��1��$	��Top=�.+��� $	��Top=����#4b4b4b$
��Left=�$��17(�$��
10 20 10 0q�$
��Wrap=�$��Center=�$��Delivery Period:��#��[ �� -   $��delivery_textbox��$	��Top=�#��[ ���� *Delivery_text+� $��2��$��Bottom=�$��Center=� �� $
��auto ��� $
��auto �.+��� 
�������$ 3��$��10q�$��Right=�$��Center=�._��� $��1q�$��0q�$��Center=�$��Right=����� *tax_command+ � FocusVisualStyle Z�  d� 	IsChecked �� *	Use_tax+�� $��1�����#4b4b4b$
��Left=�$��17(�$
��0 10q�$��Center=�$��Tick to include VAT��#��[ 