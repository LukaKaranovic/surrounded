# CSCI 265 Team Standards and Processes (Phase 2)

## Team name: We Haven't Decided

## Project/product name: Surrounded

## Key contact person and email

 - Connor McDermid, mcdermidconnor@outlook.com

## Table of Contents

[Documentation standards and processes](#docs) 

[Coding standards and processes](#code) 

[Version control standards and processes](#vc)

## Document structure

In this document we will be addressing three core areas of standards and processes:
 - Documentation standards and processes
 - Coding standards and processes
 - Version control standards and processes

Each section includes discussion of how those standards/processes will be enforced, and how they will be reviewed for potential updates if/as needed.

## <a name=”docs”></a>Documentation standards and processes

Documentation will be kept in a `docs/` directory off the project root, and will contain the proposal, team charter, requirements, standards and processes, design, project update, and other future documents.

Images included in the documentation will be kept in an `images/` subdirectory located inside the `docs/` directory mentioned above. 
Any/all image files must have relevant and useful names related to the content it holds and have the .png extension. 

All old documentation that is not currently in use (such as past project update deliverables) will be kept in an `archived/` subdirectory inside the `docs/` directory.

The phase documents will be maintained and updated each phase by Luka Karanovic as the term progresses. Changes will be submitted on the `docs` [feature branch](#vc). Changes will be approved by at least two other members by virtue of our pull request approval process.

List of phase documents:
[Proposal.md](proposal.md): the preliminary proposal deliverable (phase 1)
[Team Charter](charter.md): the team charter deliverable (phase 1)
[Requirements](requirements.md): the product requirements deliverable (phase 2)
[Standards and Procedures](standards.md): the standards and processes deliverable (phase 2)
[Logical Design](logicaldesign.md): the logical design deliverable (phase 3)
[Project Update](update.md): the project update deliverable for the most recent phase (currently phase 4)
[Proof of Concept](proofconcept.md): the proof of concept deliverable (phase 4)

More to be added later.

Documents are to, as closely as possible, follow the organization/layout structure provided by the course project/phase specifications and skeletal versions of the documents provided. If additional sections are needed within the documents, the heading and layout choices will be the same as the rest of the document to look and feel consistent.

To the extent possible, all documents should follow the format and conventions set out in the project template’s documents. Documents are expected to have proper grammar and spelling (Canadian English).

## <a name=”code”></a>Coding standards and processes

Unity uses C# as the engine’s scripting language. When working with C#, we will try to apply Microsoft’s [C# and .NET Coding Conventions](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions). 

Methods and functions should be kept short whenever possible – never more than a screen. If something is done repeatedly, it should be refactored into its own method. Avoid the use of global variables when practicable.

All code files (\*.cs) will be kept in a src/ directory off the project root. All assets (images, sounds, etc.) will be kept in an `assets/` directory off the project root.

Features should be completed at a reasonable pace. Priority will be given to features that are “blockers” – that is, features whose development must be completed before some other portion of the project can continue.
As developers finish features, they will check to help complete blockers before taking out another feature assignment.

For in-code documentation: When creating new classes, methods, members, etc., Doxygen-style comments will be added to those objects. When a feature is merged to main, CI/CD will generate a Doxygen comprehensive document, stored in a `code-docs/` directory off the project root. This is not to be confused with the `docs/` directory for phase documentation.

When a method gets particularly long, or the reason for why something is done in a certain way would be unclear to an uninformed reader, inline comments should clarify the reason.

*Code Reviews:*
Before merging code into the testing branch, it is required at least one other member does a code review before a merge can continue. This mechanism is done via a 'pull request' (more context on this in the [version control section](#vc)).
* Members designing features are responsible for writing basic unit tests for those features and showing that they pass before a merge to testing will be permitted. 
* The reviewer must be able to understand the code and must ensure the code writer has provided proper in-code documentation. 
    * If the reviewer does not understand part of the code, it must be described in the in-code documentation. If not, the code writer must go back and edit the comments to explain said parts before merging.
* Both the reviewer and code writer must ensure the logic looks good enough before merging into the testing branch. The code does not have to be perfect because it is being tested in the testing branch.

All code must be finalised and ready for testing atleast two days before a submission to allow time for testing, documentation of bugs, and patching.

*Disclaimer: This section is subject to change when we actually start developing our product in phase 5 as we learn what works better for the group in terms of efficiency and reducing confusion*

## <a name=”vc”></a>Version control standards and processes

Version control will be set up on GitHub [here](https://github.com/wehaventdecided/surrounded) and will be maintained by Version Control Grandmaster Connor McDermid and apprentice Anmol Baidwan.

We will be using multiple branches to ensure proper version control. There will be individual branches for each feature to be worked on, which, once the feature is deemed complete, it will be pushed to a “testing” branch, where it will be tested for integration with the main code. Once everything works on the “testing” branch, it will be pushed to main.
Only code that works properly will be allowed on the main branch (more on that below). 

GitHub provides limited tools for access control within a specific repository to users who do not pay for higher tiers, which limits our ability to restrict pushes to specific branches. 

When applicable, branch protection will be applied (to main and testing) requiring code reviews by at least one other member before a merge can continue (described in coding standards and processes). 

The branch protection process for merging feature branches to testing is as follows:
* The code writer creates a pull request when they are ready to commit changes. A comment is left on the pull-request describing the changes.
* We have a GitHub bot linked to our repository in our team project discord server. When a pull request is made, it will send a message in the #github channel notifying others of this request.
* The code writer must then request a review officially on GitHub, where a reviewer must accept this request and look at the changes.
* After the review, if the code/documentation is deemed to be up to standard, the changes will be merged into the testing branch.

The branch protection process for merging the testing branch to main is as follows:
* Our QA specialist will be responsible for designing integration testing for the testing branch and showing that it passes before a merge to main will be permitted.
* This process must happen two days before the phase deadline, or any time we feel like there are significant enough changes to the project that we want to save.
* Only the git lead (Connor) will be allowed to merge the contents of the testing branch into main. This will be done after all code works with (little to) no errors and after the changes are reviewed by at least three members of the group (including Connor).
* Only the contents in the testing branch will be merged to main, as that is the only branch where features are actively being tested together to ensure they work with one another.

A single commit ideally should never modify more than 200 lines. Commit message titles should be clear, and commit messages should be clearly descriptive about the changes made. Separate commits should be made to resolve separate issues.

