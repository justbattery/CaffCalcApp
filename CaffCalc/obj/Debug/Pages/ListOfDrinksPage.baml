   M S B A M L   `   `   `  ����C  ?CaffCalc, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:CaffCalc.PagesCaffCalc.Pages  5      %    CaffCalc.Pages.ListOfDrinksPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:CaffCalc.Pages     5        N� Title$  ListOfDrinksPage��5	       N� 
Background
 �����.��5      �  � RowDefinitions 5   
   �� 5      $	��70* �6   �� 5      $
��auto �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dataGridOfDrinks��5   ,   $��0��6   $��20q�6       AutoGenerateColumns . 5      �� 5   
   $��1��6    �� Orientation$ 
Horizontal=�6"   .+�5      �� $	��200��6   $
��Left=�6%   $��10q�6@   .+�5      �� $��Dodaj napój��6   �� 5      $ 
Horizontal=�6   .+�5      �� $��Nazwa:��6    �� 5      -   5        $��	drinkName��5   <   $��10,0,0,0q�6   $	��100��60   6<   5      �� 5       $ 
Horizontal=�6   .+�5!      �� $��Pojemność:��6    �� 5"      -   5        $��drinkCapacity��5"   <   $��10,0,0,0q�6   $	��100��60   6<   5#      �� 5%      $ 
Horizontal=�6   .+�5&      �� $��Zawartość kofeiny:��6    �� 5'      -   5        $��drinkCaffeineContent��5'   <   $��10,0,0,0q�6   $	��100��60   6<   5(      �� 5*      $��Center=�6   $ 
Horizontal=�6:   .+�5+      	� -   5        $��per100mlRadio��5+   L    	� 	GroupName$ 
CaffeineMg��6"   $��Na 100ml��69    d� 	IsChecked$
 TrueY�6a   	� 5,      -   5        $��wholeCaffeineRadio��5,   _   $��10,0,0,0q�6"   $ 
CaffeineMg��64   $��
Całkowita��6K   6_   5-      �� 5.      -   5        $��addDrinkButton��5.   d   $��10q�6   $��Dodaj napój��6%   $	��100��6;   $��Center=�6G   6z   5/      �� 50      -   5        $��removeDrinkButton��50   B   $��50��6   $	��100��6!   $��Usuń napój��6-   6[   51      52      53      