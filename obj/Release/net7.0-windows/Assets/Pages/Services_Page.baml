   M S B A M L   `   `   `  ���� K  GStock_Management, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:Stock_Management.Assets.PagesStock_Management.Assets.Pages  1    +Stock_Management.Assets.Pages.Services_Page   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     =local+clr-namespace:Stock_Management.Assets.Pages        
page style#��[    N� Title$  Services_Page�� � 	Resources   	BoolToVis��%   &	       �� .����   border style#��[ ���#eff2f7 �� CornerRadius$ 7��._��  � RowDefinitions �� $
��auto ��� $��9* �.+��  � ColumnDefinitions �� $��4* ��� $��2* �.+��� $��20 10 10 10q�$��Services��  Header text#��[ $
��Left=�$��Bottom=�� -   $��Search_Grid��$��Bottom=�$��Stretch=�$��1��.+��� $��	28 0 50 0q�$��Center=����#b0b9c6 J� IsHitTestVisible$ False�� K� ZIndex$ 1��$��Search by service name��y���  �� ElementName$ 	TxtSearch�� �� Path$ Text.IsEmpty�	 �� 	Converter#	 [ �� -   $��	TxtSearch��  	searchbox#��[ $��Stretch=�$��Center=��� -   $��clear_button��$	����  search_logo#��[ $��Center=�$��0 2 20 0q�$��Right=����� *
clear_txt1+�� -   $��TxtSearch_button��$y�	Collapsed=�${�False������ *search_for1+���� $ 	TxtSearch��$
 Text�� $��1�� �� $��4* ��� $��2* �.+��  �� $
��auto ��� 
 � FocusVisualStyle
 Z� .+��� $
��Auto=�$��	30 7 10 0q�.���� -    ��Name$ cat_grid������ *Category_list1+���� .R���  �� Orientation$ 
Horizontal=�$	��Top=�$��Stretch=����� .R��� $��cat_grid_button��-     category_button#��[ ���� *Button_content+���� $ cat_grid��$ DataContext.search_categ1����� *Button_content+�� $��1��.���� ���� *Items_list1+���� .R��   Services_Page_ViewModel � DataContext# [  � Orientation$ 
Horizontal=�$��Stretch=�$��Stretch=�$��10 10 10 20q� � FocusVisualStyle Z� ���� .R���   item_button#��[ ���� *Button_content+����  �� 
TargetType" ��.R��� $ 10��#��z�� �� Padding$ 10q�._�]� $��Stretch=�$��Stretch=�.+�]� $	��Top=�$	��Top=�$��Stretch=�.+��� $��content_presenter��$��18(�#��z�� �� TextAlignment$
 Left=�$
��Wrap=�$	��Top=�$��	10 15 0 0q�#��[ $
��Left=�$��Center=��� $��button_price_block��$��	10 10 0 0q�#��[ $��14(�$
��Left=�$	��Top=����� *Button_price+�� $��button_type_block��$y�	Collapsed=����� *Button_category+�� $��button_id_block��$y�	Collapsed=����� *	Button_id+�� # [  	 add_to_cart#��[	 ���� *add1+��`�  
 convertor_class `� 	Converter# [
 .1��� $
 Text�$ content_presenter���� $
 Text�$ button_price_block���� $
 Text�$ button_type_block���� $
 Text�$ button_id_block���� $��1��
�������$��10q�$ 15��._�]� $��10q�.+�]� $��
10 10 10 5q�$	��Top=�$	��Top=�.+��� $
��Left=�$��14(�$��10q� �� Padding$ 0 2 0 0q����#4b4b4b$��Service Description��#��[ �� # [ $��	Clear all��  clear_items_button#��[ ���� *
clear_all1+�� # [ $��Stretch=�$��Purchase��$��Bottom=�$��Bottom=�  purchase_button#��[ ���� *purchase_services+�� $��
10 5 10 10q�$��90��$��Stretch=�$��Bottom=�$ 7��$��Bottom=����#eff2f7._�]� $��Stretch=�$��Stretch=�$��	0 10 0 10q�.+�� $��Bottom=�$��0 5 0 0q�.+��� $
��Left=����#4b4b4b$
��Left=�$��17(�$��Normal"�$��15 3 5 0q�$��Center=�$��Received��#��[ �� -   $��purchase_txtbox��$��16(�$��30��$��
100 0 10 0q�$��Center=�$��Bottom=�  entrytextbox#��[ ���� *Amount_given_s+ �� UpdateSourceTrigger$ PropertyChanged=�� $	��Top=�$��0 5 0 10q�.+��� $
��Left=����#4b4b4b$
��Left=�$��17(�$��Normal"�$��15 0 5 0q�$��Bottom=�#��[ ���� *Currency_value1+ �� StringFormat$ Total ({0})��$ PropertyChanged=��� -   $��total_amount_txtblock��# [ $��Right=����#4b4b4b$��Right=�$��17(�$��SemiBold"�$��5 0 15 0q�$��Bottom=�#��[ ���� *Total_price1+$ N2��$ PropertyChanged=��� # [ $��False��  listview style#��[ ���� *Checkout_Lists1+���� .R�]� $��10q�$��Stretch=�$��Stretch=�.+�]� $
��Left=�.+��� $	��Top=�$
��Wrap=�$	��120��#��[ $��14(�$
��Left=�$	��Top=����� *	Item_name+�� $��id_Block��$y�	Collapsed=����� *	Item_id+�� $��Bottom=�$
��Wrap=�#��[ $��14(�$
��Left=�$��Bottom=����� *
Item_price+$ N2��]� $��Right=�$��Right=�$��Center=�.+��� # [   items_quantity_minus#��[ $
��Left=�$
��Left=�$��Center=����� *	reduce1+���� $ id_Block��$
 Text��� # [   items_quantity_plus#��[ $��Right=�$��Right=�$��Center=����� *	increase1+���� $ id_Block��$
 Text��� $��5q�#��[ $��14(�$��Center=�$��Center=����� *
Quantity+