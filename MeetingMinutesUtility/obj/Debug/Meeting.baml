   M S B A M L   `   `   `  ����P  LMeetingMinutesUtility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:MeetingMinutesUtilityMeetingMinutesUtility  5   	   #    MeetingMinutesUtility.Meeting   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:MeetingMinutesUtility     5   	   -   5          � Title$  Meeting Minutes Utility��5   	    � WindowStartupLocation$ CenterScreen=�6)   $	��500��6N   $	��500��6[    � AllowsTransparency .  � WindowStyle$
 None=�6�   ��5	      �� 5
   
    �� Opacity$	 0.8Q�6    �� Color$ Lavender��6(   .��5      � .+�5   
   �� -   5         ��Name$ _headingLabel��5      $��Meeting Details��6'   $��Script MT Bold)�6A   $��36(�6]   $��Center=�6k   $��0,40,0,0q�6�   $	��Top=�6�   
����  �6�   �� 5   
   -   5        $ _meetingNameLabel��5      $��Meeting Name��6+   $��Script MT Bold)�6B   $��25(�6^   $
��Left=�6l   $��
50,130,0,0q�6�   $	��Top=�6�   
����  �6�   �� 5   
   -   5        $ _meetingHostLabel��5      $��Meeting Host��6+   $��Script MT Bold)�6B   $��25(�6^   $
��Left=�6l   $��
50,230,0,0q�6�   $	��Top=�6�   
����  �6�   �� 5   
   -   5        $ _durationLabel��5      $��Remaining Time��6(   $��Script MT Bold)�6A   $��25(�6]   $
��Left=�6k   $��
50,330,0,0q�6�   $	��Top=�6�   
����  �6�   �� 5   
   -   5        $ _meetingNameLabel_Value��5      $�� ��61   $��Script MT Bold)�6<   $��25(�6X   $
��Left=�6f   $��250,130,0,0q�6�   $	��Top=�6�   
����  �6�   �� 5   
   -   5        $ _meetingHostLabel_Value��5      $�� ��61   $��Script MT Bold)�6<   $��25(�6X   $
��Left=�6f   $��250,230,0,0q�6�   $	��Top=�6�   
����  �6�   �� 5   
   -   5        $ _durationLabel_Value��5      $�� ��6.   $��Script MT Bold)�69   $��25(�6U   $
��Left=�6c   $��250,330,0,0q�6~   $	��Top=�6�   
����  �6�   �� 5   
   -	   5         ��Name$ button��5      $��End Meeting��6!   $��Script MT Bold)�67   $��12(�6S   $��Center=�6b   $��	0,415,0,0q�6   $	��Top=�6�   $��75��6�   
����  � � ToolTip$ Ends meeting��6�   	 � Cursor$
	 Hand��6�   6�   �� 5   
   -
   5        $ _informationLabel��5      $��9(�6+   $I��C*Note: For training purposes, entire meeting audio may be recorded.��68   $
��Left=�6�   $��
50,450,0,0q�6�   $	��Top=�6�   
����  �6�   5      5      