   M S B A M L   `   `   `  ����H  DWpfEscapeGame, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:WpfEscapeGameWpfEscapeGame  5   	       WpfEscapeGame.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:WpfEscapeGame     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      � .+�5
   
   �� -   5         ��Name$ txtRoomDesc��5
       �� Padding$ 10,10,10,10q�6)   $
��Left=�6?   $��63��6Z   $��	24,10,0,0q�6f   $
��Wrap=�6y   $	��Top=�6�   $	��743��6�   $��16(�6�   ���	#FFF9F5F56�   �� 5   
   -   5         ��Name$ 
lblMessage��5      $��10,10,10,10q�6$   $�� ��6:   $
��Left=�6E   $��45��6`   $��	24,85,0,0q�6l   $	��Top=�6   $	��743��6�   ���	#FFF9F5F5$��16(�6�   ���	#FF0000996�   �� 5   
   $��
Room items��6   $
��Left=�6%   $��26��6@   $��
24,150,0,0q�6L   $	��Top=�6`   $	��112��6x   �� 5   
   -   5         ��Name$ btnCheck��5      $��<- CHECK��6#   $
��Left=�69   $��35��6T   $��313,176,0,0q�6`   $	��Top=�6u   $	��161��6�   ${�False��6�   6�   �� 5   
   -   5        $ 	btnPickUp��5      $��
PICK UP >>��6$   $
��Left=�6?   $��35��6Z   $��313,256,0,0q�6f   $	��Top=�6{   $	��161��6�   ${�False��6�   6�   �� 5   
   -   5        $ btnDrop��5      $
��DROP��6"   $
��Left=�61   $��35��6L   $��313,296,0,0q�6X   $	��Top=�6m   $	��161��6�   ${�False��6�   6�   �� 5   
   -   5        $ btnUseOn��5      $��<- USE ON ->��6#   $
��Left=�6@   $��35��6[   $��313,216,0,0q�6g   $	��Top=�6|   $	��161��6�   ${�False��6�   6�   �� 5   
   -   5         ��Name$ lstRoomItems��5      $
��Left=�6(   $	��155��6C   $��
24,176,0,0q�6P   $	��Top=�6d   $	��234��6|   6�   �� 5   
   $��Picked up items��6   $
��Left=�6*   $��26��6E   $��528,150,0,0q�6Q   $	��Top=�6f   $	��112��6~   �� 5   
   -   5        $ 
lstMyItems��5      $
��Left=�6&   $	��155��6A   $��528,176,0,0q�6N   $	��Top=�6c   $	��239��6{   6�   5      5      