# Learning by doing **C#**

## Plan / work

A check-mark indicates area has been covered. Either as tutorial or
directly in one of the applied projects.

* [polygons_cs](https://github.com/mambrus/polygons_cs)

## Fundamentals

- [x] Inheritance
- [x] Interface
- [x] Generics
- [x] Namespaces
- [x] Operator overloading
- [X] Build-system and fundamental tools (Visual Studio v.s./and/or CMake)

## Targeted areas

- [x] [Properties](https://www.tutorialspoint.com/csharp/csharp_properties.htm)
- [x] Indexers
- [x] Exeptions
- [x] [Attributes](https://www.tutorialspoint.com/csharp/csharp_attributes.htm)
  - [x] [Reflections](https://www.tutorialspoint.com/csharp/csharp_reflection.htm)
- [ ] [LINQ](https://www.tutorialspoint.com/linq/index.htm)
  - [x] [Lambda expressions](https://www.tutorialspoint.com/linq/linq_lambda_expressions.htm)
 
- [ ] [Collections fundamenta](http://www.c-sharpcorner.com/UploadFile/dacca2/implement-ienumerable-interface-in-C-Sharp/)
- [ ] Delegates
  - [ ] [Events](https://www.tutorialspoint.com/csharp/csharp_events.htm)
  - [x] `Func< T >`
  - [ ] `Action< T >`
  - [ ] `Predicate< T >`
- [ ] Constraints
- [ ] Windows (C#) concurrency techniques
   - [ ] Threads
   - [ ] Task
     - [x] `TaskFactory` and group sychronization 
   - [ ] Synchronization
     - [ ] [Cancelaton token](https://msdn.microsoft.com/en-us/library/system.threading.cancellationtokensource(v=vs.110).aspx)
       - [ ] Used for canceling
       - [x] [completion notification (blocking)](https://msdn.microsoft.com/en-us/library/dd997364(v=vs.110).aspx)

*(Plan so far. Probably more to follow...)*

## References

* Tutorials & Labs ()
	* [tutorialspoint](https://www.tutorialspoint.com/csharp/)
		* [Reflections](https://www.tutorialspoint.com/csharp/csharp_reflection.htm)
		* [Operators](https://www.tutorialspoint.com/csharp/csharp_operators.htm)
* "Language" specifics
    * [Auto-Implemented Properties](https://msdn.microsoft.com/en-us/library/bb383979.aspx)
    * [Q: Func vs. Action vs. Predicate](http://stackoverflow.com/questions/4317479/func-vs-action-vs-predicate) 

* CMake
	* [CMake and VisualStudio](https://cognitivewaves.wordpress.com/cmake-and-visual-studio/)
	* [CMake tutorial](https://cmake.org/cmake-tutorial/)
	* [Q: Generate from](http://stackoverflow.com/questions/2074144/generate-c-sharp-project-using-cmake)
* Operator overloading & constraints
	* [Q: Contraint for the + operator](http://stackoverflow.com/questions/5997107/is-there-a-generic-constraint-i-could-use-for-the-operator)
	* [Q: Contraint to numeric types](http://stackoverflow.com/questions/32664/is-there-a-constraint-that-restricts-my-generic-method-to-numeric-types)
	* [Q: Arithmetic operator overloading](http://stackoverflow.com/questions/756954/arithmetic-operator-overloading-for-a-generic-class-in-c-sharp)
* Other
	* [VS build macros](https://msdn.microsoft.com/en-us/library/c02as0cs.aspx)
	* [Miscellaneous Utility Library](http://www.yoda.arachsys.com/csharp/miscutil/)
    * [Functional programming](https://www.codeproject.com/Articles/375166/Functional-programming-in-Csharp) Lambda e.t.c.


# Notes / progress

## 2017-04-27

## Language rambling

C# is not a language, it's a script-syntax and a run-time. Similar to Java
and Java class-libraries in a sense, but with the difference that Java
language-syntax is strictly defined and the runtime is a separate (3'rd)
entity.

For C#, the runtime (CLR) **is part of .NET** and also explains why the two
are so heavily intertwined. I.e. C# syntax and abilities changes with it's
runtime. One obvious drawback of this is that C# programs (i.e. source-code),
similarly to Pythons, become version sensitive. See git-history for recent
bug-fix/workaround example (Attributes/Reflection).

The recent Attributes/Reflection exercises has shown me just how un-alike
C++ and C# really are. One observation: In C#, everything that isn't a
primitive scalar *is an Object*, furthermore each with it's complete
complete "data-base" for run-time. I.e. an instantiated variable is just the
top of an ice-berg compared to C++. This has to come with a hefty run-time
price. I have i.e. serious doubts C# will ever become standard/preferred for
embedded use-case. *The two with fit together as badly as children and
bazookas...* :-)

## Other

**I'm considering** to abandon the ** polygons_cxx\* ** projects and
continue with **polygons_cs** only. The differences between *C++* and *C#*
start to become too great as many C# language features just don't have any
corresponding equality in C++. Keeping the shadow C++ projects on par,
considering how much slower writing in C++ is, has become a serious burden.
