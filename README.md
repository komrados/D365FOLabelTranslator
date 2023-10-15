# D365FOLabelTranslator
D365FOLabelTranslator is the Visual Studio 2019 and Visual Studio 2017 extension tool which allows to automatically translate labels at Dynamics 365 for Finance and Operations to the needed languages. This tool could be useful for developer teams which are creating multilingual F&O solutions. 

Of course there is a standard MS solution for automatic translation, based on LCS (https://docs.microsoft.com/en-us/dynamics365/fin-ops-core/dev-itpro/lifecycle-services/translation-service-overview) but in some cases its usage is quite time consuming. 

This tool allows to do the same but just in a few mouse clicks. Also this tool allows to use other than Azure translation service providers, like Google and Yandex. This could be useful for translation quality improvement.

# Technical 
D365FOLabelTranslator is build upon cloud translation service provider (TSP), so it requires active cloud subscription with created translator service to work on.

For now D365FOLabelTranslator supports following TSPs:
* **Google Cloud Translation API** (https://cloud.google.com/translate?hl=en)
* **Yandex Translate** (https://cloud.yandex.com/en/docs/translate/)
* **Azure Translator** (https://azure.microsoft.com/en-us/services/cognitive-services/translator/#overview)

# Installation & setup
1. Download VSIX file and install tool
2. In the Tools/Options new setup menu will appear "Dynamics 365 Labels Translation". In this menu translation service provider should be selected. For each TSP there will be different set of parameters below.
   ![1](https://github.com/komrados/D365FOLabelTranslator/assets/50162691/ca6bc6cb-d2c2-42d9-9bb9-93cfaaedab65)

* For Google Cloud Translation following parameters are requred:
	- **Json Credentials**		- In this field should be specified entire content of the Json file which will be received after new Key creation process. Just open Json file in any text editor and copy all the text from it into this parameter field.
	- **Project**			- The name of the Google cloud project in which translation service is created.

   ![image](https://github.com/komrados/D365FOLabelTranslator/assets/50162691/ebf5988d-ef05-48e2-a05c-aea68bcab9d9)
   ![image](https://github.com/komrados/D365FOLabelTranslator/assets/50162691/4671a239-7e20-4b1e-a41d-7f9005f042ac)

* For Yandex Translate service following parameters are required:
	- **API Key** 			- Secret API Key, which provided once just after API key created. 
	- **API Endpoint** 		- Text translation API endpoint. Usually (https://translate.api.cloud.yandex.net/translate/v2)
	- **Folder Id** 		- The cloud folder in which translation service is created.

   ![4](https://github.com/komrados/D365FOLabelTranslator/assets/50162691/f19c793a-f589-49f5-8bb0-6f555fa3d617)
   ![5](https://github.com/komrados/D365FOLabelTranslator/assets/50162691/ca8dfa27-98e5-4869-913f-08ef76fb396e)
   ![image](https://github.com/komrados/D365FOLabelTranslator/assets/50162691/19b7a2e2-2a92-49fe-a314-c812ed5fc7dd)


* For Azure Translator service following parameters should be specified:
	- **API key**			- Azure translator service key
	- **API Endpoint** 		- Text translation API endpoint
	- **Location/Region** 		- This is the location/region of the Azure translation service resource. 

   ![image](https://github.com/komrados/D365FOLabelTranslator/assets/50162691/c1115d08-53e0-4f46-b4e1-b80d410e1af2)
   ![image](https://user-images.githubusercontent.com/50162691/183009243-f81a6d10-5ab6-4348-84bd-7b191ad56021.png)


# Translation process
After new labels in the basic language was created by developer, new option "Translate labels" on the label resource file (*.txt) can be used in the Solution Explorer.

   ![image](https://user-images.githubusercontent.com/50162691/183012458-eea780c6-ea6c-4d26-b2d7-9bb80ec7e446.png)

By this option tool will determine which labels are present in the selected basic language file but absent in all other language files and will translate only these delta labels.

In details steps which tool performs are following:
1. collect all labels from the selected label resource file; 
2. determine what other languages exists for selected label file;
3. for each language will read related label resource file and determine what labels are absent there but present in the basic label resource file **(comparison made by label Id)**;
4. then these absent labels will be translated to the appropriate languages,
5. and new translated labels will be created in the appropriate label resource files.

Label Ids and Comments of the new created labels will be copied from ones in the basic language.
