
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

## Install

1. In Unity, open the Package Manager by opening `Window/Package Manager`
2. Then click on the + button on the upper-left-hand corner of the Package Manager, select "Add package from git URL..." on the context menu, then paste the following: ```https://github.com/thehen/unlock-unity-package/```

![packagefromurl](https://user-images.githubusercontent.com/1434865/141595366-fcc29d10-ee13-4436-a5aa-308c2981125a.png)

3. Now setup Unlock Protocol by selecting `Unlock Protocol/Setup Unlock Protocol`.

![setup](https://user-images.githubusercontent.com/1434865/141595923-c1b837f6-5782-4c29-ae06-62598cd107c2.png)

4. Finally, open up `Edit/Project Settings/Player` and select the `Unlock-paywall` WebGL Template.

![webgltemplate](https://user-images.githubusercontent.com/1434865/141598055-83a82773-94ed-4fb9-ba23-7ac90cab4c47.png)

## Import the Examples

1. In Unity, open the Package Manager by opening `Window/Package Manager`
1. Ensure you're viewing `Packages: In Project` and select `Unlock Protocol`
2. Under the Samples dropdown, press import next to the sample you want to include in the project.

![samples](https://user-images.githubusercontent.com/1434865/141598403-05d7d031-a1c0-4bd2-822b-882c4f719568.png)

## Adding the Paywall to a new Scene

1.) Create a new Unity scene and open it up.

2.) Create a Lock config file by selecting `Assets/Create/Unlock/Lock Config`

3.) Select the Lock config file and fill in the lock details as follows.

`0x9b9b3b8B1B2Bf18e91592101dF90F26dBde3089F`

`Unity Plugin Demo`

`4`

![lockconfig](https://user-images.githubusercontent.com/1434865/141599042-d4ba4aeb-db00-4706-afca-b8b31d3bbf54.png)

4.) Create a Paywall config file by selecting `Assets/Create/Unlock/Paywall Config`.

5.) Select the Paywall config file and add your Lock config file to the Lock Configs:

![lockconfigs](https://user-images.githubusercontent.com/1434865/141599193-17cca1d0-9e45-4585-b202-42cacb215ee4.png)

6.) Add a UI and a button by selecting `GameObject/UI/Button`.

7.) Drag the `UnlockPaywall` prefab into the scene from `Packages/Unlock Protocol/Runtime/Prefabs`. Select the prefab in the scene, and set the Unlock Paywall component to match the following:

![paywlass](https://user-images.githubusercontent.com/1434865/141599374-20022432-749b-486e-bc25-66408b7a734e.png)

8.) Select `File/Build Settings`, ensure your build target is WebGL, and press `Build and Run` to test the scene.

You should be presented with an empty scene and a button. Upon pressing the button, the payment flow will begin. After succesful payment, the button should then disappear.


---
