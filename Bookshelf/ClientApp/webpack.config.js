var HtmlWebpackPlugin = require('html-webpack-plugin');
const path = require('path');
const agent = require('agentkeepalive');

module.exports = {
    mode: 'development',
    module: {
        rules: [
            {
                test: /\.jsx?$/,
                loader: 'babel-loader'
            },
            {
                test: /\.css$/,
                use: ['style-loader', 'css-loader']
            },
            {
                test: /\.(png|jpg|gif)$/i,
                use: [
                    {
                        loader: 'url-loader',
                        options: {
                            limit: 8192
                        }
                    }
                ]
            }
        ],
    },
    resolve: {
        extensions: ['.js', '.jsx'],
        alias: {
            '@': path.resolve(__dirname, 'src/'),
        }
    },

    plugins: [new HtmlWebpackPlugin({
        template: './src/index.html'
    })],
    devServer: {
        //proxy: {
        //    '*': {
        //        target: 'https://localhost:5001',
        //        changeOrigin: true
        //    },
        //},
        historyApiFallback: true
    },
    externals: {
        // global app config object
        config: JSON.stringify({
            apiUrl: 'https://localhost:5001'
        })
    }
}