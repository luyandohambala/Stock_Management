   M S B A M L   `   `   `  ����g  cLiveChartsCore.SkiaSharpView.WPF, Version=2.0.0.0, Culture=neutral, PublicKeyToken=cc92a3e13d40c573}Xclr-namespace:LiveChartsCore.SkiaSharpView.WPF;assembly=LiveChartsCore.SkiaSharpView.WPF LiveChartsCore.SkiaSharpView.WPF  5   N    Stock_Management-   'Stock_Management.Assets.Pages.Home_Page   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      hlvcXclr-namespace:LiveChartsCore.SkiaSharpView.WPF;assembly=LiveChartsCore.SkiaSharpView.WPF     6N      
page style#��[  5        N� Title$  	Home_Page��5      .��5
      ��   border style#��[ 6   ���#eff2f7 �� CornerRadius$ 7��6H   ._�5   
   �  � RowDefinitions 5      �� 5      $��* �6    �� 5      $��9* �6    .+�5      �� $��10q�6   $��Your company at a glance��6$     Header text#��[ 6D   $��Center=�6i   $��Bottom=�6�   �� 5      $��1��6   $��Stretch=�6&   $��Stretch=�6D   .+�5      �� -   5        $ ��dashboard_items_stackpanel��5       �� Orientation$ 
Horizontal=�6?   $	��190��6X   $��Center=�6e   .+�5      ��   dashboard_button_style#��[ 6   $��stock��5      ��5   M   ��   Home_Page_ViewModel �� Source# [  �� Path$ change_view�.��5      �� $
��Wrap=�6$   ��68   �� *Total_stock_available+ �� StringFormat$# Available Items in Stock 
{0}��5      �� 5      #��[ 6   $��stock_sales��5      ��5   M   �� # [ $ change_view�.��5      �� $
��Wrap=�6$   ��68   �� *Total_sales_p_month+$ Sales This Month 
{0}��5       �� 5"      #��[ 5#      ��5"      �� *show_notification_command+.��5$      �� $
��Wrap=�6$   ��5%   $   �� # [ $ Pending_reports�$ Pending Reports 
{0}��5&      �� 5)      -   5        $��Notification_Panel_Border��5)      
�������$��10q�5*   0   $ 10��6<   y�5)   >   �� *Notification_visibility+._�5+      �� .+�5,      ]� .+�5-   "   �� $��Notifications��6,   $��10 12q�6A   $
��Left=�6P   $
��Left=�5.   )   #��[ 6D   $��14(�6i   ���#4b4b4b6w   �� 50   "   $��	Clear all��6)   $��10q�6=   $��Right=�51   )   $	��Top=�6@   $��Right=�52   )     clear_items_button#��[ 6E   $��14(�6q   ��50   J   �� # [ $! clear_notifications_command�52   q   53      �� 55       � DataContext# [ 6'   $	��250��6Z   $	��130��6f   $��False��6s   $��Center=�56   '   $
��Left=�6B   $��	5 10 5 10q�6X   $
��Left=�57   '     notification style#��[ 6B   ��58   '   �� *Notification_list+59      5:      5;      �� 5=      $ 
Horizontal=�6   $	��190��66   $��Center=�6C   .+�5>      �� #��[ 6   $��settings��5?      ��5>   M   �� # [ $ change_view�.��5@      �� $
��Wrap=�6$   ��68   �� *Number_of_users+$ Active Users 
{0}��5A      �� 5C      
�������$ 10��60   ._�5D      5   /LiveChartsCore.SkiaSharpView.WPF.CartesianChart  $	��390��6-   $��0q�69      ZoomMode$ X=�6D   	   Series	 5E   !   �� *Series+
   XAxes
 5F   !   �� *Xaxes+   YAxes 5G   !   �� *Yaxes+5H      5I      5K      5M      5O      5P      5Q      