   M S B A M L   `   `   `  ����D  @LabWork10, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:LabWork10	LabWork10  5   	       LabWork10.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:LabWork10     5   	   -   5          � Title$  
MainWindow��5   	   $	��720��6   $
��1080��6)   .��5      �  � RowDefinitions 5   
   �� 5      �� 5      $��40 �6   .+�5   
   '�  '� Camera 5      =� 5      -   5        
MainCamera�� � Position$ 0, 0, 21�5   8    � LookDirection$ 
0, 0, -4.15�6K   x�5      g� 5       g� Content 5      t� 5       �� Color$ White��6+    t� 	Direction$ -1.4, -1, -25�69   5      g� 5       5      � 5        � Geometry 5"      k� 5#   "   -   5        My3d��	 k� 	Positions&	 �   �^���^�� �  � �^��
 k� TriangleIndices
 �    5#   p    � Material 5(      �� 5)   "   .��5*   &   u�  u� Brush
 �����66   �� 5+   &    �� Brush
 ����� �� SpecularPower$ 75Q�6F   5,   #   5.       g� 	Transform 50      �� 51       �� Rotation 52      �� 53   "   -   5        
rotate�� �� Axis$ 0 0 05�53   F    �� Angle$ 10Q�6S   55      57      59      � 5;   
   $��2��6    � ColumnDefinitions 5<      �� 5=      $��4* �6#   �� 5>      $��* �6#   .+�5A      ��  � Minimum$
 -360Q�6    � Maximum$ 0Q�6$    � Value 60   ��  �� ElementName$ rotate�� �� Path$ Angle�� 5B      $��1��6    5C      �� 5D      �� 5E      �� 5F      .+�5I      � $��0��6    5J      �� 5K      �� 5L      .+�5N      �� $��Center=�6   $��Center=�6>   .��6b   X6e   �� 5O      -   5         ��Name$ 	isXRotate��5O       d� 	IsChecked$
 TrueY�62   $��1��6{   $
��40px��6�   $��Center=�6�   $��Center=�6�   $��20(�6�   5P      � 5R      $��1��6    5S      �� 5T      �� 5U      .+�5W      �� -   5         ��Name$
 test��5W      $��Center=�6*   $��Center=�6L   .��6p   Y6s   �� 5X      -   5        $ 	isYRotate��5X      $��1��6j   $
��40px��6z   $��Center=�6�   $��Center=�6�   $��20(�6�   5Y      � 5[      $��2��6    5\      �� 5]      �� 5^      .+�5`      �� $��Center=�6   $��Center=�6>   .��6b   Z6e   �� 5a      -   5        $ 	isZRotate��5a      $��1��6j   $
��40px��6z   $��Center=�6�   $��Center=�6�   $��20(�6�   5b      5c      5d      5e      5f      