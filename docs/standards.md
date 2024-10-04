# CSCI 265 Team Standards and Processes (Phase 2)

## Team name: We Haven't Decided

## Project/product name: Surrounded

## Key contact person and email

 - Connor McDermid, mcdermidc@stumail.viu.ca 

## Document structure

In this document we will be addressing three core areas of standards and processes:
 - Documentation standards and processes
 - Coding standards and processes
 - Version control standards and processes

Each section includes discussion of how those standards/processes will be enforced, and how they will be reviewed for potential updates if/as needed.

## Documentation standards and processes

Documentation will be mostly in-code documentation. When creating new classes, methods, members, etc., Doxygen-style comments will be added to those objects. When a feature is merged to main, CI/CD will generate a Doxygen comprehensive document, stored in the docs/ directory.

When a method gets particularly long, or the reason for why something is done in a certain way would be unclear to an uninformed reader, inline comments should clarify the reason.

Documentation will be kept in a `docs/` directory off the project root, and will contain the Phase 1 documents, the requirements document, this standards document, and other Phase documents created in future.

The phase documents will each have a primary author responsible for updating that document as the term progresses. Changes will be submitted on the `docs` [feature branch](#vc). Changes will be approved by at least two other members by virtue of our pull request approval process.
Primary authors list:
[proposal.md](proposal.md) – Brandon Tobin
[charter.md](charter.md) – Quetzal Torres
[requirements.md](requirements.md) – Luka Karanovic
[Standards and Procedures](standards.md) – Connor McDermid
More to be added later.

To the extent possible, all documents should follow the format and conventions set out in the project template’s documents. Documents are expected to have proper grammar and spelling (Canadian English).

## Coding standards and processes

Unity uses C# as the engine’s scripting language. When working with C#, we will try to apply Microsoft’s [C# and .NET Coding Conventions](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions). 

Methods and functions should be kept short whenever possible – never more than a screen. If something is done repeatedly, it should be refactored into its own method. Avoid the use of global variables when practicable.

All code files (\*.cs) will be kept in a src/ directory off the project root. All assets (images, sounds, etc.) will be kept in an assets/ directory off the project root.

Features should be completed at a reasonable pace. Priority will be given to features that are “blockers” – that is, features whose development must be completed before some other portion of the project can continue.
As developers finish features, they will check to help complete blockers before taking out another feature assignment.

All code must be finalised and ready for testing two days before a submission, to allow time for testing, documentation of bugs, and patching.

## <a name=”vc”></a>Version control standards and processes

Version control will be set up on Github [here](https://github.com/wehaventdecided/surrounded) and will be maintained by Version Control Grandmaster Connor McDermid and apprentice Anmol Baidwan

We will be using multiple branches to ensure version control. There will be individual branches for each feature to be worked on, which, once the feature is deemed complete,
it will be pushed to a “testing” branch, where it will be tested for integration with the main code. Once everything works on the “testing” branch, it will be pushed to main.
Only code that works properly will be allowed on the main branch. 

GitHub provides limited tools for access control within a specific repository to users who do not pay for higher tiers, which limits our ability to restrict pushes to specific branches. 
When applicable, branch protection will be applied (to main and testing) requiring code reviews by at least one other member before a merge can continue. CI/CD will test for compilation success and trivial fatal errors.
Members designing features are responsible for writing unit tests for those features and showing that they pass before a merge to testing will be permitted.
Our QA specialist will be responsible for designing integration testing for the testing branch and showing that it passes before a merge to main will be permitted.

A single commit should never modify more than 200 lines. Commit message titles should be clear, and commit messages should be clearly descriptive about the changes made. Separate commits should be made to resolve separate issues.

