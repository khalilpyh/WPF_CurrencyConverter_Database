   M S B A M L   `   `   `  ????U  QCurrencyConverter_Database, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:CurrencyConverter_DatabaseCurrencyConverter_Database  5   	   +    %CurrencyConverter_Database.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   :local(clr-namespace:CurrencyConverter_Database     5   	   Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  5   	     ? Title$  Currency Converter??5	   	    ? SizeToContent$ WidthAndHeight=?5
   	    ? WindowStartupLocation$ CenterScreen=?5   	    ? Icon$ /Images/money.png??5   	   .??5      ?? -   5        $??tbMain??5       ?? TabStripPlacement$	 Top=?6   .@?5   
   ?? -   5        $??tbConverter??5      $??Currency Converter??6%   .??5      ?  ? ColumnDefinitions 5      ?? 5      $
??179* ?6'   ?? 5      $
??321* ?6'   ?? 5      $
??500* ?6'    ? RowDefinitions 5      ?? 5      $??60 ?6$   ?? 5      $??80 ?6$   ?? 5      $	??150 ?6$   ?? 5      $	??100 ?6$   ?? 5      $	??150 ?6$   .+?5      ?? $??2??6   $	??800??6&    ?? CornerRadius$ 10??62   $??5q?6D   $??100,0q?6X   $??3??6g   ??5      ?? 5       ?? 
StartPoint$	 0,0&?6.   	 ?? EndPoint$		 1,0&?6?   .??5       ? 
 ? Color$
 #ec2075??6+    ? Offset$	 0.0Q?6;   ? 5!      $
 #f33944??6+   $	 0.5Q?6;   5"      ._?5$      ?? $??2??6    ??5%      ?? 5&      $	 0,0&?62   $		 1,0&?6C   .??5'   "   ? $
 #ec2075??6/   $	 0.0Q?6?   ? 5(   "   $
 #f33944??6/   $	 0.5Q?6?   5)      5+      5,      ?? 5.      $??0??6    ?? Orientation$ 
Horizontal=?6*   $??Center=?6C   $??Center=?6`   $??50??6{   $
??1000??6?   $??3??6?   $	??0,5q?6?   .+?5/      ?? $??50??6   $
??1000??6(   $??Center=?65   $??Center=?6Y   $??Currency Converter??6{   $??30(?6?   ???#ec2075$
??Bold"?6?   50      ?? 51      $??1??6   $ Vertical=?6*   $??Center=?6A   $??80??6^   $
??1000??6j   $??3??6w   .+?52      ?? $??40??6   $
??1000??6(   $??Center=?65   $??Center=?6Y   $??Converted Currency??6{   $??20(?6?   ?? 53      -   5        $??lblCurrency??53      $??40??6/   $
??1000??6;   $??Center=?6H   $??Center=?6l   $??20(?6?   54      ?? 55      $??2??6   $ 
Horizontal=?6*   $??Center=?6C   $	??Top=?6`   $??60??6x   $	??800??6?   $??3??6?   $??100,0q?6?   .+?56      ?? $??40??6   $	??150??6(   $??Enter Amount : ??64   $??35,0,0,0q?6N   $??Bottom=?6`   
???????$??20(?6?   ?? 57      $??40??6   $	??150??6(   $??From : ??64   $??	110,0,0,0q?6F   $??Bottom=?6Y   
???????$??20(?6?   ?? 58      $??40??6   $	??150??6(   $??To : ??64   $??	130,0,0,0q?6D   $??Bottom=?6W   
???????$??20(?6?   59      ?? 5:      $??2??6   $ 
Horizontal=?6*   $??Center=?6C   $??Bottom=?6`   $??90??6{   $	??800??6?   $??3??6?   $??100,0q?6?   .+?5;      ?? -   5        $??txtCurrency??5;      $??30??61   $	??200??6=   $??40,0,0,0q?6I   $??18(?6?   $	??Top=?6?   $??Center=?6?   ?? 5<      -   5        $??cboFromCurrency??5<      $??30??66   $	??170??6B   $??	60,0,40,0q?6N   $??Center=?6a   $	??Top=?6?    ?? MaxDropDownHeight$	 150??6?   $??18(?6?   6?   "  FontAwesome.WPF.ImageAwesome  5=         Icon$ Exchange=?6&   $??30??66   $??30??6B   $	??Top=?6M      
Foreground
 ?????6e   ?? 5>      -   5        $??cboToCurrency??5>      $??30??64   $	??170??6@   $??40,0,0,0q?6L   $??Center=?6^   $	??Top=?6?   $	 150??6?   $??18(?6?   6?   5?      ?? 5@      $??3??6   $ 
Horizontal=?6*   $	??100??6C   $
??1000??6P   $??3??6]   .+?5A      ?? -   5        $??
btnConvert??5A      $??40??6/   $	??150??6;   $??Convert??6G   $??
350,0,20,0q?6Y   
???????$??20(?6?      ButtonRound#??[  6?   ??5B      ?? 5C      $	 0,0&?62   $		 1,0&?6C   .??5D   "   ? $
 #ec2075??6/   $	 0.0Q?6?   ? 5E   "   $
 #f33944??6/   $	 0.5Q?6?   5F      5H      ?? 5I      -   5        $??btnClear??5I      $??40??6-   $	??150??69   $??Clear??6E   
???????$??20(?6h   #??[  6v   ??5J      ?? 5K      $	 0,0&?62   $		 1,0&?6C   .??5L   "   ? $
 #ec2075??6/   $	 0.0Q?6?   ? 5M   "   $
 #f33944??6/   $	 0.5Q?6?   5N      5P      5Q      5R      5S      ?? 5T   
   -	   5        $??tbConverterMaster??5T      $??Currency Master??6+   .??5U      ?  5V      ?? 5W      $??60 ?6$   ?? 5X      $	??100 ?6$   ?? 5Y      $??60 ?6$   ?? 5Z      $	??200 ?6$   ?? 5[      $	??150 ?6$   .+?5]      ?? $??1??6   $	??800??6&   $ 10??62   $??5q?6D   $??100,0q?6X   ??5^      ?? 5_      $	 0,0&?6.   $		 1,0&?6?   .??5`      ? $
 #ec2075??6+   $	 0.0Q?6;   ? 5a      $
 #f33944??6+   $	 0.5Q?6;   5b      ._?5d      ?? $??1??6    ??5e      ?? 5f      $	 0,0&?62   $		 1,0&?6C   .??5g   "   ? $
 #ec2075??6/   $	 0.0Q?6?   ? 5h   "   $
 #f33944??6/   $	 0.5Q?6?   5i      5k      5l      ?? 5n      $??0??6   $ 
Horizontal=?6*   $??Center=?6C   $??50??6`   $
??1000??6l   $??Center=?6y   $	??0,5q?6?   .+?5o      ?? $??50??6   $
??1000??6(   $??Center=?65   $??Center=?6Y   $??Currency Master??6{   $??30(?6?   ???#ec2075$
??Bold"?6?   5p      ?? 5q      $??1??6   $ 
Horizontal=?6*   $??Center=?6C   $	??Top=?6`   $??40??6x   $	??800??6?   $??100,0q?6?   .+?5r      ?? $??40??6   $	??180??6(   $??Enter Amount : ??64   $??	180,0,0,0q?6N   $??Bottom=?6a   
???????$??20(?6?   ?? 5s      $??40??6   $	??180??6(   $??Currency Name : ??64   $??60,0,0,0q?6O   $??Bottom=?6a   
???????$??20(?6?   5t      ?? 5u      $??1??6   $ 
Horizontal=?6*   $??Center=?6C   $??Bottom=?6`   $??60??6{   $	??800??6?   $??100,0q?6?   .+?5v      ?? -
   5        $??	txtAmount??5v      $??30??6/   $	??200??6;   $??	180,0,0,0q?6G   $??18(?6?   $??Center=?6?   $	??Top=?6?   ?? 5w      -   5        $??txtCurrencyName??5w      $??30??65   $	??200??6A   $??40,0,0,0q?6M   $??18(?6_   $??Center=?6m   $	??Top=?6?    ?? 	MaxLength$ 50??6?    ?? CharacterCasing$ Upper=?6?   5x      ?? 5y      $??2??6   $??60??6*   $
??1000??66   $ 
Horizontal=?6C   .+?5z      ?? -   5        $??btnSave??5z      $??40??6,   $	??150??68   $
??Save??6D   $??
350,0,20,0q?6S   
???????$??20(?6z   #??[  6?   ??5{      ?? 5|      $	 0,0&?62   $		 1,0&?6C   .??5}   "   ? $
 #ec2075??6/   $	 0.0Q?6?   ? 5~   "   $
 #f33944??6/   $	 0.5Q?6?   5      5?      ?? 5?      -   5        $??	btnCancel??5?      $??40??6.   $	??150??6:   $??Cancel??6F   
???????$??20(?6j   #??[  6x   ??5?      ?? 5?      $	 0,0&?62   $		 1,0&?6C   .??5?   "   ? $
 #ec2075??6/   $	 0.0Q?6?   ? 5?   "   $
 #f33944??6/   $	 0.5Q?6?   5?      5?      5?      ?? 5?      $??3??6   $	??200??6*   $	??800??67   $??150,0q?6C   $	??Top=?6R   .+?5?      &   System.Windows.Controls.DataGrid  -   5        $??
dgCurrency??5?         AutoGenerateColumns .  $	??180??6M   $	??480??6Z   $??10q?6f   
??????    CanUserAddRows .     SelectionUnit$
 Cell=?6?   "   VerticalScrollBarVisibility$
 Auto=?6?      Columns 5?      0  *System.Windows.Controls.DataGridTextColumn  5?      -   5        Id??,  &System.Windows.Controls.DataGridColumn   Header$ Id??5?   =      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6I      CanUserResize .     
Visibility$ Hidden=?6k   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6   ??  ?? Path$ Id?4  .System.Windows.Controls.DataGridTemplateColumn  5?      $  ??65   $ 70 6?      
IsReadOnly .    DisplayIndex$ 0??6\      CellTemplate 5?   "   ?? 5?   &   .R?5?   *   ??   ??Name$  imgEdit??60   $??/Images/edit-button.png??6A   ! ? ToolTip$
! Edit??6b   $??20??6q   $??20??6|   5?   '   5?        5?      $  ??65   $ 70 6?    . $ 1??6\    5?   "   ?? 5?   &   .R?5?   *   ?? $  	imgDelete??60   $??/Images/delete-button.png??6C   $! Delete??6f   $??20??6w   $??20??6?   5?   '   5?        5?      -   5        
Amount??$ Amount??5?   A   $	 100 6Q    .  .  "   CanUserReorder" .   6?   ?? $ Amount?  5?      -   5        CurrencyName??$ Currency Name??5?   G   $ * 6^   #   MinWidth$# 20Q?6h    .  .  " .   6?   ?? $ CurrencyName?5?      5?      5?      5?      5?      5?      