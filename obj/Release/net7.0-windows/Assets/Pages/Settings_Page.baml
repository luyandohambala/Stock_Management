   M S B A M L   `   `   `  ���� K  GStock_Management, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:Stock_Management.Assets.ViewModel!Stock_Management.Assets.ViewModel  1    +Stock_Management.Assets.Pages.Settings_Page   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Alocal/clr-namespace:Stock_Management.Assets.ViewModel        
page style#��[    N� Title$  
stock_Page�� � 	Resources   	BoolToVis��%   &	       �� .����   border style#��[ ���#eff2f7 �� CornerRadius$ 7��._��  � RowDefinitions �� $
��auto ��� $��9* �.+��  � ColumnDefinitions �� $��4* ��� $
��2.5* �.+��� $��20 10 10 10q�$��Settings��  Header text#��[ $
��Left=�$��Bottom=�� -   $��Search_Grid��$��Bottom=�$��Stretch=�$��1��.+��� $��	28 0 50 0q�$��Center=����#b0b9c6 J� IsHitTestVisible$ False�� K� ZIndex$ 1��$��	Search...��y���  �� ElementName$ 	TxtSearch�� �� Path$ Text.IsEmpty�	 �� 	Converter#	 [ �� -   $��	TxtSearch��  	searchbox#��[ $��Stretch=�$��Center=��� -   $��clear_button��$	����  search_logo#��[ $��Center=�$��0 2 20 0q�$��Right=����� *
clear_txt4+�� -   $��TxtSearch_button��$y�	Collapsed=�${�False������ *search_for4+���� $ 	TxtSearch��$
 Text�� $��1��.+��  �� $
��auto ��� 
 � FocusVisualStyle
 Z� .+��� $
��Auto=�$��
30 10 10 5q�.����  �� Orientation$ 
Horizontal=�$	��Top=�$��Stretch=�.+��� -   $��general_settings��$��General��  category_button#��[ ���� *general_settings_command+�� -   $��user_settings��$��Users��#��[ ���� *user_settings_command+�� -   $��general_view��$��10q�$��1��$y�Visible=�.���� .+��� $��10q�$��1q�����  �� 
StartPoint$	 1,0&� �� EndPoint$	 1,1&�.���  � Color$ #4b4b4b�� � Offset$ 1Q�� $	 Red��$ 0Q��� $
��Left=�$��17(�$��20q�$��Center=�$!��Backup and Printer settings��#��[ � $
��Left=�$��10q� �� $
��auto ��� $	��200 ��� $
��auto �.+��� ���#4b4b4b$
��Left=�$��17(�$
��10 0q�$��Center=�$��Email statistics��#��[ �� -   $��email_backup��$��1��  entrytextbox#��[ $��Stretch=�$��Center=����� *Email_backup+ �� UpdateSourceTrigger$ PropertyChanged=��� $��2��$
��Left=�$��17(�$
��10 0q�$��Center=�$��Interval in days��#��[ � $
��Left=�$��10q� �� $
��auto ��� $	��200 ��� $
��auto �.+��� ���#4b4b4b$
��Left=�$��17(�$
��10 0q�$��Center=�$��Backup data��#��[ �� -	   $��backup_data_txtbox��$��1��#��[ $��Stretch=�$��Center=����� *Backup_data+$ PropertyChanged=��� $��2��$
��Left=�$��17(�$
��10 0q�$��Center=�$��Interval in days��#��[ �� $��10q�$��1q����� $	 1,0&�$	 1,1&�.��� $ #4b4b4b��$ 1Q�� $	 Red��$ 0Q�� $
��Left=�$��10q� �� $
��auto ��� $	��200 ��� $
��auto �.+��� ���#4b4b4b$
��Left=�$��17(�$
��10 0q�$��Center=�$��Printer��#��[ �� $��1��#��[ $��Stretch=�$��Center=����� *Printer_name+$ PropertyChanged=��� $��2��$
��Left=�$��17(�$
��10 0q�$��Center=�$��Name of printer��#��[ �� $��10q�$��1q����� $	 1,0&�$	 1,1&�.��� $ #4b4b4b��$ 1Q�� $	 Red��$ 0Q��� $
��Left=�$��17(�$��20q�$��Center=�$��Financem Managment��#��[ � $
��Left=�$��10q� �� $
��auto ��� $	��200 ��� $
��auto �.+��� ���#4b4b4b$
��Left=�$��17(�$
��10 0q�$��Center=�$��Currency��#��[ �� $��1��#��[ $��Stretch=�$��Center=����� *	Currency_+$ PropertyChanged=��� $��2��$
��Left=�$��17(�$
��10 0q�$��Center=�$��Your currency initial(s)��#��[ � $
��Left=�$��10q� �� $
��auto ��� $	��200 ��� $
��auto �.+��� ���#4b4b4b$
��Left=�$��17(�$
��10 0q�$��Center=�$��Value Added Tax��#��[ �� $��1��#��[ $��Stretch=�$��Center=����� *Value_added_tax+$ PropertyChanged=��� $��2��$
��Left=�$��17(�$
��10 0q�$��Center=�$��% VAT��#��[ �� $��10q�$��1q����� $	 1,0&�$	 1,1&�.��� $ #4b4b4b��$ 1Q�� $	 Red��$ 0Q��� $��2��$
��Left=�$��17(�$��20q�$��Center=�$:��4Location of quotation, invoice and receipt templates��#��[ � $
��Left=�$��10q� �� $
��auto ��� $	��200 ��� $
��auto �.+��� ���#4b4b4b$
��Left=�$��17(�$
��10 0q�$��Center=�$��	Quotation��#��[ ��  �� 
IsReadOnly$
 True��$��1��#��[ $��Stretch=�$��Center=����� *Quotation_template+$ PropertyChanged=��� $��2��$��Choose file��  add/edit#��[ � $
��Left=�$��10q� �� $
��auto ��� $	��200 ��� $
��auto �.+��� ���#4b4b4b$
��Left=�$��17(�$
��10 0q�$��Center=�$��Invoice��#��[ �� $��1��$
 True��#��[ $��Stretch=�$��Center=����� *Invoice_template+$ PropertyChanged=��� $��2��$��Choose file��#��[ � $
��Left=�$��10q� �� $
��auto ��� $	��200 ��� $
��auto �.+��� ���#4b4b4b$
��Left=�$��17(�$
��10 0q�$��Center=�$��Receipt��#��[ �� $��1��$
 True��#��[ $��Stretch=�$��Center=����� *Receipt_template+$ PropertyChanged=��� $��2��$��Choose file��#��[ �� $��10q�$��1q����� $	 1,0&�$	 1,1&�.��� $ #4b4b4b��$ 1Q�� $	 Red��$ 0Q�� $	��320�� �� $��2* ��� $��2* �.+��� $
��Save��#��[ ���� *save_settings_command+�� $��1��$��Reset to Default�� 
	 remove#��[	 ���� *reset_settings_command+� -
   $��	user_view��$��1��$
��0 10q�$y�Hidden=� �� $��4* ��� $
��2.5* �.+��  �� $
��auto ��� 
 Z� .+��� $ 
Horizontal=�$	��Top=�$��
30 10 10 5q�$��Stretch=�.+��� -   $��category_all��$	��All��#��[ ���� *	all_users+�� -   $��category_admin��$��Administrators��#��[ ���� *admin_users+�� -   $��category_non_admin��$��Non-Administrators��#��[ ���� *non_admin_users+�� $��1��
�������$ 10��$��10 10 10 10q�$	��Top=�._�&   System.Windows.Controls.DataGrid  $��10q� 
 DataGridStyle1#��� 
   DataGridCellStyle1   	CellStyle# �    DataGridColumnHeaderStyle1   ColumnHeaderStyle# �    DataGridRowStyle1   RowStyle# �   �� SelectedItem �� *Value4+���� *	User_list+   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ 
First Name��   
IsReadOnly$
 True��   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *
First_name+   ElementStyle �� .���  �� Property � �� �� Value$
 Wrap=�  $ 	Last Name��$
 True��$ *  �� *	Last_name+ �� .���  � ��$
 Wrap=�  $ Usename��$
 True��$ *  �� *	User_name+ �� .���  � ��$
 Wrap=�  $ Password��$
 True��$ *  �� *Password_entry+ �� .���  � ��$
 Wrap=�  $ 	Authority��$
 True��$ *  �� *
Authority_+ �� .���  � ��$
 Wrap=��� $��1��
�������$��10q�$ 15��._�]� $��10q�.+�]� $��
10 10 10 5q�$	��Top=�$	��Top=�.+��� $
��Left=�$��Center=�$��16(�$
��Left=�$��5q� �� Padding$ 0 2 0 0q����#4b4b4b$��User details��#��[ �� $��Right=�$��Center=�$��Right=�$��	Clear all��  clear_items_button#��[ ���� *	clearall4+� $��	0 10 0 10q�$��Bottom=�$��Bottom=� �� $��2* ��� $��2* ��� $��2* �.+��� $��Stretch=�$	��Add��$��Center=�#��[ ���� *add_users_command+�� $��1��$��Stretch=�$��Center=�#��[ ���� *Button_state+���� *edit_users_command+�� $��2��$��Stretch=�$��Remove��$��Center=�#��[	 ���� *remove_users_command+�� .���� ���#eff2f7$ 7��._��  �� �� $
��2.5* �.+��� $	��Top=�.+��� $
��Left=����#4b4b4b$
��Left=�$��17(�$��
10 20 0 14q�$��Center=�$��F/ Name��#��[ �� $
��Left=����#4b4b4b$
��Left=�$��17(�$��
10 20 0 14q�$��Center=�$��L/ Name��#��[ �� $
��Left=����#4b4b4b$
��Left=�$��17(�$��
10 20 0 14q�$��Center=�$��U/ Name��#��[ �� $
��Left=����#4b4b4b$
��Left=�$��17(�$��
10 20 0 14q�$��Center=�$��Password��#��[ �� $
��Left=����#4b4b4b$
��Left=�$��17(�$��
10 20 0 14q�$��Center=�$��	Authority��#��[ �� $��1��$	��Top=�.+��� #��[ ���� *
First_name+$ PropertyChanged=��� #��[ ���� *	Last_name+$ PropertyChanged=��� #��[ ���� *	User_name+$ PropertyChanged=��� #��[ ���� *Password_entry+$ PropertyChanged=��� #��[ ���� *
Authority_+$ PropertyChanged=�