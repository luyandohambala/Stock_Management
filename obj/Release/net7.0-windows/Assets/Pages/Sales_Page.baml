   M S B A M L   `   `   `  ����   Stock_Management.    (Stock_Management.Assets.Pages.Sales_Page   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     @d2http://schemas.microsoft.com/expression/blend/2008     R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006        
page style#��[    N� Title$  
Sales_Page�� � 	Resources   	BoolToVis��%   &	       �� .����   border style#��[ ���#eff2f7 �� CornerRadius$ 7��._��  � RowDefinitions �� $
��auto ��� $��9* �.+��  � ColumnDefinitions �� $��4* ��� $��2* �.+��� $��20 10 10 10q�$��Product Sales��  Header text#��[ $
��Left=�$��Bottom=�� -   $��Search_Grid��$��Bottom=�$��Stretch=�$��1��.+��� $��	28 0 50 0q�$��Center=����#b0b9c6 J� IsHitTestVisible$ False�� K� ZIndex$ 1��$��Search by item name��y���  �� ElementName$ 	TxtSearch�� �� Path$ Text.IsEmpty�	 �� 	Converter#	 [ �� -   $��	TxtSearch��  	searchbox#��[ $��Stretch=�$��Center=��� -   $��clear_button��$	����  search_logo#��[ $��Center=�$��0 2 20 0q�$��Right=����� *	clear_txt+�� -   $��TxtSearch_button��$y�	Collapsed=�${�False������ *
search_for+���� $ 	TxtSearch��$
 Text�� $��1�� �� $��4* ��� $��2* �.+��  �� $
��auto ��� 
 � FocusVisualStyle
 Z� .+��� $
��Auto=�$��	30 7 10 0q�.���� -    ��Name$ cat_grid������ *Category_list+���� .R���  �� Orientation$ 
Horizontal=�$	��Top=�$��Stretch=����� .R��� $��cat_grid_button��-     category_button#��[ ���� *Button_content+���� $ cat_grid��$ DataContext.search_categ����� *Button_content+�� $��1��.���� ���� *
Items_list+���� .R��   Sales_Page_ViewModel � DataContext# [  � Orientation$ 
Horizontal=�$��Stretch=�$��Stretch=�$��10 10 10 20q� � FocusVisualStyle Z� ���� .R���   item_button#��[ ���� *Button_content+�� $��1��
�������$��10q�$ 15��._�]� $��10q�.+�]� $��
10 10 10 5q�$	��Top=�$	��Top=�.+��� $
��Left=�$��14(�$��10q� �� Padding$ 0 2 0 0q����#4b4b4b$��Item Description��#��[ �� # [ $��	Clear all�� 	 clear_items_button#��[	 ���� *	clear_all+�� # [ $��Stretch=�$��Purchase��$��Bottom=�$��Bottom=� 
 purchase_button#��[
 ���� *purchase_items+�� $��
10 5 10 10q�$��90��$��Stretch=�$��Bottom=�$ 7��$��Bottom=����#eff2f7._�]� $��Stretch=�$��Stretch=�$��	0 10 0 10q�.+�� $��Bottom=�$��0 5 0 0q�.+��� $
��Left=����#4b4b4b$
��Left=�$��17(�$��Normal"�$��15 3 5 0q�$��Center=�$��Received��#��[ �� -   $��purchase_txtbox��$��16(�$��30��$��
100 0 10 0q�$��Center=�$��Bottom=�  entrytextbox#��[ ���� *Amount_given+ �� UpdateSourceTrigger$ PropertyChanged=�� $	��Top=�$��0 5 0 10q�.+��� $
��Left=����#4b4b4b$
��Left=�$��17(�$��Normal"�$��15 0 5 0q�$��Bottom=�#��[ ���� *Currency_value+ �� StringFormat$ Total ({0})��$ PropertyChanged=��� -   $��total_amount_txtblock��# [ $��Right=����#4b4b4b$��Right=�$��17(�$��SemiBold"�$��5 0 15 0q�$��Bottom=�#��[ ���� *Total_price+$ N2��$ PropertyChanged=��� # [ $��False��  listview style#��[ ���� *Checkout_Lists+