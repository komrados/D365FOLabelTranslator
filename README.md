# D365FOLabelTranslator
D365FOLabelTranslator is the Visual Studio 2019 extension tool which allows automatically translate labels at Dynamics 365 for Finance and Operations to the needed languages. This tool could be useful for developer teams which are creating multilingual F&O solutions. 
Of course there is a standard MS solution for automatic translation, based on LCS (https://docs.microsoft.com/en-us/dynamics365/fin-ops-core/dev-itpro/lifecycle-services/translation-service-overview) but in some cases its usage is quite time consuming. This tool allows to do the same but just in a few mouse clicks.

# Technical 
D365FOLabelTranslator is build upon MS Azure translator service, so it requires active Azure subscription with created translator service. 
https://azure.microsoft.com/en-us/services/cognitive-services/translator/#overview

# Installation & setup
1. Download VSIX file and install tool
2. In the Tools/Options new setup menu will be created "Dynamics 365 Labels Translation". In this menu following Azure Translator service parameters should be specified:
	- Location/Region 		    - This is the location/region of the Azure translation service resource. 
	- Text translation API 		- Text translation API endpoint
	- Translator service key	- Azure translator service key

![image](https://user-images.githubusercontent.com/50162691/183013805-e34b7de8-c1b5-4057-b1c0-4d6ad73a524b.png)
![image](https://user-images.githubusercontent.com/50162691/183009243-f81a6d10-5ab6-4348-84bd-7b191ad56021.png)


# Translation process
After new labels in the basic language (this is usually an En-US language, as it is used as a basic language in the Azure translator service) was created, new option "Translate labels" 
on the label resource file (*.txt) can be used.

![image](https://user-images.githubusercontent.com/50162691/183012458-eea780c6-ea6c-4d26-b2d7-9bb80ec7e446.png)

By this option tool will:
1. collect all labels from the selected label resource file; 
2. determine what other languages exists for selected label file;
3. for each language will read related label resource file and determine what labels are absent there but present in the basic label resource file (comparison made by label Id);
4. then these absent labels will be translated to the appropriate languages,
5. and new translated labels will be created in the appropriate label resource files.
