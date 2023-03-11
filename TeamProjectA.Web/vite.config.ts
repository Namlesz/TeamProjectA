import {fileURLToPath, URL} from 'node:url'

import {defineConfig} from 'vite'
import vue from '@vitejs/plugin-vue'
import vueJsx from '@vitejs/plugin-vue-jsx'
import Components from 'unplugin-vue-components/vite'

// https://vitejs.dev/config/
export default defineConfig({
    plugins: [vue(), vueJsx(), Components(),],
    resolve: {
        alias: {
            '@': fileURLToPath(new URL('./src', import.meta.url))
        }
    },
    build: {
        outDir: '../TeamProjectA.Api/wwwroot'
    },
    server: {
        proxy: {
            '/api': {
                target: 'https://localhost:7188',
                changeOrigin: true,
                secure: false,
                ws: true,
            }
        }
    }
})
