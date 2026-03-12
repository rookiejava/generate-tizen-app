# Tizen.UI

**Tizen.UI** is a lightweight C# UI framework to make Tizen .NET apps lighter and more performant.

### Key Concepts

#### Slim View Hierarchy
- Provides a much simpler and lighter view hierarchy than before.
- Only the essential and necessary APIs are provided.

#### [Enhanced Layout System](Tizen.UI.Layout-Overview)
- Two phases layout process – Measure() and Arrange().
- Optimized layouts within the scope of changes.

#### Effective Memory Management
- Minimize the use of expensive _Reflection_
- [Effective data object management]((Effective-data-object-management)) & [Effective native handle management](Effective-native-handle-management)
  - Separate the Native and C# data objects independently.
  - All C# data objects are represented as struct to ensure not stored on the heap.
  - No need for native calls of the creation of native objects, even with frequent C# data object creation and deletion.
- [Use _Object Pool_](Using-ObjectPool-for-temporary-object)
  - Objects created once for each type are reused for subsequent creations.
  - Object Pool is applicable only to objects that use the Stack.
- Effective children view lifecycle management
  - When the parent view is removed, it also removes all the child views it contains.
  - No longer a need to clean up the view tree in the _dispose()_ of each component.

#### [C# Markup](Tizen.UI-C#-Markup) (Declarative UI)
- A set of fluent helper methods and classes designed to simplify the process of building declarative user interfaces in code.

#### Aligned with .NET Framework Design guidelines
- Adheres to the [.NET Framework Design guidelines](https://learn.microsoft.com/en-us/dotnet/standard/design-guidelines/) and [Conding Standard](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions) and best practices to ensure high code quality and consistency.
  - Follows the [naming convension and guidelines](https://learn.microsoft.com/en-us/dotnet/standard/design-guidelines/naming-guidelines).
  - Follows the [Dispose pattern](https://learn.microsoft.com/en-us/dotnet/standard/design-guidelines/dispose-pattern)
  - Use _SafeHandle_ for representing a wrapper class for native platform handles, not _HandleRef_.
  - ...
