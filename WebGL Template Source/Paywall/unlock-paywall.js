export async function initializePaywall (paywallConfig) {
  window.unlockProtocolConfig = JSON.parse(paywallConfig)
  window.unlockProtocol.resetConfig(window.unlockProtocolConfig)

  window.addEventListener('unlockProtocol.status', function (event) {
    window.gameInstance.SendMessage('UnlockPaywall', 'UpdateStatus', event.detail.state)
  })

  window.addEventListener('unlockProtocol.authenticated', function (event) {
    window.gameInstance.SendMessage('UnlockPaywall', 'UpdateAddress', event.detail.address)
  })

  window.addEventListener('unlockProtocol.transactionSent', function (event) {
    window.gameInstance.SendMessage('UnlockPaywall', 'UpdateHash', event.detail.hash)
  })
}

export async function loadCheckoutModal (lockConfig) {
  const config = JSON.parse(lockConfig)
  window.unlockProtocol.loadCheckoutModal(config)
}
