   M S B A M L   `   `   `  ����  WPFApplication1&     WPFApplication1.Views.MainWindow   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      E ACatel.MVVM, Version=5.5.0.0, Culture=neutral, PublicKeyToken=null+catelhttp://schemas.catelproject.com  5        � 
ResizeMode$  	CanResize=�5      .��5      � -   5         �Name$ 
LayoutRoot��5       � RowDefinitions 5   
   �� 5	      $
��Auto �6   �� 5
      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $��* �6   6+   �� 5      $��3* �6   6,   .+�5   
   �� $��0��6   $��0��6   ��6-   �� *Title+�� 5   
   $��1��6   $��0��6   $!��Here goes your real content��6-   �� 5   
   $��2��6   $��0��6"   .+�5      �� ��6   �� *Id+6,   �� 5      ��6   �� *Name+6.   �� 5       �� Orientation$ 
Horizontal=�6   .+�5      �� ��6   �� *
AddState+.��66   Add6;   �� 5      ��6   �� *
DelState+.��66   Del6;   �� 5      ��6   �� *RefreshStates+.��6;   	Refresh6D   5      5      &   System.Windows.Controls.DataGrid  5.   
   $��2��5/      $��1��50         AutoGenerateColumns .  ��51      �� *States+ �� SelectedItem 52      �� *
SelState+   Columns 54      0  *System.Windows.Controls.DataGridTextColumn  55      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6%   	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 90 6M   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 61   ��  �� Path$ Id�6M     56      $
 Name��6%   $	 80 6Q   
 63   �� $
 Name�6Q   58      59      5;      