   M S B A M L   `   `   `  ����G  CКурсач, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:КурсачКурсач  5          Курсач.Req   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:Курсач     5        N� Title$	  Req��5	       � 	Resources 5
         FocusVisual �� Property �� Value �� StrokeDashArray J� SnapsToDevicePixels  Button.Static.Background �� Color  Button.Static.Border  Button.MouseOver.Background  Button.MouseOver.Border  Button.Pressed.Background  Button.Pressed.Border  Button.Disabled.Background  Button.Disabled.Border 	 Button.Disabled.Foreground 
 ButtonStyle1 �� 
TargetType �� 
TargetType	 ��Name
 �� CornerRadius ��Name �� Triggers P� Property P� Value �� 
TargetName��%J  &	        &	 �     &	 �     &	 �     &	     &	 6    &	 Y    &	 |    &	 �    &		 �    &	
 �    7   7  7  7  7  7  7  7  7  7 	 �� 5   
   .�5      ��  � �� 5      �� 5      .R�5      �� $��2q�6$   $	 1 2R�6/   #��� ��6E    . $��1��6�   5      5      5      �� 5   
   $ 	#FFDDDDDD��6;   �� 5   
   $ 	#FF707070��67   �� 5   
   $ 	#FFBEE6FD��6>   �� 5   
   $ 	#FF3C7FB1��6:   �� 5   
   $ 	#FFC4E5F6��6<   �� 5   
   $ 	#FF2C628B��68   �� 5   
   $ 	#FFF4F4F4��6=   �� 5   
   $ 	#FFADB2B5��69   �� 5   
   $ 	#FF838383��6=   �� 5   
   " ��6%   .�5      ��  �@�FocusVisualStyle8   61   �� 5       � ��8  6+   �� 5        � ��8  6,   �� 5!       � ��# � ��6+   �� 5"       � ��$ 1q�60   �� 5#       � ��$ Center=�6;   �� 5$       � ��$ Center=�69   �� 5%       � ��$ 1q�6(   �� 5&       � �� 5'      �� 5(      " ��6&   .R�5)      �� $	 border��63   $
 10��6!   #��z��6C   #��z��6m   #��z��6�    . ._�5*      �� $ contentPresenter��6/   |�.  #��z��6[   #��z��6�   ��. # z 6�   #��z��6  5+       5,      P� 5-       �@��IsDefaulted . . �5.   "   �� $ border��6@   # � ��6T    � ��5/      P� 50       �@J�IsMouseOver . . �51   "   �� $ border��6?   8   � ��6S   �� 52   "   $ border��6@   8   � ��6T   53      P� 54       � �� . . �55   "   �� $ border��6?   8   � ��6S   �� 56   "   $ border��6@   8   � ��6T   57      P� 58       � {� .  . �59   "   �� $ border��6?   8   � ��6S   �� 5:   "   $ border��6@   8   � ��6T   �� 5;   "   $ contentPresenter��6K   8 	  � ��6i   5<      5>      5@      5A      5B      .��5E      �� .��5F   
   � ���	#FFFFFCF0.+�5G      �� $��Логин ��6   $
��Left=�6%   $��	24,27,0,0q�6@   $	��Top=�6S   $
��Bold"�6k   $��18(�6}   �� 5H      $��Запрос��6   $
��Left=�6%   $��
158,27,0,0q�6@   $	��Top=�6T   $
��Bold"�6l   $��18(�6~   �� 5I      $#��Одобрение/отказ��6   $
��Left=�6.   $��
340,27,0,0q�6I   $	��Top=�6]   $
��Bold"�6u   $��18(�6�   �� 5J      -   5         ��Name$ userName��5J      $�� ��6&   $
��Left=�61   $��	24,66,0,0q�6L   $	��Top=�6_   �� 5K      -   5        $	 req��5K      $�� ��6!   $
��Left=�6,   $��
158,66,0,0q�6G   $	��Top=�6[   �� 5L      $X��R Введите id пользователя для одобрения/отказа��6   $
��Left=�6L   $��
340,66,0,0q�6g   $	��Top=�6{    J� RenderTransformOrigin$ 0.559,0.493&�6�   �� 5M      -   5         ��Name$ nameTextBox��5M      $
��Left=�6+   $��344,108,0,0q�6F    �� TextWrapping$
 Wrap=�6[   $	��Top=�6o   $	��134��6�   $��25��6�   �� 5N      -   5        #��� 
 5N      $��Одобрить��6<   $
��Left=�6O   $��464,172,0,0q�6j   $	��Top=�6   $��32��6�   $��73��6�   ���	#FFD8FBBD6�   �� 5O      -   5        #��� 
 5O      $��Отказать��6<   $
��Left=�6O   $��542,172,0,0q�6j   $	��Top=�6   $��32��6�   $��73��6�   ���	#FFFBBDBD6�   5Q      5R      5T      