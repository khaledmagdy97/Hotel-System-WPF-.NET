   M S B A M L   `   `   `  ���� L  HHOTEL PROJECT WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:HOTEL_PROJECT_WPFHOTEL_PROJECT_WPF      HOTEL_PROJECT_WPF.Kitchen   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     1localclr-namespace:HOTEL_PROJECT_WPF     -     � Title$  Kitchen��$	��619��$	��997�� � WindowStartupLocation$ CenterScreen=�.���  � ColumnDefinitions �� $
��425* ��� $	��11* � � RowDefinitions �� $
��0.2* ��� $
��0.8* �.+��� $��Room Service��$��0��$
��Bold"�$��35(�
���   �
�������$��2���� ���	#FFACE0A0$��2��$��	0,110,0,0q�$��2��.@��� -   $��TODO*��$��30(����	#FFE9160E���	#FF0F0F0F$��46��$��
-2,-2,-2,0q�$	��Top=�.��� ����  �� EndPoint$ 0.5,1&� �� 
StartPoint$ 0.5,0&�.���  � Color$ Black��� $ White�� � Offset$ 1Q�.+��� $��
First Name��$
��Left=�$��5,33,0,0q�$	��Top=�$��18(�
��������� $��	last Name��$
��Left=�$��6,68,0,0q�$	��Top=�$��18(�
��������� -    ��Name$ fnameTextBox��$
��Left=�$��
106,37,0,0q�	 �� TextWrapping$
	 Wrap=�$	��Top=�$	��120��$��18(��� -   $ lnameTextBox��$
��Left=�$��
106,77,0,0q�$
	 Wrap=�$	��Top=�$	��120��$��18(��� $��Phone��$
��Left=�$��	5,130,0,0q�$	��Top=�$��18(��� -   $ phoneTextBox��$
��Left=�$��105,139,0,0q�$
	 Wrap=�$	��Top=�$	��221��$��18(��� $��	Room type��$
��Left=�$��	8,198,0,0q�$	��Top=�$��18(��� $��Phone��$
��Left=�$��	5,130,0,0q�$	��Top=�$��18(�
��������� $��Floor#��$
��Left=�$��202,200,0,0q�$	��Top=�$��18(��� $��Room Number��$
��Left=�$��	8,295,0,0q�$	��Top=�$��18(��� -   
 ��Name$
 RoomTypeComboBox��$��7,231,794,163q�#��� ��#��� ��$��14(�$
��Bold"�
���   �4  .System.Windows.Automation.AutomationProperties   IsRequiredForForm$
 True���� -   $
 FloorComboBox��$��206,231,615,162q�#��� ��#��� ��$��14(�$
��Bold"�
���   �$
 True���� -   $
 RoomNumberTypeComboBox��$��15,325,621,66q�#��� ��#��� ��$��14(�$
��Bold"�
���   �$
 True���� $
��TODO��$��388,25,306,17q�$��18(�
���  ���� $��Special Needs��$��0�����	#FFEE1A1A$��14(�$��386,187,368,194q� J� RenderTransformOrigin$ 0.5,0.5&�z�V� .~��� �� ��  �� Angle$ 0.122Q�T� �� -	    ��Name$ cleanningWindow��$��Cleaning�����	#FF424141$��14(�$��396,222,372,179q��� -
   $ towelWindow��$��Towels�����	#FF424141$��396,258,355,139q�$��14(��� -   $ surpriseWindow��$��Sweatest Surprise�����	#FF424141$��396,292,314,108q�$��14(��� -    ��Name$ 	UpdateBtn��$��change food selection��$��410,351,320,37q�
�������
�������$
��Bold"� � Cursor$
 Hand��$��17(� J� OpacityMask �� $ 0.5,1&�$ 0.5,0&�.��� $ Black��� $ 	#FF453434��$ 1Q����� $ 0.5,1&�$ 0.5,0&�.��� $ Black��� $ 	#FF68E016��$ 1Q��� -    ��Name$
 List��$��703,37,7,68q�$��13(��� -   $ 	updateBtn��$��Update��$��769,380,78,6q�
�������
�������$
��Bold"�$
 Hand��$��14(� �� $ 0.5,1&�$ 0.5,0&�.��� $ Black��� $ 	#FF453434��$ 1Q����� $ 0.5,1&�$ 0.5,0&�.��� $ Black��� $ 	#0068E016��$ 1Q��� -   $��Overview��$��30(����	#FFF30B03
���   �.��� 
���   �.+�&   System.Windows.Controls.DataGrid  -     Name$ dataGridRooms��$��114,74,120,78q�$��15(�   HorizontalGridLinesBrush
 �  ��   VerticalGridLinesBrush
 ������� -   $ breakfastWindow��$��Breakfast (7$)��$��1��$��0��
 �   �
�������$��402,96,370,340q�$��14(��� -   $ lunchWindow��$��lunch (27$)��$��1��
 �   �
�������$��535,97,243,345q�$��14(��� -   $ breakfastNumberWindow��$��1��$��0��$��404,128,443,310q�$��
Quantity ?��
 �   �$��14(��� -   $ lunchNumberWindow��$��1��$��534,126,317,309q�$��
Quantity ?��
 �   �$��14(��� -   $ dinnerWindow��$��Dinner (17$)��$��1��$��0��
 �   �
�������$��14(�$��402,167,374,276q��� -   $ dinnnerNumberWindow��$��1��$��0��$��404,193,442,243q�$��
Quantity ?��
 �   �$��14(�