   M S B A M L   `   `   `  ?????  ;FETA, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:FETAFETA  5   	   /clr-namespace:FETA.ViewModelFETA.ViewModel  5	   	   %clr-namespace:FETA.View	FETA.View  5
   	       FETA.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:FETA     5   	   _ [MaterialDesignThemes.Wpf, Version=4.6.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -
modelViewsclr-namespace:FETA.ViewModel  5	   	   #viewsclr-namespace:FETA.View  5
   	     ? Title$*  $File Encryption Tool Advanced - FETA??5      $	??450??65   $	??800??6B    ? 	Resources 5       ?? DataType#   FETA.ViewModel.AboutViewModel   FETA.View.AboutView ? DataContext,   &FETA.ViewModel.EncryptDecryptViewModel"   FETA.View.EncryptDecryptView??%?   (??       5      *, +)(?? Z     5      *, +)?? 5   
   aboutViewTemplate??"  5      .R?5         6   ?? 5      ?? 5   
   encryptDecryptViewTemplate??"  5      .R?5         6'   ?? 5      5      .??5      ]? ???	#FF010030.+?5   
   ?? $
??Left=?6    ?? Orientation$ Vertical=?5      ???	#99393838.+?5       ?? -   5        $??btnEncryptDecrypt??5&       ? ToolTip$ Encrypt Decrypt??5!      
?????? 
?????? 
???????$??0,0,0,10q?5%      $??60??5'      $??40??5(      ??5       0  *MaterialDesignThemes.Wpf.PackIconExtension     Kind$ 
Encryption=?   Size 305)      ?? 5,      -   5        $??btnAbout??52      $ About??5-      
?????? 
?????? 
???????$??0,0,0,10q?51      $??60??53      $??40??54      ??5,        $ About=? 3055      57      ? 58   
   .+?59      ?? ??6   ?? 5:      5;      5<      