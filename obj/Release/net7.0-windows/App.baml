   M S B A M L   `   `   `  ���� K  GStock_Management, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:Stock_Management.Assets.ViewModel!Stock_Management.Assets.ViewModel  M+clr-namespace:Stock_Management.Assets.PagesStock_Management.Assets.Pages  a ]PresentationFramework.Aero, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35gJclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.AeroMicrosoft.Windows.Themes     Stock_Management.App   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Alocal/clr-namespace:Stock_Management.Assets.ViewModel     >local1+clr-namespace:Stock_Management.Assets.Pages     \themeJclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero       �� 	Resources  <  6Stock_Management.Assets.ViewModel.Sales_Page_ViewModel   Sales_Page_ViewModel?  9Stock_Management.Assets.ViewModel.Services_Page_ViewModel  Services_Page_ViewModel<  6Stock_Management.Assets.ViewModel.stock_page_viewmodel  stock_page_viewmodel@  :Stock_Management.Assets.ViewModel.Quotation_Page_ViewModel  Quotation_Page_ViewModel?  9Stock_Management.Assets.ViewModel.Settings_Page_ViewModel  Settings_Page_ViewModel7  1Stock_Management.Assets.ViewModel.Convertor_Class  convertor_class.   (Stock_Management.Assets.Pages.Sales_Page  
sales_page  border style �� 
TargetType �� Property �� Value  
page style 	 frame style �� 
TargetType �� CornerRadius 
 Header text �� 
StartPoint �� EndPoint � Color	 � Offset  header navigation
 �� Triggers P� Property P� Value N� EnterActions �� TargetProperty	 W� To g� Duration N� ExitActions  	exit logo �� BasedOn �� Triggers  dashboard_button_style �� Padding	 �� To  	Icon_Font  	searchbox ��Name  entrytextbox  purchase_button g� AutoReverse �� From W� From  add_to_cart  items_quantity_plus  items_quantity_minus  item_button �� TextAlignment � DataContext `� 	Converter �� Path �� ElementName  category_button  ScrollThumbs �Name  ��Name! �� 
TargetName" ]�Name# ]� Thumb$ n�Name% ]� IncreaseRepeatButton& ��Name' J� Opacity( ]� DecreaseRepeatButton) P� 
SourceName* g� RepeatBehavior+ �� Angle  listview style, �� StringFormat- �� UpdateSourceTrigger  clear_items_button  search_logo  add/edit 
 remove. �� 
ResourceId/ �� TypeInTargetAssembly&   System.Windows.Controls.DataGrid0 ��Name1 J� SnapsToDevicePixels2 �Name3 � Points4 �� Stretch  DataGridStyle15	  /System.Windows.Controls.DataGridLengthConverter5 � ColumnDefinitions6 � RowDefinitions7   SelectAllCommand7
  1System.Windows.Controls.DataGridHeadersVisibility
8 
  All9 �� ConverterParameter!:   HeadersVisibilityConverter; �� 	Converter< �� RelativeSource= �� AncestorTypeG  ASystem.Windows.Controls.Primitives.DataGridColumnHeadersPresenter>  Name? 
  Column@ ��NameA �� CanContentScrollB ��NameC �� ScrollableHeightD � MaximumE �� OrientationF �� ViewportHeightG �� ViewportSize*H �� #ComputedVerticalScrollBarVisibilityI � ValueJ �� ModeK �� ModeL �� ScrollableWidthM �� ViewportWidth,N �� %ComputedHorizontalScrollBarVisibilityO ]� 
ConditionsP �� PropertyQ �� Value  DataGridStyle2  DataGridCellStyle1*  $System.Windows.Controls.DataGridCell   ColumnHeaderGripperStyle ! DataGridColumnHeaderStyle1=  7System.Windows.Controls.Primitives.DataGridColumnHeader3  -Microsoft.Windows.Themes.DataGridHeaderBorderR   	IsPressedS J� IsMouseOverT   	IsHoveredU   CanUserSortV   IsClickableW   SortDirectionX   SortDirectionY   SeparatorVisibilityZ   SeparatorVisibility[   SeparatorBrush\   SeparatorBrush " DataGridColumnHeaderStyle2 # DataGridRowStyle1)  #System.Windows.Controls.DataGridRow?  9System.Windows.Controls.Primitives.SelectiveScrollingGrid?  9System.Windows.Controls.Primitives.DataGridCellsPresenter]   
ItemsPanelA  ;System.Windows.Controls.Primitives.DataGridDetailsPresenter^   DetailsVisibility$_   SelectiveScrollingOrientation;  5System.Windows.Controls.SelectiveScrollingOrientation`   Vertical#a   RowDetailsScrollingConverter:  4System.Windows.Controls.Primitives.DataGridRowHeader
b 
  Row��%�F  &	        &	      &	 
     &	      &	      &	      &	      &	 #     &	 k     &		     &	
 �    &	 �    &	 *    7  &	 �    &	 �    &	 �    &	 	    &	 �    &	 �    7  &	 D    &	 �    7  &	 �    7 
 7 
 7   7  7  &	 �    &	 K     '�� �!    7  &	 *    7 
 7 
 7   7  7   7  7  &	 �-    &	 �/    7  &	 �0    7  &	 �0    7  (�� A3    $". DataGridSelectAllButtonStyle��"/  )&	 �4    &	 x<    7  &	 �<    &	  �=    &	! +>    7   7   &	" 1@    7 ! &	# �@                  �� " ��.���  �@��CornerRadius$ 15����  � ��
 ������� " N�.���  � ��$
 auto����  � ��$ Stretch=���  � ��$ Stretch=���  � ��$
 auto����  �@N�
Background
 ���� �� "  �.���  �@ �NavigationUIVisibility$ Hidden=���  �@�FocusVisualStyle Z� ��  � �� �#eff2f7��  � ��$ 
5 20 10 20q���  � �� �� "  �.R��� #��z��$ 7��._��� $��Stretch=�$��Stretch=��� " ��.���  � ��
 ���� ��  � �� �� $	 0,0&�$	 1,1&�.��� $ #4b4b4b��$	 1Q�� $	 Red��$	 0Q���  � ��$ Micro Sans Serif)���  � ��$ 25(���  � ��$ SemiBold"��� " ��.���  � ��
 ���� ��  � ��$ 5 7 5 0q���  �@�FocusVisualStyle Z� ��  � ��
 �������  � ��$. (./Assets/Font/#Font Awesome 6 Free Solid)���  � ��$ 20(���  � ��$ SemiBold"���  � �� �� " ��.R��� #��z��$��40��$	��5 5q�$��40��._��� $��Center=�$��Center=�
 P�  �@J�IsMouseOver$
 True��. ���  � �� �� $	 0,0&�$	 1,1&�.��� $	 Red��$	 .2Q�� $ Maroon��$	 .8Q� �� .���� .��W� $ FontSize� 35$ 0:0:.05D� �� .���� .��W� $ FontSize� 20$ 0:0:.05D��� " ��8    P�  �@J�IsMouseOver$
 True��. ���  � ��
 �  ��P�  �@J�IsMouseCaptured$
 True��. ���  � ��
 �  ���� " ��.���  � ��$ 16(���  � ��$ SemiBold"���  � ��$ 2q���  � ��$	 166����  � ��$ 	20 0 20 0q���  � ��$	 150����  � �� �� $	 0,0&�$	 1,1&�.��� $ White��$	 .4Q�� $ White��$	 .4Q���  � �� �� $	 0,0&�$	 1,1&�.��� $ #4b4b4b��$	 0Q�� $	 Red��$	 1Q���  �@�FocusVisualStyle Z� ��  � �� �� " ��.R��� $��dashboard_border��#��z��$ 15��$ 15q�._��� $��Center=�$��Center=� P�  �@J�IsMouseOver$
 True��. ���  � ��
 �������  � ��$ 0q� �� .���� .��W� $ Width� 190$ 0:0:.2D�W� $ Height� 170$ 0:0:.2D�W� $ FontSize� 20$ 0:0:.2D��� $U O(Button.Background).(LinearGradientBrush.GradientStops)[0].(GradientStop.Color)� #4b4b4b$ 0:0:.2D��� $U O(Button.Background).(LinearGradientBrush.GradientStops)[1].(GradientStop.Color)� Red$ 0:0:.2D�W� $V P(Button.Background).(LinearGradientBrush.GradientStops)[0].(GradientStop.Offset)� .2$ 0:0:.4D�W� $V P(Button.Background).(LinearGradientBrush.GradientStops)[1].(GradientStop.Offset)� 1$ 0:0:.4D� �� .���� .��W� $ Width� 166$ 0:0:.2D�W� $ Height� 150$ 0:0:.2D�W� $ FontSize� 16$ 0:0:.2D��� $U O(Button.Background).(LinearGradientBrush.GradientStops)[0].(GradientStop.Color)�	 White$ 0:0:.4D��� $U O(Button.Background).(LinearGradientBrush.GradientStops)[1].(GradientStop.Color)�	 White$ 0:0:.4D�W� $V P(Button.Background).(LinearGradientBrush.GradientStops)[0].(GradientStop.Offset)� .5$ 0:0:.4D�W� $V P(Button.Background).(LinearGradientBrush.GradientStops)[1].(GradientStop.Offset)� .5$ 0:0:.4D��� " ��.���  � ��$. (./Assets/Font/#Font Awesome 6 Free Solid)���  � ��$ 14(���  � �� �� $	 0,0&�$	 1,1&�.��� $ #4b4b4b��$	 0Q�� $	 Red��$	 1Q���  � ��
 ���� �� " ��.���  � ��$
 10 5q���  � �� �#b0b9c6��  � ��$ Micro Sans Serif)���  � ��$ 14(���  � ��$ SemiBold"���  � ��$ 40����  � ��$ 
16 12 35 0q���  � ��$ 0q���  � �� �� $	 0,0&�$	 1,1&�.��� $ #4b4b4b��$	 0Q�� $	 Red��$	 1Q���  � ��
 �������  � �� �� " ��.R��� $��Border1��$ 8��#��z��#��z��#��z��._��� $ PART_ContentHost��$|�False��$��Hidden=�$��Hidden=�
 P�  �@J�IsMouseOver$
 True��. ���  � ��$ 1q�P�  �@J�IsKeyboardFocused$
 True��. ���  � �� �#4b4b4b��  � ��$ 1q��� " ��.���  � ��$ 10q���  � �� �#4b4b4b��  � ��$ Micro Sans Serif)���  � ��$ 16(���  � ��$ SemiBold"���  � ��$ 35����  � ��$ 0q���  � ��$	 5 7q���  � ��
 �������  � ��$ Stretch=���  � ��$ Center=���  � �� �� " ��.R��� $��Border1��$ 8��#��z��#��z��#��z��._��� $ PART_ContentHost��$|�False��$��Hidden=�$��Hidden=��� " ��.���  � ��$ 16(���  � ��$ SemiBold"���  � ��$ Center=���  � ��$ 1q���  � ��$
 10 0q���  � ��$
 auto����  � ��$ 40����  �@�FocusVisualStyle Z� ��  � �� �� $	 0,0&�$	 1,1&�.��� $ White��$	 .4Q�� $ White��$	 .4Q���  � �� �� $	 0,0&�$	 1,1&�.��� $ #4b4b4b��$	 0Q�� $	 Red��$	 1Q���  � �� �� " ��.R��� $��dashboard_border��#��z��$ 15��#��z��#��z��$ 5q�._��� $��Center=�$��Center=� P�  � ��$
 True�� �� .���� .���� $U O(Button.Background).(LinearGradientBrush.GradientStops)[0].(GradientStop.Color)� #4b4b4b$ 0:0:.25D�$
 True���� $U O(Button.Background).(LinearGradientBrush.GradientStops)[1].(GradientStop.Color)� DarkRed Red$ 0:0:.25D�$
 True��W� $V P(Button.Background).(LinearGradientBrush.GradientStops)[0].(GradientStop.Offset)� .4 0$ 0:0:.25D�$
 True��W� $V P(Button.Background).(LinearGradientBrush.GradientStops)[1].(GradientStop.Offset)� .6 1$ 0:0:.25D�$
 True��P�  �@J�IsMouseOver$
 True��. ���  � �� �� $	 0,0&�$	 1,1&�.��� $ #4b4b4b��$	 0Q�� $	 Red��$	 1Q���  � ��$ 0q���  � ��
 ������� " ��8   .���  � ��$	 add����  � ��$ Bottom=���  � ��$ Bottom=���  � ��$ Stretch=��� " ��.���  � ��
 ���� ��  � ��
 �  ����  � ��$. (./Assets/Font/#Font Awesome 6 Free Solid)���  � ��$	 add����  � ��$ 30����  � ��$ 30����  � �� �� " ��.R��� #��z��$ 50��#��z��#��z��$��1q�#��z��._��� $��Center=�$��Center=� P�  �@J�IsMouseOver$
 True��. ���  � �� �� $	 1,0&�$	 1,1&�.��� $ #4b4b4b��$	 0Q�� $	 Red��$	 1Q���  � ��
 �����P�  �@J�IsMouseCaptured$
 True��. ���  � �� �� $	 1,0&�$	 1,1&�.��� $ #4b4b4b��$	 0Q�� $ DarkRed��$	 1Q���  � ��
 ������� " ��8   .���  � ��$ minus���� " ��.���  � ��$ SemiBold"���  � ��$ Micro Sans Serif)���  � ��$	 160����  � ��$	 160����  � ��$ 10 10 10 10q���  � ��
 �������  � �� �� $	 0,0&�$	 1,1&�.��� $ #4b4b4b��$	 0Q�� $	 Red��$	 1Q���  �@�FocusVisualStyle Z� ��  � �� �� " ��.R��� $ 10��#��z��$ 10q�._�]� $��Stretch=�$��Stretch=�.+�]� $	��Top=�$	��Top=�$��Stretch=�.+��� $��content_presenter��$��18(�#��z��$
 Left=�$
��Wrap=�$	��Top=�$��	10 15 0 0q�8��  $
��Left=�$��Center=��� $��button_price_block��$��	10 10 0 0q�8�� $��14(�$
��Left=�$	��Top=����� *Button_price+�� $��button_type_block��$y�	Collapsed=����� *Button_category+�� $��button_id_block��$y�	Collapsed=����� *	Button_id+�� 8  8�� ���� *add+��`� 8  .1��� $
 Text�$ content_presenter���� $
 Text�$ button_price_block���� $
 Text�$ button_type_block���� $
 Text�$ button_id_block���� " ��.���  � �� �#4b4b4b��  � ��$ 	15 7 15 7q���  � ��$ SemiBold"���  � �� �� $	 1,0&�$	 1,1&�.��� $ 	LightGray��$	 .2Q�� $ 	LightGray��$	 1Q���  � ��$ 0q���  �@�FocusVisualStyle Z� ��  � ��$ 13(���  � ��$ 7 3 7 3q���  � ��$ Micro Sans Serif)���  � �� �� " ��.R��� $ 7��# z��#��z��#��z��._��� $��Center=�$��Center=� P�  �@J�IsMouseOver$
 True��. ���  � ��
 �������  � �� �� $	 1,0&�$	 1,1&�.��� $ #4b4b4b��$	 .2Q�� $	 Red��$	 1Q��� " n�.���  � �� �� .R�� $
 Grid��.+��� $��Stretch=�$��Stretch=�$
��auto��$
��Auto��
������ �� $  
Rectangle1��$ 5��$��0 8 0 10q�$��Stretch=�$��Stretch=�$
��auto��$
��auto��#��z��
 P�  �@�Tag$ 
Horizontal��. ��� $! 
Rectangle1�� � ��$
 auto���� $! 
Rectangle1�� � ��$ 12���� $! 
Rectangle1�� � ��$ 8 0 10 0q��� " ��.���  �@��IsFlicksEnabled$ False����  � �� �� $	 0,0&�$	 1,1&�.��� $ 	LightGray��$	 .5Q�� $ 	LightGray��$	 .5Q���  � ��
 �������  � ��$ 10����  � �� �� " ��.R�� $ GridRoot��$��12����Z� .+�]� $" 
PART_Track��$��0��$
��True��$|�False��# n� $$ Thumb��#��z��8��  % �� $& PageUp��$��ScrollBar.PageDownCommand��$' 0Q�$|�False��( �� $& PageDown��$��ScrollBar.PageUpCommand��$' 0Q�$|�False��
 P� $) Thumb�� �@J�IsMouseOver$
 True�� �� .���� .���� $N H(Foreground).(LinearGradientBrush.GradientStops)[0].(GradientStop.Color)� #4b4b4b$ 0:0:.4D��� $N H(Foreground).(LinearGradientBrush.GradientStops)[1].(GradientStop.Color)� Red$ 0:0:.4D�W� $O I(Foreground).(LinearGradientBrush.GradientStops)[0].(GradientStop.Offset)� 0$ 0:0:.5D�$
 True��$* Forever��W� $O I(Foreground).(LinearGradientBrush.GradientStops)[1].(GradientStop.Offset)� 1$ 0:0:.5D�$
 True��$* Forever�� �� .���� .���� $N H(Foreground).(LinearGradientBrush.GradientStops)[0].(GradientStop.Color)� 	LightGray$ 0:0:.4D��� $N H(Foreground).(LinearGradientBrush.GradientStops)[1].(GradientStop.Color)� 	LightGray$ 0:0:.4D�W� $O I(Foreground).(LinearGradientBrush.GradientStops)[0].(GradientStop.Offset)� .5$ 0:0:.4D�W� $O I(Foreground).(LinearGradientBrush.GradientStops)[1].(GradientStop.Offset)� .5$ 0:0:.4D�P� $) Thumb�� �@n�
IsDragging$
 True��. ��� $! Thumb�� � �� �� $	 0,0&�$	 1,1&�.��� $ #4b4b4b��$	 0Q�� $	 Red��$	 1Q�P�  � {�$ False��. ��� $! Thumb�� � y�$ 	Collapsed=�P�  �@��Orientation$ 
Horizontal=�. ��� $! GridRoot�� �@�LayoutTransform �� $	+ -90Q��� $! 
PART_Track�� �@�LayoutTransform �� $	+ -90Q���  � ��$
 auto����  � ��$ 12���� $! Thumb�� �@�Tag$ 
Horizontal���� $! PageDown�� � ��$ ScrollBar.PageLeftCommand���� $! PageUp�� � ��$  ScrollBar.PageRightCommand���� " ��.���  � ��$ 	10 5 10 5q���  � ��$ 0q���  � ��$ Stretch=���  � ��$ Stretch=���  � ��$	 Top=���  �@�FocusVisualStyle Z� ��  � �� �� " ��.���  � �� �� " ��.R��� $��Stretch=�$��Stretch=���  � ��$ Stretch=���  � �� �� .R�]� $��10q�$��Stretch=�$��Stretch=�.+�]� $
��Left=�.+��� $	��Top=�$
��Wrap=�$	��120��8��  $��14(�$
��Left=�$	��Top=����� *	Item_name+�� $��id_Block��$y�	Collapsed=����� *	Item_id+�� $��Bottom=�$
��Wrap=�8�� $��14(�$
��Left=�$��Bottom=����� *
Item_price+$, N2��]� $��Right=�$��Right=�$��Center=�.+��� 8  8�� $
��Left=�$
��Left=�$��Center=����� *reduce+���� $ id_Block��$
 Text��� 8  8�� $��Right=�$��Right=�$��Center=����� *
increase+���� $ id_Block��$
 Text��� $��5q�8�� $��14(�$��Center=�$��Center=����� *
Quantity+$- PropertyChanged=��� " ��.���  � ��$ 14(���  � ��
 �������  � ��
 ���� ��  �@�FocusVisualStyle Z� ��  � ��$ SemiBold"���  � ��$ Right=���  � ��$ Center=���  � ��$ 10q���  � �� �� " ��.R��� $��dashboard_border��#��z��._��� $��Center=�$��Center=� P�  �@J�IsMouseCaptured$
 True��. ���  � ��
 �  ���� " ��8   .���  � ��$. (./Assets/Font/#Font Awesome 6 Free Solid)���  � �� �� $	 0,0&�$	 1,1&�.��� $ #4b4b4b��$	 0Q�� $	 Red��$	 1Q� P�  �@J�IsMouseCaptured$
 true��. ���  � �� �� $	 0,0&�$	 1,1&�.��� $ #4b4b4b��$	 0Q�� $	 Red��$	 1Q��� " ��8   .���  � �� �#4b4b4b�� " ��8   .���  � ��
 �  �� P�  � ��$
 True�� �� .���� .���� $U O(Button.Background).(LinearGradientBrush.GradientStops)[0].(GradientStop.Color)� Red$ 0:0:.25D�$
 True���� $U O(Button.Background).(LinearGradientBrush.GradientStops)[1].(GradientStop.Color)� Red$ 0:0:.25D�$
 True��W� $V P(Button.Background).(LinearGradientBrush.GradientStops)[0].(GradientStop.Offset)� .4 0$ 0:0:.25D�$
 True��W� $V P(Button.Background).(LinearGradientBrush.GradientStops)[1].(GradientStop.Offset)� .6 1$ 0:0:.25D�$
 True���� " ��.���  � �� �� " ��.R�� .+��� $0 Border��#��� ��$
1 True��� $2 Arrow��
���   �$��Right=�$��8,8,3,3q�$
' 0.15Q�3 �   ��� ��� ��� ��� $4 Uniform=�$��Bottom=�
 P�  �@J�IsMouseOver$
 True��. ��� $! Border��# � �� � ��P�  � ��$
 True��. ��� $! Border��# � �� � ��P�  � {�$ False��. ��� $! Arrow�� � y�$ 	Collapsed=��� "  .���  � ��
 ���� ��  � �� �#454545��  � ��$
 Wrap=���  � ��$ 0q���   �@ RowDetailsVisibilityMode$ VisibleWhenSelected=���  �@ AutoGenerateColumns$ False����  � ��$
 true����  �@��PanningMode$
 Both=���  �@��IsFlicksEnabled$ False����  �@ HeadersVisibility$ Column=���  � ��$ 0 10 0 0q���  �@ SelectionMode$ Single=���  �@ SelectionUnit$ FullRow=���  �@ CanUserAddRows$ False����  �@ CanUserDeleteRows$ False����  �@ CanUserResizeRows$ False����  �@ CanUserReorderColumns$ False����  �@ CanUserResizeColumns$ False����  �@ ColumnWidth$
 auto	 ��  �@ GridLinesVisibility$
 None=���  � �� �� "  .R��� #��z��#��z��#��z��# z��$
1 True��._��� $ DG_ScrollViewer��$|�false������ " ��.R�� 5 �� $
��Auto ��� $��* ��� $
��Auto �6 �� $
��Auto ��� $��* ��� $
��Auto �.+��� #��Z7 $|�false����C� *�� $". DataGridSelectAllButtonStyle��"/  +y��� *HeadersVisibility+#9 Z8 #; Z: < �� "=  ���� *CellsPanelHorizontalOffset+< �� "=    $!> PART_ColumnHeadersPresenter��$��1��y��� *HeadersVisibility+#9 Z? #; Z: < �� "=  �� $!@ PART_ScrollContentPresenter��#A z��$��2��$��1���� $B PART_VerticalScrollBar��$��2��#D zC $E Vertical=�$��1��#G zF #y�zH I �� *VerticalOffset+$J OneWay=�< �� $K TemplatedParent=�� $��1��$��2��5 �� ���� **(NonFrozenColumnsViewportHorizontalOffset+< �� "=  �� $��* �.+��� $B PART_HorizontalScrollBar��$��1��#D zL $E 
Horizontal=�#G zM #y�zN I �� *HorizontalOffset+$J OneWay=�< �� $K TemplatedParent=�.���� #1 z1  ]� O �� P �@��
IsGrouping$
Q true���� "P �@%�IsVirtualizingWhenGrouping$Q false��./���  � ��$ false���� "  8   .���  � ��$ 0q��� "  .���  � ��
 ���� ��  � ��$ Center=���  � ��$ Center=���  �@�FocusVisualStyle Z� ��  � ��$ SemiBold"���  � ��$
 15 0q���  � �� �� "  .R��� #��z��$��0q�$
1 True��._��� #1 z1 �� " n�.���  � ��$ 8����  � ��
 ���� ��  �@�Cursor$ SizeWE����  � �� �� " n�.R��� #��z��# z���� "  .���  � ��$ Center=���  � ��$ Center=���  � ��
 ���� ��  � ��$ SemiBold"���  � ��$ 16(���  � �� �� $	 0,0&�$	 1,1&�.��� $ #4b4b4b��$	 0Q�� $	 Red��$	 1Q���  � ��$ 	8 10 8 10q���  � �� �� "  .R�� .+�  #��z��#��z��#��z��#R z��#T zS #V zU # z��#X zW #Z zY #\ z[ ._��� #��z��$
��True��#1 z1 #��z��n� $$ PART_LeftHeaderGripper��$
��Left=�8��  n� $$ PART_RightHeaderGripper��$��Right=�8�� �� "  8   .���  � ��$
 Wrap=���  � ��$ 0q���  � ��$ 50����  � ��$ 10q��� "  .���  � ��
 �������  � ��$ 0 4 0 0q���  � ��$ 14(���  �@J�SnapsToDevicePixels$
 true����  �@=�ErrorTemplate Z� ��  �@ ValidationErrorTemplate �� .R��� 
���  ��$��2,0,0,0q�$��!��$��Center=���  � �� �� "  .R��� $  
DGR_Border��$	 0 8q�#��z��$ 7��$��0q�$
1 True��._�  5 �� $
��Auto ��� $��* �6 �� $��* ��� $
��Auto �.+�  $��1��#��z] #1 z1   $��1��$��1��#y�z^ _ �� *AreRowDetailsFrozen+#9 Z` #; Za < �� "=    $��2��$_ Vertical=�y��� *HeadersVisibility+#9 Zb #; Z: < �� "=   P�  �@J�IsMouseOver$
 True��. ���  � �� �� $	 1,0&�$	 1,1&�.��� $ #4b4b4b��$	 .2Q�� $	 Red��$	 1Q���  � �� �#ffffffP�  �@ 
IsSelected$
 True��. ���  � �� �� $	 1,0&�$	 1,1&�.��� $ #4b4b4b��$	 .2Q�� $	 Red��$	 1Q���  � �� �#ffffff]� O �� P �@ 
IsSelected$
Q True���� P �@��IsSelectionActive$Q false��./���  � �� �#dfdfdf