// const { defineConfig } = require('@vue/cli-service')
// module.exports = defineConfig({
//   transpileDependencies: true
// })

module.exports = {
  devServer: {
      open: 'http://localhost:8080/#/login',
      hot: true,
      historyApiFallback: true, 
      
      // publicPath: '/',
      // contentBase: ['./wwwroot']
  },
  transpileDependencies: true
};



