   M S B A M L   `   `   `  ����D  @WpfPazzle, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:WpfPazzle	WpfPazzle  5   	       WpfPazzle.MainWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:WpfPazzle     5   	   -   5        $��window��5   	     � Title$  
MainWindow��5	   	   $	��450��6   $	��800��6)   .��5
      �  � RowDefinitions 5   
   �� 5      $��40 �6   �� 5      �� 5      $��40 �6   .+�5   
   ��  �� ContentStringFormat$ 
Time : {0}��6)   ��6   �� *Time+6)   �� 5   
   $��1��6   ��6$   �� *Parts+��5      �� 5      .R�5      A�  A� Rows$ 4��6"    A� Columns$ 6��6+   5      ��5      �� 5      .R�5      �� ��6   ��  �� ElementName$ window�� �� Path$ DataContext.ClickCommand���6c   �� .��5      �� $
��Fill=�6    ��6/   �� *Path+5      5      5!      ]� 5#   
   $��2��6   $��false��6!   .+�5$      o� $
��Left=�6   $��40��6)   $��30��64   $��5q�6@   .@�5%      m� $
��Menu��6   .@�5&      m� $��Start��6   .@�5'      m� $��Forest��6#    m� Command 63   �� *ChoiseImageForest+m� 5(      $
��Lake��6#    61   �� *ChoiseImageLake+m� 5)      $��	Waterfall��6#    66   �� *ChoiseImageWaterfall+5*      5+      5,      �� 5-      $
��Left=�6   $��40��6+   $��5q�66   ��6A   �� $ window��$! DataContext.ClickButtonShow�.��6�   Show6�   5.      5/      50      