   M S B A M L   `   `   `  ����C  ?TestTask, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:TestTaskTestTask  5   	   O,clr-namespace:TestTask.Controls.ViewControlsTestTask.Controls.ViewControls  5   	       TestTask.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:TestTask     5   	   EViewControls,clr-namespace:TestTask.Controls.ViewControls     5   	     � Title$  
MainWindow��5	   	   $	��541��6   $	��801��6)    � 	Resources 5         UserControlStyle �� Property �� Value��%�   &	        �� 5   
   .�5      ��  � ��$	 400��63   �� 5       � ��$	 Top=�6>   �� 5       � ��$
 Left=�6@   �� 5       � ��$	 267��62   5      5      .��5      � $	��501��6   $	��801��6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   4   .TestTask.Controls.ViewControls.UserControlPart  -   5          Name$ Control1��5   '   $��0��69   #��[  6I    � DataContext 6s   ��  �� Path$ Control1�  5   
   -   5        $ Control2��5   '   $��1��69   #��[  6I    6s   �� $ Control2�  5   
   -   5        $ Control3��5   '   $��2��69   #��[  6I    6s   �� $ Control3��� 5   
   -   5         ��Name$ btnStartAll��5      $��3��6F   $��ЗАГРУЗИТЬ ВСЕ��6Z   $��	0,300,0,0q�6t   $	��200��6�   $��37��6�   $��17(�5      
�������$��Verdana)�64   	 � Cursor$
	 Hand��6I   ���#24752C��5   &   �� *BtnAllStart+5   W   � 5   
   -   5        
 �Name$
 pbStatus��5      $��3��6]    � Minimum$ 0Q�6q    � Maximum$	 100Q�6}   $
��Left=�6�   $��18��6�   $��185,443,0,0q�6�   $	��Top=�6�   $	��418��6�    � Value 6(   �� $ CurrentProgress� �� Mode$ OneWay=�6�   �� 5    
   -   5         ��Name$ lblLoad��5       $��3��6"   $��Загружено:��66   $��12(�6K   
���   �$��Verdana)�6l   $
��Left=�5!      $	��Top=�6+   $��296,466,0,0q�6C   �� 5"   
   -   5        $ checkProgress��5"      $��12(�6Z   
���   �$��Verdana)�6{   $
��Left=�5#      $	��Top=�6+   $��115.8,466,0,0q�6C   $��1��6Z   ��5"   '   �� $ CurrentValue�$ OneWay=�5#   Z   �� 5$   
   -   5        $ allProgress��5$      $��12(�6w   
���   �$��Verdana)�6�   $
��Left=�5%      $	��Top=�6+   $��164.8,466,0,0q�6C   $��1��6Z   ��5$   %   �� $ AllSize�$ OneWay=� �� UpdateSourceTrigger$ PropertyChanged=�5%   Z   5,      5-      