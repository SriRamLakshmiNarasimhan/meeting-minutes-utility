   M S B A M L   `   `   `  ����P  LMeetingMinutesUtility, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:MeetingMinutesUtilityMeetingMinutesUtility  5   	   *    $MeetingMinutesUtility.MeetingSummary   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:MeetingMinutesUtility     5   	   -   5          � Title$  Meeting Minutes Utility��5   	    � WindowStartupLocation$ CenterScreen=�6)   $	��500��6N   $	��500��6[    � AllowsTransparency .  � WindowStyle$
 None=�6�   ��5	      �� 5
   
    �� Opacity$	 0.8Q�6    �� Color$ Lavender��6(   .��5      � .+�5   
   �� -   5         ��Name$ _headingLabel��5      $��Meeting Summary��6'   $��Script MT Bold)�6A   $��36(�6]   $��Center=�6k   $��0,40,0,0q�6�   $	��Top=�6�   
����  �6�   �� 5   
   -   5         ��Name$ image��5      $
��Left=�6   $	��100��6:   $��300,105,0,0q�6G   $	��Top=�6\   $	��100��6t   �� 5   
   -   5        $ _sentimentalAnalysisLabel��5      $��Sentimental Analysis��63   $��Script MT Bold)�6R   $��25(�6n   $
��Left=�6|   $��
50,130,0,0q�6�   $	��Top=�6�   
����  �6�   �� 5   
   -   5         ��Name$ textBox��5      $��Center=�6#   $	��200��6@   $��	0,230,0,0q�6M   	 �� TextWrapping$
	 Wrap=�6`   $�� ��6t   $	��Top=�6|   $	��400��6�   6�   �� 5   
   -   5        $ _summaryLabel��5      $��Meeting Minutes��6'   $��Script MT Bold)�6A   $��25(�6]   $
��Left=�6k   $��
50,190,0,0q�6�   $	��Top=�6�   
����  �6�   �� 5   
   -   5        
 ��Name$
 
_playAudio��5      $��
Play Audio��6%   $��Script MT Bold)�6:   $��12(�6V   $��75��6d   
����  � � ToolTip$ Play recording��6�    � Cursor$
 Hand��6�   $
��Left=�6�   $��50,450,375,0q�6�   $	��Top=�6�   6�   �� 5   
   -   5        $
 _textConversion��5      $��Complete Text��6*   $��Script MT Bold)�6B   $��12(�6^   
����  �$��Center=�6�   $��	0,450,0,0q�6�   $	��Top=�6�   $��75��6�   6�   �� 5   
   -	   5        $
 _exit��5      $
��Exit��6    $��Script MT Bold)�6/   $��12(�6K   
����  �$��Right=�6p   $��
0,450,50,0q�6�   $	��Top=�6�   $��75��6�   6�   5      5      