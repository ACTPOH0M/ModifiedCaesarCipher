   M S B A M L   `   `   `  ����O  KModifiedCaesarCipher, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:ModifiedCaesarCipherModifiedCaesarCipher  5   	   %    ModifiedCaesarCipher.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:ModifiedCaesarCipher     5   	     � Title$  Modified Caesar Cipher��5   	   $	��650��6(   $	��610��65   .��5	      � 
�������.+�5
   
   �� -   5         ��Name$ shifrButton��5
   '   $��Зашифровать��6   $��14(�6V   $
��Left=�6d   $��	10,10,0,0q�6   $	��Top=�6�   $��30��6�   $	��150��6�   �� 5   
   -   5        $ unshifrButton��5   '   $��Расшифровка��6   $��14(�6Z   $
��Left=�6h   $��	10,45,0,0q�6�   $	��Top=�6�   $��30��6�   $	��150��6�   �� 5   
   -   5         ��Name$ textBox��5   -   $
��Left=�6   $��14(�6>   $��
181,12,0,0q�6L    �� TextWrapping$
 Wrap=�6`   $��Введите текст��6t   $	��Top=�6�   $	��210��6�   $	��400��6�   �� 5   
   $��	Итог:��6   $��24(�6    $
��Left=�6.   $��181,227,0,0q�6I   $	��Top=�6^   �� 5   
   -   5        $ result��5   -   $
��Left=�6   $��14(�6=   
������� �� 
IsReadOnly$
 True��6^   $��181,274,0,0q�6p   $
 Wrap=�6�   $	��Top=�6�   $	��316��6�   $	��400��6�   �� 5   
   $��Часовой пояс��6   $��18(�6'   $
��Left=�65   $��	10,81,0,0q�6P   $	��Top=�6c   �� 5   
   -   5         ��Name$ listOfTimeZones��5   .   $
��Left=�6   $��
10,122,0,0q�6G   $	��Top=�6[   $	��150��6s   $��30��6�   �� 5   
   -   5        $��?��5      $
��Left=�6   $��
10,227,0,0q�6Y   $��25��6m   $��25��6y   $	��Top=�6�   �� 5   
   -   5        $��Выбрать файл��5      $	��150��6?   $��30��6K   $��
10,157,0,0q�6W   $	��Top=�6k   $
��Left=�6�   �� 5   
   -   5        $$��Сохранить в файл��5      $	��150��6C   $��30��6O   $��
10,192,0,0q�6[   $	��Top=�6o   $
��Left=�6�   5      5      