   M S B A M L   `   `   `  ����G  CКурсач, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:КурсачКурсач  5   	       Курсач.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Курсач     5   	     � Title$  
MainWindow��5   	   $	��610��6   $
��1100��6)    � 	Resources 5	         ScrollTrumbs �� 
TargetType �� Property �� Value �Name ��Name �� CornerRadius �� Triggers	 P� Property
 P� Value �� 
TargetName�� 5
   
   %�  &	        �� 5      " n�6)   .�5      ��  � �� 5      �� 5      .R�5      � $
 Grid��6#   .+�5   "   �� $��Stretch=�6,   $��Stretch=�6J   $
��Auto��6f   �� 5   "   $ Retangle��6)   $ 10��6;   6O   5       5      P� 5   "   	 �@�Tag$
 
Horizontal��69   . �5   &   �� $ Retangle��6-    � ��$
 auto��6T   �� 5   &   $ Retangle��6-    � ��$ 7��6U   5   #   5      5      5      5      .��5      � -   5        $
 grid��5       J� RenderTransformOrigin$ 0.5,0.5&�6   ���	#FFFFF8D6 � RowDefinitions 5    
   �� 5!      $��60 �6   �� 5"      $��* �6   .+�5$   
   � $��0��6   ���	#4C000000.+�5%      �� -   5        $��Корзина��5%      $
��Left=�6'   $��	852,0,0,0q�6B   $��Center=�6U   $��22��6p   $��74��6|   6�   �� 5&      -   5         ��Name$
 user��5&      $��Профиль��6#   $
��Left=�65   $��10,0,0,0q�6P   $��Center=�6b   $��22��6}   $��61��6�   6�   �� 5'      -   5         ��Name$ _balanse��5'      $��Кошелёк ��6&   $
��Left=�69   $��71,0,0,0q�6T   $��Center=�6f   $��24��6�   $	��108��6�   �� 5(      -   5        $
 back��5(      $��<-��6#   $
��Left=�63   $��	827,0,0,0q�6N   $��Center=�6a   $ 0.073,-0.026&�6|   $��20��6�   6�   �� 5)      -   5        $��Button��5)      $
��Left=�6&   $��	690,0,0,0q�6A   $��Center=�6T   $��92��6o   6z   �� 5*      -   5        $��+��5*      $
��Left=�6!   $��	216,0,0,0q�6<   $��Center=�6O   $��26��6�   $
��Bold"�6�   5+      � 5,   
   $��1��6   .+�5-       � -   5        $	��LOL��5-        � NavigationUIVisibility$ Hidden=�6   5.      51      53      