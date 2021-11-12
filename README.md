
<div align="center">
  <img src="https://user-images.githubusercontent.com/1434865/141594907-4536905a-1302-4bf6-ad1f-b06af36edcc3.png"><br><br>
  <h1>
    Unlock Protocol / Unity Game Engine Integration
  </h1>

<p align="center">
    <img alt="GitHub" src="https://img.shields.io/github/license/thehen/unlock-unity-package">
</p>

  <p>Add paid memberships and content access to your Unity WebGL projects.</p>
</div>


![Unity Package Manager](https://omiyagames.github.io/template-unity-package/resources/preview.png)

## Overview

Easily add payments and NFTs to your Unity WebGL project - no coding  necessary. Users can purchase NFTs to grant access to content, purchase in-game items, provide ad-free experiences, buy tickets to in-game events, and lots more!

## Features 

- Accept payment in ETH or any other ERC20 token
- Credit card payments supported
- Ethereum Mainnet, xDAI, Polygon, Binance Smart Chain network support
- Set a limited or unlimited number of keys 
- Set duration for how long the keys last for (useful for recurring subscriptions!)

## Create Locks

You can easily create and manage locks through the Unlock Dashboard. For more information, refer to the [official Unlock Protocol documentation](https://docs.unlock-protocol.com/creators/deploying-lock).

## Adding the Unlock Protocol Package to your Unity Project

## Import the Examples

---

**Template Unity Package** is a Github template [Omiya Games](https://www.omiyagames.com/) uses to start a new [Unity](https://unity.com/) package.  To use this template for your own purposes, we recommend:

- Clicking on the green "Use this template" button to create a new online repository on Github directly, or
- Click the "Releases" link, and download the latest archive as zip or gzip file.

From there, consult the following documentation to get a better idea of what files should be edited and/or renamed, and how:

- This project's [own documentation](https://omiyagames.github.io/template-unity-package/)
- [*How to Split Up an Existing Unity Git Project into Smaller Unity Packages*](https://www.taroomiya.com/2020/04/29/how-to-split-up-an-existing-unity-git-project-into-smaller-unity-packages/) by [Taro Omiya](https://github.com/japtar10101)

This package uses [DocFX](https://dotnet.github.io/docfx/) and Github Actions to auto-generate its documentation from both the comments in the source code and the Markdown files in the [`Documentation~`](/Documentation~) directory.  Consult the manual on [customizing documentation files](https://omiyagames.github.io/template-unity-package/manual/customizeDocumentation.html) for your own packages.  There is also has a pre-made [Doxygen](https://github.com/doxygen/doxygen) settings file in the same directory to run Doxywizard through.

## Install



### Through [Unity Package Manager](https://docs.unity3d.com/Manual/upm-ui-giturl.html)

Unity's own Package Manager supports [importing packages through a URL to a Git repo](https://docs.unity3d.com/Manual/upm-ui-giturl.html):

1. First, on this repository page, click the "Clone or download" button, and copy over this repository's HTTPS URL.  
2. Then click on the + button on the upper-left-hand corner of the Package Manager, select "Add package from git URL..." on the context menu, then paste this repo's URL!
