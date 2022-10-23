import WalletConnectProvider from '@walletconnect/web3-provider'
const { WalletService, Web3Service } = require('@unlock-protocol/unlock-js')
const { ethers } = require('ethers')

const gameObjectName = 'UnlockCustom'

let networks
let web3service
let walletService
let provider
let signer

const nativeSymbols = {
  1: 'ETH',
  3: 'ETH',
  4: 'ETH',
  5: 'ETH',
  10: 'ETH',
  42: 'ETH',
  56: 'BSC',
  69: 'ETH',
  100: 'XDAI',
  137: 'MATIC',
  1337: 'ETH',
  31337: 'ETH',
  42161: 'AETH'
}

export async function initialize (networksJson) {
  networks = JSON.parse(networksJson)
  console.log(networks)
  web3service = new Web3Service(networks)
  walletService = new WalletService(networks)
}

export async function initializePaywall () {
  console.error('Error: calling Paywall function on Custom template. Ensure you have the Paywall WebGL template selected in your Unity build settings.')
}

export async function connectMetaMask () {
  provider = new ethers.providers.Web3Provider(window.ethereum, 'any')

  // Subscribe to accounts change
  window.ethereum.on('accountsChanged', (accounts) => {
    window.gameInstance.SendMessage(gameObjectName, 'AccountsChanged', JSON.stringify(accounts))
  })

  // Subscribe to session disconnection
  window.ethereum.on('disconnect', (code, reason) => {
    window.gameInstance.SendMessage(gameObjectName, 'Disconnected')
  })

  try {
    await provider.send('eth_requestAccounts', [])
  } catch (e) {
    console.error(e.message)
    window.gameInstance.SendMessage(gameObjectName, 'ConnectWalletFail', e.message)
    return
  }
  connected()
}

export async function connectWalletConnect () {
  const rpc = {}
  Object.keys(networks).forEach(key => {
    rpc[key] = networks[key].provider
  })

  const walletConnectProvider = new WalletConnectProvider({
    rpc: rpc
  })

  try {
    await walletConnectProvider.enable()
  } catch (e) {
    console.error(e.message)
    window.gameInstance.SendMessage(gameObjectName, 'ConnectWalletFail', e.message)
    return
  }

  // Subscribe to accounts change
  walletConnectProvider.on('accountsChanged', (accounts) => {
    window.gameInstance.SendMessage(gameObjectName, 'AccountsChanged', JSON.stringify(accounts))
  })

  // Subscribe to session disconnection
  walletConnectProvider.on('disconnect', (code, reason) => {
    window.gameInstance.SendMessage(gameObjectName, 'Disconnected')
  })

  provider = new ethers.providers.Web3Provider(walletConnectProvider)
  connected()
}

export async function connected () {
  // on network change
  provider.on('network', (newNetwork, oldNetwork) => {
    if (oldNetwork) {
      window.gameInstance.SendMessage(gameObjectName, 'NetworkChanged', newNetwork.chainId)
    }
  })

  signer = provider.getSigner()
  const address = await signer.getAddress()
  window.gameInstance.SendMessage(gameObjectName, 'ConnectWalletSuccess', address)
}

export async function getLock (lockConfig) {
  const config = JSON.parse(lockConfig)
  const lockAddress = Object.keys(config)[0]
  const network = config[Object.keys(config)[0]].network

  try {
    const lock = await web3service.getLock(lockAddress, network)
    lock.lockAddress = lockAddress

    // Get currency symbol
    if (lock.currencyContractAddress == null) {
      lock.currencySymbol = nativeSymbols[network]
    }

    window.gameInstance.SendMessage(gameObjectName, 'GetLockSuccess', JSON.stringify(lock))
  } catch (e) {
    console.error(e.message)
    window.gameInstance.SendMessage(gameObjectName, 'GetLockFailed', getLockErrorJson(lockAddress, e.message))
  }
}

export async function getHasValidKey (hasValidKeyParamsJson) {
  const hasValidKeyParams = JSON.parse(hasValidKeyParamsJson)
  const lockAddress = hasValidKeyParams.lockAddress
  const network = hasValidKeyParams.network

  try {
    const expiration = await web3service.getKeyExpirationByLockForOwner(
      lockAddress,
      hasValidKeyParams.recipient,
      network
    )

    const now = Math.floor(new Date().getTime() / 1000)

    hasValidKeyParams.hasKey = false
    if (expiration > now) {
      hasValidKeyParams.hasKey = true
    }

    window.gameInstance.SendMessage(gameObjectName, 'GetHasValidKeySuccess', JSON.stringify(hasValidKeyParams))
  } catch (e) {
    console.error(e.message)
    window.gameInstance.SendMessage(gameObjectName, 'GetHasValidKeyFailed', getLockErrorJson(lockAddress, e.message))
  }
}

export async function purchaseKey (lockConfig) {
  const config = JSON.parse(lockConfig)
  const lockAddress = Object.keys(config)[0]
  const referrer = Object.values(config)[0].referrer

  await walletService.connect(provider, signer)

  try {
    await walletService.purchaseKey(
      {
        lockAddress: lockAddress,
        referrer: referrer
      }
    )
    window.gameInstance.SendMessage(gameObjectName, 'PurchaseKeySuccess', lockAddress)
  } catch (e) {
    console.error(e.message)
    window.gameInstance.SendMessage(gameObjectName, 'PurchaseKeyFailed', getLockErrorJson(lockAddress, e.message))
  }
}

export async function getNetworkId () {
  try {
    const { chainId } = await provider.getNetwork()
    window.gameInstance.SendMessage(gameObjectName, 'GetNetworkIdSuccess', chainId)
  } catch (e) {
    console.error(e.message)
    window.gameInstance.SendMessage(gameObjectName, 'GetNetworkIdFailed', e.message)
  }
}

export async function getBalance (address) {
  try {
    provider.getBalance(address).then((balance) => {
      const balanceInEth = ethers.utils.formatEther(balance)
      window.gameInstance.SendMessage(gameObjectName, 'GetBalanceSuccess', parseFloat(balanceInEth))
    })
  } catch (e) {
    console.error(e.message)
    window.gameInstance.SendMessage(gameObjectName, 'GetBalanceFailed', e.message)
  }
}

function getLockErrorJson (lockAddress, error) {
  const obj =
  {
    lockAddress: lockAddress,
    error: error
  }
  return JSON.stringify(obj)
}
