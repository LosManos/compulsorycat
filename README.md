# CompulsoryCat
is a small collection of helper methods.

## There is the class MetaData for getting meta data out of dotnet4 classes.
Use it for instance for avoiding

```csharp
    void MyMethod(){
        MyLoggingMethod( "MyMethod", "Start" );
        ...
```
and instead

```csharp
    void MyMethod(){
        MyLoggingMethod( GetMethod().Name, "Start" );
        ...
```

See a tad more <a href="http://code.google.com/p/compulsorycat/source/browse/trunk/CompulsoryCat/CompulsoryCatExample/Program.cs">here</a>.

## There is the class Assemblyname for retrieving a tree of the AssemblyNames the running application uses.
See a tad more <a href="http://code.google.com/p/compulsorycat/source/browse/trunk/CompulsoryCat/ApplicationInfoExample/Program.cs">here</a>.

There is a helper method for splitting a string into parts.

```csharp
"abcdefg".SplitToLength(3) => "abc","def","g"
```

----

Original, and deprecated, repository was at Google code: https://code.google.com/p/compulsorycat/

----

Protecting angel is Lews Carrol.
So every file should begin with a tribute
which is a quote.

Continue from here:
http://www.alice-in-wonderland.net/books/1poem1.html
Last used quote:
Presently she began again. `I wonder if I shall fall right THROUGH the earth! How funny it'll seem to come out among the people that walk with their heads downward! The Antipathies, I think--' (she was rather glad there WAS no one listening, this time, as it didn't sound at all the right word) `--but I shall have to ask them what the name of the country is, you know. Please, Ma'am, is this New Zealand or Australia?' (and she tried to curtsey as she spoke--fancy CURTSEYING as you're falling through the air! Do you think you could manage it?) `And what an ignorant little girl she'll think me for asking! No, it'll never do to ask: perhaps I shall see it written up somewhere.'
