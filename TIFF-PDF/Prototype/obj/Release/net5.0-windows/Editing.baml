   M S B A M L   `   `   `  ���� O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  E APrototype2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Prototype2
Prototype2    Prototype2.Editing   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6sys&clr-namespace:System;assembly=mscorlib     *localclr-namespace:Prototype2     -     � Title$  Editing Window��$	��445��$	��635�� � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=� � SizeToContent$ Manual=����	#FFE2DFDC.��� $��0,0,0,0q� � ColumnDefinitions �� $	��71* ��� $
��582* ��� $
��147* �.+��� $��	File Path��$��14,12,74,10q�$��2��$
��Bold"�.��� $	��306�� � RowDefinitions �� $
��131* ��� $	��22* � �� $	��24* ��� $
��181* �.+��� $��Client Name:��$
��Left=�$��11,7,0,0q�$	��Top=�$��2��$��Normal"��� -    ��Name$ 	txt_cname��${�False��$
��Left=�$��	16,33,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$	��100��$��20��$��2��$��Normal"��� $��Client Key:��$
��Left=�$��96,7,0,0q�$	��Top=�$��1��$��Normal"��� -   $ txt_ckey��$
��Left=�$��
101,33,0,0q�${�False��$
 Wrap=�$	��Top=�$	��100��$��20��$��1��$��Normal"��� $��Client Type:��$
��Left=�$��	228,7,0,0q�$	��Top=�$��1��$��Normal"��� -   $ 	txt_ctype��$
��Left=�$��
232,33,0,0q�${�False��$
 Wrap=�$	��Top=�$	��100��$��20��$��1��$��Normal"��� $��Description��$
��Left=�$��	11,64,0,0q�$	��Top=�$��2��$��Normal"��� -   $ txt_desc��$
��Left=�$��	15,90,0,0q�$
 Wrap=�$	��Top=�$	��365��$��75��$��2��$��Normal"��� $��Document Type:��$
��Left=�$��228,180,0,0q�$	��Top=�$��1��$��Normal"��� -   $ txt_doctype��${�False��$
��Left=�$��233,206,0,0q�$
 Wrap=�$	��Top=�$	��100��$��20��$��1��$��Normal"��� $��Document ID:��$
��Left=�$��
97,182,0,0q�$	��Top=�$��1��$��Normal"��� -   $ 	txt_docid��$
��Left=�$��101,207,0,0q�$
 Wrap=�$	��Top=�$	��100��$��20��$��1��$��Normal"��� $��
Scan Date:��$
��Left=�$��
11,179,0,0q�$	��Top=�$��2��$��Normal"��� $��File Location:��$
��Left=�$��
11,240,0,0q�$	��Top=�$��2��$��2��$��Normal"��� -   $ txt_filepath��$
��Left=�${�False��$��16,4,0,0q�$
 Wrap=�$	��Top=�$	��362��$��20��$��2�� J� RenderTransformOrigin$ 0.5,0.5&�$��1��$��Normal"�.��z�V� .~��� �� �� 	 �� Angle$	 0.024Q�T� .��(  "System.Windows.Controls.DatePicker  -	   
  Name$
 txt_scandate��${�False��$
��Left=�$��
11,205,0,0q�$	��Top=�$��2��$��23��$��Normal"�   DisplayDateEnd ��  �� Mode$ OneWay=� �� Today �� Source# Z �� $��
Operations��$��377,12,6,10q�$��1��$��2��$
��Bold"�.��� $	��395��.+��� -
    ��Name$ btn_generate��$��	GENERATE ��$��Center=�$	��Top=�$��46��$	��155��$��	0,118,0,0q�$��14(�$��Normal"��� -   $ btn_undo��$
��UNDO��$��Center=�$��	0,201,0,0q�$	��Top=�$��46��$	��155��$y�Hidden=��� -   $ txt_id��$��Center=�$��0,21,0,0q�$��TextBox��$
 Wrap=�$	��Top=�$	��120��$y�Hidden=��� -   $ 
btn_cancel��$��CANCEL��$��Center=�$��Center=�$��46��$	��155��$��14(�$��Normal"��� -   $ btn_done��$
��DONE��$��Center=�$��	0,233,0,0q�$	��Top=�$��46��$	��155��$��14(�$��Normal"�