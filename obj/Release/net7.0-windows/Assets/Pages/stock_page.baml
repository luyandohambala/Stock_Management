   M S B A M L   `   `   `  ���� K  GStock_Management, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:Stock_Management.Assets.PagesStock_Management.Assets.Pages  .    (Stock_Management.Assets.Pages.stock_page   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     =local+clr-namespace:Stock_Management.Assets.Pages        
page style#��[    N� Title$  
stock_Page�� � 	Resources   	BoolToVis��%   &	       �� .����   border style#��[ ���#eff2f7 �� CornerRadius$ 7��._��  � RowDefinitions �� $
��auto ��� $��9* �.+��  � ColumnDefinitions �� $��4* ��� $
��2.5* �.+��� $��20 10 10 10q�$%��Product and Services Management��  Header text#��[ $
��Left=�$��Bottom=�� -   $��Search_Grid��$��Bottom=�$��Stretch=�$��1��.+��� $��	28 0 50 0q�$��Center=����#b0b9c6 J� IsHitTestVisible$ False�� K� ZIndex$ 1��$��	Search...��y���  �� ElementName$ 	TxtSearch�� �� Path$ Text.IsEmpty�	 �� 	Converter#	 [ �� -   $��	TxtSearch��  	searchbox#��[ $��Stretch=�$��Center=��� -   $��clear_button��$	����  search_logo#��[ $��Center=�$��0 2 20 0q�$��Right=����� *
clear_txt2+�� -   $��TxtSearch_button��$y�	Collapsed=�${�False������ $ 	TxtSearch��$
 Text�� $��1�� �� $��4* ��� $
��2.5* �.+��  �� $
��auto ��� 
 � FocusVisualStyle
 Z� .+��� $
��Auto=�$��
30 10 10 5q�.����  �� Orientation$ 
Horizontal=�$	��Top=�$��Stretch=�.+��� -   $��stock_records��$��Stock Records��  category_button#��[ ���� *general_settings_command+�� -   $��sales_records��$��Sales Records��#��[ ���� *user_settings_command+�� -   $��items_grid_border��$��1��
�������$ 10��$��10 10 10 10q�._�&   System.Windows.Controls.DataGrid  -   $��
items_grid��$��10q�  DataGridStyle1#���    DataGridCellStyle1   	CellStyle# �   	 DataGridColumnHeaderStyle1   ColumnHeaderStyle# � 	  
 DataGridRowStyle1   RowStyle# � 
  �� SelectedItem �� *Value2+���� *
Data_lists+   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��   
IsReadOnly$
 True��   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Name+   ElementStyle �� .���  �� Property � �� �� Value$
 Wrap=�  $
 Type��$
 True��$ *  �� *Type+ �� .���  � ��$
 Wrap=�  $ Category��$
 True��$ *  �� *
Category+ �� .���  � ��$
 Wrap=�  $ Quantity��$
 True��$ *  �� *
Quantity+ �� .���  � ��$
 Wrap=�  $
 Cost��$
 True��$ *  �� *Cost+ �� .���  � ��$
 Wrap=��� -	   $��sales_grid_border��$��1��
�������$ 10��$��10 10 10 10q�._�  $��10q�#���  # �  # � 	 # � 
 ���� *Sales_lists_+   $
 Date��$
 True��$ *  �� *Date+ �� .���  � ��$
 Wrap=�  $
 Name��$
 True��$ *  �� *	Item_name+ �� .���  � ��$
 Wrap=�  $ Quantity��$
 True��$ *  �� *Item_quantity+ �� .���  � ��$
 Wrap=�  $ Amount��$
 True��$ *  �� *Amount+ �� .���  � ��$
 Wrap=�  $ Change��$
 True��$ *  �� *Change+ �� .���  � ��$
 Wrap=�  $ Cashier��$
 True��$ *  �� *	Cashier+ �� .���  � ��$
 Wrap=��� $��1��
�������$��10q�$ 15��._�]� $��10q�.+�]� $��
10 10 10 5q�$	��Top=�$	��Top=�.+��� $
��Left=�$��14(�$��10q� �� Padding$ 0 2 0 0q����#4b4b4b$��Product Description��#��[ �� $��	Clear all��  clear_items_button#��[ ���� *
clear_all2+� $��	0 10 0 10q�$��Bottom=�$��Bottom=� �� $��2* ��� $��2* ��� $��2* �.+��� -
   $��add_edit_button��$��Stretch=�$	��Add��$��Center=�  add/edit#��[ ���� *
add_record+�� $��1��$��Stretch=�$��Center=�#��[ ���� *Button_state1+���� *edit_users_command1+�� $��2��$��Stretch=�$��Remove��$��Center=� 
 remove#��[ ���� *remove_record+�� ���#eff2f7$ 7��._��  �� �� $
��2.5* �.+��� $	��Top=�.+��� $
��Left=����#4b4b4b$
��Left=�$��17(�$��
10 20 8 14q�$��Center=�$
��Name��#��[ �� $
��Left=����#4b4b4b$
��Left=�$��17(�$��
10 20 8 14q�$��Center=�$
��Type��#��[ �� $
��Left=����#4b4b4b$
��Left=�$��17(�$��
10 19 8 14q�$��Center=�$��Category��#��[ �� $
��Left=����#4b4b4b$
��Left=�$��17(�$��
10 19 8 14q�$��Center=�$��Quantity��#��[ �� $
��Left=����#4b4b4b$
��Left=�$��17(�$��
10 20 8 14q�$��Center=�$
��Cost��#��[ �� $��1��$	��Top=�.+��� -   $��Name_txtbox��  entrytextbox#��[ ���� *Name+�� -   $��Type_txtbox��#��[ ���� *Type+�� $
��10 8q�$ 7��$��38��
�������._��� -   $��Category_txtbox��$��14(�$��SemiBold"����#4b4b4b$��0q�$��6q� �� *
Category+ �� UpdateSourceTrigger$ PropertyChanged=����� *Category_listItems+�� -   $��Quantity_txtbox��#��[ ���� *
Quantity+�� -   $��Cost_txtbox��#��[ ���� *Cost+�� -   $��checkout_panel_hider��$y�	Collapsed=�$��1��
�������$��10q�$ 15��._�]� $��10q�.+��� $��Section Inactive��$��25(�$
��Wrap=�#��[ $��Center=�$��Center=�