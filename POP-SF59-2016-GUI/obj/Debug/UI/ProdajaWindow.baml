   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5   	   L HPOP-SF59-2016-GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:POP_SF59_2016_GUI.UIPOP_SF59_2016_GUI.UI 5   	   (   "POP_SF59_2016_GUI.UI.ProdajaWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6sys&clr-namespace:System;assembly=mscorlib     5   	   4local"clr-namespace:POP_SF59_2016_GUI.UI     5   	     � Title$  ProdajaWindow��5	   	   $��639.026��6   $	��387��60   .��5
      � .+�5   
   �� $��0��6   $��0��6   $��Datum prodaje��6-   $��
8,32,0,527q�6E   $
��Left=�6Y   $��Center=�6t   $��49��6�   $	��117��6�   �� 5   
   $��127,35,10,541q�5   3   ��5      ��  �� Today �� Source# Z  �� StringFormat$ {0:dddd, MMMM dd, yyyy}��5   3   �� 5   
   $��0��6   $��0��6   $��Kupac��6-   $��
8,86,0,473q�6=   $
��Left=�6Q   $��Center=�6l   $��49��6�   $	��117��6�   �� 5   
   -   5         ��Name$ tbKupac��5      $��127,86,10,485q�6#   $	��242��6:   $��37��6F   $
��Left=�6i   ��6R   �� *Kupac+6i   �� 5   
   $��0��6   $��0��6   $��Broj racuna��6-   $��8,140,0,419q�6C   $
��Left=�6X   $��Center=�6s   $��49��6�   $	��117��6�   �� 5   
   -   5        $ tbBrojRacuna��5      $��127,135,10,436q�6(   $	��242��6@   $��37��6L   $
��Left=�6t   ��6X   �� *
BrojRacuna+6t   �� 5   
   $��0��6   $��0��6   $��Namestaj za prodaju��6-   $��8,194,0,365q�6K   $
��Left=�6`   $��Center=�6{   $��49��6�   $	��117��6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ 
dgNamestaj��5   m      CanUserAddRows .     CanUserDeleteRows .     AutoGenerateColumns .  $��0��6`   $��127,194,10,280q�6�   	 �� SelectedItem	 6�   �� 
 �� Path$
 NamestajZaProdajuId��� 5   
   -   5        $��Dodaj��5      $��36,224,295,358q�6!   $��10(�69   6G   �� 5   
   -   5        $��Sacuvaj��5      $��40��6#   $��80��6/   $��155,534,144,34q�6:   6R   �� 5   
   -   5        $��Izadji��5      $��40��6"   $��80��6.   $��273,534,26,34q�69   6P   �� 5   
   $��0��6   $��0��6   $��Dodatne usluge��6-   $��8,353,0,206q�6F   $
��Left=�6[   $��Center=�6v   $��49��6�   $	��117��6�     5   
   -   5        $ dgUsluge��5   m    .   .   .  $��0��6`   $��127,353,10,121q�6   	 6�   �� *NamestajZaProdajuId+�� 5   
   -   5        $��Dodaj��5      $��36,383,295,199q�6!   $��10(�69   6G   �� 5   
   -	   5        $��Obrisi��5      $��36,269,295,313q�6"   $��10(�6:   6H   �� 5   
   -
   5        $��Obrisi��5      $��36,429,295,153q�6"   $��10(�6:   6H   5      5      