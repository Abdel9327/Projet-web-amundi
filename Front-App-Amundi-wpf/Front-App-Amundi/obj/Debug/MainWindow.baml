   M S B A M L   `   `   `  ����K  GFront-App-Amundi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Front_App_AmundiFront_App_Amundi  5   	   I)clr-namespace:Front_App_Amundi.ConditionsFront_App_Amundi.Conditions  5   	   !    Front_App_Amundi.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:Front_App_Amundi     5   	   ?	converter)clr-namespace:Front_App_Amundi.Conditions     5   	     � Title$  Menu ��5	   	   $	��850��5
   	   $
��1800��5   	    � WindowStartupLocation$ CenterScreen=�5   	    � Icon$ Images/amundi_icon.ico��5   	   $��Century Gothic)�5   	    � 	Resources 5      2   ,Front_App_Amundi.Conditions.ConditionConvert   conditionConvert7   1Front_App_Amundi.Conditions.ConditionConvertGreen  conditionConvertGreen5   /Front_App_Amundi.Conditions.ConditionConvertRed  conditionConvertRed?  9Front_App_Amundi.Conditions.ConditionConvertHistorisation ! conditionConvertHistorisation �� 
TargetType �� Property �� Value �� 
TargetType �Name	 � RowDefinitions
 ��Name �� CornerRadius ]�Name ]� Thumb n�Name  ScrollBarTrackThumb ]� IncreaseRepeatButton ��Name J� Opacity ]� DecreaseRepeatButton �� Triggers P� 
SourceName P� Property P� Value �� 
TargetName �� Angle��%�
  &	        &	      &	 &     &	 9     '�� L     &	 �      5   
   6%     5   
   6*     5   
   6(     5   
   62   �� 5   
   " ��6   .�5      ��  �@��IsFlicksEnabled .  5      �� 5       � �� �#ADABAB5      �� 5       � ��
 ���� 5      �� 5        � ��$ 7��5!      �� 5"       � �� 5#      �� 5$      " ��6&   .R�5%      � $ GridRoot��6   #��z��5'      	 5(      �� 5)   "   $��0.00001* �60   .+�5+      �� $
 CornerScrollBarRectangle��6%   $ 5��5,   !   $��1q�62   ���#DCDCDC$��Stretch=�5-   !   $��Stretch=�5.   !   $
��Auto��5/   !   $
��Auto��50   !   $��0,1,0,1q�51   !   
������ 52   !   ]� 53      $ 
PART_Track��6$   $��0��54   !   ��. |�.   57   "   n� 58   &   $ Thumb��6,   #��z��59   )   #���  5:   )    5<   "   �� 5=   &   $ PageUp��63   $��ScrollBar.PageDownCommand��5>   1   $ 0Q�5?   1   |�.  5@   1    5B   "   �� 5C   &   $ PageDown��63   $��ScrollBar.PageUpCommand��5D   1   $ 0Q�5E   1   |�.  5F   1   5H      5J       5K      P� 5L      $ Thumb��6&    �@J�IsMouseOver . 5P      P� 5Q      $ Thumb��6&    �@n�
IsDragging . 5U      P� 5W       � {� .  . �5Y   "   �� $ Thumb��6)    � y�$ 	Collapsed=�5[   %   5\      P� 5]       �@��Orientation$ 
Horizontal=�5^   %   . �5_   "   �� $ GridRoot��6)    �@�LayoutTransform 5a   &   �� 5b   *   $	 -90Q�6:   5d   #   �� 5e   "   $ 
PART_Track��6)    �@�LayoutTransform 5g   &   �� 5h   *   $	 -90Q�6:   5j   #   �� 5k   "    � ��$
 Auto��5l   %   �� 5m   "    � ��$ 8��5n   %   �� 5o   "   $ Thumb��6)    �@�Tag$ 
Horizontal��5q   %   �� 5r   "   $ PageDown��6)    � ��$ ScrollBar.PageLeftCommand��5t   %   �� 5u   "   $ PageUp��6)    � ��$  ScrollBar.PageRightCommand��5w   %   5x      5z      5|      5}      �� 5   
   " n�5�      .�5�      ��  � �� 5�      �� 5�      " n�6&   .R�5�      � $
 Grid��6   
������ .+�5�      �� $��Stretch=�6(   $��Stretch=�5�   %   $
��Auto��5�   %   $
��Auto��5�   %   
������ 5�   %   �� 5�      $
 CornerScrollBarRectangle��6%   $ 5��5�   !   $��1q�62   ���#005483$��Stretch=�5�   !   $��Stretch=�5�   !   $
��Auto��5�   !   $
��Auto��5�   !   $��0,1,0,1q�5�   !   
������ 5�   !   5�       5�      P� 5�       �@�Tag$ 
Horizontal��5�   %   . �5�   "   �� $ CornerScrollBarRectangle��6)    � ��$
 Auto��5�   %   �� 5�   "   $ CornerScrollBarRectangle��6)    � ��$ 6��5�   %   5�      5�      5�      5�      5�      ��5�      �� 5�   
    �� ImageSource$ Images/wallpaper.jpg��6   .��5�      �  � ColumnDefinitions 5�   
   �� 5�      .+�5�   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dataGrid��5�      $��533,141,48,44q�6@    J� RenderTransformOrigin$ 0.5,0.5&�6W   �� 5�   
   -   5         ��Name$ LbxRequestStarted��5�      $��533,51,48,698q�6/   ��5�      �� 5�      .R�5�      ��  �� Orientation$ 
Horizontal=�6!   5�      ��5�      �� 5�      .R�5�      � .+�5�      �� -   5        $��0��5�   !   
 � Tag 6S   �� ��5�      �� 5�   "   ��5�   &   `� 5�   *     �� StringFormat$0  *{0}                 
 {1}                 ��67   .1�5�   .   �� ! �� Path$! description�66   �� 5�   .   $! hourOfStart�66   5�   +   5�   #   5�      �� 5�      -   5        $��Right=�5�   "   $��1��6>   #��[" �6O   $��X��6�   $��20(�6�    6�   �� �� 5�      -   5        $��Right=�5�   "   $��2��6>   #��[" �6O   $��0,0,20,0q�6�    6�   �� .��5�      �� .+�5�   "   �� $��20��6(   $��Images/reload.png��63   5�      5�      5�      5�      5�      �� 5�   
   -   5        $ 
LbxRequest��5�      $
��Left=�5�      $��27,210,0,103q�5�   !   $	��481��67   ��5�      �� 5�      .R�5�      � .+�5�      �� $��1��6!   $��Right=�62   $��20��6N   $��Images/rondgris.png��6Y   $��0,4,0,0q�6v   y�5�      `� 5�   "   " `� 	Converter#" [  6/   .1�5�   &   �� $! 	condition�6.   �� 5�   &   $! conditionValider�6.   5�   #   5�      �� 5�      $��1��6!   $��Right=�62   $��20��6N   $��Images/rondVert.png��6Y   $��0,4,0,0q�6v   y�5�      `� 5�   "   #" [ 6/   .1�5�   &   �� $! 	condition�6.   �� 5�   &   $! conditionValider�6.   5�   #   5�      �� 5�      $��1��6!   $��Right=�62   $��20��6N   $��Images/rondRouge.png��6Y   $��0,4,0,0q�6w   y�5      `� 5  "   #" [ 6/   .1�5  &   �� $! 	condition�6.   �� 5  &   $! conditionValider�6.   5  #   5     �� 5     -   5        $	��450��5  !   $��Center=�6-   $��0,0,0,5q�6x    6h   �� ��5     �� 5	  "   ��5
  &   `� 5  *   $  {0}        
   {1}��67   .1�5  .   �� $! description�66   �� 5  .   $! 	condition�66   5  +   5  #   5     �� 5     -   5        $��Right=�5  �   $��1��6�   #��[" �6�   $��0,0,50,0q�65  y�6!   �� *requestStarted+# �� 	Converter## [ ��6�   ��  6	  �� .��5     �� .+�5  "   �� $��20��6)   $��Images/historiqueLogo.png��64   5     5     �� 5     -	   5        $��Right=�5  @   $��1��6\   #��[" �6m   $��0,4,24,0q�6�   ��6"   ��  6�   �� .��5     �� .+�5  "   �� $��20��6)   $��Images/parameter.png��64   5     5      5#     5$     5'     �� 5(  
   $��23,11,1360,704q�6   ��5)     �� 5*     $ �� 	UriSource$$ Images/amundi.png?�6   5,     �� 5-  
   -
   5        #��[" �5-     $��Ajouter Requete��6e   $��	573,0,0,0q�6   $��20(�6�   $
��Left=�6�   $	��Top=�6�   $��46��6�   $	��188��6�   �� 5.  
   -   5        #��[" �5.     $��Modifier Requete��6h   $��20(�6�   $	��Top=�6�   $��46��6�   $	��188��6�   � 53  
   -   5        % �Name$% PopupAdd��53     $	��500��6"   $	��700��6.   $��Center=�54     & � PlacementTarget& 53  >   �� ' �� ElementName$' 	MainPanel��.��57     � $��3q�6   ��58     �� 59     $ Images/wallpaper.jpg��6!    5;     �� 5<     $
��Auto �6'   �� 5=     $��* �6'   	 5?     �� 5@     $
��Auto �6$   �� 5A     $
��Auto �6$   �� 5B     $
��Auto �6$   �� 5C     $
��Auto �6$   �� 5D     $
��Auto �6$   �� 5E     $
��Auto �6$   �� 5F     $
��Auto �6$   �� 5G     $
��Auto �6$   �� 5H     $
��Auto �6$   �� 5I     $
��Auto �6$   �� 5J     $
��Auto �6$   �� 5K     $
��Auto �6$   �� 5L     $
��Auto �6$   �� 5M     $
��Auto �6$   �� 5N     $
��Auto �6$   �� 5O     $
��Auto �6$   �� 5P     $
��Auto �6$   �� 5Q     $
��Auto �6$   �� 5R     $
��Auto �6$   �� 5S     $
��Auto �6$   .+�5Z     �� -   5        #��[" �5Z     $��0��6X   $��Center=�6h   $��X��6�   $��20(�6�   $��30��6�   $��5,0,0,54q�6�   �� 5\     $��Center=�6   $��1��6<   $��30(�6L   $��	0,20,0,25q�6Z   .��6m   Ajout d'une requete6�   �� 5^     $��1��6   $��2��6)   $��Center=�66   .��6Z   Description:6h   �� 5_     -   5        ( ��Name$( LbxbDescriptionAdd��5_     $��Center=�67   $��3��6[   $��1��6h   $��	40,0,40,0q�6x   ) �� AcceptsReturn) . 6�   �� 5a     $��1��6   $��4��6(   $��Center=�65   .��6Z   Type Requete:6i   �� 5b     -   5        $( LbxbTypeRequeteAdd��5b     $��Center=�66   $��5��6Z   $��1��6g   $��	40,0,40,0q�6w   ) . 6�   �� 5d     $��1��6   $��6��6(   $��Center=�65   .��6Z   
Requete:6d   �� 5e     -   5        $( LbxbRequeteAdd��5e     $��Center=�62   $��7��6V   $��1��6c   $��	40,0,40,0q�6s   ) . 6�   �� 5g     $��1��6   $��8��6(   $��Center=�65   .��6Z   	Type BDD:6e   �� 5h     -   5        $( LbxbTypeBddAdd��5h     $��Center=�62   $��9��6V   $��1��6c   $��	40,0,40,0q�6s   ) . 6�   �� 5j     $��1��6   $��10��6(   $��Center=�66   .��6[   
Serveur:6e   �� 5k     -   5        $( LbxbServeurBddAdd��5k     $��Center=�65   $��11��6Y   $��1��6g   $��	40,0,40,0q�6w   ) . 6�   �� 5m     $��1��6   $��12��6(   $��Center=�66   .��6[   	Compte:6d   �� 5n     -   5        $( LbxbCompteAdd��5n     $��Center=�61   $��13��6U   $��1��6c   $��	40,0,40,0q�6s   ) . 6�   �� 5p     $��1��6   $��14��6(   $��Center=�66   .��6[   Mot de Passe:6j   �� 5q     -   5        $( 
LbxbMdpAdd��5q     $��Center=�6.   $��15��6R   $��1��6`   $��	40,0,40,0q�6p   ) . 6�   �� 5s     $��1��6   $��16��6(   $��Center=�66   .��6[   
Condition:6g   �� 5t     -   5        $( LbxbConditionAdd��5t     $��Center=�64   $��17��6X   $��1��6f   $��	40,0,40,0q�6v   ) . 6�   �� 5v     -   5        #��[" �5v     
�������$��18��6h   $��1��6w   $��Center=�6�   $��Ajouter Requete��6�   $��170,30,170,0q�6�   �� 5x     -   5        * ��Name$* messageErrorAdd��5x     
���  ��$��0,40,0,0q�6B   $��1��6T   $��19��6d   $��Center=�6r   5y     5{     � 5~  
   -   5        $% 
ModifPopup��5~     $
��1500��6$   $	��700��61   $��Center=�5     & 5~  A   �� $' 	MainPanel��.��5�     � $��3q�6   ��5�     �� 5�     $ Images/wallpaper.jpg��6!    5�     �� 5�     $
��Auto �6'   �� 5�     $��* �6'   	 5�     �� 5�     $
��Auto �6$   �� 5�     $
��Auto �6$   �� 5�     $
��Auto �6$   �� 5�     $
��Auto �6$   �� 5�     $
��Auto �6$   �� 5�     $
��Auto �6$   �� 5�     $
��Auto �6$   �� 5�     $
��Auto �6$   �� 5�     $
��Auto �6$   �� 5�     $
��Auto �6$   �� 5�     $
��Auto �6$   �� 5�     $
��Auto �6$   �� 5�     $
��Auto �6$   �� 5�     $
��Auto �6$   �� 5�     $
��Auto �6$   �� 5�     $
��Auto �6$   �� 5�     $
��Auto �6$   �� 5�     $
��Auto �6$   �� 5�     $
��Auto �6$   �� 5�     $
��Auto �6$   �� 5�     $
��Auto �6$   .+�5�     �� -   5        $ LbxRequestModify��5�     $
��Left=�5�     $��
50,81,0,44q�5�  ,   $	��421��6@   ��5�     �� 5�     .R�5�     �� -   5        ��5�  %   �� *description+ 6E   �� 6U   5�     5�     �� 5�     -   5        #��[" �5�     $��0��6X   $
��Left=�6h   $��X��6�   $��20(�6�   $��50��6�   $��0,0,500,650q�6�   �� 5�     $��Center=�6   $��1��6<   $��30(�6L   $��	0,20,0,25q�6Z   .��6m   Modification de requete6�   �� 5�     $��1��6   $��Center=�6*   $��
0,100,40,0q�6N   .��6c   Description:6q   �� 5�     -   5        $( txtbDesciptionMod��5�     $��Center=�66   $��0��6Z   $��1��6g   $��100,130,100,550q�6w   ) . 6�   �� 5�     $��1��6   $��Center=�6)   $��
0,150,40,0q�6N   .��6c   Type Requete:6r   �� 5�     -   5        $( txtbTypeRequestMod��5�     $��Center=�66   $��1��6[   $��100,180,100,500q�6k   ) . 6�   �� 5�     $��1��6   $��Center=�6(   $��
0,200,40,0q�6L   .��6a   
Requete:6k   �� 5�     -   5        $( txtbRequestMod��5�     $��Center=�62   $��1��6W   $��100,230,100,450q�6g   ) . 6�   �� 5�     $��1��6   $��Center=�6(   $��
0,250,40,0q�6L   .��6a   	Type BDD:6l   �� 5�     -   5        $( txtbTypeBddMod��5�     $��Center=�62   $��1��6W   $��100,280,100,400q�6g   ) . 6�   �� 5�     $��1��6   $��Center=�6(   $��
0,300,40,0q�6L   .��6a   
Serveur:6k   �� 5�     -    5        $( txtbServeurMod��5�     $��Center=�62   $��1��6V   $��100,330,100,350q�6g   ) . 6�   �� 5�     $��1��6   $��Center=�6(   $��
0,350,40,0q�6M   .��6b   	Compte:6k   �� 5�     -!   5        $( txtbCompteMod��5�     $��Center=�61   $��1��6V   $��100,380,100,300q�6g   ) . 6�   �� 5�     $��1��6   $��Center=�6)   $��
0,400,40,0q�6M   .��6a   Mot de Passe:6p   �� 5�     -"   5        $( 
txtbMdpMod��5�     $��Center=�6.   $��1��6S   $��100,430,100,250q�6c   ) . 6}   �� 5�     $��1��6   $��Center=�6)   $��
0,450,40,0q�6N   .��6b   
Condition:6n   �� 5�     -#   5        $( txtbConditionMod��5�     $��Center=�64   $��1��6Y   $��100,480,100,200q�6j   ) . 6�   �� 5�     -$   5        #��[" �5�     
�������$��1��6j   $��Center=�6z   $��Modifier Requete��6�   $��
0,350,35,0q�6�   �� 5�     -%   5        $* messageErrorMod��5�     
���  ��$��
0,550,40,0q�6B   $��1��6V   $��Center=�6g   5�     5�     � 5�  
   -&   5        $% HistoriquePopup��5�     $	��300��6)   $	��400��65   $��Center=�5�     & 5�  E   �� $' 	MainPanel��.��5�     � $��3q�6   ��5�     �� 5�     $ Images/wallpaper.jpg��6!    5�     �� 5�     $
��Auto �6'   �� 5�     $��* �6'   	 5�     �� 5�     $
��Auto �6$   �� 5�     $
��Auto �6$   �� 5�     $
��Auto �6$   .+�5�     �� -'   5        #��[" �5�     $��0��6X   $
��Left=�6h   $��X��6�   $��20(�6�   $��50��6�   �� 5�     $��Center=�6   $��1��6<   $��30(�6L   $��0,10,0,0q�6Z   .��6l   Historisation6{   �� 5�     -(   5        $ LbxRequestHistorique��5�     $��Center=�5�     $��0,51,0,0q�5�  0   $	��170��6C   $	��200��6O   $��1��6\   $��1��6i   ��5�     �� 5�     .R�5�     �� -)   5         5�  $   �� ��5�  "   �� 5�  &   ��5�  *   `� 5�  .   $	  {0}��6;   .1�5�  2   �� $!  hourOfStart�6:   5�  /   5�  '   5�     5�     5      5     5     � 5  
   -*   5        $% ModifyColumnPopup��5     $	��650��6+   $	��400��67   $��Center=�5     & 5  G   �� $' 	MainPanel��.��5
     � $��3q�6   ��5     �� 5     $ Images/wallpaper.jpg��6!    5     �� 5     $
��Auto �6'   �� 5     $��* �6'   	 5     �� 5     $
��Auto �6$   �� 5     $
��Auto �6$   �� 5     $
��Auto �6$   .+�5     �� $��Center=�6   $��1��6<   $��30(�6L   $��0,10,0,0q�6Z   .��6l   Modification des colonnes6�   �� 5     -+   5        + ��Name$+ btnexitModifyColumn��5     #��[" �6   $��0��6X   $��Center=�6h   $��X��6�   $��20(�6�   $��30��6�   $��5,0,0,54q�6�   ��6�   �� 6   �� 5     -,   5        $ LbxColumnsRequest��5     $��Center=�5     $��0,10,0,0q�5  -   $	��580��6?   $	��250��6K   $��1��6X   $��1��6e   ��5     �� 5     .R�5      �  5!  "   �� 5"  &   $
��Auto �67   �� 5#  &   $��* �67   �� 5$  &   $
��Auto �67   �� 5%  &   $��* �67   .+�5(  "   �� $��0��6L   $��0,0,0,10q�6\   $	��250��6n   ��6)   �� *initialColumn+6n   �� 5)  "   $��AS��6(   $��1��65   $	��130��6E   �� 5*  "   $��TextBoxList��6*   $��2��6�   $��20��6�   $	��150��6�   $��0,0,0,6q�6�   ��6=   �� *modifyColumn+, �� UpdateSourceTrigger$, PropertyChanged=�6�   5+     5,     5/     52     54     A� 56  
   --   5        - A�Name$- spinnerLoad��56     ���#00B6ED$��967,335,538,238q�68   . �� StrokeDashArray$. 235 78R�6Q   $ 0.5 0.5&�6j   z�57     �� 58     -.   5        Rotation��$ 0Q�58  4   / � Triggers/ 5:     :� 5;     0 :� RoutedEvent$0 Loaded��6   .[�5<     �� .��5=     �� 1 g� RepeatBehavior$1 Forever��6%   .��5>     W� 2 �� 
TargetName$2 Rotation��6.   3 �� TargetProperty$3 Angle�6O   4 W� From$4 0X�6q   	5 W� To$
5 360 X�6z   5?     5@     5A     5C     �� 5D  
   -/   5        $��Test Requete Condition��5D     $
��Left=�62   $��37��6M   $��178,753,0,0q�6Y   $	��Top=�6n   $	��178��6�   ���	#FFFCFDFD$��0,1,1,1q�6�   $ 0,0.5&�6�   �� 5F  
   -0   5        $
��Left=�5F     $��26��6-   $��
27,163,0,0q�69   6 �� TextWrapping$
6 Wrap=�6M   $	��Top=�6a   $	��480��6y   6�   5G     5H     