export async function initializePaywall (paywallConfig) {
  window.unlockProtocolConfig = JSON.parse(paywallConfig)
  window.unlockProtocol.resetConfig(window.unlockProtocolConfig)

  window.addEventListener('unlockProtocol.status', function (event) {
    console.log(event.detail.state)
    window.gameInstance.SendMessage('UnlockPaywall', 'UpdateStatus', event.detail.state)
  })

  window.addEventListener('unlockProtocol.authenticated', function (event) {
    window.gameInstance.SendMessage('UnlockPaywall', 'UpdateAddress', event.detail.address)
  })

  window.addEventListener('unlockProtocol.transactionSent', function (event) {
    window.gameInstance.SendMessage('UnlockPaywall', 'UpdateHash', event.detail.hash)
  })
}

export async function initialize () {
  console.error('Error: calling custom function on Paywall template. Ensure you have the custom WebGL template selected in your Unity build settings.')
}

export async function loadCheckoutModal (lockConfig) {
  const config = JSON.parse(lockConfig)
  window.unlockProtocol.loadCheckoutModal(config)
}
