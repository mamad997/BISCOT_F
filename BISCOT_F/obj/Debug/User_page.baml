   M S B A M L   `   `   `  ����C  ?BISCOT_F, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:test_matrialtest_matrial  5          test_matrial.User_page   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:test_matrial     5      b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      $Customhttp://wpfcontrols.com/  5        N� Title$  	User_page��5      .��5      � ���	#FFD7E9F3$��RightToLeft=�6"    � ColumnDefinitions 5   
   �� 5      $	��58* �6   �� 5      $��0* �6   �� 5      $
��235* �6   �� 5      $	��42* �6   �� 5      $
��228* �6   �� 5      $	��42* �6   �� 5      $
��236* �6   �� 5      $
��159* �6   �� 5      $
��130* �6   �� 5      $
��176* �6    � RowDefinitions 5   
   �� 5      $	��10* �6   �� 5      $	��23* �6   �� 5      $	��31* �6   �� 5       $	��66* �6   �� 5!      $��30 �6   �� 5"      $��60 �6   �� 5#      $	��32* �6   �� 5$      $	��74* �6   �� 5%      $	��74* �6   �� 5&      $	��74* �6   �� 5'      $	��66* �6   �� 5(      $	��80* �6   �� 5)      $
��118* �6   �� 5*      $	��70* �6   �� 5+      $	��42* �6   .+�5-   
   (  "MaterialDesignThemes.Wpf.ColorZone     Mode$ SecondaryLight=�5.      $��20q�5/      +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth5=�50      $��	1,48,62,0q�6>   $	��Top=�6Q   $	��332��6i   $��5��6v   $��6��6�   $��8��6�   $��2��6�   �� 51   
   -   5         ��Name$ txtname��51      $
��Left=�6#   $�� ��6@   $	��200��6I   $��Cambria Math)�6V   $��15(�6p   ���	#FF090909$��	26,20,0,9q�6�   $��7��6�   $��2��6�   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ نام��6�    %  !MaterialDesignFloatingHintTextBox#��[  6�   �� 52   
   -   5        $ txtphone��52      $
��Left=�6$   $ شماره تماس��6A   #��[  6m   $��40��6�   $��Bottom=�6�   $	��200��6�   $��Cambria Math)�6�   $��15(�6�   ���	#FF090909$��	26,0,0,21q�6  $��9��6/  $��2��6<  6L  �� 53   
   -   5         ��Name$ label��53      $��اطلاعات کاربر��6   $��Center=�67   $��Bottom=�6T   $��Cambria Math)�6p   $��26��6�   $	��121��6�   $��16(�6�   $
��Bold"�6�   ���	#FF090909$��13,0,118,13q�6�   $��2��6�   $��5��6�   �� 54   
   -   5        $ txtlastname��54      $
��Left=�6'   $ نام خانوادگی��6C   #��[  6q   $	��200��6�   $��Cambria Math)�6�   $��15(�6�   ���	#FF090909$��	21,20,0,9q�6�   $��7��6  $��4��6  �� 55   
   -   5        $ txtcode��55      $
��Left=�6#   $ شماره پرسنلی��6A   #��[  6o   $	��200��6�   $��Cambria Math)�6�   $��15(�6�   ���	#FF090909$��
20,20,0,10q�6�   $��7��6  $��6��6  �� 56   
   -   5         ��Name$ btnsabt��56      $��ثبت��6"   $
��Left=�60   $��	20,22,0,0q�6K   $	��Top=�6^   $	��210��6v   $��11��6�   $��6��6�   $��48��6�   6�   �� 57   
   -   5        $ button_Copy��57      $��انصراف��6&   $
��Left=�67   $��	11,22,0,0q�6R   $	��Top=�6e   $	��210��6}   $��11��6�   $��4��6�   $��48��6�   6�   � 58   
   $��	13,25,0,0q�6   	 J� SnapsToDevicePixels	 . $	��100��6=   $	��100��6J   $
��Left=�6V   $	��Top=�6q   $��8��6�   $��7��6�   $��2��6�   
 J� OpacityMask
 59      !� 5:       !� Visual 6   ��  �� ElementName$ ClipEllipse��.+�5<      A� -   5         A�Name$ ClipEllipse��5<      
�������6+   '  !MaterialDesignThemes.Wpf.PackIcon  5=         Kind$ AccountCircle=�6&   	 . $
��Auto��5>   <   $
��Auto��6I   $��-4q�5?   *   $��Stretch=�66   $��Stretch=�5@   *   �� 5A      -	   5         ��Name$ Image��5A      $��UniformToFill=�6$   $C��=Source/52eabf633ca6414e60a7677b0b917d92-male-avatar-maker.jpg��6<   6�   5B      �� 5C   
   -
   5        $ 	btnBrowse��5C      $��انتخاب عکس��6$   $��8��69   $
��Left=�6I   $��	10,22,0,0q�6d   $��9��6w   $	��Top=�6�   $	��109��6�   6�   �� 5D   
   -   5        $ 	txtaddres��5D      $
��Left=�6%   $ آدرس��6B   #��[  6h   $��40��6�   $��Bottom=�6�   $	��563��6�   $��Cambria Math)�6�   $��15(�6�   ���	#FF090909$��	21,0,0,21q�6  $��9��6*  $��4��67  $��4��6H  5G      5H      