   M S B A M L   `   `   `  ���� O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  E APrototype2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Prototype2
Prototype2    Prototype2.Add   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6sys&clr-namespace:System;assembly=mscorlib     *localclr-namespace:Prototype2       � Title$  Editing Window��$	��513��$	��635�� � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=� � SizeToContent$ Manual=�.��� $��0,0,10,0q� � ColumnDefinitions �� $	��71* ��� $
��582* ��� $
��147* �.+��� $
��Edit��$��14,12,74,141q�$��2��.��� $	��306�� �� $	��24* ��� $
��181* �.+��� $��Client Name:��$
��Left=�$��11,7,0,0q�$	��Top=�$��2���� -    ��Name$ 	txt_cname��$
��Left=�$��	16,33,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$	��100��$��20��$��2���� $��Client Key:��$
��Left=�$��96,7,0,0q�$	��Top=�$��1���� -   $ txt_ckey��$
��Left=�$��
101,33,0,0q�$
 Wrap=�$	��Top=�$	��100��$��20��$��1���� $��Client Type:��$
��Left=�$��	228,7,0,0q�$	��Top=�$��1���� -   $ 	txt_ctype��$
��Left=�$��
232,33,0,0q�$
 Wrap=�$	��Top=�$	��100��$��20��$��1���� $��Description��$
��Left=�$��	11,64,0,0q�$	��Top=�$��2���� -   $ txt_desc��$
��Left=�$��	15,90,0,0q�$
 Wrap=�$	��Top=�$	��365��$��75��$��2���� $��Document Type:��$
��Left=�$��228,180,0,0q�$	��Top=�$��1���� -   $ txt_doctype�� �� 
IsReadOnly$
 true��$
��Left=�$��233,206,0,0q�$
 Wrap=�$	��Top=�$	��100��$��20��$��1���� $��Archive:��$
��Left=�$��
97,182,0,0q�$	��Top=�$��1���� -   $ txt_archive��$
��Left=�$��101,207,0,0q�$
 Wrap=�$	��Top=�$	��100��$��20��$��1���� $��
Scan Date:��$
��Left=�$��
11,179,0,0q�$	��Top=�$��2���� $��File Location:��$
��Left=�$��
11,240,0,0q�$	��Top=�$��2���� -   $ txt_filelocation��$
��Left=�$
 true��$��
16,266,0,0q�$
 Wrap=�$	��Top=�$	��338��$��20��$��2�� J� RenderTransformOrigin$ 0.5,0.5&�.��z�V� .~��� �� �� 	 �� Angle$	 0.024Q�T� .��(  "System.Windows.Controls.DatePicker  -   
  Name$
 txt_scandate��$
��Left=�$��
11,205,0,0q�$	��Top=�$��2��$��23��   DisplayDateEnd ��  �� Mode$ OneWay=� �� Today �� Source# Z �� -	    ��Name$ 
btn_browse��$	��...��$��1��$
��Left=�$��306,266,0,0q�$	��Top=�$��24���� $��
Operations��$��377,12,6,17q�$��1��$��2��.��� $	��395��.+��� -
   $ btn_save��$
��SAVE��$��Center=�$��0,48,0,0q�$	��Top=�$��46��$	��155��$��14(��� -   $ 
btn_update��$��UPDATE��$��Center=�$	��Top=�$��46��$	��155��$��	0,107,0,0q�$��14(��� -   $ btn_undo��$
��UNDO��$��Center=�$��	0,201,0,0q�$	��Top=�$��46��$	��155��$y�Hidden=��� -   $ txt_id��$��Center=�$��0,21,0,0q�$��TextBox��$
 Wrap=�$	��Top=�$	��120��$y�Hidden=��� -   $ 
btn_cancel��$��REFRESH��$��Center=�$��	0,223,0,0q�$	��Top=�$��46��$	��155��$��14(��� -   $ btn_done��$
��DONE��$��Center=�$��	0,281,0,0q�$	��Top=�$��46��$	��155��$��14(��� -   $ 
btn_delete��$��DELETE��$��Center=�$��	0,165,0,0q�$	��Top=�$��46��$	��155��$��14(�&   System.Windows.Controls.DataGrid  -     Name$ 	dataGrid2��$��2��$��14,341,74,17q�   
IsReadOnly$
 True�� � 	Resources ��%       	CellStyle �� 