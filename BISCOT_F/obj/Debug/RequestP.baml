   M S B A M L   `   `   `  ����C  ?BISCOT_F, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:BISCOT_FBISCOT_F  5      #clr-namespace:BISCOT_FBISCOT_F  5          BISCOT_F.RequestP   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      &srcclr-namespace:BISCOT_F     5      b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      :d2http://schemas.microsoft.com/expression/blend/2008  5      "localclr-namespace:BISCOT_F  5      -   5        $
��auto��5
      $
��auto��5   	     N� 
Background  �	#FFF7F7F7 � 	Resources 5         ZoomUpButton �� 
TargetType �� Property �� Value �� 
TargetType �� Triggers P� Property P� Value3  -System.Windows.Media.Effects.DropShadowEffect	   ShadowDepth  ZoomDownButton  
BlueHeader
 �� Orientation �� EndPoint �� 
StartPoint � Color � Offset��%�  &	        &	 �    &	 �    �� 5   
   " ��6%   .�5      ��  � ��$
 23.5��6&   �� 5       � ��$
 25.5��6'   �� 5       � �� 5      �� 5      " ��6&   .R�5      � $
��23.5��6   $
��25.5��6,   .+�5      �� $��Resources/zoom+.png��6$   $
��Fill=�6A   �� 5      $��Center=�6/   5       5      P� 5       �@J�IsMouseOver . . �5   "   ��  �@J�Effect 5   &     5   *   $	 2Q�6;   5   #   5      5!      5#      5$      �� 5%   
   " ��6'   .�5&      ��  � ��$
 23.5��6&   �� 5'       � ��$
 25.5��6'   �� 5(       � �� 5)      �� 5*      " ��6&   .R�5+      � $
��23.5��6   $
��25.5��6,   .+�5,      �� $��Resources/zoom-.png��6$   $
��Fill=�6A   �� 5-      $��Center=�6/   5.       5/      P� 50       �@J�IsMouseOver . . �51   "   ��  �@J�Effect 52   &     53   *   $	 2Q�6;   55   #   56      58      5:      5;      �� 5<   
   .R�5=      �� $
 
Horizontal=�6   $��-5,-5,-5,-5q�62   $
��auto��6G   ��5>      �� 5?      $ 0.5,1&�6*   $ 0.5,0&�6;   .��5@      � $ 	#FF223B84��6'   $ 1Q�69   � 5A      $ 	#FF57A0F4��6'   $	 0.5Q�69   � 5B      $ 	#FF4B94EC��6'   $	 0.5Q�69   5C      .+�5E      �� $��10,10,10,10q�6   $��Center=�5F      
���������5E   1   �� 5F      5G      5H      5I      .��5J      � 
�������.+�5K   
   � $��0��6   $��1��6    � RowDefinitions 5L      �� 5N      $
��300* �6    �� 5O      $	��170 �6    �� 5P      $	��170 �6     � ColumnDefinitions 5S      �� 5T      �� 5U      $
��Auto �6#   .+�5W      �� -   5        $��mapgroup��5W      $	��map��6(   $��0��67   $��1��6D   $
��auto��6V   $��1��6d   .��5X         BISCOT_F.Map  -   5          Name$ MainMap��5X      c _GMap.NET.WindowsPresentation, Version=1.7.5.0, Culture=neutral, PublicKeyToken=b85b9027b614afef.  (GMap.NET.WindowsPresentation.GMapControl   Zoom$ 13Q�6+      MaxZoom$ 24��65      MinZoom$ 1��6B   $��-8,-9,-8,-8q�6N   5Y      �� 5Z      -   5        $��	groupBox3��5Z   G   $��loading��6   $��Right=�6*   $��0��6Y   $��1��6f   $��1��6w   $
��auto��6�   $��60��6�   $	��Top=�6�   $
��50,0q�6�   .��5[      � .+�5\      � -   5        $��progressBar1��5\   -   $��2q�6"    � IsIndeterminate . /  )MaterialDesignThemes.Wpf.TransitionAssist   DisableTransitions . 6X   5]      5^      �� 5_      $��Right=�6   $��0��64   $��1��6A   $
��auto��6S   $��1��6a   $
��Zoom��6u   $��52��6�   $��0,0,0,59q�6�   .��5`      � .+�5a      �� -   5         ��Name$ 	czuZoomUp��5a      #��[  60   $��Center=�6V   $	��Top=�6s   $
��23.5��6�   $
��25.5��6�   6�   �� 5b      -   5         ��Name$ 
sliderZoom��5b   �    �� Orientation$ Vertical=�6   $��Center=�64   $��Stretch=�6Q    � Maximum$ 17Q�6m    � Minimum$ 12Q�6z    �� TickPlacement$
 Both=�6�   $��	0,30,0,40q�6�    � SmallChange$ 1Q�6�    � Value 6�   ��  �� ElementName$ MainMap��  �� Path$
  Zoom�6  �� 5c      -   5        $ czuZoomDown��5c   E   #��[ 6   $��Center=�6Z   $��Bottom=�6w   $��23��6�   $��25��6�   6�   5d      5e      � 5f      -	   5        ! �Name$! 
help_tools��5f      $	��163��6'   $��
10,0,0,0.4q�64   $��Bottom=�6H   $
��Left=�6c   $	��504��6~   .+�5g      �� -
   5        $��	groupBox2��5g   Y   $
��gmap��6   $��Right=�6*   $��	0,2,335,0q�6F   $	��169��6j   $	��Top=�6v   $	��151��6�   .��5h      � $��Stretch=�6   $��Stretch=�69   .+�5i      �� -   5        $��comboBoxMapType��5i   C   $��12(�6#   $��6,6,45,0q�61   $��25.04��6Z   $	��Top=�6i   " �� SelectedIndex$" 1��6�   .@�5j      �� # �� 
IsSelected# . .��6=   GoogleHybridMap6N   �� 5k      .��6+   	GoogleMap66   5l      �� 5n      -   5        $��label1��5n   M   $��Right=�6    $��0,6,3,0q�6<   $��33��6[   $��25��6f   $	��Top=�6r   .��6�   type6�   �� 5q      -   5        $��checkBoxCurrentMarker��5q   B   $��23��6#   $��	6,76,60,0q�6/   $	��Top=�6_   $��8(�6�   .��6�   Current Marker6�   �� 5r      -   5        $��comboBoxMode��5r   P   $��10(�6#   $��25��61   $��	6,46,45,0q�6=   $	��Top=�6d   6|   �� 5s      -   5        $��label5��5s   [   $��25��6    $��Right=�6,   $��	0,46,-4,0q�6H   $	��Top=�6i   $��43��6�   .��6�   mode6�   �� 5t      -   5        $��button7��5t   I   $��22��6!   $��Right=�6-   $��Bottom=�6X   $��54��6s   $��
0,0,6,3.06q�6�   $��10(�6�   .��6�   Save6�   5v      5w      �� 5x      -   5        $��markers��5x   a   $y�	Collapsed=�6   $��markers��64   $��Right=�6E   $	��131��6p   $��	0,2,194,0q�6|   $	��151��6�   $	��Top=�6�   .��5y      � .+�5z      �� -   5        $��button8��5z   5   $��
7,6,34.2,0q�6!   $��21��6D   $	��Top=�6P   $��7(�6~   .��6�   
Add Marker6�   �� 5{      -   5        $��button10��5{   5   $��
7,0,0,21.8q�6!   $��21��6E   $��Bottom=�6Q   $
��Left=�6�   $��78��6�   $��10(�6�   .��6�   	Clear All6�   5~      5      �� 5�      -   5        $��	groupBox1��5�   w   $y�	Collapsed=�6   $��coordinates��63   $��Right=�6H   $��	0,2,25,10q�6d   $	��169��6�   .��5�      � .+�5�      �� -   5        $��button1��5�   B   $��23��6!   $��0,0,1.2,7.8q�6-   $��Bottom=�6Q   $��Right=�6�   $��71��6�   $��10(�6�   .��6�   Reload6�   �� 5�      -   5        $��
textBoxLat��5�   @   $��23��6"   $��6,6,36,0q�6.   $	��Top=�6R   �� 5�      -   5        $��
textBoxLng��5�   5   $��	6,35,36,0q�6"   $��22.04��6G   $	��Top=�6V   �� 5�      -   5        $��button2��5�   Y   $��23��6!   $
��Left=�6-   $��6,0,0,7q�6H   $��Bottom=�6h   $��68��6�   $��10(�6�   .��6�   Go To!6�   �� 5�      -   5        $��label2��5�   Z   $��23��6    $��Right=�6,   $��0,4,12,0q�6H   $	��Top=�6h   $��27��6�   $��Center=�6�   .��6�   lat6�   �� 5�      -   5        $��label3��5�   [   $��23��6    $��Right=�6,   $��	0,33,12,0q�6H   $	��Top=�6i   $��Center=�6�   $��27��6�   .��6�   lng6�   5�      5�      5�      �� 5�      -   5        $ ��Name$$ 	groupBox4��5�      $��1��6*   $��2��67   $
��auto��6I   $��1��6W   $��RightToLeft=�6l   $��17(�6�   $
��Bold"�6�   ���	#FF99D834
�������.  (MaterialDesignThemes.Wpf.ColorZoneAssist%   Mode$% Custom=�6�   .��5�      � .+�5�      � $��
14,-90,0,0q�6   & J� SnapsToDevicePixels& . $	��100��6J   $	��100��6W   $
��Left=�6c   $	��Top=�6~   ' J� OpacityMask' 5�      !� 5�      ( !� Visual( 6*   �� $ ClipEllipse��.+�5�      A� -   5        ) A�Name$) ClipEllipse��5�   "   
�������67   '  !MaterialDesignThemes.Wpf.PackIcon  5�      *   Kind$* AccountCircle=�62   & . $
��Auto��5�   <   $
��Auto��6I   $��-4q�5�   *   $��Stretch=�66   $��Stretch=�5�   *   �� 5�      -   5        + ��Name$+ image1��5�       $��UniformToFill=�61   $C��=Source/52eabf633ca6414e60a7677b0b917d92-male-avatar-maker.jpg��6I   5�      �� 5�      -   5        , ��Name$, label��5�      $&�� نام درخواست کننده��6+   $
��Left=�6G   $��	10,10,0,0q�6b   $	��Top=�6u   
�������$��2��6�   �� 5�      -   5        $, 
label_Copy��5�      $��زمان درخواست��60   $
��Left=�6G   $��	407,9,0,0q�6b   $	��Top=�6u   
�������6�   �� 5�      -    5        $, label_Copy1��5�      $��شماره تماس��61   $
��Left=�6F   $��	10,77,0,0q�6a   $	��Top=�6t   
�������6�   �� 5�      -!   5        $, label_Copy2��5�      $��مقصد��61   $
��Left=�6@   $��
215,76,0,0q�6[   $	��Top=�6o   
�������6�   �� 5�      -"   5        - ��Name$- txt_name��5�       $
��Left=�62   $��	10,44,0,0q�6M   $
��Wrap=�6`   $	��Top=�6t   $��28��6�   $	��104��6�   
�������$��2��6�   �� 5�      -#   5        $- 	txt_start��5�       $
��Left=�63   $��
215,43,0,0q�6N   $
��Wrap=�6b   $	��Top=�6v   $��28��6�   $	��104��6�   
�������6�   �� 5�      -$   5        $- txt_phonenum��5�       $
��Left=�66   $��
10,105,0,0q�6Q   $
��Wrap=�6e   $	��Top=�6y   $��28��6�   $	��104��6�   
�������$��2��6�   �� 5�      -%   5        $- txt_end��5�       $
��Left=�61   $��215,104,0,0q�6L   $
��Wrap=�6a   $	��Top=�6u   $��28��6�   $	��104��6�   
�������6�   �� 5�      -&   5        $, label_Copy3��5�      $��مبدا��61   $
��Left=�6@   $��	215,9,0,0q�6[   $	��Top=�6n   
�������6�   �� 5�      -'   5        $- txt_date��5�       $
��Left=�62   $��
407,44,0,0q�6M   $
��Wrap=�6a   $	��Top=�6u   $��28��6�   $	��104��6�   
�������6�   �� 5�      $��Right=�6!   $	��Top=�6=   $��1��6U   $��
0,0,-0.4,0q�6e   .+�5�      �� -(   5        $- success��5�   $   $
��Left=�66   $
��Wrap=�6R   $	��Top=�6f   $��97��6~   $	��122��6�   ���	#FFFDFDFD�� 6�   .F�5�        $* 
TickCircle=�66   $��97��6H   $	��112��6T   5�      5�      �� 5�      -)   5        $- success1��5�   $   $��پایان یافته��66   $��Right=�6I   $��Bottom=�6e   $��28��6�   $	��104��6�   
�������$
��Bold"�6�   5�      �� 5�      $��Right=�6!   $	��Top=�6=   $��1��6U   $��
0,0,-0.4,0q�6e   .+�5�      �� -*   5        $- doing��5�   $   $
��Left=�64   $
��Wrap=�6P   $	��Top=�6d   $��97��6|   $	��122��6�   ���	#FFFDFDFD$y�	Collapsed=�6�   �� 6�   .F�5�        $* Clock=�66   $��97��6C   $	��112��6O   5�      5�      �� 5�      -+   5        $- doing1��5�   $   $��در حال انجام��64   $��Right=�6H   $��Bottom=�6d   $��28��6   $	��104��6�   
�������$
��Bold"�6�   $y�	Collapsed=�6�   5�      �� 5�      $��Right=�6!   $	��Top=�6=   $��1��6U   $��
0,0,-0.4,0q�6e   .+�5�      �� -,   5        $
- Fail��5�   $   $
��Left=�63   $
��Wrap=�6O   $	��Top=�6c   $��97��6{   $	��122��6�   ���	#FFFDFDFD$y�	Collapsed=�6�   �� 6�   .F�5�        $* CloseCircle=�66   $��97��6I   $	��112��6U   5�      5�      �� 5�      --   5        $- Fail1��5�   $   $��کنسل شده��63   $��Right=�6C   $��Bottom=�6_   $��28��6z   $	��104��6�   
�������$
��Bold"�6�   $y�	Collapsed=�6�   5�      �� 5�      -.   5        $, label_Copy8��5�      $��توضیحات��61   $
��Left=�6C   $��
407,69,0,0q�6^   $	��Top=�6r   
�������6�   �� 5�      -/   5        $- 
txttozihat��5�   !   $
��Left=�65   $��407,102,0,0q�6P   $
��Wrap=�6e   $	��Top=�6y   $��28��6�   $	��274��6�   
�������$��13(�6�   5�      5�      5�      �� 5�      -0   5        $$ 	groupBox5��5�      $��3��6+   $��3��68   $
��auto��6J   $��1��6X   $��RightToLeft=�6m   $��17(�6�   $
��Bold"�6�   $% Custom=�6�   .��5�      � $��RightToLeft=�6    5�      �� 5�      $
��369* �6+   �� 5�      $
��536* �6+   .+�5�      �� -1   5        $ Btnsabtesafar��5�      $��
تایید��64   $��Right=�6D   $��Bottom=�6`   $��	0,0,30,30q�6{   $��1��6�   $��91��6�   $��45��6�   6�   �� 5�      -2   5        . ��Name$. 	comboBoxd��5�      $
��Left=�62   $��-5,0,0,0q�6M   $	��Top=�6_   $	��200��6w   $��52��6�   )  #MaterialDesignThemes.Wpf.HintAssist/   Hint$/ راننده سفر��6�   .  (MaterialDesignThemes.Wpf.TextFieldAssist0   HasClearButton0 . $% Inverted=�5�      
�������
�������5�      �� 5�      -3   5        $, label_Copy4��5�      $��نام راننده��61   $
��Left=�6F   $��
200,10,0,0q�6a   $	��Top=�6u   $	��137��6�   
�������6�   �� 5�      -4   5        $, label_Copy5��5�      $��شماره تماس��61   $
��Left=�6F   $��
200,77,0,0q�6a   $	��Top=�6u   $��96��6�   
�������6�   �� 5�      -5   5        $, label_Copy6��5�      $��پلاک��61   $
��Left=�6@   $��37.8,77,0,0q�6[   $	��Top=�6p   $��56��6�   
�������$��1��6�   �� 5�      -6   5        $- txt_drivername��5�       $
��Left=�68   $��
200,44,0,0q�6S   $
��Wrap=�6g   $	��Top=�6{   $��28��6�   $	��137��6�   
�������6�   �� 5�      -7   5        $- txt_car��5�       $
��Left=�61   $��36.8,44,0,0q�6L   $
��Wrap=�6a   $	��Top=�6u   $��28��6�   $	��139��6�   
�������$��1��6�   �� 5�      -8   5        $- txt_driverphone��5�       $
��Left=�69   $��200,105,0,0q�6T   $
��Wrap=�6i   $	��Top=�6}   $��28��6�   $	��137��6�   
�������6�   �� 5�      -9   5        $- 	txt_pelak��5�       $
��Left=�63   $��36.8,105,0,0q�6N   $
��Wrap=�6d   $	��Top=�6x   $��28��6�   $	��139��6�   
�������$��1��6�   �� 5�      -:   5        $, label_Copy7��5�      $��
ماشین��61   $
��Left=�6A   $��37.8,10,0,0q�6\   $	��Top=�6q   $��56��6�   
�������$��1��6�   5�      5�      �� 5�      -;   5        $$ groupBox��5�      $�� ��6)   $
��Left=�63   $��1��6O   $��0��6`   $��3��6m   $��0.2,0.4,0,-0.4q�6~   #��� ��6�   .��5�      �� -<   5        1 ��Name$1 ListView_Requset��5�   8   $��RightToLeft=�6   $" 0��6R   $
��Left=�6�   $
��auto��6�   ���	#FFF4F4F42 � Cursor$
2 Hand��6�   3 �� View3 5�      �� 5�      4 �� AllowsColumnReorder4 . .P�5�      �� $��شماره سفر��6-   5 �� Width$
5 auto��6A   6 �� DisplayMemberBinding6 6N   �� $  Id��� 5�      $&�� نام درخواست کننده��6-   $
5 auto��6I   6 6V   �� $  usertbl.FullName��� 5�      $��مبدا��6-   $
5 auto��6;   6 6H   �� $  StartLocName��� 5�      $��مقصد��6-   $
5 auto��6;   6 6H   �� $  
EndLocName�5�      ��5�      �� 5�      " ��6    .�5�      -=   5        �� 5�       � ��$ 50��67   7 �� Triggers7 5�      �� 5�   "   8 �� Binding8 6.   �� *Status+9 �� Value9 36I   .a�5�   &   ��  � �� �	#FF00C3FF6C   5�   #   �� 5�   "   8 6.   �� *Status+9 26I   .a�5�   &   ��  � ��
 �  ��6C   5�   #   �� 5�   "   8 6.   �� *Status+9 16I   .a�5�   &   ��  � �� �	#FFFFB74D6C   5   #   �� 5  "   8 6.   �� *Status+9 06I   .a�5  &   ��  � �� �	#FF99D8346C   5  #   5     5     5
     5     5     5     