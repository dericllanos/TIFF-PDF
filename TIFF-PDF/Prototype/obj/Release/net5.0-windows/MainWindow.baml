   M S B A M L   `   `   `  ���� O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  E APrototype2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Prototype2
Prototype2    Prototype2.MainWindow   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6sys&clr-namespace:System;assembly=mscorlib     *localclr-namespace:Prototype2     -     �Name$  window1�� � Title$ Main Window��$	��540��$	��978�� � 
ResizeMode$ 	CanResize=� � SizeToContent$ Manual=� � WindowStartupLocation$ CenterScreen=� � WindowState$ Normal=� � WindowStyle$ ThreeDBorderWindow=����	#FFE2DFDC���� .��� -    �Name$ MainGrid��$��
-1,1,-1,-1q�$��4�����	#FFE2DFDC J� SnapsToDevicePixels$
 True��	 � LayoutTransform	 �� -   ApplicationScaleTransform��
 �� CenterX$
 0Q� �� CenterY$ 0Q� �� ScaleX ��  �� ElementName$ window1�� �� Path$ 
ScaleValue� �� ScaleY �� $ window1��$ 
ScaleValue�.+��� $��Search��$��	18,10,0,0q�$��10(�$
��Bold"�$��3,3,3,3q����	#FFA6ACB9$
��Left=�$	��Top=�$	��525��$	��237��.��� $	��470�� � ColumnDefinitions �� $	��19* ��� $
��515* �.+��� $��Client Name:��$
��Left=�$��	15,13,0,0q�$	��Top=�$��10(�$��Normal"�$��2���� -    ��Name$ combo_cname��$
��Left=�$��3,36,0,0q�$	��Top=�$	��110��$��21��$��Normal"� �� 
IsEditable$
 True��$��1���� $��Client Key:��$
��Left=�$��
176,13,0,0q�$	��Top=�$��10(�$��1��$��Normal"��� -   $ 
combo_ckey��$
��Left=�$��
182,36,0,0q�$	��Top=�$	��110��$��1��$��21��$��Normal"�$
 True���� $��Client Type:��$
��Left=�$��
355,13,0,0q�$	��Top=�$��10(�$��1��$��Normal"��� -   $ combo_ctype��$
��Left=�$��
362,36,0,0q�$	��Top=�$	��110��$��1��$��21��$��Normal"�$
 True���� $��Description:��$
��Left=�$��	15,75,0,0q�$	��Top=�$��10(�$��Normal"�$��2���� -   $ 
combo_desc��$
��Left=�$��3,98,0,0q�$	��Top=�$	��110��$��21��$��Normal"�$
 True��$��1���� $��Export Status:��$
��Left=�$��
176,75,0,0q�$	��Top=�$��10(�$��1��$��Normal"��� -   $ combo_doctype��$
��Left=�$��
182,98,0,0q�$	��Top=�$	��110��$��1��$��21��$��Normal"�$
 True���� $��Archive:��$
��Left=�$��
355,75,0,0q�$	��Top=�$��10(�$��1��$��Normal"��� -	   $ combo_archive��$
��Left=�$��
362,98,0,0q�$	��Top=�$	��110��$��1��$��21��$��Normal"�$
 True���� $��
Scan Date:��$
��Left=�$��	3,137,0,0q�$	��Top=�$��10(�$��Normal"�$��1���� $��Start Date:��$
��Left=�$��176,137,0,0q�$	��Top=�$��10(�$��1��$��Normal"��� $��	End Date:��$
��Left=�$��355,137,0,0q�$	��Top=�$��10(�$��1��$��Normal"�(  "System.Windows.Controls.DatePicker  -
     Name$ date_scandate��$
��Left=�$��	3,160,0,0q�$	��Top=�$	��110��$��24��$��Normal"�$��1��   DisplayDateEnd ��  �� Mode$ OneWay=� �� Today �� Source# Z   -   $ date_startdate��$��1��$
��Left=�$��182,160,0,0q�$	��Top=�$	��110��$��24��$��Normal"� �� $ OneWay=�# Z   -   $ date_enddate��$��1��$
��Left=�
 �� Now   SelectedDate# Z $��362,160,0,0q�$	��Top=�$	��110��$��24��$��Normal"� �� $ OneWay=�# Z �� $��Document View��$��553,10,18,17q�$}�False��$
��Bold"�$��10(����	#FFA6ACB9$��3,3,3,3q� J� RenderTransformOrigin$ 0.5,0.5&�$��Right=�$��Center=�z�V� .~��� $ 1Q��� �� T� .��� -   $ pdf_grid�����	#FFE2DFDC$}�False�� �� $	��20* ��� $
��345* ��� $	��76* ��� $
��287* �.+�(  "System.Windows.Controls.WebBrowser  -     Name$ browser��$}�False��$��4��$��10,10,10,10q� J� OpacityMask
 �����-� -    -�Name$ 
doc_viewer��$��4�� -� ViewingMode$ Scroll=�.��/� .T��� -    �Name$ ImageContainer��.r��� $.��(C:/Users/Predator/Desktop/Test/blank.png��$y�Hidden=��� -     ��Name$  txt_path��$��2��$
��Left=�$��340,219,0,0q�$��TextBox��! �� TextWrapping$
! Wrap=�$	��Top=�$	��120��$y�Hidden=�$}�False���� -   " ��Name$" btn_edit��$
��Edit��$
��Left=�$y�Hidden=�$��114,226,0,0q�$	��Top=�$��77��$��21��$}�False���� -   # ��Name$# 	checkbox1��$��Enable Editing��$y�Hidden=�$
��Left=�$��206,230,0,0q�$	��Top=�$}�False��� -   $ 
table_grid��$��18,0,0,0q�$
��Left=�$��Bottom=�$	��250��$	��530��.+��� -   $" btn_refresh2��$
{�True��$
��Left=�$��	86,12,0,0q�$	��Top=�$��20��$��20��$}�False��$��10(�$��Normal"�$��Normal$�$��Normal&�.���� $	��⟳��$��0,-4,0,0q��� -   $" btn_add2��$
{�True��$
��Left=�$��
111,12,0,0q�$	��Top=�$��20��$��20��$}�False��$��10(�$��Normal"�$��Normal$�$��Normal&�.���� $��+��$��0,-4,0,0q��� -   $" 
btn_export��$
{�True��$��Generate PDF��$
��Left=�$��9,12,0,0q�$	��Top=�$��72��$��20��$}�False��$��10(�$��Normal"�&   System.Windows.Controls.DataGrid  -   $  Name$$ 	dataGrid1��%   
IsReadOnly$
% True��$}�False��$��
2,37,10,17q�$��10(�$��Normal"�$��3,3,3,3q����	#FFA6ACB9$��SemiCondensed&�$��Segoe UI)����	#FFF9F8F7$ 0.5,0.5&�z�V� .~��� $ 1Q��� �� T� &   Columns& 4  .System.Windows.Controls.DataGridTemplateColumn  '   CellTemplate' �� .R��� $# 
myCheckBox��-   $��Center=�$��Center=�$��5,0,5,0q�${�False��( d� 	IsChecked( �� $ window1��$ c�$ TwoWay=�  -   $$ 	dataGrid2��$
% True��$}�False��$��
2,37,10,17q�$��10(�$��Normal"�$��3,3,3,3q����	#FFA6ACB9$ 0.5,0.5&�z�V� .~��� $ 1Q��� �� T� 