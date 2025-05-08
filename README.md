# GmsDownloaderDll

This extension for Game Maker Studio uses C#'s WebClient to provide file download functionality with cancellation support - a feature not available in standard GMS functionality. Made it for [Fatalny-Direct](https://github.com/fataliti/Fatalny-Direct)
### `DownloadCreate()`
Creates a new download instance and returns its Id
### `DownloadAddHeader(id, name, value)`
Adds a custom header to download request.
### `DownloadDelete(id)`
Cancels and removes a download instance. If the download is in progress, it will be aborted.
### `DownloadFile(id, link, file_path)`
Starts file download for the specified instance.
### `DownloadGetProgress(id)`
Gets the current download progress percentage `(0-100)`
### `DownloadIsComplete(id)`
Checks the completion status of a download.
- `1.0` - Download completed successfully
- `0.0` - Download in progress 
- `-1.0` - Download failed or was aborted
- `-2.0` - Download Id doesn't exis
### `DownloadGetResult(id)`
Gets the full path to the downloaded file.
