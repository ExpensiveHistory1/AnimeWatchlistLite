   M S B A M L   `   `   `  ����M  IAnimeWatchlistLite, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:AnimeWatchlistLiteAnimeWatchlistLite  5   	   M+clr-namespace:AnimeWatchlistLite.ConvertersAnimeWatchlistLite.Converters  5   	   #    AnimeWatchlistLite.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:AnimeWatchlistLite     5   	   B
converters+clr-namespace:AnimeWatchlistLite.Converters     5   	     � Title$  Anime Watchlist��5	   	   $	��465��6!   $	��800��6.    � Icon$ results.png��6:    � 	Resources 5
      8   2AnimeWatchlistLite.Converters.BoolToColorConverter   BoolToColor��%   &	          5   
   6*   5      .��5      � ��6   �� *Settings.DarkMode+ �� 	Converter# [   � ColumnDefinitions 5   
   �� 5      $��0.35* �6   6/   �� 5      $��* �6   6+    � RowDefinitions 5   
   �� 5      $
��Auto �6   6,   �� 5      $��* �6   6)   .+�5   
   ]� .+�5      o� 
���   � � Cursor$
 Hand��6w   ��6   �� *Settings.DarkMode+# [  .@�5      m� $��General��6   
�������
���   �.@�5      m� $��Settings��6    m� Command 61   �� *OpenSettingsCommand+6[   5      5      5      �� 5      $��0��6   $��10q�6)   .+�5      �� 
���   �$��0,5,0,0q�6'   .��68   Titel:6@   �� 5      ��6   �� *
AnimeTitel+ �� Mode$ TwoWay=�	 �� UpdateSourceTrigger$	 PropertyChanged=�.��6d   
 J� InputBindings
 5       �� 5!      
 �� Key$ Enter��6!    �� Command 6-   �� *AddToDBCommand+6R   .��5"   )   5#      �� 5$      $
 Hand��6   $��0,10,0,0q�6$   ��66   �� *AddToDBCommand+.��6Y   Hinzufügen6e   5%      �� 5&   
   $��1��6   
�������$��5q�69   .+�5'      �� $
 Hand��6   $��	5,10,5,10q�6#   $��40��66   $
��Alle��6h   ��6B   �� *SortAnimesCommand+.��6�   Alle6�   �� 5(      $
 Hand��6   $��5,0,5,10q�6#   $��40��65   
�������$��Alphabet��6�   ��6Z   �� *SortByAlphabetCommand+.��6�   Alphabetisch6�   �� 5)      $
 Hand��6   $��5,0,5,10q�6#   $��40��65   
������$��Watched��6   ��6Y   �� *SortAnimesCommand+.��6�   	Watched6�   �� 5*      $
 Hand��6   $��5,0,5,10q�6#   $��40��65   
���\\��$��	Unwatched��6~   ��6X   �� *SortAnimesCommand+.��6�   	Unwatched6�   �� 5+      $
 Hand��6   $��5,0,5,10q�6#   $��40��65   
����ح�$��
InProgress��6~   ��6X   �� *SortAnimesCommand+.��6�   In Progress6�   �� 5,      $
 Hand��6   $��5,0,5,10q�6#   $��40��65   
��� ���$��Waiting��6{   ��6U   �� *SortAnimesCommand+.��6�   	Waiting6�   5-      �� 5.   
   $��1��6   .+�5/      �� $��0,15,0,0q�6   
���   �.��69   Suche:6A   �� 50      $��5,0,20,0q�6   ��6(   �� *Search+$ TwoWay=�$	 PropertyChanged=�.��6r   
 51      �� 52      $ Enter��6!    6-   �� *SearchDbCommand+6S   .��53   )   54      �� 55      $
 Hand��6   $��
5,10,20,10q�6H   ��6$   �� *SearchDbCommand+.��6\   Suchen6d   56      �� 57   
   $��Visible=�6   $��1��6=   $��1��6J   
�������$��5q�6q   .��58      �� $��1��6   $��1��6+   ��68   �� *AnimeCollection+��59      �� 5:      .R�5;      � 6&   5<      ��5>      �� 5?      .R�5@      �� 
���   �$��1q�65   $	��130��6I   $	��180��6U   $��10q�6b   ._�5A      �  5B   "   �� 5C   &   $	��140 �64   6C   �� 5D   &   $��20 �64   6B   �� 5E   &   $��20 �64   6B   .+�5G   "   �� $	��130��6)   $	��140��65   
 5H   &   d� 5I   *    d� Gesture$ LeftDoubleClicka�67    6Q   ��  �� RelativeSource ��  �� AncestorType" �� �� Path$! DataContext.PicClickCommand� �� CommandParameter 6�   �� 6�   .��5K   &   �� -   5         J� 	AllowDrop . ��5K   ,   �� *
BildSource+6�   5L   #   �� 5M   "   $��5,0,0,0q�6,   $��1��6=   $
��Bold"�6J   ��6\   �� *Titel+6u   �� 5N   "   $��2��6(   ��65   �� *Status_Image+6W   5O      5P      5Q      5S      5T      5U      5V      