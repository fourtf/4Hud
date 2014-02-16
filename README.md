4Hud
====

A TF2 Hud editor for Windows

Project file is 4Hud/4Hud/4Hud.csproj

Welcome to the 4Plug source code.
Written in C# for .net 2.0 and created with Visual Studio 2010

On a messyness level from 0 to 10 I'd give it a 7 so good luck figuring out how stuff works.

4Hud uses a custom build version of Fast Colored Textbox so you may wanna check out how that works here:
	http://www.codeproject.com/Articles/161871/Fast-Colored-TextBox-for-syntax-highlighting

Here's a quick overview over what the different files do:
Important stuff:
	Program.cs
		Main Start Point
	Form1.cs
		Main Form
		Eventhandlers
	Settings.cs
		An old version of a class I wrote to handle settings.
	SplitFCTB.cs
		The Editor control with split and everything
	TabContent.cs
		Class that holds all the data of a tab while it's not visible
	TF.cs
		Some functions that have to do with the tf2 window
	TreeView.cs
		Eventhandlers for the treeviews


Other Stuff:
	ColorStyle.cs
		Custom style for FCTB, to draw colors colored.
		It parses the text it's supposed to draw while drawing.
	DragTabControl.cs
		Extension of the TabControl to allow drag 'n' drop of pages
	Editor.cs
		SaveAll() function
	KeyChooser.cs
		Key Choose Control
	LaunchPresent.cs
		Struct that holds the args when launching tf2
	Line.cs
		A control that draws a single line
	OpenFolderDialog.cs
		Open Folder Dialogs
	SelectHudPathForm.cs
		Select Hud Path Form
	SettingsDialog.cs
		Editor for the "Settings" menu entry
	TFKey.cs
		Everything key releated
	Transpanel.cs
		The panel that appears transparent in the editor + the line stuff
	Win32.cs
		Winapi calls

Unused stuff:
 	TFLabel.cs
		Unused control for main menu editor
	TFObject.cs
		Usused class for main menu editor
	ITFControl.cs
		Unused interface for main menu editor
	MainMenuDesigner.cs
		Unused
