import loadjs from '@beyondspace/loadjs'

if (typeof window.ethereum !== 'undefined') {
  window.ethereum.autoRefreshOnNetworkChange = false
}

export async function initializePaywall (paywallConfig) {
  window.unlockProtocolConfig = JSON.parse(paywallConfig)

  await loadjs(window.unlockProtocolConfig.checkoutUrlBase, 'paywall', { returnPromise: true })
  window.unlockProtocol.resetConfig(window.unlockProtocolConfig)

  window.addEventListener('unlockProtocol.status', function (event) {
    window.gameInstance.SendMessage('UnlockPaywall', 'UpdateStatus', event.detail.state)
  })
}

export async function initialize () {
  console.error('Error: calling custom function on Paywall template. Ensure you have the custom WebGL template selected in your Unity build settings.')
}

export async function loadCheckoutModal (lockConfig) {
  const config = JSON.parse(lockConfig)
  window.unlockProtocol.loadCheckoutModal(config)
}
