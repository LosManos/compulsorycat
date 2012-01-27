Compulsory cat is a helper lib.

Release:
1.0
MetaData functionality
1.1
Updated MetaData functionality.
1.2
Added this document.
Added the Assemblyname functionality.
There are no unit tests for this new functionality but they are left as inconclusive.
Set the version to 1.2.* to get automatic increase.
Added help files to SVN.

Known Issues:
There should be a memory leak for every call to Assemblyname.Get since the loaded assemblies can't be unloaded.

TODO:
Move todo to issue managing in code.google.

Write unit tests for Assemblyname functionality.

The code loads new Assemblies from the entry assembly down.  
	First, these assemblies can't be unloaded so every call uses memory.  
	Secondly, since we don't iterate through the loaded Assemblies but instead through the references we can't be totally sure we are finding what is in reality loaded.
	It would be good to rewrite to really report the _loaded_ assemblies.  How does one do that?
