   M S B A M L   `   `   `  ���� O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  L HPOP-SF59-2016-GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:POP_SF59_2016_GUI.UIPOP_SF59_2016_GUI.UI (   "POP_SF59_2016_GUI.UI.ProdajaWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6sys&clr-namespace:System;assembly=mscorlib     4local"clr-namespace:POP_SF59_2016_GUI.UI       � Title$  ProdajaWindow��$��639.026��$	��387��.��� .+��� $��0��$��0��$��Datum prodaje��$��
8,32,0,527q�$
��Left=�$��Center=�$��49��$	��117���� $��127,35,10,541q�����  �� Today �� Source# Z  �� StringFormat$ {0:dddd, MMMM dd, yyyy}���� $��0��$��0��$��Kupac��$��
8,86,0,473q�$
��Left=�$��Center=�$��49��$	��117���� -    ��Name$ tbKupac��$��127,86,10,485q�$	��242��$��37��$
��Left=����� *Kupac+�� $��0��$��0��$��Broj racuna��$��8,140,0,419q�$
��Left=�$��Center=�$��49��$	��117���� -   $ tbBrojRacuna��$��127,135,10,436q�$	��242��$��37��$
��Left=����� *
BrojRacuna+�� $��0��$��0��$��Namestaj za prodaju��$��8,194,0,365q�$
��Left=�$��Center=�$��49��$	��117��&   System.Windows.Controls.DataGrid  -     Name$ 
dgNamestaj��   CanUserAddRows .     CanUserDeleteRows .     AutoGenerateColumns .  $��0��$��127,194,10,280q�	 �� SelectedItem	 �� 
 �� Path$
 NamestajZaProdaju��� -   $��Dodaj��$��36,224,295,358q�$��10(��� -   $��Sacuvaj��$��40��$��80��$��155,534,144,34q��� -   $��Izadji��$��40��$��80��$��273,534,26,34q��� $��0��$��0��$��Dodatne usluge��$��8,353,0,206q�$
��Left=�$��Center=�$��49��$	��117��  -   $ dgUsluge�� .   .   .  $��0��$��127,353,10,121q�	 �� *NamestajZaProdajuId+�� -   $��Dodaj��$��36,383,295,199q�$��10(�