   M S B A M L   `   `   `  ?????  ;FETA, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:FETAFETA  5   	   /clr-namespace:FETA.ViewModelFETA.ViewModel  5	   	   %clr-namespace:FETA.View	FETA.View  5
   	       FETA.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:FETA     5   	   _ [MaterialDesignThemes.Wpf, Version=4.6.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -
modelViewsclr-namespace:FETA.ViewModel  5	   	   #viewsclr-namespace:FETA.View  5
   	     ? Title$*  $File Encryption Tool Advanced - FETA??5   	   $	??500??5   	   $	??500??5   	   $
??1200??5   	   $
??1200??5   	    ? 	Resources 5       ?? DataType#   FETA.ViewModel.AboutViewModel   FETA.View.AboutView ? DataContext"   FETA.ViewModel.HashViewModel   FETA.View.HashView,   &FETA.ViewModel.EncryptDecryptViewModel"   FETA.View.EncryptDecryptView0   *FETA.ViewModel.EncryptDecryptDataViewModel&    FETA.View.EncryptDecryptDataView??%?  (??       5      *, +)(?? Z     5      *, +)(?? ?     5      *, +)(??     5#      *, +)?? 5   
   aboutViewTemplate??"  5      .R?5         6   ?? 5      ?? 5   
   hashViewTemplate??"  5      .R?5         6   ?? 5      ?? 5   
   encryptDecryptViewTemplate??"  5      .R?5         6'   ?? 5       ?? 5"   
   "encryptDecryptDataViewTemplate??"  5#      .R?5$         6+   ?? 5%      5'      .??5)      ]? ???	#FF010030.+?5*   
   ?? $
??Left=?6    ?? Orientation$ Vertical=?5+      ???	#99393838.+?5.      ?? -   5        $??btnEncryptDecryptData??54       ? ToolTip$ Encrypt Decrypt??5/      
?????? 
?????? 
???????$??0,0,0,10q?53      $??60??55      $??40??56       ? Cursor$
 Hand??57   9   ??5.      0	  *MaterialDesignThemes.Wpf.PackIconExtension	   	  Kind$ 
Encryption=? 	  Size 3057   9   ?? 5:      -   5        $??btnEncryptDecryptFile??5@      $ Encrypt Decrypt??5;      
?????? 
?????? 
???????$??0,0,0,10q?5?      $??60??5A      $??40??5B      $
 Hand??5C   9   ??5:      	  $ FileLockOutline=? 305C   9   ?? 5E      -   5        $??btnSha??5K      $ Encrypt Decrypt??5F      
?????? 
?????? 
???????$??0,0,0,10q?5J      $??60??5L      $??40??5M      $
 Hand??5N   +   ??5E      	  $ Hashtag=? 305N   +   ?? 5R      -   5        $??btnAbout??5X      $ About??5S      
?????? 
?????? 
???????$??0,0,0,10q?5W      $??60??5Y      $??40??5Z      ??5R      	  $ About=? 305[      5]      ? 5^   
   .+?5_      ?? ??6   ?? 5`      5a      5b      