   M S B A M L   `   `   `  ����L  HPostManagementApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:PostManagementAppPostManagementApp  5   	   F BPostApiCore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullR8clr-namespace:PostApiCore.Converter;assembly=PostApiCorePostApiCore.Converter 5   
   "    PostManagementApp.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:PostManagementApp     5   	   Fl8clr-namespace:PostApiCore.Converter;assembly=PostApiCore     5   
     � Title$  Post Management App��5	   	   $	��600��6%   $	��720��62    � WindowStartupLocation$ CenterScreen=�6@   $��5q�6e    � WindowStyle$ 
ToolWindow=�6y    � 	Resources 5
      5  /PostApiCore.Converter.BoolToVisibilityConverter   converterForVisibility=  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property �� Value  ButtonFocusVisual J� SnapsToDevicePixels �� StrokeDashArray��%�  &	        '       &	     '�� �    7    5   
   6&   �� 5   
   "  6   .�5      ��  � ��$ Center=�69   �� 5       � ��$ Center=�6;   �� 5       �@ SeparatorBrush
 �����6/   �� 5       � ��$
 Bold"�6+   �� 5       � ��$ 30��6'   5      �� 5   
   .�5      ��  � �� 5      �� 5      .R�5      �� $��2q�6$    . #��� ��6J   $��1��6�   $	 1 2R�6�   5      5      5!      �� 5#   
   " ��6   .�5$      ��  � ��$ 10,2,1,2q�6'   �� 5%       � ��$
 Left=�64   �� 5&       � ��$ 25��6'   64   �� 5'       � ��$	 100��6&   64   �� 5(       �@�FocusVisualStyle8   61   �� 5)       � ��$	 Top=�62   6@   �� 5*       � �� �	#EEEEEEEE6+   �� 5,       � ��
 �   �6+   �� 50       � ��$ 14(�6)   �� 52       � ��$ 2q�60   54      56      .��59      � 	 � RowDefinitions	 5:   
   �� 5;      $��50 �6   6*   �� 5<      $��40 �6   6*   �� 5=      $
��Auto �6   6,   .+�5@   
   �� $��1q�6   $��0,0,0,1q�6%   $��0��66   
 J� Effect
 5A      3  -System.Windows.Media.Effects.DropShadowEffect  5B         Color# � ��6#   ._�5D      �� $��16(�6   $
��Bold"�6"   $��Center=�64   $��Center=�6O   .��6l   Post Management Application6�   5E      �� 5F   
    �� Orientation$ 
Horizontal=�6   $��1��6.   .+�5G      �� -   5        $��	LoadPosts��5G      $��	Load Post��6&   ��6:   �� *LoadPostCommand+6a   5H      �� 5J   
   $ 
Horizontal=�6   $��2��6.   .+�5K      �� .+�5L      &   System.Windows.Controls.DataGrid     AutoGenerateColumns .     AlternatingRowBackground
 ����$��Stretch=�6]   $��Stretch=�6{   $��10q�5M      $	��450��6#   $	��420��60   
�������$��1q�6O      
IsReadOnly .    CanUserReorderColumns .  "   VerticalScrollBarVisibility$
 Auto=�6�   $   HorizontalScrollBarVisibility$
 Auto=�6�   ��5L   �   ��  �� Path$ PostCollection� �� SelectedItem 6�   �� *SelectedPost+   Columns 5N      0  *System.Windows.Controls.DataGridTextColumn  5O      ,  &System.Windows.Controls.DataGridColumn   Header$ User ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 60 6Q   1  +System.Windows.Controls.DataGridBoundColumn   Binding 66   �� *userId+6_     5P      $ ID��6%   $ 50 6H    61   �� *id+6U     5Q      $ Title��6%   $	 350 6N    64   �� *title+6\   5S      5U      �� 5W      $��Post Details��6   $	��226��61   $
��Bold"�6=   .��5X      �� $��1,1,1,1q�6    � ToolTip$# Right Click to Copy Post data��6J   $
��Wrap=�6r   ��6-   �� *PostDetails+ � ContextMenu 5Y      �� 5Z      .@�5[      m� $��Copy Plain text��6'    m� Command 6@   �� *CopyPlainTextCommand+ 5\   "   �� 5]   &   .+�5^   *   �� $
��Bold"�64   $��14(�6F   $��0,0,0,5q�6T   .,Copy the JSON API Post Content in Plain Text6�   5_   '    m� Icon 5a   "   �� 5b   &   $��/Resources/Text.png��6,   6K   5d      m� 5e      $��Copy JSON text��6'   $��2q�6c    6?   �� *CopyJSONCommand+ 5f   "   �� 5g   &   $��/Resources/JSon.png��6,   6K    5i   "   �� 5j   &   .+�5k   *   �� $
��Bold"�64   $��14(�6F   $��0,0,0,5q�6T   (&Copy the JSON API Post Content in JSON6�   5l   '   5n      m� 5o      $��Copy XML Text��6'    6?   �� *CopyJSONXMLCommand+ 5p   "   �� 5q   &   $��/Resources/XML.png��6,   6J    5s   "   �� 5t   &   .+�5u   *   �� $
��Bold"�64   $��14(�6F   $��0,0,0,5q�6T   '%Copy the JSON API Post Content in XML6�   5v   '   5x      m� 5y      $��Copy HTML Text��6'    6@   �� *CopyHTMLCommand+ 5z   "   �� 5{   &   .+�5|   *   �� $
��Bold"�64   $��14(�6F   $��0,0,0,5q�6T   (&Copy the JSON API Post Content in HTML6�   5}   '    5   "   �� 5�   &   $��/Resources/HTML.png��6,   6K   5�      5�      5�      5�      5�      �� 5�   
   
������ $��3��6,   $��0,-120,0,120q�6�   y�6=   �� *IsDataExtracted+ �� 	Converter# [  ._�5�      �� $��Loading Posts...��6   $y�Visible=�60   $��Center=�6E   $��20(�6b   $��Center=�6p   5�      5�      5�      