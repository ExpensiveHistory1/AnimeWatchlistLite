   M S B A M L   `   `   `  ����M  IAnimeWatchlistLite, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:AnimeWatchlistLite.ViewsAnimeWatchlistLite.Views  5   	   M+clr-namespace:AnimeWatchlistLite.ConvertersAnimeWatchlistLite.Converters  5   	   )    #AnimeWatchlistLite.Views.EditWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:AnimeWatchlistLite.Views     5   	   B
converters+clr-namespace:AnimeWatchlistLite.Converters     5   	   -   5          �Name$  Edit_Window��5   	    � Title$ Bearbeitung��5
   	   $	��380��6   $	��300��6*    � Icon$ results.png��6M    � 	Resources 5      8   2AnimeWatchlistLite.Converters.BoolToColorConverter   BoolToColor��%   &	          5   
   6*   5      .��5      � ��6   �� *Settings.DarkMode+ �� 	Converter# [  .+�5   
   �� -   5        $��20,20,20,10q�5      .+�5      �� $	��140��6   $	��130��6"    � Cursor$
 Hand��6L   ��6.   �� *	UploadPic+.��5      �� $	��140��6=   $	��130��6J   ��6   �� *_anime.BildSource+6X   5      �� 5      .��6   Name:6   �� 5      ��6   �� *_anime.Titel+66   �� 5      .��6   	Status:6   � 5      $��0,10,0,0q�6   .+�5      �� $��Watched��67   
������
���   �$
 Hand��6�   ��6   �� *	selStatus+��6j   �� *WatchedBorder+.��6�   	Watched6�   �� 5      $��	Unwatched��67   
���\\��$��5,0,0,0q�6k   
���   �$
 Hand��6�   ��6   �� *	selStatus+��6|   �� *UnwatchedBorder+.��6�   	Unwatched6�   �� 5      $��
InProgress��67   
����ح�$��5,0,0,0q�6l   
���   �$
 Hand��6�   ��6   �� *	selStatus+��6}   �� *InProgressBorder+.��6�   
InProgress6�   �� 5      $��Waiting��67   
��� ���$��5,0,0,0q�6f   
���   �$
 Hand��6�   ��6   �� *	selStatus+��6w   �� *WaitingBorder+.��6�   	Waiting6�   5      �� 5      $��0,10,0,0q�6j   $
 Hand��6|   ��6   �� *saveChanges+��65   ��  �� ElementName$ Edit_Window��.��6�   	Speichern6�   �� 5      $��20��6k   
���  ��
�������$	��250��6�   $��0,10,0,0q�6�   $
 Hand��6�   ��6   �� *RemoveAnime+��65   �� $ Edit_Window��.��6�   	Entfernen6�   5      5      5       