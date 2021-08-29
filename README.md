<p align="center">
<img width="300px" src="https://raw.githubusercontent.com/NotMyself/DotNetCoreKoans/master/static/img/dot-net-core-koans-logo.svg" />
</p>


# .Net Core Koans 
[![Build status](https://ci.appveyor.com/api/projects/status/j0ykx336513hmnep/branch/master?svg=true)](https://ci.appveyor.com/project/NotMyself/dotnetcorekoans/branch/master)<!-- ALL-CONTRIBUTORS-BADGE:START - Do not remove or modify this section -->
[![All Contributors](https://img.shields.io/badge/all_contributors-31-orange.svg?style=flat-square)](#contributors-)
<!-- ALL-CONTRIBUTORS-BADGE:END -->
</div>
The .NET Core Koans walk you along the path to enlightenment in order to learn C# on .NET Core. The goal is to learn C# syntax, structure and some common functions and libraries available on the .NET Core platform. .NET Core is a cross platform environment that runs happily on Windows, OS X and Linux. It is super simple to get started learning.

### The Structure

The koans are broken out into areas by file, arrays are covered in AboutArrays.cs, lambdas are introduced in AboutLambdas.cs, etc. They are presented in order in the PathToEnlightenment.cs file.

Each koan builds up your knowledge of C# and builds upon itself. It will stop at the first place you need to correct.

Some koans simply need to have the correct answer substituted for an incorrect one. Some, however, require you to supply your own answer. If you see the object FILL_ME_IN listed, it is a hint to you to supply your own code in order to make it work correctly.

### Getting Started

<div align="center">
      <a href="https://www.youtube.com/watch?v=ta43g95Hznk">
     <img 
      src="https://s3-us-west-1.amazonaws.com/iamnotmyself-com/2020/11/Screen-Shot-2020-11-01-at-1.05.28-PM.png" 
      alt=".NET Core Koans" 
      style="width:100%;">
      </a>
    </div>

#### Running Locally

1. Install [.NET Core SDK 3.1](https://www.microsoft.com/net/core).
2. Install [Visual Studio Code](https://code.visualstudio.com/), the [Insiders Edition](https://code.visualstudio.com/insiders) is highly recommended.
3. Clone the repository: `git clone https://github.com/NotMyself/DotNetCoreKoans.git`.
4. Change directory into the cloned repository `cd DotNetCoreKoans`.
5. Restore packages: `dotnet restore`.
6. Open the project in VSCode `code-insiders .` or `code .` depending on what version you chose to install.
7. Run the koans in watch mode: `dotnet watch --quiet run`.
   - **Note:** The `--quiet` flag is used here to suppress messages from the watch framework.
8. Follow along with the instructions printed to your console. Each time you save a \*.cs file, the project will be built and run again for you automatically.

### Contributing

Want to contribute? Check out our [Code of Conduct](CODE_OF_CONDUCT.md) and [Contributing](CONTRIBUTING.md) docs. This project follows the [all-contributors](https://github.com/all-contributors/all-contributors) specification. Contributions of any kind welcome!

There are many topics yet to be covered by this set of koans. I have added a handful of needed topics as [issues](https://github.com/NotMyself/DotNetCoreKoans/issues) and tagged them as [Up for Grabs](https://github.com/NotMyself/DotNetCoreKoans/issues?q=is%3Aopen+is%3Aissue+label%3A%22Up+for+Grabs%22). There are even some specifically tagged as [Beginner Friendly](https://github.com/NotMyself/DotNetCoreKoans/issues?q=is%3Aopen+is%3Aissue+label%3A%22Beginner+Friendly%22).

If you have never contributed to an open source project, let this be your first. Take a stab at updating the AboutStrings Koan to include information about [interpolation](https://github.com/NotMyself/DotNetCoreKoans/issues/7) then submit it as a pull request. I promise to work with you to get your contribution into the repository and be friendly and encouraging about it. It is what Jim would have done.

If you think a topic is missing, propose it's inclusion by [submitting an issue](https://github.com/NotMyself/DotNetCoreKoans/issues/new) yourself. Or better yet submit the issue and an accompanying pull request with how you think the topic should be introduced. Think about beginners in your effort; be clear and informative, be concise and most of all be playful with your examples.

### About Koans

This project is based on the work of [Cory Foy](https://github.com/CoryFoy) and his original multi-language project [DotNetKoans](https://github.com/CoryFoy/DotNetKoans). If you are interested in learning VB.NET or the Full .NET Framework (windows only), please look at his fine work.

Programming Koans came about because of the most enlightened [Ruby Koans](https://github.com/edgecase/ruby_koans) by [Jim Weirich](https://github.com/jimweirich). Jim was a great teacher & programmer whom I had the pleasure of meeting, learning from and playing games with. Rest in peace, sir. We will continue your effort to bring a love of the craft to anyone willing to learn.

For a fuller explanation of what is going here, see the blog post [Learn C# on Windows, OSX or Linux with the .NET Core Koans](http://iamnotmyself.com/2016/07/22/learn-c-on-windows-osx-or-linux-with-the-net-core-koans-2/)

## Contributors ✨

Thanks goes to these wonderful people ([emoji key](https://allcontributors.org/docs/en/emoji-key)):

<!-- ALL-CONTRIBUTORS-LIST:START - Do not remove or modify this section -->
<!-- prettier-ignore-start -->
<!-- markdownlint-disable -->
<table>
  <tr>
    <td align="center"><a href="http://stackoverflow.com/users/1453907/john-hoerr"><img src="https://avatars1.githubusercontent.com/u/1151206?v=4" width="100px;" alt=""/><br /><sub><b>John Hoerr</b></sub></a><br /><a href="https://github.com/NotMyself/DotNetCoreKoans/commits?author=jhoerr" title="Code">💻</a></td>
    <td align="center"><a href="https://github.com/vgrigoriu"><img src="https://avatars3.githubusercontent.com/u/95696?v=4" width="100px;" alt=""/><br /><sub><b>Victor Grigoriu</b></sub></a><br /><a href="https://github.com/NotMyself/DotNetCoreKoans/commits?author=vgrigoriu" title="Code">💻</a></td>
    <td align="center"><a href="https://jamesnaylor.dev"><img src="https://avatars0.githubusercontent.com/u/3864985?v=4" width="100px;" alt=""/><br /><sub><b>James Naylor</b></sub></a><br /><a href="https://github.com/NotMyself/DotNetCoreKoans/commits?author=euronay" title="Code">💻</a></td>
    <td align="center"><a href="http://samcherinet.com"><img src="https://avatars1.githubusercontent.com/u/1375088?v=4" width="100px;" alt=""/><br /><sub><b>Samuel Cherinet</b></sub></a><br /><a href="https://github.com/NotMyself/DotNetCoreKoans/commits?author=samqty" title="Code">💻</a></td>
    <td align="center"><a href="https://github.com/cmdkeen"><img src="https://avatars3.githubusercontent.com/u/54735?v=4" width="100px;" alt=""/><br /><sub><b>Chris</b></sub></a><br /><a href="https://github.com/NotMyself/DotNetCoreKoans/commits?author=cmdkeen" title="Code">💻</a></td>
    <td align="center"><a href="https://github.com/delainewendling"><img src="https://avatars2.githubusercontent.com/u/12090406?v=4" width="100px;" alt=""/><br /><sub><b>Delaine Wendling</b></sub></a><br /><a href="https://github.com/NotMyself/DotNetCoreKoans/commits?author=delainewendling" title="Code">💻</a></td>
    <td align="center"><a href="https://github.com/allenz0810"><img src="https://avatars0.githubusercontent.com/u/5561722?v=4" width="100px;" alt=""/><br /><sub><b>Allen</b></sub></a><br /><a href="https://github.com/NotMyself/DotNetCoreKoans/commits?author=allenz0810" title="Code">💻</a></td>
  </tr>
  <tr>
    <td align="center"><a href="https://github.com/beforan"><img src="https://avatars0.githubusercontent.com/u/1846005?v=4" width="100px;" alt=""/><br /><sub><b>Jonathan Couldridge</b></sub></a><br /><a href="https://github.com/NotMyself/DotNetCoreKoans/commits?author=beforan" title="Code">💻</a></td>
    <td align="center"><a href="https://www.linkedin.com/in/lukas-sinkus/"><img src="https://avatars1.githubusercontent.com/u/10304156?v=4" width="100px;" alt=""/><br /><sub><b>Lukas Sinkus</b></sub></a><br /><a href="https://github.com/NotMyself/DotNetCoreKoans/commits?author=LUS1N" title="Code">💻</a></td>
    <td align="center"><a href="http://www.dutton.me.uk"><img src="https://avatars1.githubusercontent.com/u/2182427?v=4" width="100px;" alt=""/><br /><sub><b>Richard D</b></sub></a><br /><a href="https://github.com/NotMyself/DotNetCoreKoans/commits?author=dutts" title="Code">💻</a></td>
    <td align="center"><a href="http://www.meetup.com/Thessaloniki-NET-Meetup/"><img src="https://avatars2.githubusercontent.com/u/9317179?v=4" width="100px;" alt=""/><br /><sub><b>Stratos Kourtzanidis</b></sub></a><br /><a href="https://github.com/NotMyself/DotNetCoreKoans/commits?author=melkor54248" title="Code">💻</a></td>
    <td align="center"><a href="https://github.com/agustashd"><img src="https://avatars2.githubusercontent.com/u/22988154?v=4" width="100px;" alt=""/><br /><sub><b>Agustin</b></sub></a><br /><a href="https://github.com/NotMyself/DotNetCoreKoans/commits?author=agustashd" title="Code">💻</a></td>
    <td align="center"><a href="https://www.pontifex-tech.com"><img src="https://avatars2.githubusercontent.com/u/1691149?v=4" width="100px;" alt=""/><br /><sub><b>Matthew Parsons</b></sub></a><br /><a href="https://github.com/NotMyself/DotNetCoreKoans/commits?author=OranguTech" title="Code">💻</a></td>
    <td align="center"><a href="http://macleod.in"><img src="https://avatars0.githubusercontent.com/u/8996312?v=4" width="100px;" alt=""/><br /><sub><b>Jamie MacLeod</b></sub></a><br /><a href="https://github.com/NotMyself/DotNetCoreKoans/commits?author=macleodmac" title="Code">💻</a></td>
  </tr>
  <tr>
    <td align="center"><a href="https://github.com/pezholio"><img src="https://avatars0.githubusercontent.com/u/109774?v=4" width="100px;" alt=""/><br /><sub><b>Stuart Harrison</b></sub></a><br /><a href="https://github.com/NotMyself/DotNetCoreKoans/commits?author=pezholio" title="Code">💻</a></td>
    <td align="center"><a href="https://c-j.tech"><img src="https://avatars0.githubusercontent.com/u/3969086?v=4" width="100px;" alt=""/><br /><sub><b>Chris Jones</b></sub></a><br /><a href="https://github.com/NotMyself/DotNetCoreKoans/commits?author=cmjchrisjones" title="Documentation">📖</a></td>
    <td align="center"><a href="https://github.com/Dgaduin"><img src="https://avatars1.githubusercontent.com/u/2265194?v=4" width="100px;" alt=""/><br /><sub><b>Atanas Pashkov</b></sub></a><br /><a href="https://github.com/NotMyself/DotNetCoreKoans/commits?author=Dgaduin" title="Code">💻</a></td>
    <td align="center"><a href="http://ostebaronen.dk"><img src="https://avatars3.githubusercontent.com/u/249719?v=4" width="100px;" alt=""/><br /><sub><b>Tomasz Cielecki</b></sub></a><br /><a href="https://github.com/NotMyself/DotNetCoreKoans/commits?author=Cheesebaron" title="Code">💻</a></td>
    <td align="center"><a href="https://github.com/SophieLemos"><img src="https://avatars0.githubusercontent.com/u/48099481?v=4" width="100px;" alt=""/><br /><sub><b>SophieLemos</b></sub></a><br /><a href="https://github.com/NotMyself/DotNetCoreKoans/commits?author=SophieLemos" title="Code">💻</a> <a href="https://github.com/NotMyself/DotNetCoreKoans/issues?q=author%3ASophieLemos" title="Bug reports">🐛</a> <a href="#design-SophieLemos" title="Design">🎨</a> <a href="https://github.com/NotMyself/DotNetCoreKoans/commits?author=SophieLemos" title="Documentation">📖</a> <a href="#ideas-SophieLemos" title="Ideas, Planning, & Feedback">🤔</a></td>
    <td align="center"><a href="https://github.com/dsschnau"><img src="https://avatars1.githubusercontent.com/u/1373329?v=4" width="100px;" alt=""/><br /><sub><b>Dan Schnau</b></sub></a><br /><a href="https://github.com/NotMyself/DotNetCoreKoans/issues?q=author%3Adsschnau" title="Bug reports">🐛</a> <a href="https://github.com/NotMyself/DotNetCoreKoans/commits?author=dsschnau" title="Documentation">📖</a></td>
    <td align="center"><a href="http://www.joshuabelden.com"><img src="https://avatars3.githubusercontent.com/u/1337406?v=4" width="100px;" alt=""/><br /><sub><b>Joshua Belden</b></sub></a><br /><a href="https://github.com/NotMyself/DotNetCoreKoans/commits?author=JoshuaBelden" title="Code">💻</a></td>
  </tr>
  <tr>
    <td align="center"><a href="https://shawn.vause.us"><img src="https://avatars1.githubusercontent.com/u/8197405?v=4" width="100px;" alt=""/><br /><sub><b>Shawn Vause</b></sub></a><br /><a href="https://github.com/NotMyself/DotNetCoreKoans/commits?author=napalm684" title="Code">💻</a></td>
    <td align="center"><a href="https://github.com/jeannienguyen"><img src="https://avatars0.githubusercontent.com/u/44417397?v=4" width="100px;" alt=""/><br /><sub><b>Jeannie Nguyen</b></sub></a><br /><a href="#design-jeannienguyen" title="Design">🎨</a></td>
    <td align="center"><a href="https://github.com/A-Scratchy"><img src="https://avatars0.githubusercontent.com/u/25309929?v=4" width="100px;" alt=""/><br /><sub><b>Adam</b></sub></a><br /><a href="https://github.com/NotMyself/DotNetCoreKoans/commits?author=A-Scratchy" title="Code">💻</a></td>
    <td align="center"><a href="https://www.linkedin.com/in/benjamin-ferrier-95490060/"><img src="https://avatars2.githubusercontent.com/u/16334582?v=4" width="100px;" alt=""/><br /><sub><b>Ferrier Benjamin</b></sub></a><br /><a href="#question-Benjioe" title="Answering Questions">💬</a> <a href="https://github.com/NotMyself/DotNetCoreKoans/commits?author=Benjioe" title="Code">💻</a></td>
    <td align="center"><a href="https://about.me/ibrahim.islam"><img src="https://avatars3.githubusercontent.com/u/6401874?v=4" width="100px;" alt=""/><br /><sub><b>Ibrahim Islam</b></sub></a><br /><a href="https://github.com/NotMyself/DotNetCoreKoans/commits?author=Ibrahim-Islam" title="Code">💻</a></td>
    <td align="center"><a href="http://nikiforovall.github.io"><img src="https://avatars2.githubusercontent.com/u/8037439?v=4" width="100px;" alt=""/><br /><sub><b>Nikiforov Alexey</b></sub></a><br /><a href="https://github.com/NotMyself/DotNetCoreKoans/commits?author=NikiforovAll" title="Code">💻</a></td>
    <td align="center"><a href="http://www.ocimen.com"><img src="https://avatars2.githubusercontent.com/u/583585?v=4" width="100px;" alt=""/><br /><sub><b>Ozge Cimendere</b></sub></a><br /><a href="https://github.com/NotMyself/DotNetCoreKoans/commits?author=ocimen" title="Code">💻</a></td>
  </tr>
  <tr>
    <td align="center"><a href="https://www.linkedin.com/in/jakub-rusek-897968163/"><img src="https://avatars0.githubusercontent.com/u/29798657?v=4" width="100px;" alt=""/><br /><sub><b>Jakub Rusek</b></sub></a><br /><a href="https://github.com/NotMyself/DotNetCoreKoans/commits?author=IRusio" title="Code">💻</a></td>
    <td align="center"><a href="https://github.com/RAFAELDEV2016"><img src="https://avatars1.githubusercontent.com/u/29690569?v=4" width="100px;" alt=""/><br /><sub><b>RAFAELDEV2016</b></sub></a><br /><a href="#design-RAFAELDEV2016" title="Design">🎨</a></td>
    <td align="center"><a href="https://github.com/CedricRup"><img src="https://avatars3.githubusercontent.com/u/1677902?v=4" width="100px;" alt=""/><br /><sub><b>Cedric Rup</b></sub></a><br /><a href="https://github.com/NotMyself/DotNetCoreKoans/commits?author=CedricRup" title="Code">💻</a></td>
  </tr>
</table>

<!-- markdownlint-enable -->
<!-- prettier-ignore-end -->
<!-- ALL-CONTRIBUTORS-LIST:END -->

This project follows the [all-contributors](https://github.com/all-contributors/all-contributors) specification. Contributions of any kind welcome!
