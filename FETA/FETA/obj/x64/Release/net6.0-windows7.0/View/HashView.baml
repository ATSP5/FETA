   M S B A M L   `   `   `  ???? ?  ;FETA, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:FETA.View	FETA.View  1clr-namespace:FETA.ConvertersFETA.Converters      FETA.View.HashView   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     )localclr-namespace:FETA.View     .convclr-namespace:FETA.Converters       ? 	Resources  '   !FETA.Converters.HCActionConverter   hcActionConverterKey??%   &	          .??? ???	#FF403D3D ? ColumnDefinitions ?? ?? $	??130 ??? .+??? 
???????$??2q? ?? CornerRadius$ 8,8,8,8??$??10q?$??0??._??? $??Visible=?$??Disabled=?.???? .+??? $??Input??
???????$??15(?$??Center=?$??10q??? $??10q?
??????? ?? AcceptsReturn$
 True??????  ?? Path$ HashModel_O.Input??? $
??Seed??
???????$??15(?$??Center=?$??10q??? $??10q?$
 True??
??????????? $ HashModel_O.Seed??? 
???????$??2q?$ 8,8,8,8??$??10q?$??1??._??? .+?	? -   $??rbtnHash??$
??10,5q?$
??Hash?? 	? 	GroupName$	 HAS??
??????? d? 	IsChecked ?? *HashModel_O.HCAction+ ?? 	Converter# [   ?? ConverterParameter$ H??	? -   $??rbtnCompare??$
??10,5q?$??Compare??$	 HAS??
??????? ?? *HashModel_O.HCAction+# [  $ C????  " MaterialDesignRaisedDarkButton#??[    MaterialDesignDarkBackground#??[ #??[ $??Process??$??10q?	 ? Cursor$
	 Hand?????? *	Process+?? 
???????$??2q?$ 8,8,8,8??$??10q?$??2??._??? $??Visible=?$??Disabled=?.???? .+??? 
???????$??15(?$??Center=?$??10q????? $ HashModel_O.IOLabel??? $??10q?$
 True??
??????????? $ HashModel_O.Output?