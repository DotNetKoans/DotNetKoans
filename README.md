# .Net Core Koans [![Build status](https://ci.appveyor.com/api/projects/status/j0ykx336513hmnep/branch/master?svg=true)](https://ci.appveyor.com/project/NotMyself/dotnetcorekoans/branch/master) [![Join the chat at https://gitter.im/dotnetcorekoans/Lobby](https://badges.gitter.im/dotnetcorekoans/Lobby.svg)](https://gitter.im/dotnetcorekoans/Lobby?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge)

The .NET Core Koans walk you along the path to enlightenment in order to learn C# on .NET Core. The goal is to learn C# syntax, structure and some common functions and libraries available on the .NET Core platform. .NET Core is a cross platform environment that runs happily on Windows, OS X and Linux. It is super simple to get started learning.

### The Structure

The koans are broken out into areas by file, arrays are covered in AboutArrays.cs, lambdas are introduced in AboutLambdas.cs, etc. They are presented in order in the PathToEnlightenment.cs file.

Each koan builds up your knowledge of C# and builds upon itself. It will stop at the first place you need to correct.

Some koans simply need to have the correct answer substituted for an incorrect one. Some, however, require you to supply your own answer. If you see the object FILL_ME_IN listed, it is a hint to you to supply your own code in order to make it work correctly.

### Getting Started

1. Install [.NET Core SDK 2.0](https://www.microsoft.com/net/core).
2. Install [Visual Studio Code](https://code.visualstudio.com/), the [Insiders Edition](https://code.visualstudio.com/insiders) is highly recommended.
3. Clone the repository: `git clone https://github.com/NotMyself/DotNetCoreKoans.git`.
4. Change directory into the cloned repository `cd DotNetCoreKoans`.
5. Restore packages: `dotnet restore`.
6. Open the project in VSCode `code-insiders .` or `code .` depending on what version you chose to install.
7. Run the koans in watch mode: `dotnet watch --quiet run`.
    - **Note:** The `--quiet` flag is used here to suppress mesages from the watch framework.
8. Follow along with the instructions printed to your console. Each time you save a *.cs file, the project will be built and run again for you automatically.

### Contributing

There are many topics yet to be covered by this set of koans. I have added a handful of needed topics as [issues](https://github.com/NotMyself/DotNetCoreKoans/issues) and tagged them as [Up for Grabs](https://github.com/NotMyself/DotNetCoreKoans/issues?q=is%3Aopen+is%3Aissue+label%3A%22Up+for+Grabs%22). There are even some specifically tagged as [Beginner Friendly](https://github.com/NotMyself/DotNetCoreKoans/issues?q=is%3Aopen+is%3Aissue+label%3A%22Beginner+Friendly%22).

If you have never contributed to an open source project, let this be your first. Take a stab at updating the AboutStrings Koan to include information about [interpolation](https://github.com/NotMyself/DotNetCoreKoans/issues/7) then submit it as a pull request. I promise to work with you to get your contribution into the repository and be friendly and encouraging about it. It is what Jim would have done.

If you think a topic is missing, propose it's inclusion by [submitting an issue](https://github.com/NotMyself/DotNetCoreKoans/issues/new) yourself. Or better yet submit the issue and an accompanying pull request with how you think the topic should be introduced. Think about beginners in your effort; be clear and informative, be concise and most of all be playful with your examples.


### About Koans

This project is based on the work of [Cory Foy](https://github.com/CoryFoy) and his original multi-language project [DotNetKoans](https://github.com/CoryFoy/DotNetKoans). If you are interested in learning VB.NET or the Full .NET Framework (windows only), please look at his fine work.


Programming Koans came about because of the most enlightened [Ruby Koans](https://github.com/edgecase/ruby_koans) by [Jim Weirich](https://github.com/jimweirich). Jim was a great teacher & programmer whom I had the pleasure of meeting, learning from and playing games with. Rest in peace, sir. We will continue your effort to bring a love of the craft to anyone willing to learn.

For a fuller explanation of what is going here, see the blog post [Learn C# on Windows, OSX or Linux with the .NET Core Koans](http://iamnotmyself.com/2016/07/22/learn-c-on-windows-osx-or-linux-with-the-net-core-koans-2/)
