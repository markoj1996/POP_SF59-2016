   M S B A M L   `   `   `  ����L  HPOP-SF59-2016-GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:POP_SF59_2016_GUI.UIPOP_SF59_2016_GUI.UI  5   	   (    "POP_SF59_2016_GUI.UI.DetaljiWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:POP_SF59_2016_GUI.UI     5   	     � Title$  DetaljiWindow��5   	   $	��550��6   $��386.842��6,   .��5	      � .+�5
   
   �� $��Datum prodaje��6   $��10,25,267,458q�6(   $	��102��6?   $��36��6K   �� 5   
   -   5         ��Name$ tbDatum��5      $��117,28,10,461q�6#    �� 
IsReadOnly . $��30��6L   $	��252��6X   $
��Left=�6�   ��6d   �� *DatumProdaje+6�   �� 5   
   $��Kupac��6   $��10,76,267,407q�6    $	��102��67   $��36��6C   �� 5   
   -   5        $ tbKupac��5      $��117,79,10,410q�6#    . $��30��6L   $	��252��6X   $
��Left=�6{   ��6d   �� *Kupac+6{   �� 5   
   $��Broj racuna��6   $��10,133,267,350q�6&   $	��102��6>   $��36��6J   �� 5   
   -   5        $ tbBrojRacuna��5      $��117,136,10,353q�6(    . $	��252��6R   $��30��6^   $
��Left=�6�   ��6j   �� *
BrojRacuna+6�   �� 5   
   $��Namestaj��6   $��10,188,267,295q�6#   $	��102��6;   $��36��6G   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ 
dgNamestaj��5   r      
IsReadOnly .    CanUserAddRows .     CanUserDeleteRows .     AutoGenerateColumns .  $��117,189,10,230q�6�   $	��252��6�   $	��100��6�    �� SelectedItem 6�   �� *NamestajZaProdajuId+�� 5   
   $��Dodatne usluge��6   $��10,310,267,173q�6)   $	��102��6A   $��36��6M     5   
   -   5        $ dgUsluge��5   r    .  .   .   .  $��117,311,10,108q�6�   $	��252��6�   $	��100��6�    6�   �� *DodatneUsluge+�� 5   
   $��Ukupna Cena��6   $��10,432,267,51q�6&   $	��102��6=   $��36��6I   �� 5   
   -   5        $ tbUkupnaCena��5      $��117,432,10,57q�6(    . $	��252��6Q   $��30��6]   $
��Left=�6i   �� 5   
   -   5        $��Izadji��5      $��274,482,10,10q�6"   69   5      5      