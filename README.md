# Data Structures
This repository has a project that contains multiple smaller projects that implement data structures and test their usability

## File Structure
- `EllenderRy_AlgoDataStructures.sln` is the Visual Studio solution that can run the available projects
- `EllenderRy_<InsertFolderName>` are the folders containing the test projects for each data structure
- `<InsertFolderName>Library` are the libraries containing the implementation of each data structure

# Installation
__This project is built for XUnit Testing in Visual Studio__

## Visual Studio Setup
- Clone the repository via exporting a zip or using `git clone https://github.com/TheGreatRy/DataStructures.git`
- Open the solution in [any version of Visual Studio](https://visualstudio.microsoft.com/downloads/).
  - This project was built with `Visual Studio Enterprise`, but a public accessible version is `Visual Studio Community`

# Running Tests
- Running/Debugging using the solution ▶️ buttons will **NOT** run the tests

❎<img width="1620" height="91" alt="image" src="https://github.com/user-attachments/assets/0d59febd-ddc6-4e70-8cf2-f379c8a244d8" />

- You need to open a `Test Explorer` tab, which will compile all available tests to run

☑️ <img width="614" height="78" alt="image" src="https://github.com/user-attachments/assets/e48a65b9-ac26-4aff-8f26-e419de2a6b61" />

  - Each set expands to subsets of tests that you can run together or individually.
  - Select the level of tests you want to run (these should all pass)

## Editing Tests
- Any of the tests can be edited in the `.cs` file in `EllenderRy_<InsertFolderName>`
- I recommend look at the [Microsoft Learn Article on C# Unit Testing](https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-csharp-with-xunit) for creating your own tests!
