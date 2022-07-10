const path = require('path')
const CopyPlugin = require('copy-webpack-plugin')
const { CleanWebpackPlugin } = require('clean-webpack-plugin')
const TerserPlugin = require('terser-webpack-plugin')
const webpack = require('webpack')

module.exports = {
  target: 'web',
  entry: {
    'Unlock-custom/unlock-custom': './Custom/unlock-custom.js',
    'Unlock-paywall/unlock-paywall': './Paywall/unlock-paywall.js'
  },
  output: {
    path: path.resolve(__dirname, 'lib/'),
    filename: '[name].js',
    library: 'UnlockUnity',
    libraryTarget: 'var'
  },
  plugins: [
    new CopyPlugin({
      patterns: [
        { from: 'Custom/index.html', to: 'Unlock-custom/' },
        { from: 'Custom/thumbnail.png', to: 'Unlock-custom/' },
        { from: 'TemplateData', to: 'Unlock-custom/TemplateData' },
        { from: 'Paywall/index.html', to: 'Unlock-paywall/' },
        { from: 'Paywall/thumbnail.png', to: 'Unlock-paywall/' },
        { from: 'TemplateData', to: 'Unlock-paywall/TemplateData' }
      ]
    }),
    new CleanWebpackPlugin(),
    new webpack.ProvidePlugin({
      Buffer: ['buffer', 'Buffer']
    }),
    new webpack.ProvidePlugin({
      process: 'process/browser'
    })
  ],
  resolve: {
    fallback: {
      os: require.resolve('os-browserify/browser'),
      https: require.resolve('https-browserify'),
      http: require.resolve('stream-http'),
      stream: require.resolve('stream-browserify'),
      util: require.resolve('util/'),
      url: require.resolve('url/'),
      assert: require.resolve('assert/'),
      crypto: require.resolve('crypto-browserify')
    }
  },
  optimization: {
    minimize: false,
    minimizer: [
      new TerserPlugin({
        extractComments: false
      })
    ]
  }
}
