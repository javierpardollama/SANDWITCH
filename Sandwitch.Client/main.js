const { app, BrowserWindow, screen} = require('electron');
const path = require('path');

function createWindow() {
    const size = screen.getPrimaryDisplay().workAreaSize;

    const win = new BrowserWindow({
        x: 0,
        y: 0,
        width: size.width,
        height: size.height,
        webPreferences: {
            nodeIntegration: false,
            contextIsolation: true,
        },
    });

    if (!app.isPackaged) {
        win.loadURL('https://localhost:4200');
        win.webContents.openDevTools();
    } else {
        // Prod build
        const indexPath = path.join(__dirname, 'dist', 'sandwitch.client', 'browser', 'index.html');
        console.log('File loaded: ', indexPath);  // For debugging
        win.loadFile(indexPath);

        // If the download fails, try again or switch to a local file
        win.webContents.on('did-fail-load', () => {
            win.loadFile(indexPath);  // Try to load file again
        });
    }
}

app.whenReady().then(createWindow);

app.on('window-all-closed', () => {
    if (process.platform !== 'darwin') app.quit();
});